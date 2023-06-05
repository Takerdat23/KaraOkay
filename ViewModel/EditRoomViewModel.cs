using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_Karaokay.Model;
using WPF_Karaokay;


namespace Wpf_Karaokay.ViewModel
{
    public class EditRoomViewModel : BaseViewModel
    {
        private Room Room { get; set; }
        private string _RoomID;
        public string RoomID
        {
            get { return _RoomID; }
            set
            {
                _RoomID = value;
                OnPropertyChanged(nameof(RoomID));
            }
        }

        private string _RoomType;
        public string RoomType
        {
            get { return _RoomType; }
            set
            {
                _RoomType = value;
                OnPropertyChanged(nameof(RoomType));
            }
        }

        private string _RoomStatus;
        public string RoomStatus
        {
            get { return _RoomStatus; }
            set
            {
                _RoomStatus = value;
                OnPropertyChanged(nameof(RoomStatus));
            }
        }
        private string _PricePerHour;
        public string PricePerHour
        {
            get { return _PricePerHour; }
            set
            {
                _PricePerHour = value;
                OnPropertyChanged(nameof(PricePerHour));
            }
        }

        public ObservableCollection<Room> Rooms { get; set; }

        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public EditRoomViewModel()
        {

            
            List<Room> roomsFromDatabase = DataProvider.Ins.DB.Rooms.ToList();
            Rooms = new ObservableCollection<Room>(roomsFromDatabase);
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
            {
                string query = "INSERT INTO Room (RmId, RMStatus, RmType, PricePerHour) VALUES (@RmId, @RMStatus, @RmType, @PricePerHour)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RmId", RoomID);
                command.Parameters.AddWithValue("@RMStatus", RoomStatus);
                command.Parameters.AddWithValue("@RmType", RoomType);
                command.Parameters.AddWithValue("@PricePerHour", PricePerHour);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Notify the UI that the collection has been modified
                    Room room = new Room()
                    {
                        RmId = RoomID,
                        RmType = RoomType,
                        RMStatus = int.Parse(RoomStatus),
                        PricePerHour = int.Parse(PricePerHour)
                    };
                    Rooms.Add(room);
                    OnPropertyChanged(nameof(Rooms));
                    MessageBox.Show("Room inserted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting room: {ex.Message}");
                }
            }
        }

        private void Update(object p)
        {
            
            string connectionString = @"data source=.\sqlexpress;initial catalog=KaraOkay;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Room SET RmId = @RmId, RMStatus = @RMStatus, RmType = @RmType, PricePerHour = @PricePerHour WHERE RmId = @RmId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RmId", RoomID);
                command.Parameters.AddWithValue("@RMStatus", RoomStatus);
                command.Parameters.AddWithValue("@RmType", RoomType);
                command.Parameters.AddWithValue("@PricePerHour", PricePerHour);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Update other properties as needed

                    // Notify the UI that the collection has been modified
                    OnPropertyChanged(nameof(Rooms));
                    MessageBox.Show("Room updated successfully!");
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating room: {ex.Message}");
                }
            }
        }

        private void Delete(object p) 
        {
            
            string connectionString = @"data source=.\sqlexpress;initial catalog=KaraOkay;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Room WHERE RmId = @RmId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RmId", RoomID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Notify the UI that the collection has been modified
                    Room room = Rooms.FirstOrDefault(r => r.RmId == RoomID);
                    Rooms.Remove(room);
                    OnPropertyChanged(nameof(Rooms));
                    MessageBox.Show("Room deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting room: {ex.Message}");
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
