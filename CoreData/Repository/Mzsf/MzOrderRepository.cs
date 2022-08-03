using Dapper;
using Data.Entities.Mzsf;
using Data.Entities;
using Data.IRepository.Mzsf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository.Mzsf
{
    public class MzOrderRepository : RepositoryBase<MzOrder>, IMzOrderRepository
    {
        CprChargesRepository chargesRepository = new CprChargesRepository();
        public List<MzOrder> GetMzOrdersByPatientId(string patient_id, int times)
        {

            string ghsql = GetSqlByTag("mzsf_mzdetailcharge_getbypid");
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            return Select(ghsql, para);
        }

        /// <summary>
        /// 保存新增处方
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="times"></param>
        /// <param name="order_string">order_type-charge_code-charge_amount,order_type-charge_code-charge_amount;order_type-charge_code-charge_amount;</param>
        /// <param name="opera"></param>
        /// <returns></returns>
        public bool SaveOrder(string patient_id, int times, string order_string, string opera)
        {
            try
            {
                DynamicParameters para = new DynamicParameters();
                var dt_now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //查询挂号信息exec sp_executesql N'exec mzcpr_GetVisitInfo  @P1, @P2',N'@P1 varchar(20),@P2 int','000296903300',319
                        para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@times", times);
                        var visit_info = connection.QueryFirstOrDefault<MzVisit>("mzcpr_GetVisitInfo", para, transaction, null, CommandType.StoredProcedure);

                        string insert_sql = "";

                        //处方数
                        var orders = order_string.Split(";");
                        //foreach (var order in orders)
                        for (int i = 0; i < orders.Length; i++)
                        {
                            var order = orders[i];
                            //项目数组
                            var item_arr = order.Split(",");
                            //foreach (var item in item_arr)
                            for (int j = 0; j < item_arr.Length; j++)
                            {
                                var item = item_arr[j];
                                //类型，序号，名称，数量
                                var obj = item.Split("-");
                                string order_type = obj[0];
                                string order_no = obj[1];
                                string charge_code = obj[2];
                                string serial = obj[3];
                                string charge_amount = obj[4];

                                //其他数据根据charge_code查询获取

                                //查询药房信息
                                para = new DynamicParameters();
                                para.Add("@order_code", order_type);
                                para.Add("@team_no", "1");
                                DrugWin drugwin = connection.QueryFirstOrDefault<DrugWin>("mzsf_GetDrugWin", para, transaction, null, CommandType.StoredProcedure);

                                //根据处方类型和药品编码查询药品详情
                                string order_item_sql = "";
                                if (order_type == "01")
                                {
                                    //诊疗
                                    order_item_sql = GetSqlByTag("mzsf_huajia_zhenliao");


                                }
                                else if (order_type == "02")
                                {
                                    //西药
                                    order_item_sql = GetSqlByTag("mzsf_huajia_xiyao");


                                }
                                else if (order_type == "04")
                                {
                                    //草药
                                    order_item_sql = GetSqlByTag("mzsf_huajia_caoyao");
                                }

                                //类型不同，写入字段不一样
                                if (order_type == "01")
                                {
                                    insert_sql = GetSqlByTag("mzsf_mzdetailcharge_add_zhenliao");

                                    para = new DynamicParameters();
                                    para.Add("@code", charge_code);
                                    var order_item = connection.QueryFirstOrDefault<MzOrderItem>(order_item_sql, para, transaction);

                                    para = new DynamicParameters();

                                    para.Add("@charge_price", int.Parse(charge_amount) * order_item.orig_price);
                                    para.Add("@patient_id", patient_id);
                                    para.Add("@times", times);
                                    para.Add("@order_type", order_type);
                                    para.Add("@order_no", order_no);//todo:要加上已有的处方数量
                                    para.Add("@item_no", j + 1);
                                    para.Add("@ledger_sn", 0);
                                    para.Add("@charge_code", charge_code);
                                    para.Add("@serial_no", order_item.serial);
                                    para.Add("@group_no", order_item.group_no);

                                    para.Add("@charge_status", "1");
                                    para.Add("@bill_code", order_item.bill_item_code);
                                    para.Add("@audit_code", order_item.audit_code);
                                    para.Add("@exec_sn", order_item.exec_unit);
                                    para.Add("@charge_amount", int.Parse(charge_amount));
                                    para.Add("@orig_price", order_item.orig_price);
                                    para.Add("@charge_group", order_item.charge_group);
                                    para.Add("@caoyao_fu", 1);
                                    para.Add("@back_amount", 0);

                                    para.Add("@happen_date", dt_now);
                                    para.Add("@enter_date", dt_now);
                                    para.Add("@enter_opera", opera);
                                    para.Add("@windows_no", drugwin.window_no);
                                    para.Add("@dosage", order_item.dosage);
                                    para.Add("@persist_days", 1);
                                    para.Add("@dosage_unit", "");
                                    para.Add("@fit_type", "0");
                                    para.Add("@poision_flag", "0");

                                    para.Add("@charge_no", -2100301);  //todo 查询charge_no
                                    para.Add("@mz_dept_no", "1");
                                    para.Add("@apply_unit", visit_info.visit_dept);
                                    para.Add("@doctor_code", visit_info.doctor_code);
                                    para.Add("@name", visit_info.name);
                                    para.Add("@parent_no", 0);
                                    para.Add("@order_properties", "001");
                                    para.Add("@skin_test_flag", "0");
                                    para.Add("@change_drug_code", "0");
                                    para.Add("@order_sn", "935774");//todo 查询 order_sn

                                }
                                else
                                {
                                    insert_sql = GetSqlByTag("mzsf_mzdetailcharge_add_xiyao");

                                    para = new DynamicParameters();
                                    para.Add("@code", charge_code);
                                    para.Add("@serial", serial);
                                    var order_item = connection.QueryFirstOrDefault<MzOrderItem>(order_item_sql, para, transaction);

                                    para = new DynamicParameters();

                                    para.Add("@charge_price", int.Parse(charge_amount) * order_item.orig_price);
                                    para.Add("@patient_id", patient_id);
                                    para.Add("@times", times);
                                    para.Add("@order_type", order_type);
                                    para.Add("@order_no", order_no);//todo:要加上已有的处方数量
                                    para.Add("@item_no", j + 1);
                                    para.Add("@ledger_sn", 0);
                                    para.Add("@charge_code", charge_code);
                                    para.Add("@serial_no", order_item.serial);
                                    para.Add("@group_no", order_item.group_no);

                                    para.Add("@charge_status", "1");
                                    para.Add("@bill_code", order_item.bill_item_code);
                                    para.Add("@audit_code", order_item.audit_code);
                                    para.Add("@exec_sn", order_item.exec_unit);
                                    para.Add("@charge_amount", int.Parse(charge_amount));
                                    para.Add("@orig_price", order_item.orig_price);
                                    para.Add("@charge_group", order_item.charge_group);
                                    para.Add("@caoyao_fu", 1);
                                    para.Add("@back_amount", 0);

                                    para.Add("@happen_date", dt_now);
                                    para.Add("@enter_date", dt_now);
                                    para.Add("@enter_opera", opera);
                                    para.Add("@windows_no", drugwin.window_no);
                                    para.Add("@confirm_flag", 1);
                                    para.Add("@supply_code", "");
                                    //para.Add("@dosage", order_item.dosage);
                                    para.Add("@persist_days", 1);
                                    //para.Add("@dosage_unit", "");
                                    para.Add("@comment", "");
                                    para.Add("@fit_type", "0");
                                    para.Add("@self_flag", order_item.self_flag);
                                    para.Add("@separate_flag", order_item.separate_flag);
                                    para.Add("@supprice_flag", order_item.suprice_flag);
                                    para.Add("@poision_flag", "0");


                                    para.Add("@charge_no", -2100301);  //todo 查询charge_no
                                    para.Add("@mz_dept_no", "1");
                                    para.Add("@apply_unit", visit_info.visit_dept);
                                    para.Add("@doctor_code", visit_info.doctor_code);
                                    para.Add("@name", visit_info.name);
                                    para.Add("@parent_no", 0);
                                    para.Add("@order_properties", "001");
                                    para.Add("@skin_test_flag", "0");
                                    para.Add("@change_drug_code", "0");
                                    para.Add("@order_sn", "935774");//todo 查询 order_sn

                                }

                                connection.Execute(insert_sql, para, transaction);

                            }
                        }
                        para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@times", times);

                        connection.Execute("mzcpr_UpdatePatientInfo", para, transaction, null, CommandType.StoredProcedure);


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


        /// <summary>
        /// 提交门诊收费付款
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public int Pay(string patient_id, int times, string pay_string, string order_no_str, string opera)
        {

            try
            {
                DynamicParameters para = new DynamicParameters();

                int max_ledger_sn = 0;
                int max_item_sn = 0;
                string order_no_param = "";

                string mxa_ledger_sql = GetSqlByTag("mzsf_maxledgersn_get");

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

                if (!string.IsNullOrWhiteSpace(order_no_str))
                {
                    var order_no_arr = order_no_str.Split("-");

                    chargeList = chargeList.Where(p => order_no_arr.Contains(p.order_no)).ToList();

                    // order_no_param = string.Join(""','", order_no_arr);

                }

                //门诊机制发票号
                int max_sn = 0;

                string sql1 = GetSqlByTag("mzsf_receiptsn_get");

                //门诊发票号 根据当前用户获取  
                MzOpReceiptRepository opreceiptResp = new MzOpReceiptRepository();
                //p1: usermi,p2:1
                var dtreceipt = opreceiptResp.GetCurrentReceiptNo(opera);

                //更新发票号
                string sql3 = GetSqlByTag("mzsf_mzopreceipt_updateno");
                //p1:sql2 currentno,p2 opera,p3 date


                //查询药房信息
                //string sql4 = @"EXEC mzsf_GetDrugWin @P1, @P2',N'@P1 varchar(2),@P2 varchar(1)','02','1'";
                //p1 oder_code, p2 没用到

                //更新信息
                string sql5 = GetSqlByTag("mzsf_mzorderput_updatecount");
                //sql4 结果

                //虚拟库存处理
                string sql6 = GetSqlByTag("mzsf_ypbase_updatestock");

                //更新 mz_patient_mi
                string sql7 = GetSqlByTag("mzsf_mzpatient_updatetimes");

                //更新 mz_visit_table
                string sql8 = GetSqlByTag("mzsf_mzvisit_updatestatus");

                //获取就诊信息
                string mz_sql = GetSqlByTag("mzsf_mzvisit_getbypid");

                //9.更新detail_charge项目 
                string sql_detail_charge_zl = GetSqlByTag("mzsf_mzdetailcharge_update_zl");
                string sql_detail_charge_xy = GetSqlByTag("mzsf_mzdetailcharge_update_xy");
                string sql_detail_charge_cy = GetSqlByTag("mzsf_mzdetailcharge_update_cy");

                //10.查询 写入mz_receipt_charge
                string sql10 = GetSqlByTag("mzsf_mzdetailcharge_getitems");
                string sql11 = GetSqlByTag("mzsf_mzreceiptcharge_add");

                //11.写入mz_receipt
                string sql12 = GetSqlByTag("mzsf_mzreceipt_add");

                //12.写入 mz_deposit
                string sql13 = GetSqlByTag("mzsf_mzdeposit_add");

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
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
                        para.Add("@team_no", "1");
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
                                para.Add("@P4", item.serial_no); //@serial ??
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
                                para.Add("@sum_total", item.charge_price);
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
                                para.Add("@sum_total", item.charge_price);
                                para.Add("@patient_id", patient_id);
                                para.Add("@times", times);
                                para.Add("@order_type", item.order_type);
                                para.Add("@order_no", item.order_no);
                                para.Add("@item_no", item.item_no);
                                para.Add("@ledger_sn", item.ledger_sn);

                                connection.Execute(sql_detail_charge_xy, para, transaction);
                            }
                            else if (item.order_type == "04")//草药
                            {
                                para = new DynamicParameters();
                                para.Add("@current_ledger_sn", max_ledger_sn);
                                para.Add("@price_data", op_date);
                                para.Add("@price_opera", opera);
                                para.Add("@confirm_date", op_date);
                                para.Add("@group_no", drugwin.group_no);
                                para.Add("@windows_no", drugwin.window_no);
                                para.Add("@confirm_win", drugwin.window_no);
                                para.Add("@response_type", "01");//用户信息表身份
                                para.Add("@charge_type", "01");//用户信息表类型
                                para.Add("@sum_total", item.charge_price);
                                para.Add("@patient_id", patient_id);
                                para.Add("@times", times);
                                para.Add("@order_type", item.order_type);
                                para.Add("@order_no", item.order_no);
                                para.Add("@item_no", item.item_no);
                                para.Add("@ledger_sn", item.ledger_sn);

                                connection.Execute(sql_detail_charge_cy, para, transaction);
                            }
                            else
                            {
                                para = new DynamicParameters();
                                para.Add("@current_ledger_sn", max_ledger_sn);
                                para.Add("@price_data", op_date);
                                para.Add("@price_opera", opera);
                                para.Add("@confirm_date", op_date);
                                para.Add("@response_type", "01");//用户信息表身份
                                para.Add("@charge_type", "01");//用户信息表类型
                                para.Add("@sum_total", item.charge_price);
                                para.Add("@patient_id", patient_id);
                                para.Add("@times", times);
                                para.Add("@order_type", item.order_type);
                                para.Add("@order_no", item.order_no);
                                para.Add("@item_no", item.item_no);
                                para.Add("@ledger_sn", item.ledger_sn);

                                connection.Execute(sql_detail_charge_zl, para, transaction);
                            }
                        }

                        //10.写入mz_receipt_charge  
                        //查询结果，有几条 写入几条
                        para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@times", times);
                        para.Add("@ledger_sn", max_ledger_sn);
                        //para.Add("@order_no_str", order_no_param);

                        var chargeItemList = connection.Query<DetailChargeItem>(sql10, para, transaction);

                        if (!string.IsNullOrWhiteSpace(order_no_str))
                        {
                            var order_no_arr = order_no_str.Split("-");
                            chargeItemList = chargeItemList.Where(p => order_no_arr.Contains(p.order_no)).ToList();
                        }

                        //根据收费项目类型分组写入
                        var bill_list = (from c in chargeItemList
                                         group c by c.bill_code
                                        into s
                                         select new
                                         {
                                             bill_code = s.Max(m => m.bill_code),
                                             charge = s.Sum(m => m.charge)
                                         }).ToList();

                        foreach (var item in bill_list)
                        {
                            //写入
                            para = new DynamicParameters();
                            para.Add("@patient_id", patient_id);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@receipt_sn", max_sn);
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
                            //var cheque_no = current_no;
                            para = new DynamicParameters();


                            para = new DynamicParameters();
                            para.Add("@patient_id", patient_id);
                            para.Add("@item_no", item_no);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@cheque_type", cheque_type);
                            para.Add("@cheque_no", out_trade_no);
                            para.Add("@charge", charge);
                            para.Add("@depo_status", "3");
                            para.Add("@windows_no", drugwin.window_no);
                            para.Add("@dcount_date", op_date);
                            para.Add("@dcount_id", opera);
                            para.Add("@mz_dept_no", "1");
                            //para.Add("@out_trade_no", out_trade_no);
                            para.Add("@out_trade_no", "");

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

                    return max_ledger_sn;
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
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

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
                        connection.Execute("mzsf_BackFee2", para, transaction, null, CommandType.StoredProcedure);

                        string sql = GetSqlByTag("mzsf_mzreceiptcancel_add");
                        para = new DynamicParameters();
                        para.Add("@operator", opera);
                        para.Add("@receipt_sn", receipt_sn);
                        para.Add("@receipt_no", receipt_no);
                        para.Add("@subsys_id", "mz");
                        para.Add("@mz_dept_no", "1");
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

        public bool BackFeePart(string opera, string pid, int ledger_sn, string receipt_sn, string receipt_no, string cheque_cash, string refund_item_str)
        {
            try
            {
                DynamicParameters para = new DynamicParameters();
                var dt_now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //门诊发票号 根据当前用户获取  
                MzOpReceiptRepository opreceiptResp = new MzOpReceiptRepository();
                //p1: usermi,p2:1
                var dtreceipt = opreceiptResp.GetCurrentReceiptNo(opera);

                //更新发票号
                string sql3 = GetSqlByTag("mzsf_mzopreceipt_updateno");

                //整理退款项目
                List<string> charge_code_list = new List<string>();
                decimal refund_charge = 0;
                var refund_item_arr = refund_item_str.Split(",");
                foreach (var item in refund_item_arr)
                {
                    var refund_item = item.Split("-");
                    var order_type = refund_item[0];
                    var charge_code = refund_item[1];
                    var price = Convert.ToDecimal(refund_item[2]);

                    refund_charge += price;
                    charge_code_list.Add(charge_code);
                }


                using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        para = new DynamicParameters();

                        para.Add("@opera", opera);
                        para.Add("@pid", pid);
                        para.Add("@ledger_sn", ledger_sn);
                        para.Add("@receipt_sn", receipt_sn);
                        para.Add("@receipt_no", receipt_no);
                        para.Add("@cheque_cash", cheque_cash);
                        para.Add("@isall", '0');
                        connection.Execute("mzsf_BackFee2", para, transaction, null, CommandType.StoredProcedure);

                        string user_sql = GetSqlByTag("mzgh_mzpatient_getbypid");
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        var patient = connection.Query<Patient>(user_sql, para, transaction).FirstOrDefault();
                        int max_item_sn = patient.max_item_sn + 1;

                        string mxa_ledger_sql = GetSqlByTag("mzsf_maxledgersn_get");
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        int max_ledger_sn = Convert.ToInt32(ExcuteScalar(mxa_ledger_sql, para)) + 1;

                        string update_user_sql = GetSqlByTag("mzsf_patient_update_ledger");
                        para = new DynamicParameters();
                        para.Add("@max_ledger_sn", max_ledger_sn);
                        para.Add("@max_item_sn", max_item_sn);
                        para.Add("@patient_id", pid);
                        connection.Execute(update_user_sql, para, transaction);



                        //门诊机制发票号
                        int max_sn = 0;

                        string sql1 = GetSqlByTag("mzsf_receiptsn_get");

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


                        //查询当前处方的数据

                        //1.mz_detail_charge

                        string sql_1 = GetSqlByTag("mzsf_mzdetailcharge_getbypidandledger");
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        para.Add("@ledger_sn", ledger_sn);
                        var detail_charge_list = connection.Query<CprCharges>(sql_1, para, transaction).ToList();

                        //2.mz_deposit
                        string sql_2 = GetSqlByTag("mzsf_mzdeposit_getbypidandledger");
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        para.Add("@ledger_sn", ledger_sn);
                        var deposit_list = connection.Query<MzDeposit>(sql_2, para, transaction).ToList();

                        //3.mz_receipt
                        string sql_3 = GetSqlByTag("mzsf_mzreceipt_getbypidandledger");
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        para.Add("@ledger_sn", ledger_sn);
                        para.Add("@receipt_sn", receipt_sn);
                        var receipt_list = connection.Query<MzReceipt>(sql_3, para, transaction).ToList();

                        //4.mz_receipt_charge
                        string sql_4 = GetSqlByTag("mzsf_mzreceiptcharge_getbypidandledger");
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        para.Add("@ledger_sn", ledger_sn);
                        para.Add("@receipt_sn", receipt_sn);
                        var receipt_charge_list = connection.Query<MzReceiptCharge>(sql_4, para, transaction).ToList();


                        // mz_receipt_charge receipt_sn 不是统一的？？

                        //todo： 排除掉未勾选的项目进行写入操作

                        //写入没有退款的数据 leder_sn +1
                        string insert_1 = GetSqlByTag("mzsf_mzdetailcharge_add");

                        foreach (var item in detail_charge_list)
                        {
                            if (charge_code_list.Contains(item.charge_code))
                            {
                                //选择退款的，不写入
                                continue;
                            }

                            item.ledger_sn = max_ledger_sn;
                            item.confirm_date = dt_now;
                            item.enter_date = dt_now;
                            item.happen_date = dt_now;
                            item.price_date = dt_now;


                            //写入 
                            para = new DynamicParameters();

                            para.Add("@charge_price", item.charge_price);
                            para.Add("@patient_id", item.patient_id);
                            para.Add("@times", item.times);
                            para.Add("@order_type", item.order_type);
                            para.Add("@order_no", item.order_no);
                            para.Add("@item_no", item.item_no);
                            para.Add("@ledger_sn", item.ledger_sn);
                            para.Add("@charge_code", item.charge_code);
                            para.Add("@serial_no", item.serial_no);
                            para.Add("@group_no", item.group_no);

                            para.Add("@charge_status", item.charge_status);
                            para.Add("@bill_code", item.bill_code);
                            para.Add("@audit_code", item.audit_code);
                            para.Add("@exec_sn", item.exec_sn);
                            para.Add("@charge_amount", item.charge_amount);
                            para.Add("@orig_price", item.orig_price);
                            para.Add("@charge_group", item.charge_group);
                            para.Add("@caoyao_fu", item.caoyao_fu);
                            para.Add("@back_amount", item.back_amount);

                            para.Add("@happen_date", item.happen_date);
                            para.Add("@price_data", item.price_date);
                            para.Add("@confirm_date", item.confirm_date);
                            para.Add("@price_opera", opera);
                            para.Add("@enter_date", item.enter_date);
                            para.Add("@enter_opera", opera);
                            para.Add("@windows_no", item.windows_no);
                            para.Add("@confirm_flag", item.confirm_flag);
                            para.Add("@supply_code", item.supply_code);
                            para.Add("@dosage", item.dosage);
                            para.Add("@persist_days", item.persist_days);
                            para.Add("@dosage_unit", item.dosage_unit);
                            para.Add("@comment", item.comment);
                            para.Add("@fit_type", item.fit_type);
                            para.Add("@ope_flag", item.ope_flag);
                            para.Add("@emergency_flag", item.emergency_flag);
                            para.Add("@infant_flag", item.infant_flag);
                            para.Add("@self_flag", item.self_flag);
                            para.Add("@separate_flag", item.seperate_flag);
                            para.Add("@supprice_flag", item.supprice_flag);
                            para.Add("@poision_flag", item.poision_flag);
                            para.Add("@sum_total", item.sum_total);
                            para.Add("@response_type", item.response_type);
                            para.Add("@charge_type", item.charge_type);


                            para.Add("@charge_no", item.charge_no);  //todo 查询charge_no
                            para.Add("@mz_dept_no", item.mz_dept_no);
                            para.Add("@apply_unit", item.apply_unit);
                            para.Add("@doctor_code", item.doctor_code);
                            para.Add("@name", item.name);
                            para.Add("@parent_no", item.parent_no);
                            para.Add("@order_properties", item.order_properties);
                            para.Add("@skin_test_flag", item.skin_test_flag);
                            para.Add("@change_drug_code", item.change_drug_code);
                            para.Add("@order_sn", item.order_sn);//todo 查询 order_sn


                            connection.Execute(insert_1, para, transaction);

                        }

                        string insert_2 = GetSqlByTag("mzsf_mzdeposit_add2");
                        foreach (var item in deposit_list)
                        {

                            item.ledger_sn = max_ledger_sn;
                            item.dcount_date = Convert.ToDateTime(dt_now);
                            var charge = deposit_list.Sum(p => p.charge) - refund_charge;

                            para = new DynamicParameters();
                            para.Add("@patient_id", item.patient_id);
                            para.Add("@item_no", item.item_no);
                            para.Add("@ledger_sn", item.ledger_sn);
                            para.Add("@cheque_type", 1); ///这里的支付类型 是否是默认现金 ，金额
                            para.Add("@cheque_no", item.cheque_no);
                            para.Add("@charge", charge);
                            para.Add("@depo_status", item.depo_status);
                            para.Add("@windows_no", item.windows_no);
                            para.Add("@dcount_date", item.dcount_date);
                            para.Add("@dcount_id", item.dcount_id);
                            para.Add("@mz_dept_no", item.mz_dept_no);
                            para.Add("@out_trade_no", "");

                            connection.Execute(insert_2, para, transaction);

                            break;//模拟一次现金缴费

                        } 

                        string insert_3 = GetSqlByTag("mzsf_mzreceipt_add2");

                        foreach (var item in receipt_list)
                        {
                            item.ledger_sn = max_ledger_sn;
                            //item.backfee_date = "";
                            item.cash_date = Convert.ToDateTime(dt_now);
                            item.charge_total -= refund_charge; //减去退款的金额
                            item.receipt_sn = max_sn;
                            item.receipt_no = current_no;

                            para = new DynamicParameters();
                            para.Add("@patient_id", item.patient_id);
                            para.Add("@ledger_sn", item.ledger_sn);
                            para.Add("@receipt_sn", max_sn);
                            para.Add("@pay_unit", item.pay_unit);
                            para.Add("@charge_total", item.charge_total);
                            para.Add("@charge_status", item.charge_status);
                            para.Add("@cash_date", item.cash_date);
                            para.Add("@cash_opera", opera);
                            para.Add("@windows_no", item.windows_no);
                            para.Add("@receipt_no", item.receipt_no);
                            para.Add("@mz_dept_no", item.mz_dept_no);
                            para.Add("@contract_code", item.contract_code);
                            // para.Add("@backfee_date", item.backfee_date);

                            connection.Execute(insert_3, para, transaction);
                        }

                        //                        string sel_detail_charge = @"
                        //select patient_id,times,order_type,bill_code,exec_sn,sum(charge_amount* charge_price) charge from 
                        // mz_detail_charge 
                        // WHERE patient_id = @patient_id
                        // AND       ledger_sn =@ledger_sn
                        // and charge_amount>0
                        // group by patient_id,times,exec_sn,order_type,bill_code";

                        string sel_detail_charge = GetSqlByTag("mzsf_mzdetailcharge_getbypidledgeramount");
                                               
                        //查询结果，有几条 写入几条
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        para.Add("@ledger_sn", max_ledger_sn);


                        var chargeItemList = connection.Query<DetailChargeItem>(sel_detail_charge, para, transaction);

                        //根据收费项目类型分组写入
                        var bill_list = (from c in chargeItemList
                                         group c by c.bill_code
                                        into s
                                         select new
                                         {
                                             bill_code = s.Max(m => m.bill_code),
                                             charge = s.Sum(m => m.charge)
                                         }).ToList();

                        string insert_4 = GetSqlByTag("mzsf_mzreceiptcharge_add");
                         
                        foreach (var item in bill_list)
                        {
                            //写入
                            para = new DynamicParameters();
                            para.Add("@patient_id", pid);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@receipt_sn", max_sn);
                            para.Add("@bill_code", item.bill_code);
                            para.Add("@charge", item.charge);
                            para.Add("@pay_unit", "01");//现金

                            connection.Execute(insert_4, para, transaction);
                        }
 
                        //写入退费记录
                        string sql = GetSqlByTag("mzsf_mzreceiptcancel_add");
                        para = new DynamicParameters();
                        para.Add("@operator", opera);
                        para.Add("@receipt_sn", receipt_sn);
                        para.Add("@receipt_no", receipt_no);
                        para.Add("@subsys_id", "mz");
                        para.Add("@mz_dept_no", "1");

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
