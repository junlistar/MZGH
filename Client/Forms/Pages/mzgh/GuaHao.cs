using Client.ViewModel;
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
using System.Threading;
using Client.Forms.Wedgit;
using Client.Forms.Pages.mzgh;

namespace Client
{
    public partial class GuaHao : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(GuaHao));//typeof放当前类
        public GuaHao()
        {
            InitializeComponent();
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
        public List<GHRequestVM> clinicList;
        public string request_key = "";

        //定义当前用户信息
        public string patient_id = "";
        public static PatientVM PatientVM;

        Color cur_color = Color.FromArgb(0, 150, 136);

        UIHeaderAsideMainFooterFrame parentForm;

        //科室搜索框
        UIListBox lstunits = new UIListBox();

        Client.Forms.Wedgit.KeySuggest ks;
        bool isBreadHandleSet = false;//维护是否是手动设置面包屑状态

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

            //设置按钮提示文字信息
            uiToolTip1.SetToolTip(uiSymbolButton1, uiSymbolButton1.Text + "[F1]");
            uiToolTip1.SetToolTip(uiSymbolButton4, uiSymbolButton4.Text + "[F2]");
            uiToolTip1.SetToolTip(btnTuihao, btnTuihao.Text + "[F3]");
            uiToolTip1.SetToolTip(uiSymbolButton2, uiSymbolButton2.Text + "[F4]");

        }

        /// <summary>
        /// 初始化界面控件显示
        /// </summary>
        public void InitUIText()
        {
            try
            {
                cur_color = (this as UIPage).RectColor;
                isBreadHandleSet = true;
                uiBreadcrumb2.ItemIndex = 0;
                clinicList = null;

                patient_id = "";
                InitUserInfo();

                lblTitle.ForeColor = cur_color;
                lblMsg.ForeColor = Color.Red;
                gbxUnits.ForeColor = cur_color;

                int currentHour = DateTime.Now.Hour;
                pnlHours.Clear();
                var hourslist = SessionHelper.requestHours.OrderBy(p => p.start_hour).ToList();
                //foreach (var item in hourslist)
                for (int i = 0; i < hourslist.Count; i++)
                {
                    UIButton btn1 = new UIButton();
                    btn1.Style = UIStyle.Green;
                    btn1.StyleCustomMode = true;
                    btn1.Text = hourslist[i].name;
                    btn1.TagString = hourslist[i].code;
                    btn1.Width = 86;
                    btn1.Height = 31;

                    if (i == 0)
                    {
                        if (currentHour < hourslist[i].start_hour)
                        {
                            btn1.FillColor = Color.FromArgb(230, 80, 80);
                        }
                        else if (currentHour >= hourslist[i].start_hour && currentHour < hourslist[i].end_hour)
                        {
                            btn1.FillColor = Color.FromArgb(230, 80, 80);
                        }
                    }
                    else if (i > 0 && i < hourslist.Count)
                    {
                        if (currentHour < hourslist[i].start_hour && currentHour >= hourslist[i - 1].end_hour)
                        {
                            btn1.FillColor = Color.FromArgb(230, 80, 80);
                        }
                        else if (currentHour >= hourslist[i].start_hour && currentHour < hourslist[i].end_hour)
                        {
                            btn1.FillColor = Color.FromArgb(230, 80, 80);
                        }
                    }

                    btn1.Click += Btn1_Click;
                    pnlHours.Add(btn1);
                }
                pnlHours.RectColor = Color.Transparent;

                ////初始化明天，后天按钮
                //btnMingtian.FillColor = Color.FromArgb(110, 190, 40);
                //btnHoutian.FillColor = Color.FromArgb(110, 190, 40);

                this.dtpGhrq.Value = DateTime.Now;

                request_key = "";
                gbxUnits.Text = "选择科室";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var control in pnlHours.FlowLayoutPanel.Controls)
                {
                    var cc = control as UIButton;
                    cc.FillColor = Color.FromArgb(110, 190, 40);
                }
                var btn = sender as UIButton;
                btn.FillColor = Color.FromArgb(230, 80, 80); ;
                LoadRequestInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCode.Text) || btnEditUser1.TagString == "")
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
            APButtonClick(sender);
        }
        private void btnPM_Click(object sender, EventArgs e)
        {

            APButtonClick(sender);
        }
        private void btnMid_Click(object sender, EventArgs e)
        {
            APButtonClick(sender);
        }

        private void btnEve_Click(object sender, EventArgs e)
        {
            APButtonClick(sender);
        }
        public void APButtonClick(object sender)
        {

            var btn = sender as UIButton;
            btn.FillColor = cur_color;

            LoadRequestInfo();
        }
        /// <summary>
        /// 加载挂号信息
        /// </summary>
        public void LoadRequestInfo()
        {

            try
            {
                string dh_data = this.dtpGhrq.Text;

                string ampm = "";

                foreach (var control in pnlHours.FlowLayoutPanel.Controls)
                {
                    var cc = control as UIButton;
                    if (cc.FillColor == Color.FromArgb(230, 80, 80))
                    {
                        ampm = cc.TagString;
                        break;
                    }
                }


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
                string paramurl = string.Format($"/api/GuaHao/GetGhRequest?request_date={d.request_date}&ampm={d.ampm}");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);

                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        public void BindUnit(Dictionary<string, List<GHRequestVM>> source)
        {
            #region 绑定可选科室信息 使用系统panel控件

            //gbxUnits.Controls.Clear();
            //int left = 0, top = 0;
            //int btnWidth = 220;
            //int btnHeight = 60;
            //int btnmargin = 10;
            //int leftmargin = 10;
            //int topmargin = 10;

            //int textsize = 11;

            ////计算rowCount 
            //int rowCount = (gbxUnits.Width - leftmargin) / (btnWidth + btnmargin);

            //for (int i = 0; i < source.Keys.Count; i++)
            //{
            //    UIButton btn1 = new UIButton();


            //    btn1.Style = UIStyle.LayuiGreen;
            //    btn1.Width = btnWidth;
            //    btn1.Height = btnHeight;
            //    btn1.Text = source.Keys.ElementAt(i);
            //    btn1.Tag = source.Keys.ElementAt(i);
            //    if (btn1.Text.Length > textsize * 2)
            //    {
            //        btn1.Text = btn1.Text.Substring(0, textsize) + "\r\n" + btn1.Text.Substring(textsize, textsize) + "\r\n" + btn1.Text.Substring(textsize * 2);
            //    }
            //    else if (btn1.Text.Length > textsize)
            //    {
            //        btn1.Text = btn1.Text.Substring(0, textsize) + "\r\n" + btn1.Text.Substring(textsize);
            //    }

            //    if (i % rowCount == 0)
            //    {
            //        left = 0;
            //    }

            //    if (left != 0)
            //    {
            //        left += (int)(btn1.Width + btnmargin);
            //    }
            //    else
            //    { 
            //        left = leftmargin;
            //        if (left < 0)
            //        {
            //            left = 0;
            //        }
            //        if (top != 0)
            //        {
            //            top += (int)(btn1.Height * 1.3);
            //        }
            //        else
            //        {
            //            top = topmargin; 
            //        }
            //    }
            //    btn1.Top = top;
            //    btn1.Left = left;
            //    btn1.Click += btnks_Click;
            //    gbxUnits.Controls.Add(btn1);
            //}

            #endregion

            #region 绑定可选科室信息 使用系统uiFlowLayoutPanel控件

            gbxUnits.Clear();
            int btnWidth = 220;
            int btnHeight = 60;

            int textsize = 11;
            for (int i = 0; i < source.Keys.Count; i++)
            {
                UIButton btn1 = new UIButton();

                btn1.Style = UIStyle.LayuiGreen;
                btn1.StyleCustomMode = true;
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
                btn1.Click += btnks_Click;
                gbxUnits.Add(btn1);
            }

            #endregion
        }

        /// <summary>
        /// 绑定专科医生数据
        /// </summary>
        /// <param name="source"></param>
        public void BindClinic()
        {
            if (clinicList == null)
            {
                return;
            }
            List<GHRequestVM> list = clinicList;

            #region 绑定可选科室信息  使用系统panel控件

            //gbxUnits.Controls.Clear();
            //int left = 0, top = 0;
            //int btnWidth = 220;
            //int btnHeight = 60;
            //int btnmargin = 10;
            //int leftmargin = 10;
            //int topmargin = 10;

            ////计算rowCount 
            //int rowCount = (gbxUnits.Width - leftmargin) / (btnWidth + btnmargin);

            ////foreach (var item in source)
            //for (int i = 0; i < list.Count; i++)
            //{ 

            //    UIButton btn1 = new UIButton();
            //    btn1.Style = UIStyle.LayuiGreen;
            //    btn1.Width = btnWidth;
            //    btn1.Height = btnHeight;
            //    btn1.Text = list[i].clinic_name;
            //    btn1.TagString = list[i].record_sn;

            //    //处理剩余号数
            //    btn1.TipsText = (list[i].end_no - list[i].current_no + 1).ToString();
            //    btn1.ShowTips = true;
            //    btn1.TipsColor = Color.FromArgb(80, 160, 255);// Color.Blue;

            //    if (!string.IsNullOrEmpty(list[i].doctor_name))
            //    {
            //        btn1.Text += "\r\n" + list[i].doctor_name;
            //    }
            //    btn1.Text += " (￥" + list[i].je + "元)";

            //    if (i % rowCount == 0)
            //    {
            //        left = 0;
            //    }

            //    if (left != 0)
            //    {
            //        left += (int)(btn1.Width + btnmargin);
            //    }
            //    else
            //    {
            //        //left = (gbxUnits.Width - (rowCount * btn1.Width + (rowCount - 1) * btnmargin)) / 2;
            //        left = leftmargin;
            //        if (left < 0)
            //        {
            //            left = 0;
            //        }
            //        if (top != 0)
            //        {
            //            top += (int)(btn1.Height * 1.3);
            //        }
            //        else
            //        {
            //            top = topmargin;
            //            //top = (int)(btn1.Height);
            //        }
            //    }
            //    btn1.Top = top;
            //    btn1.Left = left;
            //    btn1.Click += btnClinic_Click;
            //    gbxUnits.Controls.Add(btn1);

            //}
            #endregion

            #region 绑定可选科室信息  使用系统uiFlowLayoutPanel控件

            gbxUnits.Clear();
            int btnWidth = 220;
            int btnHeight = 60;

            for (int i = 0; i < list.Count; i++)
            {
                UIButton btn1 = new UIButton();
                btn1.Style = UIStyle.LayuiGreen;
                btn1.Width = btnWidth;
                btn1.Height = btnHeight;
                btn1.Text = list[i].clinic_name;
                btn1.TagString = list[i].record_sn;

                //处理剩余号数
                btn1.TipsText = (list[i].end_no - list[i].current_no + 1).ToString();
                btn1.ShowTips = true;
                btn1.TipsColor = Color.FromArgb(80, 160, 255);// Color.Blue;

                if (!string.IsNullOrEmpty(list[i].doctor_name))
                {
                    btn1.Text += "\r\n" + list[i].doctor_name;
                }
                btn1.Text += " (￥" + list[i].je + "元)";

                btn1.Click += btnClinic_Click;
                gbxUnits.Add(btn1);
            }
            #endregion
        }

        /// <summary>
        /// 选择医生，进行挂号操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClinic_Click(object sender, EventArgs e)
        {
            //todo:判断是否挂了相同的号


            var btn = sender as UIButton;
            foreach (var item in clinicList)
            {
                if (item.record_sn == btn.TagString)
                {
                    if (CheckGhRepeat(btnEditUser1.TagString, item.record_sn))
                    {
                        UIMessageBox.ShowWarning("同时段存在相同挂号记录！");
                        break;
                    }

                    SelectPayType fe = new SelectPayType(item, btnEditUser1.TagString);
                    fe.ShowDialog();

                    uiBreadcrumb2.ItemIndex = 0;

                    //打印发票
                    if (SessionHelper.do_gh_print)
                    {
                        SessionHelper.do_gh_print = false;
                        GhPrint ghprint = new GhPrint();
                        ghprint.Show();
                    }
                }
            }

        }

        public bool CheckGhRepeat(string patient_id, string record_sn)
        {
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/CheckGhRepeat?patient_id={patient_id}&record_sn={record_sn}");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                if (result.status == 1)
                {
                    return result.data;
                }
                else
                {

                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
            return false;
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
            bool isWrong = false;

            //当前日期是今天
            if (DateTime.Now.ToString("yyyy-MM-dd") == this.dtpGhrq.Text)
            {

                foreach (var control in pnlHours.FlowLayoutPanel.Controls)
                {
                    var cc = control as UIButton;
                    if (cc.FillColor == cur_color)
                    {
                        var code = cc.TagString;
                        var requestHour = SessionHelper.requestHours.Where(p => p.code == code).FirstOrDefault();
                        if (DateTime.Now.Hour >= requestHour.end_hour)
                        {
                            isWrong = true;
                        }
                        break;
                    }
                }

            }
            if (isWrong)
            {
                UIMessageTip.ShowError("请选择正确的时间段进行挂号操作!");
                lblMsg.Text = "请选择正确的时间段进行挂号操作！";
                return;
            }

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                UIMessageTip.ShowError("请刷卡!");
                lblMsg.Text = "请刷卡！";
                txtCode.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtCode.Text) && string.IsNullOrEmpty(btnEditUser1.TagString))
            {
                UIMessageTip.ShowError("未获取到用户信息!");
                lblMsg.Text = "未获到取用户信息！";
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PatientVM.hic_no))
            {
                UIMessageTip.ShowError("用户身份证信息为空，请编辑保存!");
                lblMsg.Text = "未获到取用户身份证信息，请编辑保存！";
                txtCode.Focus();
                return;
            }

            SessionHelper.patientVM = PatientVM;

            var btn = sender as UIButton;

            #region 弹窗方式 更改为当前页
            //SelctClinic sc = new SelctClinic(requestDic[btn.Tag.ToString()], btnEditUser.TagString);
            //sc.FormClosed += Sc_FormClosed;
            //sc.ShowDialog();
            #endregion

            #region 当前页 加载方式
            isBreadHandleSet = true;
            uiBreadcrumb2.ItemIndex = 1;

            clinicList = requestDic[btn.Tag.ToString()];
            BindClinic();
            #endregion

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



        Color lvse = Color.FromArgb(110, 190, 40);
        Color hongse = Color.FromArgb(230, 80, 80);
        private void btnCika_Click(object sender, EventArgs e)
        {

            //更改刷卡方式按钮样式
            btnCika.FillColor = hongse;
            btnIDCard.FillColor = lvse;
            btnSFZ.FillColor = lvse;
            btnYBK.FillColor = lvse;

            ReadCika rc = new ReadCika("磁卡");
            rc.FormClosed += Rc_FormClosed;
            rc.ShowDialog();


            //var barcode = this.txtCode.Text.Trim();
            //lblMsg.Text = "";
            //if (string.IsNullOrEmpty(barcode))
            //{
            //    this.txtCode.Focus();
            //}
            //else
            //{
            //    SearchUser();
            //}

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
            //更改刷卡方式按钮样式
            btnCika.FillColor = lvse;
            btnIDCard.FillColor = lvse;
            btnSFZ.FillColor = hongse;
            btnYBK.FillColor = lvse;

            ReadCard rc = new ReadCard("身份证");
            //关闭，刷新
            //rc.FormClosed += Rc_FormClosed;
            if (rc.ShowDialog() == DialogResult.OK)
            {
                DoSearch();
            }
        }
        public void DoSearch()
        {
            if (!string.IsNullOrWhiteSpace(SessionHelper.cardno))
            {
                txtCode.Text = SessionHelper.cardno;
                SearchUser();
            }
        }

        private void btnYBK_Click(object sender, EventArgs e)
        {
            YBHelper.currentYBInfo = null;

            //更改刷卡方式按钮样式
            btnCika.FillColor = lvse;
            btnIDCard.FillColor = lvse;
            btnSFZ.FillColor = lvse;
            btnYBK.FillColor = hongse;

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

                var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

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

                    Task.Run(() =>
                    {
                        SaveCardData(yBResponse.output); SaveCardDataAll(parm[2].ToString());
                    });
                }
            }
            catch (Exception ex)
            {
                log.Error("请求接口数据出错：" + ex.Message);
            }

        }

        public void SaveCardData(UserInfoResponseModel model)
        {
            Task<HttpResponseMessage> task = null;
            string json = "";

            var d = new
            {
                psn_no = model.baseinfo.psn_no,
                psn_cert_type = model.baseinfo.psn_cert_type,
                certno = model.baseinfo.certno,
                psn_name = model.baseinfo.psn_name,
                gend = model.baseinfo.gend,
                naty = model.baseinfo.naty,
                brdy = model.baseinfo.brdy,
                age = model.baseinfo.age,
            };

            string paramurl = string.Format($"/api/user/UpdateYbkInfo?psn_no={d.psn_no}&psn_cert_type={d.psn_cert_type}&certno={d.certno}&psn_name={d.psn_name}&gend={d.gend}&naty={d.naty}&brdy={d.brdy}&age={d.age}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);
            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }

        }

        public void SaveCardDataAll(string jsonStr)
        {

            //更新医保其他信息  
            string paramurl = string.Format($"/api/user/UpdateYbkInfoAll");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                HttpContent httpContent = new StringContent(jsonStr);

                SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }

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
            Refund();
        }

        public void Refund()
        {
            if (string.IsNullOrEmpty(btnEditUser1.TagString))
            {
                UIMessageTip.ShowError("请刷卡!");
                lblMsg.Text = "请刷卡！";
                txtCode.Focus();
                return;
            }
            else
            {
                Refund rf = new Refund(txtCode.Text.Trim());
                rf.ShowDialog();
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Reset();

        }

        public void Reset()
        {
            txtCode.TextChanged -= txtCode_TextChanged;
            txtCode.Text = "";
            txtCode.TextChanged += txtCode_TextChanged;
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
            //if (txtCode.Focused)
            //{
            //    return;
            //}
            //else
            //{
            //    if (e.KeyCode != Keys.F1 && e.KeyCode != Keys.F2 && e.KeyCode != Keys.F3 && e.KeyCode != Keys.F4 && e.KeyCode != Keys.F5)
            //    {
            //        ShowSearchWindow();
            //    }
            //}
        }

        public void ShowSearchWindow()
        {
            if (ks != null && ks.Visible)
            {
                ks.Dispose();
                return;
            }
            ks = new KeySuggest(this);
            Rectangle rect = SystemInformation.VirtualScreen;

            ks.Top = SessionHelper.clientHeight - ks.Height;
            ks.Left = SessionHelper.clientWidth - ks.Width;

            //ks.Deactivate += Ks_LostFocus;

            ks.FormClosing += Ks_FormClosing;

            ks.Show();

        }

        private void Ks_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (requestDic != null && requestDic.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(request_key))
                {
                    //var source = requestDic.Where(p=>p.Key==request_key);

                    Dictionary<string, List<GHRequestVM>> source = new Dictionary<string, List<GHRequestVM>>();
                    source.Add(request_key, requestDic[request_key]);
                    BindUnit(source);
                    //gbxUnits.Text = "选择科室(" + request_key + ")";
                    //uiBreadcrumb2.Items[0]= "选择科室(" + request_key + ")";
                    isBreadHandleSet = true;
                    uiBreadcrumb2.ItemIndex = 0;
                }
            }

        }


        private void GuaHao_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F1:
                    Reset();//重新
                    break;

                case Keys.F2:
                    ShowSearchWindow();//搜索
                    break;
                case Keys.F3:
                    Refund();//退号
                    break;
                case Keys.F4:
                    this.Close();//退出
                    break;
            }
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
            btnEditUser1.TagString = ""; //btnEditUser1.Hide();
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

            //如果点击的是身份证，择查询身份证信息
            if (SessionHelper.CardReader != null|| YBHelper.currentYBInfo != null)
            {
                paramurl = string.Format($"/api/GuaHao/GetPatientBySfzId?sfzid={barcode}");
            }

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);
                if (result.status == 1 && result.data != null && result.data.Count > 0)
                {
                    var userInfo = result.data[0];


                    //如果身份证查询到多条记录
                    //if (SessionHelper.CardReader != null && result.data.Count > 1)
                    if (result.data.Count > 1)
                    {
                        //弹出选择提示
                        SelectPatient selectPatient = new SelectPatient(result.data, this);
                        if (selectPatient.ShowDialog() == DialogResult.OK)
                        {
                            userInfo = result.data.Where(p => p.patient_id == patient_id).FirstOrDefault();
                        }
                        else
                        {
                            return;
                        }
                    }
                    PatientVM = userInfo;
                    if (string.IsNullOrEmpty(userInfo.name))
                    {
                        return;
                    }

                    btnEditUser1.TagString = userInfo.patient_id.ToString(); //btnEditUser1.Show();
                    //this.txtpatientid.Text = userInfo["patient_id"].ToString();
                    lblName.Text = userInfo.name.ToString();
                    if (string.IsNullOrEmpty(userInfo.age) && userInfo.birthday.HasValue)
                    {
                        userInfo.age = (DateTime.Now.Year - userInfo.birthday.Value.Year).ToString();
                    }
                    lblAge.Text = userInfo.age.ToString() + "岁";
                    lblhometel.Text = userInfo.home_tel;
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
                    lblsfz.Text = userInfo.hic_no; ;

                    if (YBHelper.currentYBInfo != null)
                    {
                        //保存用户的医保信息
                        var d = new
                        {
                            yb_psn_no = YBHelper.currentYBInfo.output.baseinfo.psn_no,
                            pid = userInfo.patient_id,
                            social_no = YBHelper.currentYBInfo.output.baseinfo.certno,
                            yb_insuplc_admdvs = YBHelper.currentYBInfo.output.insuinfo[0].insuplc_admdvs,
                            yb_insutype = YBHelper.currentYBInfo.output.insuinfo[0].insutype,
                            opera = SessionHelper.uservm.user_mi
                        };
                        var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        paramurl = string.Format($"/api/GuaHao/UpdateUserYBInfo?pid={d.pid}&social_no={d.social_no}&yb_psn_no={d.yb_psn_no}&yb_insutype={d.yb_insutype}&yb_insuplc_admdvs={d.yb_insuplc_admdvs}");

                        string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                        var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);

                        if (responseJson.status == 1)
                        {
                            log.Debug("修改用户医保信息成功");

                            PatientVM.yb_insuplc_admdvs = d.yb_insuplc_admdvs;
                            PatientVM.yb_insutype = d.yb_insutype;
                            PatientVM.yb_psn_no = d.yb_psn_no;

                            YBHelper.currentYBInfo = null;
                        }
                        else
                        {
                            log.Error(responseJson.message);
                        }

                    }
                }
                else
                {

                    lblMsg.Text = "没有查询到数据";

                    InitUserInfo();

                    //身份证
                    if (SessionHelper.CardReader != null || YBHelper.currentYBInfo != null)
                    {
                        ////自动打开创建新用户窗口
                        //UserInfoEdit ue = new UserInfoEdit("", null);
                        //ue.FormClosed += Ue_FormClosed;
                        //ue.ShowDialog();

                        //自动创建一条用户信息
                        string _hicno = AutoAddUserInfo();
                         
                        this.txtCode.Text = _hicno;
                        SearchUser();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }

        }

        public string AutoAddUserInfo()
        {
            try
            {
                var _pid = "";
                var _hicno = "";
                var _name = "";
                var _sex = "";
                var _birth = "";
                var _home_street = "";

                if (SessionHelper.CardReader != null)
                {
                    _hicno = SessionHelper.CardReader.IDCard;
                    _name = SessionHelper.CardReader.Name;
                    _sex = SessionHelper.CardReader.Sex == "男" ? "1" : "2";
                    _birth = SessionHelper.CardReader.BirthDay;
                    _home_street = SessionHelper.CardReader.Address;

                }
                else if (YBHelper.currentYBInfo != null)
                {
                    _hicno = YBHelper.currentYBInfo.output.baseinfo.certno;
                    _name = YBHelper.currentYBInfo.output.baseinfo.psn_name;
                    _sex = YBHelper.currentYBInfo.output.baseinfo.gend;
                    _birth = YBHelper.currentYBInfo.output.baseinfo.brdy;
                    _home_street = "";
                }

                var paramurl = string.Format($"/api/GuaHao/GetNewPatientId");
                var json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<string>>(json);

                if (result.status == 1)
                {
                    _pid = result.data;
                }
                else
                {
                    log.Error(result.message);
                    return "";
                }
                //var json = HttpClientUtil.Get(paramurl);
                var d = new
                {
                    pid = _pid,
                    hicno = _hicno,
                    sno = _hicno,
                    barcode = _pid,
                    name = _name,
                    sex = _sex,
                    birth = _birth,
                    tel = "",
                    home_district = "",
                    home_street = _home_street,
                    occupation_type = "",
                    response_type = "01",
                    charge_type = "01",
                    opera = SessionHelper.uservm.user_mi
                };
                Task<HttpResponseMessage> task = null;

                paramurl = string.Format($"/api/GuaHao/EditUserInfo?pid={d.pid}&sno={d.sno}&hicno={d.hicno}&barcode={d.barcode}&name={d.name}&sex={d.sex}&birthday={d.birth}&tel={d.tel}&home_district={d.home_district}&home_street={d.home_street}&occupation_type={d.occupation_type}&response_type={d.response_type}&charge_type={d.charge_type}&opera={d.opera}");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);
                var res = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);
                if (res.status == 1)
                {
                }
                else
                {
                    log.Error(res.message);
                    return "";
                }
                return _hicno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }

            return "";
        }

        private void btnMingtian_Click(object sender, EventArgs e)
        {
            btnHoutian.FillColor = Color.FromArgb(110, 190, 40);
            btnMingtian.FillColor = Color.FromArgb(230, 80, 80);
            dtpGhrq.Value = DateTime.Now.AddDays(1);
        }

        private void btnHoutian_Click(object sender, EventArgs e)
        {
            btnMingtian.FillColor = Color.FromArgb(110, 190, 40);
            btnHoutian.FillColor = Color.FromArgb(230, 80, 80);
            dtpGhrq.Value = DateTime.Now.AddDays(2);
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            ShowSearchWindow();//搜索
        }

        private void GuaHao_Initialize(object sender, EventArgs e)
        {
            // this.Focus();
        }


        private void uiBreadcrumb2_ItemIndexChanged(object sender, int value)
        {
            if (uiBreadcrumb2.ItemIndex == 0)
            {
                if (!isBreadHandleSet)
                {
                    clinicList = null;
                    BindUnit(requestDic);
                }
                //if (uiBreadcrumb2.Items[0] != "选择科室")
                //{
                //    uiBreadcrumb2.Items[0] = "选择科室";
                //} 

            }
            else if (uiBreadcrumb2.ItemIndex == 1)
            {
                if (!isBreadHandleSet && clinicList == null)
                {
                    uiBreadcrumb2.ItemIndex = 0;
                }
            }
            isBreadHandleSet = false;
        }


        private void uiGroupBox2_MouseEnter(object sender, EventArgs e)
        {
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            FilterGuahaoData();
        }

        public void FilterGuahaoData()
        {
            var py_code = txtSearch.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(py_code))
            {
                BindUnit(requestDic);
                return;
            }
            if (py_code.Length < 2)
            {
                return;
            }
            var _list = SessionHelper.units.Where(p => p.py_code.StartsWith(py_code)).ToList();
            var _source = new Dictionary<string, List<GHRequestVM>>();
            foreach (var _item in _list)
            {
                if (requestDic.ContainsKey(_item.name))
                {
                    _source.Add(_item.name, requestDic[_item.name]);
                }
            }

            BindUnit(_source); isBreadHandleSet = true;
            uiBreadcrumb2.ItemIndex = 0;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

            }
            else if (e.KeyCode == Keys.Enter)
            {
                FilterGuahaoData();
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            //清空缓存
            SessionHelper.CardReader = null;
            YBHelper.currentYBInfo = null;

            UserInfoEdit ue = new UserInfoEdit("", null);
            ue.FormClosed += Ue_FormClosed;
            ue.ShowDialog();
        }

        private void btnIDCard_Click(object sender, EventArgs e)
        {
            //更改刷卡方式按钮样式
            btnCika.FillColor = lvse;
            btnIDCard.FillColor = hongse;
            btnSFZ.FillColor = lvse;
            btnYBK.FillColor = lvse;

            ReadCika rc = new ReadCika("ID号");
            rc.FormClosed += Rc_FormClosed;
            rc.ShowDialog();
        }
    }
}
