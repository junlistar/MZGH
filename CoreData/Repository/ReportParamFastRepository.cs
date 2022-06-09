using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ReportParamFastRepository : RepositoryBase<ReportParam>, IReportParamFastRepository
    {
    
        public List<ReportParam> GetReportParam(string code)
        {

            //string ghsql = GetSqlByTag(220041);
            string sql = "select * from rt_report_params_fast_net where report_code = @report_code";
            var para = new DynamicParameters();

            para.Add("@report_code", code);
            return Select(sql, para);

        } 
    }
}
