using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IXTGroupRepository : IRepositoryBase<XTGroup> 
    {
        #region 扩展的dapper操作

        List<XTGroup> GetXTGroupsBySysId(string subsys_id);

        int AddXTGroup(string group_name, string subsys_id);

        int DeleteXTGroup(string user_group, string subsys_id);

        #endregion
    }
}
