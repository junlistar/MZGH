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
    public partial class RequestTime : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(RequestTime));//typeof放当前类

        public RequestTime()
        {
            InitializeComponent();
        }

        private void RequestHour_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            cbx_ampm.DataSource = SessionHelper.requestHours;
            cbx_ampm.DisplayMember = "name";
            cbx_ampm.ValueMember = "code";

            GetData();
        }

        public void GetData()
        {
            try
            {
                //获取挂号时间段 
                var paramurl = string.Format($"/api/GuaHao/GetRequestTimes");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);
                var dat = WebApiHelper.DeserializeObject<ResponseResult<List<RequestTimeVM>>>(json).data;

                dgvRequestTime.Init();

                dgvRequestTime.DataSource = dat;

                dgvRequestTime.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgvRequestTime.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
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
            try
            {

                if (e.RowIndex != -1)
                {
                    txt_section.Text = dgvRequestTime.Rows[e.RowIndex].Cells["Section_number"].Value.ToString();
                    txtComment.Text = dgvRequestTime.Rows[e.RowIndex].Cells["Section_number_comment"].Value.ToString();
                    txt_start_time.Text = dgvRequestTime.Rows[e.RowIndex].Cells["start_time"].Value.ToString();
                    txt_end_time.Text = dgvRequestTime.Rows[e.RowIndex].Cells["end_time"].Value.ToString();

                    cbx_ampm.SelectedValue = dgvRequestTime.Rows[e.RowIndex].Cells["ampm"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var d = new
            {
                section = txt_section.Text,
                section_name = txtComment.Text,
                start_time = txt_start_time.Text,
                end_time = txt_end_time.Text,
                ampm = cbx_ampm.SelectedValue,

            };

            if (d.ampm != null && d.ampm.ToString() != "")
            {
                UIMessageTip.ShowError("请将数据填写完整！");
                return;
            }
            if (string.IsNullOrWhiteSpace(d.section) || string.IsNullOrWhiteSpace(d.section_name))
            {
                UIMessageTip.ShowError("请将数据填写完整！");
                return;
            }

            try
            {
                // EditRequestTime(string section, string section_name, string start_time, string end_time,string ampm)
                string time1 = d.start_time;
                string time2 = d.end_time;

                string paramurl = string.Format($"/api/GuaHao/EditRequestTime?section={d.section}&section_name={d.section_name}&start_time={d.start_time}&end_time={d.end_time}&ampm={d.ampm}");

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
                log.Error(ex.ToString());
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // DeleteRequestTime(string section)
            var d = new
            {
                section = txt_section.Text,
            };

            if (string.IsNullOrWhiteSpace(d.section))
            {
                UIMessageTip.ShowError("请选择数据项目进行操作！");
                return;
            }

            if (!UIMessageDialog.ShowAskDialog(this, "确定要进行删除操作吗？"))
            {
                return;
            }

            string paramurl = string.Format($"/api/GuaHao/DeleteRequestTime?section={d.section}");

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
                log.Error(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetTextData();


        }
        public void ResetTextData()
        {
            txt_section.Text = "";
            txtComment.Text = "";
            txt_start_time.Text = "00:00:00";
            txt_start_time.Text = "00:59:59";
        }
    }
}
