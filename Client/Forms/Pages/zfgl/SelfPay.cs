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

namespace Client.Forms.Pages.zfgl
{
    public partial class SelfPay : UIPage
    {
        public SelfPay()
        {
            InitializeComponent();
        }

        private void SelfPay_Initialize(object sender, EventArgs e)
        {

            txtBeginDate.Value = DateTime.Now;
            txtEndDate.Value = DateTime.Now;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuajia_Click(object sender, EventArgs e)
        {
            try
            {

                var _rowIndex = dgv_paylist.SelectedIndex;
                if (_rowIndex == -1)
                {
                    UIMessageTip.Show("未选择数据！");
                    return;
                }

                //todo:第三方退费操作
                //todo:

                var patient_id = dgv_paylist.Rows[_rowIndex].Cells["patient_id"].Value.ToString();
                var cheque_type = dgv_paylist.Rows[_rowIndex].Cells["cheque_type"].Value.ToString();
                var cheque_no = dgv_paylist.Rows[_rowIndex].Cells["cheque_no"].Value.ToString();
                var charge = dgv_paylist.Rows[_rowIndex].Cells["charge"].Value.ToString();
                var price_date = dgv_paylist.Rows[_rowIndex].Cells["price_date"].Value.ToString();
                var status = dgv_paylist.Rows[_rowIndex].Cells["status"].Value;

                if (status != null && status.ToString() == "HIS支付失败")
                {
                    price_date = Convert.ToDateTime(price_date).ToString("yyyy-MM-dd HH:mm:ss");

                    //获取数据  RefundMzThridPay(string patient_id, string cheque_type, string cheque_no, string charge, string price_date) 
                    string paramurl = string.Format($"/api/mzsf/RefundMzThridPay?patient_id={patient_id}&cheque_type={cheque_type}&cheque_no={cheque_no}&charge={charge}&price_date={price_date}");

                    log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);

                    var json = HttpClientUtil.Get(paramurl);


                    var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);
                    if (result.status == 1)
                    {
                        UIMessageTip.Show("退费成功");
                    }
                    else
                    {
                        UIMessageTip.Show(result.message);
                        log.Error(result.message);
                    }

                }
                else
                {
                    UIMessageTip.Show("该数据不能执行退款操作！");
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
    }
}
