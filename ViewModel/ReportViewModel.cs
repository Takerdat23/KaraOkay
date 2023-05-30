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

namespace Wpf_Karaokay.ViewModel
{
    public class ReportViewModel:BaseViewModel
    {

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }
        public ReportViewModel()
        {
            DateTime startDate = StartDate;
            DateTime endDate = EndDate;
            List<bill> BillInRange = GetBillsInRange(startDate, endDate);
        }

        private List<bill> GetBillsInRange(DateTime startDate, DateTime endDate)
        {
            List<bill> billsInRange = new List<bill>();

            // Assuming you have a collection of all bills available
            List<bill> allBills = DataProvider.Ins.DB.bills.ToList();

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
    }
}
