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

namespace Client.Forms.Pages.cwgl
{
    public partial class GuahaoRijie : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(GuaHao));//typeof放当前类
        public GuahaoRijie()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuahaoRijie_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;

            GetGhDailyReport();  
        }
         
        public void GetGhDailyReport()
        {
            try
            {

                //查询当日扎帐记录
                //ResponseResult<List<string>> GetGhDailyReport(string opera, string report_date, string mz_dept_no)
                var d = new
                {
                    opera = SessionHelper.uservm.user_mi,
                    report_date = txtDate.Text,
                    mz_dept_no = "1"
                }; 

                var param = $"opera={d.opera}&report_date={d.report_date}&mz_dept_no={d.mz_dept_no}";

                var json = "";
                var paramurl = string.Format($"/api/cwgl/GetGhDailyReport?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                var task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<string>>>(json);
                cbxStatus.Clear();
                if (result.status == 1)
                {
                    if (result.data.Count>0&& result.data[0]!=null)
                    {
                        cbxStatus.Items.AddRange(result.data.ToArray());
                    }
                    else
                    {
                        cbxStatus.Items.Add("未结");
                        cbxStatus.SelectedIndex = 0;
                    }
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
    }
}
