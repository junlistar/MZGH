using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MzsfData.Repository
{
    public class MzOrderRepository : RepositoryBase<MzOrder>, IMzOrderRepository
    {
        CprChargesRepository chargesRepository = new CprChargesRepository();
        public List<MzOrder> GetMzOrdersByPatientId(string patient_id, int times)
        {

            string ghsql = GetSqlByTag(221002);
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            return Select(ghsql, para);
        }

        /// <summary>
        /// 提交门诊收费付款
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public bool Pay(string patient_id, int times, string pay_string, string opera)
        {

            try
            {
                DynamicParameters para = new DynamicParameters();

                int max_ledger_sn = 0;
                int max_item_sn = 0;

                string mxa_ledger_sql = GetSqlByTag(221005);

                para = new DynamicParameters();
                para.Add("@patient_id", patient_id);
                max_ledger_sn = Convert.ToInt32(ExcuteScalar(mxa_ledger_sql, para)) + 1;


                var op_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                var orderlist = GetMzOrdersByPatientId(patient_id, times);

                if (orderlist == null || orderlist.Count == 0)
                {
                    throw new Exception("未查询到处方信息");
                }

                var chargeList = chargesRepository.GetCprCharges(patient_id, times, "1");

                if (chargeList == null || chargeList.Count == 0)
                {
                    throw new Exception("该处方已经缴费");
                }

                //门诊机制发票号
                int max_sn = 0;

                string sql1 = GetSqlByTag(221006);

                //门诊发票号 根据当前用户获取  
                GhOpReceiptRepository opreceiptResp = new GhOpReceiptRepository();
                //p1: usermi,p2:1
                var dtreceipt = opreceiptResp.GetCurrentReceiptNo(opera);

                //更新发票号
                string sql3 = GetSqlByTag(221008);
                //p1:sql2 currentno,p2 opera,p3 date


                //查询药房信息
                //string sql4 = @"EXEC mzsf_GetDrugWin @P1, @P2',N'@P1 varchar(2),@P2 varchar(1)','02','1'";
                //p1 oder_code, p2 没用到

                //更新信息
                string sql5 = GetSqlByTag(221009);
                //sql4 结果

                //虚拟库存处理
                string sql6 = GetSqlByTag(221010);

                //更新 mz_patient_mi
                string sql7 = GetSqlByTag(221011);

                //更新 mz_visit_table
                string sql8 = GetSqlByTag(221012);

                //获取就诊信息
                string mz_sql = GetSqlByTag(221013);

                //9.更新detail_charge项目 
                string sql_detail_charge_zl = GetSqlByTag(221014);
                string sql_detail_charge_xy = GetSqlByTag(221015);

                //10.查询 写入mz_receipt_charge
                string sql10 = GetSqlByTag(221016);
                string sql11 = GetSqlByTag(221017);

                //11.写入mz_receipt
                string sql12 = GetSqlByTag(221018);

                //12.写入 mz_deposit
                string sql13 = GetSqlByTag(221019);

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        para = new DynamicParameters();

                        //获取就诊信息 
                        para.Add("@patient_id", patient_id);
                        para.Add("@times", times);

                        var mz_visit = connection.QueryFirstOrDefault<MzVisit>(mz_sql, para, transaction);

                        //1.获取机制号
                        max_sn = Convert.ToInt32(connection.ExecuteScalar(sql1, null, transaction));

                        //2.获取发票号 
                        var current_no = "";
                        var start_no = "";
                        var end_no = "";
                        DateTime happen_date = DateTime.MaxValue;
                        var step_length = 1;
                        var deleted_flag = "0";
                        var report_flag = "0";
                        var receipt_type = "0";
                        if (dtreceipt != null && dtreceipt.Count > 0)
                        {
                            current_no = dtreceipt[0].current_no.ToString();
                            start_no = dtreceipt[0].start_no.ToString();
                            end_no = dtreceipt[0].end_no.ToString();
                            happen_date = dtreceipt[0].happen_date;

                            step_length = dtreceipt[0].step_length;
                            deleted_flag = dtreceipt[0].deleted_flag;
                            report_flag = dtreceipt[0].report_flag;
                            receipt_type = dtreceipt[0].receipt_type;
                        }
                        //3.更新发票号
                        para = new DynamicParameters();
                        para.Add("@current_no", int.Parse(current_no) + step_length);
                        para.Add("@operator", opera);
                        para.Add("@happen_date", happen_date);
                        connection.Execute(sql3, para, transaction);

                        string order_code = "02";

                        var xiyao_list = orderlist.Where(p => p.order_type == order_code).ToList();
                        var xiyao_detail_list = chargeList.Where(p => p.order_type == order_code).ToList();

                        //4. 查询药房信息 (西药)
                        para = new DynamicParameters();
                        para.Add("@order_code", order_code);
                        para.Add("@@team_no", "1");
                        var drugwin = connection.QueryFirstOrDefault<DrugWin>("mzsf_GetDrugWin", para, transaction, null, CommandType.StoredProcedure);


                        if (xiyao_list != null && xiyao_list.Count > 0)
                        {
                            //5. 更新相关药房信息
                            if (drugwin != null)
                            {
                                para = new DynamicParameters();
                                para.Add("@P1", order_code);
                                para.Add("@P2", drugwin.group_no);
                                para.Add("@P3", drugwin.window_no);
                                //connection.Execute(sql5, para, transaction);
                            }

                            foreach (var item in xiyao_list)
                            {
                                connection.Execute(sql5, para, transaction);
                            }

                            foreach (var item in xiyao_detail_list)
                            {
                                //6.虚拟库存处理（西药药方细目）
                                para = new DynamicParameters();
                                para.Add("@P1", item.charge_amount);
                                para.Add("@P2", item.caoyao_fu);
                                para.Add("@P3", item.charge_code);
                                para.Add("@P4", "01"); //@serial ??
                                para.Add("@P5", drugwin.group_no);
                                connection.Execute(sql6, para, transaction);
                            }
                        }


                        //7.更新 mz_patient_mi 
                        para = new DynamicParameters();
                        para.Add("@max_ledger_sn", max_ledger_sn); //??
                        para.Add("@max_item_sn", 1);    //??
                        para.Add("@patient_id", patient_id);
                        connection.Execute(sql7, para, transaction);

                        //8.更新 mz_visit_table 
                        para = new DynamicParameters();
                        para.Add("@charge_status", 4);
                        para.Add("@charge_times", 1);  //??
                        para.Add("@patient_id", patient_id);
                        para.Add("@times", times);
                        connection.Execute(sql8, para, transaction);


                        //9.更新detail_charge项目
                        foreach (var item in chargeList)
                        {
                            if (item.order_type == "01")//诊疗
                            {
                                para = new DynamicParameters();
                                para.Add("@current_ledger_sn", max_ledger_sn);
                                para.Add("@price_data", op_date);
                                para.Add("@price_opera", opera);
                                para.Add("@confirm_date", op_date);
                                para.Add("@response_type", "01");//用户信息表身份
                                para.Add("@charge_type", "01");//用户信息表类型
                                para.Add("@sum_total", item.charge_amount * item.charge_price);
                                para.Add("@patient_id", patient_id);
                                para.Add("@times", times);
                                para.Add("@order_type", item.order_type);
                                para.Add("@order_no", item.order_no);
                                para.Add("@item_no", item.item_no);
                                para.Add("@ledger_sn", item.ledger_sn);

                                connection.Execute(sql_detail_charge_zl, para, transaction);
                            }
                            else if (item.order_type == "02")//西药
                            {
                                para = new DynamicParameters();
                                para.Add("@current_ledger_sn", max_ledger_sn);
                                para.Add("@price_data", op_date);
                                para.Add("@price_opera", opera);
                                para.Add("@confirm_date", op_date);
                                para.Add("@windows_no", drugwin.window_no);
                                para.Add("@confirm_win", drugwin.window_no);


                                para.Add("@response_type", "01");//用户信息表身份
                                para.Add("@charge_type", "01");//用户信息表类型
                                para.Add("@sum_total", item.charge_amount * item.charge_price);
                                para.Add("@patient_id", patient_id);
                                para.Add("@times", times);
                                para.Add("@order_type", item.order_type);
                                para.Add("@order_no", item.order_no);
                                para.Add("@item_no", item.item_no);
                                para.Add("@ledger_sn", item.ledger_sn);

                                connection.Execute(sql_detail_charge_xy, para, transaction);
                            }
                            else
                            {

                            }
                        }

                        //10.写入mz_receipt_charge  
                        //查询结果，有几条 写入几条
                        para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@times", times);
                        var chargeItemList = connection.Query<DetailChargeItem>(sql10, para, transaction);

                        foreach (var item in chargeItemList)
                        {
                            //写入
                            para = new DynamicParameters();
                            para.Add("@patient_id", patient_id);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@receipt_sn", current_no);
                            para.Add("@bill_code", item.bill_code);
                            para.Add("@charge", item.charge);
                            para.Add("@pay_unit", "01");//现金

                            connection.Execute(sql11, para, transaction);
                        }

                        //11.写入mz_receipt 
                        para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@ledger_sn", max_ledger_sn);
                        para.Add("@receipt_sn", max_sn);
                        para.Add("@pay_unit", "01");
                        para.Add("@charge_total", chargeItemList.Sum(p => p.charge));
                        para.Add("@charge_status", "4");
                        para.Add("@cash_date", op_date);
                        para.Add("@cash_opera", opera);
                        para.Add("@windows_no", drugwin.window_no);
                        para.Add("@receipt_no", current_no);
                        para.Add("@mz_dept_no", "1");
                        para.Add("@contract_code", "0100");

                        connection.Execute(sql12, para, transaction);

                        //12.写入 mz_deposit 

                        //处理多重支付
                        var pay_method_arr = pay_string.Split(',');
                        int item_no = 1;
                        foreach (var pay_method in pay_method_arr)
                        {
                            var pay_detail = pay_method.Split('-');
                            var cheque_type = pay_detail[0];
                            var charge = decimal.Parse(pay_detail[1]);
                            var out_trade_no = pay_detail[2];//订单编号
                            var cheque_no = current_no;
                            para = new DynamicParameters();


                            para = new DynamicParameters();
                            para.Add("@patient_id", patient_id);
                            para.Add("@item_no", item_no);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@cheque_type", cheque_type);
                            para.Add("@cheque_no", cheque_no);
                            para.Add("@charge", charge);
                            para.Add("@depo_status", "3");
                            para.Add("@windows_no", drugwin.window_no);
                            para.Add("@dcount_date", op_date);
                            para.Add("@dcount_id", opera);
                            para.Add("@mz_dept_no", "1");
                            para.Add("@out_trade_no", out_trade_no);

                            connection.Execute(sql13, para, transaction);


                            item_no++;
                        }

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


        public bool BackFee(string opera, string pid, int ledger_sn, string receipt_sn, string receipt_no, string cheque_cash, string isall = "1")
        {
            try
            { 
                var para = new DynamicParameters();

                para.Add("@opera", opera);
                para.Add("@pid", pid);
                para.Add("@ledger_sn", ledger_sn);
                para.Add("@receipt_sn", receipt_sn);
                para.Add("@receipt_no", receipt_no);
                para.Add("@cheque_cash", cheque_cash);
                para.Add("@isall", isall);
                ExecQuerySP("mzsf_BackFee2", para);

                string sql = @"INSERT INTO mz_receipt_cancel
         ( operator,   
           happen_date,   
           report_date,   
           receipt_sn,
           receipt_no,   
           subsys_id,
           mz_dept_no )  
  VALUES ( @operator,
            cast( convert(char(19),getdate(),121) as datetime) ,   
           null,
           @receipt_sn,
           @receipt_no,   
           @subsys_id,
           @mz_dept_no)";
                para = new DynamicParameters();
                para.Add("@operator", opera);
                para.Add("@receipt_sn", receipt_sn);
                para.Add("@receipt_no", receipt_no); 
                para.Add("@subsys_id", "mz");
                para.Add("@mz_dept_no", "1");

                Update(sql, para);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
