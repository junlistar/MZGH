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
using Mzsf.ClassLib;
using Mzsf.ViewModel;
using Sunny.UI;

namespace Mzsf.Forms.Pages
{
    public partial class RefundHistory : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(RefundHistory));//typeof放当前类
        public RefundHistory()
        {
            InitializeComponent();
        }
        public decimal total_charge = 0;
        public decimal refund_charge = 0;
        public string patient_id = "";
        public int ledger_sn = 0;
        public string receipt_sn = "";
        public string receipt_no = "";

        public string tbl_flag = "";


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BindDrugDetails(string p_id, int ledger_sn, string tbl_flag)
        {

            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetDrugDetails?p_id={p_id}&ledger_sn={-ledger_sn}&tbl_flag={tbl_flag}");

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
                    //查询部分退款，重新生成的数据，做比较得到退款的数据项目
                    paramurl = string.Format($"/api/mzsf/GetDrugDetails?p_id={p_id}&ledger_sn={-ledger_sn + 1}&tbl_flag={tbl_flag}");
                    task = SessionHelper.MyHttpClient.GetAsync(paramurl);
                    task.Wait();
                    response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var read = response.Content.ReadAsStringAsync();
                        read.Wait();
                        json = read.Result;
                    }
                    var new_result = WebApiHelper.DeserializeObject<ResponseResult<List<CprChargesVM>>>(json);

                    foreach (var item in result.data)
                    {
                        if (new_result.data.Where(p => p.charge_code == item.charge_code).Count() > 0)
                        {
                            item.is_delete = false;
                        }
                        else
                        {
                            item.is_delete = true;
                            refund_charge += item.sum_total;
                        }
                    }

                    var list = result.data.Select(p => new
                    { 
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
                        is_delete = p.is_delete,

                    }).ToList();
                    //dgvCpr.Init();
                    dgvCpr.DataSource = list;
                    dgvCpr.ShowGridLine = true;
                    dgvCpr.AutoResizeColumns();

                    //退款金额处理
                    lblZongji.Text = result.data.Sum(p => p.sum_total).ToString();
                    lblTuikuan.Text = refund_charge.ToString();
                    //lblTuikuan.Text = result.data.Sum(p => p.sum_total).ToString();
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

        public void SelectNewLedgerData(string p_id, int ledger_sn, string tbl_flag)
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



        private void RefundConfirm_Load(object sender, EventArgs e)
        {
            lblZongji.Text = total_charge.ToString();
            lblTuikuan.Text = total_charge.ToString();

            lblZongji.Text = total_charge.ToString();
            lblTuikuan.Text = "0";


            BindDrugDetails(patient_id, ledger_sn, tbl_flag);
        }


        private void btnBufenTuikuan_Click(object sender, EventArgs e)
        {
            RefundApart refundApart = new RefundApart();
            refundApart.patient_id = patient_id;
            refundApart.ledger_sn = ledger_sn;
            refundApart.receipt_no = receipt_no;
            refundApart.receipt_sn = receipt_sn;
            refundApart.ShowDialog();
            this.Close();
        }

        private void dgvCpr_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                var is_delete = Convert.ToBoolean(dgvCpr.Rows[e.RowIndex].Cells["is_delete"].Value);
                if (is_delete)
                {
                    dgvCpr.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    //dgvCpr.Rows[e.RowIndex].Cells["charge_name"].Style.Font = new Font("微软雅黑",12, FontStyle.Strikeout);
                    dgvCpr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("微软雅黑",12, FontStyle.Strikeout);
                }
            }
        }
    }
}
