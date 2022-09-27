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
using Client.ViewModel;
using System.Net.Http;
using System.Configuration;
using Client.ClassLib;
using System.Net.Http.Headers;
using System.Web;
using WxPayAPI;
using System.Threading;
using log4net;
using Client.Pay.AliPayAPI;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Payment.FaceToFace.Models;
using Alipay.EasySDK.Kernel.Util;
using Alipay.EasySDK.Payment.Common.Models;
using System.Drawing.Printing;
using FastReport;
using Client.FastReportLib;
using System.Runtime.InteropServices;
using System.Reflection;
using FastReport.Utils;
using MyMzghLib;
using FastReport.Design;
using System.IO;
using Client.Forms.Wedgit;
using Newtonsoft.Json;

namespace Client
{
    public partial class SelectPayType : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(SelectPayType));//typeof放当前类


        GHRequestVM vm = new GHRequestVM();
        string patientId = ""; int max_sn = 0;
        Dictionary<int, double> dicPay = new Dictionary<int, double>();
        List<GHPayModel> paylist = new List<GHPayModel>();
        List<ChargeItemVM> chargeItems = new List<ChargeItemVM>();

        //用户医保信息返回
        public UserInfoResponseModel userInfoResponseModel;
        public GHResponseModel gHResponseModel;
        public MzjsResponse mzjsResponse;
        string acct_used_flag;


        public SelectPayType(GHRequestVM _vm, string _patientId)
        {
            InitializeComponent(); vm = _vm; patientId = _patientId;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (paylist.Count > 0)
            {
                if (UIMessageBox.ShowAsk("取消支付并退还已支付的款项，是否确认操作？"))
                {
                    Refund(); this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        public void Refund()
        {

            log.Info("取消支付,退款处理：");
            UIMessageTip.ShowOk("取消支付,退款处理开始");
            foreach (var item in paylist)
            {
                RefundType(item);
            }

            log.Info("结束取消支付,退款处理");

        }

        public void RefundType(GHPayModel item)
        {
            try
            {


                var chequeCompare = SessionHelper.pageChequeCompares.Where(p => p.his_code == item.pay_type).FirstOrDefault();

                if (chequeCompare != null)
                {
                    log.Info("处理退款:" + item.pay_type + ",金额：" + item.pay_je);

                    UIMessageBox.ShowInfo($"处理{chequeCompare.his_name}退款,金额：" + item.pay_je);

                    if (chequeCompare.page_code == ((int)PayMethodEnum.Xianjin).ToString())
                    {
                        //UIMessageBox.ShowInfo("处理现金退款,金额：" + item.pay_je);
                    }
                    else if (chequeCompare.page_code == ((int)PayMethodEnum.WeiXin).ToString())
                    {
                        //var transaction_id = "";
                        //var out_trade_no = "";
                        //var total_fee = "";
                        //var redfund_fee = "";

                        //var wx_response = WxPayAPI.Refund.Run(transaction_id, out_trade_no, total_fee, redfund_fee);
                        //log.Info("微信退款返回字符串：" + wx_response);


                        UpdateThirdPayStatus(SessionHelper.patientVM.patient_id, item.pay_type.ToString(), item.out_trade_no, item.pay_je.ToString());
                        // UIMessageBox.ShowInfo("处理微信退款,金额：" + item.pay_je);
                        //UIMessageTip.ShowOk("处理微信退款,金额：" + item.pay_je); Thread.Sleep(1000);
                    }
                    else if (chequeCompare.page_code == ((int)PayMethodEnum.Yibao).ToString())
                    {
                        // UIMessageBox.ShowInfo("处理医保退款,金额：" + item.pay_je);

                        if (YBRefund())
                        {

                            UpdateThirdPayStatus(SessionHelper.patientVM.patient_id, item.pay_type.ToString(), item.out_trade_no, item.pay_je.ToString());
                        }
                    }
                    else if (chequeCompare.page_code == ((int)PayMethodEnum.Yinlian).ToString())
                    {
                        UpdateThirdPayStatus(SessionHelper.patientVM.patient_id, item.pay_type.ToString(), item.out_trade_no, item.pay_je.ToString());
                        //  UIMessageBox.ShowInfo("处理银联退款,金额：" + item.pay_je);
                    }
                    else if (chequeCompare.page_code == ((int)PayMethodEnum.Zhifubao).ToString())
                    {
                        UpdateThirdPayStatus(SessionHelper.patientVM.patient_id, item.pay_type.ToString(), item.out_trade_no, item.pay_je.ToString());

                        //var cof = AliConfig.GetConfig();
                        //Factory.SetOptions(cof);

                        ////全部退款
                        //AlipayTradeRefundResponse response = Factory.Payment.Common().Refund("外部订单号", "1.0");
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

                        //UIMessageBox.ShowInfo("处理支付宝退款,金额：" + item.pay_je);
                    }
                    else
                    {
                        //UIMessageBox.ShowInfo("处理其他退款,金额：" + item.pay_je);
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        public bool YBRefund()
        {
            try
            {

                //查询用户医保信息 
                var insuplc_admdvs = GuaHao.PatientVM.yb_insuplc_admdvs.Trim();
                var mdtrt_id = gHResponseModel.mdtrt_id;
                var ipt_otp_no = gHResponseModel.ipt_otp_no;
                var psn_no = gHResponseModel.psn_no;



                YBRequest<GHRefundRequestModel> ghRefund = new YBRequest<GHRefundRequestModel>();
                ghRefund.infno = ((int)InfoNoEnum.门诊挂号撤销).ToString();

                ghRefund.msgid = YBHelper.msgid;
                ghRefund.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                ghRefund.insuplc_admdvs = insuplc_admdvs;
                ghRefund.recer_sys_code = YBHelper.recer_sys_code;
                ghRefund.dev_no = "";
                ghRefund.dev_safe_info = "";
                ghRefund.cainfo = "";
                ghRefund.signtype = "";
                ghRefund.infver = YBHelper.infver;
                ghRefund.opter_type = YBHelper.opter_type;
                ghRefund.opter = SessionHelper.uservm.user_mi;
                ghRefund.opter_name = SessionHelper.uservm.name;
                ghRefund.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ghRefund.fixmedins_code = YBHelper.fixmedins_code;
                ghRefund.fixmedins_name = YBHelper.fixmedins_name;
                ghRefund.sign_no = YBHelper.msgid;

                ghRefund.input = new RepModel<GHRefundRequestModel>();
                ghRefund.input.data = new GHRefundRequestModel();
                ghRefund.input.data.mdtrt_id = mdtrt_id;
                ghRefund.input.data.psn_no = psn_no;
                ghRefund.input.data.ipt_otp_no = ipt_otp_no;


                var json = WebApiHelper.SerializeObject(ghRefund);

                var BusinessID = "2202";
                var Dataxml = json;
                var Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                log.Debug(parm[2]);

                var refund_resp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                if (!string.IsNullOrEmpty(refund_resp.err_msg))
                {
                    MessageBox.Show(refund_resp.err_msg);
                    log.Error(refund_resp.err_msg);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
            return false;
        }


        private void btnwx_Click(object sender, EventArgs e)
        {

            //OpenPayWindow(PayMethodEnum.WeiXin);

        }

        public void ShowMessage()
        {
            var left_je = Convert.ToDouble(lblsyje.Text);
            if (left_je == 0)
            {
                lblmsg.Visible = true;
                lblmsg.ForeColor = Color.Red;
                timer1.Interval = 500;
                timer1.Start();
            }
            else
            {
                timer1.Stop(); lblmsg.Visible = false;
            }
        }



        public void OpenPayWindow(PayMethodEnum payMethod, string his_cheque_type)
        {

            try
            {

                var left_je = Convert.ToDouble(lblsyje.Text);

                if (left_je == 0)
                {
                    UIMessageTip.ShowWarning("金额为0，无需支付！");
                    return;
                }

                //如果选择了组合支付
                if (chkcomb.Checked)
                {

                    //if (UIInputDialog.InputDoubleDialog(this  ,ref left_je, 2,true,"请输入金额：",false))
                    if (UIInputDialog.InputDoubleDialog(ref left_je, 2, true, $"请核对本次{ PayMethod.GetPayStringByEnum(payMethod) }支付金额："))
                    {
                        //UIMessageTip.ShowOk("ok");

                        if (left_je > Convert.ToDouble(lblsyje.Text))
                        {
                            UIMessageTip.ShowWarning("金额大于剩余付款金额！");
                            return;
                        }
                        //else if (left_je == 0)
                        //{
                        //    UIMessageTip.ShowWarning("金额为0！");
                        //    return;
                        //}
                        else if (left_je <= 0)
                        {
                            UIMessageTip.ShowWarning("金额有误！");
                            return;
                        }

                        //生成商户订单号

                    }
                    else
                    {
                        UIMessageTip.Show("取消了支付");
                        return;
                    }
                }
                else
                {
                    //没有选择组合支付 

                }

                string out_trade_no = System.DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(1000, 9999));

                if (payMethod == PayMethodEnum.WeiXin || payMethod == PayMethodEnum.Zhifubao)
                {

                    WxPay wxPay = new WxPay(his_cheque_type, left_je.ToString(), out_trade_no);
                    wxPay.ShowDialog();
                    if (wxPay.DialogResult == DialogResult.OK)
                    {
                        log.Info("完成支付：" + his_cheque_type + ",金额：" + left_je);
                        //保存支付数据，用于退款
                        paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je, out_trade_no));

                        this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                        //总金额-支付金额
                        lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                        lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();

                        //保存到数据库
                        AddMzThridPay(his_cheque_type, out_trade_no, "", "", "", "", "", (decimal)left_je);

                    }
                    else
                    {
                        log.Info("取消支付：" + his_cheque_type + ",金额：" + left_je);

                    }

                }
                else if (payMethod == PayMethodEnum.Yinlian)
                {
                    CardPay card = new CardPay((his_cheque_type), left_je.ToString());
                    card.ShowDialog();
                    if (card.DialogResult == DialogResult.OK)
                    {
                        log.Info("完成支付：" + his_cheque_type + ",金额：" + left_je);
                        //保存支付数据，用于退款
                        paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je, out_trade_no));

                        this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                        //总金额-支付金额
                        lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                        lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();

                        //保存到数据库
                        AddMzThridPay(his_cheque_type, out_trade_no, "", "", "", "", "", (decimal)left_je);
                    }
                    else
                    {
                        log.Info("取消支付：" + his_cheque_type + ",金额：" + left_je);
                    }
                }
                else if (payMethod == PayMethodEnum.Yibao)
                {
                    var _fund_pay_code = "";
                    var _acct_pay_code = "";
                    try
                    {
                        var _ybmodel = SessionHelper.ybNames[0].parms;

                        var pay_arr = _ybmodel.Split(";");
                        _acct_pay_code = pay_arr[0].Split("=")[1];
                        _fund_pay_code = pay_arr[1].Split("=")[1];

                        if (_acct_pay_code.Contains("<"))
                        {
                            _acct_pay_code = _acct_pay_code.Substring(0, _acct_pay_code.IndexOf("<"));
                        }
                        if (_fund_pay_code.Contains("<"))
                        {
                            _fund_pay_code = _fund_pay_code.Substring(0, _fund_pay_code.IndexOf("<"));
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("没有获取到医保支付配置表数据：YbName");
                        return;
                    }



                    //刷医保卡，再挂号 
                    if (YiBaoPay(Convert.ToDecimal(left_je)))
                    {
                        //基金支付总额 6
                        var _fund_pay_sumamt = mzjsResponse.setlinfo.fund_pay_sumamt;
                        //个人账户 a
                        var _acct_pay = mzjsResponse.setlinfo.acct_pay;
                        //个人现金 1
                        var _psn_cash_pay = mzjsResponse.setlinfo.psn_cash_pay;

                        if (decimal.Parse(_fund_pay_sumamt) != 0)
                        {
                            log.Info("完成支付：" + _fund_pay_code + ",金额：" + decimal.Parse(_fund_pay_sumamt));
                            this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + decimal.Parse(_fund_pay_sumamt));

                            paylist.Add(new GHPayModel(_fund_pay_code, decimal.Parse(_fund_pay_sumamt), mzjsResponse.setlinfo.mdtrt_id, mzjsResponse.setlinfo.setl_id));

                            //保存到数据库
                            AddMzThridPay(_fund_pay_code, gHResponseModel.mdtrt_id, mzjsResponse.setlinfo.mdtrt_id, mzjsResponse.setlinfo.setl_id, gHResponseModel.ipt_otp_no, gHResponseModel.psn_no, userInfoResponseModel.insuinfo[0].insuplc_admdvs, (decimal)left_je);
                        }
                        if (acct_used_flag == "1")
                        {
                            if (decimal.Parse(_acct_pay) != 0)
                            {
                                log.Info("完成支付：" + _acct_pay_code + ",金额：" + decimal.Parse(_acct_pay));
                                this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + decimal.Parse(_acct_pay));
                                paylist.Add(new GHPayModel(_acct_pay_code, decimal.Parse(_acct_pay), mzjsResponse.setlinfo.mdtrt_id, mzjsResponse.setlinfo.setl_id));
                                //保存到数据库
                                AddMzThridPay(_acct_pay_code, gHResponseModel.mdtrt_id, mzjsResponse.setlinfo.mdtrt_id, mzjsResponse.setlinfo.setl_id, gHResponseModel.ipt_otp_no, gHResponseModel.psn_no, userInfoResponseModel.insuinfo[0].insuplc_admdvs, (decimal)left_je);

                            }
                        }
                        if (acct_used_flag == "0")
                        {
                            if (decimal.Parse(_psn_cash_pay) != 0)
                            {
                                log.Info("完成支付：" + "1" + ",金额：" + decimal.Parse(_psn_cash_pay));
                                this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(PayMethodEnum.Xianjin) + "，金额： " + decimal.Parse(_psn_cash_pay));
                                paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je, "", ""));
                            }
                        } 
                       // log.Info("完成支付：" + his_cheque_type + ",金额：" + left_je);
                        //保存支付数据，用于退款
                        //paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je, mzjsResponse.setlinfo.mdtrt_id, mzjsResponse.setlinfo.setl_id));

                       // this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                        //总金额-支付金额
                        lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                        lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();

                        //保存到数据库
                       // AddMzThridPay(his_cheque_type, gHResponseModel.mdtrt_id, mzjsResponse.setlinfo.mdtrt_id, mzjsResponse.setlinfo.setl_id, gHResponseModel.ipt_otp_no, gHResponseModel.psn_no, userInfoResponseModel.insuinfo[0].insuplc_admdvs, (decimal)left_je);
                    }
                    else
                    {
                        log.Info("支付失败：" + his_cheque_type + ",金额：" + left_je);
                    }
                }
                else if (payMethod == PayMethodEnum.Xianjin)
                {
                    JKZL xjzf = new JKZL(his_cheque_type, left_je.ToString());
                    if (chkcomb.Checked)
                    {
                        xjzf.lbl1.Text = "本次支付:";
                    }

                    xjzf.ShowDialog();
                    if (xjzf.DialogResult == DialogResult.OK)
                    {
                        log.Info("完成支付：" + (int)payMethod + ",金额：" + left_je);
                        //保存支付数据，用于退款
                        paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je));

                        this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                        //总金额-支付金额
                        lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                        lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();
                    }
                    else
                    {
                        log.Info("取消支付：" + his_cheque_type + ",金额：" + left_je);

                    }
                }
                else
                {
                    log.Info("其他支付：" + his_cheque_type + ",金额：" + left_je);
                    //其他支付
                    UIMessageTip.ShowOk("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + ",金额：" + left_je);
                }

                ShowMessage();

                //支付完成，自动提交
                var sy_je = Convert.ToDouble(lblsyje.Text);
                if (sy_je == 0)
                {
                    TiJiaoZhifu();
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        public List<YBChargeItem> GetChargeItems()
        {
            List<YBChargeItem> _list = new List<YBChargeItem>();

            foreach (var item in chargeItems)
            {
                YBChargeItem _detail = new YBChargeItem();
                _detail.charge_code = item.charge_code;
                _detail.charge_price = item.charge_price;
                _detail.charge_amount = 1;
                _detail.orig_price = item.charge_price;
                _list.Add(_detail);
            }
            return _list;
        }
        public bool YiBaoPay(decimal left_je)
        {
            try
            {
                int admiss_times = GuaHao.PatientVM.max_times + 1;
                string patient_id = GuaHao.PatientVM.patient_id;
                //机制号
                var sn_no = GetReceiptMaxNo();

                //获取预结算数据   GetYBCardInfo(string patient_id, int admiss_times, string doctor_code, string apply_unit)
                var yburl = string.Format($"/api/YbInfo/GetYBCardInfo?patient_id={patient_id}&admiss_times={admiss_times}&doctor_code={vm.doctor_sn}&apply_unit={vm.unit_sn}");
                var ybjsonstr = HttpClientUtil.Get(yburl);
                var ybresult = WebApiHelper.DeserializeObject<ResponseResult<UserInfoResponseModel>>(ybjsonstr);
                if (ybresult.status==-1)
                {
                    MessageBox.Show("获取医保卡数据失败");
                    return false;
                }

                //基础数据(读卡存在了)

                //就诊数据
                var jiuzhenInfo = ybresult.data.jiuzhenInfo;
                var diseinfo = ybresult.data.diseinfo;
                 
                string ybhzComaper_str = WebApiHelper.SerializeObject(SessionHelper.ybhzCompare);
                string doctList_str = WebApiHelper.SerializeObject(SessionHelper.userDics.Where(p => !string.IsNullOrEmpty(p.yb_ys_code)).ToList());
                string unitList_str = WebApiHelper.SerializeObject(SessionHelper.units);
                string diseinfoList_str = WebApiHelper.SerializeObject(diseinfo);
                string icdCodes_str = WebApiHelper.SerializeObject(SessionHelper.icdCodes);
                string diagTypeList_str = WebApiHelper.SerializeObject(SessionHelper.diagTypes);
                string chargeItems_str = WebApiHelper.SerializeObject(GetChargeItems());
                string insutypes_str = WebApiHelper.SerializeObject(SessionHelper.insutypes);
                string birctrlTypes_str = WebApiHelper.SerializeObject(SessionHelper.birctrlTypes);
                string medTypes_str = WebApiHelper.SerializeObject(SessionHelper.medTypes);
                string mdtrtCertTypes_str = WebApiHelper.SerializeObject(SessionHelper.mdtrtCertTypes);
                string jiuzhenInfo_str = WebApiHelper.SerializeObject(jiuzhenInfo); 

                YbjsLib.Ybjs ybjs = new YbjsLib.Ybjs();

                ybjs.Init(ybhzComaper_str, doctList_str, unitList_str, icdCodes_str, diagTypeList_str, diseinfoList_str, jiuzhenInfo_str,chargeItems_str, insutypes_str, birctrlTypes_str, medTypes_str, mdtrtCertTypes_str,"0","1");

                object[] objparam = new object[4];

                var js_result = ybjs.PreDeal(patient_id, admiss_times, GuaHao.PatientVM.hic_no, left_je, sn_no, vm.icd_code, vm.yb_ys_code, vm.doctor_name, vm.unit_sn, vm.unit_name, vm.clinic_name, SessionHelper.uservm.user_mi, SessionHelper.uservm.name, ref objparam);
                if (js_result)
                {
                    userInfoResponseModel = WebApiHelper.DeserializeObject<UserInfoResponseModel>(objparam[0].ToString());
                    gHResponseModel = WebApiHelper.DeserializeObject<GHResponseModel>(objparam[1].ToString());
                    mzjsResponse = WebApiHelper.DeserializeObject<MzjsResponse>(objparam[2].ToString()); 
                    acct_used_flag = WebApiHelper.DeserializeObject<string>(objparam[3].ToString());
                }
                return js_result;

                string json = "";
                string BusinessID = "1101";
                string Dataxml = json;
                string Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };


                //var res = DataPost("http://10.87.82.212:8080", json);

                //if (string.IsNullOrEmpty(GuaHao.PatientVM.yb_insuplc_admdvs) || string.IsNullOrEmpty(GuaHao.PatientVM.hic_no)
                //   || string.IsNullOrEmpty(GuaHao.PatientVM.yb_insutype) || string.IsNullOrEmpty(GuaHao.PatientVM.yb_psn_no))
                //{
                YBRequest<UserInfoRequestModel> request = new YBRequest<UserInfoRequestModel>();
                request.infno = ((int)InfoNoEnum.人员信息).ToString();
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
                request.opter = SessionHelper.uservm.user_mi;
                request.opter_name = SessionHelper.uservm.name;
                request.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                request.fixmedins_code = YBHelper.fixmedins_code;
                request.fixmedins_name = YBHelper.fixmedins_name;
                request.sign_no = YBHelper.msgid;

                request.input = new RepModel<UserInfoRequestModel>();
                request.input.data = new UserInfoRequestModel();
                request.input.data.mdtrt_cert_type = "03";
                request.input.data.psn_cert_type = "1";

                json = WebApiHelper.SerializeObject(request);

                //调用 com名称  方法  参数
                BusinessID = ((int)InfoNoEnum.人员信息).ToString();
                Dataxml = json;
                Outputxml = "";
                parm = new object[] { BusinessID, json, Outputxml };

                InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                log.Debug(parm[2]);

                YBResponse<UserInfoResponseModel> yBResponse = WebApiHelper.DeserializeObject<YBResponse<UserInfoResponseModel>>(parm[2].ToString());

                if (!string.IsNullOrEmpty(yBResponse.err_msg))
                {
                    MessageBox.Show(yBResponse.err_msg);
                    log.Error(yBResponse.err_msg);
                    return false;
                }
                else if (yBResponse.output != null && !string.IsNullOrEmpty(yBResponse.output.baseinfo.certno))
                {
                    //记录医保日志
                    var paramurl = string.Format($"/api/YbInfo/AddYB1101");
                    yBResponse.output.patient_id = patient_id;
                    yBResponse.output.admiss_times = admiss_times.ToString();
                    HttpClientUtil.PostJSON(paramurl, yBResponse.output);

                    SessionHelper.cardno = yBResponse.output.baseinfo.certno;

                    if (YBHelper.yb_identity_only == "1" && yBResponse.output.baseinfo.certno != GuaHao.PatientVM.hic_no)
                    {
                        //如果号码不一致，提示返回
                        MessageBox.Show("医保卡与患者身份不一致！");
                        return false;
                    }

                    YBHelper.currentYBInfo = yBResponse;

                    GuaHao.PatientVM.yb_insuplc_admdvs = yBResponse.output.insuinfo[0].insuplc_admdvs;
                    GuaHao.PatientVM.yb_insutype = yBResponse.output.insuinfo[0].insutype;
                    GuaHao.PatientVM.yb_psn_no = yBResponse.output.baseinfo.psn_no;

                    //保存用户的医保信息
                    var d = new
                    {
                        yb_psn_no = yBResponse.output.baseinfo.psn_no,
                        social_no = yBResponse.output.baseinfo.certno,
                        pid = patientId,
                        yb_insuplc_admdvs = yBResponse.output.insuinfo[0].insuplc_admdvs,
                        yb_insutype = yBResponse.output.insuinfo[0].insutype,
                        opera = SessionHelper.uservm.user_mi
                    };
                    var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    paramurl = string.Format($"/api/GuaHao/UpdateUserYBInfo?pid={d.pid}&social_no={d.social_no}&yb_psn_no={d.yb_psn_no}&yb_insutype={d.yb_insutype}&yb_insuplc_admdvs={d.yb_insuplc_admdvs}");

                    string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                    var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);

                    if (responseJson.data == 1)
                    {
                        log.Debug("修改用户医保信息成功");

                    }
                    else
                    {
                        log.Error(responseJson.message);
                    }
                }

                //}


                //门诊挂号
                YBRequest<GHRequestModel> ghRequest = new YBRequest<GHRequestModel>();
                ghRequest.infno = ((int)InfoNoEnum.门诊挂号).ToString();

                ghRequest.msgid = YBHelper.msgid;
                ghRequest.mdtrtarea_admvs = "421099";// YBHelper.mdtrtarea_admvs;
                ghRequest.insuplc_admdvs = GuaHao.PatientVM.yb_insuplc_admdvs.Trim();
                ghRequest.recer_sys_code = YBHelper.recer_sys_code;
                ghRequest.dev_no = "";
                ghRequest.dev_safe_info = "";
                ghRequest.cainfo = "";
                ghRequest.signtype = "";
                ghRequest.infver = YBHelper.infver;
                ghRequest.opter_type = YBHelper.opter_type;
                ghRequest.opter = SessionHelper.uservm.user_mi;
                ghRequest.opter_name = SessionHelper.uservm.name;
                ghRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ghRequest.fixmedins_code = YBHelper.fixmedins_code;
                ghRequest.fixmedins_name = YBHelper.fixmedins_name;
                ghRequest.sign_no = YBHelper.msgid;

                ghRequest.input = new RepModel<GHRequestModel>();
                ghRequest.input.data = new GHRequestModel();

                ghRequest.input.data.psn_no = GuaHao.PatientVM.yb_psn_no.Trim();
                ghRequest.input.data.insutype = GuaHao.PatientVM.yb_insutype.Trim();

                ghRequest.input.data.begntime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //ghRequest.input.data.mdtrt_cert_type = yBResponse.output.baseinfo.psn_cert_type;
                //ghRequest.input.data.mdtrt_cert_no = yBResponse.output.baseinfo.certno;
                ghRequest.input.data.mdtrt_cert_type = "02";//身份证
                ghRequest.input.data.mdtrt_cert_no = GuaHao.PatientVM.hic_no;

                ghRequest.input.data.ipt_otp_no = sn_no; //机制号 唯一" ipt_otp_no": "1533956",
                ghRequest.input.data.atddr_no = vm.yb_ys_code == "" ? "D421003007628" : vm.yb_ys_code; //"D421003007628"; //医生医保编号 "atddr_no": "D421003007628",
                ghRequest.input.data.dr_name = vm.doctor_name;
                ghRequest.input.data.dept_code = vm.unit_sn;
                ghRequest.input.data.dept_name = vm.unit_name;
                ghRequest.input.data.caty = vm.clinic_name;

                json = WebApiHelper.SerializeObject(ghRequest);

                BusinessID = "2201";
                Dataxml = json;
                Outputxml = "";
                parm = new object[] { BusinessID, json, Outputxml };

                //提交门诊挂号信息
                var result = InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                log.Debug(parm[2]);

                var resp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                if (resp != null && !string.IsNullOrEmpty(resp.err_msg))
                {
                    MessageBox.Show(resp.err_msg);
                    log.Error(resp.err_msg);
                }
                else if (resp.output != null && !string.IsNullOrEmpty(resp.output.data.mdtrt_id))
                {
                    //记录医保日志
                    var paramurl = string.Format($"/api/YbInfo/AddYB2201");
                    resp.output.data.patient_id = patient_id;
                    resp.output.data.admiss_times = admiss_times.ToString();
                    HttpClientUtil.PostJSON(paramurl, resp.output.data);

                    //保存医保支付信息，用于退款
                    YBHelper.currentYBPay = resp;
                    //就诊ID 医保返回唯一流水
                    string mdtrt_id = resp.output.data.mdtrt_id;
                    //人员编号
                    string psn_no = resp.output.data.psn_no;
                    //住院/门诊号
                    string ipt_otp_no = resp.output.data.ipt_otp_no;

                    //弹出预结算信息
                    YBJSPreview yBJSPreview = new YBJSPreview();
                    yBJSPreview.admiss_times = admiss_times;
                    yBJSPreview.patient_id = patient_id;
                    yBJSPreview.mdtrt_id = mdtrt_id;
                    yBJSPreview.psn_no = psn_no;
                    yBJSPreview.ipt_otp_no = ipt_otp_no;
                    yBJSPreview.ghRequest = vm;
                    yBJSPreview.chargeItems = chargeItems;
                    yBJSPreview.left_je = left_je;

                    //绑定医师信息
                    yBJSPreview.doctList = SessionHelper.userDics.Where(p => !string.IsNullOrEmpty(p.yb_ys_code)).ToList();
                    yBJSPreview.unitList = SessionHelper.units;

                    if (yBJSPreview.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                    return true;

                    #region 退款代码 （备用）

                    //门诊挂号撤销
                    YBRequest<GHRefundRequestModel> ghRefund = new YBRequest<GHRefundRequestModel>();
                    ghRefund.infno = ((int)InfoNoEnum.门诊挂号撤销).ToString();

                    ghRefund.msgid = YBHelper.msgid;
                    ghRefund.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                    ghRefund.insuplc_admdvs = "421002";
                    ghRefund.recer_sys_code = YBHelper.recer_sys_code;
                    ghRefund.dev_no = "";
                    ghRefund.dev_safe_info = "";
                    ghRefund.cainfo = "";
                    ghRefund.signtype = "";
                    ghRefund.infver = YBHelper.infver;
                    ghRefund.opter_type = YBHelper.opter_type;
                    ghRefund.opter = SessionHelper.uservm.user_mi;
                    ghRefund.opter_name = SessionHelper.uservm.name;
                    ghRefund.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ghRefund.fixmedins_code = YBHelper.fixmedins_code;
                    ghRefund.fixmedins_name = YBHelper.fixmedins_name;
                    ghRefund.sign_no = YBHelper.msgid;

                    ghRefund.input = new RepModel<GHRefundRequestModel>();
                    ghRefund.input.data = new GHRefundRequestModel();
                    ghRefund.input.data.mdtrt_id = resp.output.data.mdtrt_id.Trim();
                    ghRefund.input.data.psn_no = resp.output.data.psn_no.Trim();
                    ghRefund.input.data.ipt_otp_no = resp.output.data.ipt_otp_no.Trim();

                    json = WebApiHelper.SerializeObject(ghRefund);

                    BusinessID = "2202";
                    Dataxml = json;
                    Outputxml = "";
                    parm = new object[] { BusinessID, json, Outputxml };

                    result = InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                    log.Debug(parm[2]);

                    var refund_resp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                    if (!string.IsNullOrEmpty(refund_resp.err_msg))
                    {
                        MessageBox.Show(refund_resp.err_msg);
                        log.Error(refund_resp.err_msg);
                    }

                    #endregion
                }

                MessageBox.Show("支付失败！");
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
            return false;
        }

        public string GetReceiptMaxNo()
        {
            try
            {

                string paramurl = string.Format($"/api/GuaHao/GetNewReceiptMaxSN");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<string>>(json);

                if (result.status == 1)
                {
                    return result.data;
                }
                else
                {
                    log.Error(result.message);
                    UIMessageBox.ShowError(result.message);

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                UIMessageBox.ShowError(ex.Message);
            }
            return "";
        }


        private void SelectPayType_Load(object sender, EventArgs e)
        {
            lblzje.ForeColor = Color.Red;
            lblyfje.ForeColor = Color.Green;

            //获取实际金额
            GetEffectivePriceByRecordSN();

            lblzje.Text = vm.je;
            lblsyje.Text = vm.je;
            lblyfje.Text = "0.00";


            //this.lbltop.Text = "号已锁定，请在 " + SessionHelper.gh_pay_countdown + " 秒内完成支付提交";
            this.lbltop.ForeColor = Color.Red;
            CountDown();

            ShowMessage();

            BindChequelist();
        }

        public void BindChequelist()
        {
            try
            {
                gbxChequelist.Clear();
                int btnWidth = 120;
                int btnHeight = 60;
                var _ds = SessionHelper.pageChequeCompares.OrderBy(p => p.page_code).ToList();

                for (int i = 0; i < _ds.Count; i++)
                {
                    UISymbolButton btn1 = new UISymbolButton();

                    //btn1.Style = Sunny.UI.UIStyle.Blue;
                    //btn1.StyleCustomMode = true;
                    btn1.Width = btnWidth;
                    btn1.Height = btnHeight;
                    btn1.Text = _ds[i].page_name + "("+ (i+1)+")";
                    btn1.TagString = _ds[i].his_code;
                     
                    if (_ds[i].page_name.Contains("现金"))
                    {
                        btn1.Symbol = 361783;
                    }
                    else if (_ds[i].page_name.Contains("医保"))
                    {
                        btn1.Symbol = 62147;
                    }
                    else if (_ds[i].page_name.Contains("微信"))
                    {
                        btn1.Symbol = 161911;
                    }
                    else if (_ds[i].page_name.Contains("支付宝"))
                    {
                        btn1.Symbol = 163042;
                    }
                    else if (_ds[i].page_name.Contains("银联"))
                    {
                        btn1.Symbol = 161940;
                    }
                    btn1.Font = new Font("微软雅黑", 14, FontStyle.Regular);
                    btn1.Click += ChequeCompare_Click; ;
                    gbxChequelist.Add(btn1);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }


        private void ChequeCompare_Click(object sender, EventArgs e)
        {
            var btn = sender as UISymbolButton;

            if (btn.Text.Contains("微信"))
            {
                OpenPayWindow(PayMethodEnum.WeiXin, btn.TagString);
            }
            else if (btn.Text.Contains("支付宝"))
            {
                OpenPayWindow(PayMethodEnum.Zhifubao, btn.TagString);
            }
            else if (btn.Text.Contains("银联"))
            {
                OpenPayWindow(PayMethodEnum.Yinlian, btn.TagString);
            }
            else if (btn.Text.Contains("医保"))
            {
                if (string.IsNullOrEmpty(vm.yb_ys_code))
                {
                    UIMessageBox.ShowError("医生医保编号为空，不能进行医保支付");
                    return;
                }
                OpenPayWindow(PayMethodEnum.Yibao, btn.TagString);
            }
            else if (btn.Text.Contains("现金"))
            {
                OpenPayWindow(PayMethodEnum.Xianjin, btn.TagString);
            }

        }

        public void GetEffectivePriceByRecordSN()
        {
            var record_sn = vm.record_sn;

            string paramurl = string.Format($"/api/GuaHao/GetChargeItemsByRecordSN?record_sn={record_sn}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                var json = HttpClientUtil.Get(paramurl);

                var dat = WebApiHelper.DeserializeObject<ResponseResult<List<ChargeItemVM>>>(json).data;
                if (dat != null)
                {
                    vm.je = dat.Sum(p => p.effective_price).ToString();
                    chargeItems = dat;
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }


        private void CountDown()
        {

        }

        public void TiJiaoZhifu()
        {
            //判断剩余金额是否为0
            if (Convert.ToDecimal(lblsyje.Text) != 0)
            {
                UIMessageTip.ShowWarning("请选择支付方式并完成支付！", 1500);
                return;
            }

            string pay_string = "";
            foreach (var item in paylist)
            {
                pay_string += "," + item.pay_type + "-" + item.pay_je + "-" + item.out_trade_no + "-" + item.setl_id;
            }

            if (pay_string.Length > 0)
            {
                pay_string = pay_string.Substring(1);
            }
            else
            {
                //处理金额为0的情况
                pay_string = (int)PayMethodEnum.Xianjin + "-0--";
            }
            //MessageBox.Show(pay_string);

            //todo:处理各个支付方式和金额，写入数据库表
            var d = new
            {
                patient_id = patientId,
                record_sn = vm.record_sn,
                pay_string = pay_string,
                opera = SessionHelper.uservm.user_mi
            };

            try
            {

                var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string paramurl = string.Format($"/api/GuaHao/GuaHao?patient_id={patientId}&record_sn={vm.record_sn}&pay_string={pay_string}&max_sn={max_sn}&opera={SessionHelper.uservm.user_mi}");

                log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;

                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(responseJson);

                if (result.status == 1)
                {
                    log.Info("挂号成功");
                    UIMessageTip.ShowOk("挂号成功!", 1500);
                    SessionHelper.do_gh_print = true;

                    SessionHelper.sf_print_user_ledger = result.data;
                    var new_ledger_sn = result.data;


                    if (decimal.Parse(vm.je) == 0)
                    {
                        //支付金额为0，不写电子发票
                        log.Debug("支付金额为0，不写电子发票");
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            //写入电子发票信息
                            CreateElecBill(new_ledger_sn);

                        });
                    }
                    this.Close();
                    return;

                }
                else
                {
                    log.Error(result.message);
                    UIMessageBox.ShowError(result.message);
                    //挂号失败，退款处理
                    Refund();

                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        public void CreateElecBill(int new_ledger_sn)
        {
            try
            {

                string ip = ConfigurationManager.AppSettings["ip"];
                string port = ConfigurationManager.AppSettings["port"];
                string dllName = ConfigurationManager.AppSettings["dllName"];
                string func = ConfigurationManager.AppSettings["func"];

                string noise = Guid.NewGuid().ToString();

                string appid = ConfigurationManager.AppSettings["appid"];
                string key = ConfigurationManager.AppSettings["key"];
                string version = ConfigurationManager.AppSettings["version"];

                string weburl = ConfigurationManager.AppSettings["weburl"];


                string method = "invEBillRegistration";//医疗挂号电子票据开具接口

                string placeCode = ConfigurationManager.AppSettings["placeCode"];//开票点编码

                string busNo = DateTime.Now.Ticks.ToString(); //业务流水号
                string totalAmt = vm.je;

                List<ElectBillChargeItem> chargeItemlist = new List<ElectBillChargeItem>();
                List<ElectBillListDetail> electBillListDetails = new List<ElectBillListDetail>();
                List<PayChannelDetail> payChannelDetails = new List<PayChannelDetail>();

                var init_result = ElecBillHelper.InitCreateElecBillCom(appid, key, weburl, version, ip, port, dllName, func);

                if (!init_result)
                {
                    UIMessageTip.Show("初始化电子发票失败");
                    log.Error("初始化电子发票失败");
                    return;
                }
                //for (int i = 0; i < chargeItems.Count; i++)
                //{
                //    ElectBillChargeItem electBillCharge = new ElectBillChargeItem();
                //    electBillCharge.sortNo = i;
                //    if (chargeItems[i].mz_bill_item == "026")
                //    {
                //        electBillCharge.chargeCode = "90611";//对应挂号费
                //    }
                //    else if (chargeItems[i].mz_bill_item == "018")
                //    {
                //        electBillCharge.chargeCode = "90601";//对应诊查费
                //    }
                //    else
                //    {
                //        electBillCharge.chargeCode = "90611";//对应挂号费
                //    }
                //    electBillCharge.chargeName = chargeItems[i].name.Trim();
                //    electBillCharge.number = 1;
                //    electBillCharge.std = chargeItems[i].effective_price.ToString();
                //    electBillCharge.amt = chargeItems[i].effective_price.ToString();
                //    electBillCharge.selfAmt = chargeItems[i].effective_price.ToString();
                //    electBillCharge.remark = "";

                //    chargeItemlist.Add(electBillCharge);
                //}

                ////var _chargeDetail = new
                ////{
                ////    sortNo = "序号",
                ////    chargeCode = "收费项目代码",
                ////    chargeName = "收费项目名称",
                ////    number = 0,//数量
                ////    std = 0,//收费标准
                ////    amt = 0,//金额
                ////    selfAmt = "0",
                ////    remark = "备注"
                ////};
                ////var _listDetail = new
                ////{
                ////    name = "",//药品名称
                ////    std = "",//单价
                ////    number = "",//数量
                ////    amt = "",//金额
                ////    selfAmt = "", //自费金额
                ////};
                //string _remark = "";
                //for (int i = 0; i < paylist.Count; i++)
                //{
                //    PayChannelDetail payChannelDetail = new PayChannelDetail();
                //    var _payType = SessionHelper.pageChequeCompares.Where(p => p.his_code == paylist[i].pay_type).FirstOrDefault();
                //    if (_payType!=null&& _payType.page_code=="1")
                //    {
                //        //微信
                //        payChannelDetail.payChannelCode = "05"; _remark += ",微信-";
                //    }
                //    else if (_payType != null && _payType.page_code == "2")
                //    {
                //        //支付宝
                //        payChannelDetail.payChannelCode = "05"; _remark += ",支付宝-";
                //    }
                //    else if (_payType != null && _payType.page_code == "3")
                //    {
                //        //银联
                //        payChannelDetail.payChannelCode = "08"; _remark += ",银联-";
                //    }
                //    else if (_payType != null && _payType.page_code == "4")
                //    {
                //        //医保
                //        payChannelDetail.payChannelCode = "11"; _remark += ",医保-";
                //    }
                //    else if (_payType != null && _payType.page_code == "5")
                //    {
                //        //现金
                //        payChannelDetail.payChannelCode = "02"; _remark += ",现金-";
                //    } 

                //    _remark += paylist[i].pay_je.ToString();
                //    payChannelDetail.payChannelValue = paylist[i].pay_je.ToString();
                //    payChannelDetails.Add(payChannelDetail);
                //}
                //if (!string.IsNullOrWhiteSpace(_remark))
                //{
                //    _remark = _remark.Substring(1);
                //}

                //获取数据 ResponseResult<FPRegistration> GetFPRegistrationData(string patient_id, int ledger_sn, int admiss_times)

                //List<ElectBillListDetail> electBillListDetails = new List<ElectBillListDetail>();
                string getDataUrl = string.Format($"/api/mzsf/GetFPRegistrationData?patient_id={patientId}&ledger_sn={new_ledger_sn}&admiss_times={1}");
                log.Debug("getDataUrl：" + getDataUrl);
                var json = HttpClientUtil.Get(getDataUrl);
                log.Debug("获取数据：" + json);
                var result = WebApiHelper.DeserializeObject<ResponseResult<FPRegistrationVM>>(json);
                if (result.status != 1)
                {
                    log.Error(result.message);
                    throw new Exception(result.message);
                }
                var _data = new
                {
                    busNo = result.data.MainData.busNo,             //业务流水号
                    busType = result.data.MainData.busType,         //业务标识
                    payer = result.data.MainData.payer,               //患者姓名
                    busDateTime = result.data.MainData.busDateTime,//业务发生时间
                    placeCode = result.data.MainData.placeCode,//开票点编码
                    payee = result.data.MainData.payee,//收费员
                    author = result.data.MainData.author,//票据编制人
                    checker = result.data.MainData.checker,//票据复核人
                    totalAmt = StringUtil.RoundCharge(result.data.MainData.totalAmt),//开票总金额
                    payerType = result.data.MainData.payerType,//交款人类型 1 个人2单位
                    cardType = result.data.MainData.cardType,//卡类型
                    cardNo = result.data.MainData.cardNo,//卡号
                    age = result.data.MainData.age,
                    sex = result.data.MainData.sex,
                    accountPay = StringUtil.RoundCharge(result.data.MainData.accountPay),//个人账户支付
                    fundPay = StringUtil.RoundCharge(result.data.MainData.fundPay),//医保统筹基金支付
                    otherfundPay = StringUtil.RoundCharge(result.data.MainData.otherfundPay),//其它医保支付
                    ownPay = StringUtil.RoundCharge(result.data.MainData.ownPay),//自费金额
                    selfConceitedAmt = StringUtil.RoundCharge(result.data.MainData.selfConceitedAmt),//个人自负
                    selfPayAmt = StringUtil.RoundCharge(result.data.MainData.selfPayAmt),//个人自付
                    selfCashPay = StringUtil.RoundCharge(result.data.MainData.selfCashPay),//个人现金支付
                    reimbursementAmt = StringUtil.RoundCharge(result.data.MainData.reimbursementAmt),//医保报销总金额
                    payChannelDetail = result.data.PayChannelDetails,//交费渠道列表
                    isArrears = result.data.MainData.isArrears,//是否可流通
                    chargeDetail = result.data.ChargeDetails,
                    listDetail = electBillListDetails,
                    remark = result.data.MainData.remark
                };
                //var _data = new
                //{
                //    busNo = busNo,             //业务流水号
                //    busType = "06",         //业务标识
                //    payer = GuaHao.PatientVM.name.Trim(),               //患者姓名
                //    busDateTime = DateTime.Now.ToString("yyyyMMddHHmmss000"),//业务发生时间
                //    placeCode = placeCode,//开票点编码
                //    payee = SessionHelper.uservm.user_mi,//收费员
                //    author = SessionHelper.uservm.user_mi,//票据编制人
                //    checker = SessionHelper.uservm.user_mi,//票据复核人
                //    totalAmt = totalAmt,//开票总金额
                //    payerType = "1",//交款人类型 1 个人2单位
                //    cardType = "3101",//卡类型
                //    cardNo = GuaHao.PatientVM.patient_id,//卡号
                //    age = GuaHao.PatientVM.age,
                //    sex = GuaHao.PatientVM.sex == "1" ? "男" : "女",
                //    accountPay = "0",//个人账户支付
                //    fundPay = "0",//医保统筹基金支付
                //    otherfundPay = "0",//其它医保支付
                //    ownPay = "0",//自费金额
                //    selfConceitedAmt = "0",//个人自负
                //    selfPayAmt = "0",//个人自付
                //    selfCashPay = totalAmt,//个人现金支付
                //    reimbursementAmt = "0",//医保报销总金额
                //    payChannelDetail = payChannelDetails,//交费渠道列表
                //    isArrears = "1",//是否可流通
                //    chargeDetail = chargeItemlist,
                //    listDetail = electBillListDetails,
                //    remark = _remark
                //};
                // log.Debug("_data:" + _data);
                var stringA = $"appid={appid}&data={StringUtil.Base64Encode(JsonConvert.SerializeObject(_data))}&noise={noise}";

                //log.Debug("stringA:" + stringA);
                var stringSignTemp = stringA + $"&key={key}&version={version}";

                //log.Debug("stringSignTemp:" + stringSignTemp);

                var _sign = StringUtil.GenerateMD5(stringSignTemp).ToUpper();

                var _params = new
                {
                    appid = appid,
                    data = StringUtil.Base64Encode(JsonConvert.SerializeObject(_data)),
                    noise = noise,
                    version = version,
                    sign = _sign
                };

                var _payload = new
                {
                    method = method,
                    @params = _params
                };
                string payload = StringUtil.Base64Encode(JsonConvert.SerializeObject(_payload));
                string url = $"http://{ip}:{port}/extend?dllName={dllName}&func={func}&payload={payload}";

                log.Debug(url);
                json = HttpClientUtil.Get(url);

                var response = WebApiHelper.DeserializeObject<ElectBillCommonResponse>(json);

                if (response.data != null)
                {
                    var addbill_resp = StringUtil.Base64Decode(response.data);

                    var _resp = WebApiHelper.DeserializeObject<ElectBillAddResponse>(addbill_resp);
                    var _fpdata = StringUtil.Base64Decode(_resp.message);
                    if (_resp.result == "S0000")
                    {
                        //成功
                        var _entity = WebApiHelper.DeserializeObject<FpData>(_fpdata);
                        //写入电子发票数据到数据库
                        var d = new
                        {
                            patientId = patientId,
                            ledger_sn = new_ledger_sn,
                            billBatchCode = _entity.billBatchCode,
                            billNo = _entity.billNo,
                            random = _entity.random,
                            createTime = _entity.createTime,
                            billQRCode = _entity.billQRCode,
                            pictureUrl = _entity.pictureUrl,
                            pictureNetUrl = _entity.pictureNetUrl,
                            subsys_id = "mz",
                        };

                        string paramurl = string.Format($"/api/mzsf/AddFpData?patient_id={d.patientId}&ledger_sn={d.ledger_sn}&billBatchCode={d.billBatchCode}&billNo={d.billNo}&random={d.random}&createTime={d.createTime}&billQRCode={d.billQRCode}&pictureUrl={d.pictureUrl}&pictureNetUrl={d.pictureNetUrl}&subsys_id={d.subsys_id}");
                        var _addresult = HttpClientUtil.Get(paramurl);
                    }
                    else
                    {
                        UIMessageTip.ShowError(_fpdata);
                    }
                }
                else
                {
                    UIMessageBox.ShowError("生成电子发票失败,参考日志信息");
                    log.Error(json);
                }

            }
            catch (Exception ex)
            {
                string ermsg = ex.ToString();
                if (ermsg.IndexOf("无法连接") > -1)
                {
                    UIMessageBox.ShowError("生成电子发票失败，请检查财政票据客户端是否运行中");
                }
                else
                {
                    UIMessageBox.ShowError("生成电子发票失败,参考日志信息");
                }
                log.Error(ex.ToString());
            }

        }



        public string FormID { get; set; } = "PRDT"; //单据ID
                                                     //private string RptNo, RptName; //报表编号、名称
                                                     //private DataTable RptTable; //数据表
                                                     //private DataRow RptRow; //数据行(报表数据源)
        private bool isSaveAs = false; //另存为

        ReportDataVM rdvm;
        //初始化报表
        private void InitializeReport(string RptMode)
        {
            //string sql = "select * from rt_report_data_fast_net where report_code = 220001";
            //DataSet Ds = DbHelper.GetDataSet(sql, "REPORT");

            var paramurl = string.Format($"/api/GuaHao/GetReportDataByCode?code={SessionHelper.mzgh_report_code}");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

            var json = HttpClientUtil.Get(paramurl);

            var resp = WebApiHelper.DeserializeObject<ResponseResult<ReportDataVM>>(json);

            if (resp.status == 1)
            {
                rdvm = resp.data;
            }
            else
            {
                MessageBox.Show(resp.message);
                log.Error(resp.message);
                return;
            }
            //DataSet Ds = resp.data;

            //RptTable = Ds.Tables[0];
            //RptRow = RptTable.Rows[0];
            RegisterDesignerEvents();
            DesignReport(RptMode);
        }
        //菜单事件注册
        private void RegisterDesignerEvents()
        {
            Config.DesignerSettings.CustomSaveDialog += new OpenSaveDialogEventHandler(DesignerSettings_CustomSaveDialog);
            Config.DesignerSettings.CustomSaveReport += new OpenSaveReportEventHandler(DesignerSettings_CustomSaveReport);
        }
        //保存菜单：对话框
        private void DesignerSettings_CustomSaveDialog(object sender, OpenSaveDialogEventArgs e)
        {
            isSaveAs = true;
        }
        //保存菜单：委托函数
        private void DesignerSettings_CustomSaveReport(object sender, OpenSaveReportEventArgs e)
        {
            //SaveReport(e.Report);
            using (MemoryStream stream = new MemoryStream())
            {
                //解决多次保存问题
                Config.DesignerSettings.CustomSaveDialog -= new OpenSaveDialogEventHandler(DesignerSettings_CustomSaveDialog);
                Config.DesignerSettings.CustomSaveReport -= new OpenSaveReportEventHandler(DesignerSettings_CustomSaveReport);

                //保存 
                TargetReport.Save(stream);

                #region sql直连
                //string sql = @"update rt_report_data_fast_net set report_com=? where report_code = 220001";
                //var para = new System.Data.OleDb.OleDbParameter[1];
                //para[0] = new System.Data.OleDb.OleDbParameter("p1", stream.ToArray());
                //var result = DbHelper.ExecuteNonQuery(sql, para);
                #endregion

                #region 接口方式

                var report_data = System.Text.Encoding.UTF8.GetString(stream.ToArray());

                string paramurl = string.Format($"/api/GuaHao/UpdateReportDataByCode?code={SessionHelper.mzgh_report_code}&report_com={report_data}");

                log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(responseJson);

                if (result.status == 1)
                {
                    log.Info("保存报表成功");
                }
                else
                {
                    log.Error(result.message);
                }
                #endregion

            }
        }
        Report TargetReport;
        private void DesignReport(string RptMode)
        {
            try
            {

                TargetReport = new Report();

                TargetReport.FileName = RptMode;
                // if (RptRow["report_com"].ToString().Length > 0)
                if (rdvm != null && rdvm.report_com.Length > 0)
                {
                    //byte[] ReportBytes = (byte[])RptRow["report_com"];
                    byte[] ReportBytes = System.Text.Encoding.UTF8.GetBytes(rdvm.report_com);
                    string sql = rdvm.report_sql;
                    using (MemoryStream Stream = new MemoryStream(ReportBytes))
                    {
                        TargetReport.Load(Stream);

                        #region sql语句直连方式
                        ////查询参数
                        //string param_sql = "select * from  rt_report_params_fast_net where report_code = 220001";
                        //var dt_param = DbHelper.ExecuteDataTable(param_sql);
                        //if (dt_param != null && dt_param.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < dt_param.Rows.Count; i++)
                        //    {
                        //        sql = sql.Replace(":" + dt_param.Rows[i]["param_name"].ToString(), "'" + GuaHao.PatientVM.patient_id + "'");
                        //    }
                        //}
                        //var ds = DbHelper.GetDataSet(sql, "ghinfo");

                        //TargetReport.RegisterData(ds);
                        #endregion


                        #region 接口方式
                        //查询数据 
                        string paramurl = string.Format($"/api/GuaHao/GetReportParam?code={SessionHelper.mzgh_report_code}");

                        log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                        var result = WebApiHelper.DeserializeObject<ResponseResult<List<ReportParamVM>>>(responseJson);
                        if (result.status == 1)
                        {
                            foreach (var item in result.data)
                            {
                                if (item.param_name == "patient_id")
                                {
                                    sql = sql.Replace(":" + item.param_name, "'" + GuaHao.PatientVM.patient_id + "'");
                                }
                                //else if (item.param_name == "times")
                                //{
                                //    sql = sql.Replace(":" + item.param_name, "'" + item.param_defaultvalue + "'");
                                //}

                            }
                        }
                        paramurl = string.Format($"/api/GuaHao/GetReportDataBySql?sql={sql}&tb_name={"ghinfo"}");

                        //log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                        var ds_result = WebApiHelper.DeserializeObject<ResponseResult<string>>(responseJson);
                        if (ds_result.status == 1)
                        {
                            var jsontb = ds_result.data;
                            var dt = DataTableHelper.ToDataTable(jsontb);
                            var dataset = new DataSet();
                            dataset.Tables.Add(dt);
                            dataset.Tables[0].TableName = "ghinfo";
                            TargetReport.RegisterData(dataset);
                        }
                        #endregion
                    }
                }
                //操作方式：DESIGN-设计;PREVIEW-预览;PRINT-打印
                if (RptMode == "DESIGN")
                {
                    TargetReport.Design();
                }
                else if (RptMode == "PREVIEW")
                {
                    TargetReport.Prepare();
                    TargetReport.ShowPrepared();
                }
                else if (RptMode == "PRINT")
                {
                    TargetReport.Print();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        /// <summary>
        /// fastreport打印
        /// </summary>
        /// <returns></returns>
        public Report CreateReportAndLoadFrx(string pay_string)
        {
            Report report = new Report();

            report.Load(Application.StartupPath + @"\FastReport\file\gh_pay.frx");//这里是模板的路径 

            report.SetParameterValue("pid", GuaHao.PatientVM.patient_id);
            report.SetParameterValue("record_sn", vm.record_sn);


            //处理多重支付
            var pay_method_arr = pay_string.Split(',');
            var result = "";

            foreach (var pay_method in pay_method_arr)
            {
                var pay_detail = pay_method.Split('-');
                var cheque_type = pay_detail[0];
                var charge = decimal.Parse(pay_detail[1]);
                var out_trade_no = pay_detail[2];//订单编号

                result += "支付方式：" + PayMethod.GetPayStringByEnumValue(cheque_type) + "，金额： " + charge + "元" + "\r\n";
            }
            report.SetParameterValue("paystr", result);

            List<string> list = new List<string>();
            list.Add("aaaa");
            list.Add("bbbb");
            list.Add("cccc");
            list.Add("dddd");

            report.SetParameterValue("dat", list);
            return report;
        }

        string printPaystr = "";
        public void Print(string paystring, int type = 1)
        {
            printPaystr = paystring;
            //打印预览            
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            //设置边距
            Margins margin = new Margins(10, 10, 10, 10);
            pd.DefaultPageSettings.Margins = margin;
            int height = 300;

            //纸张设置默认
            PaperSize pageSize = new PaperSize("First custom size", (int)(58 * 100 / 25.4), height);//58mm   转绘图宽度
                                                                                                    //PaperSize pageSize = new PaperSize("First custom size", 300,400);//58mm   转绘图宽度
            pd.DefaultPageSettings.PaperSize = pageSize;
            //打印事件设置            
            if (type == 1)
            {
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            }
            else if (type == 2)
            {
                pd.PrintPage += new PrintPageEventHandler(yy_PrintPage);
            }
            ppd.Document = pd;
            ppd.ShowDialog();
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
            }

        }

        /// <summary>
        /// 患者打印内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            ComboPrintContent(e, 1);
        }

        /// <summary>
        /// 医院打印内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yy_PrintPage(object sender, PrintPageEventArgs e)
        {

            ComboPrintContent(e, 2);
        }

        public void ComboPrintContent(PrintPageEventArgs e, int type = 1)
        {
            Font font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

            int yLocation = e.MarginBounds.Y;
            int center = e.PageSettings.PaperSize.Width / 2;
            int heightStep = 0;

            //打印标题 
            string title = "挂号收费明细";
            SizeF size = e.Graphics.MeasureString(title, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(title, font, System.Drawing.Brushes.Black, center - size.Width / 2, yLocation);
            yLocation += heightStep;

            yLocation += 5;

            //患者信息
            font = new Font("Arial", 6, System.Drawing.FontStyle.Bold);
            var ptext = "卡号：" + GuaHao.PatientVM.patient_id;
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;
            ptext = "姓名：" + GuaHao.PatientVM.name.Trim() + "  年龄：" + GuaHao.PatientVM.age;
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;



            //挂号信息（时间，科室，号类，医生，序号）
            font = new Font("Arial", 6, System.Drawing.FontStyle.Bold);
            ptext = "时间：" + vm.request_date.ToShortDateString() + " " + (vm.ap == "a" ? "上午" : "下午");
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;

            ptext = vm.unit_name + " " + vm.group_name;
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;

            ptext = vm.clinic_name + " " + vm.doctor_name;
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;


            //打印收费项目
            font = new Font("Arial", 6, System.Drawing.FontStyle.Bold);
            ptext = "收费项目" + "(总计" + chargeItems.Sum(p => p.effective_price) + ")";
            //ptext = "收费项目";
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;

            foreach (var item in chargeItems)
            {
                //打印支付内容
                font = new Font("Arial", 6, System.Drawing.FontStyle.Regular);
                string payitem = "项目" + item.item_no + ":" + item.name.Trim() + "，金额:" + item.effective_price + "元";
                size = e.Graphics.MeasureString(payitem, font);
                heightStep = Convert.ToInt32(size.Height * 1.3);
                e.Graphics.DrawString(payitem, font, System.Drawing.Brushes.Black, 10, yLocation);
                yLocation += heightStep;
            }

            yLocation += 5;

            font = new Font("Arial", 6, System.Drawing.FontStyle.Bold);
            ptext = "支付信息" + "(总计：" + vm.je + ")";
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;

            //处理多重支付
            var pay_method_arr = printPaystr.Split(',');

            foreach (var pay_method in pay_method_arr)
            {
                var pay_detail = pay_method.Split('-');
                var cheque_type = pay_detail[0];
                var charge = decimal.Parse(pay_detail[1]);
                var out_trade_no = pay_detail[2];//订单编号

                //打印支付内容
                font = new Font("Arial", 6, System.Drawing.FontStyle.Regular);
                string payitem = "支付方式：" + PayMethod.GetPayStringByEnumValue(cheque_type) + "，金额： " + charge + "元";
                size = e.Graphics.MeasureString(payitem, font);
                heightStep = Convert.ToInt32(size.Height * 1.3);
                e.Graphics.DrawString(payitem, font, System.Drawing.Brushes.Black, 10, yLocation);
                yLocation += heightStep;
            }
            yLocation += 5;
            font = new Font("Arial", 6, System.Drawing.FontStyle.Regular);
            ptext = "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;

            if (type == 1)
            {
                ptext = "患者存单";
            }
            else if (type == 2)
            {
                ptext = "医院存单";
            }
            font = new Font("Arial", 6, System.Drawing.FontStyle.Bold);
            size = e.Graphics.MeasureString(ptext, font);
            heightStep = Convert.ToInt32(size.Height * 1.3);
            e.Graphics.DrawString(ptext, font, System.Drawing.Brushes.Black, 10, yLocation);
            yLocation += heightStep;

        }

        private void btnSubmitCombi_Click(object sender, EventArgs e)
        {
            log.Info("提交支付");

            TiJiaoZhifu();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {

            Buquan("wx");
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            Buquan("zfb");
        }
        public bool Buquan(string type)
        {
            try
            {

                if (string.IsNullOrEmpty(vm.je))
                {
                    return true;
                }
                var je = Convert.ToDecimal(vm.je);

            }

            catch (Exception ex)
            {
                UIMessageTip.ShowError("金额组合不正确!");

            }
            return true;
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            Buquan("yl");
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            Buquan("xj");
        }
        private void btnAdd5_Click(object sender, EventArgs e)
        {
            Buquan("ybk");
        }

        /// <summary>
        /// 屏蔽数字textbox的其他字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void tBoxNumbers_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.Back:
                case Keys.OemPeriod:
                case Keys.Delete:
                case Keys.Decimal:
                    e.SuppressKeyPress = false;
                    break;
                default:
                    break;
            }
        }

        public virtual void tBoxNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tBox = sender as UITextBox;
            char c = e.KeyChar;

            if (c.ToString().Equals("."))
            {
                if (tBox.Text.Length <= 0 || tBox.Text.IndexOf(".") > 0)
                    e.Handled = true;           //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(tBox.Text, out oldf);
                    b2 = float.TryParse(tBox.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        /// <summary>
        /// 屏蔽数字textbox的其他字符串
        /// </summary>
        /// <param name="tbox">要屏蔽的textbox</param>
        public virtual void ShieldNumberTextBoxOtherKeys(UITextBox tbox)
        {
            tbox.ImeMode = ImeMode.Disable;
            tbox.KeyDown += tBoxNumbers_KeyDown;
            tbox.KeyPress += tBoxNumbers_KeyPress;
        }


        private void txtje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;

            }
        }

        private void uiPanel3_Click(object sender, EventArgs e)
        {

        }


        private void txtybk_Leave(object sender, EventArgs e)
        {
            var ui = sender as UITextBox;
            if (string.IsNullOrEmpty(ui.Text))
            {
                ui.Text = "0";
            }
        }

        public void Tuikuan()
        {
            //微信订单号
            var transaction_id = "";
            //和商户订单号
            var out_trade_no = "";
            //订单总金额
            var total_fee = "0";
            //退款金额
            var refund_fee = "0";
            //微信订单号(transaction_id)和商户订单号至少填一个
            // string result = WxPayAPI.Refund.Run(transaction_id.Text, out_trade_no.Text, total_fee.Text, refund_fee.Text);
        }

        private void btnzfb_Click(object sender, EventArgs e)
        {

            //OpenPayWindow(PayMethodEnum.Zhifubao);
        }

        private void btnyl_Click(object sender, EventArgs e)
        {
            // OpenPayWindow(PayMethodEnum.Yinlian);
        }

        private void btnybk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(vm.doctor_name))
            {
                MessageBox.Show("医生名称为空，不能选择医保支付！");
                return;
            }

            // OpenPayWindow(PayMethodEnum.Yibao);
        }

        private void btnxj_Click(object sender, EventArgs e)
        {
            //OpenPayWindow(PayMethodEnum.Xianjin);


        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblmsg.ForeColor == Color.Green)
            {
                lblmsg.ForeColor = Color.Red;
            }
            else if (lblmsg.ForeColor == Color.Red)
            {
                lblmsg.ForeColor = Color.Green;
            }

        }

        private void SelectPayType_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Dispose();
        }

        private void chkcomb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkcomb_Click(object sender, EventArgs e)
        {
            if (!chkcomb.Checked && paylist.Count > 0)
            {
                UIMessageTip.ShowWarning("存在支付记录！");
                chkcomb.Checked = true;
            }
        }



        #region 医保组件调用

        [DllImport("ole32.dll")]
        static extern int CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid pclsid);

        public static object InvokeMethod(string comName, string methodName, ref object[] args)
        {

            object ret = null;
            COMInfo com = GetCOMInfo(comName);
            try
            {
                //用参数的索引属性来指出哪些参数是一个返回的参数
                //对于那些是[in]或ByRef的参数可以不用指定
                ParameterModifier[] ParamMods = new ParameterModifier[1];
                ParamMods[0] = new ParameterModifier(3); // 初始化为接口参数的个数
                ParamMods[0][2] = true; // 设置第三个参数为返回参数


                ret = com.COMType.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, com.Instance, args, ParamMods,
                                                         null,
                                                         null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


        public static COMInfo GetCOMInfo(string comName)
        {
            COMInfo comInfo;
            Type type;
            object instance = null;
            instance = CreateInstance(comName, out type);
            comInfo = new COMInfo(type, instance);
            return comInfo;
        }


        private static object CreateInstance(string progName, out Type type)
        {
            object instance = null;
            type = null;
            try
            {
                Guid clsid;
                int result = CLSIDFromProgID(progName, out clsid);
                type = Type.GetTypeFromCLSID(clsid, true);
                instance = Activator.CreateInstance(type);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return instance;
        }

        #endregion

        private void btnTuikuan_Click(object sender, EventArgs e)
        {
            if (uiListBox1.SelectedIndex == -1)
            {
                uiListBox1.SelectedIndex = 0;
            }

            var index = uiListBox1.SelectedIndex;
            if (index == -1)
            {
                //   MessageBox.Show("请选择付款项目进行退款操作！"); return;
            }
            if (MessageBox.Show(uiListBox1.SelectedItem.ToString(), "是否确认退款？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //退款
                RefundType(paylist[index]);

                uiListBox1.Items.Remove(uiListBox1.SelectedItem);
                //总金额-支付金额
                lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) - paylist[index].pay_je).ToString();
                lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();
                paylist.RemoveAt(index);
                ShowMessage();

                //uiListBox2.Items.Clear();
                //if (paylist != null && paylist.Count > 0)
                //{ 
                //    foreach (var item in paylist)
                //    {
                //        uiListBox2.Items.Add("支付方式：" + item.pay_type + "，金额： " + item.pay_je);
                //    }
                //}
            }
        }

        public void UpdateThirdPayStatus(string patient_id, string cheque_type, string cheque_no, string charge)
        {
            try
            {
                string paramurl = string.Format($"/api/mzsf/RefundMzThridPay?patient_id={patient_id}&cheque_type={cheque_type}&cheque_no={cheque_no}&charge={charge}&price_date=");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var json = HttpClientUtil.Get(paramurl);


                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);
                if (result.status == 1)
                {
                    UIMessageTip.Show("退费成功");
                }
                else
                {
                    UIMessageTip.Show(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }

        }

        public void AddMzThridPay(string payMethod, string out_trade_no, string mdtrt_id, string setl_id, string ipt_otp_no, string psn_no, string yb_insuplc_admdvs, decimal charge)
        {
            try
            {
                var _pid = SessionHelper.patientVM.patient_id;
                var _cheque_type = payMethod;
                var _cheque_no = out_trade_no;
                var _mdtrt_id = mdtrt_id;
                var _setl_id = setl_id;
                var _ipt_otp_no = ipt_otp_no;
                var _psn_no = psn_no;
                var _yb_insuplc_admdvs = yb_insuplc_admdvs;
                var _price_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var _charge = charge;
                var _opera = SessionHelper.uservm.user_mi;
                string paramurl = string.Format($"/api/mzsf/AddMzThridPay?patient_id={_pid}&cheque_type={_cheque_type}&cheque_no={_cheque_no}&mdtrt_id={_mdtrt_id}&setl_id={setl_id}&ipt_otp_no={_ipt_otp_no}&psn_no={_psn_no}&yb_insuplc_admdvs={_yb_insuplc_admdvs}&charge={_charge}&price_date={_price_date}&opera={_opera}");
                HttpClientUtil.Get(paramurl);
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void SelectPayType_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void SelectPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //提交
                log.Info("提交支付");

                TiJiaoZhifu();
            }
            else if (e.KeyCode == Keys.NumPad1 || e.KeyValue == 49)
            {
                //子控件从第4位开始
                var _cts = gbxChequelist.GetAllControls();
                if (_cts.Count > 3)
                {
                    ChequeCompare_Click(_cts[3], e);
                }
            }
            else if (e.KeyCode == Keys.NumPad2 || e.KeyValue == 50)
            {
                var _cts = gbxChequelist.GetAllControls();
                if (_cts.Count > 4)
                {
                    ChequeCompare_Click(_cts[4], e);
                }
            }
            else if (e.KeyCode == Keys.NumPad3 || e.KeyValue == 51)
            {
                var _cts = gbxChequelist.GetAllControls();
                if (_cts.Count > 5)
                {
                    ChequeCompare_Click(_cts[5], e);
                }
            }
            else if (e.KeyCode == Keys.NumPad4 || e.KeyValue == 52)
            {
                var _cts = gbxChequelist.GetAllControls();
                if (_cts.Count > 6)
                {
                    ChequeCompare_Click(_cts[6], e);
                }
            }
            else if (e.KeyCode == Keys.NumPad5 || e.KeyValue == 53)
            {
                var _cts = gbxChequelist.GetAllControls();
                if (_cts.Count > 7)
                {
                    ChequeCompare_Click(_cts[7], e);
                }
            }
        }
    }
}
