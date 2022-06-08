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
   
        //public DataSet GetReportDataByCode(string code,string tb_name)
        //{

        //    //string ghsql = GetSqlByTag(220041);
        //    string sql = "select * from rt_report_data_fast where report_code = @report_code";
        //    var para = new DynamicParameters();

        //    para.Add("@report_code", code);
        //    return ExecuteDataSet(sql,tb_name,para, CommandType.Text);
             
        //}
        public ReportData GetReportDataByCode(string code)
        {

            //string ghsql = GetSqlByTag(220041);
            string sql = "select * from rt_report_data_fast_net where report_code = @report_code";
            var para = new DynamicParameters();

            para.Add("@report_code", code);
           var dt =  ExecuteTable(sql, para, CommandType.Text);
            ReportData reportData = null;
            if (dt!=null && dt.Rows.Count>0)
            {
                reportData = new ReportData();
                var row = dt.Rows[0];
                reportData.report_code = Convert.ToInt32(row["report_code"]);
                reportData.short_name = Convert.ToString(row["short_name"]);
                reportData.long_name = Convert.ToString(row["long_name"]);
                reportData.report_sql = Convert.ToString(row["report_sql"]);
                var ReportBytes = (byte[])row["report_com"];
                reportData.report_com = System.Text.Encoding.UTF8.GetString(ReportBytes);
                reportData.report_flag = Convert.ToString(row["report_flag"]);
                reportData.datasetn = Convert.ToInt32(row["datasetn"]);
               
            }

            return reportData;
        }

        public List<ReportData> GetReportData(string code)
        {

            string ghsql = GetSqlByTag(220041);
            string sql = "select * from rt_report_data_fast_net where report_code = @report_code";
            var para = new DynamicParameters();

            para.Add("@report_code", code);
            return Select(sql, para);

        }
        public int UpdateReportDataByCode(string code, byte[] report_com)
        {

            string ghsql = GetSqlByTag(220041);
            string sql = @"update rt_report_data_fast_net set report_com=@report_com where report_code =@report_code";
            var para = new DynamicParameters();

            para.Add("@report_com", report_com);
            para.Add("@report_code", code);

            return Update(sql, para);

        }
    }
}
