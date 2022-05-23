﻿using Client.ViewModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Client.ClassLib;
using System.Configuration;
using log4net;
using System.Net;
using System.IO;
using System.Web;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Client
{
    public partial class GuaHao : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(GuaHao));//typeof放当前类
        public GuaHao()
        {
            InitializeComponent();

            //this.DoubleBuffered = true;//设置本窗体
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            //SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        /// <summary>
        /// 解决页面频繁刷新时界面闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        //定义挂号数据字典 
        public Dictionary<string, List<GHRequestVM>> requestDic = new Dictionary<string, List<GHRequestVM>>();
        public string request_key = "";

        //定义当前用户信息
        public string patient_id = "";
        public static PatientVM PatientVM;

        Color cur_color = Color.FromArgb(0, 150, 136);

        UIHeaderAsideMainFooterFrame parentForm;

        Client.Forms.Wedgit.KeySuggest ks;

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        public void GuaHao_Load(object sender, EventArgs e)
        {
            log.Debug("Load");
            log.Debug((new System.Diagnostics.StackTrace().GetFrame(0).GetMethod()).Name);

            log.Debug("初始化界面控件显示");
            InitUIText();

            parentForm = this.Parent as UIHeaderAsideMainFooterFrame;

            log.Debug("加载挂号数据");
            LoadRequestInfo();

            this.dtpGhrq.ValueChanged += dtpGhrq_ValueChanged;

            this.uiButton1.Style = UIStyle.Orange;

            //加载身份证读卡器（精伦）
            //log.Debug("启动身份证读卡器（精伦）");
            //timer1.Interval = 3000;
            //timer1.Start();


        }

        /// <summary>
        /// 初始化界面控件显示
        /// </summary>
        public void InitUIText()
        { 
            cur_color = (this as UIPage).RectColor;

            this.gbxUnits.RectColor = Color.Transparent;
             
            gbxUnits.Controls.Clear();
             
            patient_id = "";
            InitUserInfo();

            lblTitle.ForeColor = cur_color;
            lblMsg.ForeColor = Color.Red;
            gbxUnits.ForeColor = cur_color;

            //初始化刷卡方式按钮样式
            btnCika.FillColor = cur_color;
            btnSFZ.FillColor = Color.LightSteelBlue;
            btnYBK.FillColor = Color.LightSteelBlue;

            //初始化上午，下午按钮样式
            if (DateTime.Now.Hour < 12)
            {

                btnAM.FillColor = cur_color;
                btnPM.FillColor = Color.LightSteelBlue;
            }
            else
            {
                btnAM.FillColor = Color.LightSteelBlue;
                btnPM.FillColor = cur_color;
            }
             
            this.dtpGhrq.Value = DateTime.Now;

            request_key = "";
            gbxUnits.Text = "选择科室";
        }


        private void btnEditUser_Click(object sender, EventArgs e)
        {
            //var code = this.btnEditUser.TagString;
            //if (string.IsNullOrEmpty(this.btnEditUser.TagString))
            //{
            //    if (string.IsNullOrEmpty(this.txtCode.Text))
            //    {
            //        lblMsg.Text = "请刷卡！";
            //        lblMsg.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        code = this.txtCode.Text.Trim();
            //    }
            //}
            if (string.IsNullOrEmpty(this.txtCode.Text))
            {
                UIMessageTip.ShowError("请刷卡!");
                lblMsg.Text = "请刷卡！";
                txtCode.Focus();
                return;
            }
            var code = this.txtCode.Text.Trim();
            UserInfoEdit ue = new UserInfoEdit(code, dto);
            //关闭，刷新
            ue.FormClosed += Ue_FormClosed1;

            //先停止读卡器
            log.Debug("打开编辑界面，关闭读卡器");
            //timer1.Stop();


            ue.ShowDialog();

            if (ue.DialogResult == DialogResult.Cancel)
            {
                //txtCode.Text = ue.barCode;

                //关闭编辑界面，读卡器
                //timer1.Start();
                log.Debug("关闭编辑界面，读卡器");
            }
        }

        private void Ue_FormClosed1(object sender, FormClosedEventArgs e)
        {
            SearchUser();
        }

        private void btnAM_Click(object sender, EventArgs e)
        {
            if (btnAM.FillColor != cur_color)
            {
                btnAM.FillColor = cur_color;
                btnPM.FillColor = Color.LightSteelBlue;

                //todo:查询
                LoadRequestInfo();
            }

        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            if (btnPM.FillColor != cur_color)
            {
                btnAM.FillColor = Color.LightSteelBlue;
                btnPM.FillColor = cur_color;
                //todo:查询
                LoadRequestInfo();

            }
        }

        //public void LoadRequestInfo()
        //{ 
        //    Action action = () =>
        //    {
        //        InvokeGhData();
        //    };
        //    Invoke(action);
        //}

        /// <summary>
        /// 加载挂号信息
        /// </summary>
        public void LoadRequestInfo()
        {

            string dh_data = this.dtpGhrq.Text;
            string ampm = btnAM.FillColor == cur_color ? "a" : "p";

            Task<HttpResponseMessage> task = null;
            string json = "";

            var d = new
            {
                request_date = dh_data,
                unit_sn = "",
                clinic_type = "",
                doctor_sn = " ",
                group_sn = " ",
                req_type = "",
                ampm = ampm,
                win_no = "",
            };
            //string paramurl = string.Format($"GetGhRequest/?request_date={d.request_date}&ampm={d.ampm}&unit_sn={d.unit_sn}&clinic_type={d.clinic_type}&doctor_sn={d.doctor_sn}&group_sn={d.group_sn}&req_type={d.req_type}&win_no={d.win_no}");
            string paramurl = string.Format($"/api/GuaHao/GetGhRequest?request_date={d.request_date}&ampm={d.ampm}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);

            try
            {
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
            }
            catch (Exception ex)
            {
                log.Error("请求接口数据出错：" + ex.Message);
            }

            var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<GHRequestVM>>>(json);
            if (listApi.data == null)
            {
                return;
            }
            //整理数据
            requestDic = new Dictionary<string, List<GHRequestVM>>();
            foreach (var item in listApi.data)
            {

                if (!requestDic.Keys.Contains(item.unit_name))
                {
                    List<GHRequestVM> list = new List<GHRequestVM>();
                    list.Add(item);
                    requestDic.Add(item.unit_name, list);
                }
                else
                {
                    requestDic[item.unit_name].Add(item);
                }
            }
            BindUnit(requestDic);

        }

        public void BindUnit(Dictionary<string, List<GHRequestVM>> source)
        {
            #region 绑定可选科室信息

            gbxUnits.Controls.Clear();
            int left = 0, top = 0;
            int btnWidth = 220;
            int btnHeight = 60;
            int btnmargin = 25;
            int leftmargin = 50;

            int textsize = 11;

            //int rowCount = 4;

            //计算rowCount

            //gbxUnits.Width = 1000;
            int rowCount = (gbxUnits.Width - leftmargin) / (btnWidth + btnmargin);

            for (int i = 0; i < source.Keys.Count; i++)
            {
                UIButton btn1 = new UIButton();


                btn1.Style = UIStyle.LayuiGreen;
                btn1.Width = btnWidth;
                btn1.Height = btnHeight;
                btn1.Text = source.Keys.ElementAt(i);
                btn1.Tag = source.Keys.ElementAt(i);
                if (btn1.Text.Length > textsize * 2)
                {
                    btn1.Text = btn1.Text.Substring(0, textsize) + "\r\n" + btn1.Text.Substring(textsize, textsize) + "\r\n" + btn1.Text.Substring(textsize * 2);
                }
                else if (btn1.Text.Length > textsize)
                {
                    btn1.Text = btn1.Text.Substring(0, textsize) + "\r\n" + btn1.Text.Substring(textsize);
                }

                if (i % rowCount == 0)
                {
                    left = 0;
                }

                if (left != 0)
                {
                    left += (int)(btn1.Width + btnmargin);
                }
                else
                {
                    //left = (gbxUnits.Width - (rowCount * btn1.Width + (rowCount - 1) * btnmargin)) / 2;
                    left = leftmargin;
                    if (left < 0)
                    {
                        left = 0;
                    }
                    if (top != 0)
                    {
                        top += (int)(btn1.Height * 1.5);
                    }
                    else
                    {
                        top = (int)(btn1.Height);
                    }
                }
                btn1.Top = top;
                btn1.Left = left;
                btn1.Click += btnks_Click;
                gbxUnits.Controls.Add(btn1);
            }

            #endregion
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 科室按钮选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnks_Click(object sender, EventArgs e)
        {
            //判断当前是否可以挂号

            //如果当前时间是下午，不允许挂上午的号
            if (DateTime.Now.ToString("yyyy-MM-dd") == this.dtpGhrq.Text && DateTime.Now.Hour > 12 && btnAM.FillColor == cur_color)
            {
                UIMessageTip.ShowError("请选择下午的号进行挂号操作!");
                lblMsg.Text = "请选择下午的号进行挂号操作！";

                return;
            }


            if (string.IsNullOrEmpty(txtCode.Text))
            {
                UIMessageTip.ShowError("请刷卡!");
                lblMsg.Text = "请刷卡！";
                txtCode.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtCode.Text) && string.IsNullOrEmpty(btnEditUser.TagString))
            {
                UIMessageTip.ShowError("未获取到用户信息!");
                lblMsg.Text = "未获到取用户信息！";
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PatientVM.social_no))
            {
                UIMessageTip.ShowError("用户身份证信息为空，请编辑保存!");
                lblMsg.Text = "未获到取用户身份证信息，请编辑保存！";
                txtCode.Focus();
                return;
            }

            SessionHelper.patientVM = PatientVM;

            var btn = sender as UIButton;

            SelctClinic sc = new SelctClinic(requestDic[btn.Tag.ToString()], btnEditUser.TagString);

            sc.FormClosed += Sc_FormClosed;

            sc.ShowDialog();
        }

        private void Sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭 刷新
            LoadRequestInfo();
            //InitUIText(); 
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            InitUserInfo();
           
        }

        private void dtpGhrq_ValueChanged(object sender, DateTime value)
        {
            dtpGhrq.ValueChanged -= dtpGhrq_ValueChanged;
            //如果日期小于今天 
            var todays = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

            if (dtpGhrq.Value < todays)
            {
                UIMessageTip.ShowError("日期不能小于今天!");
                dtpGhrq.Value = todays;
            }
            dtpGhrq.ValueChanged += dtpGhrq_ValueChanged;

            LoadRequestInfo();
        }



        private void btnCika_Click(object sender, EventArgs e)
        {
            SearchUser();

            //更改刷卡方式按钮样式
            btnCika.FillColor = cur_color;
            btnSFZ.FillColor = Color.LightSteelBlue;
            btnYBK.FillColor = Color.LightSteelBlue;

            var barcode = this.txtCode.Text.Trim();
            lblMsg.Text = "";
            if (string.IsNullOrEmpty(barcode))
            {
                this.txtCode.Focus();
            }

            //ReadCard rc = new ReadCard("磁卡");
            ////关闭，刷新
            //rc.FormClosed += Rc_FormClosed;
            //rc.ShowDialog();

        }

        private void Rc_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SessionHelper.cardno))
            {
                txtCode.Text = SessionHelper.cardno;
                SearchUser();
            }
        }

        private void btnSFZ_Click(object sender, EventArgs e)
        {
            btnSFZ.FillColor = cur_color;
            btnCika.FillColor = Color.LightSteelBlue;
            btnYBK.FillColor = Color.LightSteelBlue;
            ReadCard rc = new ReadCard("身份证");
            //关闭，刷新
            rc.FormClosed += Rc_FormClosed;
            rc.ShowDialog();
        }

        private void btnYBK_Click(object sender, EventArgs e)
        {
            YBHelper.currentYBInfo = null;


            btnSFZ.FillColor = Color.LightSteelBlue;
            btnYBK.FillColor = cur_color;
            btnCika.FillColor = Color.LightSteelBlue;
               
            // string json = "{\"infno\":\"1101\",\"msgid\":\"H42100300513202109271813033258\",\"mdtrtarea_admvs\":\"421300\",\"insuplc_admdvs\":\"421300\",\"recer_sys_code\":\"1\",\"dev_no\":\"\",\"dev_safe_info\":\"\",\"cainfo\":\"\",\"signtype\":\"\",\"infver\":\"v2.0\",\"opter_type\":\"1\",\"opter\":\"00000\",\"opter_name\":\"全院\",\"inf_time\":\"2021-09-27 18:13:03\",\"fixmedins_code\":\"H42100300513\",\"fixmedins_name\":\"荆州市中心医院\",\"sign_no\":\"421000G0000000244038\",\"input\":{\"data\":{\"mdtrt_cert_type\":\"02\",\"mdtrt_cert_no\":\"                    \",\"card_sn\":\"                    \",\"begntime\":\"                    \",\"psn_cert_type\":\"1\",\"certno\":\"                    \",\"psn_name\":\"                    \"}}}" ;

            YBRequest<UserInfoRequestModel> request = new YBRequest<UserInfoRequestModel>();
            request.infno = ((int)InfoNoEnum.人员信息).ToString();
            request.msgid = YBHelper.msgid;
            request.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;
            request.insuplc_admdvs = "421002";
            request.recer_sys_code = YBHelper.recer_sys_code;
            request.dev_no = "";
            request.dev_safe_info = "";
            request.cainfo = "";
            request.signtype = "";
            request.infver = YBHelper.infver;
            request.opter_type = YBHelper.opter_type;
            request.opter = SessionHelper.uservm.user_mi;
            request.opter_name = SessionHelper.uservm.name;
            request.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            request.fixmedins_code = YBHelper.fixmedins_code;
            request.fixmedins_name = YBHelper.fixmedins_name;
            request.sign_no = YBHelper.msgid;

            request.input = new RepModel<UserInfoRequestModel>();
            request.input.data = new UserInfoRequestModel();
            request.input.data.mdtrt_cert_type = "03";
            request.input.data.psn_cert_type = "1";

            string json = WebApiHelper.SerializeObject(request);


            try
            {
                //var res = DataPost("http://10.87.82.212:8080", json);

                //调用 com名称  方法  参数
                string BusinessID = "1101";
                string Dataxml = json;
                string Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                var result = InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);
                 
                log.Debug(parm[2]);

                YBResponse<UserInfoResponseModel> yBResponse = WebApiHelper.DeserializeObject<YBResponse<UserInfoResponseModel>>(parm[2].ToString());

                if (!string.IsNullOrEmpty(yBResponse.err_msg))
                {
                    MessageBox.Show(yBResponse.err_msg);
                }
                else if (yBResponse.output != null && !string.IsNullOrEmpty(yBResponse.output.baseinfo.certno))
                { 
                    YBHelper.currentYBInfo = yBResponse;

                    SessionHelper.cardno = yBResponse.output.baseinfo.certno;
                    txtCode.Text = SessionHelper.cardno;
                    SearchUser();

                    if (!string.IsNullOrEmpty(btnEditUser.TagString))
                    {
                        //保存用户的医保信息
                        var d = new
                        {
                            yb_psn_no = yBResponse.output.baseinfo.psn_no,
                            pid = btnEditUser.TagString,
                            yb_insuplc_admdvs = yBResponse.output.insuinfo[0].insuplc_admdvs,
                            yb_insutype = yBResponse.output.insuinfo[0].insutype,
                            opera = SessionHelper.uservm.user_mi
                        };
                        var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        var paramurl = string.Format($"/api/GuaHao/UpdateUserYBInfo?pid={d.pid}&yb_psn_no={d.yb_psn_no}&yb_insutype={d.yb_insutype}&yb_insuplc_admdvs={d.yb_insuplc_admdvs}");

                        string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                        var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);

                        if (responseJson.data == 1)
                        {
                            log.Debug("修改用户医保信息成功");

                        }
                        else
                        {
                            log.Error(responseJson.message);
                        }
                    }

                   
                }



                //string res = client.PostAsync("", httpContent).Result.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                log.Error("请求接口数据出错：" + ex.Message);
            }

        }

        [DllImport("ole32.dll")]
        static extern int CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid pclsid);

        public static object InvokeMethod(string comName, string methodName, ref object[] args)
        {

            object ret = null;
            COMInfo com = GetCOMInfo(comName);
            try
            {
                //用参数的索引属性来指出哪些参数是一个返回的参数
                //对于那些是[in]或ByRef的参数可以不用指定
                ParameterModifier[] ParamMods = new ParameterModifier[1];
                ParamMods[0] = new ParameterModifier(3); // 初始化为接口参数的个数
                ParamMods[0][2] = true; // 设置第三个参数为返回参数


                ret = com.COMType.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, com.Instance, args, ParamMods,
                                                         null,
                                                         null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


        public static COMInfo GetCOMInfo(string comName)
        {
            COMInfo comInfo;
            Type type;
            object instance = null;
            instance = CreateInstance(comName, out type);
            comInfo = new COMInfo(type, instance);
            return comInfo;
        }


        private static object CreateInstance(string progName, out Type type)
        {
            object instance = null;
            type = null;
            try
            {
                Guid clsid;
                int result = CLSIDFromProgID(progName, out clsid);
                type = Type.GetTypeFromCLSID(clsid, true);
                instance = Activator.CreateInstance(type);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return instance;
        }



        private void btntest_Click(object sender, EventArgs e)
        {
            //static HttpClient client = new HttpClient();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void btnTuihao_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(btnEditUser.TagString))
            //{
            //    UIMessageTip.ShowError("请刷卡!");
            //    lblMsg.Text = "请刷卡！";
            //    txtCode.Focus();
            //    return;
            //}
            //else
            //{
            //    Refund rf = new Refund(txtCode.Text.Trim());
            //    rf.ShowDialog();
            //}

            Refund rf = new Refund(txtCode.Text.Trim());
            rf.ShowDialog();

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            InitUIText();

        }

        private void gbxUnits_Click(object sender, EventArgs e)
        {

        }

        private void pnlTitle_Click(object sender, EventArgs e)
        {

        }

        CardReader dto;
        /// <summary>
        /// 读身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            dto = ReadIdCardHelper.Reader();
            if (dto.Data != null)
            {
                if (this.txtCode.Text != dto.Data.IDCard)
                {
                    this.txtCode.Text = dto.Data.IDCard;
                    log.Debug("读卡信息：" + dto.Data.IDCard + "," + dto.Data.Name + "," + dto.Data.Sex);
                }
            }
            if (dto.Msg != "" && dto.Msg != "精伦IDR210：请重新放置身份证!")
            {

                //if (parentForm.tlsInfo.Text != dto.Msg)
                //{
                //    log.Debug("读卡错误：" + dto.Msg);
                //    Parent.tlsInfo.Text = dto.Msg;
                //}
            }
            else
            {
                //parentForm.tlsInfo.Text = "";
            }
        }

        private void GuaHao_FormClosing(object sender, FormClosingEventArgs e)
        {
            //parentForm.tlsInfo.Text = "";
            log.Debug("关闭身份证读卡器（精伦）");
            timer1.Dispose();
        }

        private void gbxUnits_Scroll(object sender, ScrollEventArgs e)
        {
            gbxUnits.Invalidate(true);
        }


        /// <summary>
        /// 新用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            //清空缓存
            SessionHelper.CardReader = null;
            YBHelper.currentYBInfo = null;

            UserInfoEdit ue = new UserInfoEdit("", null);
            ue.FormClosed += Ue_FormClosed;
            ue.ShowDialog();
        }

        private void Ue_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SessionHelper.cardno))
            {
                txtCode.Text = SessionHelper.cardno;
                SearchUser();
            }
        }

        private void GuaHao_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCode.Focused)
            {
                return;
            }

            ks = new Forms.Wedgit.KeySuggest(this);
            Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;

            ks.Top = SessionHelper.clientHeight - ks.Height;
            ks.Left = SessionHelper.clientWidth - ks.Width;

            //340 280
            //ks.txtKeySearch.TextChanged += TxtKeySearch_TextChanged;

            //ks.txtKeySearch.Text = e.KeyData.DisplayText();

            ks.Deactivate += Ks_LostFocus;

            ks.FormClosing += Ks_FormClosing;

            ks.Show();

        }

        private void Ks_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show(request_key);

            if (!string.IsNullOrWhiteSpace(request_key))
            {
                //var source = requestDic.Where(p=>p.Key==request_key);

                Dictionary<string, List<GHRequestVM>> source = new Dictionary<string, List<GHRequestVM>>();
                source.Add(request_key, requestDic[request_key]);
                BindUnit(source);
                gbxUnits.Text = "选择科室(" + request_key + ")";
            }
        }

        private void TxtKeySearch_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();


        }

        private void Ks_LostFocus(object sender, EventArgs e)
        {
            ks.Close();


        }

        private void GuaHao_KeyDown(object sender, KeyEventArgs e)
        {
            //pnlKeySuggest.Top = this.Height - pnlKeySuggest.Height;
            //pnlKeySuggest.Left = this.Width - pnlKeySuggest.Width;

            //pnlKeySuggest.Top = 600;
            //pnlKeySuggest.Left = 1000;
            //pnlKeySuggest.BringToFront();
            //pnlKeySuggest.BackColor = Color.Red;

            //txtKeySearch.Focus();
            //pnlKeySuggest.Visible = true; 
        }

        private void GuaHao_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("2");

        }

        private void lblmarry_Click(object sender, EventArgs e)
        {

        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //清空缓存
                SessionHelper.CardReader = null;
                YBHelper.currentYBInfo = null;
                SearchUser();
            }
        }

        public void InitUserInfo()
        {
            lblMsg.Text = "";
            btnEditUser.TagString = ""; btnEditUser.Hide();
            lblName.Text = "";
            lblAge.Text = "";
            lblstreet.Text = "";
            lbldistrict.Text = "";
            lblsfz.Text = "";
            lblhometel.Text = "";
            lblSex.Text = "";
            lblbirth.Text = "";
            lblmarry.Text = "";
          
        }

        public void SearchUser()
        {

            var barcode = this.txtCode.Text.Trim();
            lblMsg.Text = "";
            if (string.IsNullOrEmpty(barcode))
            {
                InitUIText();
                return;
            }


            List<PatientVM> listApi = new List<PatientVM>();
            //获取数据 
           
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={barcode}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                    listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;
                }


                if (listApi.Count > 0)
                {
                    var userInfo = listApi[0];
                    PatientVM = userInfo;
                    if (string.IsNullOrEmpty(userInfo.name))
                    {
                        return;
                    }

                    btnEditUser.TagString = userInfo.patient_id.ToString(); btnEditUser.Show();
                    //this.txtpatientid.Text = userInfo["patient_id"].ToString();
                    lblName.Text = userInfo.name.ToString();
                    lblAge.Text = userInfo.age.ToString();
                    lblhometel.Text = userInfo.home_tel.ToString();
                    lblSex.Text = userInfo.sex == "1" ? "男" : "女";
                    lblbirth.Text = userInfo.birthday.HasValue ? userInfo.birthday.Value.ToShortDateString() : "";
                    if (userInfo.marry_code == ((int)MarryCodeEnum.Yihun).ToString())
                    {
                        lblmarry.Text = EnumExtension.GetDescription(MarryCodeEnum.Yihun);
                    }
                    else if (userInfo.marry_code == ((int)MarryCodeEnum.Lihun).ToString())
                    {
                        lblmarry.Text = EnumExtension.GetDescription(MarryCodeEnum.Lihun);
                    }
                    else if (userInfo.marry_code == ((int)MarryCodeEnum.Qita).ToString())
                    {
                        lblmarry.Text = EnumExtension.GetDescription(MarryCodeEnum.Qita);
                    }
                    else if (userInfo.marry_code == ((int)MarryCodeEnum.Sangou).ToString())
                    {
                        lblmarry.Text = EnumExtension.GetDescription(MarryCodeEnum.Sangou);
                    }
                    else if (userInfo.marry_code == ((int)MarryCodeEnum.Weinhun).ToString())
                    {
                        lblmarry.Text = EnumExtension.GetDescription(MarryCodeEnum.Weinhun);
                    }
                    else
                    {
                        lblmarry.Text = userInfo.marry_code;
                    }
                    if (!string.IsNullOrEmpty(userInfo.home_district))
                    {
                        var model = SessionHelper.districtCodes.Where(p => p.code == userInfo.home_district).FirstOrDefault();

                        if (model != null)
                        {
                            lbldistrict.Text = model.name;
                        }
                    }

                    lblstreet.Text = userInfo.home_street;
                    lblsfz.Text = userInfo.social_no; ;

                    //自动设置对应卡类型按钮样式
                    if (barcode == userInfo.social_no)
                    {
                        //初始化刷卡方式按钮样式
                        btnCika.FillColor = Color.LightSteelBlue;
                        btnSFZ.FillColor = cur_color;
                        btnYBK.FillColor = Color.LightSteelBlue;
                    }
                    else if (barcode == userInfo.hic_no)
                    {
                        //初始化刷卡方式按钮样式
                        btnCika.FillColor = Color.LightSteelBlue;
                        btnSFZ.FillColor = Color.LightSteelBlue;
                        btnYBK.FillColor = cur_color;
                    }
                    else
                    {
                        //初始化刷卡方式按钮样式
                        btnCika.FillColor = cur_color;
                        btnSFZ.FillColor = Color.LightSteelBlue;
                        btnYBK.FillColor = Color.LightSteelBlue;
                    }
                }
                else
                {

                    lblMsg.Text = "没有查询到数据";

                    InitUserInfo();

                    //身份证
                    if (SessionHelper.CardReader != null || YBHelper.currentYBInfo != null)
                    {
                        //自动打开创建新用户窗口
                        UserInfoEdit ue = new UserInfoEdit("", null);
                        ue.FormClosed += Ue_FormClosed;
                        ue.ShowDialog();

                    }
                    else if (true)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
            finally
            {

            }

        }
    }
}
