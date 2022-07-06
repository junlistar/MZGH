using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IXTUserGroupRepository : IRepositoryBase<XTUserGroup> 
    {
        #region 扩展的dapper操作


        List<XTUserGroup> GetXTUserGroupsByGroupId(string subsys_id, string user_group);

        List<XTUserGroup> GetXTUserGroups(string subsys_id);

        bool AddXtUserGroups(string func_str, string subsys_id, string user_group);

        #endregion
    }
}
