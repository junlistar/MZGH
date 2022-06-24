using System;

namespace MzsfData.Entities
{
    public class MzReceipt : BaseModel
    { 
        public string patient_id { get; set; }
        public int ledger_sn { get; set; }
        public int receipt_sn { get; set; }
        public string pay_unit { get; set; }
        public decimal charge_total { get; set; }
        public string charge_status { get; set; }
        public string cash_opera { get; set; }
        public DateTime cash_date { get; set; }

        public string windows_no { get; set; }
        public string report_date { get; set; }
        public string receipt_no { get; set; }
        public string mz_dept_no { get; set; }
        public string group_date { get; set; } 
        public string contract_code { get; set; }
        public string op_receipt_sn { get; set; } 
        public string backfee_date { get; set; }
         
    }
    public class MzReceiptCharge : BaseModel
    {

        public string patient_id { get; set; }
        public int ledger_sn { get; set; }
        public string receipt_sn { get; set; }
        public string bill_code { get; set; }
        public decimal charge { get; set; }
        public string pay_unit { get; set; }

    }
}
