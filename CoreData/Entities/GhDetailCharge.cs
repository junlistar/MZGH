using System;

namespace Data.Entities
{
    public class GhDetailCharge : BaseModel
    {
        public string patient_id { get; set; }
        public int times { get; set; }
        public int ledger_sn { get; set; }
        public int item_no { get; set; }
        public string report_date { get; set; } 
    }
}
