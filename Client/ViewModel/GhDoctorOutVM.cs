using Client.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class GhDoctorOutVM 
    {
        public string sn { get; set; }
        public string doctor_id { get; set; }
        public string doctor_name { get; set; }

        public DateTime begin_date { get; set; }

        public DateTime end_date { get; set; }

        public int is_delete { get; set; }

        public string del_str
        {
            get
            {
                if (is_delete == 1)
                {
                    return "已删除";
                }
                else
                {
                    return "";
                }
            }
        }

    }
}
