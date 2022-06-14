﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzsf.ViewModel
{
    public class CprChargesVM
    {
        public string charge_code_lookup { get; set; }
        public string exec_SN_lookup { get; set; }

        public string patient_id { get; set; }
        public string times { get; set; }
        public string order_type { get; set; }

        public int order_no { get; set; }
        public string item_no { get; set; }
        public string ledger_sn { get; set; }
        public string charge_code { get; set; }
        public string serial_no { get; set; }
        public string group_no { get; set; }
        public string charge_status { get; set; }
        public string bill_code { get; set; }
        public string audit_code { get; set; }
        public string exec_sn { get; set; }
        public int charge_amount { get; set; }
        public string orig_price { get; set; }
        public decimal charge_price { get; set; }
        public string charge_group { get; set; }
        public string caoyao_fu { get; set; }
        public string back_amount { get; set; }
        public string happen_date { get; set; }
        public string price_date { get; set; }
        public string price_opera { get; set; }
        public string enter_date { get; set; }
        public string enter_opera { get; set; }
        public string windows_no { get; set; }
        public string confirm_date { get; set; }
        public string confirm_opera { get; set; }
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
        //太多了，暂时省略



        public string apply_unit { get; set; }
        public string doctor_code { get; set; }
        public string name { get; set; }



        public string order_sn { get; set; }


        //自定义
        public decimal total_price { get
            {
                return charge_amount * charge_price;
            } }

    }

    public class SFChargeVM
    {
        public string type { get; set; }
        public string type_name { get; set; }
        public decimal charge { get; set; }
    }
}
