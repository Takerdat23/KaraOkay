using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Karaokay.ViewModel
{
   public class FinalBillViewModel:BaseViewModel
    {
        public string FinalReceipt { get; set; }

        public FinalBillViewModel()
        {
        }

        public void GetFinalBill(String receiptText)
        {
            FinalReceipt = receiptText;
            OnPropertyChanged(nameof(FinalReceipt));
        }
    }
}
