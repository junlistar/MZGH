using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{

    public class MzThridPayViewVM
    {
        public string patient_id { get; set; }
        public string patient_name { get; set; }

        public string cheque_type { get; set; }
        public string cheque_name { get; set; }

        public string cheque_no { get; set; }
        public string mdtrt_id { get; set; }
        public string ipt_otp_no { get; set; }
        public string psn_no { get; set; }
        public DateTime price_date { get; set; }
        public DateTime? refund_date { get; set; }
        public string opera { get; set; }
        public string opera_name { get; set; }
        public decimal charge { get; set; }
        public string his_no { get; set; }

        public string status
        {
            get
            {
                if (refund_date.HasValue)
                {
                    return "已退费";
                }

                if (string.IsNullOrEmpty(his_no))
                {
                    return "HIS支付失败";
                }
                else
                {
                    return "支付成功";
                }
            }
        }

    }
}
