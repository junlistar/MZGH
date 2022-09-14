
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sunny.UI;
using System.Windows.Forms;

namespace YbjsLib.Model
{ 

    public enum InfoNoEnum
    {
        人员信息 =1101,
        门诊挂号 =2201,
        门诊挂号撤销 =2202,
        就诊信息 =2203,
        门诊明细上传 = 2204,
        预结算= 2206,
        结算= 2207
    }
    //医保配置
    public class YBHelper
    { 

        public static YBResponse<UserInfoResponseModel> currentYBInfo;
        public static YBResponse<RepModel<GHResponseModel>> currentYBPay;
         
        //用户医保信息返回
        public static UserInfoResponseModel userInfoResponseModel;
        public static GHResponseModel gHResponseModel;
        public static MzjsResponse mzjsResponse;


        public static List<InsutypeVM> insutypes;
        public static List<BirctrlTypeVM> birctrlTypes;
        public static List<MedTypeVM> medTypes;
        public static List<MdtrtCertTypeVM> mdtrtCertTypes;

        public static List<YbhzzdVM> ybhzCompare;
        public static List<UserDicVM> doctList;
        public static List<UnitVM> unitList;
        public static List<Diseinfo> diseinfoList;
        public static List<IcdCodeVM> icdCodes;
        public static List<DiagTypeVM> diagTypeList;

        public static List<YBChargeItem> chargeItems;

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
        /// <summary>
        /// 是否可以增加诊断1,0
        /// </summary>
        public static string edit_diseinfo = "0";
        /// <summary>
        /// 医保身份唯一 1,0
        /// </summary>
        public static string yb_identity_only = "0";

        public class YbLog
        {
            public int oper_sn { get; set; }
            public DateTime oper_date { get; set; }
            public string oper_code { get; set; }
            public string data { get; set; }
            public string patient_id { get; set; }
            public int admiss_times { get; set; }
            public int flag { get; set; }
            public string msgid { get; set; }
            public string ver { get; set; }
            public string opera { get; set; }
        }


        public static void AddYBLog(string info_code, int admiss_times, string data, string patient_id, string msgid, string ver, int flag, string opera, string oper_date)
        {
            try
            {
                var _yblog = new YbLog();
                _yblog.admiss_times = admiss_times;
                _yblog.data = data;
                _yblog.oper_code = info_code;
                _yblog.patient_id = patient_id;
                _yblog.msgid = msgid;
                _yblog.ver = ver;
                _yblog.flag = flag;
                _yblog.opera = opera;
                _yblog.oper_date = Convert.ToDateTime(oper_date);


                var paramurl = string.Format($"/api/guahao/AddYbLog");
                var json = HttpClientUtil.PostJSON(paramurl, _yblog);
                //var responseJson = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                //if (responseJson.status == 1)
                //{
                //    log.Debug("医保操作：" + info_code);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public static void SaveCardData(UserInfoResponseModel model)
        //{
        //    Task<HttpResponseMessage> task = null;

        //    var d = new
        //    {
        //        psn_no = model.baseinfo.psn_no,
        //        psn_cert_type = model.baseinfo.psn_cert_type,
        //        certno = model.baseinfo.certno,
        //        psn_name = model.baseinfo.psn_name,
        //        gend = model.baseinfo.gend,
        //        naty = model.baseinfo.naty,
        //        brdy = model.baseinfo.brdy,
        //        age = model.baseinfo.age,
        //    };

        //    string paramurl = string.Format($"/api/user/UpdateYbkInfo?psn_no={d.psn_no}&psn_cert_type={d.psn_cert_type}&certno={d.certno}&psn_name={d.psn_name}&gend={d.gend}&naty={d.naty}&brdy={d.brdy}&age={d.age}");

        //    log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
        //    try
        //    {
        //        task = SessionHelper.MyHttpClient.GetAsync(paramurl);
        //    }
        //    catch (Exception ex)
        //    {
        //        UIMessageTip.Show(ex.Message);
        //        log.Error(ex.ToString());
        //    }

        //}

        //public static void SaveCardDataAll(string jsonStr)
        //{

        //    //更新医保其他信息  
        //    string paramurl = string.Format($"/api/user/UpdateYbkInfoAll");

        //    log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
        //    try
        //    {
        //        HttpContent httpContent = new StringContent(jsonStr);

        //        SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent);

        //    }
        //    catch (Exception ex)
        //    {
        //        UIMessageTip.Show(ex.Message);
        //        log.Error(ex.ToString());
        //    }

        //}

    }
}
