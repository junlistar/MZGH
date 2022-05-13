using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMzHaomingRepository : IRepositoryBase<MzHaoming> 
    {
        #region 扩展的dapper操作
         
        List<MzHaoming> GetMzHaomings();
         
        #endregion
    }
}
