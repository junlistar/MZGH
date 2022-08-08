using System;

namespace Data.Entities
{
    public class MzThridPay : BaseModel
    { 
        public string patient_id { get; set; }
         
        public string cheque_type { get; set; }
         
        public string cheque_no { get; set; }
        public string mdtrt_id { get; set; }
        public string ipt_otp_no { get; set; }
        public string psn_no { get; set; }
        public DateTime price_date { get; set; }
        public string refund_date { get; set; }
        public string opera { get; set; }
        public decimal charge { get; set; } 
    }

    public class MzThridPayView : BaseModel
    {
        public string patient_id { get; set; }
        public string patient_name { get; set; }

        public string cheque_type { get; set; }
        public string cheque_name { get; set; } 

        public string cheque_no { get; set; }
        public string mdtrt_id { get; set; }
        public string ipt_otp_no { get; set; }
        public string psn_no { get; set; }
        public DateTime price_date { get; set; }
        public string refund_date { get; set; }
        public string opera { get; set; }
        public decimal charge { get; set; } 
        public string his_no { get; set; }

    }
}
