using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class OrderTypeVM
    { 
        public string code { get; set; }
        public string name { get; set; }
        public string bill_code { get; set; }
        public string group_no { get; set; }
        public string self_flag { get; set; }
        public string drug_cure { get; set; }
        public string max_item { get; set; }
        public string comment { get; set; }
    }
}
