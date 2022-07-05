using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IXTUserGroupRepository : IRepositoryBase<XTUserGroup> 
    {
        #region 扩展的dapper操作


        List<XTUserGroup> GetXTUserGroupsBySysId(string subsys_id, string user_group);
         

        #endregion
    }
}
