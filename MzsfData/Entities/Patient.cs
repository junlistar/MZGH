using System;

namespace MzsfData.Entities
{
    public class Patient : BaseModel
    { 
        public string patient_id { get; set; }
        public string times { get; set; }

        public string name { get; set; }

        public string sex { get; set; }
        public string birthday { get; set; }
        public string age { get; set; }
        public string response_type { get; set; }
        public string contract_code { get; set; }
        public string occupation_type { get; set; }
        public string charge_type { get; set; }
        public string haoming_code { get; set; }
        public string code { get; set; }
        public string inpatient_no { get; set; }
        public string visit_date { get; set; }
        public string social_no { get; set; }
        public string real_haoming_code { get; set; }
        public string home_district { get; set; }
        public string home_street { get; set; }
        public string relation_tel { get; set; }
        public string hic_no { get; set; }
        public string addition_no1 { get; set; }
        public string home_tel { get; set; }
        public string relation_name { get; set; }
        public string relation_code { get; set; }
        public string real_times { get; set; }
        public string max_times { get; set; }
        public string p_bar_code { get; set; }
        public string p_bar_code2 { get; set; }
        public string address { get; set; }
        public string poverty_code { get; set; }
        public string employer_name { get; set; }
        public string employer_street { get; set; }
        public string employer_district { get; set; }
        public string employer_tel { get; set; }
        public string allergic_diag { get; set; } 
        public string marry_code { get; set; }
        public string max_ledger_sn { get; set; }
        public string max_receipt_sn { get; set; }
        public int max_item_sn { get; set; }
        public string enter_opera { get; set; }
        public string enter_date { get; set; }
        public string update_opera { get; set; }
        public string update_date { get; set; }


        public string yb_psn_no { get; set; }
        public string yb_insuplc_admdvs { get; set; }
        public string yb_insutype { get; set; }
    }
}
