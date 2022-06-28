using Data.Entities.Mzsf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository.Mzsf
{
    public interface IMzDepositRepository : IRepositoryBase<MzDeposit> 
    {
        #region 扩展的dapper操作

         
        List<MzDeposit> GetMzDepositsByPatientId(string patient_id, int ledger_sn);

        #endregion
    }
}
