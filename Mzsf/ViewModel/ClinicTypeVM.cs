using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzsf.ViewModel
{
    public class ClinicTypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }

    }
    public class RequestTypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }

    }

    public class UserDicVM
    {
        public string emp_sn { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }

    }

    public class ChargeTypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string cheque_type { get; set; }

    }
    public class DistrictCodeVM
    {

        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string zip_code { get; set; }
        public string gb_code { get; set; }

    }

    public class OccupationCodeVM
    {

        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string flag { get; set; }
        public string group_code { get; set; }
        public string tcmms_code { get; set; }

    }
    public class ResponceTypeVM
    {

        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string response_group { get; set; }

    }

    public class ChargeItemVM
    {
        public decimal charge_price { get; set; }

        public decimal effective_price { get; set; }

        public string audit_code { get; set; }
        public string mz_bill_item { get; set; } 
        public string mz_charge_group { get; set; }

        public string item_no { get; set; }
        public string name { get; set; }
    }
}
