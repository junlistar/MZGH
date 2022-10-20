using System;
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
using Client.Forms.Pages;
using System.ComponentModel;
using System.Threading;
using Client.Forms.Wedgit;
using Mzsf.Forms.Pages;
using Client.Forms.Pages.hbgl;
using Client.Forms.Pages.cwgl;
using Client.Forms.Pages.qxgl;
using System.Linq;
using Client.Forms.Pages.yhbb;
using Client.Forms.Pages.zfgl;
using Client.Forms.Pages.xt;
using System.IO;
using Newtonsoft.Json;

namespace Client
{
    public partial class FHeaderAsideMainFooter : UIHeaderAsideMainFooterFrame
    {
        private static ILog log = LogManager.GetLogger(typeof(FHeaderAsideMainFooter));//typeof放当前类

        static int iOperCount = 0;//记录上时间未操作的时间
        static int LogOutSeconds = 0;

        List<XTUserGroupVM> function_list;
        List<XTFunctionsVM> all_list;

        //启动传参
        string[] arg;

        public FHeaderAsideMainFooter(string[] args)
        {
            arg = args;
            if (args != null && args.Count() > 0)
            {
                log.Debug($"程序被调用，参数：{args[0]}");
            }
            else
            {
                log.Debug("直接打开程序");
            }


            InitializeComponent();

            SessionHelper.MyHttpClient = ClassLib.HttpClientFactory.GetHttpClient();
            SessionHelper.MyHttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));

            MyMessager msg = new MyMessager();
            Application.AddMessageFilter(msg);


            LogOutSeconds = int.Parse(ConfigurationManager.AppSettings.Get("LogOutSeconds"));

            //报表编号获取（门诊挂号，门诊收费）
            SessionHelper.mzgh_report_code = int.Parse(ConfigurationManager.AppSettings.Get("mzgh_report_code"));
            SessionHelper.mzsf_report_code = int.Parse(ConfigurationManager.AppSettings.Get("mzsf_report_code"));
            //挂号日结，收费日结
            SessionHelper.ghrj_report_code = int.Parse(ConfigurationManager.AppSettings.Get("ghrj_report_code"));
            SessionHelper.sfrj_report_code = int.Parse(ConfigurationManager.AppSettings.Get("sfrj_report_code"));

            //读取医保配置
            YBHelper.mdtrtarea_admvs = ConfigurationManager.AppSettings.Get("mdtrtarea_admvs");
            YBHelper.recer_sys_code = ConfigurationManager.AppSettings.Get("recer_sys_code");
            YBHelper.infver = ConfigurationManager.AppSettings.Get("infver");
            YBHelper.opter_type = ConfigurationManager.AppSettings.Get("opter_type");
            YBHelper.fixmedins_code = ConfigurationManager.AppSettings.Get("fixmedins_code");
            YBHelper.fixmedins_name = ConfigurationManager.AppSettings.Get("fixmedins_name");
            YBHelper.edit_diseinfo = ConfigurationManager.AppSettings.Get("edit_diseinfo");
            YBHelper.yb_identity_only = ConfigurationManager.AppSettings.Get("yb_identity_only");

