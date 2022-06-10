using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Mzsf.ClassLib;
using Mzsf.ViewModel;
using log4net;
using Sunny.UI; 
using System.ComponentModel;
using System.Threading;
using Mzsf.Forms.Wedgit;

namespace Mzsf
{
    public partial class FHeaderAsideMainFooter : UIHeaderAsideMainFooterFrame
    {
        private static ILog log = LogManager.GetLogger(typeof(FHeaderAsideMainFooter));//typeof放当前类

        static int iOperCount = 0;//记录上时间未操作的时间
        static int LogOutSeconds = 0;

        public FHeaderAsideMainFooter()
        {
            InitializeComponent();

            SessionHelper.MyHttpClient = new HttpClient();
            SessionHelper.MyHttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));

            MyMessager msg = new MyMessager();
            Application.AddMessageFilter(msg);

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


            //Aside.CreateChildNode(parent, 61447, 24, "挂号", 1001);
            //Aside.CreateChildNode(parent, 62160, 24, "挂号查询", 1002);
            //Aside.CreateChildNode(parent, 61508, 24, "基础号表维护", 1003);
            //Aside.CreateChildNode(parent, 61674, 24, "生成号表", 1004);
            //Aside.CreateChildNode(parent, 61674, 24, "号表维护", 1005);

            //Aside.CreateNode("Page2", ++pageIndex);
            //Aside.CreateNode("Page3", ++pageIndex);

            //显示默认界面
            // Aside.SelectFirst();

            //LogOutSeconds = int.Parse(ConfigurationManager.AppSettings.Get("LogOutSeconds"));

