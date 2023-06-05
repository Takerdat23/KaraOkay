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
        public Account SelectedAccount { get; set; }
        public ObservableCollection<Account> Accounts { get; set; }

        public LoginViewModel()
        {


            NavigationService.RegisterWindow("RoomsWindow", typeof(RoomsWindows), new RoomsWindowViewModel());


            // NavigationService.RegisterWindow("MiddleWindow", typeof(MiddleWindow), new MiddleWindowViewModel());
            NavigationService.RegisterWindow("ManagerForm", typeof(ManagerForm), new ManagerFormViewModel());

            List<Account> accountsFromDatabase = DataProvider.Ins.DB.Accounts.ToList();
            Accounts = new ObservableCollection<Account>(accountsFromDatabase);

            LoginCommand = new RelayCommand<Window>(Login);

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
            if (Username == "emp00" && Password == "1234")
            {
                MessageBox.Show("Bạn là admin. Login thành công");
                NavigationService.NavigateToWindow("ManagerForm");
                p.Close();
            }
            else
            {
                var accCount = Accounts.Where(x => x.UserName == Username && x.Password == Password).Count();

                if (accCount > 0)
                {
                    MessageBox.Show("Bạn là nhân viên. Login thành công");
                    NavigationService.NavigateToWindow("RoomsWindow");
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }
        }

    }
}

