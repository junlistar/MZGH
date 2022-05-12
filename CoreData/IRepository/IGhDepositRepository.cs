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

        List<GhDeposit> GetGhDepositByStatus(string pid, int times, int status, int cheque_type,int item_no);
        //int Refund(GhDeposit vm);

        int Refund(string patient_id, int ledger_sn, string cheque_type, string item_no, decimal charge, string opera, int manual = 0);
        #endregion
    }
}
