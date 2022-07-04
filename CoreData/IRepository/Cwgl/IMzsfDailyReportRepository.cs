using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMzsfDailyReportRepository : IRepositoryBase<ChargeItem> 
    {
        #region 扩展的dapper操作

        List<string> GetMzsfReport(string opera, string report_date);

        bool SaveMzsfDaily(string opera, string cash_date);

        #endregion
    }
}
