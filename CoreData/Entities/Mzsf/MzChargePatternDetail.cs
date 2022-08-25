using System;
namespace Data.Entities.Mzsf
{
    public class MzChargePatternDetail : BaseModel
    { 
        public string charge_name { get; set; }
         
        public string order_name { get; set; }
         
        public string code { get; set; }
        public string order_type { get; set; }
        public string charge_code { get; set; }
        public string serial { get; set; }
        public int quantity { get; set; }
        public int selected { get; set; }
        public decimal price { get; set; }
        public string exec_dept { get; set; }
        public int sort_no { get; set; }
        public decimal orig_price { get; set; }
        public string bill_item_code { get; set; }
        public string audit_code { get; set; }
        public string charge_group { get; set; }
        public int self_flag { get; set; }
        public int separate_flag { get; set; }
        public int suprice_flag { get; set; }
        public int drug_flag { get; set; }
        public int mz_confirm_flag { get; set; }
        public string exec_unit { get; set; } 

    }
}
