using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IChargeTypeRepository : IRepositoryBase<ChargeType> 
    {
        #region 扩展的dapper操作
         
        List<ChargeType> GetChargeTypes();
         
        #endregion
    }
}
