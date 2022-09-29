using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class SysConfig : BaseModel
    { 
        public string comment { get; set; }
        public string current_settings { get; set; }
        public string current_value { get; set; }
        public string item_name { get; set; }
        public string subsys_id { get; set; } 

    }
     
}
