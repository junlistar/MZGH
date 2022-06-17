using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IMzDepositRepository : IRepositoryBase<MzDeposit> 
    {
        #region 扩展的dapper操作

         
        List<MzDeposit> GetMzDepositsByPatientId(string patient_id, int ledger_sn);

        #endregion
    }
}
