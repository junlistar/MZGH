using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MzClientConfigVM
    {
        public string sys_type { get; set; }
        public string client_name { get; set; }
        public string client_version { get; set; }
        public int client_ghsearchkey_length { get; set; }
        public DateTime update_time { get; set; }

        public string mzgh_report_code { get; set; }
        public string mzsf_report_code { get; set; }
        public string ghrj_report_code { get; set; }
        public string sfrj_report_code { get; set; }
        
    }
}
