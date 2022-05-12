using System;

namespace Data.Entities
{
    public class GhRequest : BaseModel
    {
        public string record_sn { get; set; }


        public string unit_name { get; set; }
        public string clinic_name { get; set; }
        public decimal je { get; set; }

        public string doctor_name { get; set; }
        public string group_name { get; set; }

        public string req_name { get; set; }
        public string ap { get; set; }

        public string ampm { get; set; }
        public string unit_sn { get; set; }
        public string group_sn { get; set; }
        public string doctor_sn { get; set; }
        public string clinic_type { get; set; }
        public string req_type { get; set; }
        public DateTime request_date { get; set; }

        public int end_no { get; set; }
        public int begin_no { get; set; }
        public int current_no { get; set; }
        public string enter_opera { get; set; }
        public string enter_date { get; set; }
        public string open_flag { get; set; }
        public string window_no { get; set; }



    }
}
