using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IUnitRepository : IRepositoryBase<Unit> 
    {
        #region 扩展的dapper操作
         

        List<Unit> GetUnits();
  

        #endregion
    }
}
