using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Data.Entities
{
    public class YBResponse<T>
    {

        public int infcode { get; set; }
        public string inf_refmsgid { get; set; }
        public string refmsg_time { get; set; }
        public string respond_time { get; set; }
        public string err_msg { get; set; }
        public string warn_msg { get; set; }
        public string signtype { get; set; }
        public string cainfo { get; set; } 
        public string detail_msg { get; set; }
        public T output { get; set; }
    }

    public class RepModel<T>
    {
        public T data { get; set; }
    }

    public class YBRequest<T>
    {

        public string infno { get; set; }
        public string msgid { get; set; }
        public string mdtrtarea_admvs { get; set; }
        public string insuplc_admdvs { get; set; }
        public string recer_sys_code { get; set; }
        public string dev_no { get; set; }
        public string dev_safe_info { get; set; }
        public string cainfo { get; set; }
        public string signtype { get; set; }
        public string infver { get; set; }
        public string opter_type { get; set; }
        public string opter { get; set; }
        public string opter_name { get; set; }
        public string inf_time { get; set; }
        public string fixmedins_code { get; set; }
        public string fixmedins_name { get; set; }
        public string sign_no { get; set; }

        public RepModel<T> input { get; set; }

    }
    #region 获取用户信息模型
    /// <summary>
    /// 获取用户信息 请求模型
    /// </summary>
    public class UserInfoRequestModel
    {
        public string mdtrt_cert_type { get; set; }
        public string mdtrt_cert_no { get; set; }
        public string card_sn { get; set; }
        public string begntime { get; set; }
        public string psn_cert_type { get; set; }
        public string certno { get; set; }
        public string psn_name { get; set; }
    }
    /// <summary>
    /// 获取用户信息 返回模型
    /// </summary>
    public class UserInfoResponseModel
    {
        public string patient_id { get; set; }
        public string admiss_times { get; set; }
        public BaseInfo baseinfo { get; set; }
        public List<InsuInfo> insuinfo { get; set; }
        public List<IdetInfo> idetinfo { get; set; }

        
    }
    public class BaseInfo
    {
        public string psn_no { get; set; }
        public string psn_cert_type { get; set; }
        public string certno { get; set; }
        public string psn_name { get; set; }
        public string gend { get; set; }
        public string naty { get; set; }
        public string brdy { get; set; }
        public string age { get; set; }
        public string exp_content { get; set; }

    }
    public class InsuInfo
    { 
        public decimal balc { get; set; }
        public string insutype { get; set; }
        public string psn_insu_stas { get; set; }
        public string psn_insu_date { get; set; }
        public string paus_insu_date { get; set; }
        public string psn_type { get; set; }
        public string cvlserv_flag { get; set; }
        public string insuplc_admdvs { get; set; }
        public string emp_name { get; set; }
    }
    public class IdetInfo {

        public string psn_idet_type { get; set; }
        public string psn_type_lv { get; set; }
        public string memo { get; set; }
        public string begntime { get; set; }
        public string endtime { get; set; } 

    }

    #endregion


    #region 门诊挂号数据模型

    public class GHRequestModel
    { 

        public string psn_no { get; set; }
        public string insutype { get; set; }
        public string begntime { get; set; }
        public string mdtrt_cert_type { get; set; }
        public string mdtrt_cert_no { get; set; }
        public string ipt_otp_no { get; set; }
        public string atddr_no { get; set; }
        public string dr_name { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public string caty { get; set; } 
    }

    public class GHResponseModel
    {
        public string patient_id { get; set; }
        public string admiss_times { get; set; }
        public string mdtrt_id { get; set; }
        public string psn_no { get; set; }
        public string ipt_otp_no { get; set; }
        public string exp_content { get; set; }
    }

    #endregion


    #region 门诊就诊信息上传请求模型

    public class JzxxUploadModel
    {
        public string patient_id { get; set; }
        public string admiss_times { get; set; }
        public Mdtrtinfo mdtrtinfo { get; set; }
        public List<Diseinfo> diseinfo { get; set; }
    }
    public class JzmxUploadModel
    {
        public string patient_id { get; set; }
        public string admiss_times { get; set; }
        public List<JzxxResponse> diseinfo { get; set; }
    }

    /// <summary>
    /// 就诊信息
    /// </summary>
    public class Mdtrtinfo
    {
        public string psn_no { get; set; }
        public string mdtrt_id { get; set; }
        public string med_type { get; set; }
        public string begntime { get; set; }
        public string main_cond_d { get; set; }
        public string scr { get; set; }
        public string dise_codg { get; set; }
        public string dise_name { get; set; }
        public string birctrl_type { get; set; }
        public string birctrl_matn_date { get; set; }

    }
    /// <summary>
    /// -诊断信息
    /// </summary>
    public class Diseinfo
    {
        public string patient_id { get; set; }
        public string admiss_times { get; set; }
        public string diag_type { get; set; }
        public string diag_srt_no { get; set; }
        public string diag_code { get; set; }
        public string diag_name { get; set; }
        public string diag_dept { get; set; }
        public string dise_dor_no { get; set; }
        public string dise_dor_name { get; set; }
        public string diag_time { get; set; }
        public string vali_flag { get; set; }
    }


    public class JzxxModel
    {
        public Mdtrtinfo mdtrtinfo;
        public Diseinfo diseinfo;
    }

    #endregion



    #region 2204就诊明细返回模型

    public class JzxxResponse
    {
        public string patient_id { get; set; }
        public string admiss_times { get; set; }
        public string feedetl_sn { get; set; }
        public string det_item_fee_sumamt { get; set; }
        public string cnt { get; set; }
        public string pric { get; set; }
        public string pric_uplmt_amt { get; set; }
        public string selfpay_prop { get; set; }
        public string fulamt_ownpay_amt { get; set; }
        public string overlmt_amt { get; set; }
        public string preselfpay_amt { get; set; }
        public string inscp_scp_amt { get; set; }
        public string chrgitm_lv { get; set; }
        public string med_chrgitm_type { get; set; }
        public string bas_medn_flag { get; set; }
        public string hi_nego_drug_flag { get; set; }
        public string chld_medc_flag { get; set; }
        public string list_sp_item_flag { get; set; }
        public string lmt_used_flag { get; set; }
        public string drt_reim_flag { get; set; }
        public string memo { get; set; }
        public string mdtrt_id { get; set; }

    }




    #endregion 

    #region 门诊结算请求模型

    public class MZJS2207A
    {
        public string psn_no { get; set; }
        public string mdtrt_cert_type { get; set; }
        public string mdtrt_cert_no { get; set; }
        public int med_type { get; set; }
        public decimal medfee_sumamt { get; set; }
        public string psn_setlway { get; set; }
        public string mdtrt_id { get; set; }
        public string chrg_bchno { get; set; }
        public string insutype { get; set; }
        public string acct_used_flag { get; set; }
        public string invono { get; set; }
        public string fulamt_ownpay_amt { get; set; }
        public string overlmt_selfpay { get; set; }
        public string preselfpay_amt { get; set; }
        public string inscp_scp_amt { get; set; }
    }

    public class MZJSCX
    {
        public string setl_id { get; set; }
        public string mdtrt_id { get; set; }
        public string psn_no { get; set; }
    }
    #endregion

    #region 预结算返回模型

    //public class YJS_Response
    //{

    //    public string patient_id { get; set; }
    //    public string admiss_times { get; set; }
    //    public string mdtrt_id { get; set; }
    //    public string setl_id { get; set; }
    //    public string psn_no { get; set; }
    //    public string psn_name { get; set; }
    //    public string @psn_cert_type { get; set; }
    //    public string @certno { get; set; }
    //    public string @gend { get; set; }
    //    public string @naty { get; set; }
    //    public string @brdy { get; set; }
    //    public string @age { get; set; }
    //    public string @insutype { get; set; }
    //    public string @psn_type { get; set; }
    //    public string @cvlserv_flag { get; set; }
    //    public string @setl_time { get; set; }
    //    public string @mdtrt_cert_type { get; set; }
    //    public string @med_type { get; set; }
    //    public string @medfee_sumamt { get; set; }
    //    public string @fulamt_ownpay_amt { get; set; }
    //    public string @overlmt_selfpay { get; set; }
    //    public string @preselfpay_amt { get; set; }
    //    public string @inscp_scp_amt { get; set; }
    //    public string @act_pay_dedc { get; set; }
    //    public string @hifp_pay { get; set; }
    //    public string @pool_prop_selfpay { get; set; }
    //    public string @cvlserv_pay { get; set; }
    //    public string @hifes_pay { get; set; }
    //    public string @hifmi_pay { get; set; }
    //    public string @hifob_pay { get; set; }
    //    public string @maf_pay { get; set; }
    //    public string @oth_pay { get; set; }
    //    public string @fund_pay_sumamt { get; set; }
    //    public string @psn_part_amt { get; set; }
    //    public string @acct_pay { get; set; }
    //    public string @psn_cash_pay { get; set; }
    //    public string @hosp_part_amt { get; set; }
    //    public string @balc { get; set; }
    //    public string @acct_mulaid_pay { get; set; }
    //    public string @medins_setl_id { get; set; }
    //    public string @clr_optins { get; set; }
    //    public string @clr_way { get; set; }
    //    public string @clr_type { get; set; }

    //}



    public class YJS_Response
    {
        public string patient_id { get; set; }
        public string admiss_times { get; set; }

        public Setlinfo setlinfo { get; set; }
        public List<Setldetail> setldetail { get; set; }
    }

    public class Setlinfo
    {
        public string setl_id { get; set; }
        public string mdtrt_id { get; set; }
        public string psn_no { get; set; }
        public string psn_name { get; set; }
        public string psn_cert_type { get; set; }
        public string certno { get; set; }
        public string gend { get; set; }
        public string naty { get; set; }
        public string brdy { get; set; }
        public string age { get; set; }
        public string insutype { get; set; }
        public string psn_type { get; set; }
        public string cvlserv_flag { get; set; }
        public string setl_time { get; set; }
        public string mdtrt_cert_type { get; set; }
        public string med_type { get; set; }
        public string medfee_sumamt { get; set; }
        public string fulamt_ownpay_amt { get; set; }
        public string overlmt_selfpay { get; set; }
        public string preselfpay_amt { get; set; }
        public string inscp_scp_amt { get; set; }
        public string act_pay_dedc { get; set; }
        public string hifp_pay { get; set; }
        public string pool_prop_selfpay { get; set; }
        public string cvlserv_pay { get; set; }
        public string hifes_pay { get; set; }
        public string hifmi_pay { get; set; }
        public string hifob_pay { get; set; }
        public string hifdm_pay { get; set; }
        public string maf_pay { get; set; }
        public string oth_pay { get; set; }
        public string fund_pay_sumamt { get; set; }
        public string psn_part_amt { get; set; }
        public string acct_pay { get; set; }
        public string psn_cash_pay { get; set; }
        public string hosp_part_amt { get; set; }
        public string balc { get; set; }
        public string acct_mulaid_pay { get; set; }
        public string medins_setl_id { get; set; }
        public string clr_optins { get; set; }
        public string clr_way { get; set; }
        public string clr_type { get; set; }
        public string exp_content { get; set; }

    }

    public class Setldetail
    {
        public string fund_pay_type { get; set; }
        public string inscp_scp_amt { get; set; }
        public string crt_payb_lmt_amt { get; set; }
        public string fund_payamt { get; set; }
        public string fund_pay_type_name { get; set; }
        public string setl_proc_info { get; set; }

    }

    #endregion



    #region 门诊挂号取消退款数据模型

    public class GHRefundRequestModel
    { 
        public string mdtrt_id { get; set; }
        public string psn_no { get; set; }
        public string ipt_otp_no { get; set; } 
    }

    #endregion

    #region  医保费用

    /// <summary>
    /// 输入-费用明细列表
    /// </summary>
    public class feedetail
    {

        //费用明细流水号
        public string feedetl_sn { get; set; }
        //就诊 ID
        public string mdtrt_id { get; set; }
        /// <summary>
        /// 人员编号
        /// </summary>
        public string psn_no { get; set; }
        /// <summary>
        /// 收费批次号
        /// </summary>
        public string chrg_bchno { get; set; }
        /// <summary>
        /// 病种编码
        /// </summary>
        public string dise_codg { get; set; }
        /// <summary>
        /// 处方号
        /// </summary>
        public string rxno { get; set; }
        /// <summary>
        /// 外购处方标志
        /// </summary>
        public string rx_circ_flag { get; set; }
        /// <summary>
        /// 费用发生时间
        /// </summary>
        public string fee_ocur_time { get; set; }
        /// <summary>
        /// 医疗目录编码
        /// </summary>
        public string med_list_codg { get; set; }
        /// <summary>
        /// 医药机构目录编码
        /// </summary>
        public string medins_list_codg { get; set; }
        /// <summary>
        /// 明细项目费用总额
        /// </summary>
        public string det_item_fee_sumamt { get; set; }
        public string cnt { get; set; }//数量
        public string pric { get; set; }//单价
        /// <summary>
        /// 单次剂量描述
        /// </summary>
        public string sin_dos_dscr { get; set;}
        /// <summary>
        /// 使用频次描述
        /// </summary>
        public string used_frqu_dscr { get; set; }

        /// <summary>
        /// 周期天数
        /// </summary>
        public string prd_days { get; set; }
        /// <summary>
        /// 用药途径描述
        /// </summary>
        public string medc_way_dscr { get; set; }
        /// <summary>
        /// 开单科室编码
        /// </summary>
        public string bilg_dept_codg { get; set; }
        /// <summary>
        /// 开单科室名称
        /// </summary>
        public string bilg_dept_name { get; set; }
        /// <summary>
        /// 开单医生编码
        /// </summary>
        public string bilg_dr_codg { get; set; }
        /// <summary>
        /// 开单医师姓名
        /// </summary>
        public string bilg_dr_name { get; set; }
        /// <summary>
        /// 受单科室编码
        /// </summary>
        public string acord_dept_codg { get; set; }
        /// <summary>
        /// 受单科室名称
        /// </summary>
        public string acord_dept_name { get; set; }
        /// <summary>
        /// 受单医生编码
        /// </summary>
        public string orders_dr_code { get; set; }
        /// <summary>
        /// 受单医生姓名
        /// </summary>
        public string orders_dr_name { get; set; }
        /// <summary>
        /// 医院审批标志
        /// </summary>
        public string hosp_appr_flag { get; set; }
        /// <summary>
        /// 中药使用方式
        /// </summary>
        public string tcmdrug_used_way { get; set; }
        /// <summary>
        /// 外检标志
        /// </summary>
        public string etip_flag { get; set; }
        /// <summary>
        /// 外检医院编码
        /// </summary>
        public string etip_hosp_code { get; set; }
        /// <summary>
        /// 出院带药标志
        /// </summary>
        public string dscg_tkdrug_flag { get; set; }
        /// <summary>
        /// 生育费用标志
        /// </summary>
        public string matn_fee_flag { get; set; }
        /// <summary>
        /// 组套编号
        /// </summary>
        public string comb_no { get; set; }
        /// <summary>
        /// 字段扩展
        /// </summary>
        public string exp_content { get; set; } 



    }

    #endregion 
}