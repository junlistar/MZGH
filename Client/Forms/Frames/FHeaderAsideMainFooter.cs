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

namespace Client
{
    public partial class FHeaderAsideMainFooter : UIHeaderAsideMainFooterFrame
    {
        private static ILog log = LogManager.GetLogger(typeof(FHeaderAsideMainFooter));//typeof放当前类

        static int iOperCount = 0;//记录上时间未操作的时间
        static int LogOutSeconds = 0;

        List<XTUserGroupVM> function_list;
        List<XTFunctionsVM> all_list;

        public FHeaderAsideMainFooter()
        {
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

        }


        public void MenuBind()
        {
            //设置关联
            Aside.TabControl = MainTabControl;
            Aside.TabControl.ShowCloseButton = true;
            //Aside.TabControl.TabVisible = true; 

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
                Aside.CreateChildNode(parent, "基础号表维护", 61508, 24, 1303);
                Aside.CreateChildNode(parent, "生成号表", 61637, 24, 1304);
                Aside.CreateChildNode(parent, "号表维护", 61674, 24, 1305);
                Aside.CreateChildNode(parent, "临时号表维护", 61508, 24, 1306);
                Aside.CreateChildNode(parent, "时间段维护", 261463, 24, 1301);
                Aside.CreateChildNode(parent, "分时段维护", 261463, 24, 1302);

                pageIndex = 1400;
                parent = Aside.CreateNode("用户报表", 61953, 24, pageIndex);
                Aside.CreateChildNode(parent, "综合统计报表", 61568, 24, 1401);

                pageIndex = 1500;
                parent = Aside.CreateNode("权限管理", 361573, 24, pageIndex);
                Aside.CreateChildNode(parent, "用户管理", 361875, 24, 1502);
               // Aside.CreateChildNode(parent, "菜单管理", 361875, 24, 1501);
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
                    if (function_list.Where(p => p.func_desc.Trim() == "基础号表维护").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "基础号表维护", 61508, 24, 1303);
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


                }
                pageIndex = 1400;
                if (function_list.Where(p => p.func_desc.Trim() == "用户报表").Count() > 0)
                {
                    parent = Aside.CreateNode("用户报表", 61953, 24, pageIndex);
                    if (function_list.Where(p => p.func_desc.Trim() == "综合统计报表").Count() > 0)
                    {
                        Aside.CreateChildNode(parent, "综合统计报表", 61568, 24, 1401);
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
                    case 1201:
                        obj = new GuahaoRijie(); break;
                    case 1202:
                        obj = new ShoufeiRijie(); break;
                    case 1401:
                        obj = new UserReport(); break;
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

                obj.TagString = pageIndex.ToString();
                obj.FormClosing += Obj_FormClosing; ;
                page = AddPage(obj, pageIndex);
            }
            SelectPage(pageIndex);


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

        private void Obj_FormClosing(object sender, FormClosingEventArgs e)
        {
            //RemovePage(int.Parse((sender as UIPage).TagString));//
            Aside.TabControl.RemovePage(int.Parse((sender as UIPage).TagString));
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
            try
            {

                this.MinimumSize = new Size(this.Width, this.Height);

                //显示默认页面
                AddPage(new Client.Forms.Pages.DefaultPage());

                //隐藏框架头部
                Header.Hide();

                this.Hide();

                tlsInfo.Text = "";

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

                    //获取菜单权限 
                    GetUserFunctions(SessionHelper.uservm.user_group);

                    //绑定名称，版本号
                    this.Text = SessionHelper.MzClientConfigVM.client_name + " " + SessionHelper.MzClientConfigVM.client_version;

                    //绑定菜单
                    MenuBind();

                    SessionHelper.clientHeight = this.Height;
                    SessionHelper.clientWidth = this.Width;

                    this.FormClosing += FHeaderAsideMainFooter_FormClosing;

                    //ping
                    //_demoBGWorker.DoWork += BGWorker_DoWork;
                    //_demoBGWorker.RunWorkerAsync();
                    //_demoBGWorker.WorkerReportsProgress = true;
                    //_demoBGWorker.ProgressChanged += BGWorker_ProgressChanged;

                    //timerSignal.Interval = 1000 * 5;//10s
                    //timerSignal.Start();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                UIMessageTip.Show(ex.Message);
            }
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
                log.Error(ex.StackTrace);
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

        public void InitDic()
        {
            try
            {

                log.Info("初始化数据字典：InitDic");

                //获取用户费别信息 
                string json;
                string paramurl = string.Format($"/api/GuaHao/GetChargeTypes");

                //log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                //task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                //task.Wait();
                //var response = task.Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    var read = response.Content.ReadAsStringAsync();
                //    read.Wait();
                //    json = read.Result;
                //}
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

                //获取用户   
                paramurl = string.Format($"/api/GuaHao/GetRelativeCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                SessionHelper.relativeCodes = WebApiHelper.DeserializeObject<ResponseResult<List<RelativeCodeVM>>>(json).data;

                //支付类型比较 
                paramurl = string.Format($"/api/GuaHao/GetPageChequeCompares");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                SessionHelper.pageChequeCompares = WebApiHelper.DeserializeObject<ResponseResult<List<PageChequeCompareVM>>>(json).data;

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
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.StackTrace);
            }

            //SessionHelper.pay_xianjin = ConfigurationManager.AppSettings.Get("pay_xianjin");
            //SessionHelper.pay_weixin = ConfigurationManager.AppSettings.Get("pay_weixin");
            //SessionHelper.pay_zhifubao = ConfigurationManager.AppSettings.Get("pay_zhifubao");
            //SessionHelper.pay_yinlian = ConfigurationManager.AppSettings.Get("pay_yinlian");
            //SessionHelper.pay_yibao = ConfigurationManager.AppSettings.Get("pay_yibao");

            //SessionHelper.pay_xianjin = SessionHelper.pageChequeCompares.Where(p=>p.page_code=="1").FirstOrDefault().his_code;
            //SessionHelper.pay_weixin = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
            //SessionHelper.pay_zhifubao = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
            //SessionHelper.pay_yinlian = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
            //SessionHelper.pay_yibao = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
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
                if (result.status == 1)
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
                    this.FormClosing -= FHeaderAsideMainFooter_FormClosing;
                    this.Close();
                }
            }
        }

    }
}
