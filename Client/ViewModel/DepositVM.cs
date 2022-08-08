using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class DepositVM
    {
        public string patient_name { get; set; }
        public string patient_id { get; set; }
        public int ledger_sn { get; set; }
        public int cheque_type { get; set; }
        public string cheque_name { get; set; }
        public string cheque_no { get; set; }
        public decimal charge { get; set; }
        public int depo_status { get; set; }
       
        public string price_opera { get; set; }
        public DateTime price_date { get; set; }
        public string mz_dept_no { get; set; }
    }
}
