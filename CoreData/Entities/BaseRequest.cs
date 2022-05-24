using System;

namespace Data.Entities
{
    public class BaseRequest : BaseModel
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
        
        public string segment { get; set; }
        public string req_type { get; set; }
        public int begin_no { get; set; }
        public int current_no { get; set; }

        
        public int end_no { get; set; }


        public string unit_name { get; set; }
        public string group_name { get; set; }
        public string doct_name { get; set; }
        public string clinic_name { get; set; } 
        public string req_name { get; set; }

        public DateTime request_date { get; set; }
        public string record_sn { get; set; }
    }
}
