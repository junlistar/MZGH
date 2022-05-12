using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IChargeItemRepository : IRepositoryBase<ChargeItem> 
    {
        #region 扩展的dapper操作


        List<ChargeItem> GetChargeItemsByCode(string code);

        List<ChargeItem> GetChargeItemsByRecordSN(string record_sn);

        #endregion
    }
}
