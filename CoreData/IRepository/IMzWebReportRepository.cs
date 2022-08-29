using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMzWebReportRepository : IRepositoryBase<MzWebReport> 
    {
        #region 扩展的dapper操作
         

        List<MzWebReport> GetMzWebReports();

        List<MzWebReport> GetMzWebReportByCode(string code);

        bool EditMzWebReports(string jsonStr);

        #endregion
    }
}
