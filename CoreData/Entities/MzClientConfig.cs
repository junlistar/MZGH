using System;

namespace Data.Entities
{
    public class MzClientConfig : BaseModel
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
