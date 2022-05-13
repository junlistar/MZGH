using System;

namespace Data.Entities
{
    public class ChargeItem : BaseModel
    { 
        public decimal charge_price { get; set; }
         
        public decimal effective_price { get; set; }
         
        public string audit_code { get; set; }
        public string mz_bill_item { get; set; }
        public string mz_charge_group { get; set; }
        public string item_no { get; set; }
        public string name { get; set; }

    }
}
