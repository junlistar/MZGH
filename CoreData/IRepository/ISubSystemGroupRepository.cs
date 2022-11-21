using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface ISubSystemGroupRepository : IRepositoryBase<SubSystemGroup> 
    {
        #region 扩展的dapper操作
         
        List<SubSystemGroup> GetSubSystemGroups();

        bool UpdateSubSystemGroup(string jsonStr);

        bool DeleteSubSystemGroup(string sys_code);

        #endregion
    }
}
