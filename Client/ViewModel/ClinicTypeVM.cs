using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
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

        public string dept_sn { get; set; }
        public string dept_name { get; set; }
        public string yb_ys_code { get; set; }
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
        public string charge_code { get; set; } 

        public decimal effective_price { get; set; }

        public string audit_code { get; set; }
        public string mz_bill_item { get; set; } 
        public string mz_charge_group { get; set; }

        public string item_no { get; set; }
        public string name { get; set; }
    }
    public class RelativeCodeVM
    {

        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }

    }
    public class PageChequeCompareVM
    {
        public string his_code { get; set; }
        public int is_show { get; set; }
        public string his_name { get; set; }
        public string page_code { get; set; }
        public string page_name { get; set; }

    }
    public class YbNameVM
    {
        public string code { get; set; }
        public string name { get; set; }
        public string dllname { get; set; }
        public string parms { get; set; }
        public string del_flag { get; set; }
    }

    public class YbhzzdVM
    {
        public string charge_code { get; set; }
        public string searial { get; set; }
        public string ybhz_code { get; set; }
        public string old_code { get; set; }
    }
}
