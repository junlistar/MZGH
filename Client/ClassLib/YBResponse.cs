using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Client.ClassLib
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
        public RepModel<T> output { get; set; }
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
    public class IdetInfo { }

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
        public string mdtrt_id { get; set; }
        public string psn_no { get; set; }
        public string ipt_otp_no { get; set; }
        public string exp_content { get; set; }
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
}