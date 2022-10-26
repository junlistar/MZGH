﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MzDepositVM
    {
        public decimal amount { get; set; }
        public string patient_id { get; set; }
        public int item_no { get; set; }
        public int ledger_sn { get; set; }
        public string cheque_type { get; set; }
        public string cheque_no { get; set; }
        public decimal charge { get; set; }
        public decimal refund_charge { 
            get
            {
                return charge - amount;
            }
        }
        public int depo_status { get; set; }
        public int windows_no { get; set; }
        public DateTime dcount_date { get; set; }
        public string dcount_id { get; set; }
        public string deposit_no { get; set; }
        public string cheque_name { get; set; }
        public string cheque_flag { get; set; }
        public string mz_dept_no { get; set; }
        public string mdtrt_id { get; set; }
        public string psn_no { get; set; }
        public string setl_id { get; set; } 
        public string admiss_times { get; set; }
        public string clr_optins { get; set; } 
        
        public decimal bcje { get; set; }
        public decimal ytje { get; set; }
    }
}
