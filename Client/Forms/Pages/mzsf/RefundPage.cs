using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;

namespace Mzsf.Forms.Pages
{
    public partial class RefundPage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(RefundPage));//typeof放当前类

        List<MzOrderReceiptVM> ds = new List<MzOrderReceiptVM>();
        public RefundPage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearDataBind();
            Search();

        }

        public void Search()
        {
            ds = new List<MzOrderReceiptVM>();

            var cash_opera = SessionHelper.uservm.user_mi;
            var begin_date = txtBeginDate.Value.ToString("yyyy-MM-dd 00:00:00");
            var end_date = txtEndDate.Value.ToString("yyyy-MM-dd 23:59:59");
            var bar_code = txtBarcode.Text.Trim();

            string status = "%";
            if (cbxRefundStatus.Text == "收费")
            {
                status = "4";
            }
            else if (cbxRefundStatus.Text == "退款")
            {
                status = "7";
            }

            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetReceipts?cash_opera={cash_opera}&begin_date={begin_date}&end_date={end_date}&bar_code={bar_code}&status={status}");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzOrderReceiptVM>>>(json);
                if (result.status == 1)
                {
                    ds = result.data;
                }
                else
                {
                    log.Error(result.message);
                }
                BindDgvDate();

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
            finally
            {

            }
        }

        private void BindDgvDate()
        {
            dgvRefund.Init();

            var list = ds.Select(p => new
            {
                patient_id = p.patient_id,
                patient_name = p.patient_name,
                p_bar_code = p.p_bar_code,
                receipt_no = p.receipt_no,
                receipt_sn = p.receipt_sn,
                cash_opera = p.cash_opera,
                cash_date = p.cash_date,
                times = p.times,
                ledger_sn = p.ledger_sn,
                charge_total = p.charge_total,
                charge_status = p.charge_status,
                cheque_type_name = p.cheque_type_name,
                cash_name = p.cash_name,
            }).ToList();

            dgvRefund.DataSource = list;
            dgvRefund.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRefund.AutoGenerateColumns = false;
            dgvRefund.AutoResizeColumns();

            lblTotalCount.ForeColor = Color.Red;

            var zje = list.Sum(p => p.charge_total);
            var jkcs = list.Count(p => p.charge_total > 0);
            var tkcs = list.Count(p => p.charge_total < 0);
            lblTotalCount.Text = $" 缴款次数：{jkcs}人次， 退款次数：{tkcs}人次， 实收金额：{zje} 元";
        }

        private void RefundPage_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            lblNodata.Visible = false;

            txtBeginDate.Value = DateTime.Now;
            txtEndDate.Value = DateTime.Now;

            txtBarcode.Text = "";

            cbxRefundStatus.Text = "全部";

            ClearDataBind();
        }

        public void ClearDataBind()
        {
            dgvRefund.DataSource = null;

            lblPatientId.Text = "";
            lblName.Text = "";
            lblTimes.Text = "";
            lblReceiptNo.Text = "";
            lblRecriptSn.Text = "";
            lblDateTime.Text = "";
            lblPayType.Text = "";
            lblCharge.Text = "";
        }

        private void dgvRefund_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var dat = ds[e.RowIndex];
                lblPatientId.Text = dat.patient_id;
                lblName.Text = dat.patient_name;
                lblTimes.Text = dat.times.ToString();
                lblReceiptNo.Text = dat.receipt_no;
                lblRecriptSn.Text = dat.receipt_sn;
                lblDateTime.Text = dat.cash_date.ToString("yyyy-MM-dd HH:mm:ss");
                lblPayType.Text = dat.cheque_type_name.Replace(") ", ")\r\n"); ;
                lblCharge.Text = dat.charge_total.ToString();


                //处方详情数据
                //BindDrugDetails(dat.patient_id, dat.ledger_sn, dat.tableflag);

            }
        }


        private void btnHuajia_Click(object sender, EventArgs e)
        {
            var index = dgvRefund.SelectedIndex;
            if (index != -1)
            {
                var dat = ds[index];

                if (!string.IsNullOrEmpty(dat.backfee_date) || dat.charge_total < 0)
                {
                    UIMessageTip.ShowWarning("该记录已经退号！");
                    return;
                }


                //弹出支付详情，进行退款 
                RefundConfirm refundConfirm = new RefundConfirm();
                refundConfirm.total_charge = Math.Round(dat.charge_total, 2);
                refundConfirm.patient_id = dat.patient_id;
                refundConfirm.ledger_sn = dat.ledger_sn;
                refundConfirm.receipt_no = dat.receipt_no;
                refundConfirm.receipt_sn = dat.receipt_sn;

                //关闭 刷新
                refundConfirm.FormClosed += RefundConfirm_FormClosed;

                refundConfirm.ShowDialog();
            }
        }

        private void RefundConfirm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearDataBind();
            Search();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRefund_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var charge_total = Convert.ToDecimal(dgvRefund.Rows[e.RowIndex].Cells["charge_total"].Value);
                if (charge_total < 0)
                {
                    dgvRefund.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void dgvRefund_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var dat = ds[e.RowIndex];
                //lblPatientId.Text = dat.patient_id;
                //lblName.Text = dat.patient_name;
                //lblTimes.Text = dat.times.ToString();
                //lblReceiptNo.Text = dat.receipt_no;
                //lblRecriptSn.Text = dat.receipt_sn;
                //lblDateTime.Text = dat.cash_date.ToString("yyyy-MM-dd HH:mm:ss");
                //lblPayType.Text = dat.cheque_type_name;
                //lblCharge.Text = dat.charge_total.ToString();

                if (dat.charge_total < 0)
                {
                    var times = dat.times;
                    var ledger_sn = dat.ledger_sn;
                    var receipt_no = dat.receipt_no;
                    var receipt_sn = dat.receipt_sn;
                    var patient_id = dat.patient_id;

                    RefundHistory refundHistory = new RefundHistory();

                    refundHistory.total_charge = Math.Round(dat.charge_total, 2);
                    refundHistory.patient_id = dat.patient_id;
                    refundHistory.ledger_sn = dat.ledger_sn;
                    refundHistory.receipt_no = dat.receipt_no;
                    refundHistory.receipt_sn = dat.receipt_sn;
                    refundHistory.tbl_flag = dat.tableflag;

                    refundHistory.ShowDialog();
                }
                else
                {
                    UIMessageTip.ShowWarning("请选择退款数据进行查看！");
                }

                //处方详情数据
                //BindDrugDetails(dat.patient_id, dat.ledger_sn, dat.tableflag);

            }
        }

        private void btnRefundDetail_Click(object sender, EventArgs e)
        {
            var index = dgvRefund.SelectedIndex;
            if (index != -1)
            {
                var dat = ds[index];
                if (dat.charge_total < 0)
                {
                    var times = dat.times;
                    var ledger_sn = dat.ledger_sn;
                    var receipt_no = dat.receipt_no;
                    var receipt_sn = dat.receipt_sn;
                    var patient_id = dat.patient_id;

                    RefundHistory refundHistory = new RefundHistory();

                    refundHistory.total_charge = Math.Round(dat.charge_total, 2);
                    refundHistory.patient_id = dat.patient_id;
                    refundHistory.ledger_sn = dat.ledger_sn;
                    refundHistory.receipt_no = dat.receipt_no;
                    refundHistory.receipt_sn = dat.receipt_sn;
                    refundHistory.tbl_flag = dat.tableflag;

                    refundHistory.ShowDialog();
                }
                else
                {
                    UIMessageTip.ShowWarning("请选择退款数据进行查看！");
                }

                //处方详情数据
                //BindDrugDetails(dat.patient_id, dat.ledger_sn, dat.tableflag);

            }
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearDataBind();
                Search();
            }
        }

        private void pnlTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
