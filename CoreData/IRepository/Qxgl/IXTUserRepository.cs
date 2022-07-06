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

        int AddXtUser(string user_name, string subsys_id, string pass_word, string user_group, string user_mi);

        int DeleteXtUser(string user_name, string subsys_id, string user_group);

        #endregion
    }
}
