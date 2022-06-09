using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IReportDataFastRepository : IRepositoryBase<ReportData> 
    {
        DataSet GetReportDataBySql(string sql, string tb_name);
        ReportData GetReportDataByCode(string code);

        List<ReportData> GetReportData(string code);

        int UpdateReportDataByCode(int code ,string report_com);
    }
}
