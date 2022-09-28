using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{

    public class GhSearchVM
    {
        public string patient_id { get; set; }

        public string times { get; set; }

        public DateTime? gh_date { get; set; }
        public string gh_time
        {
            get
            {
                if (gh_date.HasValue)
                {
                    return gh_date.Value.ToString("HH:mm:ss");
                }
                return "";
            }
        }
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

        public int ledger_sn { get; set; }
        public string billNo { get; set; }
    }

    public class GhRefundPayVM
    {
        public string patient_id { get; set; }

        public int item_no { get; set; }
        public int ledger_sn { get; set; }
        public int times { get; set; }
        public decimal charge { get; set; }
        public string cheque_type { get; set; }
        public string cheque_name { get; set; }
        public string cheque_no { get; set; }
        public string receipt_sn { get; set; }
        public string receipt_no { get; set; }
        public string price_opera { get; set; }
        public DateTime price_date { get; set; }

        public string out_trade_no { get; set; }
        public string admiss_times { get; set; }
        public string mdtrt_id { get; set; }
        public string psn_no { get; set; }
        public string setl_id { get; set; }

        public string clr_optins { get; set; }

    }
}
