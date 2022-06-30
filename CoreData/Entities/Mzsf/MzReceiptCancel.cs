using System;

namespace Data.Entities.Mzsf
{
    public class MzReceiptCancel : BaseModel
    {
        //public string operator { get; set; }
        public string happen_date { get; set; }
        public string report_date { get; set; }
        public int receipt_sn { get; set; }
        public string receipt_no { get; set; }
        public string subsys_id { get; set; }
        public string mz_dept_no { get; set; }

    }

}
