using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class CprChargesVM
    {
        public string code { get; set; }
        public string charge_code_lookup { get; set; }
        public string charge_code_lookup_str
        {
            get
            {
                if (parent_no != "0")
                {
                    // return "　　" + charge_code_lookup;
                    return "　└  " + charge_code_lookup;
                }
                else
                {
                    return charge_code_lookup;
                }
            }
        }
        public string exec_SN_lookup { get; set; }

        public string patient_id { get; set; }
        public int times { get; set; }
        public string order_type { get; set; }

        public int order_no { get; set; }
        public int item_no { get; set; }
        public string ledger_sn { get; set; }
        public string charge_code { get; set; }
        public string serial_no { get; set; }
        public string group_no { get; set; }
        public string charge_status { get; set; }
        public string bill_code { get; set; }
        public string audit_code { get; set; }
        public string exec_sn { get; set; }
        public int charge_amount { get; set; }
        public decimal orig_price { get; set; }
        public decimal charge_price { get; set; }
        public string charge_group { get; set; }
        public int caoyao_fu { get; set; }
        public string back_amount { get; set; }
        public string happen_date { get; set; }
        public string price_date { get; set; }
        public string price_opera { get; set; }
        public string enter_date { get; set; }
        public string enter_opera { get; set; }
        public string windows_no { get; set; }
        public string confirm_date { get; set; }
        public string confirm_opera { get; set; }
        public string confirm_name { get; set; }
        public string confirm_win { get; set; }
        public string confirm_flag { get; set; }
        public string trans_flag { get; set; }
        public string trans_times { get; set; }
        public string supply_code { get; set; }
        public string dosage { get; set; }
        public string freq_code { get; set; }
        public string persist_days { get; set; }
        public string dosage_unit { get; set; }
        public string exec_times { get; set; }
        public string comment { get; set; }
        public string fit_type { get; set; }
        public string infant_flag { get; set; }
        public string self_flag { get; set; }
        public string seperate_flag { get; set; }
        public string supprice_flag { get; set; }
        public string poision_flag { get; set; }
        public string slave_flag { get; set; }
        public string ope_flag { get; set; }

        public decimal sum_total { get; set; }
        public string parent_no { get; set; }
        //太多了，暂时省略



        public string apply_unit { get; set; }
        public string doctor_code { get; set; }
        public string name { get; set; }

        public string order_sn { get; set; }


        //退款详情增加字段
        public string back { get; set; }
        public string charge_name { get; set; }
        public string bill_name { get; set; }
        public string haoming_code { get; set; }



        //自定义
        public decimal total_price
        {
            get
            {
                return charge_amount * orig_price * caoyao_fu;
            }
        }

        //是否是退款标记
        public bool is_delete
        {
            get; set;
        }

        public string confirm_flag_str
        {
            get
            {
                //if (hasBackYp &&confirm_flag == "1" && !string.IsNullOrEmpty(confirm_date) && !string.IsNullOrEmpty(confirm_opera))
                //{
                //    return confirm_name + "(" + confirm_date + ")";
                //}
                if (hasBackYp && !string.IsNullOrEmpty(confirm_date) && !string.IsNullOrEmpty(confirm_opera))
                {
                    return confirm_name + "(" + confirm_date + ")";
                }
                return "";
            }
        }

        public bool hasBackYp
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(back) && back != charge_amount.ToString())
                {
                    return true;
                }
                return false;
            }
        }
    }

    public class SFChargeVM
    {
        public string type { get; set; }
        public string type_name { get; set; }
        public decimal charge { get; set; }
    }
}
