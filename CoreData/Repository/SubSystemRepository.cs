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
            //string ghsql =GetSqlByTag("zd_responsetype_get");
            string ghsql = "select * from subsystem";

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

                        //查询是否存在，存在即修改，不存在则新增
                        string sql = "select * from subsystem where sys_code=@sys_code ";
                        var _exist_list = connection.Query<SubSystem>(sql, para, transaction);
                        if (_exist_list!=null && _exist_list.AsList().Count>0)
                        {
                            //sql = GetSqlByTag("");
                            sql = @"update subsystem set sys_name=@sys_name,sys_no=@sys_no,file_path=@file_path,file_type=@file_type,icon_path=@icon_path,
open_mode=@open_mode,active_flag=@active_flag,update_time=getDate()
where sys_code=@sys_code ";
                            //para.Add("@update_time", dt_now);

                            connection.Execute(sql, para, transaction);
                        }
                        else
                        {
                            sql = @"insert into subsystem(sys_code,sys_name,sys_no,file_path,file_type,icon_path,open_mode,active_flag,update_time) 
values(@sys_code,@sys_name,@sys_no,@file_path,@file_type,@icon_path,@open_mode,@active_flag,getDate())";
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
    }
}
