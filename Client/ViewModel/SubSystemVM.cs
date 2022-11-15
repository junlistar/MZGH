using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainFrame.Common
{
    public class SubSystemVM
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

    }
}
