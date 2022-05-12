﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Client.ClassLib;
using Client.ViewModel;
using log4net;
using Sunny.UI;


namespace Client
{
    public partial class FHeaderAsideMainFooter : UIHeaderAsideMainFooterFrame
    {
        private static ILog log = LogManager.GetLogger(typeof(GuaHao));//typeof放当前类


        public FHeaderAsideMainFooter()
        {
            InitializeComponent();

            SessionHelper.MyHttpClient = new HttpClient();
            SessionHelper.MyHttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));


            //设置关联
            Aside.TabControl = MainTabControl;

            //增加页面到Main
            //AddPage(new FTitlePage1(), 1001);
            //AddPage(new FTitlePage2(), 1002);
            //AddPage(new FTitlePage3(), 1003);

            int pageIndex = 1000;
            TreeNode parent = Aside.CreateNode("业务", 61451, 24, pageIndex);

            //设置Header节点索引

            //Aside.CreateNode("业务", 1001);

            //Aside.CreateChildNode(parent, AddPage(new GuaHao(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new GhList(), ++pageIndex));
            Aside.CreateChildNode(parent, 61447, 24, "挂号", 1001);
            Aside.CreateChildNode(parent, 62160, 24, "挂号查询", 1002);
            Aside.CreateChildNode(parent, 61508, 24, "基础号表维护", 1003);
            Aside.CreateChildNode(parent, 61674, 24, "生成号表", 1004);

            //Aside.CreateNode("Page2", ++pageIndex);
            //Aside.CreateNode("Page3", ++pageIndex);

            //显示默认界面
            // Aside.SelectFirst();
        }

        private void Aside_MenuItemClick(System.Windows.Forms.TreeNode node, NavMenuItem item, int pageIndex)
        {
            Footer.Text = "PageIndex: " + pageIndex;

            //UIMessageTip.Show(node.Text);


            if (node.Text == "挂号")
            {
                if (!ExistPage(1001))
                {
                    AddPage(new GuaHao());
                }
                SelectPage(1001);
            }
            else if (node.Text == "挂号查询")
            {
                if (!ExistPage(1002))
                {
                    AddPage(new GhList());
                }
                SelectPage(1002);
            }
            else if (node.Text == "基础号表维护")
            {
                if (!ExistPage(1003))
                {
                    AddPage(new BaseRequest());
                }
                SelectPage(1003);
            }
            else if (node.Text == "生成号表")
            {
                if (!ExistPage(1004))
                {
                    AddPage(new CreateRequestRecord());
                }
                SelectPage(1004);
            }
        }

        private void FHeaderAsideMainFooter_Load(object sender, System.EventArgs e)
        {
            AddPage(new Client.Forms.Pages.DefaultPage());
            // SelectPage(1000);
            Header.Hide();

            this.Hide();

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
                this.Show();

                frm.Dispose();


                //statusstrip信息
                tsslblName.Text = SessionHelper.uservm.name;

                tsslblMidhost.Text = ConfigurationManager.AppSettings.Get("apihost");
                timer1.Interval = 1000;
                timer1.Start();

                //加载字典数据

                InitDic();

                SessionHelper.clientHeight = this.Height;
                SessionHelper.clientWidth = this.Width;

                timerSignal.Interval = 1000 * 10;//10s
                timerSignal.Start();
            }
            else
            {

            }


        }
        ToolTip toolTip1 = new ToolTip();

        public void LoadSingnal()
        {
            //获取用户费别信息
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/TestDBConnection");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
            if (result.status == 1 && result.data)
            {
                //uiSignal1.Level = 5;
                uiSignal1.OnColor = Color.FromArgb(80, 160, 255);
            }
            else
            {
                //uiSignal1.Level = 0;
                uiSignal1.OnColor = Color.Red;

            } 

            toolTip1.AutoPopDelay = 5000; toolTip1.InitialDelay = 500; toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(uiSignal1, "ping:" + result.message);  //设置提示信息为自定义
        }

        public void InitDic()
        {
            log.Info("初始化数据字典：InitDic");

            //获取用户费别信息
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/GetChargeTypes");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.chargeTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ChargeTypeVM>>>(json).data;

            //获取地区信息
            json = "";
            paramurl = string.Format($"/api/GuaHao/GetDistrictCodes");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.districtCodes = WebApiHelper.DeserializeObject<ResponseResult<List<DistrictCodeVM>>>(json).data;


            //获取职业信息
            json = "";
            paramurl = string.Format($"/api/GuaHao/GetOccupationCodes");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.occupationCodes = WebApiHelper.DeserializeObject<ResponseResult<List<OccupationCodeVM>>>(json).data;

            //获取身份信息
            json = "";
            paramurl = string.Format($"/api/GuaHao/GetResponceTypes");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.responseTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ResponceTypeVM>>>(json).data;


            //获取科室
            json = "";
            paramurl = string.Format($"/api/GuaHao/GetUnits");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.units = WebApiHelper.DeserializeObject<ResponseResult<List<UnitVM>>>(json).data;

            //获取号别
            json = "";
            paramurl = string.Format($"/api/GuaHao/GetClinicTypes");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.clinicTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ClinicTypeVM>>>(json).data;

            json = "";
            paramurl = string.Format($"/api/GuaHao/GetRequestTypes");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.requestTypes = WebApiHelper.DeserializeObject<ResponseResult<List<RequestTypeVM>>>(json).data;
              
            //获取用户
            json = "";
            paramurl = string.Format($"/api/GuaHao/GetUserDic");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.userDics = WebApiHelper.DeserializeObject<ResponseResult<List<UserDicVM>>>(json).data;
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
                //HttpClient client = new HttpClient();
                ////client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));
                string paramurl = string.Format($"/api/GuaHao/GetLoginUser?uname={userName}&pwd={password}");

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
                    return false;
                }
                var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<LoginUsersVM>>>(json);

                if (listApi.data != null && listApi.data.Count > 0)
                {
                    SessionHelper.uservm = listApi.data[0];
                    return true;
                }
                else
                {
                    UIMessageTip.ShowWarning(" 登录名或密码有误!");
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

            }
            return false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsslblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void FHeaderAsideMainFooter_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (!UIMessageBox.ShowAsk("确定退出程序吗?"))
            {
                e.Cancel = true;
            }
        }

        private void FHeaderAsideMainFooter_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("1");
        }

        private void timerSignal_Tick(object sender, EventArgs e)
        {
            //Task t2 = Task.Run(() =>
            //{
            //    LoadSingnal();
            //});

            Action action = () =>
            {
                LoadSingnal();

            };
            Invoke(action);
        }
    }
}