using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class XTGroupRepository : RepositoryBase<XTGroup>, IXTGroupRepository
    {
   
        public List<XTGroup> GetXTGroupsBySysId(string subsys_id)
        {
            string ghsql = @"select * from xt_group where subsys_id = @subsys_id";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            return  Select(ghsql,para); 

        } 

        public int AddXTGroup(string group_name, string subsys_id)
        {
            string sql = @"select isnull(max(user_group),0) user_group from xt_group
where subsys_id = @subsys_id";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);

            int user_group = Convert.ToInt32(ExcuteScalar(sql, para));

            sql = @"insert into xt_group (subsys_id, user_group, group_name) values (@subsys_id, @user_group, @group_name)";
            
            para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", ++user_group);
            para.Add("@group_name", group_name);

            return Update(sql, para);
        }

        public int DeleteXTGroup(string user_group, string subsys_id)
        {
            string sql = @"delete from  xt_group where subsys_id=@subsys_id and user_group=@user_group";

            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", user_group); 

            return Update(sql, para);
        }
    }
}
