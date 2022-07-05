using System;

namespace Data.Entities
{
    public class XTUser : BaseModel
    { 
        public string user_name { get; set; }
        public string subsys_id { get; set; }
        public string pass_word { get; set; }
        public string user_group { get; set; }
        public string create_pw_date { get; set; } 
        public string user_mi { get; set; }
        public string name { get; set; } 

    }
}
