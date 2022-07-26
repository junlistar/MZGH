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
            string ghsql = GetSqlByTag(221046);
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", user_group); 
            return Select(ghsql, para);

        }

        public List<XTUserGroup> GetXTUserGroups(string subsys_id)
        {
            string ghsql = GetSqlByTag(221047);
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            return Select(ghsql, para);

        }

        public bool AddXtUserGroups(string func_str, string subsys_id, string user_group)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    var func_list = func_str.Split(",");
                    //先删除，后添加
                    string sql = GetSqlByTag(221048);

                    var para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@user_group", user_group);
                    connection.Execute(sql, para, transaction);

                    foreach (var func in func_list)
                    {
                        sql = GetSqlByTag(221049);

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

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    var func_list = func_str.Split(",");


                    foreach (var func in func_list)
                    {
                        //删除
                        string sql = GetSqlByTag(221050);

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

        public bool AddFuncton(string subsys_id, string func_name, string func_desc,string parent_func, string action_flag)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //查询是否存在相同数据
                    string sql = GetSqlByTag(221051);

                    var para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_name", func_name);
                    int count = connection.QueryFirstOrDefault<int>(sql, para, transaction);
                    if (count > 0)
                    {
                        throw new Exception("存在相同功能编号！");
                    }

                    sql = GetSqlByTag(221052);
                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_desc", func_desc);
                    count = connection.QueryFirstOrDefault<int>(sql, para, transaction);
                    if (count > 0)
                    {
                        throw new Exception("存在相同功能描述！");
                    } 
                    sql = GetSqlByTag(221053);

                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_name", func_name);
                    para.Add("@func_desc", func_desc);
                    para.Add("@parent_func", parent_func);
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

        public bool UpdateFuncton(string subsys_id, string func_name, string func_desc, string parent_func, string action_flag)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //查询是否存在相同数据  
                    var para = new DynamicParameters(); 
                    string sql = GetSqlByTag(221054);
                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_desc", func_desc);
                    para.Add("@func_name", func_name);
                    int count = connection.QueryFirstOrDefault<int>(sql, para, transaction);
                    if (count > 0)
                    {
                        throw new Exception("存在相同功能描述！");
                    }
                    sql = GetSqlByTag(221055);

                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@func_name", func_name);
                    para.Add("@func_desc", func_desc);
                    para.Add("@parent_func", parent_func);
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

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //查询是否存在相同数据
                    string sql = GetSqlByTag(221056);

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
