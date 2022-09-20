using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class PageChequeCompare : BaseModel
    {
        public string his_code { get; set; }
        public int is_show { get; set; }
        public string his_name { get; set; }
        public string page_code { get; set; }
        public string page_name { get; set; }

    }

    public class YbName : BaseModel
    {
        public string code { get; set; }
        public string name { get; set; }
        public string dllname { get; set; }
        public string parms { get; set; }
        public string del_flag { get; set; } 
    }

    public class Common
    {

    }
}
