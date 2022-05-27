using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ReportDataFastRepository : RepositoryBase<ReportData>, IReportDataFastRepository
    {
   
        public DataSet GetReportDataByCode(string code,string tb_name)
        {

            string ghsql = GetSqlByTag(220041);
            string sql = "select * from rt_report_data_fast where report_code = @report_code";
            var para = new DynamicParameters();

            para.Add("@report_code", code);
            return ExecuteDataSet(sql,tb_name,para, CommandType.Text);
             
        }

        public List<ReportData> GetReportData(string code)
        {

            string ghsql = GetSqlByTag(220041);
            string sql = "select * from rt_report_data_fast where report_code = @report_code";
            var para = new DynamicParameters();

            para.Add("@report_code", code);
            return Select(sql, para);

        }
        public int UpdateReportDataByCode(string code, byte[] report_com)
        {

            string ghsql = GetSqlByTag(220041);
            string sql = @"update rt_report_data_fast set report_com=@report_com where report_code =@report_code";
            var para = new DynamicParameters();

            para.Add("@report_com", report_com);
            para.Add("@report_code", code);

            return Update(sql, para);

        }
    }
}
