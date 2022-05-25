using System;

namespace Data.Entities
{
    public class GhRefund : BaseModel
    { 
        public string visit_date { get; set; }
         
        public string visit_dept { get; set; }
         
        public string group_sn { get; set; }
        public string doctor_code { get; set; }
        public string ampm { get; set; }
        public string unit_name { get; set; }
        public string group_name { get; set; }
        public string doctor_name { get; set; }
        public string gh_sequence { get; set; }
        public string patient_id { get; set; }
        public string name { get; set; }

        public string times { get; set; }
        public decimal charge { get; set; }

        public int ledger_sn { get; set; }

        public int item_no { get; set; }
        public string response_type { get; set; }
        public string charge_type { get; set; }
        public string clinic_type { get; set; }
        public string req_type { get; set; }
        public string clinic_name { get; set; }
        public string request_name { get; set; }
        public string gh_opera { get; set; }
        public string gh_date { get; set; }
        public string gh_sequence_c { get; set; }
        public string cheque_name { get; set; }
        public string cheque_type { get; set; }
        public string cheque_no { get; set; } 
        public string receipt_sn { get; set; }
        public string receipt_no { get; set; }
        public string report_date { get; set; }
        public string ic_count { get; set; }
        public string visit_flag { get; set; }
        public string visit_flag_name { get; set; }
        


    }
    
}
