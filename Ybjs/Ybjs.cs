using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YbjsLib.Model;
using System.Windows.Forms;
using System.Configuration;

namespace YbjsLib
{
    public class Ybjs
    {
        //public string Do(string infno,string base) 
        public Ybjs()
        { 
            YBHelper.mdtrtarea_admvs = ConfigurationManager.AppSettings.Get("mdtrtarea_admvs");
            YBHelper.recer_sys_code = ConfigurationManager.AppSettings.Get("recer_sys_code");
            YBHelper.infver = ConfigurationManager.AppSettings.Get("infver");
            YBHelper.opter_type = ConfigurationManager.AppSettings.Get("opter_type");
            YBHelper.fixmedins_code = ConfigurationManager.AppSettings.Get("fixmedins_code");
            YBHelper.fixmedins_name = ConfigurationManager.AppSettings.Get("fixmedins_name");
            YBHelper.edit_diseinfo = ConfigurationManager.AppSettings.Get("edit_diseinfo");
            YBHelper.yb_identity_only = ConfigurationManager.AppSettings.Get("yb_identity_only");
        }


        public void Init(string ybhzComaper_str, string doctList_str, string unitList_str, string icdCodes_str, string diagTypeList_str,string diseinfoList_str,string jiuzhenInfo_str,
            string chargeItems_str, string insutypes_str, string birctrlTypes_str, string medTypes_str, string mdtrtCertTypes_str, string yb_identity_only = "0", string edit_diseinfo = "0")
        {
            try
            {

                //初始化数据下拉列表 
                YBHelper.ybhzCompare = WebApiHelper.DeserializeObject<List<YbhzzdVM>>(ybhzComaper_str);
                YBHelper.doctList = WebApiHelper.DeserializeObject<List<UserDicVM>>(doctList_str);
                YBHelper.unitList = WebApiHelper.DeserializeObject<List<UnitVM>>(unitList_str);
                YBHelper.icdCodes = WebApiHelper.DeserializeObject<List<IcdCodeVM>>(icdCodes_str);
                YBHelper.diagTypeList = WebApiHelper.DeserializeObject<List<DiagTypeVM>>(diagTypeList_str);

                YBHelper.insutypes = WebApiHelper.DeserializeObject<List<InsutypeVM>>(insutypes_str);
                YBHelper.birctrlTypes = WebApiHelper.DeserializeObject<List<BirctrlTypeVM>>(birctrlTypes_str);
                YBHelper.medTypes = WebApiHelper.DeserializeObject<List<MedTypeVM>>(medTypes_str);
                YBHelper.mdtrtCertTypes = WebApiHelper.DeserializeObject<List<MdtrtCertTypeVM>>(mdtrtCertTypes_str);

                YBHelper.diseinfoList = WebApiHelper.DeserializeObject<List<Diseinfo>>(diseinfoList_str);
                YBHelper.chargeItems = WebApiHelper.DeserializeObject<List<YBChargeItem>>(chargeItems_str);
                 
                if (HttpClientFactory.GetHttpClient().BaseAddress == null)
                {
                    //HttpClientFactory.GetHttpClient().BaseAddress = new Uri("http://localhost:5000");
                    HttpClientFactory.GetHttpClient().BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));
                } 
                YBHelper.yb_identity_only = yb_identity_only;
                YBHelper.edit_diseinfo = edit_diseinfo;

