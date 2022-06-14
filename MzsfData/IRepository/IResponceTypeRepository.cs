using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IResponceTypeRepository : IRepositoryBase<ResponceType> 
    {
        #region 扩展的dapper操作
         
        List<ResponceType> GetResponceTypes();
         
        #endregion
    }
}
