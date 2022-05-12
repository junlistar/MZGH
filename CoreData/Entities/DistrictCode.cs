using System;

namespace Data.Entities
{
    public class DistrictCode : BaseModel
    {  
         
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string zip_code { get; set; }
        public string gb_code { get; set; }

    }
}
