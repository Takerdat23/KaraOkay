using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Wpf_Karaokay.Model;

namespace Wpf_Karaokay.ViewModel
{
    public class EditEmployeeViewModel : BaseViewModel
    {
        private Employee Employee { get; set; }
        private string _EmpID;
        public string EmpID
        {
            get { return _EmpID; }
            set
            {
                _EmpID = value;
                OnPropertyChanged(nameof(EmpID));
            }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                _EmpName = value;
                OnPropertyChanged(nameof(EmpName));
            }
        }

        private string _CitizenID;
        public string CitizenID
        {
            get { return _CitizenID; }
            set
            {
                _CitizenID = value;
                OnPropertyChanged(nameof(CitizenID));
            }
        }
        private string _EmpPhone;
        public string EmpPhone
        {
            get { return _EmpPhone; }
            set
            {
                _EmpPhone = value;
                OnPropertyChanged(nameof(EmpPhone));
            }
        }

        private DateTime _BirthDate;
        public DateTime BirthDate 
        {
            get { return _BirthDate; }
            set
            {
                _BirthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        private string _PlaceOfOrigin;
        public string PlaceOfOrigin
        {
            get { return _PlaceOfOrigin; }
            set
            {
                _PlaceOfOrigin = value;
                OnPropertyChanged(nameof(PlaceOfOrigin));
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public EditEmployeeViewModel()
        {


            List<Employee> employeesFromDatabase = DataProvider.Ins.DB.Employees.ToList();
            Employees = new ObservableCollection<Employee>(employeesFromDatabase);
            //LoadRooms();

            InsertCommand = new RelayCommand(Insert);
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
            BackCommand = new RelayCommand<Window>(Back);
        }


        private void Insert(object p)
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=KaraOkay;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection connection = new SqlConnection(connectionString))
            // EmpId, EmpName, CCCD, EmpPhone, BirthDate, PlaceOfOrigin, AccountName
            {
                string query = "INSERT INTO Employee (EmpId, EmpName, CCCD, EmpPhone, BirthDate, PlaceOfOrigin, Password) VALUES (@EmpId, @EmpName, @CitizenID, @EmpPhone, @BirthDate, @PlaceOfOrigin, @Password)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpId", EmpID);
                command.Parameters.AddWithValue("@EmpName", EmpName);
                command.Parameters.AddWithValue("@CitizenID", CitizenID);
                command.Parameters.AddWithValue("@EmpPhone", EmpPhone);
                command.Parameters.AddWithValue("@BirthDate", BirthDate);
                command.Parameters.AddWithValue("@PlaceOfOrigin", PlaceOfOrigin);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Notify the UI that the collection has been modified
                    Employee employee = new Employee()
                    {
                        EmpId = EmpID,
                        EmpName = EmpName,
                        CCCD = CitizenID,
                        EmpPhone = EmpPhone,
                        BirthDate = BirthDate,
                        PlaceOfOrigin = PlaceOfOrigin,
                        Password = Password,
                    };
                    Employees.Add(employee);
                    OnPropertyChanged(nameof(Employees));
                    MessageBox.Show("Employee inserted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting employee: {ex.Message}");
                }
            }
        }

        private void Update(object p)
        {

            string connectionString = @"data source=.\sqlexpress;initial catalog=KaraOkay;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employee SET EmpId = @EmpId, EmpName = @EmpName, CitizenID = @CitizenID, EmpPhone = @EmpPhone, BirthDate = @BirthDate, PlaceOfOrigin = @PlaceOfOrigin, Password = @Password WHERE EmpId = @EmpId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpId", EmpID);
                command.Parameters.AddWithValue("@EmpName", EmpName);
                command.Parameters.AddWithValue("@CitizenID", CitizenID);
                command.Parameters.AddWithValue("@EmpPhone", EmpPhone);
                command.Parameters.AddWithValue("@BirthDate", BirthDate);
                command.Parameters.AddWithValue("@PlaceOfOrigin", PlaceOfOrigin);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Update other properties as needed
                    Employee employee = Employees.Where(r => r.EmpId == EmpID).FirstOrDefault();
                    int index = Employees.IndexOf(employee);
                    if (index != -1)
                    {
                        employee.EmpId = EmpID;
                        employee.EmpName = EmpName;
                        employee.CCCD = CitizenID;
                        employee.EmpPhone = EmpPhone;
                        employee.BirthDate = BirthDate;
                        employee.PlaceOfOrigin = PlaceOfOrigin;
                        employee.Password = Password;
                        Employees[index] = employee;
                    }
                    // Notify the UI that the collection has been modified
                    OnPropertyChanged(nameof(Employees));
                    MessageBox.Show("Employee updated successfully!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating employee: {ex.Message}");
                }
            }
        }

        private void Delete(object p)
        {

            string connectionString = @"data source=.\sqlexpress;initial catalog=KaraOkay;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employee WHERE EmpId = @EmpId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpId", EmpID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Notify the UI that the collection has been modified
                    Employee employee = Employees.FirstOrDefault(r => r.EmpId == EmpID);
                    Employees.Remove(employee);
                    OnPropertyChanged(nameof(Employees));
                    MessageBox.Show("Employee deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}");
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
