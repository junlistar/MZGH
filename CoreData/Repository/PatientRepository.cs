using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {


        ChargeItemRepository chargeItemResp = new ChargeItemRepository();
        GhOpReceiptRepository opreceiptResp = new GhOpReceiptRepository();
        GhRequestRepository ghResp = new GhRequestRepository();


        public List<Patient> GetPatientByCard(string cardno)
        {
            string selectSql = GetSqlByTag(220002);

            var para = new DynamicParameters();
            para.Add("@cardno", cardno);

            return Select(selectSql, para);


        }
        public List<Patient> GetPatientById(string pid)
        {
            string selectSql = GetSqlByTag(220003);

            var para = new DynamicParameters();
            para.Add("@patient_id", pid);

            return Select(selectSql, para);
        }
        public List<Patient> GetPatientByBarcode(string barcode)
        {
            //string selectSql = @"select * from mz_patient_mi a where a.p_bar_code=@barcode ";

            string selectSql = GetSqlByTag(220004);

            var para = new DynamicParameters();
            para.Add("@barcode", barcode);

            return Select(selectSql, para);
        }
        public List<Patient> GetPatientBySfzId(string sfzid)
        {
            string selectSql = @"select * from mz_patient_mi a where a.hic_no=@sfzid ";

            var para = new DynamicParameters();
            para.Add("@sfzid", sfzid);

            return Select(selectSql, para);
        }

        public List<Patient> GetPatientByPatientId(string pid)
        {
            string selectSql = GetSqlByTag(220005);// @"select * from mz_patient_mi a where a.patient_id=@patient_id ";
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
            string sql = GetSqlByTag(220006);// "UPDATE mz_patient_mi SET hic_no='' WHERE hic_no=@hic_no";
            var para = new DynamicParameters();
            para.Add("@hic_no", sno);
            return Update(sql, para);
        }

        public int UpdateUserYBInfo(string pid, string social_no, string yb_psn_no, string yb_insutype, string yb_insuplc_admdvs)
        {
            string sql = GetSqlByTag(220007);//"UPDATE mz_patient_mi SET yb_psn_no=@yb_psn_no,yb_insutype=@yb_insutype,yb_insuplc_admdvs=@yb_insuplc_admdvs WHERE patient_id=@pid";
            var para = new DynamicParameters();
            para.Add("@social_no", social_no);
            para.Add("@yb_psn_no", yb_psn_no);
            para.Add("@yb_insutype", yb_insutype);
            para.Add("@yb_insuplc_admdvs", yb_insuplc_admdvs);
            para.Add("@pid", pid);
            return Update(sql, para);
        }


        public int EditUserInfo(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
             string home_district, string home_street, string occupation_type, string response_type, string charge_type, string opera)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();

                try
                {

                    //查询是否存在
                    string issql = GetSqlByTag(220005);// "select * from mz_patient_mi where patient_id = @patient_id";
                    var para = new DynamicParameters();
                    if (pid.Length == 7)
                    {
                        pid = "000" + pid + "00";
                    }
                    para.Add("@patient_id", pid);
                    var list = connection.Query<Patient>(issql, para,transaction);
                    if (list != null && list.Count() > 0)
                    {
                        //修改

                        //                string sql = @"update mz_patient_mi
                        //set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
                        //home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type,update_date=@update_date,update_opera=@update_opera 
                        //where patient_id=@patient_id";

                        string sql = GetSqlByTag(220008);
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

                        return connection.Execute(sql, para,transaction);
                    }
                    else
                    {
                        //新增

                        //                string sql = @"insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,
                        //balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,
                        //home_district,home_street,occupation_type,response_type,charge_type,enter_date,update_date,enter_opera,update_opera) values
                        //(@patient_id,@social_no,@hic_no,@p_bar_code,@name,@sex,@birthday,@home_tel,'0',0,0,0,0,
                        //@home_district,@home_street,@occupation_type,@response_type,@charge_type,@enter_date,@update_date,@enter_opera,@update_opera)";

                        string sql = GetSqlByTag(220009);

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
                         
                        connection.Execute(sql, para, transaction);

                        //写patientId和身份证id关联表
                        sql = "insert into mz_patient_sfz(patient_id,sfz_id) value (@patient_id,@sfz_id)";
                        para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        para.Add("@hic_no", hicno);
                        connection.Execute(sql, para, transaction);

                    }
                    transaction.Commit();

                    return 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                 
            }

        }

        public int EditUserInfoPage(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
            string home_district, string home_street, string occupation_type, string response_type, string charge_type,
            string relation_name, int marrycode, string addition_no1, string employer_name, string opera)
        {
            //查询是否存在
            string issql = GetSqlByTag(220005);// "select * from mz_patient_mi where patient_id = @patient_id";
            var para = new DynamicParameters();
            if (pid.Length == 7)
            {
                pid = "000" + pid + "00";
            }
            para.Add("@patient_id", pid);
            var list = Select(issql, para);
            if (list != null && list.Count > 0)
            {
                //修改

                //                string sql = @"update mz_patient_mi
                //set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
                //home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type,
                //update_date=@update_date,update_opera=@update_opera,relation_name=@relation_name,marry_code=@marry_code,addition_no1=@addition_no1,employer_name=@employer_name
                //where patient_id=@patient_id";

                string sql = GetSqlByTag(220010);

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
                para.Add("@relation_name", relation_name);
                para.Add("@marry_code", marrycode);
                para.Add("@addition_no1", addition_no1);
                para.Add("@employer_name", employer_name);
                para.Add("@patient_id", pid);

                return Update(sql, para);
            }
            else
            {
                //新增

                //                string sql = @"insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,
                //balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,
                //home_district,home_street,occupation_type,response_type,charge_type,enter_date,update_date,enter_opera,update_opera,
                //relation_name,marry_code,addition_no1,employer_name) values
                //(@patient_id,@social_no,@hic_no,@p_bar_code,@name,@sex,@birthday,@home_tel,'0',0,0,0,0,
                //@home_district,@home_street,@occupation_type,@response_type,@charge_type,@enter_date,@update_date,@enter_opera,@update_opera,
                //@relation_name,@marry_code,@addition_no1,@employer_name)";

                string sql = GetSqlByTag(220011);

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

                para.Add("@relation_name", relation_name);
                para.Add("@marry_code", marrycode);
                para.Add("@addition_no1", addition_no1);
                para.Add("@employer_name", employer_name);

                return Update(sql, para);
            }

        }


        /// <summary>
        /// 加上事务处理
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="record_sn"></param>
        /// <param name="pay_string"></param>
        /// <param name="opera"></param>
        /// <returns></returns>
        public bool GuaHao(string patient_id, string record_sn, string pay_string, int max_sn = 0, string opera = "")
        {
            try
            {

                var chargeItems = chargeItemResp.GetChargeItemsByRecordSN(record_sn);
                var dtreceipt = opreceiptResp.GetCurrentReceiptNo();

                //查询当前号是否超过数量
                string exsitsql = GetSqlByTag(220012);
                //更新挂号表
                string sql1 = GetSqlByTag(220013);
                //更新门诊用户信息 max_times
                string sql2 = GetSqlByTag(220014);
                //更新发票号
                string sql3 = GetSqlByTag(220015);
                //写入mz_visit_table
                string visit_sql = GetSqlByTag(220016);
                //写入挂号收费明细表
                string sql4 = GetSqlByTag(220017);
                //写入现金流表
                string sql7 = GetSqlByTag(220018);

                //写入挂号发票明细表
                string sql6 = GetSqlByTag(220019);
                //写入挂号发票明细表
                string sql5 = GetSqlByTag(220020);
                //更新挂号发票记录表
                string sql8 = GetSqlByTag(220021);

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //查询挂号信息
                        var relist = ghResp.GetGhRecord(record_sn);
                        int result = 0;

                        //查询当前号是否超过数量
                        //string exsitsql = "select * from gh_request where record_sn = @record_sn and current_no<= end_no";
                        DynamicParameters para = new DynamicParameters();
                        para.Add("@record_sn", record_sn);
                        var obj = connection.QueryFirstOrDefault<GhRequest>(exsitsql, para, transaction);
                        if (obj == null)
                        {
                            throw new Exception("没有号了！");
                        }
                        var visit_date = obj.request_date;

                        //更新挂号表 当前号haole
                        //string sql1 = "UPDATE gh_request SET current_no =current_no+1 WHERE record_sn = @record_sn";
                        para = new DynamicParameters();
                        para.Add("@record_sn", record_sn);

                        connection.Execute(sql1, para, transaction);

                        //更新门诊用户信息 max_times
                        //string sql2 = "update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=@patient_id " +
                        //    "select max_ledger_sn,max_times from mz_patient_mi where  patient_id=@patient_id";

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
                        //                        string sql3 = @"UPDATE mz_order_generator  
                        //     SET max_sn = max_sn + 1
                        //   WHERE(mz_order_generator.define = 'gh_receipt_sn')
                        //SELECT mz_order_generator.max_sn
                        //   FROM mz_order_generator
                        //   WHERE(mz_order_generator.define = 'gh_receipt_sn') ";

                        if (max_sn == 0)
                        {
                            max_sn = Convert.ToInt32(connection.ExecuteScalar(sql3, null, transaction));
                        }



                        if (relist.Count > 0)
                        {
                            var plist = GetPatientById(patient_id);

                            var recorditem = relist[0];
                            var patient = plist[0];

                            //写入mz_visit_table 
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

                            para.Add("@patient_id", patient_id);
                            para.Add("@item_no", item_no);
                            para.Add("@ledger_sn", max_ledger_sn);
                            para.Add("@times", max_times);
                            para.Add("@cheque_no", cheque_no);
                            para.Add("@charge", charge);
                            para.Add("@cheque_type", cheque_type);
                            para.Add("@depo_status", "4");
                            para.Add("@price_opera", opera);
                            para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            para.Add("@mz_dept_no", "1");
                            para.Add("@out_trade_no", out_trade_no);

                            result = connection.Execute(sql7, para, transaction);

                            item_no++;
                        }

                        //写入挂号发票明细表 

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
                        ////更新挂号发票记录表

                        para = new DynamicParameters();

                        para.Add("@new_no", new_no.ToString().PadLeft(10, '0'));
                        para.Add("@operator", opera);
                        para.Add("@happen_date", happen_date);
                        para.Add("@start_no", start_no);
                        para.Add("@current_no", current_no);
                        para.Add("@end_no", end_no);
                        para.Add("@step_length", step_length);

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
                string snosql = GetSqlByTag(220022); //@"Update gh_config set patient_sn = patient_sn + 1;select patient_sn from gh_config";
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

        /// <summary>
        /// 获取最新机制号
        /// </summary>
        /// <returns></returns>
        public string GetNewReceiptMaxSN()
        {
            try
            {
                //更新发票号
                string sql = GetSqlByTag(220015);

                var dtconfig = ExcuteScalar(sql, null);

                if (dtconfig != null)
                {
                    return dtconfig.ToString();
                }
                throw new Exception("获取最新机制号配置表失败！mz_order_generator");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
