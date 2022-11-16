using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
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
        public string open_mode_str
        {
            get
            {
                if (open_mode == 1)
                {
                    return "在程序中打开";
                }
                else if (open_mode == 1)
                {
                    return "外部打开";
                }
                return "";
            }
        }
        public int active_flag { get; set; }
        public DateTime update_time { get; set; }

        //检查版本更新地址
        public string system_update_url { get; set; }
    }
}
