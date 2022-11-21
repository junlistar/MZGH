using Dapper;
using Data.Entities;
using Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SubSystemGroupRepository : RepositoryBase<SubSystemGroup>, ISubSystemGroupRepository
    {

        public List<SubSystemGroup> GetSubSystemGroups()
        {
            string ghsql =GetSqlByTag("subsystemgroup_get"); 

            return Select(ghsql);
        }

        public bool UpdateSubSystemGroup(string jsonStr)
        {
            try
            {
                SubSystemGroup model = JsonConvert.DeserializeObject<SubSystemGroup>(jsonStr);

                DynamicParameters para = new DynamicParameters();
                //var dt_now = GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss");

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //参数
                        para = new DynamicParameters(); 
                        para.Add("@group_code", model.group_code);
                        para.Add("@group_name", model.group_name);
                        para.Add("@active_flag", model.active_flag);
                        para.Add("@sort", model.sort); 
                        //查询是否存在，存在即修改，不存在则新增 
                        string sql = GetSqlByTag("subsystemgroup_getbycode");  
                        var _exist_list = connection.Query<SubSystemGroup>(sql, para, transaction);
                        if (_exist_list != null && _exist_list.AsList().Count > 0)
                        { 
                            sql = GetSqlByTag("subsystemgroup_update");  
                            connection.Execute(sql, para, transaction);
                        }
                        else
                        {
                            sql = GetSqlByTag("subsystemgroup_add");
                            connection.Execute(sql, para, transaction);
                        } 
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteSubSystemGroup(string sys_code)
        {
            try
            {
                //SubSystemGroup SubSystemGroup = JsonConvert.DeserializeObject<SubSystemGroup>(jsonStr);

                DynamicParameters para = new DynamicParameters();
                //var dt_now = GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss");

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //参数
                        para = new DynamicParameters();
                        para.Add("@group_code", sys_code);
                        
                        string sql = GetSqlByTag("subsystemgroup_delete");// @"update SubSystemGroup set active_flag=0 where sys_code=@sys_code ";

                        connection.Execute(sql, para, transaction);
                         
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
