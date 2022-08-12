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


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         

        private void RefundConfirm_Load(object sender, EventArgs e)
        {
            lblZongji.Text = total_charge.ToString();
            lblTuikuan.Text = total_charge.ToString();


            // GetMzDepositsByPatientId(string patient_id, int ledger_sn)
             
            Task<HttpResponseMessage> task = null;
            string json = "";

            string paramurl = string.Format($"/api/mzsf/GetMzDepositsByPatientId?patient_id={patient_id}&ledger_sn={ledger_sn}");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzDepositVM>>>(json);
                if (result.status == 1)
                {
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
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
        }

        private void btnTuikuan_Click(object sender, EventArgs e)
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
                    cheque_cash = "",//"14;11;12"
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
                    SessionHelper.do_gh_print = true;
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
    }
}
