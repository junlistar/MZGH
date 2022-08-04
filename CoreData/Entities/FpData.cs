using System;

namespace Data.Entities
{
    public class FpData : BaseModel
    {  
         
        public string patient_id { get; set; }
        public int ledger_sn { get; set; }
        public string billBatchCode { get; set; }
        public string billNo { get; set; }
        public string cheque_type { get; set; }
        public string random { get; set; }
        public string createTime { get; set; }
        public string billQRCode { get; set; }
        public string pictureUrl { get; set; }
        public string pictureNetUrl { get; set; }
        public string subsys_id { get; set; } 

         
    }
}
