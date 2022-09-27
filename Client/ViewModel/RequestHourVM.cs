using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class RequestHourVM
    {
        public int end_hour { get; set; }
        public int start_hour { get; set; }
        public string code { get; set; }
        public string name { get; set; }

        public string desc
        {
            get
            {
                return start_hour + "时-" + end_hour + "时";
            }
        }
    } 
}
