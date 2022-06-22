using Mzsf.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace Mzsf.ViewModel
{
    public class MzOrderItemVM
    {
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }

        public string specification { get; set; }
        public string orig_price { get; set; }
        public string manufactory { get; set; }
        public int stock_amount { get; set; }
        public string serial { get; set; }
        public string dosage { get; set; }
        public string bill_item_code { get; set; }
        public string audit_code { get; set; }
        public string exec_unit { get; set; }
        public string exec_unit_str { 
            get
            {
                UnitVM mm = SessionHelper.units.Where(m => m.unit_sn == exec_unit).FirstOrDefault();
                if (mm!=null)
                {
                    return mm.name;
                }
                else
                {
                    return exec_unit;
                }
            }
        }

        public string charge_group { get; set; }
        public string self_flag { get; set; }
        public string separate_flag { get; set; }
        public string suprice_flag { get; set; }
        public string drug_flag { get; set; }
        public string mz_confirm_flag { get; set; }
        public string amount1 { get; set; }
        public string amount2 { get; set; }
        public string amount3 { get; set; }
        public string amount4 { get; set; }
        public string amount5 { get; set; }
        public string item_flag { get; set; }
        public string group_no { get; set; }
        public string group_name { get; set; }
    }
}
