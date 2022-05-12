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
using ThoughtWorks.QRCode.Codec;
using System.Threading;
using log4net;
using Client.Pay.AliPayAPI;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Payment.FaceToFace.Models;
using Alipay.EasySDK.Kernel.Util;
using Alipay.EasySDK.Payment.Common.Models;

namespace Client
{
    public partial class SelectPayType : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(GuaHao));//typeof放当前类


        GHRequestVM vm = new GHRequestVM();
        string patientId = "";
        Dictionary<int, double> dicPay = new Dictionary<int, double>();
        List<GHPayModel> paylist = new List<GHPayModel>();

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

            log.Info("结束取消支付,退款处理");

        }

        private void btnwx_Click(object sender, EventArgs e)
        {

            OpenPayWindow(PayMethodEnum.WeiXin);

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

                    this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                    //总金额-支付金额
                    lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                    lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();
                }
                else
                {
                    log.Info("取消支付：" + (int)PayMethodEnum.Zhifubao + ",金额：" + left_je);

                }

            }
            else if (payMethod == PayMethodEnum.Yinlian || payMethod == PayMethodEnum.Yibao)
            {
                CardPay card = new CardPay(((int)payMethod).ToString(), left_je.ToString());
                card.ShowDialog();
                if (card.DialogResult == DialogResult.OK)
                {
                    log.Info("完成支付：" + (int)payMethod + ",金额：" + left_je);
                    //保存支付数据，用于退款
                    paylist.Add(new GHPayModel((int)payMethod, (decimal)left_je));

                    this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                    //总金额-支付金额
                    lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                    lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();
                }
                else
                {
                    log.Info("取消支付：" + (int)payMethod + ",金额：" + left_je);


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

                    this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                    //总金额-支付金额
                    lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                    lblsyje.Text = (Convert.ToDecimal(vm.je) - Convert.ToDecimal(lblyfje.Text)).ToString();
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

            if (chkcomb.Checked)
            {

                ShowMessage();
            }
            else
            {

                //单个支付，支付完成，自动提交
                var sy_je = Convert.ToDouble(lblsyje.Text);
                if (sy_je == 0)
                {
                    TiJiaoZhifu();
                }

            }
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
            //txtwx.Visible = false;
            //txtzfb.Visible = false;
            //txtyl.Visible = false;
            //txtxj.Visible = false;
            //txtybk.Visible = false;

            //btnAdd1.Visible = false;
            //btnAdd2.Visible = false;
            //btnAdd3.Visible = false;
            //btnAdd4.Visible = false;
            //btnAdd5.Visible = false;

            //lblTotal.Text += vm.je + "元";
            //txtxj.Text = vm.je;
            //txtzfb.Text = "0";
            //txtyl.Text = "0";
            //txtybk.Text = "0";
            //txtwx.Text = "0";


            //ShieldNumberTextBoxOtherKeys(txtwx);
            //ShieldNumberTextBoxOtherKeys(txtzfb);
            //ShieldNumberTextBoxOtherKeys(txtyl);
            //ShieldNumberTextBoxOtherKeys(txtwx);
            //ShieldNumberTextBoxOtherKeys(txtxj);

            //txtwx.KeyPress += txtje_KeyPress;
            //txtzfb.KeyPress += txtje_KeyPress;
            //txtyl.KeyPress += txtje_KeyPress;
            //txtxj.KeyPress += txtje_KeyPress;
            //txtybk.KeyPress += txtje_KeyPress;

            // this.chkxj.Checked = true;
        }
        public void GetEffectivePriceByRecordSN()
        {
            var record_sn = vm.record_sn;

            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/GetChargeItemsByRecordSN?record_sn={record_sn}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                    var chargeItems = WebApiHelper.DeserializeObject<ResponseResult<List<ChargeItemVM>>>(json).data;
                    if (chargeItems!=null)
                    {
                        vm.je = chargeItems.Sum(p => p.effective_price).ToString();
                    } 
                }
            }
            catch ( Exception ex)
            {
                log.Error(ex.Message);
                
            }

        }


        private void CountDown()
        {

        }

        private void btncombi_Click(object sender, EventArgs e)
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
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));
                string paramurl = string.Format($"/api/GuaHao/GuaHao?patient_id={patientId}&record_sn={vm.record_sn}&pay_string={pay_string}&opera={SessionHelper.uservm.user_mi}");

                //client.DefaultRequestHeaders.Add("user_mi", MdiForm.uservm.user_mi);

                log.Info("接口：" + client.BaseAddress + paramurl);
                string responseJson = client.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;

                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(responseJson);

                if (result.status == 1 && result.data)
                {
                    log.Info("挂号成功");
                    UIMessageTip.ShowOk("挂号成功!");
                }
                else
                {
                    log.Error(result.message);
                    // UIMessageTip.ShowError(result.message,3000);
                    UIMessageBox.ShowError(result.message);
                    //挂号失败，退款处理
                    Refund();

                }


            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());

            }
            this.Close();

        }

        private void btnSubmitCombi_Click(object sender, EventArgs e)
        {
            log.Info("提交支付");

            TiJiaoZhifu();




            return;



            //如果是组合支付
            //if (chkCombi.Checked)
            //{
            //    //判断金额组合是否正确

            //    var je = Convert.ToDecimal(vm.je);

            //    if (je > 0)
            //    {
            //        var money1 = Convert.ToDecimal(this.txtwx.Text);
            //        var money2 = Convert.ToDecimal(this.txtzfb.Text);
            //        var money3 = Convert.ToDecimal(this.txtyl.Text);
            //        var money4 = Convert.ToDecimal(this.txtxj.Text);
            //        var money5 = Convert.ToDecimal(this.txtybk.Text);

            //        var current = money1 + money2 + money3 + money4 + money5;


            //        if (current != je)
            //        {
            //            log.Info("金额组合不正确");
            //            UIMessageTip.ShowError("金额组合不正确!");
            //            return;
            //        }
            //    }
            //}
            //else
            //{
            //    //如果是单个支付方式



            //}
            //Dictionary<string, string> paylist = new Dictionary<string, string>();

            ////判断当前选择的支付方式 便利所有checkbox
            //foreach (var item in this.Controls)
            //{
            //    if (item is UIPanel)
            //    {
            //        foreach (var pnlItem in (item as UIPanel).Controls)
            //        {
            //            if (pnlItem is UICheckBox)
            //            {
            //                var uichk = pnlItem as UICheckBox;


            //                if (uichk.Checked)
            //                {
            //                    //获取当前选择项的金额
            //                    foreach (var ct in uichk.Parent.Controls)
            //                    {
            //                        if (ct is UITextBox)
            //                        {
            //                            var money = (ct as UITextBox).Text;
            //                            //if (money=="" || (decimal.Parse(money)==0))
            //                            //{
            //                            //    break;
            //                            //}
            //                            paylist.Add(uichk.TagString, money); break;
            //                        }
            //                    }
            //                }

            //            }
            //        }
            //    }
            //}
            //if (paylist.Keys.Count == 0)
            //{
            //    UIMessageTip.ShowError("请选择支付方式!");
            //    return;
            //}

            //if (paylist.Keys.Count == 1)
            //{
            //    paylist[paylist.ElementAt(0).Key] = vm.je;
            //}
            //string pay_string = "";
            //bool cancelTrade = false;

            //Dictionary<string, string> dicPay = new Dictionary<string, string>();
            //foreach (var key in paylist.Keys)
            //{

            //    log.Info("支付方式：" + key + ",金额：" + paylist[key]);
            //    //UIMessageTip.ShowOk("支付方式：" + key + ",金额：" + paylist[key]);

            //    //生成商户订单号
            //    string out_trade_no = System.DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(1000, 9999));


            //    pay_string += "," + key + "-" + paylist[key] + "-" + out_trade_no;

            //    //打开对应的支付扫码界面
            //    if (int.Parse(key) == (int)PayMethodEnum.WeiXin || int.Parse(key) == (int)PayMethodEnum.Zhifubao)//微信,支付宝
            //    {

            //        WxPay wxPay = new WxPay(key, paylist[key], out_trade_no);
            //        wxPay.ShowDialog();
            //        if (wxPay.DialogResult == DialogResult.OK)
            //        {
            //            log.Info("完成支付：" + key + ",金额：" + paylist[key]);
            //            //保存支付数据，用于退款
            //            dicPay.Add(key, paylist[key]);
            //        }
            //        else
            //        {
            //            log.Info("取消支付：" + key + ",金额：" + paylist[key]);
            //            //取消支付
            //            cancelTrade = true;
            //            break;

            //        }

            //    }
            //    else if (int.Parse(key) == (int)PayMethodEnum.Yinlian || int.Parse(key) == (int)PayMethodEnum.Yibao)//银联，医保卡
            //    {

            //        CardPay card = new CardPay(key, paylist[key]);
            //        card.ShowDialog();
            //        if (card.DialogResult == DialogResult.OK)
            //        {
            //            log.Info("完成支付：" + key + ",金额：" + paylist[key]);
            //            //保存支付数据，用于退款
            //            dicPay.Add(key, paylist[key]);
            //        }
            //        else
            //        {
            //            log.Info("取消支付：" + key + ",金额：" + paylist[key]);
            //            //取消支付
            //            cancelTrade = true;
            //            break;

            //        }
            //    }
            //    else if (int.Parse(key) == (int)PayMethodEnum.Xianjin)
            //    {
            //        JKZL xjzf = new JKZL(key, paylist[key]);
            //        xjzf.ShowDialog();
            //        if (xjzf.DialogResult == DialogResult.OK)
            //        {
            //            log.Info("完成支付：" + key + ",金额：" + paylist[key]);
            //            //保存支付数据，用于退款
            //            dicPay.Add(key, paylist[key]);
            //        }
            //        else
            //        {
            //            log.Info("取消支付：" + key + ",金额：" + paylist[key]);
            //            //取消支付
            //            cancelTrade = true;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        log.Info("其他支付：" + key + ",金额：" + paylist[key]);
            //        //其他支付
            //        UIMessageTip.ShowOk("支付方式：" + key + ",金额：" + paylist[key]);
            //    }

            //}
            ////如果取消交易
            //if (cancelTrade)
            //{

            //    log.Info("取消支付处理：");
            //    UIMessageTip.ShowOk("取消支付");

            //    //如果组合支付，完成了一笔或多笔支付，但还未完成全部支付，此时取消，退款处理
            //    if (dicPay.Keys.Count > 0)
            //    {
            //        foreach (var key in dicPay.Keys)
            //        {
            //            log.Info("处理退款:" + key + ",金额：" + paylist[key]);
            //            switch (int.Parse(key))
            //            {
            //                case (int)PayMethodEnum.Xianjin:
            //                    UIMessageTip.ShowOk("处理现金退款,金额：" + paylist[key]); Thread.Sleep(1000);
            //                    break;
            //                case (int)PayMethodEnum.WeiXin:

            //                    var transaction_id = "";
            //                    var out_trade_no = "";
            //                    var total_fee = "";
            //                    var redfund_fee = "";

            //                    var wx_response = WxPayAPI.Refund.Run(transaction_id, out_trade_no, total_fee, redfund_fee);
            //                    log.Info("微信退款返回字符串：" + wx_response);


            //                    UIMessageTip.ShowOk("处理微信退款,金额：" + paylist[key]); Thread.Sleep(1000);
            //                    break;
            //                case (int)PayMethodEnum.Yibao:
            //                    UIMessageTip.ShowOk("处理医保退款,金额：" + paylist[key]); Thread.Sleep(1000);
            //                    break;
            //                case (int)PayMethodEnum.Yinlian:
            //                    UIMessageTip.ShowOk("处理银联退款,金额：" + paylist[key]); Thread.Sleep(1000);
            //                    break;
            //                case (int)PayMethodEnum.Zhifubao:


            //                    var cof = AliConfig.GetConfig();
            //                    Factory.SetOptions(cof);

            //                    //全部退款
            //                    AlipayTradeRefundResponse response = Factory.Payment.Common().Refund("外部订单号", "1.0");
            //                    //部分退款
            //                    //AlipayTradeRefundResponse response = Factory.Payment.Common().Optional("out_request_no", "2020093011380002-2").Refund("2020093011380003", "0.02");

            //                    if (ResponseChecker.Success(response))
            //                    {
            //                        log.Info("支付宝退款调用成功");
            //                    }
            //                    else
            //                    {
            //                        log.Error("支付宝退款调用失败，原因：" + response.Msg);
            //                    }

            //                    UIMessageTip.ShowOk("处理支付宝退款,金额：" + paylist[key]); Thread.Sleep(1000);
            //                    break;
            //                default:

            //                    UIMessageTip.ShowOk("处理其他退款,金额：" + paylist[key]); Thread.Sleep(1000);
            //                    break;
            //            }

            //        }

            //    }

            //    log.Info("结束取消支付处理");

            //    this.Close();

            //    return;
            //}

            //if (pay_string.Length > 0)
            //{
            //    pay_string = pay_string.Substring(1);
            //}
            ////MessageBox.Show(pay_string);

            ////todo:处理各个支付方式和金额，写入数据库表
            //var d = new
            //{
            //    patient_id = patientId,
            //    record_sn = vm.record_sn,
            //    pay_string = pay_string,
            //    opera = SessionHelper.uservm.user_mi
            //};

            //try
            //{

            //    var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
            //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    HttpClient client = new HttpClient();
            //    client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));
            //    string paramurl = string.Format($"/api/GuaHao/GuaHao?patient_id={patientId}&record_sn={vm.record_sn}&pay_string={pay_string}&opera={SessionHelper.uservm.user_mi}");

            //    //client.DefaultRequestHeaders.Add("user_mi", MdiForm.uservm.user_mi);

            //    log.Info("接口：" + client.BaseAddress + paramurl);
            //    string responseJson = client.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;

            //    if (responseJson == "true")
            //    {
            //        log.Info("挂号成功");
            //        UIMessageTip.ShowOk("挂号成功!");
            //    }


            //}
            //catch (Exception ex)
            //{
            //    log.Info(ex.ToString());

            //}
            //this.Close();

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

                //var money1 = Convert.ToDecimal(this.txtwx.Text);
                //var money2 = Convert.ToDecimal(this.txtzfb.Text);
                //var money3 = Convert.ToDecimal(this.txtyl.Text);
                //var money4 = Convert.ToDecimal(this.txtxj.Text);
                //var money5 = Convert.ToDecimal(this.txtybk.Text);

                //var current = money1 + money2 + money3 + money4 + money5;


                //if (current < je)
                //{
                //    switch (type)
                //    {
                //        case "wx":
                //            txtwx.Text = (money1 + (je - current)).ToString(); break;

                //        case "zfb":
                //            txtzfb.Text = (money2 + (je - current)).ToString(); break;

                //        case "yl":
                //            txtyl.Text = (money3 + (je - current)).ToString(); break;

                //        case "xj":
                //            txtxj.Text = (money4 + (je - current)).ToString(); break;
                //        case "ybk":
                //            txtybk.Text = (money5 + (je - current)).ToString(); break;
                //        default:
                //            break;
                //    }
                //}
                //else if (current > je)
                //{
                //    UIMessageTip.ShowError("金额组合不正确!");
                //    return false;
                //}
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

        private void uiCheckBox5_CheckedChanged(object sender, EventArgs e)
        {

            //chkyl.CheckedChanged -= uiCheckBox5_CheckedChanged;
            //chkwx.CheckedChanged -= uiCheckBox5_CheckedChanged;
            //chkzfb.CheckedChanged -= uiCheckBox5_CheckedChanged;
            //chkybk.CheckedChanged -= uiCheckBox5_CheckedChanged;
            //chkxj.CheckedChanged -= uiCheckBox5_CheckedChanged;

            //var ui = sender as UICheckBox;

            //Color colxz = Color.FromArgb(0, 192, 192);
            //Color colmr = Color.FromArgb(238, 251, 250);

            ////如果打开组合支付按钮
            //if (chkCombi.Checked)
            //{
            //    if (ui.Checked)
            //    {
            //        var uipanel = ui.Parent as UIPanel;
            //        uipanel.FillColor = colxz;
            //    }
            //    else
            //    {
            //        var uipanel = ui.Parent as UIPanel;
            //        uipanel.FillColor = colmr;
            //    }
            //}
            //else
            //{
            //    //单选
            //    foreach (var item in this.Controls)
            //    {
            //        if (item is UIPanel)
            //        {
            //            foreach (var pnlItem in (item as UIPanel).Controls)
            //            {
            //                if (pnlItem is UICheckBox)
            //                {
            //                    var uichk = pnlItem as UICheckBox;


            //                    if (uichk.Checked && uichk.Name != ui.Name)
            //                    {
            //                        uichk.Checked = false;
            //                        var pnl = uichk.Parent as UIPanel;
            //                        pnl.FillColor = colmr;
            //                    }

            //                }
            //            }
            //        }
            //    }
            //    ////ui.Checked = true;
            //    if (ui.Checked)
            //    {
            //        var uipanel = ui.Parent as UIPanel;
            //        uipanel.FillColor = colxz;
            //    }
            //    else
            //    {
            //        var uipanel = ui.Parent as UIPanel;
            //        uipanel.FillColor = colmr;
            //    };
            //}


            //chkyl.CheckedChanged += uiCheckBox5_CheckedChanged;
            //chkwx.CheckedChanged += uiCheckBox5_CheckedChanged;
            //chkzfb.CheckedChanged += uiCheckBox5_CheckedChanged;
            //chkybk.CheckedChanged += uiCheckBox5_CheckedChanged;
            //chkxj.CheckedChanged += uiCheckBox5_CheckedChanged;

        }


        /// <summary>
        /// 点击选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlxj_Click(object sender, EventArgs e)
        {
            ////没选颜色
            //Color colmr = Color.FromArgb(238, 251, 250);
            //Color colxz = Color.FromArgb(0, 192, 192);
            //pnlwx.FillColor = colmr;
            //pnlxj.FillColor = colmr;
            //pnlybk.FillColor = colmr;
            //pnlyl.FillColor = colmr;
            //pnlzfb.FillColor = colmr;


            //(sender as UIPanel).FillColor = colxz;
        }

        private void chkCombi_CheckedChanged(object sender, EventArgs e)
        {
            //txtwx.Visible = chkCombi.Checked;
            //txtzfb.Visible = chkCombi.Checked;
            //txtyl.Visible = chkCombi.Checked;
            //txtxj.Visible = chkCombi.Checked;
            //txtybk.Visible = chkCombi.Checked;

            //btnAdd1.Visible = chkCombi.Checked;
            //btnAdd2.Visible = chkCombi.Checked;
            //btnAdd3.Visible = chkCombi.Checked;
            //btnAdd4.Visible = chkCombi.Checked;
            //btnAdd5.Visible = chkCombi.Checked;

            //if (!chkCombi.Checked)
            //{
            //    txtxj.Text = vm.je;

            //    this.chkxj.Checked = true;
            //}
            //else
            //{
            //    txtxj.Text = "0";
            //}

            //txtzfb.Text = "0";
            //txtyl.Text = "0";
            //txtybk.Text = "0";
            //txtwx.Text = "0";
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

            OpenPayWindow(PayMethodEnum.Zhifubao);
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

            //MessageBox.Show(chkcomb.Checked.ToString());
        }
    }
}
