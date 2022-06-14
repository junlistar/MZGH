using Mzsf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mzsf.ClassLib
{ 

    public enum InfoNoEnum
    {
        人员信息 =1101,
        门诊挂号 =2201,
        门诊挂号撤销 =2202,
         
    }

    //医保配置
    public class YBHelper
    {

        public static YBResponse<UserInfoResponseModel> currentYBInfo;
        public static YBResponse<RepModel<GHResponseModel>> currentYBPay;


        /// <summary>
        /// 发送方报文 ID
        /// 定点医药机构编号(12)+时间(14)+ 顺序号(4)
        /// 时间格式：yyyyMMddHHmmss
        /// </summary>
        public static string msgid
        {
            get
            {
                return fixmedins_code + DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(1000,10000));
            }
        }

        /// <summary>
        /// 就医地医保区划 421003
        /// </summary>
        public static string mdtrtarea_admvs = "421003";
        /// <summary>
        /// 接收方系统代码 1
        /// </summary>
        public static string recer_sys_code = "1";
        /// <summary>
        /// 接口版本号 v2.0
        /// </summary>
        public static string infver = "v2.0";
        /// <summary>
        /// 经办人类别 1-经办人；2-自助终端；3-移动终端
        /// </summary>
        public static string opter_type = "1";
        /// <summary>
        /// 定点医药机构编号 H42100300513
        /// </summary>
        public static string fixmedins_code = "H42100300513";
        /// <summary>
        /// 定点医药机构名称 荆州市中心医院
        /// </summary>
        public static string fixmedins_name = "荆州市中心医院";
        /// <summary>
        /// 交易签到流水号 421000G0000000244038
        /// </summary>
        public static string sign_no = "421000G0000000244038";
    }
}
