using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IXTUserRepository : IRepositoryBase<XTUser> 
    {
        #region 扩展的dapper操作


        List<XTUser> GetXTUsersBySysId(string subsys_id, string user_group);
         

        #endregion
    }
}
