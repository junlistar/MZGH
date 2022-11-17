using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Client.ViewModel;
using log4net;
using MainFrame.Common;
using Sunny.UI;

namespace MainFrame
{
    public partial class Index : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(Index));//typeof放当前类
        public Index()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        public delegate void SetData(string clientName, int index);
        public SetData setData;
        public static List<SubSystemVM> systemList;

        private void Index_Initialize(object sender, EventArgs e)
        {
            //pnlSystem.Hide();
        }
        public void LoadSystem()
        {
            int _index = 0;
            foreach (var subSystem in systemList)
            {
                var _txt = subSystem.sys_name;
                UIButton uIButton = new UIButton();
                uIButton.Font = new Font("微软雅黑", 16, FontStyle.Regular);
                uIButton.Style = UIStyles.PopularStyles()[_index++];
                uIButton.Text = _txt;
                uIButton.Width = 370;
                uIButton.Height = 200;
                uIButton.TagString = subSystem.sys_no.ToString();
                uIButton.Click += UIButton_Click;
                pnlSystem.Controls.Add(uIButton);
            }

            for (int i = _index; i < 6; i++)
            {
                var _txt = "门诊子系统" + (i + 1).ToString();
                UIButton uIButton = new UIButton();
                uIButton.Font = new Font("微软雅黑", 16, FontStyle.Regular);
                uIButton.Style = UIStyles.PopularStyles()[i];
                uIButton.Text = _txt;
                uIButton.Width = 370;
                uIButton.Height = 200;
                uIButton.TagString = "9999";
                uIButton.Click += UIButton_Click;
                pnlSystem.Controls.Add(uIButton);
            }
            // pnlSystem.Show();
        }

        private void UIButton_Click(object sender, EventArgs e)
        {
            var _btn = sender as UIButton;

            //UIPage uIPage = new UIPage();
            //uIPage.Text = _btn.Text;

            int _sysno = int.Parse(_btn.TagString);

            //获取当前系统
            var _system = Index.systemList.Where(p => p.sys_no == _sysno).FirstOrDefault();
            if (_system == null)
            {
                UIMessageTip.ShowError("未配置系统");
            }
            else
            {
                //检查是否需要升级更新子系统
                if (!string.IsNullOrWhiteSpace(_system.sys_update_url))
                {
                    AutoUpdaterStarter(_system);
                }
                else
                {
                    setData(_btn.Text, _sysno);
                }
                
            }

        }

        private void Index_Load(object sender, EventArgs e)
        {
            try
            {
                pnlSystem.FillColor = Color.Transparent;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "/resource/index.jpeg");
                //this.BackColor =Color.Wheat;
                BindData();
                LoadSystem();
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("加载背景图片失败！");

            }
        }
        public void BindData()
        {
            try
            {
                string json = "";
                string paramurl = string.Format($"/api/subsystem/GetSubSystems");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<SubSystemVM>>>(json);
                if (result.status == 1)
                {
                    systemList = result.data.OrderBy(p=>p.sys_no).ToList();
                }
                else
                {
                    UIMessageTip.ShowError(result.message, 2000);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }
        }
        private void uiLabel1_Click(object sender, EventArgs e)
        {
            AddSystem addSystem = new AddSystem();
            addSystem.FormClosing += AddSystem_FormClosing;
            addSystem.ShowDialog();
        }

        private void AddSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            BindData();
        }
        public string ReadLocalVersion(string sys_code)
        {
            try
            {
                //判断文件是否存在
                if (!File.Exists(Application.StartupPath + $"\\version\\{sys_code}.ini"))
                {
                    //File.Create(Application.StartupPath + "\\AlarmSet.txt");//创建该文件

                    FileStream fs1 = new FileStream(Application.StartupPath + $"\\version\\{sys_code}.ini", FileMode.Create, FileAccess.Write);//创建写入文件 

                    StreamWriter sw = new StreamWriter(fs1);
                    sw.WriteLine("1.0.0.0");

                    sw.Close();
                    fs1.Close();
                }
                //读取配置
                //读取文件值并显示到窗体
                FileStream fs = new FileStream(Application.StartupPath + $"\\version\\{sys_code}.ini", FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadToEnd().Trim();
                sr.Close();
                fs.Close();
                return line;
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("读取版本文件失败，请查看日志信息！");
                log.Error(ex.ToString());
            }
            return "";
        }

        private void AutoUpdaterStarter(SubSystemVM vm)
        {
            //XML文件服务器下载地址 
            //AutoUpdater.Start("http://10.102.38.158/Updates/AutoUpdaterStarter.xml");
            
            AutoUpdater.Start(vm.sys_update_url);

            //读取本地版本配置文件，
            var _version = ReadLocalVersion(vm.sys_code);

            if (!string.IsNullOrWhiteSpace(_version))
            {
                log.Error($"系统：{vm.sys_name}的版本号:{_version}");
                //通过将其分配给InstalledVersion字段来提供自己的版本
                AutoUpdater.InstalledVersion = new Version(_version);
            }
            else
            {
                log.Error($"没有获取到系统：{vm.sys_name}的版本号");
                return;
            }
           

            //查看中文版本
            //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture("zh");

            //显示自定义的应用程序标题
            AutoUpdater.AppTitle = vm.sys_name + " 升级更新";

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
            //Application.Exit();
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
                                $@"您有新的版本 {args.CurrentVersion} 可用，当前使用的是{
                                        args.InstalledVersion
                                    } 版本，这是必需的更新。",
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
                                MessageBoxIcon.Information);
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
    }
}
