using System;

namespace Data.Entities
{
    public class XTUserGroup : BaseModel
    {  
        public string subsys_id { get; set; } 
        public int user_group { get; set; }
        public string func_name { get; set; } 
        public string func_desc { get; set; } 
        public int action_flag { get; set; }

        public string sys_type {  get; set; }

    }
}
