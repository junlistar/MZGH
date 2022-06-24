using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Mzsf.ClassLib;
using Mzsf.ViewModel;
using Sunny.UI;

namespace Mzsf.Forms.Pages
{
    public partial class Check : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(Check));//typeof放当前类

        List<GHPayModel> paylist = new List<GHPayModel>();
        //List<ChargeItemVM> chargeItems = new List<ChargeItemVM>();

        decimal total_charge = 0;
        public int times = 0;

        public Check()
        {
            InitializeComponent();
        }

        private void Check_Load(object sender, EventArgs e)
        {
            dgvzd.Init();
            dgvfk.Init();
            total_charge = Math.Round(SessionHelper.cprCharges.Sum(p => p.total_price), 2);

            lblZongji.Text = total_charge.ToString();
            lblzje.Text = total_charge.ToString();
            lblsyje.Text = total_charge.ToString();
            lblYouhui.Text = "0.00";

            lblfpzje.Text = total_charge.ToString();
            lblfpje.Text = total_charge.ToString();


            //绑定发票数据
            BindChargeData();
        }

        private void BindChargeData()
        {
            var orders = SessionHelper.mzOrders;
            var charges = SessionHelper.cprCharges;

            List<SFChargeVM> list = new List<SFChargeVM>();

            var dat = orders.GroupBy(p => new { p.order_type, p.order_typename }).Select(g => g.First()).ToList();

            foreach (var item in dat)
            {
                var model = new SFChargeVM();
                model.type_name = item.order_typename;
                model.type = item.order_type;
                list.Add(model);
            }

            foreach (var item in list)
            {
                item.charge = Math.Round(charges.Where(p => p.order_type == item.type).Sum(p => p.charge_amount * p.charge_price), 2);
            }

            dgvzd.DataSource = list;
            dgvzd.ShowGridLine = true;




        }

        public void OpenPayWindow(PayMethodEnum payMethod)
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


                WxPay wxPay = new WxPay(((int)payMethod).ToString(), left_je.ToString(), out_trade_no);
                wxPay.ShowDialog();
                if (wxPay.DialogResult == DialogResult.OK)
                {
                    log.Info("完成支付：" + (int)payMethod + ",金额：" + left_je);
                    //保存支付数据，用于退款
                    paylist.Add(new GHPayModel((int)payMethod, (decimal)left_je, out_trade_no));

                }
                else
                {
                    log.Info("取消支付：" + (int)PayMethodEnum.Zhifubao + ",金额：" + left_je);

                }

            }
            else if (payMethod == PayMethodEnum.Yinlian)
            {
                CardPay card = new CardPay(((int)payMethod).ToString(), left_je.ToString());
                card.ShowDialog();
                if (card.DialogResult == DialogResult.OK)
                {
                    log.Info("完成支付：" + (int)payMethod + ",金额：" + left_je);
                    //保存支付数据，用于退款
                    paylist.Add(new GHPayModel((int)payMethod, (decimal)left_je));
                     
                }
                else
                {
                    log.Info("取消支付：" + (int)payMethod + ",金额：" + left_je);


                }
            }
            else if (payMethod == PayMethodEnum.Yibao)
            {
                //刷医保卡，再挂号 
                if (YiBaoPay())
                {
                    log.Info("完成支付：" + (int)payMethod + ",金额：" + left_je);
                    //保存支付数据，用于退款
                    paylist.Add(new GHPayModel((int)payMethod, (decimal)left_je, YBHelper.currentYBPay.output.data.mdtrt_id));
                     
                }
                else
                {
                    log.Info("支付失败：" + (int)payMethod + ",金额：" + left_je);
                }
            }
            else if (payMethod == PayMethodEnum.Xianjin)
            {
                JKZL xjzf = new JKZL(((int)payMethod).ToString(), left_je.ToString());
                if (chkcomb.Checked)
                {
                    xjzf.lbl1.Text = "本次支付:";
                }

                xjzf.ShowDialog();
                if (xjzf.DialogResult == DialogResult.OK)
                {
                    log.Info("完成支付：" + (int)payMethod + ",金额：" + left_je);
                    //保存支付数据，用于退款
                    paylist.Add(new GHPayModel((int)payMethod, (decimal)left_je));
                     
                }
                else
                {
                    log.Info("取消支付：" + (int)payMethod + ",金额：" + left_je);

                }
            }
            else
            {
                log.Info("其他支付：" + (int)payMethod + ",金额：" + left_je);
                //其他支付
                UIMessageTip.ShowOk("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + ",金额：" + left_je);
            }


            this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

            //总金额-支付金额
            lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
            lblsyje.Text = (total_charge - Convert.ToDecimal(lblyfje.Text)).ToString();

            //发票tab，数据更新
            BindReceiptData();


            if (chkcomb.Checked)
            {
                //ShowMessage();
            }
            else
            {

                ////单个支付，支付完成，自动提交
                //var sy_je = Convert.ToDouble(lblsyje.Text);
                //if (sy_je == 0)
                //{
                //    TiJiaoZhifu();
                //}
            }
        }

        private void BindReceiptData()
        {
            var dgv_data = paylist.Select(p => new
            {
                pay_type_name = p.type_name,
                pay_je = p.pay_je
            }).ToList();
            dgvfk.DataSource = dgv_data;
            dgvfk.ShowGridLine = true;
        }

        public bool YiBaoPay()
        {
            try
            {
                string json = "";
                string BusinessID = "1101";
                string Dataxml = json;
                string Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                if (string.IsNullOrEmpty(SessionHelper.PatientVM.yb_insuplc_admdvs) || string.IsNullOrEmpty(SessionHelper.PatientVM.hic_no)
                   || string.IsNullOrEmpty(SessionHelper.PatientVM.yb_insutype) || string.IsNullOrEmpty(SessionHelper.PatientVM.yb_psn_no))
                {
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
                    BusinessID = "1101";
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
                        SessionHelper.cardno = yBResponse.output.baseinfo.certno;

                        if (yBResponse.output.baseinfo.certno != SessionHelper.PatientVM.hic_no)
                        {
                            //如果号码不一致，提示返回
                            MessageBox.Show("医保卡与患者身份不一致！");
                            return false;
                        }

                        YBHelper.currentYBInfo = yBResponse;

                        SessionHelper.PatientVM.yb_insuplc_admdvs = yBResponse.output.insuinfo[0].insuplc_admdvs;
                        SessionHelper.PatientVM.yb_insutype = yBResponse.output.insuinfo[0].insutype;
                        SessionHelper.PatientVM.yb_psn_no = yBResponse.output.baseinfo.psn_no;

                        //保存用户的医保信息
                        var d = new
                        {
                            yb_psn_no = yBResponse.output.baseinfo.psn_no,
                            social_no = yBResponse.output.baseinfo.certno,
                            pid = SessionHelper.PatientVM.patient_id,
                            yb_insuplc_admdvs = yBResponse.output.insuinfo[0].insuplc_admdvs,
                            yb_insutype = yBResponse.output.insuinfo[0].insutype,
                            opera = SessionHelper.uservm.user_mi
                        };
                        var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        var paramurl = string.Format($"/api/GuaHao/UpdateUserYBInfo?pid={d.pid}&social_no={d.social_no}&yb_psn_no={d.yb_psn_no}&yb_insutype={d.yb_insutype}&yb_insuplc_admdvs={d.yb_insuplc_admdvs}");

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

                }
                //todo:医保支付

                ////机制号
                //var sn_no = GetReceiptMaxNo();
                //max_sn = int.Parse(sn_no);

                ////门诊挂号
                //YBRequest<GHRequestModel> ghRequest = new YBRequest<GHRequestModel>();
                //ghRequest.infno = ((int)InfoNoEnum.门诊挂号).ToString();

                //ghRequest.msgid = YBHelper.msgid;
                //ghRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                //ghRequest.insuplc_admdvs = SessionHelper.PatientVM.yb_insuplc_admdvs.Trim();
                //ghRequest.recer_sys_code = YBHelper.recer_sys_code;
                //ghRequest.dev_no = "";
                //ghRequest.dev_safe_info = "";
                //ghRequest.cainfo = "";
                //ghRequest.signtype = "";
                //ghRequest.infver = YBHelper.infver;
                //ghRequest.opter_type = YBHelper.opter_type;
                //ghRequest.opter = SessionHelper.uservm.user_mi;
                //ghRequest.opter_name = SessionHelper.uservm.name;
                //ghRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //ghRequest.fixmedins_code = YBHelper.fixmedins_code;
                //ghRequest.fixmedins_name = YBHelper.fixmedins_name;
                //ghRequest.sign_no = YBHelper.msgid;

                //ghRequest.input = new RepModel<GHRequestModel>();
                //ghRequest.input.data = new GHRequestModel();

                //ghRequest.input.data.psn_no = SessionHelper.PatientVM.yb_psn_no.Trim();
                //ghRequest.input.data.insutype = SessionHelper.PatientVM.yb_insutype.Trim();

                //ghRequest.input.data.begntime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ////ghRequest.input.data.mdtrt_cert_type = yBResponse.output.baseinfo.psn_cert_type;
                ////ghRequest.input.data.mdtrt_cert_no = yBResponse.output.baseinfo.certno;
                //ghRequest.input.data.mdtrt_cert_type = "02";//身份证
                //ghRequest.input.data.mdtrt_cert_no = SessionHelper.PatientVM.hic_no;

                //ghRequest.input.data.ipt_otp_no = sn_no; //机制号 唯一" ipt_otp_no": "1533956",
                //ghRequest.input.data.atddr_no = "D421003007628"; //医生医保编号 "atddr_no": "D421003007628",
                //ghRequest.input.data.dr_name = vm.doctor_name;
                //ghRequest.input.data.dept_code = vm.unit_name;
                //ghRequest.input.data.dept_name = vm.unit_name;
                //ghRequest.input.data.caty = vm.clinic_name;

                //json = WebApiHelper.SerializeObject(ghRequest);

                //BusinessID = "2201";
                //Dataxml = json;
                //Outputxml = "";
                //parm = new object[] { BusinessID, json, Outputxml };

                //var result = InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                //log.Debug(parm[2]);

                //var resp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                //if (!string.IsNullOrEmpty(resp.err_msg))
                //{
                //    MessageBox.Show(resp.err_msg);
                //    log.Error(resp.err_msg);
                //}
                //else if (resp.output != null && !string.IsNullOrEmpty(resp.output.data.mdtrt_id))
                //{
                //    //MessageBox.Show(resp.output.data.mdtrt_id);

                //    //保存医保支付信息，用于退款
                //    YBHelper.currentYBPay = resp;
                //    //就诊ID 医保返回唯一流水
                //    string mdtrt_id = resp.output.data.mdtrt_id;
                //    //人员编号
                //    string psn_no = resp.output.data.psn_no;
                //    //住院/门诊号
                //    string ipt_otp_no = resp.output.data.ipt_otp_no;


                //    return true; 
                //}

                //MessageBox.Show("支付失败！");

                return true;
            }
            catch (Exception ex)
            {
                log.Error("请求接口数据出错：" + ex.Message);
            }
            return false;
        }
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

        public string GetReceiptMaxNo()
        {
            try
            {

                string paramurl = string.Format($"/api/mzsf/GetNewReceiptMaxSN");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var task = SessionHelper.MyHttpClient.GetAsync(paramurl);
                var json = "";
                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }

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

            log.Info("处理退款:" + item.pay_type + ",金额：" + item.pay_je);
            switch (item.pay_type)
            {
                case (int)PayMethodEnum.Xianjin:
                    UIMessageBox.ShowInfo("处理现金退款,金额：" + item.pay_je);
                    //UIMessageTip.ShowOk("处理现金退款,金额：" + item.pay_je); Thread.Sleep(1000);
                    break;
                case (int)PayMethodEnum.WeiXin:

                    //var transaction_id = "";
                    //var out_trade_no = "";
                    //var total_fee = "";
                    //var redfund_fee = "";

                    //var wx_response = WxPayAPI.Refund.Run(transaction_id, out_trade_no, total_fee, redfund_fee);
                    //log.Info("微信退款返回字符串：" + wx_response);


                    UIMessageBox.ShowInfo("处理微信退款,金额：" + item.pay_je);
                    //UIMessageTip.ShowOk("处理微信退款,金额：" + item.pay_je); Thread.Sleep(1000);
                    break;
                case (int)PayMethodEnum.Yibao:
                    UIMessageBox.ShowInfo("处理医保退款,金额：" + item.pay_je);

                    if (YBRefund())
                    {

                    }

                    //UIMessageTip.ShowOk("处理医保退款,金额：" + item.pay_je); Thread.Sleep(1000);
                    break;
                case (int)PayMethodEnum.Yinlian:
                    UIMessageBox.ShowInfo("处理银联退款,金额：" + item.pay_je);
                    //UIMessageTip.ShowOk("处理银联退款,金额：" + item.pay_je); Thread.Sleep(1000);
                    break;
                case (int)PayMethodEnum.Zhifubao:

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

                    UIMessageBox.ShowInfo("处理支付宝退款,金额：" + item.pay_je);
                    //UIMessageTip.ShowOk("处理支付宝退款,金额：" + item.pay_je); Thread.Sleep(1000);
                    break;
                default:

                    UIMessageBox.ShowInfo("处理其他退款,金额：" + item.pay_je);
                    //UIMessageTip.ShowOk("处理其他退款,金额：" + item.pay_je); Thread.Sleep(1000);
                    break;



            }
        }
        public bool YBRefund()
        {
            //查询用户医保信息 
            var insuplc_admdvs = SessionHelper.PatientVM.yb_insuplc_admdvs.Trim();
            var mdtrt_id = YBHelper.currentYBPay.output.data.mdtrt_id;
            var ipt_otp_no = YBHelper.currentYBPay.output.data.ipt_otp_no;
            var psn_no = YBHelper.currentYBPay.output.data.psn_no;



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
        private void Check_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void btnwx_Click(object sender, EventArgs e)
        {
            OpenPayWindow(PayMethodEnum.WeiXin);
        }

        private void btnyl_Click(object sender, EventArgs e)
        {
            OpenPayWindow(PayMethodEnum.Yinlian);
        }

        private void btnybk_Click(object sender, EventArgs e)
        {
            OpenPayWindow(PayMethodEnum.Yibao);
        }

        private void btnxj_Click(object sender, EventArgs e)
        {
            OpenPayWindow(PayMethodEnum.Xianjin);
        }

        private void btnzfb_Click(object sender, EventArgs e)
        {
            OpenPayWindow(PayMethodEnum.Zhifubao);
        }

        private void btnSubmitCombi_Click(object sender, EventArgs e)
        {
            log.Info("提交支付");

            TiJiaoZhifu();
        }

        public void TiJiaoZhifu()
        {
            //判断剩余金额是否为0
            if (Convert.ToDecimal(lblsyje.Text) != 0)
            {
                UIMessageTip.ShowWarning("请选择支付方式并完成支付！", 1500);
                return;
            }

            //搜集数据 处方
            var order_list = SessionHelper.cprCharges.GroupBy(p => new { p.order_no })
   .Select(g => g.First())
   .ToList();

            var order_no_str = "";//order_type-charge_code-charge_amount,order_type-charge_code-charge_amount;order_type-charge_code-charge_amount;
            foreach (var order in order_list)
            {
                order_no_str += "-" + order.order_no;

            }
            if (order_no_str != "")
            {
                order_no_str = order_no_str.Substring(1);
            }

            //支付数据
            string pay_string = "";
            foreach (var item in paylist)
            {
                pay_string += "," + item.pay_type + "-" + item.pay_je + "-" + item.out_trade_no;
            }

            if (pay_string.Length > 0)
            {
                pay_string = pay_string.Substring(1);
            }
            else
            {
                //处理金额为0的情况
                pay_string = (int)PayMethodEnum.Xianjin + "-0-";
            } 

           

            try
            {

                //todo:交款提交 
                var d = new
                {
                    patient_id = SessionHelper.PatientVM.patient_id,
                    times = times,
                    pay_string = pay_string,
                    order_no_str = order_no_str,
                    opera = SessionHelper.uservm.user_mi
                }; 
                var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string paramurl = string.Format($"/api/mzsf/pay?patient_id={d.patient_id}&times={d.times}&pay_string={d.pay_string}&order_no_str={d.order_no_str}&opera={d.opera}");

                log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;

                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(responseJson);

                if (result.status == 1 && result.data)
                {
                    log.Info("缴费成功");
                    UIMessageTip.ShowOk("缴费成功!", 1500);
                    SessionHelper.do_gh_print = true;
                    this.Close();
                    return;
                }
                else
                {
                    log.Error(result.message);
                    UIMessageBox.ShowError(result.message);
                    //失败，退款处理
                    //Refund();

                }


            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());

            }
        }
    }
}
