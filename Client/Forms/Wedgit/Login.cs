using Client.ClassLib;
using Client.ViewModel;
using log4net;
using Sunny.UI;
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

namespace Client.Forms.Wedgit
{
    public partial class Login : Form
    {
        private static ILog log = LogManager.GetLogger(typeof(Login));//typeof放当前类
        public bool IsLogin = false;

        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtName.Text.Trim();
            var password = txtPwd.Text.Trim();



            if (string.IsNullOrWhiteSpace(username))
            {
                UIMessageTip.ShowWarning("请输入登录名!"); txtName.Focus();
                return;
            }

            try
            {
                Task<HttpResponseMessage> task = null;
                string json = "";
                string paramurl = string.Format($"/api/GuaHao/GetLoginUser?uname={username}&pwd={password}");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                else
                {
                    log.Info(" 访问登录接口失败!" + json);
                    UIMessageTip.ShowWarning(" 访问登录接口失败!");
                    return;
                }
                var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<LoginUsersVM>>>(json);

                if (listApi.data != null && listApi.data.Count > 0)
                {
                    SessionHelper.uservm = listApi.data[0];
                    IsLogin = true;
                    this.Close();
                }
                else
                {
                    UIMessageTip.ShowWarning(" 登录名或密码有误!");
                    return;
                }

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                {
                    log.Error(ex.InnerException.InnerException.Message.ToString());
                    UIMessageTip.ShowError(ex.InnerException.InnerException.Message);
                }
                else
                {
                    log.Error(ex.InnerException.ToString());
                    UIMessageTip.ShowError(ex.InnerException.Message);
                }

                return;
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPwd.Focus();
            }
        }

        private void txtPwd_KeyUp(object sender, KeyEventArgs e)
        {
            btnLogin_Click(sender, e);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
