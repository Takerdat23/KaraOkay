using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Wpf_Karaokay.Model;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;

namespace Wpf_Karaokay.ViewModel
{
    public class CashierViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<BillDetail> BillDetails { get; set; }
        public ICommand TimerCommand { get; private set; }
        public ICommand StopTimmerCommand { get; private set; }
        public ICommand BackCommand { get; set; }
        public ICommand DecreaseQuantityCommand { get; private set; }
        public ICommand IncreaseQuantityCommand { get; private set; }

        public ObservableCollection<Item> FoodItems { get; set; }
        public ObservableCollection<Item> BeverageItems { get; set; }
        public ObservableCollection<Item> OthersItems { get; set; }

        public Room CurrentRoom { get; set; }

        public String RoomName { get; set; }

        public bill CurrentBill { get; set; }

        public List<BillDetail> CurrentReceipt { get; set; }

        public string receiptText { get; set; }

        private readonly TimerService _timerService;



        public String ElapsedTimeForRoom { get; set; }

        public CashierViewModel()
        {
            //Load the current room 
            Items = new ObservableCollection<Item>(DataProvider.Ins.DB.Items.ToList());
            FoodItems = new ObservableCollection<Item>(Items.Where(i => i.itemType == "food"));
            BeverageItems = new ObservableCollection<Item>(Items.Where(i => i.itemType == "beverage"));
            OthersItems = new ObservableCollection<Item>(Items.Where(i => i.itemType == "others"));

            DecreaseQuantityCommand = new RelayCommand<Item>(DecreaseQuantity);
            IncreaseQuantityCommand = new RelayCommand<Item>(IncreaseQuantity);
            TimerCommand = new RelayCommand<Room>(StartTimer);
            StopTimmerCommand = new RelayCommand<Room>(StopTimer);
            BackCommand = new RelayCommand<Window>(BackButton);

            CurrentReceipt= new List<BillDetail>();
           //get timer 
           var app = Application.Current as App;
            _timerService = app.TimerService;
        }


