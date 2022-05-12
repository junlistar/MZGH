using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IResponceTypeRepository : IRepositoryBase<ResponceType> 
    {
        #region 扩展的dapper操作
         
        List<ResponceType> GetResponceTypes();
         
        #endregion
    }
}
