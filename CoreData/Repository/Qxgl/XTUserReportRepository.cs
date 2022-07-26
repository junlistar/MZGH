using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class XTUserReportRepository : RepositoryBase<XTUserReport>, IXTUserReportRepository
    {

        public List<XTUserReport> GetXTUserReportsByGroupId(string subsys_id, string user_group)
        {
            string ghsql = GetSqlByTag("xt_userreport_getbygroupid");
            var para = new DynamicParameters();

            para.Add("@user_group", user_group);
            para.Add("@subsys_id", subsys_id);
            return Select(ghsql, para);

        }
        public List<XTUserReport> GetXTUserReports(string subsys_id)
        { 
            string ghsql = GetSqlByTag("xt_report_getbysysid");
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            return Select(ghsql, para);
        }
        public bool AddXtUserReports(string rep_id, string subsys_id, string user_group)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    string sql = GetSqlByTag("xt_report_getbyid");

                    var para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@rep_id", rep_id);
                    var report = connection.QueryFirstOrDefault<XTUserReport>(sql, para, transaction);

                    if (report == null)
                    {
                        throw new Exception("没有找到报表");
                    }


                    sql = GetSqlByTag("xt_userreport_checkadd");

                    para = new DynamicParameters();
                    para.Add("@user_group", user_group);
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@rep_id", rep_id);

                    int count = connection.ExecuteScalar<int>(sql, para, transaction);
                    if (count > 0)
                    {
                        throw new Exception("已经添加了该报表");
                    }

                    sql = GetSqlByTag("xt_userreport_add");
                    para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@user_group", user_group);
                    para.Add("@report_code", report.report_code);
                    para.Add("@rep_id", report.rep_id);
                    para.Add("@rep_name", report.rep_name);
                    para.Add("@parent_id", report.parent_id);

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
        public bool DelXtUserReports(string rep_id, string subsys_id, string user_group)
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    string sql = GetSqlByTag("xt_userreport_del");

                    var para = new DynamicParameters();
                    para.Add("@subsys_id", subsys_id);
                    para.Add("@rep_id", rep_id);
                    para.Add("@user_group", user_group);
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
