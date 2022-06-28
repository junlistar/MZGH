using System;

namespace Data.Entities.Mzsf
{
    public class MzOrderReceipt : BaseModel
    { 
        public string patient_id { get; set; }
        public string patient_name { get; set; }
        public string social_no { get; set; }
        public string p_bar_code { get; set; }
        public string receipt_no { get; set; }
        public string receipt_sn { get; set; }
        public string cash_opera { get; set; }
        public DateTime cash_date { get; set; }
		public int times { get; set; }
        public decimal charge_total { get; set; }
        public string charge_status { get; set; }
        public int status { get; set; }  
        public int ledger_sn { get; set; }

        public string report_date { get; set; }
        public string cheque_type { get; set; }
        public string cheque_type_name { get; set; }
        public string cash_name { get; set; }
        public string tableflag { get; set; }
        public string responce_group { get; set; }
        public string backfee_date { get; set; }
         
    } 
}
