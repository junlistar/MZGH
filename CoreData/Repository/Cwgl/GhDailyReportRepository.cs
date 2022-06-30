using Dapper;
using Data.Entities;
using Data.Entities.Mzsf;
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

        public bool SaveGhDaily(string opera)
        {

            try
            {
                DynamicParameters para; 

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql1 = @"select * from gh_deposit
where price_opera = @P1 and
      isnull(convert(char(10), report_date, 121),'1900-01-01') = @P2
      and mz_dept_no like @P3"; 
                        para = new DynamicParameters();
                        para.Add("@P1", opera);
                        para.Add("@P2", "1900-01-01");
                        para.Add("@P3", "1");
                        var depostList = connection.Query<GhDeposit>(sql1, para, transaction);

                        string sql2 = @"select * from gh_receipt
where price_opera = @P1 and
      isnull(convert(char(10), report_date, 121), '1900-01-01') = @P2
      and mz_dept_no like @P3";
                        para = new DynamicParameters();
                        para.Add("@P1", opera);
                        para.Add("@P2", "1900-01-01");
                        para.Add("@P3", "1");
                        var receiptList = connection.Query<GhReceipt>(sql2, para, transaction);

                        string sql3 = @"select patient_id, 
                                           times, 
                                           item_no, 
                                           ledger_sn, 
                                           report_date
                                    from gh_detail_charge
                                    where report_date is null and
                                          mz_dept_no = @P1 and
                                          confirm_opera = @P2 and
                                          charge_status in ('4', '7')";
                        para = new DynamicParameters();
                        para.Add("@P1", "1");
                        para.Add("@P2", opera); 

                        var detailChargeList = connection.Query<GhDetailCharge>(sql3, para, transaction);

                        string sql4 = @"select *
                                        from mz_receipt_cancel
                                        where operator = @P1 and
                                              isnull(report_date,'1900-01-01') = @P2 and
                                              subsys_id like @P3 and
                                              mz_dept_no like @P4";
                        para = new DynamicParameters();
                        para.Add("@P1", opera);
                        para.Add("@P2", "1900-01-01");
                        para.Add("@P3", "mzgh");
                        para.Add("@P4", "1");

                        var mzReceiptCancelList = connection.Query<MzReceiptCancel>(sql4, para, transaction);

                        string sql5 = @"select * from gh_op_receipt
                                    where operator = @P1 and
                                          report_flag = '0'
                                    order by happen_date";
                        para = new DynamicParameters();
                        para.Add("@P1", opera); 

                        var ghOpReceiptCancelList = connection.Query<GhOpReceipt>(sql5, para, transaction);



                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
