using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class HisLoginVM
    {
        public string Application { get; set; }
        public string Screen { get; set; }
        public string UserMi { get; set; }
        public string AppServer { get; set; }

        public string SubsysRelativePath { get; set; }
        public string group_no { get; set; }//药房编号
        public string subsys_id { get; set; }//关联系统id，xt_user

    }

 
}
