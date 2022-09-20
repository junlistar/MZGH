using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{

    /// <summary>
    /// 险种类型
    /// </summary>
    public class InsutypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    /// <summary>
    /// 就诊凭证类型
    /// </summary>
    public class MdtrtCertTypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    /// <summary>
    /// 医疗类别
    /// </summary>
    public class MedTypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    //诊断类别
    public class DiagTypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    //计划生育手术类别
    public class BirctrlTypeVM
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    public class IcdCodeVM
    {
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string yb_code { get; set; }
        public string yb_name { get; set; }
    }
    public class YBChargeItem
    {
        public int charge_amount { get; set; }
        public decimal orig_price { get; set; }
        public decimal charge_price { get; set; }
        public string charge_code { get; set; }
        public int caoyao_fu { get; set; }
    }

}
