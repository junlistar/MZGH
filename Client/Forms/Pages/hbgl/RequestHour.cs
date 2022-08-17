using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using log4net;
using Sunny.UI;

namespace Client.Forms.Pages.hbgl
{
    public partial class RequestHour : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(RequestHour));//typeof放当前类

        public RequestHour()
        {
            InitializeComponent();
        }

        private void RequestHour_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            GetData();

            dgvRequestHour.Init();
            this.dgvRequestHour.DataSource = SessionHelper.requestHours;

            dgvRequestHour.CellBorderStyle = DataGridViewCellBorderStyle.Single;

        }


        public void GetData()
        {
            try
            {
                //获取挂号时间段 
                var paramurl = string.Format($"/api/GuaHao/GetRequestHours"); 
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);
                SessionHelper.requestHours = WebApiHelper.DeserializeObject<ResponseResult<List<RequestHourVM>>>(json).data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvRequestHour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtCode.Text = dgvRequestHour.Rows[e.RowIndex].Cells["code"].Value.ToString();
                txtName.Text = dgvRequestHour.Rows[e.RowIndex].Cells["name"].Value.ToString();
                cbxHour1.Text = dgvRequestHour.Rows[e.RowIndex].Cells["start_hour"].Value.ToString();
                cbxHour2.Text = dgvRequestHour.Rows[e.RowIndex].Cells["end_hour"].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var d = new
            {
                code = txtCode.Text,
                name = txtName.Text,
                start_hour = cbxHour1.Text,
                end_hour = cbxHour2.Text,

            };
            if (string.IsNullOrWhiteSpace(d.code) || string.IsNullOrWhiteSpace(d.name) || string.IsNullOrWhiteSpace(d.start_hour) || string.IsNullOrWhiteSpace(d.end_hour))
            {
                UIMessageTip.ShowError("请将数据填写完整！");
                return;
            }


            try
            {
                int hour1 = int.Parse(d.start_hour);
                int hour2 = int.Parse(d.end_hour);

                if (hour1 >= hour2)
                {
                    UIMessageTip.ShowWarning("开始小时数必须小于等于结束小时数！");
                    return;
                } 
                string paramurl = string.Format($"/api/GuaHao/EditRequestHour?code={d.code}&name={d.name}&start_hour={d.start_hour}&end_hour={d.end_hour}");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                if (result.status == 1)
                {
                    UIMessageTip.ShowOk("保存成功！"); ResetTextData();
                    BindData();
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var d = new
            {
                code = txtCode.Text,
            };

            if (string.IsNullOrWhiteSpace(d.code))
            {
                UIMessageTip.ShowError("请选择数据项目进行操作！");
                return;
            }

            if (!UIMessageDialog.ShowAskDialog(this, "确定要进行删除操作吗？"))
            {
                return;
            }
             
            string paramurl = string.Format($"/api/GuaHao/DeleteRequestHour?code={d.code}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                string json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                if (result.status == 1)
                {
                    UIMessageTip.ShowOk("删除成功！");
                    BindData();
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetTextData();


        }
        public void ResetTextData()
        {
            txtCode.Text = "";
            txtName.Text = "";
            cbxHour1.Text = "0";
            cbxHour2.Text = "23";
        }
    }
}
