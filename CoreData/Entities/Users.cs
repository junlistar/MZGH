using System;

namespace Data.Entities
{
    public class LoginUsers : BaseModel
    {
        public string user_name { get; set; }

        public string subsys_id { get; set; }
        public string user_group { get; set; }

        public string user_mi { get; set; }
        public string dept_sn { get; set; }
        public string name { get; set; }

    }

    public class UserDic : BaseModel
    {
        public string emp_sn { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string dept_sn { get; set; }
        public string dept_name { get; set; }
        public string yb_ys_code { get; set; }
    }

    public class UserGroupSystem : BaseModel {

        public string subsys_id { get; set; }
        public string user_group { get; set; }
        public string func_name { get; set; }
        public string sys_type { get; set; }
        public string sys_code { get; set; }
        public string sys_name { get; set; }
        public string group_no { get; set; }
        public string group_code { get; set; }
        public string group_name { get; set; } 
    }

}
