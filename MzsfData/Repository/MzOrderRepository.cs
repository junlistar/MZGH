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

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //查询挂号信息exec sp_executesql N'exec mzcpr_GetVisitInfo  @P1, @P2',N'@P1 varchar(20),@P2 int','000296903300',319
                        para = new DynamicParameters();
                        para.Add("@P1", patient_id);
                        para.Add("@P2", times);
                        var visit_info = connection.QueryFirstOrDefault<MzVisit>("mzcpr_GetVisitInfo", para, transaction, null, CommandType.StoredProcedure);

                        //                    string sql = @"INSERT INTO mz_detail_charge 
                        //( charge_price, patient_id, times, order_type, order_no, item_no, ledger_sn, charge_code, serial_no, group_no, 
                        //charge_status, bill_code, audit_code, exec_sn, charge_amount, orig_price, charge_group, caoyao_fu, back_amount,
                        //happen_date, enter_date, enter_opera, windows_no, dosage, persist_days, dosage_unit, fit_type, poision_flag, 
                        //charge_no, mz_dept_no, apply_unit, doctor_code, name, parent_no, order_properties, skin_test_flag, change_drug_code, order_sn) 
                        //Values ( 25.000000, '000296903300', 319, '01', 1, 1, 0, '100097', '**', '%', '1', '009', '00009', '1021100', 1.000000, 25.000000, '12', 1, 0,
                        //'2022-06- 10:49:55', '2022-06-21 10:49:55', '00000', 1, 1.000000, 1, '', 0, '0',
                        //-2100301, '1', '1021100', '00000', 'IC卡测试', 0, '001', '0', 0, '935774') ";
                        //                    string sql = @"INSERT INTO mz_detail_charge 
                        //( charge_price, patient_id, times, order_type, order_no, item_no, ledger_sn, charge_code, serial_no, group_no,
                        //charge_status, bill_code, audit_code, exec_sn, charge_amount, orig_price, charge_group, caoyao_fu, back_amount,
                        //happen_date, enter_date, enter_opera, windows_no, confirm_flag, supply_code, dosage, persist_days, dosage_unit, comment, fit_type, self_flag,
                        //separate_flag, supprice_flag, poision_flag, charge_no, mz_dept_no, apply_unit, doctor_code, name, parent_no, order_properties, skin_test_flag, change_drug_code, order_sn) 
                        //Values ( 41.029900, '000296903300', 319, '02', 2, 2, 0, '002377', '01', '000003', '1', '001', '00001', '1021100', 1.000000, 41.029900, '02', 1, 0, 
                        //'2022-06-21 10:54:42', '2022-06-21 10:54:42', '00000', 1, '1', '001', 0.400000, 1, '17', 'hdaa', 0, '0', '0', '0', '0', -2100306, '1', '1021100', '00000', 'IC卡测试', 0, '001', '0', 0, '935775') ";

                        //                    string sql = @"INSERT INTO mz_detail_charge 
                        //( charge_price, patient_id, times, order_type, order_no, item_no, ledger_sn, charge_code, serial_no, group_no,
                        //charge_status, bill_code, audit_code, exec_sn, charge_amount, orig_price, charge_group, caoyao_fu, back_amount,
                        //happen_date, enter_date, enter_opera, windows_no, confirm_flag, freq_code, persist_days, dosage_unit, comment, fit_type, self_flag,
                        //separate_flag, supprice_flag, poision_flag, charge_no, mz_dept_no, apply_unit, doctor_code, name, parent_no, order_properties, skin_test_flag, change_drug_code, order_sn)
                        //Values ( 61.580000, '000296903300', 319, '04', 3, 1, 0, '000771', '00', '000004', '1', '001', '00001', '1021100', 1.000000, 61.580000, '02', 1, 0,
                        //'2022-06-21 10:54:57', '2022-06-21 10:54:57', '00000', 1, '1', 'ONCE', 1, '', 'bvbbxvcxvc', 0, '0', '0', '0', '0', -2100307, '1', '1021100', '00000', 'IC卡测试', 0, '001', '0', 0, '935776') ";

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
                                //类型，名称，数量
                                var obj = item.Split("-");
                                string order_type = obj[0];
                                string charge_code = obj[1];
                                string charge_amount = obj[2];

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
                                    order_item_sql = @"SELECT code,  
        case when  serial =''**'' then  name  else  name end name,
        specification,
        orig_price, 
        manufactory,
        serial, 
        dosage, 
        bill_item_code, 
        audit_code, 
        exec_unit, 
        charge_group, 
        self_flag, 
        separate_flag, 
        suprice_flag, 
        drug_flag, 
        mz_confirm_flag, 
        amount1, 
        amount2, 
        amount3, 
        amount4, 
        amount5, 
        item_flag ,
        group_no,
        group_name
  FROM view_mz_huajia_zhenliao
 WHERE    
        code =@code AND  
       code <> '000085'
