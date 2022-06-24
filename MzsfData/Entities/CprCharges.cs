using System;

namespace MzsfData.Entities
{
    public class CprCharges : BaseModel
    {
        public string charge_code_lookup { get; set; }
        public string exec_SN_lookup { get; set; }

        public string patient_id { get; set; }
        public int times { get; set; }
        public string order_type { get; set; }

        public string order_no { get; set; }
        public string item_no { get; set; }
        public int ledger_sn { get; set; }
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
        public string emergency_flag { get; set; }
        
        public decimal sum_total { get; set; }
        public string response_type { get; set; }
        public string charge_type { get; set; }
        

        public string parent_no { get; set; }
        public string order_properties { get; set; }
        public string skin_test_flag { get; set; }
        public string change_drug_code { get; set; }
        // 省略部分

        

        public int charge_no { get; set; }
        public string mz_dept_no { get; set; }
        public string apply_unit { get; set; }
        public string doctor_code { get; set; }
        public string name { get; set; }



        public string order_sn { get; set; } 


        //退款详情增加字段
        public string back { get; set; }
        public string charge_name { get; set; }
        public string bill_name { get; set; }
        public string haoming_code { get; set; }

        


    }
}
