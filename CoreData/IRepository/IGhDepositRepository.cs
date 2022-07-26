using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGhDepositRepository : IRepositoryBase<GhDeposit>
    {
        #region 扩展的dapper操作


        List<GhDeposit> GetGhDeposit(string request_date);
         

        //int Refund(string patient_id, int ledger_sn, string cheque_type, string item_no, decimal charge, string opera, int manual = 0);

        int Refund(string patient_id, int times, string opera, int manual = 0);

        List<GhDeposit> GetGhRefundPayList(string request_date, string patient_id, int times);

        #endregion
    }
}
