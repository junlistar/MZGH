using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class XTUserGroupRepository : RepositoryBase<XTUserGroup>, IXTUserGroupRepository
    {

        public List<XTUserGroup> GetXTUserGroupsByGroupId(string subsys_id, string user_group)
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
            return Select(ghsql, para);

        }

        public List<XTUserGroup> GetXTUserGroups(string subsys_id)
        {
            string ghsql = @"select * from xt_func where subsys_id = @subsys_id";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            return Select(ghsql, para);

        }

        public bool AddXtUserGroups(string func_str, string subsys_id, string user_group)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                { 
                    var func_list = func_str.Split(",");
                    //先删除，后添加
                    string sql = @"delete from xt_user_group where subsys_id=@subsys_id and user_group=@user_group";

                    var para = new DynamicParameters(); 
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@user_group", user_group);
                    connection.Execute(sql, para, transaction);

                    foreach (var func in func_list)
                    {
                        sql = @"insert into xt_user_group(subsys_id,user_group,func_name)
  values (@subsys_id,@user_group,@func_name)";

                        para = new DynamicParameters();

                        para.Add("@subsys_id", subsys_id);
                        para.Add("@user_group", user_group);
                        para.Add("@func_name", func);

                        connection.Execute(sql, para, transaction);
                    } 

                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }


        }

        public bool DeleteXtUserGroups(string func_str, string subsys_id, string user_group)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    var func_list = func_str.Split(",");
                   

                    foreach (var func in func_list)
                    {
                        //删除
                        string sql = @"delete from xt_user_group where subsys_id=@subsys_id and user_group=@user_group and func_name=@func_name";

                        var para = new DynamicParameters();
                        para.Add("@subsys_id", subsys_id);
                        para.Add("@user_group", user_group);
                        para.Add("@func_name", func);
                        connection.Execute(sql, para, transaction);
                    }

                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }


        }
    }
}
