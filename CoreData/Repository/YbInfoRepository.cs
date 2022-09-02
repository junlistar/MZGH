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
    public class YbInfoRepository : RepositoryBase<BaseModel>, IYbInfoRepository
    {
        //基本信息
        public bool AddYB1101(string jsonStr)
        {

            UserInfoResponseModel _dat = JsonConvert.DeserializeObject<UserInfoResponseModel>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            { 
                IDbTransaction transaction = connection.BeginTransaction();
                try
                { 
                    //添加baseinfo
                    var baseinfo = _dat.baseinfo;
                    var idetinfo = _dat.idetinfo;
                    var insuinfo = _dat.insuinfo;
                    string del_sql = "delete from ybNew_1101_baseinfo where patient_id=@patient_id and admiss_times=@admiss_times";
                    string sql = @"insert into ybNew_1101_baseinfo(patient_id,admiss_times,psn_no,psn_cert_type,certno,psn_name,gend,naty,brdy,age,flag,mzzy,insuplc_admdvs)
values(@patient_id,@admiss_times,@psn_no,@psn_cert_type,@certno,@psn_name,@gend,@naty,@brdy,@age,null,null,null)";
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _dat.patient_id);
                    para.Add("@admiss_times", _dat.admiss_times);
                    para.Add("@psn_no", baseinfo.psn_no);
                    para.Add("@psn_cert_type", baseinfo.psn_cert_type);
                    para.Add("@certno", baseinfo.certno);
                    para.Add("@psn_name", baseinfo.psn_name);
                    para.Add("@gend", baseinfo.gend);
                    para.Add("@naty", baseinfo.naty);
                    para.Add("@brty", baseinfo.brdy);
                    para.Add("@age", baseinfo.age);

                    connection.Execute(del_sql, para, transaction);

                    connection.Execute(sql, para, transaction);
                    if (idetinfo != null)
                    {
                        //添加idetinfo
                        del_sql = "delete from ybNew_1101_idetinfo where patient_id=@patient_id and admiss_times=@admiss_times";
                        sql = @"insert into ybNew_1101_idetinfo(patient_id,admiss_times,psn_idet_type,psn_type_lv,memo,begntime,endtime)
values(@patient_id,@admiss_times,@psn_idet_type,@psn_type_lv,@memo,@begntime,@endtime)";
                        foreach (var item in idetinfo)
                        {
                            para = new DynamicParameters();
                            para.Add("@patient_id", _dat.patient_id);
                            para.Add("@admiss_times", _dat.admiss_times);
                            para.Add("@psn_idet_type", item.psn_idet_type);
                            para.Add("@psn_type_lv", item.psn_type_lv);
                            para.Add("@memo", item.memo);
                            para.Add("@begntime", item.begntime);
                            para.Add("@endtime", item.endtime);

                            connection.Execute(del_sql, para, transaction);
                            connection.Execute(sql, para, transaction);
                        }
                    }
                    if (insuinfo != null)
                    {
                        //添加insuinfo
                        del_sql = "delete from ybNew_1101_insuinfo where patient_id=@patient_id and admiss_times=@admiss_times";
                        sql = @"insert into ybNew_1101_insuinfo(patient_id,admiss_times,balc,insutype,psn_type,psn_insu_stas,psn_insu_date,paus_insu_date,cvlserv_flag,insuplc_admdvs,emp_name)
values(@patient_id,@admiss_times,@balc,@insutype,@psn_type,@psn_insu_stas,@psn_insu_date,@paus_insu_date,@cvlserv_flag,@insuplc_admdvs,@emp_name)";
                        foreach (var item in insuinfo)
                        {
                            para = new DynamicParameters();
                            para.Add("@patient_id", _dat.patient_id);
                            para.Add("@admiss_times", _dat.admiss_times);
                            para.Add("@balc", item.balc);
                            para.Add("@insutype", item.insutype);
                            para.Add("@psn_type", item.psn_type);
                            para.Add("@psn_insu_stas", item.psn_insu_stas);
                            para.Add("@psn_insu_date", item.psn_insu_date);
                            para.Add("@paus_insu_date", item.paus_insu_date);
                            para.Add("@cvlserv_flag", item.cvlserv_flag);
                            para.Add("@insuplc_admdvs", item.insuplc_admdvs);
                            para.Add("@emp_name", item.emp_name);

                            connection.Execute(del_sql, para, transaction);
                            connection.Execute(sql, para, transaction);
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        //门诊挂号
        public bool AddYB2201(string jsonStr)
        {

            GHResponseModel _dat = JsonConvert.DeserializeObject<GHResponseModel>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //添加 
                    string del_sql = "delete from ybNew_2201_data where patient_id=@patient_id and admiss_times=@admiss_times";
                    string sql = @"insert into ybNew_2201_data(patient_id,admiss_times,mdtrt_id,psn_no,ipt_otp_no)
values(@patient_id,@admiss_times,@mdtrt_id,@psn_no,@ipt_otp_no)";
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _dat.patient_id);
                    para.Add("@admiss_times", _dat.admiss_times);
                    para.Add("@mdtrt_id", _dat.mdtrt_id); 
                    para.Add("@psn_no", _dat.psn_no);
                    para.Add("@ipt_otp_no", _dat.ipt_otp_no);

                    connection.Execute(del_sql, para, transaction);

                    connection.Execute(sql, para, transaction);
                    
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //诊断信息
        public bool AddYB2203(string jsonStr)
        {

            GHResponseModel _dat = JsonConvert.DeserializeObject<GHResponseModel>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //添加 
                    string del_sql = "delete from ybNew_2203_diseinfo where patient_id=@patient_id and admiss_times=@admiss_times";
                    string sql = @"insert into ybNew_2203_diseinfo(patient_id,admiss_times,mdtrt_id,diag_type,diag_srt_no,diag_code,diag_name,diag_dept,dise_dor_no,dise_dor_name,diag_time,vali_flag)
values(@patient_id,@admiss_times,@mdtrt_id,@diag_type,@diag_srt_no,@diag_code,@diag_name,@diag_dept,@dise_dor_no,@dise_dor_name,@diag_time,vali_flag)";
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _dat.patient_id);
                    para.Add("@admiss_times", _dat.admiss_times);
                    para.Add("@mdtrt_id", _dat.mdtrt_id);
                    para.Add("@psn_no", _dat.psn_no);
                    para.Add("@ipt_otp_no", _dat.ipt_otp_no);

                    connection.Execute(del_sql, para, transaction);

                    connection.Execute(sql, para, transaction);

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //mingxi信息
        public bool AddYB2204(string jsonStr)
        {

            GHResponseModel _dat = JsonConvert.DeserializeObject<GHResponseModel>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //添加 
                    string del_sql = "delete from ybNew_2204_result where patient_id=@patient_id and admiss_times=@admiss_times";
                    string sql = @"insert into ybNew_2204_result(patient_id, admiss_times, feedetl_sn, det_item_fee_sumamt, cnt, pric, pric_uplmt_amt, selfpay_prop, fulamt_ownpay_amt, overlmt_amt, preselfpay_amt, inscp_scp_amt, chrgitm_lv, med_chrgitm_type, bas_medn_flag, hi_nego_drug_flag, chld_medc_flag, list_sp_item_flag, lmt_used_flag, drt_reim_flag, memo, mdtrt_id)
values(@patient_id, @admiss_times, @feedetl_sn, @det_item_fee_sumamt, @cnt, @pric, @pric_uplmt_amt, @selfpay_prop, @fulamt_ownpay_amt, @overlmt_amt, @preselfpay_amt, @inscp_scp_amt, @chrgitm_lv, @med_chrgitm_type, @bas_medn_flag, @hi_nego_drug_flag, @chld_medc_flag, @list_sp_item_flag, @lmt_used_flag, @drt_reim_flag, @memo, @mdtrt_id)
";
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _dat.patient_id);
                    para.Add("@admiss_times", _dat.admiss_times);
                    para.Add("@mdtrt_id", _dat.mdtrt_id);
                    para.Add("@psn_no", _dat.psn_no);
                    para.Add("@ipt_otp_no", _dat.ipt_otp_no);

                    connection.Execute(del_sql, para, transaction);

                    connection.Execute(sql, para, transaction);

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //预结算信息
        public bool AddYB2207(string jsonStr)
        { 
            GHResponseModel _dat = JsonConvert.DeserializeObject<GHResponseModel>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //添加 
                    string del_sql = "delete from ybNew_2204_result where patient_id=@patient_id and admiss_times=@admiss_times";
                    string sql = @"insert into ybNew_2207_result([patient_id],
	[admiss_times],
	[mdtrt_id],
	[setl_id] ,
	[psn_no] ,
	[psn_name] ,
	[psn_cert_type],
	[certno],
	[gend],
	[naty] ,
	[brdy],
	[age] ,
	[insutype] ,
	[psn_type] ,
	[cvlserv_flag] ,
	[setl_time] ,
	[mdtrt_cert_type],
	[med_type] ,
	[medfee_sumamt],
	[fulamt_ownpay_amt] ,
	[overlmt_selfpay] ,
	[preselfpay_amt] ,
	[inscp_scp_amt] ,
	[act_pay_dedc] ,
	[hifp_pay] ,
	[pool_prop_selfpay],
	[cvlserv_pay] ,
	[hifes_pay] ,
	[hifmi_pay] ,
	[hifob_pay],
	[maf_pay] ,
	[oth_pay] ,
	[fund_pay_sumamt],
	[psn_part_amt] ,
	[acct_pay] ,
	[psn_cash_pay] ,
	[hosp_part_amt] ,
	[balc],
	[acct_mulaid_pay],
	[medins_setl_id] ,
	[clr_optins] ,
	[clr_way] ,
	[clr_type] )
values (@patient_id,
	@admiss_times,
	@mdtrt_id,
	@setl_id ,
	@psn_no,
	@psn_name ,
	@psn_cert_type,
	@certno,
	@gend,
	@naty ,
	@brdy,
	@age ,
	@insutype ,
	@psn_type ,
	@cvlserv_flag ,
	@setl_time ,
	@mdtrt_cert_type,
	@med_type ,
	@medfee_sumamt,
	@fulamt_ownpay_amt ,
	@overlmt_selfpay ,
	@preselfpay_amt,
	@inscp_scp_amt,
	@act_pay_dedc,
	@hifp_pay,
	@pool_prop_selfpay,
	@cvlserv_pay ,
	@hifes_pay ,
	@hifmi_pay ,
	@hifob_pay,
	@maf_pay ,
	@oth_pay ,
	@fund_pay_sumamt,
	@psn_part_amt ,
	@acct_pay ,
	@psn_cash_pay ,
	@hosp_part_amt ,
	@balc,
	@acct_mulaid_pay,
	@medins_setl_id ,
	@clr_optins ,
	@clr_way ,
	@clr_type )
";
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _dat.patient_id);
                    para.Add("@admiss_times", _dat.admiss_times);
                    para.Add("@mdtrt_id", _dat.mdtrt_id);
                    para.Add("@psn_no", _dat.psn_no);
                    para.Add("@ipt_otp_no", _dat.ipt_otp_no);

                    connection.Execute(del_sql, para, transaction);

                    connection.Execute(sql, para, transaction);

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }


}
