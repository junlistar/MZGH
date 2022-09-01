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
using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;
using Newtonsoft.Json;
using System.Configuration;
using Client.Forms.Wedgit;

namespace Mzsf.Forms.Pages
{
    public partial class Check : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(Check));//typeof放当前类

        List<GHPayModel> paylist = new List<GHPayModel>();
        //List<ChargeItemVM> chargeItems = new List<ChargeItemVM>();

        decimal total_charge = 0;
        public int times = 0;
        public string doct_code = "";

        public Check()
        {
            InitializeComponent();
        }

        private void Check_Load(object sender, EventArgs e)
        {
            dgvzd.Init();
            dgvfk.Init();
            total_charge = Math.Round(SessionHelper.cprCharges.Sum(p => p.total_price), 2);

            lblzje.Text = "0.00";
            lblyfje.Text = "0.00";
            lblsyje.Text = "0.00";

            lblZongji.Text = total_charge.ToString();
            lblzje.Text = total_charge.ToString();
            lblsyje.Text = total_charge.ToString();
            lblYouhui.Text = "0.00";

            lblfpzje.Text = total_charge.ToString();
            lblfpje.Text = total_charge.ToString();

            BindChequelist();

            //绑定发票数据
            BindChargeData();

            //获取医生医保编号
            //if (doc)
            //{

            //}

        }
        public void BindChequelist()
        {

            gbxChequelist.Clear();
            int btnWidth = 120;
            int btnHeight = 60;
            var _ds = SessionHelper.pageChequeCompares.OrderBy(p => p.page_code).ToList();

            for (int i = 0; i < _ds.Count; i++)
            {
                UISymbolButton btn1 = new UISymbolButton();

                btn1.Style = Sunny.UI.UIStyle.Blue;
                btn1.StyleCustomMode = true;
                btn1.Width = btnWidth;
                btn1.Height = btnHeight;
                btn1.Text = _ds[i].page_name;
                btn1.TagString = _ds[i].his_code;

                if (_ds[i].page_name.Contains("微信"))
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
                else if (_ds[i].page_name.Contains("医保"))
                {
                    btn1.Symbol = 62147;
                }
                else if (_ds[i].page_name.Contains("现金"))
                {
                    btn1.Symbol = 361783;
                }
                btn1.Font = new Font("微软雅黑", 16, FontStyle.Regular);
                btn1.Click += ChequeCompare_Click; ;
                gbxChequelist.Add(btn1);
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
                OpenPayWindow(PayMethodEnum.Yibao, btn.TagString);
            }
            else if (btn.Text.Contains("现金"))
            {
                OpenPayWindow(PayMethodEnum.Xianjin, btn.TagString);
            }

        }

        private void BindChargeData()
        {
            try
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
                dgvzd.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
        public void AddMzThridPay(string payMethod, string out_trade_no, string mdtrt_id, string ipt_otp_no, string psn_no, string yb_insuplc_admdvs, decimal charge)
        {
            try
            { 
                var _pid = SessionHelper.patientVM.patient_id;
                var _cheque_type = payMethod;
                var _cheque_no = out_trade_no;
                var _mdtrt_id = mdtrt_id;
                var _ipt_otp_no = ipt_otp_no;
                var _psn_no = psn_no;
                var _yb_insuplc_admdvs = yb_insuplc_admdvs;
                var _price_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var _charge = charge;
                var _opera = SessionHelper.uservm.user_mi;
                string paramurl = string.Format($"/api/mzsf/AddMzThridPay?patient_id={_pid}&cheque_type={_cheque_type}&cheque_no={_cheque_no}&mdtrt_id={_mdtrt_id}&ipt_otp_no={_ipt_otp_no}&psn_no={_psn_no}&yb_insuplc_admdvs={_yb_insuplc_admdvs}&charge={_charge}&price_date={_price_date}&opera={_opera}");
                HttpClientUtil.Get(paramurl);
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
        public void OpenPayWindow(PayMethodEnum payMethod, string his_cheque_type = "")
        {
            try
            {

                var left_je = Convert.ToDouble(lblsyje.Text);

                if (left_je == 0)
                {
                    UIMessageTip.ShowWarning("剩余应付金额为0，无需支付！");
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
                            left_je = Convert.ToDouble(lblsyje.Text);
                            //UIMessageTip.ShowWarning("金额大于剩余付款金额！");
                            //return;
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

                        //保存到数据库
                        AddMzThridPay(his_cheque_type, out_trade_no, "", "", "", "", (decimal)left_je);
                    }
                    else
                    {
                        log.Info("取消支付：" + his_cheque_type + ",金额：" + left_je);
                        return;
                    }

                }
                else if (payMethod == PayMethodEnum.Yinlian)
                {
                    CardPay card = new CardPay(his_cheque_type, left_je.ToString());
                    card.ShowDialog();
                    if (card.DialogResult == DialogResult.OK)
                    {
                        log.Info("完成支付：" + his_cheque_type + ",金额：" + left_je);
                        //保存支付数据，用于退款
                        paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je, out_trade_no));

                        //保存到数据库
                        AddMzThridPay(his_cheque_type, out_trade_no, "", "", "", "", (decimal)left_je);
                    }
                    else
                    {
                        log.Info("取消支付：" + his_cheque_type + ",金额：" + left_je);
                        return;

                    }
                }
                else if (payMethod == PayMethodEnum.Yibao)
                {
                    //刷医保卡，再挂号 
                    if (YiBaoPay(Convert.ToDecimal(left_je)))
                    {
                        log.Info("完成支付：" + his_cheque_type + ",金额：" + left_je);
                        //保存支付数据，用于退款
                        paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je, YBHelper.currentYBPay.output.data.mdtrt_id));

                        //保存到数据库
                        AddMzThridPay(his_cheque_type, YBHelper.currentYBPay.output.data.mdtrt_id, YBHelper.currentYBPay.output.data.mdtrt_id, YBHelper.currentYBPay.output.data.ipt_otp_no, YBHelper.currentYBPay.output.data.psn_no, SessionHelper.patientVM.yb_insuplc_admdvs, (decimal)left_je);

                    }
                    else
                    {
                        log.Info("支付失败：" + his_cheque_type + ",金额：" + left_je);
                        return;
                    }
                }
                else if (payMethod == PayMethodEnum.Xianjin)
                {
                    JKZL xjzf = new JKZL((his_cheque_type).ToString(), left_je.ToString());
                    if (chkcomb.Checked)
                    {
                        xjzf.lbl1.Text = "本次支付:";
                    }

                    xjzf.ShowDialog();
                    if (xjzf.DialogResult == DialogResult.OK)
                    {
                        log.Info("完成支付：" + his_cheque_type + ",金额：" + left_je);
                        //保存支付数据，用于退款
                        paylist.Add(new GHPayModel(his_cheque_type, (decimal)left_je));

                    }
                    else
                    {
                        log.Info("取消支付：" + his_cheque_type + ",金额：" + left_je);
                        return;
                    }
                }
                else
                {
                    log.Info("其他支付：" + his_cheque_type + ",金额：" + left_je);
                    //其他支付
                    UIMessageTip.ShowOk("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + ",金额：" + left_je);
                }


                this.uiListBox1.Items.Add("支付方式：" + PayMethod.GetPayStringByEnum(payMethod) + "，金额： " + left_je);

                //总金额-支付金额
                lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) + Convert.ToDecimal(left_je)).ToString();
                lblsyje.Text = (total_charge - Convert.ToDecimal(lblyfje.Text)).ToString();

                //发票tab，数据更新
                BindReceiptData();

                //单个支付，支付完成，自动提交
                var sy_je = Convert.ToDouble(lblsyje.Text);
                if (sy_je == 0)
                {
                    TiJiaoZhifu();
                }
                
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
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
            dgvfk.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        }

        public bool YiBaoPay(decimal left_je)
        {
            try
            {
                string json = "";
                string BusinessID = "1101";
                string Dataxml = json;
                string Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                if (string.IsNullOrEmpty(SessionHelper.patientVM.yb_insuplc_admdvs) || string.IsNullOrEmpty(SessionHelper.patientVM.hic_no)
                   || string.IsNullOrEmpty(SessionHelper.patientVM.yb_insutype) || string.IsNullOrEmpty(SessionHelper.patientVM.yb_psn_no))
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

                    ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

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

                        if (yBResponse.output.baseinfo.certno != SessionHelper.patientVM.hic_no)
                        {
                            //如果号码不一致，提示返回
                            MessageBox.Show("医保卡与患者身份不一致！");
                            return false;
                        }

                        YBHelper.currentYBInfo = yBResponse;

                        SessionHelper.patientVM.yb_insuplc_admdvs = yBResponse.output.insuinfo[0].insuplc_admdvs;
                        SessionHelper.patientVM.yb_insutype = yBResponse.output.insuinfo[0].insutype;
                        SessionHelper.patientVM.yb_psn_no = yBResponse.output.baseinfo.psn_no;

                        //保存用户的医保信息
                        var d = new
                        {
                            yb_psn_no = yBResponse.output.baseinfo.psn_no,
                            social_no = yBResponse.output.baseinfo.certno,
                            pid = SessionHelper.patientVM.patient_id,
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

                //机制号
                var sn_no = GetReceiptMaxNo();
                var max_sn = int.Parse(sn_no);

                //门诊挂号
                YBRequest<GHRequestModel> ghRequest = new YBRequest<GHRequestModel>();
                ghRequest.infno = ((int)InfoNoEnum.门诊挂号).ToString();

                ghRequest.msgid = YBHelper.msgid;
                ghRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
                ghRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
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

                ghRequest.input.data.psn_no = SessionHelper.patientVM.yb_psn_no.Trim();
                ghRequest.input.data.insutype = SessionHelper.patientVM.yb_insutype.Trim();

                ghRequest.input.data.begntime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //ghRequest.input.data.mdtrt_cert_type = yBResponse.output.baseinfo.psn_cert_type;
                //ghRequest.input.data.mdtrt_cert_no = yBResponse.output.baseinfo.certno;
                ghRequest.input.data.mdtrt_cert_type = "02";//身份证
                ghRequest.input.data.mdtrt_cert_no = SessionHelper.patientVM.hic_no;

                ghRequest.input.data.ipt_otp_no = sn_no; //机制号 唯一" ipt_otp_no": "1533956",
                ghRequest.input.data.atddr_no = "D421003007628"; //医生医保编号 "atddr_no": "D421003007628",
                ghRequest.input.data.dr_name = "1";
                ghRequest.input.data.dept_code = "1";
                ghRequest.input.data.dept_name = "1";
                ghRequest.input.data.caty = "1";

                json = WebApiHelper.SerializeObject(ghRequest);

                BusinessID = "2201";
                Dataxml = json;
                Outputxml = "";
                parm = new object[] { BusinessID, json, Outputxml };

                AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver,0, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver,1, SessionHelper.uservm.user_mi, ghRequest.inf_time);
                log.Debug(parm[2]);

                var resp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                if (!string.IsNullOrEmpty(resp.err_msg))
                {
                    MessageBox.Show(resp.err_msg);
                    log.Error(resp.err_msg);
                }
                else if (resp.output != null && !string.IsNullOrEmpty(resp.output.data.mdtrt_id))
                {
                    //MessageBox.Show(resp.output.data.mdtrt_id);

                    //保存医保支付信息，用于退款
                    YBHelper.currentYBPay = resp;
                    //就诊ID 医保返回唯一流水
                    string mdtrt_id = resp.output.data.mdtrt_id;
                    //人员编号
                    string psn_no = resp.output.data.psn_no;
                    //住院/门诊号
                    string ipt_otp_no = resp.output.data.ipt_otp_no;

                    var _dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    //提交门诊就诊信息 
                    var jzxxRequest = new YBRequest<object>();
                    jzxxRequest.infno ="2203";

                    jzxxRequest.msgid = YBHelper.msgid;
                    jzxxRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                    jzxxRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
                    jzxxRequest.recer_sys_code = YBHelper.recer_sys_code;
                    jzxxRequest.dev_no = "";
                    jzxxRequest.dev_safe_info = "";
                    jzxxRequest.cainfo = "";
                    jzxxRequest.signtype = "";
                    jzxxRequest.infver = YBHelper.infver;
                    jzxxRequest.opter_type = YBHelper.opter_type;
                    jzxxRequest.opter = SessionHelper.uservm.user_mi;
                    jzxxRequest.opter_name = SessionHelper.uservm.name;
                    jzxxRequest.inf_time = _dt;
                    jzxxRequest.fixmedins_code = YBHelper.fixmedins_code;
                    jzxxRequest.fixmedins_name = YBHelper.fixmedins_name;
                    jzxxRequest.sign_no = YBHelper.msgid;
                    jzxxRequest.input = new RepModel<object>(); 
                     

                    jzxxRequest.input.mdtrtinfo = new Mdtrtinfo();
                    jzxxRequest.input.diseinfo = new List<Diseinfo>();

                    jzxxRequest.input.mdtrtinfo.mdtrt_id = mdtrt_id;
                    jzxxRequest.input.mdtrtinfo.psn_no = psn_no;
                    jzxxRequest.input.mdtrtinfo.med_type = "11";
                    jzxxRequest.input.mdtrtinfo.begntime = _dt;

                    Diseinfo diseinfo = new Diseinfo();

                    diseinfo.diag_type = "01";
                    diseinfo.diag_srt_no = "1";
                    diseinfo.diag_code = "R50.900";
                    diseinfo.diag_name = "0";
                    diseinfo.diag_dept = "0";
                    diseinfo.dise_dor_no = "D421002005282";
                    diseinfo.dise_dor_name = "11";
                    diseinfo.diag_time = _dt;
                    diseinfo.vali_flag = "1";

                    jzxxRequest.input.diseinfo.Add(diseinfo);


                    json = WebApiHelper.SerializeObject(jzxxRequest);
                    BusinessID = "2203";
                    Dataxml = json;
                    Outputxml = "";
                    parm = new object[] { BusinessID, json, Outputxml };

                    AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 0, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                    result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                    AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 1, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                    log.Debug("就诊系信息返回：" + parm[2]);

                    var _jzxxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                    if (_jzxxresp != null && !string.IsNullOrEmpty(_jzxxresp.err_msg))
                    {
                        MessageBox.Show(_jzxxresp.err_msg);
                        log.Error(_jzxxresp.err_msg);
                        return false;
                    }

                    //提交门诊挂号明细信息 
                    var mzmxRequest = new YBRequest<List<feedetail>>();
                    mzmxRequest.infno = ((int)InfoNoEnum.门诊明细上传).ToString();

                    mzmxRequest.msgid = YBHelper.msgid;
                    mzmxRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                    mzmxRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
                    mzmxRequest.recer_sys_code = YBHelper.recer_sys_code;
                    mzmxRequest.dev_no = "";
                    mzmxRequest.dev_safe_info = "";
                    mzmxRequest.cainfo = "";
                    mzmxRequest.signtype = "";
                    mzmxRequest.infver = YBHelper.infver;
                    mzmxRequest.opter_type = YBHelper.opter_type;
                    mzmxRequest.opter = SessionHelper.uservm.user_mi;
                    mzmxRequest.opter_name = SessionHelper.uservm.name;
                    mzmxRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    mzmxRequest.fixmedins_code = YBHelper.fixmedins_code;
                    mzmxRequest.fixmedins_name = YBHelper.fixmedins_name;
                    mzmxRequest.sign_no = YBHelper.msgid;
                    mzmxRequest.input = new RepModel<List<feedetail>>();
                    List<feedetail> feedetails = new List<feedetail>();
                    int _index = 1;
                    foreach (var item in SessionHelper.cprCharges)
                    { 
                        feedetail _detail = new feedetail();
                        _detail.feedetl_sn = SessionHelper.patientVM.patient_id + "_" + SessionHelper.patientVM.max_ledger_sn + "_" + _index++;
                        _detail.mdtrt_id = mdtrt_id;
                        _detail.psn_no = psn_no;
                        _detail.chrg_bchno = ipt_otp_no;
                        _detail.rx_circ_flag = "0";
                        _detail.fee_ocur_time = _dt;
                        var ybbill = SessionHelper.ybhzCompare.Where(p => p.charge_code == item.charge_code).FirstOrDefault();
                        if (ybbill != null)
                        {
                            _detail.med_list_codg = ybbill.ybhz_code;
                        }
                        else
                        {
                            MessageBox.Show("没有找到关联医保目录");
                        }
                        _detail.medins_list_codg = item.charge_code;
                        _detail.det_item_fee_sumamt = item.charge_price;
                        _detail.cnt = item.charge_amount;
                        _detail.pric = item.orig_price;
                        _detail.bilg_dept_codg = SessionHelper.uservm.dept_sn;
                        _detail.bilg_dept_name = SessionHelper.uservm.name;
                        _detail.bilg_dr_codg = "D421002005282";
                        _detail.bilg_dr_name = SessionHelper.uservm.name;
                        _detail.hosp_appr_flag = "1";

                        feedetails.Add(_detail);
                    }
                    mzmxRequest.input.feedetail = feedetails;
                    json = WebApiHelper.SerializeObject(mzmxRequest);
                    BusinessID = "2204";
                    Dataxml = json;
                    Outputxml = "";
                    parm = new object[] { BusinessID, json, Outputxml };

                    AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 0, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                    result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                    AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 1, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                    log.Debug("明细提交返回：" + parm[2]);

                    var _mxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                    if (_mxresp != null && !string.IsNullOrEmpty(_mxresp.err_msg))
                    {
                        MessageBox.Show(_mxresp.err_msg);
                        log.Error(_mxresp.err_msg);
                        return false;
                    }

                    //预结算
                    var yjsRequest = new YBRequest<MZJS2207A>();
                    yjsRequest.infno = ((int)InfoNoEnum.预结算).ToString();

                    yjsRequest.msgid = YBHelper.msgid;
                    yjsRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                    yjsRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
                    yjsRequest.recer_sys_code = YBHelper.recer_sys_code;
                    yjsRequest.dev_no = "";
                    yjsRequest.dev_safe_info = "";
                    yjsRequest.cainfo = "";
                    yjsRequest.signtype = "";
                    yjsRequest.infver = YBHelper.infver;
                    yjsRequest.opter_type = YBHelper.opter_type;
                    yjsRequest.opter = SessionHelper.uservm.user_mi;
                    yjsRequest.opter_name = SessionHelper.uservm.name;
                    yjsRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    yjsRequest.fixmedins_code = YBHelper.fixmedins_code;
                    yjsRequest.fixmedins_name = YBHelper.fixmedins_name;
                    yjsRequest.sign_no = YBHelper.msgid;
                    yjsRequest.input = new RepModel<MZJS2207A>();
                    // mzmxRequest = new RepModel<List<feedetail>>();

                    MZJS2207A _mzyjs = new MZJS2207A();
                    _mzyjs.psn_no = psn_no;
                    _mzyjs.mdtrt_cert_type = "02";
                    _mzyjs.mdtrt_cert_no = SessionHelper.patientVM.hic_no;
                    _mzyjs.med_type = 11; //门诊挂号 门诊挂号不能结算 11为普通门诊
                    _mzyjs.medfee_sumamt = left_je;
                    _mzyjs.psn_setlway = "01"; //01 按项目结算 02 按定额结算
                    _mzyjs.mdtrt_id = mdtrt_id;
                    _mzyjs.chrg_bchno = ipt_otp_no;//收费批次号
                    _mzyjs.insutype = SessionHelper.patientVM.yb_insutype;
                    _mzyjs.acct_used_flag = "1";//0 否 1 是

                    yjsRequest.input.data = _mzyjs;
                    json = WebApiHelper.SerializeObject(yjsRequest);
                    BusinessID = "2206";//预结算
                    Dataxml = json;
                    Outputxml = "";
                    parm = new object[] { BusinessID, json, Outputxml };

                    AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 0, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                    result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                    AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 1, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                    log.Debug("预结算返回：" + parm[2]);

                    var _yjsresp = WebApiHelper.DeserializeObject<YBResponse<MzjsResponse>>(parm[2].ToString());

                    if (_yjsresp != null && !string.IsNullOrEmpty(_yjsresp.err_msg))
                    {
                        MessageBox.Show(_yjsresp.err_msg);
                        log.Error(_yjsresp.err_msg);
                        return false;
                    }

                    //弹出预结算信息
                    YBJSPreview yBJSPreview = new YBJSPreview();
                    yBJSPreview.mzjsResponse = _yjsresp.output;
                    if (yBJSPreview.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }

                    //门诊结算
                    var jsRequest = new YBRequest<MZJS2207A>();
                    jsRequest.infno = "2207A";

                    jsRequest.msgid = YBHelper.msgid;
                    jsRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                    jsRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
                    jsRequest.recer_sys_code = YBHelper.recer_sys_code;
                    jsRequest.dev_no = "";
                    jsRequest.dev_safe_info = "";
                    jsRequest.cainfo = "";
                    jsRequest.signtype = "";
                    jsRequest.infver = YBHelper.infver;
                    jsRequest.opter_type = YBHelper.opter_type;
                    jsRequest.opter = SessionHelper.uservm.user_mi;
                    jsRequest.opter_name = SessionHelper.uservm.name;
                    jsRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    jsRequest.fixmedins_code = YBHelper.fixmedins_code;
                    jsRequest.fixmedins_name = YBHelper.fixmedins_name;
                    jsRequest.sign_no = YBHelper.msgid;
                    jsRequest.input = new RepModel<MZJS2207A>();

                    MZJS2207A _mzjs = new MZJS2207A();
                    _mzjs.psn_no = psn_no;
                    _mzjs.mdtrt_cert_type = "02";
                    _mzjs.mdtrt_cert_no = SessionHelper.patientVM.hic_no;
                    _mzjs.med_type = 11; //门诊挂号12
                    _mzjs.medfee_sumamt = left_je;
                    _mzjs.psn_setlway = "02"; //01 按项目结算 02 按定额结算
                    _mzjs.mdtrt_id = mdtrt_id;
                    _mzjs.chrg_bchno = ipt_otp_no;//收费批次号
                    _mzjs.insutype = SessionHelper.patientVM.yb_insutype;
                    _mzjs.acct_used_flag = "1";//0 否 1 是

                    jsRequest.input.data = _mzjs;

                    json = WebApiHelper.SerializeObject(jsRequest);
                    BusinessID = "2207A";
                    Dataxml = json;
                    Outputxml = "";
                    parm = new object[] { BusinessID, json, Outputxml };

                    //提交门诊挂号结算信息
                    AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 0, SessionHelper.uservm.user_mi, ghRequest.inf_time);
                    
                    result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                    AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 1, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                    log.Debug("结算返回：" + parm[2].ToString());

                    var _jsresp = WebApiHelper.DeserializeObject<YBResponse<MzjsResponse>>(parm[2].ToString());

                    if (_jsresp != null && !string.IsNullOrEmpty(_jsresp.err_msg))
                    {
                        MessageBox.Show(_jsresp.err_msg);
                        log.Error(_jsresp.err_msg);
                    }
                    else if (_jsresp.output != null)
                    {
                        var setl_id = _jsresp.output.setlinfo.setl_id;

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
                        _mzjscx.psn_no = _jsresp.output.setlinfo.psn_no;
                        _mzjscx.setl_id = _jsresp.output.setlinfo.setl_id;//结算返回值 
                        _mzjscx.mdtrt_id = _jsresp.output.setlinfo.mdtrt_id; 

                        jscxRequest.input.data = _mzjscx;

                        json = WebApiHelper.SerializeObject(jscxRequest);
                        BusinessID = "2208";
                        Dataxml = json;
                        Outputxml = "";
                        parm = new object[] { BusinessID, json, Outputxml };

                        
                        AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 0, SessionHelper.uservm.user_mi, ghRequest.inf_time);
                        //提交
                        result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                        AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, ghRequest.sign_no, ghRequest.infver, 1, SessionHelper.uservm.user_mi, ghRequest.inf_time);

                        log.Debug("结算撤销返回：" + parm[2]);

                        var _jscxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                        if (_jscxresp != null && !string.IsNullOrEmpty(_jscxresp.err_msg))
                        {
                            MessageBox.Show(_jscxresp.err_msg);
                            log.Error(_jscxresp.err_msg);
                        }
                        else
                        {
                            return true;
                        } 

                    }

                    return false; 
                }

                MessageBox.Show("支付失败！");

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
            return false;
        }

        public void AddYBLog(string info_code,string data,string patient_id,string msgid,string ver,int flag,string opera,string oper_date)
        {
            try
            {
                var _yblog = new YbLog();
                _yblog.admiss_times = 4;
                _yblog.data = data;
                _yblog.oper_code = info_code;
                _yblog.patient_id = patient_id;
                _yblog.msgid = msgid;
                _yblog.ver = ver;
                _yblog.flag = flag;
                _yblog.opera = opera;
                _yblog.oper_date =Convert.ToDateTime(oper_date);


                var paramurl = string.Format($"/api/guahao/AddYbLog");
                var json = HttpClientUtil.PostJSON(paramurl, _yblog);
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                if (responseJson.status == 1)
                {
                    log.Debug("医保操作：" + info_code);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public string GetReceiptMaxNo()
        {
            try
            {

                string paramurl = string.Format($"/api/guahao/GetNewReceiptMaxSN");

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
            paylist = new List<GHPayModel>();

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
                        //UIMessageBox.ShowInfo("处理医保退款,金额：" + item.pay_je);

                        if (YBRefund())
                        {

                            UpdateThirdPayStatus(SessionHelper.patientVM.patient_id, item.pay_type.ToString(), item.out_trade_no, item.pay_je.ToString());
                        }

                    }
                    else if (chequeCompare.page_code == ((int)PayMethodEnum.Yinlian).ToString())
                    {
                        UpdateThirdPayStatus(SessionHelper.patientVM.patient_id, item.pay_type.ToString(), item.out_trade_no, item.pay_je.ToString());
                        //UIMessageBox.ShowInfo("处理银联退款,金额：" + item.pay_je);
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
                        // UIMessageBox.ShowInfo("处理其他退款,金额：" + item.pay_je);
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
        public bool YBRefund()
        {
            try
            {

                //查询用户医保信息 
                var insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
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

                ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

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
                log.Error(ex.Message);
            }
            return false;
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
                pay_string = PayMethod.GetChequeTypeByEnum(PayMethodEnum.Xianjin) + "-0-";
            }
            try
            {

                //todo:交款提交 
                var d = new
                {
                    patient_id = SessionHelper.patientVM.patient_id,
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

                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(responseJson);

                if (result.status == 1)
                {
                    log.Info("缴费成功");
                    UIMessageTip.ShowOk("缴费成功!", 1500);
                    SessionHelper.do_sf_print = true;
                    SessionHelper.sf_print_user_ledger = result.data;
                    this.DialogResult = DialogResult.OK;


                    if (total_charge == 0)
                    {
                        //支付金额为0，不写电子发票
                        log.Debug("支付金额为0，不写电子发票");
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            //写入电子发票信息
                            CreateElecBill(result.data);
                        });
                    }
                    paylist.Clear();
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
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
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

                string method = "invoiceEBillOutpatient";//医疗挂号电子票据开具接口

                string placeCode = ConfigurationManager.AppSettings["placeCode"];//开票点编码

                string busNo = DateTime.Now.Ticks.ToString(); //业务流水号
                decimal totalAmt = total_charge;

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

                //         //搜集数据 处方
                //         var order_list = SessionHelper.cprCharges.GroupBy(p => new { p.order_no })
                //.Select(g => g.First())
                //.ToList();


                //         for (int i = 0; i < order_list.Count; i++)
                //         {
                //             ElectBillChargeItem electBillCharge = new ElectBillChargeItem();
                //             electBillCharge.sortNo = i;
                //             if (order_list[i].order_type == "01")
                //             {
                //                 //诊疗
                //                 electBillCharge.chargeCode = "90609";
                //             }
                //             else if (order_list[i].order_type == "02")
                //             {
                //                 //西药
                //                 electBillCharge.chargeCode = "90607";

                //             }
                //             else if (order_list[i].order_type == "04")
                //             {
                //                 //草药
                //                 electBillCharge.chargeCode = "90613";

                //             }
                //             electBillCharge.chargeName = order_list[i].order_type;
                //             electBillCharge.number = 1;
                //             electBillCharge.std = Math.Round(order_list[i].charge_price, 2).ToString();
                //             electBillCharge.amt = Math.Round(order_list[i].charge_price, 2).ToString();
                //             electBillCharge.selfAmt = Math.Round(order_list[i].charge_price, 2).ToString();
                //             electBillCharge.remark = "";
                //             chargeItemlist.Add(electBillCharge);
                //         }

                //         //for (int i = 0; i < chargeItems.Count; i++)
                //         //{
                //         //    ElectBillChargeItem electBillCharge = new ElectBillChargeItem();
                //         //    electBillCharge.sortNo = i;
                //         //    if (chargeItems[i].mz_bill_item == "026")
                //         //    {
                //         //        electBillCharge.chargeCode = "90611";//对应挂号费
                //         //    }
                //         //    else if (chargeItems[i].mz_bill_item == "018")
                //         //    {
                //         //        electBillCharge.chargeCode = "90601";//对应诊查费
                //         //    }
                //         //    else
                //         //    {

                //         //    }
                //         //    electBillCharge.chargeName = chargeItems[i].name;
                //         //    electBillCharge.number = 1;
                //         //    electBillCharge.std = chargeItems[i].effective_price.ToString();
                //         //    electBillCharge.amt = chargeItems[i].effective_price.ToString();
                //         //    electBillCharge.selfAmt = chargeItems[i].effective_price.ToString();
                //         //    electBillCharge.remark = "";

                //         //    chargeItemlist.Add(electBillCharge);
                //         //}

                //         //var _chargeDetail = new
                //         //{
                //         //    sortNo = "序号",
                //         //    chargeCode = "收费项目代码",
                //         //    chargeName = "收费项目名称",
                //         //    number = 0,//数量
                //         //    std = 0,//收费标准
                //         //    amt = 0,//金额
                //         //    selfAmt = "0",
                //         //    remark = "备注"
                //         //};
                //         //var _listDetail = new
                //         //{
                //         //    name = "",//药品名称
                //         //    std = "",//单价
                //         //    number = "",//数量
                //         //    amt = "",//金额
                //         //    selfAmt = "", //自费金额
                //         //};

                //         string _remark = "";
                //         for (int i = 0; i < paylist.Count; i++)
                //         {
                //             PayChannelDetail payChannelDetail = new PayChannelDetail();
                //             //if (paylist[i].pay_type == SessionHelper.pay_xianjin)
                //             //{//现金
                //             //    payChannelDetail.payChannelCode = "02"; _remark += ",现金-";
                //             //}
                //             //else if (paylist[i].pay_type == SessionHelper.pay_yibao)
                //             //{//医保
                //             //    payChannelDetail.payChannelCode = "07"; _remark += ",医保-";
                //             //}
                //             //else if (paylist[i].pay_type == SessionHelper.pay_zhifubao)
                //             //{//支付宝
                //             //    payChannelDetail.payChannelCode = "01"; _remark += ",支付宝-";
                //             //}
                //             //else if (paylist[i].pay_type == SessionHelper.pay_weixin)
                //             //{//微信
                //             //    payChannelDetail.payChannelCode = "01"; _remark += ",微信-";
                //             //}
                //             //else if (paylist[i].pay_type == SessionHelper.pay_yinlian)
                //             //{//银联
                //             //    payChannelDetail.payChannelCode = "01"; _remark += ",银联-";
                //             //}
                //             var _payType = SessionHelper.pageChequeCompares.Where(p => p.his_code == paylist[i].pay_type).FirstOrDefault();
                //             if (_payType != null && _payType.page_code == "1")
                //             {
                //                 //微信
                //                 payChannelDetail.payChannelCode = "01"; _remark += ",微信-";
                //             }
                //             else if (_payType != null && _payType.page_code == "2")
                //             {
                //                 //支付宝
                //                 payChannelDetail.payChannelCode = "01"; _remark += ",支付宝-";
                //             }
                //             else if (_payType != null && _payType.page_code == "3")
                //             {
                //                 //银联
                //                 payChannelDetail.payChannelCode = "01"; _remark += ",银联-";
                //             }
                //             else if (_payType != null && _payType.page_code == "4")
                //             {
                //                 //医保
                //                 payChannelDetail.payChannelCode = "07"; _remark += ",医保-";
                //             }
                //             else if (_payType != null && _payType.page_code == "5")
                //             {
                //                 //现金
                //                 payChannelDetail.payChannelCode = "02"; _remark += ",现金-";
                //             }


                //             _remark += paylist[i].pay_je.ToString();
                //             payChannelDetail.payChannelValue = paylist[i].pay_je.ToString();
                //             payChannelDetails.Add(payChannelDetail);
                //         }
                //         if (!string.IsNullOrWhiteSpace(_remark))
                //         {
                //             _remark = _remark.Substring(1);
                //         }

                string getDataUrl = string.Format($"/api/mzsf/GetFPInvoiceEBillOutpatient?patient_id={SessionHelper.patientVM.patient_id}&ledger_sn={new_ledger_sn}&admiss_times={1}");
                var json = HttpClientUtil.Get(getDataUrl);
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
                    patientNo = result.data.MainData.patientNo,
                    patientId = result.data.MainData.patientId,
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
                //    busType = "02",         //业务标识06挂号，02门诊
                //    payer = SessionHelper.patientVM.name.Trim(),               //患者姓名
                //    busDateTime = DateTime.Now.ToString("yyyyMMddHHmmss000"),//业务发生时间
                //    placeCode = placeCode,//开票点编码
                //    payee = SessionHelper.uservm.user_mi,//收费员
                //    author = SessionHelper.uservm.user_mi,//票据编制人
                //    checker = SessionHelper.uservm.user_mi,//票据复核人
                //    totalAmt = Math.Round(totalAmt, 2),//开票总金额
                //    remark = _remark,
                //    patientNo = SessionHelper.patientVM.patient_id + new_ledger_sn,
                //    patientId = SessionHelper.patientVM.patient_id,
                //    payerType = "1",//交款人类型 1 个人2单位
                //    cardType = "3101",//卡类型
                //    cardNo = SessionHelper.patientVM.patient_id,//卡号
                //    age = SessionHelper.patientVM.age,
                //    sex = SessionHelper.patientVM.sex == "1" ? "男" : "女",
                //    accountPay = "0",//个人账户支付
                //    fundPay = "0",//医保统筹基金支付
                //    otherfundPay = "0",//其它医保支付
                //    ownPay = "0",//自费金额
                //    selfConceitedAmt = "0",//个人自负
                //    selfPayAmt = "0",//个人自付
                //    selfCashPay = Math.Round(totalAmt, 2),//个人现金支付
                //    reimbursementAmt = "0",//医保报销总金额
                //    payChannelDetail = payChannelDetails,//交费渠道列表
                //    isArrears = "1",//是否可流通
                //    chargeDetail = chargeItemlist,
                //    listDetail = electBillListDetails,
                //};
                //log.Debug("_data:" + _data);
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
                            patientId = SessionHelper.patientVM.patient_id,
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
                    UIMessageTip.ShowError("电子发票数据生成失败！");
                    log.Error(json);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            } 
        } 

        private void btnTuikuan_Click(object sender, EventArgs e)
        {
            var index = uiListBox1.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("请选择付款项目进行退款操作！"); return;
            }
            if (MessageBox.Show(uiListBox1.SelectedItem.ToString(), "是否确认退款？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //退款
                RefundType(paylist[index]);

                uiListBox1.Items.Remove(uiListBox1.SelectedItem);
                //总金额-支付金额
                lblyfje.Text = (Convert.ToDecimal(lblyfje.Text) - paylist[index].pay_je).ToString();
                lblsyje.Text = (total_charge - Convert.ToDecimal(lblyfje.Text)).ToString();
                paylist.RemoveAt(index);
                //ShowMessage();

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

        private void Check_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (paylist != null && paylist.Count > 0)
            {
                Refund();
            }
        }
    }
}