            uiStyleManager1.Style = UIStyle.Blue;
            MainTabControl.BeforeRemoveTabPage += MainTabControl_BeforeRemoveTabPage;
        }

        private bool MainTabControl_BeforeRemoveTabPage(object sender, int index)
        {
            if (index == 0)
            {
                return false;
            }

            string slectedTab = this.MainTabControl.SelectedTab.Text;//获取当前TabItem的显示文本

            try
            {

                if (slectedTab == "划价收费")
                {
                    Form frm = this.MainTabControl.TabPages[index].Controls.Find("ChargePage", false)[0] as Form;//获取内嵌的Form对象
                    frm.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            return true;
        }

        public void MenuBind()
        {
            //设置关联
            Aside.TabControl = MainTabControl;
            Aside.TabControl.ShowCloseButton = true;
            Aside.TabControl.TabVisible = true;
            //Aside.TabControl.Style = uiStyleManager1.Style;
            Aside.TabControl.StyleCustomMode = true;
            Aside.TabControl.TabBackColor = Color.FromArgb(60, 95, 145);
            Aside.TabControl.TabSelectedColor = Color.FromArgb(6, 146, 151);
            Aside.TabControl.TabSelectedForeColor = Color.White;


            //增加页面到Main
            //AddPage(new FTitlePage1(), 1001);
            //AddPage(new FTitlePage2(), 1002);
            //AddPage(new FTitlePage3(), 1003);

            TreeNode parent;
            int pageIndex;


            if (SessionHelper.uservm.user_mi == "00000")
            {
                pageIndex = 1000;
                parent = Aside.CreateNode("挂号业务", 61734, 24, pageIndex);
                Aside.CreateChildNode(parent, "挂号", 62004, 24, 1001);
                Aside.CreateChildNode(parent, "挂号查询", 61442, 24, 1002);
                Aside.CreateChildNode(parent, "患者基本信息", 62140, 24, 1003);

                pageIndex = 1100;
                parent = Aside.CreateNode("收费业务", 362656, 24, pageIndex);
                Aside.CreateChildNode(parent, "划价收费", 363203, 24, 1101);
                Aside.CreateChildNode(parent, "退费", 362782, 24, 1102);

                pageIndex = 1200;
                parent = Aside.CreateNode("财务管理", 361783, 24, pageIndex);
                Aside.CreateChildNode(parent, "挂号日结", 62004, 24, 1201);
                Aside.CreateChildNode(parent, "收费日结", 57581, 24, 1202);

                pageIndex = 1300;
                parent = Aside.CreateNode("号表管理", 61498, 24, pageIndex);
                Aside.CreateChildNode(parent, "号表模板", 61508, 24, 1303);
                Aside.CreateChildNode(parent, "生成号表", 61637, 24, 1304);
                Aside.CreateChildNode(parent, "号表维护", 61674, 24, 1305);
                Aside.CreateChildNode(parent, "临时号表维护", 61508, 24, 1306);
                Aside.CreateChildNode(parent, "时间段维护", 261463, 24, 1301);
                Aside.CreateChildNode(parent, "分时段维护", 261463, 24, 1302);
                Aside.CreateChildNode(parent, "停诊管理", 261463, 24, 1307);

                pageIndex = 1400;
                parent = Aside.CreateNode("用户报表", 61953, 24, pageIndex);
                Aside.CreateChildNode(parent, "综合统计报表", 61568, 24, 1401);
                Aside.CreateChildNode(parent, "挂号员日结报表", 61568, 24, 1402);
                Aside.CreateChildNode(parent, "收费员日结报表", 61568, 24, 1403);
                Aside.CreateChildNode(parent, "WEB报表查询", 61568, 24, 1404);

                pageIndex = 1500;
                parent = Aside.CreateNode("权限管理", 361573, 24, pageIndex);
                Aside.CreateChildNode(parent, "用户管理", 361875, 24, 1502);
                //Aside.CreateChildNode(parent, "菜单管理", 361875, 24, 1501);
                Aside.CreateChildNode(parent, "客户端配置", 361875, 24, 1503);

                pageIndex = 1600;
                parent = Aside.CreateNode("支付管理", 61852, 24, pageIndex);
                Aside.CreateChildNode(parent, "医保支付", 62139, 24, 1601);
                Aside.CreateChildNode(parent, "窗口支付", 361705, 24, 1602);
                Aside.CreateChildNode(parent, "自助支付", 362716, 24, 1603);


                //foreach (var item in all_list.ToArray())
                //{
                //    if (string.IsNullOrWhiteSpace(item.parent_func))
                //    {
                //        parent = Aside.CreateNode(item.func_desc.Trim(),1);
                //        var items = all_list.Where(p => p.parent_func != null && p.parent_func.Trim() == item.func_name.Trim()).ToList();
                //        if (items != null && items.Count > 0)
                //        {
                //            foreach (var subitem in items)
                //            {
                //                Aside.CreateChildNode(parent, subitem.func_desc.Trim(), 1);
                //            } 
                //        }
                //    }
                //} 

            }
            else
            {

                pageIndex = 1000;
                if (function_list.Where(p => p.func_desc.Trim() == "挂号业务").Count() > 0)
                {
                    parent = Aside.CreateNode("挂号业务", 61734, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim().Trim() == "挂号").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "挂号", 62004, 24, 1001);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "挂号查询").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "挂号查询", 61442, 24, 1002);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "患者基本信息").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "患者基本信息", 62140, 24, 1003);
                    }

                }
                pageIndex = 1100;
                if (function_list.Where(p => p.func_desc.Trim() == "收费业务").Count() > 0)
                {
                    parent = Aside.CreateNode("收费业务", 362656, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim() == "划价收费").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "划价收费", 363203, 24, 1101);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "退费").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "退费", 362782, 24, 1102);
                    }
                }
                pageIndex = 1200;
                if (function_list.Where(p => p.func_desc.Trim() == "财务管理").Count() > 0)
                {
                    parent = Aside.CreateNode("财务管理", 361783, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim() == "挂号日结").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "挂号日结", 62004, 24, 1201);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "收费日结").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "收费日结", 57581, 24, 1202);
                    }
                }
                pageIndex = 1300;
                if (function_list.Where(p => p.func_desc.Trim() == "号表管理").Count() > 0)
                {
                    parent = Aside.CreateNode("号表管理", 61498, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim() == "号表模板").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "号表模板", 61508, 24, 1303);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "生成号表").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "生成号表", 61637, 24, 1304);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "号表维护").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "号表维护", 61674, 24, 1305);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "临时号表维护").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "临时号表维护", 61508, 24, 1306);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "时间段维护").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "时间段维护", 261463, 24, 1301);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "分时段维护").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "分时段维护", 261463, 24, 1302);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "停诊管理").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "停诊管理", 261463, 24, 1307);
                    }


                }



                pageIndex = 1400;
                if (function_list.Where(p => p.func_desc.Trim() == "用户报表").Count() > 0)
                {
                    parent = Aside.CreateNode("用户报表", 61953, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim() == "综合统计报表").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "综合统计报表", 61568, 24, 1401);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "挂号员日结报表").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "挂号员日结报表", 61568, 24, 1402);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "收费员日结报表").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "收费员日结报表", 61568, 24, 1403);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "WEB报表查询").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "WEB报表查询", 61568, 24, 1404);
                    }

                }
                pageIndex = 1500;
                if (function_list.Where(p => p.func_desc.Trim() == "权限管理").Count() > 0)
                {
                    parent = Aside.CreateNode("权限管理", 361573, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim() == "用户权限").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "用户权限", 361875, 24, 1502);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "菜单管理").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "菜单管理", 361875, 24, 1501);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "客户端配置").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "客户端配置", 361875, 24, 1503);
                    }
                }
                pageIndex = 1600;
                if (function_list.Where(p => p.func_desc.Trim() == "支付管理").Count() > 0)
                {
                    parent = Aside.CreateNode("支付管理", 361573, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim() == "医保支付").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "医保支付", 361875, 24, 1601);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "窗口支付").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "窗口支付", 361875, 24, 1602);
                    }
                    if (function_list.Where(p => p.func_desc.Trim() == "自助支付").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "自助支付", 361875, 24, 1603);
                    }
                }
            }
            //设置Header节点索引

            //Aside.CreateNode("业务", 1001);

            //Aside.CreateChildNode(parent, AddPage(new GuaHao(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new GhList(), ++pageIndex));



            //Aside.CreateNode("Page2", ++pageIndex);
            //Aside.CreateNode("Page3", ++pageIndex);

            //显示默认界面
            Aside.SelectFirst();
        }


        private void Aside_MenuItemClick(System.Windows.Forms.TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (node.Nodes != null && node.Nodes.Count > 0)
            {
                return;
            }

            Footer.Text = "PageIndex: " + pageIndex;

            UIPage page = new UIPage();
            UIPage obj = new UIPage();

            if (!ExistPage(pageIndex))
            {
                switch (pageIndex)
                {
                    case 1001:
                        obj = new GuaHao(); break;
                    case 1002:
                        obj = new GhList(); break;
                    case 1003:
                        obj = new UserInfoPage(); break;
                    case 1101:
                        obj = new ChargePage(); break;
                    case 1102:
                        obj = new RefundPage(); break;
                    case 1301:
                        obj = new RequestHour(); break;
                    case 1302:
                        obj = new RequestTime(); break;
                    case 1303:
                        obj = new BaseRequest(); break;
                    case 1304:
                        //obj = new CreateRequestRecord(); break;
                        obj = new Schb(); break;
                    //case "号表维护":
                    case 1305:
                        //obj = new BaseWeiHu(); break;
                        obj = new Hbwh(); break;
                    case 1306:
                        obj = new LsHbwh(); break;
                    case 1307:
                        obj = new DocOutManage(); break;
                    case 1201:
                        obj = new GuahaoRijie(); break;
                    case 1202:
                        obj = new ShoufeiRijie(); break;
                    case 1401:
                        obj = new UserReport(); break;
                    case 1402:
                        obj = new GhrjReport(); break;
                    case 1403:
                        obj = new SfrjReport(); break;
                    case 1404:
                        obj = new WebReport(); break;
                    case 1501:
                        obj = new FunctionList(); break;
                    case 1502:
                        obj = new UserManage(); break;
                    case 1503:
                        obj = new MzClientConfig(); break;
                    case 1601:
                        obj = new YBPay(); break;
                    case 1602:
                        obj = new WindowPay(); break;
                    case 1603:
                        obj = new SelfPay(); break;
                    default:
                        break;
                }
                obj.Style = uiStyleManager1.Style;
                obj.TagString = pageIndex.ToString();
                obj.FormClosing += Obj_FormClosing; ;
                page = AddPage(obj, pageIndex);
            }
            SelectPage(pageIndex);

            //设置激活 用户键盘事件
            Task.Run(async () =>
            {
                await Task.Delay(100);

                this.Invoke(new Action(() =>
                {
                    page.Focus();
                }));
            });

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
            //RemovePage(int.Parse((sender as UIPage).TagString));//
            //Aside.TabControl.RemovePage(int.Parse((sender as UIPage).TagString));
        }
        public void LoadCorlorStyles()
        {
            var styles = UIStyles.PopularStyles();
            foreach (UIStyle style in styles)
            {
                //Header.CreateChildNode(Header.Nodes[4], style.DisplayText(), style.Value());

                if (style.DisplayText() != "DarkBlue" && style.DisplayText() != "Black")
                {
                    uiContextMenuStrip1.Items.Add(style.DisplayText());
                }

            }
        }

        private void FHeaderAsideMainFooter_Load(object sender, System.EventArgs e)
        {
            try
            {

                this.MinimumSize = new Size(this.Width, this.Height);

                LoadCorlorStyles();

                //显示默认页面
                AddPage(new Client.Forms.Pages.DefaultPage(), 9999);

                //隐藏框架头部
                Header.Hide();

                this.Hide();

                tlsInfo.Text = "";

                if (arg != null && arg.Count() > 0)
                {
                    var _jstr = arg[0];
                    log.Debug($"第三方传递json值：{_jstr}");
                    var _usermi = "";
                    try
                    {
                        var _hisloginvm = WebApiHelper.DeserializeObject<HisLoginVM>(_jstr);
                        if (_hisloginvm != null && !string.IsNullOrWhiteSpace(_hisloginvm.UserMi))
                        {
                            _usermi = _hisloginvm.UserMi;
                        }
                    }
                    catch (Exception ex)
                    {
                        var _index = _jstr.IndexOf("UserMi:");
                        _jstr = _jstr.Substring(_index + 7);
                        _index = _jstr.IndexOf(",");
                        _usermi = _jstr.Substring(0, _index);
                        //MessageBox.Show(_usermi);
                    }

                    if (_usermi != "")
                    {
                        //获取用户费别信息 
                        string json;
                        string paramurl = string.Format($"/api/GuaHao/GetLoginUserByUserMi?usermi={_usermi}");
                        json = HttpClientUtil.Get(paramurl);
                        var result = WebApiHelper.DeserializeObject<ResponseResult<List<LoginUsersVM>>>(json);
                        if (result.status == 1)
                        {

                            if (result.data != null && result.data.Count > 0)
                            {
                                SessionHelper.uservm = result.data[0];
                                LoadFormData();
                            }
                            else
                            {
                                MessageBox.Show($"没有找到usermi:{_usermi},对应的用户信息!");
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有获取到UserMi");
                        this.Close();
                    }

                }
                else
                {
                    Login frm = new Login();
                    frm.ShowDialog();
                    if (frm.IsLogin)
                    {
                        LoadFormData();
                    }
                    else
                    {
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString()); ;
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        public void LoadFormData()
        {
            UIMessageTip.ShowOk("登录成功");

            ProcessingForm processingForm = new ProcessingForm();
            if (processingForm.ShowDialog() == DialogResult.OK)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();

                //statusstrip信息
                tsslblName.Text = SessionHelper.uservm.name;

                tsslblMidhost.Text = SessionHelper.MyHttpClient.BaseAddress.ToString();
                timer1.Interval = 1000;
                timer1.Start();

                timerlogout.Interval = 1000;
                timerlogout.Start();

                //加载字典数据 
                //InitDic();

                //读取打印机配置
                InitPrinter();

                //获取菜单权限 
                GetUserFunctions(SessionHelper.uservm.user_group);

                //绑定名称，版本号
                this.Text = SessionHelper.MzClientConfigVM.client_name + " " + SessionHelper.MzClientConfigVM.client_version;

                //绑定菜单
                MenuBind();

                SessionHelper.clientHeight = this.Height;
                SessionHelper.clientWidth = this.Width;

                this.FormClosing += FHeaderAsideMainFooter_FormClosing;

            };
        }
        public void GetUserFunctions(string user_group)
        {
            try
            {
                var d = new
                {
                    subsys_id = "mz",
                    user_group = user_group
                };

                var param = $"subsys_id={d.subsys_id}&user_group={d.user_group}";
                var json = "";
                var paramurl = string.Format($"/api/qxgl/GetXTUserGroupsByGroupId?{param}");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                function_list = WebApiHelper.DeserializeObject<ResponseResult<List<XTUserGroupVM>>>(json).data;

                param = $"subsys_id={d.subsys_id}";
                paramurl = string.Format($"/api/qxgl/GetXTUserGroups?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                all_list = WebApiHelper.DeserializeObject<ResponseResult<List<XTFunctionsVM>>>(json).data;

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }

        }



        ToolTip toolTip1 = new ToolTip();



        public void LoadSingnal()
        {
            //获取用户费别信息 
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/TestDBConnection");
            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            json = HttpClientUtil.Get(paramurl);
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



        public void InitPrinter()
        {
            try
            {
                //判断文件是否存在
                if (!File.Exists(Application.StartupPath + "\\config.ini"))
                {
                    //File.Create(Application.StartupPath + "\\AlarmSet.txt");//创建该文件

                    FileStream fs1 = new FileStream(Application.StartupPath + "\\config.ini", FileMode.Create, FileAccess.Write);//创建写入文件 

                    StreamWriter sw = new StreamWriter(fs1);
                    sw.WriteLine("[printer]");//开始写入值
                    sw.WriteLine("ghxp=");
                    sw.WriteLine("sfxp=");
                    sw.WriteLine("jsbb=");
                    sw.WriteLine("default=");

                    sw.Close();
                    fs1.Close();
                }
                //读取配置
                //读取文件值并显示到窗体
                FileStream fs = new FileStream(Application.StartupPath + "\\config.ini", FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                int curLine = 0;
                while (line != null)
                {

                    if (line.StartsWith("ghxp="))
                    {
                        var _ghxp = line.Substring(line.LastIndexOf("=") + 1);//截取=号后边的值
                        if (!string.IsNullOrWhiteSpace(_ghxp))
                        {
                            SessionHelper.gh_printer = _ghxp;
                        }
                    }
                    else if (line.StartsWith("sfxp="))
                    {
                        var _sfxp = line.Substring(line.LastIndexOf("=") + 1);
                        if (!string.IsNullOrWhiteSpace(_sfxp))
                        {
                            SessionHelper.sf_printer = _sfxp;
                        }
                    }
                    else if (line.StartsWith("jsbb="))
                    {
                        var _jsbb = line.Substring(line.LastIndexOf("=") + 1);
                        if (!string.IsNullOrWhiteSpace(_jsbb))
                        {
                            SessionHelper.jsbb_printer = _jsbb;
                        }
                    }
                    else if (line.StartsWith("default="))
                    {
                        var _def = line.Substring(line.LastIndexOf("=") + 1);
                        if (!string.IsNullOrWhiteSpace(_def))
                        {
                            SessionHelper.default_printer = _def;
                        }
                    }

                    line = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                UIMessageTip.Show("打印配置文件读取失败");
            }
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
            //if (MessageBox.Show("确定退出程序吗？","确认退出", MessageBoxButtons.OKCancel) != DialogResult.OK) 
            //{
            //    e.Cancel = true;
            //}
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
                //如果检测到有鼠标或则键盘的消息，则使计数为0 
                if (m.Msg == 513 || m.Msg == 516 || m.Msg == 519 || m.Msg == 520 || m.Msg == 522 || m.Msg == 256 || m.Msg == 257)
                {
                    iOperCount = LogOutSeconds;
                }
                return false;
            }
        }

        private void timerlogout_Tick(object sender, EventArgs e)
        {
            iOperCount--;
            tlsInfo.Text = iOperCount.ToString();//屏幕长时间未操作，累计时间


            if (iOperCount == 0)
            {
                iOperCount = LogOutSeconds;
                timerlogout.Stop();
                this.Hide();
                Login login = new Login();//登录
                login.ShowDialog();//弹出
                if (login.IsLogin)
                {
                    UIMessageTip.ShowOk("登录成功");
                    //var pages = GetPages<UIPage>();

                    //foreach (var page in pages)
                    //{
                    //    RemovePage(page.PageIndex);
                    //}
                    this.Show();
                    timerlogout.Start();
                }
                else
                {
                    this.FormClosing -= FHeaderAsideMainFooter_FormClosing;
                    this.Close();
                }
            }
        }

        private void uiContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var styles = UIStyles.PopularStyles();
            foreach (UIStyle style in styles)
            {
                if (style.DisplayText() == e.ClickedItem.Text)
                {
                    uiStyleManager1.Style = style;
                }
            }
        }

        public void InitDic()
        {
            try
            {

                log.Info("初始化数据字典：InitDic");

                //获取用户费别信息 
                string json;
                string paramurl = string.Format($"/api/GuaHao/GetChargeTypes");
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.chargeTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ChargeTypeVM>>>(json).data;


                //获取地区信息
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetDistrictCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.districtCodes = WebApiHelper.DeserializeObject<ResponseResult<List<DistrictCodeVM>>>(json).data;


                //获取职业信息
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetOccupationCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.occupationCodes = WebApiHelper.DeserializeObject<ResponseResult<List<OccupationCodeVM>>>(json).data;

                //获取身份信息
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetResponceTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.responseTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ResponceTypeVM>>>(json).data;


                //获取科室
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetUnits");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.units = WebApiHelper.DeserializeObject<ResponseResult<List<UnitVM>>>(json).data;

                //获取号别
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetClinicTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.clinicTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ClinicTypeVM>>>(json).data;

                //获取RequestType
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetRequestTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.requestTypes = WebApiHelper.DeserializeObject<ResponseResult<List<RequestTypeVM>>>(json).data;

                //获取用户
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetUserDic");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.userDics = WebApiHelper.DeserializeObject<ResponseResult<List<UserDicVM>>>(json).data;

                //获取挂号时间段
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetRequestHours");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.requestHours = WebApiHelper.DeserializeObject<ResponseResult<List<RequestHourVM>>>(json).data;

                //GetRelativeCodes   
                paramurl = string.Format($"/api/GuaHao/GetRelativeCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                SessionHelper.relativeCodes = WebApiHelper.DeserializeObject<ResponseResult<List<RelativeCodeVM>>>(json).data;

                //处方模板
                paramurl = string.Format($"/api/mzsf/GetMzChargePatterns");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzChargePatternVM>>>(json);
                if (result.status == 1)
                {
                    SessionHelper.MzChargePatterns = result.data;
                }
                //处方模板详细
                paramurl = string.Format($"/api/mzsf/GetMzPatternDetails");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                var detail_result = WebApiHelper.DeserializeObject<ResponseResult<List<MzChargePatternDetailVM>>>(json);
                if (detail_result.status == 1)
                {
                    SessionHelper.MzChargePatternDetails = detail_result.data;
                }
                //处方类型
                paramurl = string.Format($"/api/mzsf/GetOrderTypes");
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.mzOrderTypes = WebApiHelper.DeserializeObject<ResponseResult<List<OrderTypeVM>>>(json).data;

                //支付类型比较 
                paramurl = string.Format($"/api/GuaHao/GetPageChequeCompares");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.pageChequeCompares = WebApiHelper.DeserializeObject<ResponseResult<List<PageChequeCompareVM>>>(json).data;

                //支付类型比较 
                paramurl = string.Format($"/api/GuaHao/GetYbName");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.ybNames = WebApiHelper.DeserializeObject<ResponseResult<List<YbNameVM>>>(json).data;


                //医保目录类型比较 
                paramurl = string.Format($"/api/GuaHao/GetYbhzzdList");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                SessionHelper.ybhzCompare = WebApiHelper.DeserializeObject<ResponseResult<List<YbhzzdVM>>>(json).data;

                //医保字典 
                paramurl = string.Format($"/api/YbInfo/GetInsutypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.insutypes = WebApiHelper.DeserializeObject<ResponseResult<List<InsutypeVM>>>(json).data;

                paramurl = string.Format($"/api/YbInfo/GetMdtrtCertTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.mdtrtCertTypes = WebApiHelper.DeserializeObject<ResponseResult<List<MdtrtCertTypeVM>>>(json).data;


                paramurl = string.Format($"/api/YbInfo/GetMedTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.medTypes = WebApiHelper.DeserializeObject<ResponseResult<List<MedTypeVM>>>(json).data;


                paramurl = string.Format($"/api/YbInfo/GetDiagTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.diagTypes = WebApiHelper.DeserializeObject<ResponseResult<List<DiagTypeVM>>>(json).data;


                paramurl = string.Format($"/api/YbInfo/GetIcdCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.icdCodes = WebApiHelper.DeserializeObject<ResponseResult<List<IcdCodeVM>>>(json).data;


                paramurl = string.Format($"/api/YbInfo/GetBirctrlTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.birctrlTypes = WebApiHelper.DeserializeObject<ResponseResult<List<BirctrlTypeVM>>>(json).data;

                //客户端配置 
                paramurl = string.Format($"/api/GuaHao/GetMzClientConfig");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                MzClientConfigVM mzClientConfig = WebApiHelper.DeserializeObject<ResponseResult<MzClientConfigVM>>(json).data;
                if (mzClientConfig != null)
                {
                    //系统配置信息，医院名称，版本号，挂号搜索词长度配置等
                    SessionHelper.MzClientConfigVM = mzClientConfig;
                }
                else
                {
                    UIMessageTip.Show("没有获取到数据库客户端配置数据");
                    log.Error("没有获取到数据库客户端配置数据");
                }
                //电子发票配置 
                paramurl = string.Format($"/api/GuaHao/GetFPConfig");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                FpConfigVM fpConfigVM = WebApiHelper.DeserializeObject<ResponseResult<FpConfigVM>>(json).data;
                if (fpConfigVM != null)
                {
                    //电子发票配置
                    SessionHelper.fpConfigVM = fpConfigVM;
                }
                else
                {
                    UIMessageTip.Show("没有获取到数据库发票配置数据");
                    log.Error("没有获取到数据库发票配置数据");
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }

        }
    }
}
