using Client.ClassLib;
using Client.ViewModel;
using log4net;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Pay.AliPayAPI;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Payment.FaceToFace.Models;
using Alipay.EasySDK.Kernel.Util;
using Alipay.EasySDK.Payment.Common.Models;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Client
{
    public partial class Refund : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(Refund));//typeof放当前类

        string _barcode = null;
        PatientVM userInfo = null;
        public Refund(string barcode)
        {
            InitializeComponent();
            _barcode = barcode;
        }

        private void Refund_Load(object sender, EventArgs e)
        {
            this.dtprq.Value = DateTime.Now;
            this.txtCode.Focus();
            //LoadData();
        }

        public void LoadData()
        {
            log.Info("LoadData");
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={_barcode}");
            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

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
                }
                else
                {
                    log.Info(response.ReasonPhrase);
                    return;
                }
                var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;
                if (listApi != null && listApi.Count > 0)
                {
                    userInfo = listApi[0];
                    lblName.Text = listApi[0].name;
                    lblAge.Text = listApi[0].age;
                    lblSex.Text = listApi[0].sex == "1" ? "男" : "女";

                    //获取挂号流水记录 选取进行退号操作
                    paramurl = string.Format($"/api/GuaHao/GetGhDeposit?patient_id={listApi[0].patient_id}");

                    log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                    task = SessionHelper.MyHttpClient.GetAsync(paramurl);
                    json = "";
                    task.Wait();
                    response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var read = response.Content.ReadAsStringAsync();
                        read.Wait();
                        json = read.Result;
                    }
                    else
                    {
                        log.Info(response.ReasonPhrase);
                    }
                    var depositList = WebApiHelper.DeserializeObject<ResponseResult<List<GhDepositVM>>>(json).data;
                    if (depositList == null)
                    {
                        return;
                    }
                    //this.dgvDeposit.DataSource = depositList.Select(p => new
                    //{
                    //    p.charge,
                    //    p.ledger_sn,
                    //    p.sname,
                    //    p.times,
                    //    p.tname
                    //}).ToList();


                    var showlist = depositList.Where(p => p.depo_status == "4").ToList();
                    var refundlist = depositList.Where(p => p.depo_status == "7").ToList();
                    foreach (var item in showlist)
                    {
                        int count = refundlist.Where(p => p.item_no == item.item_no
                        && p.ledger_sn == -item.ledger_sn
                        && p.times == item.times
                        && p.charge == -item.charge
                        && p.cheque_type == item.cheque_type).Count();

                        if (count > 0)
                        {
                            item.sname = "已退号";
                        }
                    }

                    this.dgvDeposit.DataSource = showlist;
                    //this.dgvDeposit.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                    this.dgvDeposit.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());

            }


        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (this.dgvDeposit.SelectedRows.Count == 0)
            {
                UIMessageTip.ShowWarning("没有记录!");
                return;
            }

            try
            {
                GhDepositVM vm = new GhDepositVM();
                vm.sname = this.dgvDeposit.SelectedRows[0].Cells["visit_flag_name"].Value.ToString();
                if (vm.sname == "已退号")
                {
                    UIMessageTip.ShowWarning("此记录已经退号!");
                    return;
                }
                else if (vm.sname == "已就诊")
                {
                    UIMessageTip.ShowWarning("此记录已经就诊!");
                    return;
                }
                else if (vm.sname == "取消分诊")
                {
                    UIMessageTip.ShowWarning("此记录已经退号!");
                    return;
                }

                vm.patient_id = lblhidid.Text;



                //vm.item_no =Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["item_no"].Value);
                vm.ledger_sn = Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["ledger_sn"].Value);
                vm.cheque_no = this.dgvDeposit.SelectedRows[0].Cells["cheque_no"].Value.ToString();
                var receipt_sn = this.dgvDeposit.SelectedRows[0].Cells["receipt_sn"].Value.ToString();
                vm.times = 0;
                var sel_index = dgvDeposit.SelectedIndex;
                while (vm.times == 0)
                {
                    var cel_value = this.dgvDeposit.Rows[sel_index].Cells["times"].Value.ToString();
                    if (cel_value == null || cel_value.ToString() == "")
                    {
                        sel_index--;
                    }
                    else
                    {
                        vm.times = Convert.ToInt32(cel_value);
                    }
                }
                //查询出关联的组合支付记录
                //查询列表
                var datestr = dtprq.Value.ToString("yyyy-MM-dd");
                var patient_id = lblhidid.Text;
                Task<HttpResponseMessage> task = null; var json = "";
                var paramurl = string.Format($"/api/GuaHao/GetGhRefund?datestr={datestr}&patient_id={patient_id}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);


                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                else
                {
                    log.Info(response.ReasonPhrase);
                }
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhRefundVM>>>(json);

                if (result!=null)
                {
                    var list = result.data.Where(p => p.times == vm.times.ToString() && p.visit_flag == "1").ToList();
                    if (list!=null && list.Count>0)
                    {
                        foreach (var item in list)
                        {
                            //退款操作

                            if (!string.IsNullOrWhiteSpace(item.cheque_no))
                            {
                                log.Info("有外部订单号：" + item.cheque_no);

                                if (int.Parse(item.cheque_type) == (int)PayMethodEnum.WeiXin)
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
                                else if (int.Parse(item.cheque_type) == (int)PayMethodEnum.Zhifubao)
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
                                else if (int.Parse(item.cheque_type) == (int)PayMethodEnum.Yibao)
                                {
                                    log.Info("医保退款：");
                                    //门诊挂号撤销

                                    //查询用户医保信息
                                    var insuplc_admdvs = userInfo.yb_insuplc_admdvs.Trim();
                                    var mdtrt_id = item.cheque_no;
                                    var ipt_otp_no = receipt_sn;
                                    var psn_no = userInfo.yb_psn_no;



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


                                    json = WebApiHelper.SerializeObject(ghRefund);

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
                                        return;
                                    } 
                                }
                            }
                        }
                    }
                    else
                    {
                        UIMessageTip.ShowWarning("数据已过期，请重新查询！");
                        return;
                    }
                }


                //vm.charge = Convert.ToDecimal(this.dgvDeposit.SelectedRows[0].Cells["charge"].Value);
               // vm.cheque_type = Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["cheque_type"].Value);
                //vm.cheque_no = Convert.ToString(this.dgvDeposit.SelectedRows[0].Cells["cheque_no"].Value);
                //vm.item_no = Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["item_no"].Value);


                //vm.depo_status = this.dgvDeposit.SelectedRows[0].Cells["depo_status"].Value.ToString();
                //vm.price_opera = this.dgvDeposit.SelectedRows[0].Cells["price_opera"].Value.ToString();
                //vm.price_date = Convert.ToDateTime(this.dgvDeposit.SelectedRows[0].Cells["price_date_str"].Value);
                //vm.mz_dept_no = this.dgvDeposit.SelectedRows[0].Cells["mz_dept_no"].Value.ToString();
                // vm.price_date = DateTime.Now;

                

                var aa = new
                {
                    patient_id = vm.patient_id,
                    ledger_sn = vm.ledger_sn,
                    times = vm.times,
                    cheque_type = vm.cheque_type,
                    item_no = vm.item_no,
                    charge = vm.charge,
                    opera = SessionHelper.uservm.user_mi
                };


                var data = WebApiHelper.SerializeObject(aa);
                HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string paramurl2 = string.Format($"/api/GuaHao/Refund?patient_id={aa.patient_id}&times={aa.times}&opera={SessionHelper.uservm.user_mi}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl2);

                string res = SessionHelper.MyHttpClient.PostAsync(paramurl2, httpContent).Result.Content.ReadAsStringAsync().Result;
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);
                if (responseJson.data == 1)
                {
                    UIMessageTip.ShowOk("退号成功!");
                }
                else
                {
                    UIMessageBox.ShowError(responseJson.message);
                    log.Info(responseJson.message);
                }
                BindGridView();
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.Message);
            }

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            string barcode = this.txtCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return;
            }

            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={barcode}");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
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
                }
                else
                {
                    log.Info(response.ReasonPhrase);
                }

                var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;

                if (listApi != null && listApi.Count > 0)
                {
                    userInfo = listApi[0];
                    if (string.IsNullOrEmpty(userInfo.name))
                    {
                        return;
                    }

                    lblhidid.Text = userInfo.patient_id.ToString();
                    lblName.Text = userInfo.name.ToString();
                    lblAge.Text = userInfo.age.ToString();
                    lblSex.Text = userInfo.sex == "1" ? "男" : "女";

                    BindGridView();
                }
                else
                {

                    var lis = new List<GhRefundVM>();
                    this.dgvDeposit.DataSource = lis.Select(p => new
                    {
                        p.gh_date_str,
                        //p.visit_dept,
                        p.unit_name,
                        p.visit_flag_name,
                        p.times,
                        p.ampm,
                        p.charge,
                        //p.charge_type,
                        p.cheque_name,
                        p.cheque_no,
                        p.clinic_name,
                        p.doctor_name,
                        p.group_name,
                        p.cheque_type,
                        p.ledger_sn,
                        p.item_no
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());
            }
        }

        public void BindGridView()
        {

            //查询列表
            var datestr = dtprq.Value.ToString("yyyy-MM-dd");
            var patient_id = lblhidid.Text;
            Task<HttpResponseMessage> task = null; var json = "";
            var paramurl = string.Format($"/api/GuaHao/GetGhRefund?datestr={datestr}&patient_id={patient_id}");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
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
                }
                else
                {
                    log.Info(response.ReasonPhrase);
                }
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhRefundVM>>>(json);
                if (result.data == null || result.data.Count == 0)
                {
                    var lis = new List<GhRefundVM>();
                    this.dgvDeposit.DataSource = lis.Select(p => new
                    {
                        p.gh_date_str,
                        //p.visit_dept,
                        p.unit_name,
                        p.visit_flag_name,
                        p.times,
                        p.ampm,
                        p.charge,
                        //p.charge_type,
                        p.cheque_name,
                        p.cheque_no,
                        p.clinic_name,
                        p.doctor_name,
                        p.group_name,
                        p.cheque_type,
                        p.ledger_sn,
                        p.item_no,
                        p.receipt_sn
                    }).ToList();
                    return;
                }

                foreach (var item in result.data)
                {
                    paramurl = string.Format($"/api/GuaHao/GetGhDepositByStatus?pid={patient_id}&times={item.times}&status=7&cheque_type={item.cheque_type}&item_no={item.item_no}");

                    log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                    task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                    task.Wait();
                    response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var read = response.Content.ReadAsStringAsync();
                        read.Wait();
                        json = read.Result;
                    }
                    else
                    {
                        log.Info(response.ReasonPhrase);
                    }
                    var lst = WebApiHelper.DeserializeObject<ResponseResult<List<GhDepositVM>>>(json).data;
                    if (lst.Count > 0)
                    {
                        item.visit_flag_name = "已退号";
                    }
                }
                var list = result.data;

                //整理数据，便于审阅
                string times = "";
                foreach (var item in list)
                {
                    if (item.times != times)
                    {
                        times = item.times;
                    }
                    else
                    {
                        item.gh_date = DateTime.MinValue;
                        item.unit_name = "";
                        item.group_name = "";
                        //item.visit_flag_name = "";
                        item.times = "";
                        item.doctor_name = "";
                        item.ampm = "";
                        item.cheque_type = "";
                        item.clinic_name = "";
                    }
                }

                var viewlist = list.Select(p => new
                {
                    p.gh_date_str,
                    //p.visit_dept,
                    p.unit_name,
                    p.visit_flag_name,
                    p.times,
                    p.ampm,
                    p.charge,
                    //p.charge_type,
                    p.cheque_name,
                    p.cheque_no,
                    p.clinic_name,
                    p.doctor_name,
                    p.group_name,
                    p.cheque_type,
                    p.ledger_sn,
                    p.item_no,
                    p.receipt_sn
                }).ToList();



                this.dgvDeposit.DataSource = viewlist;
                this.dgvDeposit.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            this.txtCode.Text = "";
            this.lblAge.Text = "";
            this.lblhidid.Text = "";
            this.lblName.Text = "";
            this.lblSex.Text = "";

            this.dtprq.Value = DateTime.Now;
        }

        private void dtprq_ValueChanged(object sender, DateTime value)
        {
            if (!string.IsNullOrWhiteSpace(txtCode.Text.Trim()))
            {
                BindGridView();
            }

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblAge_Click(object sender, EventArgs e)
        {

        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnCashRefund_Click(object sender, EventArgs e)
        {
            if (this.dgvDeposit.SelectedRows.Count == 0)
            {
                UIMessageTip.ShowWarning("没有记录!");
                return;
            }

            try
            {
                GhDepositVM vm = new GhDepositVM();
                vm.sname = this.dgvDeposit.SelectedRows[0].Cells["visit_flag_name"].Value.ToString();
                if (vm.sname == "已退号")
                {
                    UIMessageTip.ShowWarning("此记录已经退号!");
                    return;
                }

                vm.patient_id = lblhidid.Text;
                vm.ledger_sn = Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["ledger_sn"].Value);
                // vm.times = Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["times"].Value);

                vm.times = 0;
                var sel_index = dgvDeposit.SelectedIndex;
                while (vm.times == 0)
                {
                    var cel_value = this.dgvDeposit.Rows[sel_index].Cells["times"].Value.ToString();
                    if (cel_value == null || cel_value.ToString() == "")
                    {
                        sel_index--;
                    }
                    else
                    {
                        vm.times = Convert.ToInt32(cel_value);
                    }
                }
                //vm.charge = Convert.ToDecimal(this.dgvDeposit.SelectedRows[0].Cells["charge"].Value);
                //vm.cheque_type = Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["cheque_type"].Value);
                //vm.cheque_no = Convert.ToString(this.dgvDeposit.SelectedRows[0].Cells["cheque_no"].Value);
                //vm.item_no = Convert.ToInt32(this.dgvDeposit.SelectedRows[0].Cells["item_no"].Value);

                var je = (double)vm.charge;

                //if (UIMessageBox.ShowAsk("本次退款金额：" + vm.charge + "元，是否确定？"))
                if (UIMessageBox.ShowAsk("进行现金退款，是否确定？"))
                {
                    var aa = new
                    {
                        patient_id = vm.patient_id,
                        ledger_sn = vm.ledger_sn,
                        times = vm.times,
                        cheque_type = vm.cheque_type,
                        item_no = vm.item_no,
                        charge = vm.charge,
                        opera = SessionHelper.uservm.user_mi
                    };


                    var data = WebApiHelper.SerializeObject(aa);
                    HttpContent httpContent = new StringContent(data);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    string paramurl2 = string.Format($"/api/GuaHao/Refund?patient_id={aa.patient_id}&times={aa.times}&opera={SessionHelper.uservm.user_mi}&manual=1");

                    log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl2);

                    string res = SessionHelper.MyHttpClient.PostAsync(paramurl2, httpContent).Result.Content.ReadAsStringAsync().Result;
                    var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);
                    if (responseJson.data == 1)
                    {
                        UIMessageTip.ShowOk("退号成功!");
                    }
                    else
                    {
                        UIMessageBox.ShowError(responseJson.message);
                        log.Info(responseJson.message);
                    }
                    BindGridView();
                }


            }
            catch (Exception ex)
            {

            }

        }

        private void dgvDeposit_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //if (e.RowIndex >= dgvDeposit.Rows.Count - 1)
            //{
            //    return;
            //}
            DataGridViewRow dr = (sender as UIDataGridView).Rows[e.RowIndex];

            if (dr.Cells["visit_flag_name"].Value.ToString() == "已退号")
            {
                // 设置单元格的背景色
                //dr.DefaultCellStyle.BackColor = Color.Yellow;
                // 设置单元格的前景色
                dr.DefaultCellStyle.ForeColor = Color.Gray;
            }
            else
            {
                dr.DefaultCellStyle.ForeColor = Color.Green;
                // dr.DefaultCellStyle.BackColor = Color.Blue;
                //dr.DefaultCellStyle.ForeColor = Color.White;
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
    }
}
