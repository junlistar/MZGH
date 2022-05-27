using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IReportDataFastRepository : IRepositoryBase<ReportData> 
    {
        DataSet GetReportDataByCode(string code, string tb_name);

        List<ReportData> GetReportData(string code);

        int UpdateReportDataByCode(string code, byte[] report_com);
    }
}
