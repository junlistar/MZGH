using System;
using System.Collections.Generic;

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

    public class FPRegistration
    {
       public MainData MainData { get; set; }
       public List<PayChannelDetail> PayChannelDetails { get; set; }
       public List<ChargeDetail> ChargeDetails { get; set; }
    }
    public class MainData
    {
        public string busNo { get; set; }
        public string busType { get; set; }
        public string payer { get; set; }
        public string busDateTime { get; set; }
        public string placeCode { get; set; }
        public string payee { get; set; }
        public string author { get; set; }
        public string checker { get; set; }
        public string totalAmt { get; set; }
        public string payerType { get; set; }
        public string idCardNo { get; set; }
        public string cardType { get; set; }
        public string cardNo { get; set; }
        public string medicalInstitution { get; set; }
        public string medicalCareType { get; set; }
        public string medicalInsuranceID { get; set; }
        public string consultationDate { get; set; }
        public string patientNo { get; set; }
        public string patientId { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public string accountPay { get; set; }
        public string fundPay { get; set; }
        public string otherfundPay { get; set; }
        public string ownPay { get; set; }
        public string selfConceitedAmt { get; set; }
        public string selfPayAmt { get; set; }
        public string selfCashPay { get; set; }
        public string reimbursementAmt { get; set; }
        public string tel { get; set; }
        public string isArrears { get; set; }
        public string remark { get; set; } 
    }
    public class PayChannelDetail
    {
        public string ItemName { get; set; }
        public string payChannelCode { get; set; }
        public string payChannelValue { get; set; }
    }
    public class ChargeDetail
    { 
        public string ItemName { get; set; }
        public string sortNo { get; set; }
        public string chargeCode { get; set; }
        public string chargeName { get; set; }
        public string std { get; set; }
        public string number { get; set; }
        public string amt { get; set; }
        public string selfAmt { get; set; }
    }
}
