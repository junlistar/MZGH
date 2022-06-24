using System;

namespace MzsfData.Entities
{
    public class DetailChargeItem : BaseModel
    { 
        public string patient_id { get; set; }
        public string times { get; set; }
        public string order_type { get; set; }
        public string order_no { get; set; }

        public string bill_code { get; set; }
        public decimal charge { get; set; }  

        public string exec_sn { get; set; }



    }
}
