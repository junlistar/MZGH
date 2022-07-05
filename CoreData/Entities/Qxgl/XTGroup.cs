using System;

namespace Data.Entities
{
    public class XTGroup : BaseModel
    {  
        public string subsys_id { get; set; } 
        public int user_group { get; set; }
        public string group_name { get; set; } 

    }
}
