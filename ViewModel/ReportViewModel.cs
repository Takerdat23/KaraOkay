using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Wpf_Karaokay.Model;
using System.Runtime.InteropServices.ComTypes;
using LiveCharts;
using LiveCharts.Wpf;

namespace Wpf_Karaokay.ViewModel
{
    public class ReportViewModel:BaseViewModel
    {
        public ICommand ReportCmd { get; private set; }
        public ICommand BackCmd { get; private set; }
        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public List<int> BillAmounts { get; set; }
        public List<string> BillLabels { get; set; }

        

        // ViewModel
        public ReportViewModel()
        {

            BillAmounts = new List<int>();
            BillLabels = new List<string>();


            StartDate = DateTime.Today;
            EndDate = DateTime.Today;

            ReportCmd = new RelayCommand(Report);
            BackCmd = new RelayCommand(backtoPage);

        }

        private List<bill> GetBillsInRange(DateTime startDate, DateTime endDate)
        {
            List<bill> billsInRange = new List<bill>();

            // Assuming you have a collection of all bills available
            List<bill> allBills = DataProvider.Ins.DB.bills.Where(b => b.Billed == true).ToList(); 

            // Iterate over the bills and filter based on the date range
            foreach (bill bill in allBills)
            {
                if (bill.BillDate >= startDate && bill.BillDate <= endDate)
                {
                    billsInRange.Add(bill);

                }
            }

            return billsInRange;
        }

        private void Report(object parameter)
        {
            if(EndDate < StartDate)
            {
                MessageBox.Show("The End date needs to be greater than start date", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            List<bill> BillInRange = GetBillsInRange(StartDate, EndDate);
            BillAmounts = BillInRange
                .GroupBy(bill => bill.BillDate)
                .Select(group => group.Sum(bill => bill.TotalPrice))
                .ToList();

            BillLabels  = BillInRange
                .GroupBy(bill => bill.BillDate)
                .Select(group => group.Key.ToString("d")) 
                .ToList();

            ColumnSeries columnSeries = new ColumnSeries
            {
                Title = "Total price",
                Values = new ChartValues<int>(BillAmounts),
                DataLabels = true,
                LabelPoint = point =>
                {
                    int index = (int)point.X;
                    if (index < BillLabels.Count)
                        return BillLabels[index];
                    else
                        return string.Empty;
                }
            };

            SeriesCollection = new SeriesCollection { columnSeries };
            OnPropertyChanged(nameof(SeriesCollection)); 
        }

        private void backtoPage(object parameter)
        {
            NavigationService.RegisterWindow("ManagerForm", typeof(ManagerForm), new ManagerFormViewModel());
            NavigationService.NavigateToWindow("ManagerForm");
        }
    }
}
