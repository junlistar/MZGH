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
  and a.user_group = @user_group and a.sys_type='2.0'";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", user_group); 
            return Select(ghsql, para);

        }

        public List<XTUserGroup> GetXTUserGroups(string subsys_id)
        {
            string ghsql = @"select * from xt_func where subsys_id = @subsys_id and sys_type='2.0'";
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
                    string sql = @"delete from xt_user_group where subsys_id=@subsys_id and user_group=@user_group and sys_type='2.0'";

                    var para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@user_group", user_group);
                    connection.Execute(sql, para, transaction);

                    foreach (var func in func_list)
                    {
                        sql = @"insert into xt_user_group(subsys_id,user_group,func_name,sys_type)
  values (@subsys_id,@user_group,@func_name,'2.0')";

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
                        string sql = @"delete from xt_user_group where subsys_id=@subsys_id and user_group=@user_group and func_name=@func_name and sys_type='2.0'";

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

        public bool AddFuncton(string subsys_id, string func_name, string func_desc, string action_flag)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //查询是否存在相同数据
                    string sql = @"select count(*) from xt_func where subsys_id =@subsys_id and func_name = @func_name and sys_type='2.0'";

                    var para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_name", func_name);
                    int count = connection.QueryFirstOrDefault<int>(sql, para, transaction);
                    if (count > 0)
                    {
                        throw new Exception("存在相同功能编号！");
                    }

                    sql = @"select count(*) from xt_func where subsys_id =@subsys_id and func_desc = @func_desc and sys_type='2.0'";
                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_desc", func_desc);
                    count = connection.QueryFirstOrDefault<int>(sql, para, transaction);
                    if (count > 0)
                    {
                        throw new Exception("存在相同功能描述！");
                    } 
                    sql = @"insert into xt_func(subsys_id,func_name,func_desc,action_flag,sys_type)
  values (@subsys_id,@func_name,@func_desc,@action_flag,'2.0')";

                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_name", func_name);
                    para.Add("@func_desc", func_desc);
                    para.Add("@action_flag", action_flag);

                    connection.Execute(sql, para, transaction);


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

        public bool UpdateFuncton(string subsys_id, string func_name, string func_desc, string action_flag)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //查询是否存在相同数据 
                    var para = new DynamicParameters(); 
                    string sql = @"select count(*) from xt_func where subsys_id =@subsys_id and func_desc = @func_desc and func_name!=@func_name and sys_type='2.0'";
                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_desc", func_desc);
                    para.Add("@func_name", func_name);
                   int count = connection.QueryFirstOrDefault<int>(sql, para, transaction);
                    if (count > 0)
                    {
                        throw new Exception("存在相同功能描述！");
                    }
                    sql = @"update xt_func set func_desc=@func_desc,action_flag=@action_flag where subsys_id =@subsys_id and func_name = @func_name  and sys_type='2.0'";

                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_name", func_name);
                    para.Add("@func_desc", func_desc);
                    para.Add("@action_flag", action_flag);

                    connection.Execute(sql, para, transaction);

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

        public bool DelFuncton(string subsys_id, string func_name, string func_desc, string action_flag)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //查询是否存在相同数据
                    string sql = @"delete from xt_func where subsys_id =@subsys_id and func_name = @func_name and func_desc=@func_desc and action_flag=@action_flag and sys_type='2.0'";

                    var para = new DynamicParameters();

                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_name", func_name);
                    para.Add("@func_desc", func_desc);
                    para.Add("@action_flag", action_flag);

                    connection.Execute(sql, para, transaction);


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
