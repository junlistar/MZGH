using System;

namespace Data.Entities.Mzsf
{
    public class OrderType : BaseModel
    {   
        public string code { get; set; }
        public string name { get; set; }
        public string bill_code { get; set; }
        public string group_no { get; set; }
        public string self_flag { get; set; }
        public string drug_cure { get; set; }
        public string max_item { get; set; }
        public string comment { get; set; } 
    }
}
