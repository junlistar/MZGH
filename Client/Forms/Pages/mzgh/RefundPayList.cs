using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Client.ClassLib;
using Client.ViewModel;
using log4net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Reflection;


namespace Client
{
    public partial class RefundPayList : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(RefundPayList));//typeof放当前类
        List<GhRefundPayVM> paylist = new List<GhRefundPayVM>();

        PatientVM _userInfo;

        string _datestr = "";
        string _patient_id = "";
        int _times = 0;

        public RefundPayList(PatientVM userInfo, string datestr, string patient_id, int times)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _datestr = datestr;
            _patient_id = patient_id;
            _times = times; 
        }

        private void RefundPayList_Load(object sender, EventArgs e)
        {
            StyleHelper.SetGridColor(dgvpaylist);//设置样式
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                var paramurl = string.Format($"/api/GuaHao/GetGhRefundPayList?request_date={_datestr}&patient_id={_patient_id}&times={_times}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhRefundPayVM>>>(json);
                if (result.status == 1)
                {
                    dgvpaylist.Init();
                    paylist = result.data;
                    this.dgvpaylist.DataSource = result.data;
                    //dgvpaylist.AutoGenerateColumns = false;
                    dgvpaylist.AutoResizeColumns();
                    // dgvpaylist.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                }
                else
                {
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }

        }

        private void btnCacel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //查询出关联的组合支付记录  
                var paramurl = string.Format($"/api/GuaHao/GetGhRefund?datestr={_datestr}&patient_id={_patient_id}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhRefundVM>>>(json);

                if (result.status == 1)
                {
                    var list = result.data.Where(p => p.times == _times.ToString() && p.visit_flag == "1").ToList();
                    if (list != null && list.Count > 0)
                    {
                        foreach (var item in paylist)
                        {
                            //退款操作

                            if (!string.IsNullOrWhiteSpace(item.cheque_no))
                            {
                                log.Info("有外部订单号：" + item.cheque_no);

                                var page_model = SessionHelper.pageChequeCompares.Where(p => p.his_code == item.cheque_type).FirstOrDefault();

                                if (page_model == null || int.Parse(page_model.page_code) == (int)PayMethodEnum.Yibao)
                                {
                                    log.Info("医保退款：");
                                    //门诊挂号撤销

                                    ////查询用户医保信息
                                    //var insuplc_admdvs = _userInfo.yb_insuplc_admdvs.Trim();
                                    //var mdtrt_id = item.cheque_no;
                                    //var ipt_otp_no = receipt_sn;
                                    //var psn_no = _userInfo.yb_psn_no;

                                    //YBRequest<GHRefundRequestModel> ghRefund = new YBRequest<GHRefundRequestModel>();
                                    //ghRefund.infno = ((int)InfoNoEnum.门诊挂号撤销).ToString();

                                    //ghRefund.msgid = YBHelper.msgid;
                                    //ghRefund.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                                    //ghRefund.insuplc_admdvs = insuplc_admdvs;
                                    //ghRefund.recer_sys_code = YBHelper.recer_sys_code;
                                    //ghRefund.dev_no = "";
                                    //ghRefund.dev_safe_info = "";
                                    //ghRefund.cainfo = "";
                                    //ghRefund.signtype = "";
                                    //ghRefund.infver = YBHelper.infver;
                                    //ghRefund.opter_type = YBHelper.opter_type;
                                    //ghRefund.opter = SessionHelper.uservm.user_mi;
                                    //ghRefund.opter_name = SessionHelper.uservm.name;
                                    //ghRefund.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    //ghRefund.fixmedins_code = YBHelper.fixmedins_code;
                                    //ghRefund.fixmedins_name = YBHelper.fixmedins_name;
                                    //ghRefund.sign_no = YBHelper.msgid;

                                    //ghRefund.input = new RepModel<GHRefundRequestModel>();
                                    //ghRefund.input.data = new GHRefundRequestModel();
                                    //ghRefund.input.data.mdtrt_id = mdtrt_id;
                                    //ghRefund.input.data.psn_no = psn_no;
                                    //ghRefund.input.data.ipt_otp_no = item.receipt_sn;// ipt_otp_no;


                                    //json = WebApiHelper.SerializeObject(ghRefund);

                                    //var BusinessID = "2202";
                                    //var Dataxml = json;
                                    //var Outputxml = "";
                                    //var parm = new object[] { BusinessID, json, Outputxml };

                                    //ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                                    //log.Debug(parm[2]);

                                    //var refund_resp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                                    //if (!string.IsNullOrEmpty(refund_resp.err_msg))
                                    //{
                                    //    MessageBox.Show(refund_resp.err_msg);
                                    //    log.Error(refund_resp.err_msg);
                                    //    return;
                                    //}


                                    //门诊结算撤销
                                    var jscxRequest = new YBRequest<MZJSCX>();
                                    jscxRequest.infno = "2208";

                                    jscxRequest.msgid = YBHelper.msgid;
                                    jscxRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                                    jscxRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
                                    jscxRequest.recer_sys_code = YBHelper.recer_sys_code;
                                    jscxRequest.dev_no = "";
                                    jscxRequest.dev_safe_info = "";
                                    jscxRequest.cainfo = "";
                                    jscxRequest.signtype = "";
                                    jscxRequest.infver = YBHelper.infver;
                                    jscxRequest.opter_type = YBHelper.opter_type;
                                    jscxRequest.opter = SessionHelper.uservm.user_mi;
                                    jscxRequest.opter_name = SessionHelper.uservm.name;
                                    jscxRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    jscxRequest.fixmedins_code = YBHelper.fixmedins_code;
                                    jscxRequest.fixmedins_name = YBHelper.fixmedins_name;
                                    jscxRequest.sign_no = YBHelper.msgid;
                                    jscxRequest.input = new RepModel<MZJSCX>();

                                    MZJSCX _mzjscx = new MZJSCX();
                                    _mzjscx.psn_no = SessionHelper.patientVM.yb_psn_no;
                                    _mzjscx.setl_id = item.out_trade_no;//结算返回值 
                                    _mzjscx.mdtrt_id = item.cheque_no;

                                    jscxRequest.input.data = _mzjscx;

                                    json = WebApiHelper.SerializeObject(jscxRequest);
                                    var BusinessID = "2208";
                                    var Dataxml = json;
                                    var Outputxml = "";
                                    var parm = new object[] { BusinessID, json, Outputxml };


                                    YBHelper.AddYBLog(BusinessID, _times, json, SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 0, SessionHelper.uservm.user_mi, jscxRequest.inf_time);
                                    //提交
                                    ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                                    log.Debug("结算撤销返回：" + parm[2]);
                                    YBHelper.AddYBLog(BusinessID, _times, parm[2].ToString(), SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 1, SessionHelper.uservm.user_mi, jscxRequest.inf_time);

                                    var _jscxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                                    if (string.IsNullOrEmpty(_jscxresp.err_msg))
                                    {
                                        //记录医保日志
                                        var _url = string.Format($"/api/YbInfo/AddYB2208?patient_id={_patient_id}&admiss_times={item.admiss_times}&mdtrt_id={item.mdtrt_id}");
                                        HttpClientUtil.Get(_url);
                                    }

                                } 
                                else if (int.Parse(page_model.page_code) == (int)PayMethodEnum.WeiXin)
                                {
                                    log.Info("微信退款：");
                                    //微信退款
                                    //var transaction_id = "";
                                    //var out_trade_no = vm.cheque_no;
                                    //var total_fee = vm.charge.ToString();
                                    //var redfund_fee = vm.charge.ToString();

                                    //var wx_response = WxPayAPI.Refund.Run(transaction_id, out_trade_no, total_fee, redfund_fee);
                                    //log.Info("微信退款返回字符串：" + wx_response);

                                }
                                else if (int.Parse(page_model.page_code) == (int)PayMethodEnum.Zhifubao)
                                {
                                    log.Info("支付宝退款：");
                                    //支付宝退款
                                    //var cof = AliConfig.GetConfig();
                                    //Factory.SetOptions(cof);

                                    ////全部退款
                                    //AlipayTradeRefundResponse response = Factory.Payment.Common().Refund(vm.cheque_no, vm.charge.ToString());
                                    ////部分退款
                                    ////AlipayTradeRefundResponse response = Factory.Payment.Common().Optional("out_request_no", "2020093011380002-2").Refund("2020093011380003", "0.02");

                                    //if (ResponseChecker.Success(response))
                                    //{
                                    //    log.Info("支付宝退款调用成功");
                                    //}
                                    //else
                                    //{
                                    //    log.Error("支付宝退款调用失败，原因：" + response.Msg);
                                    //}
                                }

                            }
                        }

                        var aa = new
                        {
                            patient_id = _patient_id,
                            times = _times,
                            opera = SessionHelper.uservm.user_mi
                        };


                        var data = WebApiHelper.SerializeObject(aa);
                        HttpContent httpContent = new StringContent(data);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        string paramurl2 = string.Format($"/api/GuaHao/Refund?patient_id={aa.patient_id}&times={aa.times}&opera={SessionHelper.uservm.user_mi}");

                        log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl2);

                        string res = SessionHelper.MyHttpClient.PostAsync(paramurl2, httpContent).Result.Content.ReadAsStringAsync().Result;
                        var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);
                        if (responseJson.status == 1)
                        {
                            UIMessageTip.ShowOk("退号成功!");
                            this.DialogResult = DialogResult.OK;
                            System.Threading.Thread.Sleep(1000);
                            this.Close();
                        }
                        else
                        {
                            UIMessageBox.ShowError(responseJson.message);
                            log.Info(responseJson.message);
                        }
                    }
                    else
                    {
                        UIMessageTip.ShowWarning("数据已过期，请重新查询！");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }


        private void RefundPayList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
