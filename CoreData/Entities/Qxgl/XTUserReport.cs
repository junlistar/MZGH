using System;

namespace Data.Entities
{
    public class XTUserReport : BaseModel
    {  
        public string subsys_id { get; set; } 
        public int user_group { get; set; }
        public string report_code { get; set; } 
        public string rep_id { get; set; } 
        public string rep_name { get; set; } 
        public string parent_id { get; set; } 

    }
}
