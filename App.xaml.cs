using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Karaokay.Model;
using System.Windows.Navigation;
using Wpf_Karaokay.ViewModel;
using WPF_Karaokay;

namespace Wpf_Karaokay
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
  
    public partial class App : Application
    {
        public TimerService TimerService { get; private set; }
     

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the TimerService
            TimerService = new TimerService();

            // Create an instance of your NavigationService
     


        }
    }
}
