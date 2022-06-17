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
using Mzsf.ClassLib;
using Mzsf.ViewModel;
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

            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetReceipts?cash_opera={cash_opera}&begin_date={begin_date}&end_date={end_date}");

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
                patient_id =p.patient_id,
                patient_name = p.patient_name,
                p_bar_code = p.p_bar_code,
                receipt_no = p.receipt_no,
                receipt_sn = p.receipt_sn,
                cash_opera = p.cash_opera,
                cash_date = p.cash_date,
                times = p.times,
                //ledger_sn = p.ledger_sn,
                charge_total = p.charge_total,
                charge_status  = p.charge_status,
                cheque_type_name = p.cheque_type_name,
                cash_name = p.cash_name,
            }).ToList();

            dgvRefund.DataSource = list;
            dgvRefund.ShowGridLine = true;
            dgvRefund.AutoResizeColumns();

           
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
            txtFilterValue.Text = "";
            cbxType.Text = "";

            txtBeginDate.Value = DateTime.Now;
            txtEndDate.Value = DateTime.Now;


            ClearDataBind();
        }

        public void ClearDataBind()
        {
            dgvCpr.DataSource = null;
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

        private void dgvRefund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                lblPayType.Text = dat.cheque_type_name;
                lblCharge.Text = dat.charge_total.ToString();

                //处方详情数据
                BindDrugDetails(dat.patient_id, dat.ledger_sn, dat.tableflag);

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

                    }).ToList();
                    dgvCpr.Init();
                    dgvCpr.DataSource = list;
                    dgvCpr.ShowGridLine = true;

                    //选择框处理
                    for (int i = 0; i < this.dgvCpr.Rows.Count; i++)
                    {
                        if (dgvCpr.Rows[i].Cells["chkback"].EditedFormattedValue.ToString().ToLower() == "false")
                        {
                            dgvCpr.Rows[i].Cells["chkback"].Value = "True";
                        }
                    }
                }
                else
                {

                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
        }

        private void btnHuajia_Click(object sender, EventArgs e)
        {
            var index = dgvRefund.SelectedIndex;
            if (index != -1)
            {
                var dat = ds[index];

                if (!string.IsNullOrEmpty(dat.backfee_date))
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
                refundConfirm.Show();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
