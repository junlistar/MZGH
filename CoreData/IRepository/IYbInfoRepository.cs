using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IYbInfoRepository : IRepositoryBase<BaseModel> 
    {
        #region 扩展的dapper操作

        bool AddYB1101(string jsonStr);

        #endregion
    }
}