            //SessionHelper.mzgh_report_code= int.Parse(ConfigurationManager.AppSettings.Get("mzgh_report_code"));
        }

        private void Aside_MenuItemClick(System.Windows.Forms.TreeNode node, NavMenuItem item, int pageIndex)
        {
            Footer.Text = "PageIndex: " + pageIndex;
             
            UIPage page = new UIPage();

            if (pageIndex == 1001)
            {
                if (!ExistPage(1001))
                {
                    page = AddPage(new Form1());
                }
                SelectPage(1001); 
            } 

            //设置激活 用户键盘事件
            Task.Run(async () =>
            {
                await Task.Delay(500);

                this.Invoke(new Action(() =>
                { 
                    page.Focus();
                }));
            });
              
        }

        BackgroundWorker _demoBGWorker = new BackgroundWorker();


        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //修改进度条的显示。
            var percent = e.ProgressPercentage;

            //如果有更多的信息需要传递，可以使用 e.UserState 传递一个自定义的类型。
            //这是一个 object 类型的对象，您可以通过它传递任何类型。
            //我们仅把当前 sum 的值通过 e.UserState 传回，并通过显示在窗口上。
            ResponseResult<bool> result = e.UserState as ResponseResult<bool>;

            if (result.status == 1 && result.data)
            {
                //uiSignal1.Level = 5;
                uiSignal1.OnColor = Color.FromArgb(80, 160, 255);
                tlsInfo.Text = "";
            }
            else if (result.status == 2)
            {
                uiSignal1.OnColor = Color.Red;
                tlsInfo.Text = result.message;
            }
            else
            {
                //uiSignal1.Level = 0;
                uiSignal1.OnColor = Color.Red;
                tlsInfo.Text = "数据库服务器连接失败！";
            }

            toolTip1.AutoPopDelay = 5000; toolTip1.InitialDelay = 500; toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(uiSignal1, "ping:" + result.message);  //设置提示信息为自定义


        }
        private void FHeaderAsideMainFooter_Load(object sender, System.EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, this.Height);

            AddPage(new Mzsf.Forms.Pages.DefaultPage());
            // SelectPage(1000);
            Header.Hide();

            this.Hide();

            tlsInfo.Text = "";

            log.Debug((new System.Diagnostics.StackTrace().GetFrame(0).GetMethod()).Name);

            //UILoginForm frm = new UILoginForm();
            //frm.ShowInTaskbar = true;
            //frm.Text = "荆州中心医院";
            //frm.Title = "门诊挂号";
            //frm.SubText = "荆州中心医院 v0.1";
            //frm.OnLogin += Frm_OnLogin;
            //frm.ButtonCancelClick += btnCancel_Click;
            //frm.LoginImage = UILoginForm.UILoginImage.Login2;
            //frm.ShowDialog();
            //if (frm.IsLogin)
            //{
                //frm.Dispose();
            //}
            //else
            //{
            //    
            //}
            //return;

            Login frm = new Login();
            frm.ShowDialog();
            if (frm.IsLogin)
            {
                UIMessageTip.ShowOk("登录成功");
                this.WindowState = FormWindowState.Maximized;
                this.Show();

                //statusstrip信息
                tsslblName.Text = SessionHelper.uservm.name;

                tsslblMidhost.Text = ConfigurationManager.AppSettings.Get("apihost");
                timer1.Interval = 1000;
                timer1.Start();

                timerlogout.Interval = 1000;
                timerlogout.Start();

                //加载字典数据

                InitDic();

                SessionHelper.clientHeight = this.Height;
                SessionHelper.clientWidth = this.Width;

                this.FormClosing += FHeaderAsideMainFooter_FormClosing;

                //ping
                _demoBGWorker.DoWork += BGWorker_DoWork;
                _demoBGWorker.RunWorkerAsync();
                _demoBGWorker.WorkerReportsProgress = true;
                _demoBGWorker.ProgressChanged += BGWorker_ProgressChanged;

                //timerSignal.Interval = 1000 * 5;//10s
                //timerSignal.Start();
            }
            else
            {
                this.Close();
            } 
        }
        ToolTip toolTip1 = new ToolTip();

        public void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (1 == 1)
            {
                BackgroundWorker bgWorker = sender as BackgroundWorker;
                //UIMessageTip.Show("BGWorker_DoWork");
                try
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

                    bgWorker.ReportProgress(1, result);

                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    ResponseResult<bool> result = new ResponseResult<bool>();
                    if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    {
                        log.Error(ex.InnerException.InnerException.Message.ToString());

                        result.message = ex.InnerException.InnerException.Message.ToString();

                    }
                    else
                    {
                        log.Error(ex.InnerException.ToString());
                        result.message = ex.InnerException.InnerException.Message.ToString();

                    }
                    result.status = 2;

                    bgWorker.ReportProgress(2, result);

                }
            }
        }

        public void LoadSingnal()
        {
            //获取用户费别信息
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/TestDBConnection");

            //log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
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
            try
            {
                Task<HttpResponseMessage> task = null;
                string json = ""; 
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
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<LoginUsersVM>>>(json);
                if (result.status==1)
                {
                    if (result.data != null && result.data.Count > 0)
                    {
                        SessionHelper.uservm = result.data[0];
                        return true;
                    }
                    else
                    {
                        UIMessageTip.ShowWarning(" 登录名或密码有误!");
                    }
                }
                else
                {
                    UIMessageBox.ShowError(result.message);
                    log.Error(result.message);
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

        internal class MyMessager : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                //这个函数可以做很多事情，只要是windows消息都会经过，例如注册全局快捷键，修改窗体大小边框，等等
                //也可以调API做对应的事情
                //if (m.Msg == WM_KEYDOWN || m.Msg == 513 || m.Msg == 515 || m.Msg == 516 || m.Msg == 522
                //    //|| m.Msg == (int)WindowsMessages.WM_MOUSEMOVE
                //    //|| m.Msg == (int)WindowsMessages.WM_LBUTTONDOWN
                //    //|| m.Msg == (int)WindowsMessages.WM_RBUTTONDOWN
                //    || m.Msg == WM_KEYUP
                //    || m.Msg == WM_RBUTTONDOWN
                //    )
                //if ( m.Msg == 513 || m.Msg == 515 || m.Msg == 516 || m.Msg == 522)
                //{
                //    iOperCount = 0;
                //}

                //如果检测到有鼠标或则键盘的消息，则使计数为0
                //if (m.Msg == 0x0202)
                if (m.Msg == 513 || m.Msg == 516 || m.Msg == 519 || m.Msg == 520 || m.Msg == 522 || m.Msg == 256 || m.Msg == 257)
                {
                    iOperCount = 0;
                }
                return false;
            }
        }

        private void timerlogout_Tick(object sender, EventArgs e)
        { 
            iOperCount++;
            tlsInfo.Text = iOperCount.ToString();//屏幕长时间未操作，累计时间

            int t = LogOutSeconds;//获取配置文件中的锁屏时间
            if (iOperCount > t)
            {
                iOperCount = 0;
                timerlogout.Stop();
                this.Hide();
                Login login = new Login();//登录
                login.ShowDialog();//弹出
                if (login.IsLogin)
                {
                    UIMessageTip.ShowOk("登录成功");
                    var pages = GetPages<UIPage>();
                    
                    foreach (var page in pages)
                    {
                        RemovePage(page.PageIndex);
                    } 
                    this.Show(); 
                    timerlogout.Start();
                }
                else
                { 
                    this.FormClosing-= FHeaderAsideMainFooter_FormClosing;
                    this.Close();
                }
            }
        }
         
    } 
}
