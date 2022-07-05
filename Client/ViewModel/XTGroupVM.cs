using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class XTGroupVM
    {
        public string subsys_id { get; set; }
        public int user_group { get; set; }
        public string group_name { get; set; }

    }
    public class XTUserVM
    {
        public string user_name { get; set; }
        public string subsys_id { get; set; }
        public string pass_word { get; set; }
        public string user_group { get; set; }
        public string create_pw_date { get; set; }
        public string user_mi { get; set; }
        public string name { get; set; }

    }
    public class XTUserGroupVM
    {
        public string subsys_id { get; set; }
        public int user_group { get; set; }
        public string func_name { get; set; }
        public string func_desc { get; set; }

    }
    public class XTUserReportVM
    {
        public string subsys_id { get; set; }
        public int user_group { get; set; }
        public string report_code { get; set; }
        public string rep_id { get; set; }
        public string rep_name { get; set; }
        public string parent_id { get; set; }

    }
}
