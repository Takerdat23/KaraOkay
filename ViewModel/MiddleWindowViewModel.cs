using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_Karaokay;


namespace Wpf_Karaokay.ViewModel
{
    public class MiddleWindowViewModel : BaseViewModel
    {
        public ICommand AdminCommand { get; private set; }
        public ICommand CashierCommand { get; private set; }

        public MiddleWindowViewModel() 
        {
            NavigationService.RegisterWindow("RoomsWindow", typeof(RoomsWindows), new RoomsWindowViewModel());

            NavigationService.RegisterWindow("ManagerForm", typeof(ManagerForm), new ManagerFormViewModel());

            AdminCommand = new RelayCommand(SwitchToAdmin);

            CashierCommand = new RelayCommand(SwitchToCashier);
        }

        private void SwitchToAdmin(object p) 
        {
            NavigationService.NavigateToWindow("ManagerForm");
        }

        private void SwitchToCashier(object p)
        {
            NavigationService.NavigateToWindow("RoomsWindow");
        }
    }
}
