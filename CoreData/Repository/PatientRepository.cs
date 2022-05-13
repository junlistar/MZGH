using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {


        ChargeItemRepository chargeItemResp = new ChargeItemRepository();
        GhOpReceiptRepository opreceiptResp = new GhOpReceiptRepository();
        GhRequestRepository ghResp = new GhRequestRepository();
         

        public List<Patient> GetPatientByCard(string cardno)
        {
            string selectSql = @"select distinct a.patient_id, a.max_times times, a.[name], a.sex, a.birthday, cast(DateDiff(YY,a.birthday, GetDate()) as float) age, a.response_type, a.contract_code, a.occupation_type, a.charge_type, '07' haoming_code, '2969317' code, inpatient_no, getdate() visit_date, 
a.social_no, '07' real_haoming_code, a.home_district, a.home_street, a.relation_tel, a.hic_no, a.addition_no1, a.home_tel, a.relation_name, a.relation_code, a.max_times real_times, a.p_bar_code, a.p_bar_code2, a.black_flag, a.address, a.poverty_code, a.employer_name, a.employer_street, employer_district,
a.employer_tel, a.allergic_diag, a.marry_code, a.max_times, a.max_ledger_sn, a.max_receipt_sn, a.max_item_sn, a.enter_opera, a.enter_date, a.update_opera, a.update_date from 
 mz_patient_mi a where 
a.p_bar_code = @cardno or a.social_no=@cardno or a.hic_no=@cardno order by max_ledger_sn desc";

            var para = new DynamicParameters();
            para.Add("@cardno", cardno);

            return Select(selectSql, para);


        }
        public List<Patient> GetPatientById(string pid)
        {
            string selectSql = @"select distinct a.patient_id, a.max_times times, a.[name], a.sex, a.birthday, cast(DateDiff(YY,a.birthday, GetDate()) as float) age, a.response_type, a.contract_code, a.occupation_type, a.charge_type, '07' haoming_code, '2969317' code, inpatient_no, getdate() visit_date, 
a.social_no, '07' real_haoming_code, a.home_district, a.home_street, a.relation_tel, a.hic_no, a.addition_no1, a.home_tel, a.relation_name, a.relation_code, a.max_times real_times, a.p_bar_code, a.p_bar_code2, a.black_flag, a.address, a.poverty_code, a.employer_name, a.employer_street, employer_district,
a.employer_tel, a.allergic_diag, a.marry_code, a.max_times, a.max_ledger_sn, a.max_receipt_sn, a.max_item_sn, a.enter_opera, a.enter_date, a.update_opera, a.update_date from 
 mz_patient_mi a where 
a.patient_id=@patient_id ";

            var para = new DynamicParameters();
            para.Add("@patient_id", pid);

            return Select(selectSql, para);
        }
        public List<Patient> GetPatientByBarcode(string barcode)
        {
            string selectSql = @"select * from mz_patient_mi a where a.p_bar_code=@barcode ";

            var para = new DynamicParameters();
            para.Add("@barcode", barcode);

            return Select(selectSql, para);
        }

        public List<Patient> GetPatientByPatientId(string pid)
        {
            string selectSql = @"select * from mz_patient_mi a where a.patient_id=@patient_id ";
            if (pid.Length == 7)
            {
                pid = "000" + pid + "00";
            }
            var para = new DynamicParameters();
            para.Add("@patient_id", pid);

            return Select(selectSql, para);
        }

        public int DeleteSocialNo(string sno)
        {
            string sql = "UPDATE mz_patient_mi SET social_no='' WHERE social_no=@sno";
            var para = new DynamicParameters();
            para.Add("@sno", sno);
            return Update(sql, para);
        }


        public int EditUserInfo(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
             string home_district, string home_street, string occupation_type, string response_type, string charge_type,string opera)
        { 
            //查询是否存在
            string issql = "select * from mz_patient_mi where patient_id = @patient_id";
            var para = new DynamicParameters();
            if (pid.Length==7)
            {
                pid = "000" + pid + "00";
            }
            para.Add("@patient_id", pid);
            var list = Select(issql, para);
            if (list != null && list.Count > 0)
            {
                //修改

                string sql = @"update mz_patient_mi
set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type,update_date=@update_date,update_opera=@update_opera
where patient_id=@patient_id";
                para = new DynamicParameters();
                para.Add("@social_no", sno);
                para.Add("@hic_no", hicno);
                para.Add("@p_bar_code", barcode);
                para.Add("@name", name);
                para.Add("@sex", sex);
                para.Add("@birthday", birthday);
                para.Add("@tel", tel);
                para.Add("@home_district", home_district);
                para.Add("@home_street", home_street);
                para.Add("@occupation_type", occupation_type);
                para.Add("@response_type", response_type);
                para.Add("@charge_type", charge_type);
                para.Add("@update_date", DateTime.Now);// DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")
                para.Add("@update_opera", opera);
                para.Add("@patient_id", pid);

                return Update(sql, para);
            }
            else
            {
                //新增
               
                string sql = @"insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,
balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,
home_district,home_street,occupation_type,response_type,charge_type,enter_date,update_date,enter_opera,update_opera) values
(@patient_id,@social_no,@hic_no,@p_bar_code,@name,@sex,@birthday,@home_tel,'0',0,0,0,0,
@home_district,@home_street,@occupation_type,@response_type,@charge_type,@enter_date,@update_date,@enter_opera,@update_opera)";

                para = new DynamicParameters();
                para.Add("@patient_id", pid);
                para.Add("@social_no", sno);
                para.Add("@hic_no", hicno);
                para.Add("@p_bar_code", barcode);
                para.Add("@name", name);
                para.Add("@sex", int.Parse(sex));
                para.Add("@birthday", birthday);
                para.Add("@home_tel", tel);

                para.Add("@home_district", home_district);
                para.Add("@home_street", home_street);
                para.Add("@occupation_type", occupation_type);
                para.Add("@response_type", response_type);
                para.Add("@charge_type", charge_type);

                para.Add("@enter_date", DateTime.Now);
                para.Add("@update_date", DateTime.Now);

                para.Add("@enter_opera", opera);
                para.Add("@update_opera", opera);


                return Update(sql, para);
            }



        }

        //未加事务
        public bool GuaHao11(string patient_id, string record_sn, string pay_string, string opera)
        {
            try
            {

                //查询挂号信息
                var relist = ghResp.GetGhRecord(record_sn);
                int result = 0;

                //更新挂号表 当前号
                string sql1 = "UPDATE gh_request SET current_no =current_no+1 WHERE record_sn = @record_sn";
                DynamicParameters para = new DynamicParameters();
                para.Add("@record_sn", record_sn);


                Update(sql1, para);

                //更新门诊用户信息 max_times
                string sql2 = "update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=@patient_id " +
                    "select max_ledger_sn,max_times from mz_patient_mi where  patient_id=@patient_id";
                //, name = 'test0328', sex = '1', response_type = '01',
                //charge_type = '01', black_flag = '', birthday = '2009-03-28', p_bar_code = '2969317',
                //relation_name = 'test0328' where patient_id like '000296931700'
                para = new DynamicParameters();
                para.Add("@patient_id", patient_id);

                int max_ledger_sn = 0;
                int max_times = 0;

                var dt1 = Select(sql2, para);
                if (dt1 != null && dt1.Count > 0)
                {
                    max_ledger_sn = Convert.ToInt32(dt1[0].max_ledger_sn);
                    max_times = Convert.ToInt32(dt1[0].max_times);
                }


                //更新发票号
                string sql3 = @"UPDATE mz_order_generator  
     SET max_sn = max_sn + 1
   WHERE(mz_order_generator.define = 'gh_receipt_sn')
SELECT mz_order_generator.max_sn
   FROM mz_order_generator
   WHERE(mz_order_generator.define = 'gh_receipt_sn') ";
                int max_sn = Convert.ToInt32(ExcuteScalar(sql3, null));



                if (relist.Count > 0)
                {
                    var plist = GetPatientById(patient_id);

                    var recorditem = relist[0];
                    var patient = plist[0];

                    //写入mz_visit_table
                    string visit_sql = @"insert into mz_visit_table(patient_id,times,visit_dept,doctor_code,visit_date,name,response_type,haoming_code,charge_type,
age,group_sn,clinic_type,req_type,gh_sequence,ampm,visit_flag,gh_opera,gh_date) values
(@patient_id,@times,@visit_dept,@doctor_code,@visit_date,@name,@response_type,@haoming_code,@charge_type,
@age,@group_sn,@clinic_type,@req_type,@gh_sequence,@ampm,@visit_flag,@gh_opera,@gh_date)";
                    para = new DynamicParameters();
                    para.Add("@patient_id", patient_id);
                    para.Add("@times", max_times);
                    para.Add("@visit_dept", recorditem.unit_sn);
                    para.Add("@doctor_code", recorditem.doctor_sn);
                    para.Add("@visit_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    para.Add("@name", patient.name);
                    para.Add("@response_type", "01");
                    para.Add("@haoming_code", "07");
                    para.Add("@charge_type", "01");
                    para.Add("@age", patient.age);
                    para.Add("@group_sn", recorditem.group_sn);
                    para.Add("@clinic_type", recorditem.clinic_type);
                    para.Add("@req_type", recorditem.req_type);
                    para.Add("@gh_sequence", recorditem.current_no);
                    para.Add("@ampm", recorditem.ampm);
                    para.Add("@visit_flag", "1");
                    para.Add("@gh_opera", opera);
                    para.Add("@gh_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    int count = Update(visit_sql, para);

                }

                //查询挂号费
                var charge_code = "100001";
                //string ghsql = "select * from zd_charge_item where code = '" + charge_code + "' ";
                //var dt2 = DbHelper.ExecuteDataTable(ghsql);

                //var dt2 = chargeItemResp.GetChargeItemsByCode(charge_code);

                var chargeItems = chargeItemResp.GetChargeItemsByRecordSN(record_sn);

                decimal charge_price = 0;
                decimal effective_price = 0;
                var audit_code = "";
                var mz_bill_item = "";
                var mz_charge_group = "";
                int itemno = 0;
                //写入挂号收费明细表
                foreach (var item in chargeItems)
                {
                    charge_price = Convert.ToDecimal(item.charge_price);
                    effective_price = Convert.ToDecimal(item.effective_price);
                    audit_code = Convert.ToString(item.audit_code);
                    mz_bill_item = Convert.ToString(item.mz_bill_item);
                    mz_charge_group = Convert.ToString(item.mz_charge_group);


                    string sql4 = @"insert into gh_detail_charge
  (patient_id, times, item_no, ledger_sn, happen_date, charge_code, audit_code, bill_code, exec_sn, apply_sn,
org_price, charge_price, charge_amount, charge_group, enter_opera, enter_date, enter_win_no, 
confirm_opera, confirm_date, confirm_win_no, charge_status, trans_flag, mz_dept_no)
values (@patient_id, @max_times, @item_no, @ledger_sn, @happen_date, @charge_code, @audit_code, @bill_code, @exec_sn, @apply_sn,
@org_price, @charge_price, @charge_amount, @charge_group,@enter_opera, @enter_date, @enter_win_no,
@confirm_opera,@confirm_date, @confirm_win_no, @charge_status, @trans_flag, @mz_dept_no)";

                    para = new DynamicParameters();
                    para.Add("@patient_id", patient_id);
                    para.Add("@max_times", max_times);
                    para.Add("@item_no", ++itemno);
                    para.Add("@ledger_sn", max_ledger_sn);
                    para.Add("@happen_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    para.Add("@charge_code", charge_code);
                    para.Add("@audit_code", audit_code);
                    para.Add("@bill_code", mz_bill_item);
                    para.Add("@exec_sn", "1010501");
                    para.Add("@apply_sn", "0000000");
                    para.Add("@org_price", charge_price);
                    para.Add("@charge_price", effective_price);
                    para.Add("@charge_amount", "1");
                    para.Add("@charge_group", mz_charge_group);
                    para.Add("@enter_opera", opera);
                    para.Add("@enter_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    para.Add("@enter_win_no", "0");
                    para.Add("@confirm_opera", opera);
                    para.Add("@confirm_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    para.Add("@confirm_win_no", "0");
                    para.Add("@charge_status", "4");
                    para.Add("@trans_flag", "0");
                    para.Add("@mz_dept_no", "1");

                    result = Update(sql4, para);
                    //var result = DbHelper.ExecuteNonQuery(sql4, para);
                }
                var dtreceipt = opreceiptResp.GetCurrentReceiptNo();
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
                //写入现金流表
                string sql7 = @"insert into gh_deposit
  (patient_id, item_no, ledger_sn, times, charge, cheque_type, cheque_no, depo_status, price_opera, price_date, mz_dept_no)
values
  (@patient_id, @item_no, @ledger_sn, @times, @charge, @cheque_type,@cheque_no, @depo_status, @price_opera, @price_date, @mz_dept_no)";

                //处理多重支付
                var pay_method_arr = pay_string.Split(',');
                int item_no = 1;
                //if (pay_method_arr.Length > 1)
                //{
                //    max_ledger_sn = 1;
                //}
                foreach (var pay_method in pay_method_arr)
                {
                    var pay_detail = pay_method.Split('-');
                    var cheque_type = pay_detail[0];
                    var charge = decimal.Parse(pay_detail[1]);
                    var out_trade_no = pay_detail[2];//订单编号

                    para = new DynamicParameters();

                    para.Add("@patient_id", patient_id);
                    para.Add("@item_no", item_no);
                    para.Add("@ledger_sn", max_ledger_sn);
                    para.Add("@times", max_times);
                    para.Add("@cheque_no", out_trade_no);
                    para.Add("@charge", charge);
                    para.Add("@cheque_type", cheque_type);
                    para.Add("@depo_status", "4");
                    para.Add("@price_opera", opera);
                    para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    para.Add("@mz_dept_no", "1");

                    result = Update(sql7, para);

                    item_no++;
                }



                //写入挂号发票明细表
                string sql6 = @"insert into gh_receipt_charge
  (patient_id, times, ledger_sn, receipt_sn, bill_code, charge, pay_unit)
values
  (@patient_id, @times, @ledger_sn, @receipt_sn, @bill_code, @charge, @pay_unit) ";

                decimal to_price = 0;

                //挂号费，诊查费等分批写入  
                foreach (var item in chargeItems)
                {
                    to_price += item.effective_price;

                    para = new DynamicParameters();

                    para.Add("@patient_id", patient_id);
                    para.Add("@times", max_times);
                    para.Add("@ledger_sn", max_ledger_sn);
                    para.Add("@receipt_sn", max_sn);
                    para.Add("@bill_code", item.mz_bill_item);
                    para.Add("@charge", item.effective_price);
                    para.Add("@pay_unit", "01");

                    result = Update(sql6, para);
                }

                //写入挂号发票表
                string sql5 = @"insert into gh_receipt
  (patient_id, times, ledger_sn, receipt_sn, pay_unit, charge_total, settle_opera, settle_date, price_opera, price_date, receipt_no, charge_status, mz_dept_no)
values
  (@patient_id,@times,@ledger_sn, @receipt_sn, @pay_unit, @charge_total, @settle_opera,@settle_date, @price_opera, @price_date, @receipt_no, @charge_status, @mz_dept_no)";
                para = new DynamicParameters();

                para.Add("@patient_id", patient_id);
                para.Add("@times", max_times);
                para.Add("@ledger_sn", max_ledger_sn);
                para.Add("@receipt_sn", max_sn);
                para.Add("@pay_unit", "01");
                para.Add("@charge_total", to_price);
                para.Add("@settle_opera", opera);
                para.Add("@settle_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                para.Add("@price_opera", opera);
                para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                para.Add("@receipt_no", current_no);//gh_op_receipt receipt_no
                para.Add("@charge_status", "4");
                para.Add("@mz_dept_no", "1");

                result = Update(sql5, para);


                int new_no = Convert.ToInt32(current_no) + step_length;
                //更新挂号发票记录表
                string sql8 = @"update gh_op_receipt  set
                                 current_no = @new_no 
                                 where
                                 operator = @operator and
                                 happen_date = @happen_date and
                                 start_no = @start_no and
                                 current_no = @current_no and
                                 end_no = @end_no and
                                 step_length =@step_length and
                                 deleted_flag = @deleted_flag and
                                 report_flag = @report_flag and
                                 receipt_type = @receipt_type";


                para = new DynamicParameters();

                para.Add("@new_no", new_no.ToString().PadLeft(10, '0'));
                para.Add("@operator", opera);
                para.Add("@happen_date", happen_date);
                para.Add("@start_no", start_no);
                para.Add("@current_no", current_no);
                para.Add("@end_no", end_no);
                para.Add("@step_length", step_length);
                para.Add("@deleted_flag", deleted_flag);
                para.Add("@report_flag", report_flag);
                para.Add("@receipt_type", receipt_type);

                result = Update(sql8, para);

                max_ledger_sn++;



            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 加上事务处理
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="record_sn"></param>
        /// <param name="pay_string"></param>
        /// <param name="opera"></param>
        /// <returns></returns>
        public bool GuaHao(string patient_id, string record_sn, string pay_string, string opera)
        {
            try
            {

                var chargeItems = chargeItemResp.GetChargeItemsByRecordSN(record_sn);
                var dtreceipt = opreceiptResp.GetCurrentReceiptNo();
              

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //查询挂号信息
                        var relist = ghResp.GetGhRecord(record_sn);
                        int result = 0;

                        //查询当前号是否超过数量
                        string exsitsql = "select * from gh_request where record_sn = @record_sn and current_no<= end_no";
                        DynamicParameters para = new DynamicParameters();
                        para.Add("@record_sn", record_sn);
                        var obj = connection.QueryFirstOrDefault<GhRequest>(exsitsql, para,transaction);
                        if (obj==null)
                        {
                            throw new Exception("没有号了！");
                        }
                        var visit_date = obj.request_date;

                        //更新挂号表 当前号haole
                        string sql1 = "UPDATE gh_request SET current_no =current_no+1 WHERE record_sn = @record_sn";
                        para = new DynamicParameters();
                        para.Add("@record_sn", record_sn);

                        connection.Execute(sql1, para, transaction);

                        //更新门诊用户信息 max_times
                        string sql2 = "update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=@patient_id " +
                            "select max_ledger_sn,max_times from mz_patient_mi where  patient_id=@patient_id";
                        //, name = 'test0328', sex = '1', response_type = '01',
                        //charge_type = '01', black_flag = '', birthday = '2009-03-28', p_bar_code = '2969317',
                        //relation_name = 'test0328' where patient_id like '000296931700'
                        para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);

                        int max_ledger_sn = 0;
                        int max_times = 0;

                        var dt1 = Select(sql2, para);
                        if (dt1 != null && dt1.Count > 0)
                        {
                            max_ledger_sn = Convert.ToInt32(dt1[0].max_ledger_sn);
                            max_times = Convert.ToInt32(dt1[0].max_times);
                        }


                        //更新发票号
                        string sql3 = @"UPDATE mz_order_generator  
     SET max_sn = max_sn + 1
   WHERE(mz_order_generator.define = 'gh_receipt_sn')
SELECT mz_order_generator.max_sn
   FROM mz_order_generator
   WHERE(mz_order_generator.define = 'gh_receipt_sn') ";
                        int max_sn = Convert.ToInt32(connection.ExecuteScalar(sql3, null, transaction));

                        if (relist.Count > 0)
                        {
                            var plist = GetPatientById(patient_id);

                            var recorditem = relist[0];
                            var patient = plist[0];

                            //写入mz_visit_table
                            string visit_sql = @"insert into mz_visit_table(patient_id,times,visit_dept,doctor_code,visit_date,name,response_type,haoming_code,charge_type,
age,group_sn,clinic_type,req_type,gh_sequence,ampm,visit_flag,gh_opera,gh_date) values
(@patient_id,@times,@visit_dept,@doctor_code,@visit_date,@name,@response_type,@haoming_code,@charge_type,
@age,@group_sn,@clinic_type,@req_type,@gh_sequence,@ampm,@visit_flag,@gh_opera,@gh_date)";
                            para = new DynamicParameters();
                            para.Add("@patient_id", patient_id);
                            para.Add("@times", max_times);
                            para.Add("@visit_dept", recorditem.unit_sn);
                            para.Add("@doctor_code", recorditem.doctor_sn);
                            para.Add("@visit_date", visit_date);
                            para.Add("@name", patient.name);
                            para.Add("@response_type", "01");
                            para.Add("@haoming_code", "07");
                            para.Add("@charge_type", "01");
                            para.Add("@age", patient.age);
                            para.Add("@group_sn", recorditem.group_sn);
                            para.Add("@clinic_type", recorditem.clinic_type);
                            para.Add("@req_type", recorditem.req_type);
                            para.Add("@gh_sequence", recorditem.current_no);
                            para.Add("@ampm", recorditem.ampm);
                            para.Add("@visit_flag", "1");
                            para.Add("@gh_opera", opera);
                            para.Add("@gh_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            int count = connection.Execute(visit_sql, para, transaction);

                        }

                        //查询挂号费
                        var charge_code = "100001";
                        //string ghsql = "select * from zd_charge_item where code = '" + charge_code + "' ";
                        //var dt2 = DbHelper.ExecuteDataTable(ghsql);

                        //var dt2 = chargeItemResp.GetChargeItemsByCode(charge_code);


                        decimal charge_price = 0;
                        decimal effective_price = 0;
                        var audit_code = "";
                        var mz_bill_item = "";
                        var mz_charge_group = "";
                        int itemno = 0;
                        //写入挂号收费明细表
                        foreach (var item in chargeItems)
                        {
                            charge_price = Convert.ToDecimal(item.charge_price);
                            effective_price = Convert.ToDecimal(item.effective_price);
                            audit_code = Convert.ToString(item.audit_code);
                            mz_bill_item = Convert.ToString(item.mz_bill_item);
                            mz_charge_group = Convert.ToString(item.mz_charge_group);


                            string sql4 = @"insert into gh_detail_charge
  (patient_id, times, item_no, ledger_sn, happen_date, charge_code, audit_code, bill_code, exec_sn, apply_sn,
org_price, charge_price, charge_amount, charge_group, enter_opera, enter_date, enter_win_no, 
confirm_opera, confirm_date, confirm_win_no, charge_status, trans_flag, mz_dept_no)
values (@patient_id, @max_times, @item_no, @ledger_sn, @happen_date, @charge_code, @audit_code, @bill_code, @exec_sn, @apply_sn,
@org_price, @charge_price, @charge_amount, @charge_group,@enter_opera, @enter_date, @enter_win_no,
@confirm_opera,@confirm_date, @confirm_win_no, @charge_status, @trans_flag, @mz_dept_no)";

                            para = new DynamicParameters();
                            para.Add("@patient_id", patient_id);
                            para.Add("@max_times", max_times);
                            para.Add("@item_no", ++itemno);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@happen_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            para.Add("@charge_code", charge_code);
                            para.Add("@audit_code", audit_code);
                            para.Add("@bill_code", mz_bill_item);
                            para.Add("@exec_sn", "1010501");
                            para.Add("@apply_sn", "0000000");
                            para.Add("@org_price", charge_price);
                            para.Add("@charge_price", effective_price);
                            para.Add("@charge_amount", "1");
                            para.Add("@charge_group", mz_charge_group);
                            para.Add("@enter_opera", opera);
                            para.Add("@enter_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            para.Add("@enter_win_no", "0");
                            para.Add("@confirm_opera", opera);
                            para.Add("@confirm_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            para.Add("@confirm_win_no", "0");
                            para.Add("@charge_status", "4");
                            para.Add("@trans_flag", "0");
                            para.Add("@mz_dept_no", "1");

                            result = connection.Execute(sql4, para, transaction);
                        }

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
                        //写入现金流表
                        string sql7 = @"insert into gh_deposit
  (patient_id, item_no, ledger_sn, times, charge, cheque_type, cheque_no, depo_status, price_opera, price_date, mz_dept_no)
values
  (@patient_id, @item_no, @ledger_sn, @times, @charge, @cheque_type,@cheque_no, @depo_status, @price_opera, @price_date, @mz_dept_no)";

                        //处理多重支付
                        var pay_method_arr = pay_string.Split(',');
                        int item_no = 1;
                        //if (pay_method_arr.Length > 1)
                        //{
                        //    max_ledger_sn = 1;
                        //}
                        foreach (var pay_method in pay_method_arr)
                        {
                            var pay_detail = pay_method.Split('-');
                            var cheque_type = pay_detail[0];
                            var charge = decimal.Parse(pay_detail[1]);
                            var out_trade_no = pay_detail[2];//订单编号

                            para = new DynamicParameters();

                            para.Add("@patient_id", patient_id);
                            para.Add("@item_no", item_no);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@times", max_times);
                            para.Add("@cheque_no", out_trade_no);
                            para.Add("@charge", charge);
                            para.Add("@cheque_type", cheque_type);
                            para.Add("@depo_status", "4");
                            para.Add("@price_opera", opera);
                            para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            para.Add("@mz_dept_no", "1");

                            result = connection.Execute(sql7, para, transaction);

                            item_no++;
                        }

                        //写入挂号发票明细表
                        string sql6 = @"insert into gh_receipt_charge
  (patient_id, times, ledger_sn, receipt_sn, bill_code, charge, pay_unit)
values
  (@patient_id, @times, @ledger_sn, @receipt_sn, @bill_code, @charge, @pay_unit) ";

                        decimal to_price = 0;

                        //挂号费，诊查费等分批写入  
                        foreach (var item in chargeItems)
                        {
                            to_price += item.effective_price;

                            para = new DynamicParameters();

                            para.Add("@patient_id", patient_id);
                            para.Add("@times", max_times);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@receipt_sn", max_sn);
                            para.Add("@bill_code", item.mz_bill_item);
                            para.Add("@charge", item.effective_price);
                            para.Add("@pay_unit", "01");

                            result = connection.Execute(sql6, para, transaction);
                        }
                        //写入挂号发票表
                        string sql5 = @"insert into gh_receipt
  (patient_id, times, ledger_sn, receipt_sn, pay_unit, charge_total, settle_opera, settle_date, price_opera, price_date, receipt_no, charge_status, mz_dept_no)
values
  (@patient_id,@times,@ledger_sn, @receipt_sn, @pay_unit, @charge_total, @settle_opera,@settle_date, @price_opera, @price_date, @receipt_no, @charge_status, @mz_dept_no)";
                        para = new DynamicParameters();

                        para.Add("@patient_id", patient_id);
                        para.Add("@times", max_times);
                        para.Add("@ledger_sn", max_ledger_sn);
                        para.Add("@receipt_sn", max_sn);
                        para.Add("@pay_unit", "01");
                        para.Add("@charge_total", to_price);
                        para.Add("@settle_opera", opera);
                        para.Add("@settle_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        para.Add("@price_opera", opera);
                        para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        para.Add("@receipt_no", current_no);//gh_op_receipt receipt_no
                        para.Add("@charge_status", "4");
                        para.Add("@mz_dept_no", "1");

                        result = connection.Execute(sql5, para, transaction);

                        int new_no = Convert.ToInt32(current_no) + step_length;
                        //更新挂号发票记录表
                        string sql8 = @"update gh_op_receipt  set
                                 current_no = @new_no 
                                 where
                                 operator = @operator and
                                 happen_date = @happen_date and
                                 start_no = @start_no and
                                 current_no = @current_no and
                                 end_no = @end_no and
                                 step_length =@step_length and
                                 deleted_flag = @deleted_flag and
                                 report_flag = @report_flag and
                                 receipt_type = @receipt_type";


                        para = new DynamicParameters();

                        para.Add("@new_no", new_no.ToString().PadLeft(10, '0'));
                        para.Add("@operator", opera);
                        para.Add("@happen_date", happen_date);
                        para.Add("@start_no", start_no);
                        para.Add("@current_no", current_no);
                        para.Add("@end_no", end_no);
                        para.Add("@step_length", step_length);
                        para.Add("@deleted_flag", deleted_flag);
                        para.Add("@report_flag", report_flag);
                        para.Add("@receipt_type", receipt_type);

                        result = Update(sql8, para);

                        max_ledger_sn++;




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

        public string GetNewPatientId()
        {
            try
            {
                //新增
                string snosql = @"Update gh_config set patient_sn = patient_sn + 1;select patient_sn from gh_config";
                //string snosql = @"select patient_sn from gh_config";
                var dtconfig = ExcuteScalar(snosql, null);

                if (dtconfig != null)
                {
                    return dtconfig.ToString();
                }
                throw new Exception("获取挂号配置表失败！gh_config");
            }
            catch (Exception ex)
            { 
                throw ex;
            }
             
        }
    }
}
