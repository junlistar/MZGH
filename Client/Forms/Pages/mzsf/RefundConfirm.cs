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
using log4net;
using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;

namespace Mzsf.Forms.Pages
{
    public partial class RefundConfirm : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(RefundConfirm));//typeof放当前类
        public RefundConfirm()
        {
            InitializeComponent();
        }
        public decimal total_charge = 0;
        public string patient_id = "";
        public int ledger_sn = 0;
        public string receipt_sn = "";
        public string receipt_no = "";
        public string table_flag = "";

        string refund_item_str = "";

        List<MzDepositVM> deposit_list;
        PatientVM _patient;


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void RefundConfirm_Load(object sender, EventArgs e)
        {
            lblZongji.Text = total_charge.ToString();
            lblTuikuan.Text = total_charge.ToString();
            GetPatientInfo();
            //绑定支付信息
            BindDepositList(patient_id, ledger_sn);
            //绑定付款项目信息
            BindDrugDetails(patient_id, ledger_sn, table_flag);

        }
        public void GetPatientInfo()
        {
            try
            { 
                string paramurl = string.Format($"/api/GuaHao/GetPatientByPatientId?pid={patient_id}");

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);

                _patient = result.data[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }


        /// <summary>
        /// 退款处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTuikuan_Click(object sender, EventArgs e)
        {
            try
            {

                CalcTotalPrice();

                var je = Math.Round(decimal.Parse(lblTuikuan.Text), 2);

                if (je == 0)
                {
                    MessageBox.Show("请选择需要退款的处方细目！");
                    return;
                }

                string msg = "退款金额(￥)：" + je + "，是否确定？";

                if (UIMessageDialog.ShowAskDialog(this, msg))
                {
                    //提交部分退款
                    if (refund_item_str != "")
                    {
                        refund_item_str = refund_item_str.Substring(1);
                    }
                    else
                    {
                        MessageBox.Show("没有选择退款项目");
                        return;
                    }

                    if (lblZongji.Text == lblTuikuan.Text)
                    {
                        log.Debug("全部退款");
                        RefundAll();
                    }
                    else
                    {
                        log.Debug("部分退款");
                        RefundPart(refund_item_str);
                    }

                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        /// <summary>
        /// 全部退款
        /// </summary>
        public void RefundAll()
        {
            try
            {
                //各种支付退款处理
                if (deposit_list != null)
                {
                    //退款操作
                    foreach (var item in deposit_list)
                    {
                        if (!string.IsNullOrWhiteSpace(item.cheque_no))
                        {
                            log.Info("有外部订单号：" + item.cheque_no);

                            var page_model = SessionHelper.pageChequeCompares.Where(p => p.his_code == item.cheque_type).FirstOrDefault();

                            if (int.Parse(page_model.page_code) == (int)PayMethodEnum.WeiXin)
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
                            else if (int.Parse(page_model.page_code) == (int)PayMethodEnum.Yibao)
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
                                jscxRequest.insuplc_admdvs = _patient.yb_insuplc_admdvs.Trim();
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
                                _mzjscx.psn_no = item.psn_no;
                                _mzjscx.setl_id = item.setl_id;//结算返回值 
                                _mzjscx.mdtrt_id = item.mdtrt_id;

                                jscxRequest.input.data = _mzjscx;

                                var json = WebApiHelper.SerializeObject(jscxRequest);
                                var BusinessID = "2208";
                                var Dataxml = json;
                                var Outputxml = "";
                                var parm = new object[] { BusinessID, json, Outputxml };


                                YBHelper.AddYBLog(BusinessID, json, _patient.patient_id, jscxRequest.sign_no, jscxRequest.infver, 0, SessionHelper.uservm.user_mi, jscxRequest.inf_time);
                                //提交
                                ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                                log.Debug("结算撤销返回：" + parm[2]);
                                YBHelper.AddYBLog(BusinessID, parm[2].ToString(), _patient.patient_id, jscxRequest.sign_no, jscxRequest.infver, 1, SessionHelper.uservm.user_mi, jscxRequest.inf_time);

                                var _jscxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                            }
                        }
                    }


                    //提交数据库
                    var d = new
                    {
                        pid = patient_id,
                        ledger_sn = ledger_sn,
                        receipt_sn = receipt_sn,
                        receipt_no = receipt_no,
                        cheque_cash = ";14;11;12",
                        isall = "1",
                        opera = SessionHelper.uservm.user_mi
                    };
                    var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    string paramurl = string.Format($"/api/mzsf/BackFee?opera={d.opera}&pid={d.pid}&ledger_sn={d.ledger_sn}&receipt_sn={d.receipt_sn}&receipt_no={d.receipt_no}&cheque_cash={d.cheque_cash}&isall={d.isall}");

                    log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                    string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;

                    var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(responseJson);

                    if (result.status == 1 && result.data)
                    {
                        log.Info("退款成功");
                        UIMessageTip.ShowOk("退款成功!", 1500);
                        this.Close();
                        return;
                    }
                    else
                    {
                        log.Error(result.message);
                        UIMessageBox.ShowError(result.message);
                    }


                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        /// <summary>
        /// 部分退款，现金退
        /// </summary>
        /// <param name="refund_item_str"></param>
        public void RefundPart(string refund_item_str)
        {
            try
            {
                var d = new
                {
                    pid = patient_id,
                    ledger_sn = ledger_sn,
                    receipt_sn = receipt_sn,
                    receipt_no = receipt_no,
                    cheque_cash = "", //";14;11;12",
                    isall = "0",
                    refund_item_str = refund_item_str,
                    opera = SessionHelper.uservm.user_mi
                };
                var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string paramurl = string.Format($"/api/mzsf/BackFeePart?opera={d.opera}&pid={d.pid}&ledger_sn={d.ledger_sn}&receipt_sn={d.receipt_sn}&receipt_no={d.receipt_no}&cheque_cash={d.cheque_cash}&refund_item_str={d.refund_item_str}");

                log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;

                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(responseJson);

                if (result.status == 1 && result.data)
                {
                    log.Info("退款成功");
                    UIMessageTip.ShowOk("退款成功!", 1500);
                    this.Close();
                    return;
                }
                else
                {
                    log.Error(result.message);
                    UIMessageBox.ShowError(result.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void btnBufenTuikuan_Click(object sender, EventArgs e)
        {
            RefundApart refundApart = new RefundApart();
            refundApart.patient_id = patient_id;
            refundApart.ledger_sn = ledger_sn;
            refundApart.receipt_no = receipt_no;
            refundApart.receipt_sn = receipt_sn;
            refundApart.tbl_flag = table_flag;
            refundApart.ShowDialog();
            this.Close();
        }

        private void BindDepositList(string patient_id, int ledger_sn)
        {
            string paramurl = string.Format($"/api/mzsf/GetMzDepositsByPatientId?patient_id={patient_id}&ledger_sn={ledger_sn}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                string json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzDepositVM>>>(json);
                if (result.status == 1)
                {
                    deposit_list = result.data;
                    if (result.data.Count > 0)
                    {
                        var dat = result.data.Select(p => new
                        {
                            cheque_name = p.cheque_name,
                            amount = p.amount,
                            charge = p.charge,
                            refund_charge = p.refund_charge

                        }).ToList();
                        dgvDeposit.Init();
                        dgvDeposit.DataSource = dat;
                        dgvDeposit.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    }

                }
                else
                {
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void BindDrugDetails(string p_id, int ledger_sn, string tbl_flag)
        {

            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetDrugDetails?p_id={p_id}&ledger_sn={ledger_sn}&tbl_flag={tbl_flag}");

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
                }

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<CprChargesVM>>>(json);
                if (result.status == 1)
                {
                    var list = result.data.Select(p => new
                    {
                        chkback = 1,
                        back = p.back,
                        charge_amount = p.charge_amount,
                        charge_name = p.charge_name,
                        cf_amount = p.charge_amount,
                        caoyao_fu = p.caoyao_fu,
                        orig_price = p.orig_price,
                        charge_price = p.charge_price,
                        sum_total = p.sum_total,
                        charge_code = p.charge_code,
                        order_type = p.order_type,
                        confirm_flag = p.confirm_flag,
                        confirm_flag_str = p.confirm_flag_str,
                        confirm_name = p.confirm_name,
                        confirm_date = p.confirm_date
                    }).ToList();
                    dgvCpr.Init();
                    dgvCpr.DataSource = list;
                    dgvCpr.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    dgvCpr.AutoResizeColumns();
                    dgvCpr.Columns[0].Width = 75;

                    ////选择框处理
                    //for (int i = 0; i < this.dgvCpr.Rows.Count; i++)
                    //{
                    //    if (dgvCpr.Rows[i].Cells["chkback"].EditedFormattedValue.ToString().ToLower() == "false")
                    //    {
                    //        dgvCpr.Rows[i].Cells["chkback"].Value = "True";
                    //    }
                    //}


                    //退款金额处理
                    lblZongji.Text = result.data.Sum(p => p.sum_total).ToString();
                    lblTuikuan.Text = "0";
                    //lblTuikuan.Text = result.data.Sum(p => p.sum_total).ToString();

                    //默认选中可以退款的
                    DefaultSelect();
                }
                else
                {

                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
        private void ckall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckall.Checked)
                {
                    for (int i = 0; i < dgvCpr.Rows.Count; i++)
                    {
                        if (dgvCpr.Rows[i].Cells["confirm_flag_str"].Value != null && dgvCpr.Rows[i].Cells["confirm_flag_str"].Value.ToString() != "")
                        {
                            continue;
                        }
                        (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = true;
                        dgvCpr.Rows[i].Cells[0].Value = true;
                        (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = false;
                    }
                }
                else
                {
                    for (int i = 0; i < dgvCpr.Rows.Count; i++)
                    {
                        if (dgvCpr.Rows[i].Cells["confirm_flag_str"].Value != null && dgvCpr.Rows[i].Cells["confirm_flag_str"].Value.ToString() != "")
                        {
                            continue;
                        }
                        (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = true;
                        dgvCpr.Rows[i].Cells[0].Value = false;
                        (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = false;
                    }
                }
                CalcTotalPrice();
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        public void CalcTotalPrice()
        {
            try
            {
                refund_item_str = "";
                decimal t_price = 0;//总计金额
                for (int i = 0; i < dgvCpr.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvCpr.Rows[i].Cells[0].Value))
                    {
                        var charge = Convert.ToDecimal(dgvCpr.Rows[i].Cells["sum_total"].Value);
                        t_price += charge;

                        var order_type = dgvCpr.Rows[i].Cells["order_type"].Value;
                        var charge_code = dgvCpr.Rows[i].Cells["charge_code"].Value;
                        refund_item_str += "," + order_type + "-" + charge_code + "-" + charge;
                    }
                }
                lblTuikuan.Text = t_price.ToString();
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }


        private void dgvCpr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                if (colIndex == 0 && rowIndex != -1)
                {
                    // MessageBox.Show(this.dgvCpr.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString());
                    //if (dgvCpr.Rows[rowIndex].Cells["confirm_flag"].Value != null && Convert.ToInt32(dgvCpr.Rows[rowIndex].Cells["confirm_flag"].Value) == 1)

                    if (dgvCpr.Rows[rowIndex].Cells["confirm_flag_str"].Value != null && dgvCpr.Rows[rowIndex].Cells["confirm_flag_str"].Value.ToString() != "")
                    {
                        UIMessageTip.Show("该项目已确认，不能退费");
                        return;
                    }

                    (dgvCpr.Rows[rowIndex].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = true;
                    //if (dgvCpr.Rows[rowIndex].Cells["confirm_flag"].Value != null && Convert.ToInt32(dgvCpr.Rows[rowIndex].Cells["confirm_flag"].Value) == 1)
                    if (dgvCpr.Rows[rowIndex].Cells[0].Value != null && Convert.ToBoolean(dgvCpr.Rows[rowIndex].Cells[0].Value))
                    {
                        //dgvCpr.Rows[rowIndex].Cells["confirm_flag"].Value = "0";
                        dgvCpr.Rows[rowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        //dgvCpr.Rows[rowIndex].Cells["confirm_flag"].Value = "1";
                        dgvCpr.Rows[rowIndex].Cells[0].Value = true;
                    }
                   (dgvCpr.Rows[rowIndex].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = false;

                    CalcTotalPrice();
                }
                return;
                //int rowInde = e.RowIndex;
                //int colIndex = e.ColumnIndex;
                //if (colIndex < 0 || rowInde < 0)
                //{
                //    return;
                //}

                //if (dgvCpr.Rows[rowInde].Cells["confirm_flag"].Value != null && Convert.ToInt32(dgvCpr.Rows[rowInde].Cells["confirm_flag"].Value) == 1)
                //{
                //    UIMessageTip.Show("该项目已确认，不能退费");
                //    return;
                //}

                //if ((Convert.ToBoolean(dgvCpr.Rows[rowInde].Cells[0].Value) == true))
                //{
                //    dgvCpr.Rows[rowInde].Cells[0].Value = "False";
                //}
                //else
                //{
                //    dgvCpr.Rows[rowInde].Cells[0].Value = "True";
                //}

                //CalcTotalPrice();
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        public void DefaultSelect()
        {
            try
            {
                if (dgvCpr.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvCpr.Rows)
                    {
                        //if (row.Cells["confirm_flag"].Value == null || Convert.ToInt32(row.Cells["confirm_flag"].Value) != 1)

                        if (row.Cells["confirm_flag_str"].Value== null ||row.Cells["confirm_flag_str"].Value.ToString() == "")
                        {
                            row.Cells[0].Value = "True";
                        }
                        else
                        {
                            row.Cells[0].ReadOnly = true;
                        }
                    }
                    CalcTotalPrice();
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void RefundConfirm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
