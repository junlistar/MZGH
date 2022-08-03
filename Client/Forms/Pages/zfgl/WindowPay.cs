using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Client.ClassLib;
using Client.ViewModel;
using log4net; 

namespace Client.Forms.Pages.zfgl
{
    public partial class WindowPay : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(WindowPay));//typeof放当前类
        public WindowPay()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            var cash_opera = SessionHelper.uservm.user_mi;
            var begin_date = txtBeginDate.Value.ToString("yyyy-MM-dd 00:00:00");
            var end_date = txtEndDate.Value.ToString("yyyy-MM-dd 23:59:59");
            var bar_code = txtBarcode.Text.Trim();
            var cheque_type = "6";

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
            string paramurl = string.Format($"/api/guahao/GetThirdPayList?bengin={begin_date}&end={end_date}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                var json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<DepositVM>>>(json);
                if (result.status == 1)
                {
                    var ds = result.data;
                    dgv_paylist.DataSource = ds;
                    dgv_paylist.AutoResizeColumns();
                }
                else
                {
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                log.Error("请求接口数据出错：" + ex.Message);
                log.Error(ex.StackTrace);
            }
            finally
            {

            }
        }

        private void WindowPay_Initialize(object sender, EventArgs e)
        {

            txtBeginDate.Value = DateTime.Now;
            txtEndDate.Value = DateTime.Now;
        }
    }
}
