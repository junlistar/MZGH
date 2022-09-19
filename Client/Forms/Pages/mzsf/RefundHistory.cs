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
                    List<CprChargesVM> new_data = new List<CprChargesVM>();

                    //查询出对应的部分退费生成的新纪录的ledger_sn GetRefundNewRecordLedgerSn(int ledger_sn)
                    paramurl = string.Format($"/api/mzsf/GetRefundNewRecordLedgerSn?ledger_sn={Math.Abs(ledger_sn)}");
                    json = HttpClientUtil.Get(paramurl);
                    var ledger_result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);

                    if (ledger_result.status == 1 && ledger_result.data > 0)
                    {
                        var next_ledger_sn = ledger_result.data;

                        //查询部分退款，重新生成的数据，做比较得到退款的数据项目
                        paramurl = string.Format($"/api/mzsf/GetDrugDetails?p_id={p_id}&ledger_sn={next_ledger_sn}&tbl_flag={tbl_flag}");
                        json = HttpClientUtil.Get(paramurl);
                        var new_result = WebApiHelper.DeserializeObject<ResponseResult<List<CprChargesVM>>>(json);
                        new_data = new_result.data;
                    }
                    foreach (var item in result.data)
                    {
                        if (new_data.Where(p => p.charge_code == item.charge_code).Count() > 0)
                        {
                            item.is_delete = false;
                        }
                        else
                        {
                            item.is_delete = true;
                            refund_charge += item.total_price;
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
                        sum_total = p.total_price,
                        charge_code = p.charge_code,
                        order_type = p.order_type,
                        is_delete = p.is_delete,

                    }).ToList();

                    //dgvCpr.Init();
                    dgvCpr.DataSource = list;
                    dgvCpr.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    dgvCpr.AutoGenerateColumns = false;
                    dgvCpr.AutoResizeColumns();

                    //退款金额处理
                    lblZongji.Text = result.data.Sum(p => p.total_price).ToString();
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
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
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
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }



        private void RefundConfirm_Load(object sender, EventArgs e)
        {
            lblZongji.Text = total_charge.ToString();
            lblTuikuan.Text = total_charge.ToString();

            lblZongji.Text = total_charge.ToString();
            lblTuikuan.Text = "0";

            dgvCpr.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;

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
            try
            {

                if (e.RowIndex != -1)
                {
                    var is_delete = Convert.ToBoolean(dgvCpr.Rows[e.RowIndex].Cells["is_delete"].Value);
                    if (is_delete)
                    {
                        dgvCpr.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        //dgvCpr.Rows[e.RowIndex].Cells["charge_name"].Style.Font = new Font("微软雅黑",12, FontStyle.Strikeout);
                        dgvCpr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Strikeout);
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void RefundHistory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
