using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFrame.Common
{
    public class TestHisVM
    {
        public string Application { get; set; }
        public string Screen { get; set; }
        public string UserMi { get; set; }
        public string user_mi { get; set; }
        public string user_name { get; set; }
        
        public string AppServer { get; set; }

        public string SubsysRelativePath { get; set; }
        public string group_no { get; set; }//药房编号
        public string group_name { get; set; }//药房名称
        public string subsys_id { get; set; }//关联系统id，xt_user

        public string ParentHandle { get; set; } //父容器句柄
    }

    public class LoginUsersVM
    {
        public string user_name { get; set; }

        public string subsys_id { get; set; }
        public string user_group { get; set; }

        public string user_mi { get; set; }
        public string dept_sn { get; set; }
        public string name { get; set; }

    }
    public class UserDicVM
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


    public class UserGroupSystemVM
    {

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
