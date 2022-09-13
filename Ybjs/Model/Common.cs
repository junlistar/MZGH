using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YbjsLib.Model
{
    internal class Common
    {
    }
    [Serializable]
    public class ComboxItem
    {
        private string _Name = "";
        private object _Value = null;

        public ComboxItem()
        {

        }

        public ComboxItem(string name, object value)
        {
            _Name = name;
            _Value = value;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }

    public class ChargeItemVM
    {
        public decimal charge_price { get; set; }
        public string charge_code { get; set; }

        public decimal effective_price { get; set; }

        public string audit_code { get; set; }
        public string mz_bill_item { get; set; }
        public string mz_charge_group { get; set; }

        public string item_no { get; set; }
        public string name { get; set; }
    }

    public class GHRequestVM
    {

        public string record_sn { get; set; }
        public int current_no { get; set; }
        public string unit_sn { get; set; }
        public string icd_code { get; set; }
        public string unit_name { get; set; }
        public string clinic_name { get; set; }
        public string je { get; set; }
        public string doctor_sn { get; set; }
        public string doctor_name { get; set; }
        public string yb_ys_code { get; set; }

        public string group_name { get; set; }
        public string req_name { get; set; }
        public string ap { get; set; }
        public int end_no { get; set; }

        public DateTime request_date { get; set; }


    }

    public class YbhzzdVM
    {
        public string charge_code { get; set; }
        public string searial { get; set; }
        public string ybhz_code { get; set; }
        public string old_code { get; set; }
    }
    public class UserDicVM
    {
        public string emp_sn { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }

        public string dept_sn { get; set; }
        public string dept_name { get; set; }
        public string yb_ys_code { get; set; }
    }

    public class UnitVM
    {
        public string code { get; set; }

        public string name { get; set; }

        public string py_code { get; set; }
        public string d_code { get; set; }
        public string unit_sn { get; set; }

        public string yb_ks_code { get; set; }
        public string yb_ks_name { get; set; }
    }
}
