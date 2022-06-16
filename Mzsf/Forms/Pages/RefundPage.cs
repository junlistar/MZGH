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
            dgvRefund.DataSource = ds;
            dgvRefund.ShowGridLine = true;
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
        }

        private void dgvRefund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRefund_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
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
                BindDrugDetails(dat.patient_id, dat.ledger_sn,dat.tableflag);
                
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

                    dgvCpr.DataSource = list;

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

        }
    }
}