                YBHelper.jiuzhenInfo = WebApiHelper.DeserializeObject<JiuzhenInfo>(jiuzhenInfo_str);
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        public string M1101(string opter, string opter_name)
        {
            try
            {
                //1101 读取人员信息
                YBRequest<UserInfoRequestModel> request = new YBRequest<UserInfoRequestModel>();
                request.infno = "1101";
                request.msgid = YBHelper.msgid;
                request.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                request.insuplc_admdvs = "421002";
                request.recer_sys_code = YBHelper.recer_sys_code;
                request.dev_no = "";
                request.dev_safe_info = "";
                request.cainfo = "";
                request.signtype = "";
                request.infver = YBHelper.infver;
                request.opter_type = YBHelper.opter_type;
                request.opter = opter;
                request.opter_name = opter_name;
                request.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                request.fixmedins_code = YBHelper.fixmedins_code;
                request.fixmedins_name = YBHelper.fixmedins_name;
                request.sign_no = YBHelper.msgid;

                request.input = new RepModel<UserInfoRequestModel>();
                request.input.data = new UserInfoRequestModel();
                request.input.data.mdtrt_cert_type = "03";
                request.input.data.psn_cert_type = "1";

                var json = WebApiHelper.SerializeObject(request);

                //调用 com名称  方法  参数
                var BusinessID = ((int)InfoNoEnum.人员信息).ToString();
                var Dataxml = json;
                var Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                YBResponse<UserInfoResponseModel> yBResponse = WebApiHelper.DeserializeObject<YBResponse<UserInfoResponseModel>>(parm[2].ToString());
                if (yBResponse==null)
                {
                    return "";
                }
                YBHelper.userInfoResponseModel = yBResponse.output;

                return parm[2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        public bool PreDeal(string patient_id, int admiss_times, string hic_no, decimal left_je, string ipt_otp_no,
            string icd_code, string yb_ys_code, string doctor_name, string unit_sn, string unit_name, string clinic_name, string opter, string opter_name, ref object[] res)
        {
            try
            { 
                //1101 读取人员信息
                YBRequest<UserInfoRequestModel> request = new YBRequest<UserInfoRequestModel>();
                request.infno = "1101";
                request.msgid = YBHelper.msgid;
                request.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                request.insuplc_admdvs = YBHelper.mdtrtarea_admvs;
                request.recer_sys_code = YBHelper.recer_sys_code;
                request.dev_no = "";
                request.dev_safe_info = "";
                request.cainfo = "";
                request.signtype = "";
                request.infver = YBHelper.infver;
                request.opter_type = YBHelper.opter_type;
                request.opter = opter;
                request.opter_name = opter_name;
                request.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                request.fixmedins_code = YBHelper.fixmedins_code;
                request.fixmedins_name = YBHelper.fixmedins_name;
                request.sign_no = YBHelper.msgid;

                request.input = new RepModel<UserInfoRequestModel>();
                request.input.data = new UserInfoRequestModel();
                request.input.data.mdtrt_cert_type = "03";
                request.input.data.psn_cert_type = "1";

                var json = WebApiHelper.SerializeObject(request);

                //调用 com名称  方法  参数
                var BusinessID = ((int)InfoNoEnum.人员信息).ToString();
                var Dataxml = json;
                var Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                YBResponse<UserInfoResponseModel> yBResponse = WebApiHelper.DeserializeObject<YBResponse<UserInfoResponseModel>>(parm[2].ToString());
                if (!string.IsNullOrEmpty(yBResponse.err_msg))
                {
                    MessageBox.Show(yBResponse.err_msg);
                    return false;
                }
                else if (yBResponse.output != null && !string.IsNullOrEmpty(yBResponse.output.baseinfo.certno))
                {
                    //记录医保日志
                    var paramurl = string.Format($"/api/YbInfo/AddYB1101");
                    yBResponse.output.patient_id = patient_id;
                    yBResponse.output.admiss_times = admiss_times.ToString();
                    HttpClientUtil.PostJSON(paramurl, yBResponse.output);

                    if (YBHelper.yb_identity_only == "1" && yBResponse.output.baseinfo.certno != hic_no)
                    {
                        //如果号码不一致，提示返回
                        MessageBox.Show("医保卡与患者身份不一致！");
                        return false;
                    }
                }
                YBHelper.userInfoResponseModel = yBResponse.output;
                res[0] = WebApiHelper.SerializeObject(YBHelper.userInfoResponseModel);

                //门诊挂号
                YBRequest<GHRequestModel> ghRequest = new YBRequest<GHRequestModel>();
                ghRequest.infno = ((int)InfoNoEnum.门诊挂号).ToString();

                ghRequest.msgid = YBHelper.msgid;
                ghRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                ghRequest.insuplc_admdvs = YBHelper.userInfoResponseModel.insuinfo[0].insuplc_admdvs;
                ghRequest.recer_sys_code = YBHelper.recer_sys_code;
                ghRequest.dev_no = "";
                ghRequest.dev_safe_info = "";
                ghRequest.cainfo = "";
                ghRequest.signtype = "";
                ghRequest.infver = YBHelper.infver;
                ghRequest.opter_type = YBHelper.opter_type;
                ghRequest.opter = opter;
                ghRequest.opter_name = opter_name;
                ghRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ghRequest.fixmedins_code = YBHelper.fixmedins_code;
                ghRequest.fixmedins_name = YBHelper.fixmedins_name;
                ghRequest.sign_no = YBHelper.msgid;

                ghRequest.input = new RepModel<GHRequestModel>();
                ghRequest.input.data = new GHRequestModel();

                ghRequest.input.data.psn_no = YBHelper.userInfoResponseModel.baseinfo.psn_no;
                ghRequest.input.data.insutype = YBHelper.userInfoResponseModel.insuinfo[0].insutype;

                ghRequest.input.data.begntime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //ghRequest.input.data.mdtrt_cert_type = yBResponse.output.baseinfo.psn_cert_type;
                //ghRequest.input.data.mdtrt_cert_no = yBResponse.output.baseinfo.certno;
                ghRequest.input.data.mdtrt_cert_type = "02";//身份证
                ghRequest.input.data.mdtrt_cert_no = YBHelper.userInfoResponseModel.baseinfo.certno;

                ghRequest.input.data.ipt_otp_no = ipt_otp_no; //机制号 唯一" ipt_otp_no": "1533956",
                ghRequest.input.data.atddr_no = yb_ys_code == "" ? "D421003007628" : yb_ys_code;
                ghRequest.input.data.dr_name = doctor_name;
                ghRequest.input.data.dept_code = unit_sn;
                ghRequest.input.data.dept_name = unit_name;
                ghRequest.input.data.caty = clinic_name;

                json = WebApiHelper.SerializeObject(ghRequest);

                BusinessID = "2201";
                Dataxml = json;
                Outputxml = "";
                parm = new object[] { BusinessID, json, Outputxml };

                //提交门诊挂号信息
                var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                var resp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                if (resp != null && !string.IsNullOrEmpty(resp.err_msg))
                {
                    MessageBox.Show(resp.err_msg);
                    return false;
                }
                else if (resp.output != null && !string.IsNullOrEmpty(resp.output.data.mdtrt_id))
                {
                    //记录医保日志
                    var paramurl = string.Format($"/api/YbInfo/AddYB2201");
                    resp.output.data.patient_id = patient_id;
                    resp.output.data.admiss_times = admiss_times.ToString();
                    HttpClientUtil.PostJSON(paramurl, resp.output.data);

                    YBHelper.gHResponseModel = resp.output.data;

                    YBJSPreview yBJSPreview = new YBJSPreview();
                    yBJSPreview.patient_id = patient_id;
                    yBJSPreview.admiss_times = admiss_times;
                    yBJSPreview.dept_sn = unit_sn;
                    yBJSPreview.doct_sn = yb_ys_code;
                    yBJSPreview.icd_code = icd_code;
                    yBJSPreview.opter = opter;
                    yBJSPreview.opter_name = opter_name;
                    yBJSPreview.mdtrt_id = resp.output.data.mdtrt_id;
                    yBJSPreview.psn_no = resp.output.data.psn_no;
                    yBJSPreview.ipt_otp_no = resp.output.data.ipt_otp_no;
                    yBJSPreview.left_je = left_je;

                    if (yBJSPreview.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                    if (res == null)
                    {
                        res = new object[4];
                    }
                    //             public static UserInfoResponseModel userInfoResponseModel;
                    //public static GHResponseModel gHResponseModel;
                    //public static MzjsResponse mzjsResponse;
                    res[0] = WebApiHelper.SerializeObject(YBHelper.userInfoResponseModel);
                    res[1] = WebApiHelper.SerializeObject(YBHelper.gHResponseModel);
                    res[2] = WebApiHelper.SerializeObject(YBHelper.mzjsResponse);
                    res[3] = WebApiHelper.SerializeObject(YBHelper.acct_used_flag);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }



    }
}
