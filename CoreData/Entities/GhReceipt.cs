using System;

namespace Data.Entities
{
    public class GhReceipt : BaseModel
    {
        public string patient_id { get; set; }
        public int times { get; set; }
        public int ledger_sn { get; set; }
        public int receipt_sn { get; set; }
        public string pay_unit { get; set; }
        public decimal charge_total { get; set; }
        public string settle_opera { get; set; }
        public string settle_date { get; set; }
        public string price_opera { get; set; }
        public string price_date { get; set; }
        public string report_date { get; set; }
        public string receipt_no { get; set; }
        public int charge_status { get; set; }
        public int mz_dept_no { get; set; }
        public string op_receipt_sn { get; set; }
        public string back_opera { get; set; }
        public string back_date { get; set; }
    }
}
