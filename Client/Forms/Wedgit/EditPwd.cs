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
using log4net;
using Client.ClassLib;
using Client.ViewModel;

namespace Client.Forms.Wedgit
{
    public partial class EditPwd : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(EditPwd));//typeof放当前类
        LoginUsersVM loginUsers;

        public EditPwd()
        {
            InitializeComponent();
        }

        private void EditPwd_Load(object sender, EventArgs e)
        {
            #region 初始化控件
            pnl1.Show();
            pnl2.Hide();
            pnl3.Hide();

            pnl2.Left = pnl1.Left;
            pnl3.Left = pnl1.Left;
            pnl2.Top = pnl1.Top;
            pnl3.Top = pnl1.Top;

            txtName.Focus();

            #endregion


        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            var _name = txtName.Text.Trim();
            var _pwd = txtPwd.Text.Trim();
            if (string.IsNullOrWhiteSpace(_name))
            {
                UIMessageTip.ShowWarning("请输入登录名!"); txtName.Focus();
                return;
            } 
            try
            {
                string paramurl = string.Format($"/api/GuaHao/GetLoginUser?uname={_name}&pwd={_pwd}");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                string json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<LoginUsersVM>>>(json);

                if (result.status == 1)
                { 
                    if (result.data != null && result.data.Count > 0)
                    {
                        loginUsers = result.data[0];
                        this.uiBreadcrumb1.ItemIndex++;
                        pnl1.Hide();
                        pnl2.Show();
                    }
                    else
                    {
                        UIMessageTip.ShowWarning(" 登录名或密码有误!");
                        return;
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
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.Message);
            }

        }

        private void btn2left_Click(object sender, EventArgs e)
        {

            try
            {

                this.uiBreadcrumb1.ItemIndex--;
                pnl1.Show();
                pnl2.Hide();
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void btn2right_Click(object sender, EventArgs e)
        {
            try
            {
                var _name = txtName.Text.Trim();

                var pwd1 = txtpwd1.Text.Trim();
                var pwd2 = txtpwd2.Text.Trim();

                if (pwd1 != pwd2)
                {
                    UIMessageTip.ShowWarning("两次输入的密码不一致!");
                    return;
                }

                string paramurl = string.Format($"/api/GuaHao/UpdateUserPassWord?uname={_name}&pwd={pwd1}");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                string json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);

                if (result.status == 1)
                {
                    this.uiBreadcrumb1.ItemIndex++;
                    pnl3.Show();
                    pnl2.Hide();
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                } 
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void uiBreadcrumb1_ItemIndexChanged(object sender, int value)
        {

        }
    }
}
