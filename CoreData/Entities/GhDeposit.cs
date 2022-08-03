using System;

namespace Data.Entities
{
    public class GhDeposit : BaseModel
    { 
        public string patient_id { get; set; }
        public string patient_name { get; set; }

        public int item_no { get; set; }
        public int ledger_sn { get; set; }
        public int times { get; set; }
        public decimal charge { get; set; }
        public int cheque_type { get; set; }
        public string cheque_no { get; set; }
        public string depo_status { get; set; }
        public string price_opera { get; set; }
        public DateTime? price_date { get; set; }
        public string mz_dept_no { get; set; }
        public string report_date { get; set; }
         
        public string print_flag { get; set; }
        public string tname { get; set; }
        public string sname { get; set; }

        public string cheque_name { get; set; } 
        public string receipt_sn { get; set; }
        public string receipt_no { get; set; }
    }

    public class TuiHao : BaseModel
    {
        public string patient_id { get; set; }

        public int item_no { get; set; }
        public int ledger_sn { get; set; }
        public int times { get; set; }
        public decimal charge { get; set; }
        public int cheque_type { get; set; }
        public string cheque_no { get; set; }
        public string depo_status { get; set; }
        public string price_opera { get; set; }
        public DateTime price_date { get; set; }
        public string mz_dept_no { get; set; }
        public string report_date { get; set; }

        public string print_flag { get; set; }
        public string tname { get; set; }
        public string sname { get; set; }


    }
}
