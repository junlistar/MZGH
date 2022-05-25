using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGhRefundRepository : IRepositoryBase<GhRefund>
    {
        #region 扩展的dapper操作


        List<GhRefund> GetGhRefund(string datestr, string patient_id); 

        #endregion
    }
}
