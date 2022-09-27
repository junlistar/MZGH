using Dapper;
using Data.Entities;
using Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class GhOpReceiptRepository : RepositoryBase<GhOpReceipt>, IGhOpReceiptRepository
    {

        public List<GhOpReceipt> GetCurrentReceiptNo(string opera)
        {
            //string ghsql = "select top 1 * from gh_op_receipt order by happen_date desc ";
            string ghsql = GetSqlByTag("mzgh_ghopreceipt_getnew");

            var para = new DynamicParameters();
            para.Add("@operator", opera == "" ? "00000" : opera);
            return Select(ghsql, para);


        }
        public List<GhOpReceipt> GetOpReceipts(string opera)
        {
            string ghsql = GetSqlByTag("mzgh_ghopreceipt_get");

            var para = new DynamicParameters();
            para.Add("@operator", opera == "" ? "00000" : opera);
            return Select(ghsql, para);
        }

        public bool EditOpReceipt(string jsonStr)
        {
            GhOpReceipt _mod = JsonConvert.DeserializeObject<GhOpReceipt>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                var para = new DynamicParameters();
                string sql = @"select * from gh_op_receipt where operator=@opera and happen_date=@happen_date";
                para.Add("@opera", _mod.@operator);
                para.Add("@happen_date", _mod.happen_date);
                para.Add("@opera", _mod.@operator);
                para.Add("@happen_date", _mod.happen_date);
                para.Add("@start_no", _mod.start_no);
                para.Add("@current_no", _mod.current_no);
                para.Add("@end_no", _mod.end_no);
                para.Add("@step_length", _mod.step_length);
                para.Add("@deleted_flag", _mod.deleted_flag);
                para.Add("@report_flag", _mod.report_flag);

                var _list = connection.Query<GhOpReceipt>(sql, para);

                if (_list != null && _list.ToList().Count() > 0)
                {
                    sql = @" update gh_op_receipt set start_no=@start_no,current_no=@current_no,end_no=@end_no,
 step_length = @step_length,deleted_flag = @deleted_flag,report_flag = @report_flag
  where operator= @opera and happen_date = @happen_date";
                }
                else
                {
                    sql = @" insert into gh_op_receipt(operator,happen_date,start_no,current_no,end_no,step_length,deleted_flag,report_flag)
 values(@opera, @happen_date, @start_no, @current_no, @end_no, @step_length, @deleted_flag, @report_flag)";

                }

                return connection.Execute(sql, para) > 0;

            }
        }

        public bool DeleteOpReceipt(string jsonStr)
        {
            GhOpReceipt _mod = JsonConvert.DeserializeObject<GhOpReceipt>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                var para = new DynamicParameters(); 
                para.Add("@opera", _mod.@operator);
                para.Add("@happen_date", _mod.happen_date);
                para.Add("@opera", _mod.@operator);
                para.Add("@happen_date", _mod.happen_date);
                para.Add("@start_no", _mod.start_no);
                para.Add("@current_no", _mod.current_no);
                para.Add("@end_no", _mod.end_no);
                para.Add("@step_length", _mod.step_length);
                para.Add("@deleted_flag", "1");
                para.Add("@report_flag", _mod.report_flag);
                 
                string   sql = @" update gh_op_receipt set deleted_flag = @deleted_flag
  where operator= @opera and happen_date = @happen_date"; 

                return connection.Execute(sql, para) > 0;

            }
        }
    }
}
