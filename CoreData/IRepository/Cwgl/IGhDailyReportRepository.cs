using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGhDailyReportRepository : IRepositoryBase<ChargeItem> 
    {
        #region 扩展的dapper操作

        List<string> GetGhDailyReport(string opera, string report_date, string mz_dept_no);
         
        #endregion
    }
}
