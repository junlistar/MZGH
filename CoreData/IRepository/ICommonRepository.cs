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

        List<YbName> GetYbName();

        MzClientConfig GetMzClientConfig(); 
        FpConfig GetFPConfig();

        List<Ybhzzd> GetYbhzzdList();

        bool UpdateMzClientConfig(string jsonStr);
         
        bool  AddYbLog(string jsonStr);
        #endregion
    }
}
