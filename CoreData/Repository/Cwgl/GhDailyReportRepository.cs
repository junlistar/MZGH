using Dapper;
using Data.Entities;
using Data.Entities.Mzsf;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class GhDailyReportRepository : RepositoryBase<ChargeItem>, IGhDailyReportRepository
    {

        public List<string> GetGhDailyReport(string opera, string report_date, string mz_dept_no)
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
        /// <summary>
        /// 挂号日结保存，轧账功能
        /// </summary>
        /// <param name="opera"></param>
        /// <returns></returns>
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
                        #region 查询
                        //                        string sql1 = @"select * from gh_deposit
                        //where price_opera = @P1 and
                        //      isnull(convert(char(10), report_date, 121),'1900-01-01') = @P2
                        //      and mz_dept_no like @P3";
                        //                        para = new DynamicParameters();
                        //                        para.Add("@P1", opera);
                        //                        para.Add("@P2", "1900-01-01");
                        //                        para.Add("@P3", "1");
                        //                        var depostList = connection.Query<GhDeposit>(sql1, para, transaction);

                        //                        string sql2 = @"select * from gh_receipt
                        //where price_opera = @P1 and
                        //      isnull(convert(char(10), report_date, 121), '1900-01-01') = @P2
                        //      and mz_dept_no like @P3";
                        //                        para = new DynamicParameters();
                        //                        para.Add("@P1", opera);
                        //                        para.Add("@P2", "1900-01-01");
                        //                        para.Add("@P3", "1");
                        //                        var receiptList = connection.Query<GhReceipt>(sql2, para, transaction);

                        //                        string sql3 = @"select patient_id, 
                        //                                           times, 
                        //                                           item_no, 
                        //                                           ledger_sn, 
                        //                                           report_date
                        //                                    from gh_detail_charge
                        //                                    where report_date is null and
                        //                                          mz_dept_no = @P1 and
                        //                                          confirm_opera = @P2 and
                        //                                          charge_status in ('4', '7')";
                        //                        para = new DynamicParameters();
                        //                        para.Add("@P1", "1");
                        //                        para.Add("@P2", opera);

                        //                        var detailChargeList = connection.Query<GhDetailCharge>(sql3, para, transaction);

                        //                        string sql4 = @"select *
                        //                                        from mz_receipt_cancel
                        //                                        where operator = @P1 and
                        //                                              isnull(report_date,'1900-01-01') = @P2 and
                        //                                              subsys_id like @P3 and
                        //                                              mz_dept_no like @P4";
                        //                        para = new DynamicParameters();
                        //                        para.Add("@P1", opera);
                        //                        para.Add("@P2", "1900-01-01");
                        //                        para.Add("@P3", "mzgh");
                        //                        para.Add("@P4", "1");

                        //                        var mzReceiptCancelList = connection.Query<MzReceiptCancel>(sql4, para, transaction);
                        #endregion

                        string sql5 = @"select * from gh_op_receipt
                                    where operator = @P1 and
                                          report_flag = '0'
                                    order by happen_date";
                        para = new DynamicParameters();
                        para.Add("@P1", opera);

                        var ghOpReceiptCancelList = connection.Query<GhOpReceipt>(sql5, para, transaction);

                        ////////////////////更新以上表的report_date
                        string dtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string upsql1 = @"update gh_deposit  set
                                     report_date = @P1
                                    where
                                     price_opera = @P2
                                     and mz_dept_no like @P3 and
                                     report_date is null";
                        para = new DynamicParameters();
                        para.Add("@P1", dtNow);
                        para.Add("@P2", opera);
                        para.Add("@P3", "1");
                        connection.Execute(upsql1, para, transaction);
                        string upsql2 = @"update gh_receipt  set
                                         report_date = @P1
                                        where price_opera = @P2 and mz_dept_no like @P3 and
                                         report_date is null";
                        para = new DynamicParameters();
                        para.Add("@P1", dtNow);
                        para.Add("@P2", opera);
                        para.Add("@P3", "1");
                        connection.Execute(upsql2, para, transaction);
                        string upsql3 = @"update gh_detail_charge  set
                                         report_date = @P1
                                        where
                                         confirm_opera = @P2 and
                                         report_date is null and
                                         charge_status in ('4', '7') and
                                         mz_dept_no = @P3";
                        para = new DynamicParameters();
                        para.Add("@P1", dtNow);
                        para.Add("@P2", opera);
                        para.Add("@P3", "1");
                        connection.Execute(upsql3, para, transaction);
                        string upsql4 = @"update mz_receipt_cancel  set
                                         report_date = @P1
                                        where
                                         operator = @P2 and
                                         report_date is null and
                                         subsys_id = @P3 and
                                         mz_dept_no = @P4";
                        para = new DynamicParameters();
                        para.Add("@P1", dtNow);
                        para.Add("@P2", opera);
                        para.Add("@P3", "mzgh");
                        para.Add("@P4", "1");
                        connection.Execute(upsql4, para, transaction);

                        if (ghOpReceiptCancelList != null)
                        {
                            foreach (var item in ghOpReceiptCancelList)
                            {
                                //更新report_flag
                                string upsql5 = @"update gh_op_receipt  set
                                         report_flag = @P1
                                        where
                                         operator = @P2 and
                                         happen_date = @P3 and
                                         start_no = @P4 and
                                         current_no = @P5 and
                                         end_no = @P6 and
                                         step_length = @P7 and
                                         deleted_flag = @P8 and
                                         report_flag = @P9 and
                                         receipt_type is null";
                                para = new DynamicParameters();
                                para.Add("@P1", "1");
                                para.Add("@P2", item.@operator);
                                para.Add("@P3", item.happen_date);
                                para.Add("@P4", item.start_no);
                                para.Add("@P5", item.current_no);
                                para.Add("@P6", item.end_no);
                                para.Add("@P7", item.step_length);
                                para.Add("@P8", item.deleted_flag);
                                para.Add("@P9", item.report_flag);
                                connection.Execute(upsql5, para, transaction);

                                //写入新数据
                                upsql5 = @"insert into gh_op_receipt
  (operator, happen_date, start_no, current_no, end_no, step_length, deleted_flag, report_flag)
values
  (@P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8)";
                                para = new DynamicParameters();
                                para.Add("@P1", item.@operator);
                                para.Add("@P2", dtNow);
                                para.Add("@P3", item.start_no);
                                para.Add("@P4", item.current_no);
                                para.Add("@P5", item.end_no);
                                para.Add("@P6", item.step_length);
                                para.Add("@P7", item.deleted_flag);
                                para.Add("@P8", item.report_flag);
                                connection.Execute(upsql5, para, transaction);
                            }
                        }

                        string sql = "select report_sn from a_hospital";
                        var hospital = connection.QueryFirstOrDefault<Hosipital>(sql, para, transaction);

                        sql = @"insert into a_daily_report
                          (report_sn, report_date, opera_id, subsys_id, dept_no)
                        values
                          (@P1, @P2, @P3, @P4, @P5)";
                        para = new DynamicParameters();
                        para.Add("@P1", hospital.report_sn);
                        para.Add("@P2", dtNow);
                        para.Add("@P3", opera);
                        para.Add("@P4", "mzgh");
                        para.Add("@P5", "1");
                        connection.Execute(sql, para, transaction);

                        sql = @"select charge from gh_deposit where report_date=@report_date and price_opera=@price_opera";
                        para = new DynamicParameters();
                        para.Add("@report_date", dtNow);
                        para.Add("@price_opera", opera);
                        var deposit_list = connection.Query<decimal>(sql, para, transaction);
                        var in_amount = deposit_list.Where(p => p > 0).Sum();
                        var out_amount = deposit_list.Where(p => p < 0).Sum();


                        sql = @"insert into a_daily_report_data
                          (report_sn, code, in_amount, out_amount)
                        values
                          (@P1, @P2, @P3, @P4)";
                        para = new DynamicParameters();
                        para.Add("@P1", hospital.report_sn);
                        para.Add("@P2", "01");
                        para.Add("@P3", in_amount);
                        para.Add("@P4", out_amount);
                        connection.Execute(sql, para, transaction);

                        //todo:这里需要重新处理，获取挂号相关发票号 写入
                        sql = @"select receipt_no from mz_receipt where cash_opera='00000' 
	and backfee_date>(select top 1 report_date from a_daily_report
where opera_id='00000' and subsys_id = 'mzgh'
 order by report_date desc)";
                        var receipt_no_list = connection.Query<int>(sql, para, transaction);
                        foreach (var receipt_no in receipt_no_list)
                        {
                            sql = @"insert into a_daily_report_receipt
                                  (report_sn, begin_no, end_no, flag)
                                values
                                  (@P1, @P2, @P3, @P4)";
                            para = new DynamicParameters();
                            para.Add("@P1", hospital.report_sn);
                            para.Add("@P2", receipt_no);
                            para.Add("@P3", receipt_no);
                            para.Add("@P4", "3");

                            connection.Execute(sql, para, transaction);
                        }
                        sql = @"update a_hospital set report_sn=@new_sn where no =@no and report_sn=@report_sn";
                        para = new DynamicParameters();
                        para.Add("@new_sn", hospital.report_sn+1);
                        para.Add("@no", hospital.no);
                        para.Add("@report_sn", hospital.report_sn); 
                        connection.Execute(sql, para, transaction);

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
