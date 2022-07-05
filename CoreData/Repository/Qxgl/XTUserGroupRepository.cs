using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class XTUserGroupRepository : RepositoryBase<XTUserGroup>, IXTUserGroupRepository
    {
   
        public List<XTUserGroup> GetXTUserGroupsBySysId(string subsys_id,string user_group)
        {
            string ghsql = @"select a.*,
       b.func_desc
from xt_user_group a
join xt_func b on b.func_name = a.func_name
               and b.subsys_id = a.subsys_id
where a.subsys_id = @subsys_id
  and a.user_group = @user_group";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", user_group);
            return  Select(ghsql,para); 

        } 
    }
}
