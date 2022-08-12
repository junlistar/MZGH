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
    public partial class RefundApart : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(RefundConfirm));//typeof放当前类
        public RefundApart()
        {
            InitializeComponent();
        }
        public decimal total_charge = 0;
        public string patient_id = "";
        public int ledger_sn = 0;
        public string receipt_sn = "";
        public string receipt_no = "";

        public string tbl_flag = "";


        string refund_item_str = "";

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void RefundConfirm_Load(object sender, EventArgs e)
        {
            lblZongji.Text = total_charge.ToString();
            lblTuikuan.Text = "0";

            //ckall.Location = dgvCpr.Location;

            BindDrugDetails(patient_id, ledger_sn, tbl_flag);
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


        private void ckall_CheckedChanged(object sender, EventArgs e)
        {
            if (ckall.Checked)
            {
                for (int i = 0; i < dgvCpr.Rows.Count; i++)
                {
                    (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = true;
                    dgvCpr.Rows[i].Cells[0].Value = true;
                    (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = false;
                }
            }
            else
            {
                for (int i = 0; i < dgvCpr.Rows.Count; i++)
                {
                    (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = true;
                    dgvCpr.Rows[i].Cells[0].Value = false;
                    (dgvCpr.Rows[i].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = false;
                }
            }
            CalcTotalPrice();
        }

        public void CalcTotalPrice()
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


        private void dgvCpr_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowInde = e.RowIndex;
            if ((Convert.ToBoolean(dgvCpr.Rows[rowInde].Cells[0].Value) == true))
            {
                dgvCpr.Rows[rowInde].Cells[0].Value = "False";
            }
            else
            {
                dgvCpr.Rows[rowInde].Cells[0].Value = "True";
            }

            CalcTotalPrice();
        }

        private void btnXianjintui_Click(object sender, EventArgs e)
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

        public void RefundAll()
        {

            try
            {
                //todo:退款提交 
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
                    //SessionHelper.do_gh_print = true;
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
                log.Error(ex.ToString());

            }
        }


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
                    cheque_cash ="", //";14;11;12",
                    isall = "0",
                    refund_item_str= refund_item_str,
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
                log.Error(ex.ToString());

            }
        }

    }
}
