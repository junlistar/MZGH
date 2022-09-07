using System;

namespace Data.Entities
{
    public class Unit : BaseModel
    { 
        public string code { get; set; }
         
        public string name { get; set; }
         
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string unit_sn { get; set; }

        public string yb_ks_code { get; set; }
        public string yb_ks_name { get; set; }
    }
}
