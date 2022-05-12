using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using log4net;
using Sunny.UI;

namespace Client
{
    public partial class MdiForm : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(MdiForm));//typeof放当前类
        public MdiForm()
        {
            InitializeComponent();
        }
        //当前用户信息

        //public static LoginUsersVM uservm = new LoginUsersVM();

        private void OpenForm(string formName)
        {
            log.Info("打开窗口：" + formName);

            bool isExist = false;
            //判断是否存在已打开的窗体
            if (pnlForm.HasChildren)
            {
                foreach (Control item in pnlForm.Controls)
                {
                    if (item is Form && item.Name == formName)
                    {
                        isExist = true;
                        item.Visible = true;
                        continue;
                    }
                    item.Visible = false;
                }
            }
            if (!isExist)
            { 
                Form gf = Activator.CreateInstance(System.Type.GetType("Client." + formName)) as Form;
              
                gf.MdiParent = this;
                gf.Parent = pnlForm;
                gf.Width = gf.Parent.Width;
                gf.Height = gf.Parent.Height;
                 
                gf.Show();
            }
        }

        private void menuGuahao_Click(object sender, EventArgs e)
        {
            OpenForm("GuaHao");
        }

        private void MdiForm_Resize(object sender, EventArgs e)
        {
            if (pnlForm.HasChildren)
            {
                foreach (Control item in pnlForm.Controls)
                {
                    if (item is Form)
                    {
                        item.Width = pnlForm.Width;
                        item.Height = pnlForm.Height;
                    }
                }

            }
        }

        private void uiToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void MdiForm_Load(object sender, EventArgs e)
        {
            tlsInfo.Text = "";

            log.Debug((new System.Diagnostics.StackTrace().GetFrame(0).GetMethod()).Name);

            UILoginForm frm = new UILoginForm();
            frm.ShowInTaskbar = true;
            frm.Text = "荆州中心医院";
            frm.Title = "门诊挂号";
            frm.SubText = "荆州中心医院 v0.1";
            frm.OnLogin += Frm_OnLogin;
            frm.ButtonCancelClick += btnCancel_Click;
            frm.LoginImage = UILoginForm.UILoginImage.Login2;
            frm.ShowDialog();
            if (frm.IsLogin)
            {
                UIMessageTip.ShowOk("登录成功");
                this.WindowState = FormWindowState.Maximized;
            }

            frm.Dispose();


            //statusstrip信息
            tsslblName.Text = SessionHelper.uservm.name;

            tsslblMidhost.Text = ConfigurationManager.AppSettings.Get("apihost");
            timer1.Interval = 1000;
            timer1.Start();



        }
        private bool Frm_OnLogin(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                UIMessageTip.ShowWarning("请输入登录名!");
                return false;
            }

            //return userName == "admin" && password == "admin";
            try
            { 
                Task<HttpResponseMessage> task = null;
                string json = "";
                HttpClient client = new HttpClient();
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));
                string paramurl = string.Format($"/api/GuaHao/GetLoginUser?uname={userName}&pwd={password}");

                log.InfoFormat(client.BaseAddress+ paramurl);

                task = client.GetAsync(paramurl);

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
                    log.Info(" 访问登录接口失败!"+ json);
                    UIMessageTip.ShowWarning(" 访问登录接口失败!");
                    return false;
                }
                var listApi = WebApiHelper.DeserializeObject<List<LoginUsersVM>>(json);

                if (listApi != null && listApi.Count > 0)
                {
                    SessionHelper.uservm = listApi[0];
                    return true;
                }
                else
                {
                    UIMessageTip.ShowWarning(" 登录名或密码有误!"); 
                }

            } 
            catch (Exception ex)
            {
                if (ex.InnerException!=null && ex.InnerException.InnerException!=null)
                {
                    log.Error(ex.InnerException.InnerException.Message.ToString());
                    UIMessageTip.ShowError(ex.InnerException.InnerException.Message);
                }
                else
                {
                    log.Error(ex.InnerException.ToString());
                    UIMessageTip.ShowError(ex.InnerException.Message);
                }
                
            }
            return false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsslblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ghcx_Click(object sender, EventArgs e)
        {
            OpenForm("GhList");
        }

        private void MdiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出程序吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            } 
        }

        private void jchbwh_Click(object sender, EventArgs e)
        {
            OpenForm("BaseRequest");
        }

        private void schb_Click(object sender, EventArgs e)
        {
            OpenForm("CreateRequestRecord");
            
        }
    }
}
