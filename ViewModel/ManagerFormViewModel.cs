using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_Karaokay.Model;
using WPF_Karaokay;

namespace Wpf_Karaokay.ViewModel
{
    public class ManagerFormViewModel : BaseViewModel
    {
        public ICommand CashierCmd { get; private set; }
        public ICommand RoomCmd { get; private set; }
        public ICommand MenuCmd { get; private set; }
        public ICommand EmployCmd { get; private set; }
        public ICommand ReportCmd { get; private set; }

        public ICommand LogOutCommand { get; private set; }



        public ManagerFormViewModel() {

            

            NavigationService.RegisterWindow("RoomsWindow", typeof(RoomsWindows), new RoomsWindowViewModel());

            NavigationService.RegisterWindow("ReportWindow", typeof(ReportWindow), new ReportViewModel());

            NavigationService.RegisterWindow("EditRoom", typeof(EditRoom), new EditRoomViewModel());
            NavigationService.RegisterWindow("EditMenu", typeof(EditMenu), new EditMenuViewModel());

            NavigationService.RegisterWindow("EmployeeWindow", typeof(EditEmployee), new EditEmployeeViewModel());

            NavigationService.RegisterWindow("EditMenu", typeof(EditMenu), new EditMenuViewModel());

            NavigationService.RegisterWindow("EditEmployee", typeof(EditEmployee), new EditEmployee());

            NavigationService.RegisterWindow("LoginWindow", typeof(LoginWindow), new LoginViewModel());


            CashierCmd = new RelayCommand(SwitchToRoomWindows);
            RoomCmd = new RelayCommand(SwitchToEditRoom);
            MenuCmd = new RelayCommand(SwitchToEditMenu);
            EmployCmd = new RelayCommand(SwitchToEmployee);
            ReportCmd = new RelayCommand(SwitchToReport);
            LogOutCommand = new RelayCommand(LogOut);
        }

        private void SwitchToRoomWindows(object parameter)
        {



            // Close the current window
           
            NavigationService.NavigateToWindow("RoomsWindow");
          
           // Show the new window
            //roomsWindow.Show();
        }

        private void SwitchToEditRoom(object parameter)
        {

            
            NavigationService.NavigateToWindow("EditRoom");

        }

        private void SwitchToEditMenu(object parameter)
        {
            
            
            NavigationService.NavigateToWindow("EditMenu");
         

        }

        private void SwitchToEmployee(object parameter)
        {
            NavigationService.NavigateToWindow("EmployeeWindow");
        }

        private void SwitchToReport(object parameter)
        {
            NavigationService.NavigateToWindow("ReportWindow");
        }

        private void LogOut(object parameter) 
        {
            NavigationService.NavigateToWindow("LoginWindow");
        }



    }
}
