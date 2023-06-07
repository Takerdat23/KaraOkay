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


            NavigationService.RegisterWindow("RoomsWindow", typeof(RoomsWindows), new RoomsWindowViewModel());

            NavigationService.RegisterWindow("RoomsWindow", typeof(RoomsWindows), new RoomsWindowViewModel());


            // NavigationService.RegisterWindow("MiddleWindow", typeof(MiddleWindow), new MiddleWindowViewModel());
            NavigationService.RegisterWindow("AboutUsWindow", typeof(AboutUsWindow), new AboutUsViewModel());

            List<Employee> employeesFromDatabase = DataProvider.Ins.DB.Employee.ToList();
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
                MessageBox.Show("Bạn là admin. Login thành công");
                NavigationService.NavigateToWindow("ManagerForm");
                p.Close();
            }
            else
            {
                var accCount = Employees.Where(x => x.EmpId == Username && x.Password == Password).Count();
                if (accCount > 0)
                {
                    MessageBox.Show("Bạn là nhân viên. Login thành công");
                    NavigationService.NavigateToWindow("RoomsWindow");
                }
                else
                {   
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");}
            }
        }
        private void AboutUs(object parameter) 
        {
            NavigationService.NavigateToWindow("AboutUsWindow");
        }

    }
}

