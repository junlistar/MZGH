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
        ReportParamFastRepository reportParamFastRepository = new ReportParamFastRepository();

        public DataSet GetReportDataBySql(string sql, string tb_name)
        { 
            return ExecuteDataSet(sql, tb_name,null, CommandType.Text);

        }
        public DataTable GetDateTableBySql(string sql)
        {
            return ExecuteTable(sql,null, CommandType.Text);

        }
        public DataTable GetGhDailyByReportCode(string code,string report_date, string price_opera ,string mz_dept_no)
        {
            var reportData = GetReportDataByCode(code);
            string sql = reportData.report_sql;
            var paramlist = reportParamFastRepository.GetReportParam(code);
            foreach (var item in paramlist)
            {
                if (item.param_name == "Reportdate")
                {
                    sql = sql.Replace(":" + item.param_name, "'"+ report_date +"'");
                }
                else if (item.param_name == "opera")
                {
                    sql = sql.Replace(":" + item.param_name, "'" + price_opera + "'");
                }
                else if (item.param_name == "dept_no")
                {
                    sql = sql.Replace(":" + item.param_name, "'"+ mz_dept_no + "'");
                }
            } 
            return ExecuteTable(sql, null, CommandType.Text); 
        }
        public DataTable GetMzsfDailyByReportCode(string code, string report_date, string price_opera,string cash_date)
        {
            var reportData = GetReportDataByCode(code);
            string sql = reportData.report_sql;
            var paramlist = reportParamFastRepository.GetReportParam(code);
            foreach (var item in paramlist)
            {
                if (item.param_name == "rep_date")
                {
                    sql = sql.Replace(":" + item.param_name, "'" + report_date + "'");
                }
                else if (item.param_name == "op_id")
                {
                    sql = sql.Replace(":" + item.param_name, "'" + price_opera + "'");
                }
                else if (item.param_name == "mz_dept_no")
                {
                    sql = sql.Replace(":" + item.param_name, "'1'");
                }
                else if (item.param_name == "cash_date")
                {
                    sql = sql.Replace(":" + item.param_name, "'" + cash_date + "'");
                }
                
            }
            return ExecuteTable(sql, null, CommandType.Text);

        }


        public ReportData GetReportDataByCode(string code)
        {
             
            string sql = GetSqlByTag(220079);
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
            string sql = GetSqlByTag(220080);
            var para = new DynamicParameters();

            para.Add("@report_code", code);
            return Select(sql, para);

        }
        public int UpdateReportDataByCode(int code ,string report_com)
        { 
            string sql = GetSqlByTag(220081);
            var para = new DynamicParameters();
            byte[] ReportBytes = System.Text.Encoding.UTF8.GetBytes(report_com);
            para.Add("@report_com", ReportBytes);
            para.Add("@report_code", code);

            return Update(sql, para);

        }
         
    }
}
