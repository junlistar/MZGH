using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class LoginUsersVM
    {
        public string user_name { get; set; }

        public string subsys_id { get; set; }
        public string user_group { get; set; }

        public string user_mi { get; set; }
        public string dept_sn { get; set; }
        public string name { get; set; }

    }
    public class GhZdRequestType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PyCode { get; set; }
        public string DCode { get; set; }
        public string DeletedFlag { get; set; }
    }

    public class GHRequestVM
    {

        public string record_sn { get; set; }
        public int current_no { get; set; }
        public string unit_name { get; set; }
        public string clinic_name { get; set; }
        public string je { get; set; }
        public string doctor_name { get; set; }
        public string group_name { get; set; }
        public string req_name { get; set; }
        public string ap { get; set; }
        public int end_no { get; set; }

        public DateTime request_date { get; set; }


    }

    public class PatientVM
    {
        public string patient_id { get; set; }
        public string times { get; set; }

        public string name { get; set; }

        public string sex { get; set; }
        public DateTime? birthday { get; set; }
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
        public string max_item_sn { get; set; }
        public string enter_opera { get; set; }
        public string enter_date { get; set; }
        public string update_opera { get; set; }
        public string update_date { get; set; }

        public string yb_psn_no { get; set; }
        public string yb_insuplc_admdvs { get; set; }
        public string yb_insutype { get; set; }

    }


    public class GhDepositVM
    {
        public string patient_id { get; set; }

        public int item_no { get; set; }
        public int ledger_sn { get; set; }
        public int times { get; set; }
        public decimal charge { get; set; }
        public int cheque_type { get; set; }
        public string cheque_no { get; set; }
        public string depo_status { get; set; }
        public string price_opera { get; set; }
        public DateTime price_date
        {
            get; set;
        }
        public string price_date_str
        {
            get
            {
                return price_date.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string mz_dept_no { get; set; }
        public string print_flag { get; set; }
        public string tname { get; set; }
        public string sname { get; set; }




    }


    public class GhRefundVM
    {
        public string visit_date { get; set; }

        public string visit_dept { get; set; }

        public string group_sn { get; set; }
        public string doctor_code { get; set; }
        public string ampm { get; set; }
        public string unit_name { get; set; }
        public string group_name { get; set; }
        public string doctor_name { get; set; }
        public string gh_sequence { get; set; }
        public string patient_id { get; set; }
        public string name { get; set; }

        public string times { get; set; }
        public string charge { get; set; }

        public int ledger_sn { get; set; }

        public int item_no { get; set; }
        public string response_type { get; set; }
        public string charge_type { get; set; }
        public string clinic_type { get; set; }
        public string req_type { get; set; }
        public string clinic_name { get; set; }
        public string request_name { get; set; }
        public string gh_opera { get; set; }
        public DateTime gh_date { get; set; }
        public string gh_date_str { 
            get {
                if (gh_date!= DateTime.MinValue)
                {
                    return gh_date.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return "";
                }
                    
            }
           
        }
        public string gh_sequence_c { get; set; }
        public string cheque_name { get; set; }
        public string cheque_type { get; set; }
        public string cheque_no { get; set; }
        public string receipt_sn { get; set; }
        public string receipt_no { get; set; }
        public string report_date { get; set; }
        public string ic_count { get; set; }
        public string visit_flag { get; set; }
        public string visit_flag_name { get; set; }
        

    }

    public  class RecordTimeSpan
    {
        public string from { get; set; }
        public string from_day { get; set; }
        public string to { get; set; }
        public string to_day { get; set; }
        public string week { get; set; }
        public string day { get; set; }

    }

}
