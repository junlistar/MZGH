using System;

namespace Data.Entities
{
    public class YbkInfo : BaseModel
    { 
        public string psn_no { get; set; }
         
        public string psn_cert_type { get; set; }
         
        public string certno { get; set; }
        public string psn_name { get; set; }
        public string gend { get; set; }
        public string naty { get; set; }
        public string brdy { get; set; }
        public int age { get; set; } 

    }
}
