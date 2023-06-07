using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Wpf_Karaokay.Model;
using WPF_Karaokay;



namespace Wpf_Karaokay.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {


        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public ICommand AboutUsCommand { get; set; }
        public Employee SelectedEmployee { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        

        public LoginViewModel()
        {


            NavigationService.RegisterWindow("ManagerForm", typeof(ManagerForm), new ManagerFormViewModel());

            NavigationService.RegisterWindow("RoomsWindow", typeof(RoomsWindows), new RoomsWindowViewModel());


         
            NavigationService.RegisterWindow("AboutUsWindow", typeof(AboutUsWindow), new AboutUsViewModel());


            List<Employee> employeesFromDatabase = DataProvider.Ins.DB.Employees.ToList();
            Employees = new ObservableCollection<Employee>(employeesFromDatabase);


            LoginCommand = new RelayCommand<Window>(Login);

            AboutUsCommand = new RelayCommand(AboutUs);

            PasswordChangedCommand = new RelayCommand<PasswordBox>(UpdatePassword);
        }
        private void UpdatePassword(PasswordBox p)
        {
            Password = p.Password;
        }

        private void Login(Window p)
        {
            if (p==null) { return; }
            // Perform login validation here
            if (Username == "emp00" && Password == "12345678")
            {
                MessageBox.Show("Welcome boss !!!");
                NavigationService.NavigateToWindow("ManagerForm");
                
            
            }
            else
            {
                SelectedEmployee = Employees.FirstOrDefault(x => x.EmpId == Username && x.Password == Password); 
                var accCount = Employees.Where(x => x.EmpId == Username && x.Password == Password).Count();

                if (accCount > 0)
                {
                    MessageBox.Show("Login successful !!");
                    // hide back button in roomswindow

                    object roomVM = new object(); 
                    NavigationService.RegisterWindow("RoomsWindow", typeof(RoomsWindows), new RoomsWindowViewModel());
                    roomVM= NavigationService.GetwindowVM("RoomsWindow");
                    RoomsWindowViewModel VM = roomVM as RoomsWindowViewModel;
                    VM.ChangeBackButtonState(SelectedEmployee); 
                    NavigationService.NavigateToWindow("RoomsWindow");
               
                }
                else
                {   
                    MessageBox.Show("Wrong usename or password !!");}
            }
        }
        private void AboutUs(object parameter) 
        {
            NavigationService.NavigateToWindow("AboutUsWindow");
        }

    }
}

