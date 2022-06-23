using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzsf.ViewModel
{
    public class MzOrderReceiptVM
    {
        public string patient_id { get; set; }
        public string patient_name { get; set; }
        public string social_no { get; set; }
        public string p_bar_code { get; set; }
        public string receipt_no { get; set; }
        public string receipt_sn { get; set; }
        public string cash_opera { get; set; }
        public DateTime cash_date { get; set; }
        public int times { get; set; }
        public int ledger_sn { get; set; }
        public decimal charge_total { get; set; }
        public string charge_status { get {

                //if (!string.IsNullOrEmpty(backfee_date))
                //{
                //    return "退费";
                //}
                //else
                //{
                //    return "收费";
                //}
                if (charge_total<0)
                {
                    return "退费";
                }
                else
                {
                    return "收费";
                }
            } }
        public int status { get; set; }

        public string report_date { get; set; }
        public string cheque_type { get; set; }
        public string cheque_type_name { get; set; }
        public string cash_name { get; set; }
        public string tableflag { get; set; }
        public string responce_group { get; set; }
        public string backfee_date { get; set; }
        
    }
}
