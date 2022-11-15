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
        public string AppServer { get; set; }

        public string SubsysRelativePath { get; set; }
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
}