        private void DecreaseQuantity(Item item)
        {
            if (CurrentBill == null)
            {
                MessageBox.Show("The room haven't started yet!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                BillDetail BillDetailWithOrder = CurrentReceipt.FirstOrDefault(bd => bd.OrderID == item.itemID);
                if (BillDetailWithOrder == null)
                {
                    MessageBox.Show("No Item've chosen yet!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    BillDetailWithOrder.Quantity--;
                    if (BillDetailWithOrder.Quantity < 0)
                    {
                        BillDetailWithOrder.Quantity = 0;
                    }
                    
                    this.PrintReceipt(CurrentReceipt);
                }
            }
            
        }

        private void IncreaseQuantity(Item item)
        {

            if (CurrentBill== null)
            {
                MessageBox.Show("The room haven't started yet!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //get the orderID 
                BillDetail BillDetailWithOrder = CurrentReceipt.FirstOrDefault(bd => bd.OrderID == item.itemID);
                if (BillDetailWithOrder == null)
                {
                    BillDetail BillDetailForItem = new BillDetail();
                    BillDetailForItem.BillID = CurrentBill.BillID;
                    BillDetailForItem.OrderID = item.itemID;
                    BillDetailForItem.Quantity = 1;
                    BillDetailForItem.TotalPrice = item.itemPrice * BillDetailForItem.Quantity;
                    CurrentReceipt.Add(BillDetailForItem);
                    
                    
             
                    this.PrintReceipt(CurrentReceipt);
                }
                else
                {
                    BillDetailWithOrder.Quantity++;
          
                    this.PrintReceipt(CurrentReceipt);
                }
            }
            
        }


        private void StartTimer(Room room )
        {
            this.CreateBillDetails();
            room = CurrentRoom; 
            
            _timerService.StartTimerForRoom(room, TimerCallback);
            room.RMStatus = 1; 

        }

        private void StopTimer(Room room)
        {
            if (CurrentRoom.RMStatus == 0)
            {
                MessageBox.Show("The timer haven't started yet", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return; 
            }

            StringBuilder receiptBuilder = new StringBuilder();

            room = CurrentRoom;
            int seconds = _timerService.GetElapsedSeconds(room);
            _timerService.StopTimerForRoom(room);
            room.RMStatus = 0;
            ElapsedTimeForRoom = "0 Seconds";  
            OnPropertyChanged(nameof(ElapsedTimeForRoom));
            CurrentBill.OrderPice = 0;
            int roomPrice = (int)room.PricePerHour;
            if (CurrentReceipt == null)
            {
                CurrentBill.OrderPice = 0;
            }
            else
            {
                foreach (BillDetail billd in CurrentReceipt)
                {
                    CurrentBill.OrderPice += (billd.TotalPrice * billd.Quantity);
                }
            }
            
            int orderPrice = (int)CurrentBill.OrderPice;
            CurrentBill.TotalPrice = ((seconds / 3600) * roomPrice) + orderPrice;
            // set the billed field to true 
            CurrentBill.Billed = true; 
            DataProvider.Ins.DB.SaveChanges();  

            
            receiptBuilder.AppendLine(receiptText);
            receiptBuilder.AppendLine($"Time : {seconds}");
            receiptBuilder.AppendLine($"Room price per hour : {roomPrice}");
            receiptBuilder.AppendLine($"Total: {CurrentBill.TotalPrice}");

            string FinalBill = receiptBuilder.ToString();
            FinalBill finalbill = new FinalBill();
            FinalBillViewModel FinalviewModel = new FinalBillViewModel();
            FinalviewModel.GetFinalBill(FinalBill);
            finalbill.DataContext = FinalviewModel;
            finalbill.Show();

            CurrentReceipt = null;
            this.PrintReceipt(CurrentReceipt);


        }

        private void TimerCallback(Room room)
        {
            int elapsedSeconds = _timerService.GetElapsedSeconds(room);

            // Update UI or perform other actions based on the elapsed time

            ElapsedTimeForRoom= elapsedSeconds.ToString();

            ElapsedTimeForRoom = ElapsedTimeForRoom + " Seconds"; 
            OnPropertyChanged(nameof(ElapsedTimeForRoom));
        }

        public void LoadSavedBillDetails(Room room)
        {
            

            // get the bill info 
            CurrentBill = DataProvider.Ins.DB.bills.FirstOrDefault(b => (b.RmId == room.RmId) && (b.Billed == false));
            if (CurrentBill != null)
            {
                CurrentReceipt = DataProvider.Ins.DB.BillDetails.Where(bd => bd.BillID == CurrentBill.BillID).ToList();
                if (CurrentReceipt != null)
                {
                    this.PrintReceipt(CurrentReceipt);
                }
                // load to the receipt text box and calculate the total order price 
            }
            else
            {
                MessageBox.Show("No bill has been made", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                room.RMStatus = 0;

                DataProvider.Ins.DB.SaveChanges();
            }
        }

        public void GetCurrntRoom(Room room)
        {
            //Load current room 
            CurrentRoom = room;
            RoomName = "Room " + CurrentRoom.RmId;
        }

        // print to the temporary bill 
        public void PrintReceipt(List<BillDetail> billdetails)
        {
            StringBuilder receiptBuilder = new StringBuilder();

            if(billdetails== null)
            {
                receiptBuilder.AppendLine(""); 
            }
            else
            {
                foreach (BillDetail billDetail in billdetails)
                {
                    // get item base on the OrderId 
                    Item item = DataProvider.Ins.DB.Items.FirstOrDefault(i => (i.itemID == billDetail.OrderID));
                    //calculate the bill orderprice 
                    CurrentBill.OrderPice += item.itemPrice * billDetail.Quantity;
                    receiptBuilder.AppendLine($"Item: {item.itemName}, Quantity: {billDetail.Quantity}, Price: {item.itemPrice * billDetail.Quantity}");
                }
            }
            

            string receipt = receiptBuilder.ToString();
            receiptText = receipt;
            OnPropertyChanged(nameof(receiptText));
        }


        private void CreateBillDetails()
        {
            CurrentBill = new bill();
            string billId = Guid.NewGuid().ToString();
            DateTime billDate = DateTime.Now;
            CurrentBill.BillID = billId;
            CurrentBill.BillDate = billDate;
            CurrentBill.Billed = false;
            CurrentBill.OrderPice = 0;
            CurrentBill.TotalPrice = 0;
            CurrentBill.RmId = CurrentRoom.RmId;

            DataProvider.Ins.DB.bills.Add(CurrentBill);
            DataProvider.Ins.DB.SaveChanges(); 
           
        }



        private void BackButton(object parameter)
        {
            
            NavigationService.NavigateToWindow("RoomsWindow");
        }


        

    }
}