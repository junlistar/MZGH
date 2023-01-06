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
using System.Web.Script.Serialization;
using MainFrame.Common;
using System.Reflection;
using AutoUpdaterDotNET;
using System.Configuration;
using Client.ViewModel;

namespace MainFrame
{
    public partial class Main : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(Main));//typeof放当前类

        string head_text = "荆州市中心医院  一体化信息管理平台V1.000(谷翔科技)";

        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            uiTabControl1.BeforeRemoveTabPage += MainTabControl_BeforeRemoveTabPage;
        }

        //用于处理tab关闭时，关闭窗体句柄，否则不关闭会出现多个子系统进程
        public static Dictionary<int, IntPtr> clientDic = new Dictionary<int, IntPtr>();
        public static List<int> keylist = new List<int>();


        private bool MainTabControl_BeforeRemoveTabPage(object sender, int index)
        {
            try
            {
                if (index == 0)
                {
                    return false;
                }
                else
                {
                    // if (clientDic.Keys.Count > 0)
                    if (keylist.Count > 0)
                    {
                        //杀子系统句柄
                        //var _key = clientDic.Keys.ToArray()[index - 1];
                        var _key = keylist[index - 1];
                        var _intPtr = clientDic[_key];
                        if (_intPtr != null)
                        {

                            EmbeddedExeTool exeTool = new EmbeddedExeTool();

                            exeTool.CloseHandle(_intPtr);

                            keylist.Remove(_key);
                            clientDic.Remove(_key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            return true;
        }

        public static TestHisVM vM;
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"{head_text} 当前操作系统-首页";

                //设置窗体大小
                this.MinimumSize = new Size(this.Width, this.Height);

                #region 更新提示/判断是否自动更新
                Task.Run(() =>
                {
                    AutoUpdaterStarter();
                });

                #endregion

                //uiPanel1.Hide();
                //pnlSystem.FillColor = Color.Transparent;
                //this.BackgroundImage = Image.FromFile(Application.StartupPath + "/resource/index.jpeg");

                //设置扩展菜单
                uiContextMenuStrip1.Items.Add("子系统维护");
                uiContextMenuStrip1.Items.Add("系统分组维护");
                uiContextMenuStrip1.Items.Add("权限管理");
                //uiContextMenuStrip1.Items.Add("系统信息配置");

                //设置tabcontrol样式 
                uiTabControl1.ShowActiveCloseButton = true;
                uiTabControl1.TabVisible = true;
                //Aside.TabControl.Style = uiStyleManager1.Style;
                uiTabControl1.StyleCustomMode = true;
                uiTabControl1.TabSelectedForeColor = Color.Black;
                uiTabControl1.TabBackColor = Color.FromArgb(60, 95, 145);
                uiTabControl1.TabSelectedColor = Color.FromArgb(6, 146, 151);
                uiTabControl1.TabSelectedForeColor = Color.White;
                uiTabControl1.MainPage = "主页";
                uiTabControl1.ItemSize = new Size(150, 30);
                uiTabControl1.TabVisible = false;//不显示tab

                if (SessionHelper.MyHttpClient == null)
                {
                    SessionHelper.MyHttpClient = HttpClientFactory.GetHttpClient();
                    SessionHelper.MyHttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));
                }


                this.Hide();
                tsl_time.Text = DateTime.Now.ToShortDateString();
                Login frm = new Login();
                frm.ShowDialog();
                if (frm.IsLogin)
                {
                    //statusstrip信息
                    tsslblName.Text = SessionHelper.uservm.name;

                    tsslblMidhost.Text = SessionHelper.MyHttpClient.BaseAddress.ToString();

                    UIMessageTip.ShowOk("登录成功！");
                    this.Show();
                    var _index = new Index();
                    _index.setData = OpenNewTab;
                    AddPage(_index, 1000);

                    SelectPage(1000);


                    vM = new TestHisVM();
                    vM.Application = "75415424";
                    vM.Screen = "75349424";
                    vM.AppServer = "10.102.41.142";
                    vM.UserMi = SessionHelper.uservm.user_mi;
                    vM.user_mi = SessionHelper.uservm.user_mi;
                    vM.user_name = SessionHelper.uservm.name;
                    vM.SubsysRelativePath = "Modules/mzgh";
                    vM.group_no = "101001";
                    vM.group_name = "门诊西药房";
                    vM.subsys_id = "yp_yfxt";
                    //LoadSystem(); 


                    //var _page = new TestForm();
                    //_page.Text = "测试药品系统";
                    //AddPage(_page, 1000);
                    //SelectPage(1000);
                }
                else
                {
                    this.Close();
                }

                Task.Run(() =>
                {
                    InitDics();
                });
            }
            catch (Exception ex)
            {
                //UIMessageTip.ShowError("加载背景图片失败！");
                log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 打开子系统Tab
        /// </summary>
        /// <param name="key">系统标题名称</param>
        /// 
        /// <param name="index">系统序号</param>
        public void OpenNewTab(string clientName, int index)
        {
            var _page = new Container();
            _page.Text = clientName;
            //获取当前系统
            var _system = Index.systemList.Where(p => p.sys_no == index).FirstOrDefault();
            _page.Text = _system.sys_name;
            //if (!clientDic.Keys.Contains(index))
            if (!keylist.Contains(index))
            {
                //index = (new Random()).Next(9999); 
                _page.FormClosing += Obj_FormClosing;
                AddPage(_page, index);
            }
            SelectPage(index);
        }

        private void Obj_FormClosing(object sender, FormClosingEventArgs e)
        {
            TabPage _tabpage = null;
            foreach (TabPage page in MainTabControl.TabPages)
            {
                var _sendpage = sender as UIPage;
                if (page.Text == _sendpage.Text)
                {
                    _tabpage = page;
                    break;
                }
            }

            MainTabControl.TabPages.Remove(_tabpage);
        }

        #region 系统升级代码

        private void AutoUpdaterStarter()
        {
            //XML文件服务器下载地址
            var _myAssembly = Assembly.GetEntryAssembly().GetName().Version;

            var _updatewebsiet = ConfigurationManager.AppSettings["updatewebsite"];

            AutoUpdater.Start(_updatewebsiet);

            //todo：读取本地版本配置文件，
            //通过将其分配给InstalledVersion字段来提供自己的版本
            //AutoUpdater.InstalledVersion = new Version("1.0.0.0");

            //查看中文版本
            //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture("zh");

            //显示自定义的应用程序标题
            AutoUpdater.AppTitle = "主程序" + "升级更新";

            //不显示“稍后提醒”按钮
            //AutoUpdater.ShowRemindLaterButton = false;

            //强制选项将隐藏稍后提醒，跳过和关闭按钮的标准更新对话框。
            //AutoUpdater.Mandatory = true;
            //AutoUpdater.UpdateMode = Mode.Forced;

            //为XML、更新文件和更改日志提供基本身份验证
            //BasicAuthentication basicAuthentication = new BasicAuthentication("myUserName", "myPassword");
            //AutoUpdater.BasicAuthXML = AutoUpdater.BasicAuthDownload = AutoUpdater.BasicAuthChangeLog = basicAuthentication;

            //为http web请求设置User-Agent
            //AutoUpdater.HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36";

            //启用错误报告
            AutoUpdater.ReportErrors = true;

            //将应用程序设定不需要管理员权限来替换旧版本
            //AutoUpdater.RunUpdateAsAdmin = false;

            //打开下载页面，不直接下载最新版本*****
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.RunUpdateAsAdmin = true;
            //设置为要下载更新文件的文件夹路径。如果没有提供，则默认为临时文件夹。
            //AutoUpdater.DownloadPath = Environment.CurrentDirectory;

            //设置zip解压路径
            AutoUpdater.InstallationPath = Environment.CurrentDirectory;

            //处理应用程序在下载完成后如何退出
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;

            //自定义处理更新逻辑事件
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
        }


        private void AutoUpdater_ApplicationExitEvent()
        {
            AutoUpdater.ApplicationExitEvent -= AutoUpdater_ApplicationExitEvent;
            Text = @"Closing application...";
            System.Threading.Thread.Sleep(5000);
            Application.Exit();
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            AutoUpdater.CheckForUpdateEvent -= AutoUpdaterOnCheckForUpdateEvent;
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"您有新的版本 {args.CurrentVersion} 可用，当前使用的是{args.InstalledVersion} 版本，这是必需的更新。",
                                @"Update Available",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"您有新的版本 {args.CurrentVersion} 可用，当前使用的是{args.InstalledVersion} 版本，
                                您现在要更新应用程序吗？", @"Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }


                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            //You can use Download Update dialog used by AutoUpdater.NET to download the update.

                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    //MessageBox.Show(@"There is no update available. Please try again later.", @"Update Unavailable",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (args.Error is System.Net.WebException)
                {
                    MessageBox.Show(
                        @"There is a problem reaching update server. Please check your internet connection and try again later.",
                        @"Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                log.Debug("主程序关闭事件");
                EmbeddedExeTool exeTool = new EmbeddedExeTool();
                //杀子系统句柄
                foreach (var key in clientDic.Keys)
                {
                    var _intPtr = clientDic[key];
                    if (_intPtr != null)
                    {
                        exeTool.CloseHandle(_intPtr);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Debug(ex.ToString());
            }
        }

        private void uiContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "子系统维护")
            {
                SystemList syslist = new SystemList();
                //addSystem.FormClosing += AddSystem_FormClosing;
                syslist.ShowDialog();
            }
            else if (e.ClickedItem.Text == "系统分组维护")
            {
                SystemGroup addSystem = new SystemGroup();
                //addSystem.FormClosing += AddSystem_FormClosing;
                addSystem.ShowDialog();
            }
            else if (e.ClickedItem.Text == "权限管理")
            {
                //系统权限管理
                UserManage umForm = new UserManage();
                umForm.ShowDialog();
            }
            else if (e.ClickedItem.Text == "系统信息配置")
            {
                //打开配置信息界面

                ClientConfig clientConfig = new ClientConfig();
                clientConfig.ShowDialog();
            }
        }
        public void InitDics()
        {
            try
            {
                string json = "";
                string paramurl = string.Format($"/api/subsystem/GetGroupNames");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<YpGroup>>>(json);
                if (result.status == 1)
                {
                    SessionHelper.ypGroupsList = result.data;
                }
                else { log.Error(result.message); }


                //获取用户 
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetUserDic");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.userDics = HttpClientUtil.DeserializeObject<ResponseResult<List<UserDicVM>>>(json).data;

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }
        }

        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"{head_text} 当前操作系统-{uiTabControl1.SelectedTab.Text}";
            }
            catch (Exception ex)
            {

            }

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            log.Debug("子程序关闭事件"); 
            if (keylist != null && keylist.Count > 0)
            {
                foreach (var _key in keylist)
                { 
                    var _intPtr = clientDic[_key];
                    if (_intPtr != null)
                    {
                        EmbeddedExeTool exeTool = new EmbeddedExeTool();
                        exeTool.CloseHandle(_intPtr);
                    }

                    RemovePage(_key);
                } 

                keylist.Clear();
                clientDic.Clear(); 
                SelectPage(1000);
            } 
        }
    }
}
