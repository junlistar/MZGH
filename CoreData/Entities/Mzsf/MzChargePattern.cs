using System;
namespace Data.Entities.Mzsf
{
    public class MzChargePattern : BaseModel
    { 
        public string code { get; set; }
         
        public string name { get; set; }
         
        public string py_code { get; set; }
        public string d_code { get; set; }
        public int prompt_flag { get; set; } 

    }
}
