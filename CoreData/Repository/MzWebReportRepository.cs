using Dapper;
using Data.Entities;
using Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class MzWebReportRepository : RepositoryBase<MzWebReport>, IMzWebReportRepository
    {

        public List<MzWebReport> GetMzWebReports()
        {
            string sql = GetSqlByTag("mz_webreport_get");

            return Select(sql);

        }
        public List<MzWebReport> GetMzWebReportByCode(string code)
        {
            string sql = GetSqlByTag("mz_webreport_getbycode");
            var para = new DynamicParameters();
            para.Add("@code", code);

            return Select(sql,para);
        }

        public bool EditMzWebReports(string jsonStr)
        {
            MzWebReport webReport = JsonConvert.DeserializeObject<MzWebReport>(jsonStr);

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
            {
                string sql = "";
                if (!string.IsNullOrWhiteSpace(webReport.code))
                {
                    //edit
                    sql = GetSqlByTag("mz_webreport_update"); 
                }
                else
                {
                    //add
                    sql = GetSqlByTag("mz_webreport_add");
                    webReport.code = Guid.NewGuid().ToString();
                }

                var para = new DynamicParameters();
                para.Add("@code", webReport.code);
                para.Add("@name", webReport.name);
                para.Add("@url", webReport.url);
                para.Add("@open_flag", webReport.open_flag);
                para.Add("@create_opera", webReport.create_opera);
                para.Add("@update_opera", webReport.update_opera);

                return connection.Execute(sql, para) > 0;
            }
        }

        //public List<RelativeCode> GetMzWebReports()
        //{

        //    using IDbConnection connection = DataBaseConfig.GetSqlConnection();

        //    try
        //    {
        //        string sql = GetSqlByTag("zd_relative_get");

        //        return connection.Query<RelativeCode>(sql).ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
