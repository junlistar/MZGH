using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class SubSystem : BaseModel
    { 
        public string sys_code { get; set; }
        public string sys_name { get; set; }
        public int sys_no { get; set; }
        public string sys_desc { get; set; }
        public string file_path { get; set; }
        public string file_type { get; set; }
        public string icon_path { get; set; }  
        public int open_mode { get; set; }
        public int active_flag { get; set; }
        public DateTime update_time { get; set; }
        
        public string sys_update_url { get; set; } 
        public string sys_relative_path { get; set; }
        public string sys_group_code { get; set; }
        public string subsys_id { get; set; }
        public string group_no { get; set; }
        
    }

    public class SubSystemGroup : BaseModel
    {
        public string group_code { get; set; }
        public string group_name { get; set; }
        public int active_flag { get; set; }
        public int sort { get; set; } 
        public DateTime update_time { get; set; }
         
    }

    public class MainClientConfig 
    {
        public string id { get; set; }
        public string name { get; set; }
        public string show_image { get; set; }
        public string show_title { get; set; }
        public string title { get; set; }
        public string show_desc { get; set; } 
        public DateTime update_time { get; set; }

    }  
}
