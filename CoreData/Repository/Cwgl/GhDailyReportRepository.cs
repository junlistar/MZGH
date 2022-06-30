using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GhDailyReportRepository : RepositoryBase<ChargeItem>, IGhDailyReportRepository
    {
   
        public List<string> GetGhDailyReport(string opera,string report_date,string mz_dept_no)
        {

            //string ghsql = GetSqlByTag(220041);

            string sql = @"select distinct
       report_date 
from view_GhDailyReport_op
where (price_opera like @price_opera) and
      (report_date is null or
      convert(char(10), report_date, 121) = @report_date) and
      (mz_dept_no like @mz_dept_no)
order by report_date";
             
            var para = new DynamicParameters();

            para.Add("@price_opera", opera);
            para.Add("@report_date", report_date);
            para.Add("@mz_dept_no", mz_dept_no);

            return SelectStringList(sql, para);


        }
        
    }
}
