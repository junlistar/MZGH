using System;

namespace MzsfData.Entities
{
    public class ResponceType : BaseModel
    {  
         
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string response_group { get; set; }

    }
}
