using System;
using System.Collections.Generic;
using System.Text;

namespace MzsfData.Entities
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

    }
}
