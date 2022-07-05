using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class XTUserRepository : RepositoryBase<XTUser>, IXTUserRepository
    {
   
        public List<XTUser> GetXTUsersBySysId(string subsys_id,string user_group)
        {
            string ghsql = @"select a.*,b.name from xt_user a
join a_employee_mi b on a.user_mi = b.code
where subsys_id = @subsys_id
  and user_group = @user_group";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", user_group);
            return  Select(ghsql,para); 

        } 
    }
}
