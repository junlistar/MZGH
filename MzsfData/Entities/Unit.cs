using System;

namespace MzsfData.Entities
{
    public class Unit : BaseModel
    { 
        public string code { get; set; }
         
        public string name { get; set; }
         
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string unit_sn { get; set; }
         
    }
}
