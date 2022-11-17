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
    public class SubSystemRepository : RepositoryBase<SubSystem>, ISubSystemRepository
    {

        public List<SubSystem> GetSubSystems()
        {
            string ghsql =GetSqlByTag("subsystem_get"); 

            return Select(ghsql);
        }

        public bool UpdateSubSystem(string jsonStr)
        {
            try
            {
                SubSystem subSystem = JsonConvert.DeserializeObject<SubSystem>(jsonStr);

                DynamicParameters para = new DynamicParameters();
                //var dt_now = GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss");

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //参数
                        para = new DynamicParameters();
                        para.Add("@sys_code", subSystem.sys_code);
                        para.Add("@sys_name", subSystem.sys_name);
                        para.Add("@sys_no", subSystem.sys_no);
                        para.Add("@sys_desc", subSystem.sys_desc);
                        para.Add("@file_path", subSystem.file_path);
                        para.Add("@file_type", subSystem.file_type);
                        para.Add("@icon_path", subSystem.icon_path);
                        para.Add("@open_mode", subSystem.open_mode); 
                        para.Add("@active_flag", subSystem.active_flag);
                        para.Add("@sys_update_url", subSystem.sys_update_url);
                        para.Add("@sys_relative_path", subSystem.sys_relative_path);

                        //查询是否存在，存在即修改，不存在则新增 
                        string sql = GetSqlByTag("subsystem_getbysyscode");  
                        var _exist_list = connection.Query<SubSystem>(sql, para, transaction);
                        if (_exist_list != null && _exist_list.AsList().Count > 0)
                        { 
                            sql = GetSqlByTag("subsystem_update");  
                            connection.Execute(sql, para, transaction);
                        }
                        else
                        {
                            sql = GetSqlByTag("subsystem_add");
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

        public bool DeleteSubSystem(string sys_code)
        {
            try
            {
                //SubSystem subSystem = JsonConvert.DeserializeObject<SubSystem>(jsonStr);

                DynamicParameters para = new DynamicParameters();
                //var dt_now = GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss");

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //参数
                        para = new DynamicParameters();
                        para.Add("@sys_code", sys_code);
                        
                        string sql = GetSqlByTag("subsystem_delete");// @"update subsystem set active_flag=0 where sys_code=@sys_code ";

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
