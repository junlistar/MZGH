using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface ICprChargesRepository : IRepositoryBase<CprCharges> 
    {
        #region 扩展的dapper操作


        List<CprCharges> GetCprCharges(string patient_id,int times,string charge_status);
        List<CprCharges> GetDrugDetails(string p_id, int ledger_sn, string tbl_flag);


        #endregion
    }
}
