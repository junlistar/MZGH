using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class YbLog
    {
        public int oper_sn { get; set; }
        public DateTime oper_date { get; set; }
        public string oper_code { get; set; }
        public string data { get; set; }
        public string patient_id { get; set; }
        public int admiss_times { get; set; }
        public int flag { get; set; }
        public string msgid { get; set; }
        public string ver { get; set; }
        public string opera { get; set; }
    }
}
