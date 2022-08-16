using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IFpDataRepository : IRepositoryBase<FpData> 
    {
        #region 扩展的dapper操作
        FPRegistration GetFPRegistrationData(string patient_id, int ledger_sn, int admiss_times);

        FPRegistration GetFPInvoiceEBillOutpatient(string patient_id, int ledger_sn, int admiss_times);

        List<FpData> GetFpDatasByParams(string patient_id, int ledger_sn, string subsys_id);

        bool AddFpData(string patient_id, int ledger_sn, string billBatchCode, string billNo, string random, string createTime, string billQRCode, string pictureUrl, string pictureNetUrl, string subsys_id)
;
        #endregion
    }
}