ORDER BY len(py_code) ,d_code, name,amount1";


                                }
                                else if (order_type == "02")
                                {
                                    //西药
                                    order_item_sql = @"SELECT code,  
        name=case when  serial =''**'' then  name
  else  
name +''(''+specification+'')'' +'' ''+isnull(abname,'''') 
end,
        py_code,
        d_code
        cast(orig_price as decimal(38,6)) orig_price,
        stock_amount,
        specification, 
        manufactory,
        serial, 
        dosage, 
        bill_item_code, 
        audit_code, 
        exec_unit , 
        charge_group, 
        self_flag,
        separate_flag, 
        suprice_flag , 
        drug_flag,
        mz_confirm_flag, 
        amount1,
        amount2,
        amount3,
        amount4,
        amount5,
        item_flag ,
        group_no,
        group_name 
    FROM view_mz_huajia_xiyao
   WHERE code=@code AND  
         (bill_item_code like '001' OR
          bill_item_code like '003') AND
          group_no  like '000003'
ORDER BY d_code,py_code, name,serial DESC";


                                }
                                else if (order_type == "04")
                                {
                                    //草药
                                    order_item_sql = @"SELECT code,  
        name=case when  serial =''**'' then  name  else  name end,
        py_code,
        d_code,
        specification,
        cast(orig_price as decimal(38,6)) orig_price, 
        stock_amount ,     
        manufactory ,
        serial,
        dosage,
        bill_item_code, 
        audit_code,
        exec_unit,
        charge_group, 
        self_flag,
        separate_flag, 
        suprice_flag, 
        drug_flag, 
        mz_confirm_flag, 
        amount1, 
        amount2, 
        amount3, 
        amount4, 
        amount5, 
        item_flag ,
        group_no ,
        group_name 
    FROM view_mz_huajia_caoyao
   WHERE code=@code  AND  
         (bill_item_code like '002' OR                    
bill_item_code <> 'aa') AND
         (group_no  like '000004' OR group_no = '%') 
ORDER BY len(name)";
                                }

                                //类型不同，写入字段不一样
                                if (order_type == "01")
                                {
                                    insert_sql = @"INSERT INTO mz_detail_charge 
( charge_price, patient_id, times, order_type, order_no, item_no, ledger_sn, charge_code, serial_no, group_no, 
charge_status, bill_code, audit_code, exec_sn, charge_amount, orig_price, charge_group, caoyao_fu, back_amount,
happen_date, enter_date, enter_opera, windows_no, dosage, persist_days, dosage_unit, fit_type, poision_flag, 
charge_no, mz_dept_no, apply_unit, doctor_code, name, parent_no, order_properties, skin_test_flag, change_drug_code, order_sn) 
Values ( @charge_price, @patient_id, @times, @order_type, @order_no, @item_no, @ledger_sn, @charge_code, @serial_no, @group_no, 
@charge_status, @bill_code, @audit_code, @exec_sn, @charge_amount, @orig_price, @charge_group, @caoyao_fu, @back_amount,
@happen_date, @enter_date, @enter_opera, @windows_no, @dosage, @persist_days, @dosage_unit, @fit_type, @poision_flag, 
@charge_no, @mz_dept_no, @apply_unit, @doctor_code, @name, @parent_no, @order_properties, @skin_test_flag, @change_drug_code, @order_sn) ";

                                    para = new DynamicParameters();
                                    para.Add("@code", charge_code);
                                    var order_item = connection.QueryFirstOrDefault<MzOrderItem>(order_item_sql, para, transaction);

                                    para = new DynamicParameters();

                                    para.Add("@charge_price", int.Parse(charge_amount) * order_item.orig_price);
                                    para.Add("@patient_id", patient_id);
                                    para.Add("@times", times);
                                    para.Add("@order_type", order_type);
                                    para.Add("@order_no", i + 1);//todo:要加上已有的处方数量
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
                                    insert_sql = @"INSERT INTO mz_detail_charge 
( charge_price, patient_id, times, order_type, order_no, item_no, ledger_sn, charge_code, serial_no, group_no,
charge_status, bill_code, audit_code, exec_sn, charge_amount, orig_price, charge_group, caoyao_fu, back_amount,
happen_date, enter_date, enter_opera, windows_no, confirm_flag, supply_code, dosage, persist_days, dosage_unit, comment, fit_type, self_flag,
separate_flag, supprice_flag, poision_flag, charge_no, mz_dept_no, apply_unit, doctor_code, name, parent_no, order_properties, skin_test_flag, change_drug_code, order_sn) 
Values ( @charge_price, @patient_id, @times, @order_type, @order_no, @item_no, @ledger_sn, @charge_code, @serial_no, @group_no, 
@charge_status, @bill_code, @audit_code, @exec_sn, @charge_amount, @orig_price, @charge_group, @caoyao_fu, @back_amount,
@happen_date, @enter_date, @enter_opera, @windows_no, @confirm_flag, @supply_code, @dosage, @persist_days, @dosage_unit, @comment, @fit_type, @self_flag,
@separate_flag, @supprice_flag, @poision_flag, @charge_no, @mz_dept_no, @apply_unit, @doctor_code, @name, @parent_no, @order_properties, @skin_test_flag, @change_drug_code, @order_sn) ";

                                    para = new DynamicParameters();
                                    para.Add("@code", charge_code);
                                    var order_item = connection.QueryFirstOrDefault<MzOrderItem>(order_item_sql, para, transaction);

                                    para = new DynamicParameters();

                                    para.Add("@charge_price", int.Parse(charge_amount) * order_item.orig_price);
                                    para.Add("@patient_id", patient_id);
                                    para.Add("@times", times);
                                    para.Add("@order_type", order_type);
                                    para.Add("@order_no", i + 1);//todo:要加上已有的处方数量
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
                                    para.Add("@dosage", order_item.dosage);
                                    para.Add("@persist_days", 1);
                                    para.Add("@dosage_unit", "");
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
                string sql_detail_charge_cy = GetSqlByTag(221022);

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
                                para.Add("@sum_total", item.charge_amount * item.charge_price);
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
                                para.Add("@sum_total", item.charge_amount * item.charge_price);
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
                        var chargeItemList = connection.Query<DetailChargeItem>(sql10, para, transaction);

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
