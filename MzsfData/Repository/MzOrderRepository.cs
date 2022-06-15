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
        public bool Pay(string patient_id, int times, string opera)
        {

            try
            {
                DynamicParameters para = new DynamicParameters();

                int max_ledger_sn = 0;
                int max_item_sn = 0;


                string leder_sql = @"
 SELECT ISNULL(MAX(ledger_sn), 1) ledger_sn  
     FROM  
     (  
   SELECT ledger_sn    
     FROM view_gh_deposit WITH(NOLOCK)  
    WHERE patient_id =  @patient_id   
     
   UNION ALL  
     
   SELECT ledger_sn    
     FROM view_mz_deposit WITH(NOLOCK)  
    WHERE patient_id =  @patient_id   
     
   UNION ALL  
     
   SELECT max_ledger_sn ledger_sn  
     FROM mz_patient_mi  WITH(NOLOCK) 
    WHERE patient_id =  @patient_id  
  ) aa  ";

                para = new DynamicParameters();
                para.Add("@patient_id", patient_id);
                max_ledger_sn = Convert.ToInt32(ExcuteScalar(leder_sql, para));


                var op_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                var orderlist = GetMzOrdersByPatientId(patient_id, times);

                var chargeList = chargesRepository.GetCprCharges(patient_id, times, "1");

                //门诊机制发票号
                int max_sn = 0;

                string sql1 = @"UPDATE mz_order_generator 
      SET max_sn = ISNULL(max_sn, 0) + 1
    WHERE define = 'mz_receipt_sn'    
   SELECT max_sn 
     FROM mz_order_generator
    WHERE define = 'mz_receipt_sn'";

                //门诊发票号 根据当前用户获取  
                GhOpReceiptRepository opreceiptResp = new GhOpReceiptRepository();
                //p1: usermi,p2:1
                var dtreceipt = opreceiptResp.GetCurrentReceiptNo(opera);

                //更新发票号
                string sql3 = @"update mz_op_receipt  set
 current_no = @P1
where
 operator = @P2 and
 happen_date = @P3";
                //p1:sql2 currentno,p2 opera,p3 date


                //查询药房信息
                string sql4 = @"EXEC mzsf_GetDrugWin @P1, @P2
',N'@P1 varchar(2),@P2 varchar(1)','02','1'";
                //p1 oder_code, p2 没用到

                //更新信息
                string sql5 = @"update mz_order_put set current_count=current_count+1 where order_code=@P1 and
 group_no=@P2 and window_no=@P3";
                //sql4 结果

                //虚拟库存处理
                string sql6 = @"declare @amount int
declare @fu int
declare @charge_code varchar(10)
declare @serial varchar(5)
declare @group varchar(10)
declare @DecRealStock char(1)
declare @DrugInfo varchar(100)
declare @GroupInfo varchar(50)
declare @ErrorInfo varchar(200)

set @amount=@P1
set @fu=@P2
set @charge_code=@P3
set @serial=@P4
set @group=@P5
set @DecRealStock=''0''   --0不减实库存

set nocount on
--获取药品及库房信息
SELECT @GroupInfo = ''库房：'' + dept_name + ''('' + @group + '')'' FROM yp_group_name WHERE group_no = @group 

SELECT @DrugInfo = ''药品：'' + drugname + ''/'' + specification + ''('' + @charge_code + ''/'' + @serial + '')''
    FROM yp_dict WHERE charge_code = @charge_code and serial = @serial

if exists(select * from sysobjects where id=object_id(''mz_sys_config'') and type=''U'')
begin
  if exists(select * from mz_sys_config where item_name=''DecRealStock'' and subsys_id=''mz'' and current_value=''1'')
    set @DecRealStock=''1''
end

if @DecRealStock=''0''     --减虚库存
begin
  UPDATE yp_base SET stock_amount2=stock_amount2 - @amount * @fu
  WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group

  if exists(select * from yp_base WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group and stock_amount2<0)
  begin
    set @ErrorInfo = ''库存量低于本次收费数量!'' + CHAR(13) + @GroupInfo + CHAR(13) + @DrugInfo 
    raiserror(@ErrorInfo,10,1) --raiserror 99999 @ErrorInfo
  end
end
else         --虚实库存都减
begin
  UPDATE yp_base SET stock_amount2=stock_amount2 - @amount * @fu,
     stock_amount=stock_amount - @amount * @fu
  WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group

  if exists(select * from yp_base WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group and stock_amount<0)
  begin
    set @ErrorInfo = ''实库存量低于本次收费数量!'' + CHAR(13) + @GroupInfo + CHAR(13) + @DrugInfo 
     raiserror(@ErrorInfo,10,1)/*raiserror 99999  @ErrorInfo */
  end;
end


";

                //更新 mz_patient_mi
                string sql7 = @"update mz_patient_mi  set
                         max_ledger_sn = @max_ledger_sn,
                         max_item_sn = @max_item_sn
                        where patient_id = @patient_id";

                //更新 mz_visit_table
                string sql8 = @"update mz_visit_table  set 
 charge_status = @charge_status,
 charge_times = @charge_times
where
 patient_id = @patient_id and
 times = @times";

                //更新mz_detail_charge
                string sql9 = "";



                //写入 mz_detail_charge mz_receipt


                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {

                        para = new DynamicParameters();
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

                        para.Add("@current_no", current_no + step_length);
                        para.Add("@operator", opera);
                        para.Add("@happen_date", happen_date);
                        connection.Execute(sql3, null, transaction);

                        string order_code = "02";

                        var xiyao_list = orderlist.Where(p => p.order_type == order_code).ToList();
                        var xiyao_detail_list = chargeList.Where(p => p.order_type == order_code).ToList();

                        //4. 查询药房信息 (西药)
                        para = new DynamicParameters();
                        para.Add("@P1", "02");
                        para.Add("@P2", "1");
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
                                //connection.Execute(sql5, null, transaction);
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
                        foreach (var item in xiyao_detail_list)
                        {
                            string sql = "";
                            if (item.order_type == "01")
                            {
                                sql = @"UPDATE mz_detail_charge SET ledger_sn = @ledger_sn, charge_status = '4', 
price_data = @price_data, price_opera = @price_opera, confirm_date =@confirm_date, infant_flag = '0', self_flag = '0', ope_flag = '0', 
emergency_flag = '0', response_type = @response_type, charge_type = @charge_type, sum_total =@sum_total
WHERE patient_id = @patient_id AND times = @times AND order_type = @order_type AND order_no = @order_no AND item_no =@item_no AND ledger_sn = @ledger_sn ";

                                para = new DynamicParameters();
                                para.Add("@ledger_sn", max_ledger_sn);
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

                                connection.Execute(sql, para, transaction);
                            }
                            else if (item.order_type == "02")
                            {

                                sql = @"UPDATE mz_detail_charge SET ledger_sn = @ledger_sn, charge_status = '4', price_data = @price_data,
price_opera = @price_opera, windows_no = @windows_no, confirm_win = @confirm_win, response_type = @response_type, charge_type = @charge_type, 
sum_total =@sum_total
WHERE patient_id = @patient_id AND times = @times AND order_type = @order_type AND order_no = @order_no AND item_no =@item_no AND ledger_sn = @ledger_sn";

                                para = new DynamicParameters();
                                para.Add("@ledger_sn", max_ledger_sn);
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

                                connection.Execute(sql, para, transaction);
                            }
                            else
                            {

                            }
                        }

                        //10.写入mz_receipt_charge
                        string sql10 = @" select patient_id,times,order_type,bill_code,sum(charge_amount* charge_price) charge from 
 mz_detail_charge 
 WHERE patient_id = @patient_id
 AND       times =@times 
 and charge_amount>0
 group by patient_id,times,order_type,bill_code";

                        //查询结果，有几条 写入几条
                        para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@times", times);
                        connection.Execute(sql10, para, transaction);

                        //11.写入mz_receipt


                        ////写入 mz_detail_charge mz_receipt
                        //string sql9 = "";



                        ////查询挂号信息
                        //var relist = ghResp.GetGhRecord(record_sn);
                        //int result = 0;

                        ////查询当前号是否超过数量
                        ////string exsitsql = "select * from gh_request where record_sn = @record_sn and current_no<= end_no";
                        //DynamicParameters para = new DynamicParameters();
                        //para.Add("@record_sn", record_sn);
                        //var obj = connection.QueryFirstOrDefault<GhRequest>(exsitsql, para, transaction);
                        //if (obj == null)
                        //{
                        //    throw new Exception("没有号了！");
                        //}
                        //var visit_date = obj.request_date;

                        ////更新挂号表 当前号haole
                        ////string sql1 = "UPDATE gh_request SET current_no =current_no+1 WHERE record_sn = @record_sn";
                        //para = new DynamicParameters();
                        //para.Add("@record_sn", record_sn);

                        //connection.Execute(sql1, para, transaction);

                        ////更新门诊用户信息 max_times
                        ////string sql2 = "update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=@patient_id " +
                        ////    "select max_ledger_sn,max_times from mz_patient_mi where  patient_id=@patient_id";

                        //para = new DynamicParameters();
                        //para.Add("@patient_id", patient_id);

                        //int max_ledger_sn = 0;
                        //int max_times = 0;

                        //var dt1 = Select(sql2, para);
                        //if (dt1 != null && dt1.Count > 0)
                        //{
                        //    max_ledger_sn = Convert.ToInt32(dt1[0].max_ledger_sn);
                        //    max_times = Convert.ToInt32(dt1[0].max_times);
                        //}

                        ////更新发票号
                        ////                        string sql3 = @"UPDATE mz_order_generator  
                        ////     SET max_sn = max_sn + 1
                        ////   WHERE(mz_order_generator.define = 'gh_receipt_sn')
                        ////SELECT mz_order_generator.max_sn
                        ////   FROM mz_order_generator
                        ////   WHERE(mz_order_generator.define = 'gh_receipt_sn') ";

                        //if (max_sn == 0)
                        //{
                        //    max_sn = Convert.ToInt32(connection.ExecuteScalar(sql3, null, transaction));
                        //}



                        //if (relist.Count > 0)
                        //{
                        //    var plist = GetPatientById(patient_id);

                        //    var recorditem = relist[0];
                        //    var patient = plist[0];

                        //    //写入mz_visit_table 
                        //    para = new DynamicParameters();
                        //    para.Add("@patient_id", patient_id);
                        //    para.Add("@times", max_times);
                        //    para.Add("@visit_dept", recorditem.unit_sn);
                        //    para.Add("@doctor_code", recorditem.doctor_sn);
                        //    para.Add("@visit_date", visit_date);
                        //    para.Add("@name", patient.name);
                        //    para.Add("@response_type", "01");
                        //    para.Add("@haoming_code", "07");
                        //    para.Add("@charge_type", "01");
                        //    para.Add("@age", patient.age);
                        //    para.Add("@group_sn", recorditem.group_sn);
                        //    para.Add("@clinic_type", recorditem.clinic_type);
                        //    para.Add("@req_type", recorditem.req_type);
                        //    para.Add("@gh_sequence", recorditem.current_no);
                        //    para.Add("@ampm", recorditem.ampm);
                        //    para.Add("@visit_flag", "1");
                        //    para.Add("@gh_opera", opera);
                        //    para.Add("@gh_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        //    int count = connection.Execute(visit_sql, para, transaction);

                        //}

                        ////查询挂号费
                        //var charge_code = "100001";
                        ////string ghsql = "select * from zd_charge_item where code = '" + charge_code + "' ";
                        ////var dt2 = DbHelper.ExecuteDataTable(ghsql);

                        ////var dt2 = chargeItemResp.GetChargeItemsByCode(charge_code);


                        //decimal charge_price = 0;
                        //decimal effective_price = 0;
                        //var audit_code = "";
                        //var mz_bill_item = "";
                        //var mz_charge_group = "";
                        //int itemno = 0;
                        ////写入挂号收费明细表
                        //foreach (var item in chargeItems)
                        //{
                        //    charge_price = Convert.ToDecimal(item.charge_price);
                        //    effective_price = Convert.ToDecimal(item.effective_price);
                        //    audit_code = Convert.ToString(item.audit_code);
                        //    mz_bill_item = Convert.ToString(item.mz_bill_item);
                        //    mz_charge_group = Convert.ToString(item.mz_charge_group);

                        //    para = new DynamicParameters();
                        //    para.Add("@patient_id", patient_id);
                        //    para.Add("@max_times", max_times);
                        //    para.Add("@item_no", ++itemno);
                        //    para.Add("@ledger_sn", max_ledger_sn);
                        //    para.Add("@happen_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //    para.Add("@charge_code", charge_code);
                        //    para.Add("@audit_code", audit_code);
                        //    para.Add("@bill_code", mz_bill_item);
                        //    para.Add("@exec_sn", "1010501");
                        //    para.Add("@apply_sn", "0000000");
                        //    para.Add("@org_price", charge_price);
                        //    para.Add("@charge_price", effective_price);
                        //    para.Add("@charge_amount", "1");
                        //    para.Add("@charge_group", mz_charge_group);
                        //    para.Add("@enter_opera", opera);
                        //    para.Add("@enter_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //    para.Add("@enter_win_no", "0");
                        //    para.Add("@confirm_opera", opera);
                        //    para.Add("@confirm_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //    para.Add("@confirm_win_no", "0");
                        //    para.Add("@charge_status", "4");
                        //    para.Add("@trans_flag", "0");
                        //    para.Add("@mz_dept_no", "1");

                        //    result = connection.Execute(sql4, para, transaction);
                        //}


                        ////写入现金流表

                        ////处理多重支付
                        //var pay_method_arr = pay_string.Split(',');
                        //int item_no = 1;
                        //foreach (var pay_method in pay_method_arr)
                        //{
                        //    var pay_detail = pay_method.Split('-');
                        //    var cheque_type = pay_detail[0];
                        //    var charge = decimal.Parse(pay_detail[1]);
                        //    var out_trade_no = pay_detail[2];//订单编号
                        //    var cheque_no = current_no;
                        //    para = new DynamicParameters();

                        //    para.Add("@patient_id", patient_id);
                        //    para.Add("@item_no", item_no);
                        //    para.Add("@ledger_sn", max_ledger_sn);
                        //    para.Add("@times", max_times);
                        //    para.Add("@cheque_no", cheque_no);
                        //    para.Add("@charge", charge);
                        //    para.Add("@cheque_type", cheque_type);
                        //    para.Add("@depo_status", "4");
                        //    para.Add("@price_opera", opera);
                        //    para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //    para.Add("@mz_dept_no", "1");
                        //    para.Add("@out_trade_no", out_trade_no);

                        //    result = connection.Execute(sql7, para, transaction);

                        //    item_no++;
                        //}

                        ////写入挂号发票明细表 

                        //decimal to_price = 0;

                        ////挂号费，诊查费等分批写入  
                        //foreach (var item in chargeItems)
                        //{
                        //    to_price += item.effective_price;

                        //    para = new DynamicParameters();

                        //    para.Add("@patient_id", patient_id);
                        //    para.Add("@times", max_times);
                        //    para.Add("@ledger_sn", max_ledger_sn);
                        //    para.Add("@receipt_sn", max_sn);
                        //    para.Add("@bill_code", item.mz_bill_item);
                        //    para.Add("@charge", item.effective_price);
                        //    para.Add("@pay_unit", "01");

                        //    result = connection.Execute(sql6, para, transaction);
                        //}
                        ////写入挂号发票表
                        //para = new DynamicParameters();

                        //para.Add("@patient_id", patient_id);
                        //para.Add("@times", max_times);
                        //para.Add("@ledger_sn", max_ledger_sn);
                        //para.Add("@receipt_sn", max_sn);
                        //para.Add("@pay_unit", "01");
                        //para.Add("@charge_total", to_price);
                        //para.Add("@settle_opera", opera);
                        //para.Add("@settle_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //para.Add("@price_opera", opera);
                        //para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //para.Add("@receipt_no", current_no);//gh_op_receipt receipt_no
                        //para.Add("@charge_status", "4");
                        //para.Add("@mz_dept_no", "1");

                        //result = connection.Execute(sql5, para, transaction);

                        //int new_no = Convert.ToInt32(current_no) + step_length;
                        //////更新挂号发票记录表

                        //para = new DynamicParameters();

                        //para.Add("@new_no", new_no.ToString().PadLeft(10, '0'));
                        //para.Add("@operator", opera);
                        //para.Add("@happen_date", happen_date);
                        //para.Add("@start_no", start_no);
                        //para.Add("@current_no", current_no);
                        //para.Add("@end_no", end_no);
                        //para.Add("@step_length", step_length);
                        //para.Add("@deleted_flag", deleted_flag);
                        //para.Add("@report_flag", report_flag);
                        //para.Add("@receipt_type", receipt_type);

                        //result = Update(sql8, para);

                        //max_ledger_sn++;




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


            return false;
        }

    }
}
