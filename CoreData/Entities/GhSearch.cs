using System;

namespace Data.Entities
{
    public class GhSearch : BaseModel
    {
        public string patient_id { get; set; }

        public string times { get; set; }

        public string gh_date { get; set; }
        public string patient_name { get; set; }
        public string gh_sequence { get; set; }
        public string visit_flag { get; set; }
        public string unit_name { get; set; }
        public string clinic_name { get; set; }
        public string doctor_name { get; set; }
        public string group_name { get; set; }
        public string req_name { get; set; }
        public string response_name { get; set; }
        public string charge_name { get; set; } 

        public string haoming_name { get; set; }
        public string opera_name { get; set; }

        public string ampm { get; set; }
        public string gh_order { get; set; }
        public string gh_sequence_f { get; set; }

        public string visit_status { get; set; }
        public string flag { get; set; }
        public decimal charge_fee { get; set; }
        public string receipt_sn { get; set; }
        public string receipt_no { get; set; }
        public string p_bar_code { get; set; }



    }
}
