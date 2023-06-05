using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_Karaokay.Model;

namespace Wpf_Karaokay.ViewModel
{
    public class EditMenuViewModel : BaseViewModel
    {
        private Item Item { get; set; }
        private string _ItemID;
        public string ItemID
        {
            get { return _ItemID; }
            set
            {
                _ItemID = value;
                OnPropertyChanged(nameof(ItemID));
            }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                _ItemName = value;
                OnPropertyChanged(nameof(ItemName));
            }
        }

        private string _ItemType;
        public string ItemType
        {
            get { return _ItemType; }
            set
            {
                _ItemType = value;
                OnPropertyChanged(nameof(ItemType));
            }
        }
        private string _ItemPrice;
        public string ItemPrice
        {
            get { return _ItemPrice; }
            set
            {
                _ItemPrice = value;
                OnPropertyChanged(nameof(ItemPrice));
            }
        }

        public ObservableCollection<Item> Items { get; set; }

        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public EditMenuViewModel()
        {


            List<Item> itemsFromDatabase = DataProvider.Ins.DB.Items.ToList();
            Items = new ObservableCollection<Item>(itemsFromDatabase);
            //LoadRooms();

            InsertCommand = new RelayCommand(Insert);
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
            BackCommand = new RelayCommand<Window>(Back);
        }


        private void Insert(object p)
        {

            string connectionString = @"data source=.\sqlexpress;initial catalog=KaraOkay;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            // itemID, itemName, itemType, itemPrice
            {
                string query = "INSERT INTO Items (itemID, itemName, itemType, itemPrice) VALUES (@itemId, @itemName, @itemType, @itemPrice)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemId", ItemID);
                command.Parameters.AddWithValue("@itemName", ItemName);
                command.Parameters.AddWithValue("@itemType", ItemType);
                command.Parameters.AddWithValue("@itemPrice", ItemPrice);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Notify the UI that the collection has been modified
                    Item item = new Item()
                    {
                        itemID = ItemID,
                        itemName = ItemName,
                        itemType = ItemType,
                        itemPrice = int.Parse(ItemPrice)
                    };
                    Items.Add(item);
                    OnPropertyChanged(nameof(Items));
                    MessageBox.Show("Item inserted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting item: {ex.Message}");
                }
            }
        }

        private void Update(object p)
        {

            string connectionString = @"data source=.\sqlexpress;initial catalog=KaraOkay;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            // itemID, itemName, itemType, itemPrice
            {
                string query = "UPDATE Items SET itemID = @itemID, itemName = @itemName, itemType = @itemType, itemPrice = @itemPrice WHERE itemID = @itemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemID", ItemID);
                command.Parameters.AddWithValue("@itemName", ItemName);
                command.Parameters.AddWithValue("@itemType", ItemType);
                command.Parameters.AddWithValue("@itemPrice", ItemPrice);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Update other properties as needed

                    Item item = Items.Where(r => r.itemID == ItemID).FirstOrDefault();
                    int index = Items.IndexOf(item);
                    if (index != -1)
                    {
                        item.itemID = ItemID;
                        item.itemName = ItemName;
                        item.itemType = ItemType;
                        item.itemPrice = int.Parse(ItemPrice);
                        Items[index] = item;
                    }
                    // Notify the UI that the collection has been modified
                    OnPropertyChanged(nameof(Items));
                    MessageBox.Show("Item updated successfully!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating item: {ex.Message}");
                }
            }
        }

        private void Delete(object p)
        {

            string connectionString = @"data source=.\sqlexpress;initial catalog=KaraOkay;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            // itemID, itemName, itemType, itemPrice
            {
                string query = "DELETE FROM Items WHERE itemID = @itemID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemID", ItemID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Notify the UI that the collection has been modified
                    Item item = Items.FirstOrDefault(r => r.itemID == ItemID);
                    Items.Remove(item);
                    OnPropertyChanged(nameof(Items));
                    MessageBox.Show("Item deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting item: {ex.Message}");
                }
            }

        }
        private void Back(Window p)
        {
            NavigationService.RegisterWindow("ManagerForm", typeof(ManagerForm), new ManagerFormViewModel());
            NavigationService.NavigateToWindow("ManagerForm");
     
        }
    }
}
