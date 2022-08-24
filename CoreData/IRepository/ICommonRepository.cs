using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface ICommonRepository : IRepositoryBase<BaseModel> 
    {
        #region 扩展的dapper操作
         
        List<PageChequeCompare> GetPageChequeCompares();

        MzClientConfig GetMzClientConfig();

        bool UpdateMzClientConfig(string jsonStr);

        #endregion
    }
}
