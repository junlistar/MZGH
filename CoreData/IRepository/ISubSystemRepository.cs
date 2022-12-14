using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface ISubSystemRepository : IRepositoryBase<SubSystem> 
    {
        #region 扩展的dapper操作
         
        List<SubSystem> GetSubSystems();

        bool UpdateSubSystem(string jsonStr);

        bool DeleteSubSystem(string sys_code);

        bool UpdateMainClientConfig(string jsonStr);

        MainClientConfig GetMainClientConfig();

        #endregion
    }
}
