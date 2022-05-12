using System;

namespace Data.Entities
{
    public class GhReceiptCharge : BaseModel
    {
        public string code { get; set; }
        public string mz_bill_item { get; set; }  
        public decimal charge_price { get; set; }
          
         
    }
}
