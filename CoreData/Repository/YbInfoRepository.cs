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
                    string del_sql = GetSqlByTag("yb_baseinfo_del");
                    string sql = GetSqlByTag("yb_baseinfo_add");
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _dat.patient_id);
                    para.Add("@admiss_times", _dat.admiss_times);
                    para.Add("@psn_no", baseinfo.psn_no);
                    para.Add("@psn_cert_type", baseinfo.psn_cert_type);
                    para.Add("@certno", baseinfo.certno);
                    para.Add("@psn_name", baseinfo.psn_name);
                    para.Add("@gend", baseinfo.gend);
                    para.Add("@naty", baseinfo.naty);
                    para.Add("@brdy", baseinfo.brdy);
                    para.Add("@age", baseinfo.age);

                    connection.Execute(del_sql, para, transaction);

                    connection.Execute(sql, para, transaction);
                    if (idetinfo != null)
                    {
                        //添加idetinfo
                        del_sql = GetSqlByTag("yb_idetinfo_del");
                        sql = GetSqlByTag("yb_idetinfo_add");
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
                        del_sql = GetSqlByTag("yb_insuinfo_del");
                        sql = GetSqlByTag("yb_insuinfo_add");
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
                    string del_sql = GetSqlByTag("yb_2201_del");
                    string sql = GetSqlByTag("yb_2201_add");
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _dat.patient_id);
                    para.Add("@admiss_times", _dat.admiss_times);
                    para.Add("@mdtrt_id", _dat.mdtrt_id);
                    para.Add("@psn_no", _dat.psn_no);
                    para.Add("@ipt_otp_no", _dat.ipt_otp_no);

                    //connection.Execute(del_sql, para, transaction);

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

            JzxxUploadModel _dat = JsonConvert.DeserializeObject<JzxxUploadModel>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //添加 
                    string del_sql = GetSqlByTag("yb_2203_diseinfo_del");
                    string sql = GetSqlByTag("yb_2203_diseinfo_add");

                    if (_dat != null && _dat.diseinfo != null)
                    {
                        var para = new DynamicParameters();
                        para.Add("@patient_id", _dat.patient_id);
                        para.Add("@admiss_times", _dat.admiss_times);
                        //connection.Execute(del_sql, para, transaction);

                        foreach (var item in _dat.diseinfo)
                        {
                            para = new DynamicParameters();
                            para.Add("@patient_id", _dat.patient_id);
                            para.Add("@admiss_times", _dat.admiss_times);
                            para.Add("@mdtrt_id", _dat.mdtrtinfo.mdtrt_id);
                            para.Add("@diag_type", item.diag_type);
                            para.Add("@diag_srt_no", item.diag_srt_no);
                            para.Add("@diag_code", item.diag_code);
                            para.Add("@diag_name", item.diag_name);
                            para.Add("@diag_dept", item.diag_dept);
                            para.Add("@dise_dor_no", item.dise_dor_no);
                            para.Add("@dise_dor_name", item.dise_dor_name);
                            para.Add("@diag_time", item.diag_time);
                            para.Add("@vali_flag", item.vali_flag);

                            connection.Execute(sql, para, transaction);
                        }
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        throw new Exception("没有数据");
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //诊断明细信息上传
        public bool AddYB2204(string jsonStr)
        {

            JzmxUploadModel _mod = JsonConvert.DeserializeObject<JzmxUploadModel>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //添加 
                    string del_sql = GetSqlByTag("yb_2204_del");
                    string sql = GetSqlByTag("yb_2204_add");
                    if (_mod != null && _mod.diseinfo != null)
                    {
                        var para = new DynamicParameters();
                        para.Add("@patient_id", _mod.patient_id);
                        para.Add("@admiss_times", _mod.admiss_times);
                        //connection.Execute(del_sql, para, transaction);

                        foreach (var _dat in _mod.diseinfo)
                        {
                            para = new DynamicParameters();
                            para.Add("@patient_id", _mod.patient_id);
                            para.Add("@admiss_times", _mod.admiss_times);

                            para.Add("@mdtrt_id", _dat.mdtrt_id);
                            para.Add("@feedetl_sn", _dat.feedetl_sn);
                            para.Add("@det_item_fee_sumamt", _dat.det_item_fee_sumamt);
                            para.Add("@cnt", _dat.cnt);
                            para.Add("@pric", _dat.pric);
                            para.Add("@pric_uplmt_amt", _dat.pric_uplmt_amt);
                            para.Add("@selfpay_prop", _dat.selfpay_prop);
                            para.Add("@fulamt_ownpay_amt", _dat.fulamt_ownpay_amt);
                            para.Add("@overlmt_amt", _dat.overlmt_amt);
                            para.Add("@preselfpay_amt", _dat.preselfpay_amt);
                            para.Add("@inscp_scp_amt", _dat.inscp_scp_amt);
                            para.Add("@chrgitm_lv", _dat.chrgitm_lv);
                            para.Add("@med_chrgitm_type", _dat.med_chrgitm_type);
                            para.Add("@bas_medn_flag", _dat.bas_medn_flag);
                            para.Add("@hi_nego_drug_flag", _dat.hi_nego_drug_flag);
                            para.Add("@chld_medc_flag", _dat.chld_medc_flag);
                            para.Add("@list_sp_item_flag", _dat.list_sp_item_flag);
                            para.Add("@lmt_used_flag", _dat.lmt_used_flag);
                            para.Add("@drt_reim_flag", _dat.drt_reim_flag);
                            para.Add("@memo", _dat.memo);

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

        //预结算信息
        public bool AddYB2207(string jsonStr)
        {
            YJS_Response _mod = JsonConvert.DeserializeObject<YJS_Response>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    //添加 
                    string del_sql = GetSqlByTag("yb_2207_del");
                    string sql = GetSqlByTag("yb_2207_add");
                    var para = new DynamicParameters();
                    para.Add("@patient_id", _mod.patient_id);
                    para.Add("@admiss_times", _mod.admiss_times);

                    //connection.Execute(del_sql, para, transaction);

                    if (_mod.setlinfo != null)
                    {
                        var _dat = _mod.setlinfo;
                        para.Add("@mdtrt_id", _dat.mdtrt_id);
                        para.Add("@setl_id", _dat.setl_id);
                        para.Add("@psn_no", _dat.psn_no);
                        para.Add("@psn_name", _dat.psn_name);
                        para.Add("@psn_cert_type", _dat.psn_cert_type);
                        para.Add("@certno", _dat.certno);
                        para.Add("@gend", _dat.gend);
                        para.Add("@naty", _dat.naty);
                        para.Add("@brdy", _dat.brdy);
                        para.Add("@age", _dat.age);
                        para.Add("@insutype", _dat.insutype);
                        para.Add("@psn_type", _dat.psn_type);
                        para.Add("@cvlserv_flag", _dat.cvlserv_flag);
                        para.Add("@setl_time", _dat.setl_time);
                        para.Add("@mdtrt_cert_type", _dat.mdtrt_cert_type);
                        para.Add("@med_type", _dat.med_type);
                        para.Add("@medfee_sumamt", _dat.medfee_sumamt);
                        para.Add("@fulamt_ownpay_amt", _dat.fulamt_ownpay_amt);
                        para.Add("@overlmt_selfpay", _dat.overlmt_selfpay);
                        para.Add("@preselfpay_amt", _dat.preselfpay_amt);
                        para.Add("@inscp_scp_amt", _dat.inscp_scp_amt);
                        para.Add("@act_pay_dedc", _dat.act_pay_dedc);
                        para.Add("@hifp_pay", _dat.hifp_pay);
                        para.Add("@pool_prop_selfpay", _dat.pool_prop_selfpay);
                        para.Add("@cvlserv_pay", _dat.cvlserv_pay);
                        para.Add("@hifes_pay", _dat.hifes_pay);
                        para.Add("@hifmi_pay", _dat.hifmi_pay);
                        para.Add("@hifob_pay", _dat.hifob_pay);
                        para.Add("@maf_pay", _dat.maf_pay);
                        para.Add("@oth_pay", _dat.oth_pay);
                        para.Add("@fund_pay_sumamt", _dat.fund_pay_sumamt);
                        para.Add("@psn_part_amt", _dat.psn_part_amt);
                        para.Add("@acct_pay", _dat.acct_pay);
                        para.Add("@psn_cash_pay", _dat.psn_cash_pay);
                        para.Add("@hosp_part_amt", _dat.hosp_part_amt);
                        para.Add("@balc", _dat.balc);
                        para.Add("@acct_mulaid_pay", _dat.acct_mulaid_pay);
                        para.Add("@medins_setl_id", _dat.medins_setl_id);
                        para.Add("@clr_optins", _dat.clr_optins);
                        para.Add("@clr_way", _dat.clr_way);
                        para.Add("@clr_type", _dat.clr_type);

                        connection.Execute(sql, para, transaction);

                        //更新基本信息
                        sql = @"update ybNew_1101_baseinfo set insuplc_admdvs=@insuplc_admdvs
where patient_id = @patient_id and admiss_times = @admiss_times";
                        para = new DynamicParameters();
                        para.Add("@patient_id", _mod.patient_id);
                        para.Add("@admiss_times", _mod.admiss_times);
                        para.Add("@insuplc_admdvs", _dat.clr_optins);
                        connection.Execute(sql, para, transaction);

                        //更新2207存储过程ybNew_2207_save
                        para = new DynamicParameters();
                        para.Add("@patient_id", _mod.patient_id);
                        para.Add("@admiss_times", _mod.admiss_times);
                        para.Add("@mdtrt_id", _dat.mdtrt_id);
                        connection.Execute("ybNew_2207_save", para, transaction, null, CommandType.StoredProcedure);

                        transaction.Commit();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        //预结算信息
        public bool AddYB2208(string patient_id, string admiss_times, string mdtrt_id)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {

                    //更新2207存储过程ybNew_2207_save
                    var para = new DynamicParameters();
                    para.Add("@patient_id", patient_id);
                    para.Add("@admiss_times", admiss_times);
                    para.Add("@mdtrt_id", mdtrt_id);
                    connection.Execute("ybNew_2208_save", para, transaction, null, CommandType.StoredProcedure);

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



        public List<Insutype> GetInsutypes()
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("yb_zd_insutype");

                return connection.Query<Insutype>(sql).ToList();
            }
        }
        public List<MdtrtCertType> GetMdtrtCertTypes()
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("yb_zd_mdtrtcerttype");

                return connection.Query<MdtrtCertType>(sql).ToList();
            }
        }
        public List<MedType> GetMedTypes()
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("yb_zd_medtype");

                return connection.Query<MedType>(sql).ToList();
            }
        }

        public List<DiagType> GetDiagTypes()
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("yb_zd_diagtype");

                return connection.Query<DiagType>(sql).ToList();
            }
        }
        public List<IcdCode> GetIcdCodes()
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("zd_icd_code_get");

                return connection.Query<IcdCode>(sql).ToList();
            }
        }
        public List<BirctrlType> GetBirctrlTypes()
        {

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("yb_zd_birctrltype");

                return connection.Query<BirctrlType>(sql).ToList();
            }
        }


        public UserInfoResponseModel GetYjsUserInfo(string patient_id, int admiss_times)
        {
            try
            {
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    UserInfoResponseModel responseModel = new UserInfoResponseModel();

                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql = GetSqlByTag("yb_baseinfo_get");
                        var para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@admiss_times", admiss_times);
                        var info_list = connection.Query<BaseInfo>(sql, para, transaction);

                        sql = GetSqlByTag("yb_insuinfo_get");
                        var insu_list = connection.Query<InsuInfo>(sql, para, transaction);

                        sql = GetSqlByTag("yb_idetinfo_get");
                        var idt_list = connection.Query<IdetInfo>(sql, para, transaction);

                        responseModel.baseinfo = info_list.FirstOrDefault();
                        responseModel.insuinfo = insu_list.ToList();
                        responseModel.idetinfo = idt_list.ToList();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserInfoResponseModel GetYBCardInfo(string patient_id,int admiss_times,string doctor_code,string apply_unit)
        {
            try
            {
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    UserInfoResponseModel responseModel = new UserInfoResponseModel();

                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        var para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@admiss_times", admiss_times);
                        para.Add("@doctor_code", doctor_code);
                        para.Add("@apply_unit", apply_unit);
                        var _reader = connection.QueryMultiple("ybNew_getCardInfo", para, transaction, null, CommandType.StoredProcedure);

                        responseModel.baseinfo = _reader.Read<BaseInfo>().FirstOrDefault();

                        responseModel.insuinfo = _reader.Read<InsuInfo>().ToList();

                        responseModel.idetinfo = _reader.Read<IdetInfo>().ToList();

                        responseModel.jiuzhenInfo = _reader.Read<JiuzhenInfo>().FirstOrDefault();

                        responseModel.diseinfo = _reader.Read<Diseinfo>().ToList();
                         

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
