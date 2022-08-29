using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MzWebReportVM
    {
        public string code { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int open_flag { get; set; }
        public string create_opera { get; set; }
        public string update_opera { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }

    }
}
