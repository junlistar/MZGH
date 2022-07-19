using Client.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class BaseRequestVM
    {
        public string request_sn { get; set; }
        public int week { get; set; }
        public int day { get; set; }

        public string ampm { get; set; }
        public string unit_sn { get; set; }
        public string group_sn { get; set; }

        public string doctor_sn { get; set; }
        public string clinic_type { get; set; }

        public int totle_num { get; set; }
        public string op_id { get; set; }
        public DateTime op_date { get; set; }
        public string open_flag { get; set; }
        public int window_no { get; set; }
        public string workroom { get; set; }
        public string temp_flag { get; set; }
        public int limit_appoint_percent { get; set; }

        public string segment { get; set; }
        public string req_type { get; set; }
        public string req_name { get; set; }


        public int begin_no { get; set; }

        public int current_no { get; set; }
        public int end_no { get; set; }


        //查询显示字段

        public string record_sn { get; set; }
        public string unit_name { get; set; }
        public string group_name { get; set; }
        public string doct_name { get; set; }
        public string clinic_name { get; set; }
        public string weekstr
        {
            get
            {
                switch (week)
                {
                    case 1: return "第一周";
                    case 2: return "第二周";
                    case 3: return "第三周";
                    case 4: return "第四周";
                    case 5: return "第五周";
                    default:
                        return week.ToString();
                }
            }
        }
        public string daystr
        {
            get
            {
                switch (day)
                {
                    case 1: return "星期一";
                    case 2: return "星期二";
                    case 3: return "星期三";
                    case 4: return "星期四";
                    case 5: return "星期五";
                    case 6: return "星期六";
                    case 7: return "星期日";
                    default:
                        return day.ToString();
                }
            }
        }
        public string apstr
        {
            get
            {

                if (SessionHelper.requestHours != null)
                {
                    var req_hour = SessionHelper.requestHours.Where(p => p.code == ampm).FirstOrDefault();
                    if (req_hour != null)
                    { 
                        return req_hour.name;
                    }
                }
                return ampm.ToString(); 
            }
        }
        public string winnostr
        {
            get
            {
                switch (window_no)
                {
                    case 0: return "所有窗口";
                    default:
                        return window_no.ToString();
                }
            }
        }

        public string open_flag_str
        {
            get
            {
                switch (open_flag)
                {
                    case "1": return "开放";
                    case "0": return "不开放";
                    default:
                        return open_flag;
                }
            }
        }

        public string op_date_str
        {
            get { return op_date.ToString("yyyy-MM-dd HH:mm:ss"); }

        }

        public DateTime request_date { get; set; }
        public string request_date_str
        {
            get
            {
                return request_date.ToString("yyyy-MM-dd");
            }
        }


    }


}
