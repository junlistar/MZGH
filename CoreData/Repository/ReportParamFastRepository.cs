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
            string sql = GetSqlByTag(221082);
            var para = new DynamicParameters();

            para.Add("@report_code", code);
            return Select(sql, para);

        } 
    }
}
