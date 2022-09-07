using System;

namespace Data.Entities
{
    public class YbkInfo : BaseModel
    { 
        public string psn_no { get; set; }
         
        public string psn_cert_type { get; set; }
         
        public string certno { get; set; }
        public string psn_name { get; set; }
        public string gend { get; set; }
        public string naty { get; set; }
        public string brdy { get; set; }
        public int age { get; set; } 

    }

    /// <summary>
    /// 险种类型
    /// </summary>
    public class Insutype
    {
        public string  code { get; set; }
        public string  name { get; set; }
    }
    /// <summary>
    /// 就诊凭证类型
    /// </summary>
    public class MdtrtCertType
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    /// <summary>
    /// 医疗类别
    /// </summary>
    public class MedType
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    //诊断类别
    public class DiagType
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class IcdCode
    { 
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string yb_code { get; set; }
        public string yb_name { get; set; }
    }

}
