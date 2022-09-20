using Client.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class GHReceiptModelVM
    {
         
        public string patient_id { get; set; }
        public string patient_name { get; set; } 
        public string p_bar_code { get; set; }
        public string receipt_no { get; set; }
        public string receipt_sn { get; set; }
        public string settle_opera { get; set; }
        public string cash_name { get; set; }
        public DateTime price_date { get; set; }
        public int times { get; set; }
        public int ledger_sn { get; set; }
        public decimal charge_total { get; set; } 
    }
}
