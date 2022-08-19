using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Client.ClassLib;
using Client.Forms.Wedgit;
using Client.ViewModel;
using Sunny.UI;
using Client;
using Client.Forms.Pages.mzgh;

namespace Mzsf.Forms.Pages
{
    public partial class ChargePage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(ChargePage));//typeof放当前类

        Color cur_color = Color.FromArgb(80, 160, 255);
        public static int current_times = 0;
        public static string current_unit_name = "";
        public static string current_doct_name = "";
        public static string current_patient_id = "";

        bool is_order_lock = false;
        int current_tab_index = 0;


        public ChargePage()
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                await Task.Delay(500);

                this.Invoke(new Action(() =>
                {
                    txtCode.Focus();
                }));
            });
        }

        public void SearchUser()
        {
            lblMsg.Text = "";
            txtCode.Focus();

            this.uiTabControl1.Hide();
            this.pblSum.Hide();
            //this.pnlAddOrder.Hide();

            //ClearUserInfo();

            var barcode = this.txtCode.Text.Trim();

            if (string.IsNullOrEmpty(barcode))
            {
                return;
            }

            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetPatientByCard?cardno={barcode}");
            //如果点击的是身份证或医保卡，择查询身份证信息
            if (SessionHelper.CardReader != null || YBHelper.currentYBInfo != null)
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
                if (result.status == 1)
                {
                    if (result.data.Count > 0)
                    {
                        var userInfo = result.data[0];
                        //如果身份证查询到多条记录 
                        if (result.data.Count > 1)
                        {
                            //弹出选择提示
                            SelectPatient selectPatient = new SelectPatient(result.data);
                            if (selectPatient.ShowDialog() == DialogResult.OK)
                            {
                                userInfo = result.data.Where(p => p.patient_id == SessionHelper.sel_patientid).FirstOrDefault();
                            }
                            else
                            {
                                return;
                            }
                        }
                        if (string.IsNullOrEmpty(userInfo.name))
                        {
                            lblNodata.Text = "没有查到用户数据";
                            lblNodata.Show();
                            return;
                        }
                        SessionHelper.patientVM = userInfo;


                        //当前最大记录次数
                        current_times = userInfo.max_times;
                        current_patient_id = userInfo.patient_id;

                        BindUserInfo(userInfo);

                        BindOrders(userInfo.patient_id);

                    }
                    else
                    {
                        MessageBox.Show("没有查到用户数据");
                        lblNodata.Text = "没有查到用户数据";
                        lblNodata.Show();
                    }

                }
                else
                {
                    MessageBox.Show("没有查到用户数据");
                    lblNodata.Text = "没有查到用户数据";
                    lblNodata.Show();
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
        }

        /// <summary>
        /// 查询处方记录
        /// </summary>
        /// <param name="patient_id"></param>
        private void BindOrders(string patient_id)
        {
            //查询近两日就诊处方记录，如果有多条，要今天选择 
            Task<HttpResponseMessage> task = null;
            string json = "";

            string begin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00");
            string end = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

            string paramurl = string.Format($"/api/mzsf/GetMzVisitsByDate?patient_id={patient_id}&begin={begin}&end={end}");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzVisitVM>>>(json);
                if (result.status == 1)
                {
                    if (result.data.Count > 0)
                    {
                        //绑定科室 医生信息
                        txtUnit.Text = result.data[0].unit_name;
                        txtDoct.Text = result.data[0].doct_name;

                        if (result.data.Count > 1)
                        {
                            SelectOrder selectOrder = new SelectOrder(result.data);
                            if (selectOrder.ShowDialog() == DialogResult.OK)
                            {
                                //绑定科室 医生信息
                                txtUnit.Text = current_unit_name;
                                txtDoct.Text = current_doct_name;
                                lblTimes.Text = "来访号：" + current_times;
                            }
                        }

                    }
                    //查询处方
                    GetOrders(patient_id, current_times);
                }
                else
                {
                    MessageBox.Show(result.message);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }

        }

        /// <summary>
        /// 锁定处方，解锁处方
        /// </summary>
        /// <param name="user_mi"></param>
        /// <param name="patient_id"></param>
        /// <param name="times"></param>
        /// <param name="status"></param>
        public void LockOrder(string user_mi, string patient_id, int times, string status)
        {
            // CallCprCharges(string user_mi, string patient_id, int times, string status)

            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/CallCprCharges?user_mi={user_mi}&patient_id={patient_id}&times={times}&status={status}");

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
                }
                else
                {
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
        }

        public void BindUserInfo(PatientVM userInfo)
        {
            txtCode.Text ="";
            txtCode.TagString = userInfo.patient_id;
            txtBarcode.Text = userInfo.p_bar_code;
            lblPatientid.Text = userInfo.patient_id;
            txtName.Text = userInfo.name;
            if (string.IsNullOrEmpty(userInfo.age) && userInfo.birthday.HasValue)
            {
                userInfo.age = (DateTime.Now.Year - userInfo.birthday.Value.Year).ToString();
            }
            else
            {
                userInfo.age = "0";
            }
            txtAge.Text = userInfo.age.ToString() + "岁";
            txtTel.Text = userInfo.home_tel;
            if (userInfo.sex == "1")
            {
                txtSex.Text = "男";
            }
            else if (userInfo.sex == "2")
            {
                txtSex.Text = "女";
            }
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
            lblstreet.Text = userInfo.home_street;
            txtHicno.Text = userInfo.hic_no;

            lblTimes.Text = "来访号：" + userInfo.max_times;
            lblTimes.Tag = userInfo.max_times;

            if (!string.IsNullOrEmpty(userInfo.home_district))
            {
                var model = SessionHelper.districtCodes.Where(p => p.code == userInfo.home_district).FirstOrDefault();

                if (model != null)
                {
                    txtdistrict.Text = model.name;
                }
            }

            if (!string.IsNullOrEmpty(userInfo.response_type))
            {
                var model = SessionHelper.responseTypes.Where(p => p.code == userInfo.response_type).FirstOrDefault();

                if (model != null)
                {
                    cbxResponseType.Text = model.name;
                }
            }
            if (!string.IsNullOrEmpty(userInfo.charge_type))
            {
                var model = SessionHelper.chargeTypes.Where(p => p.code == userInfo.charge_type).FirstOrDefault();

                if (model != null)
                {
                    cbxChargeTypes.Text = model.name;
                }
            }
            lblrelationname.Text = userInfo.relation_name;
            if (!string.IsNullOrEmpty(userInfo.relation_code))
            {
                var model = SessionHelper.relativeCodes.Where(p => p.code == userInfo.relation_code).FirstOrDefault();

                if (model != null)
                {
                    lblrelation.Text = model.name;
                }
            }
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitUI();
                SearchUser();
            }
        }
        /// <summary>
        /// 获取病人处方存储过程
        /// </summary>
        public void GetOrders(string patient_id, int times)
        {
            lblNodata.Text = "没有查询到数据";
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetMzOrdersByPatientId?patient_id={patient_id}&times={times}");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzOrderVM>>>(json);
                if (result.status == 1)
                {
                    if (result.data.Count == 0)
                    {
                        lblNodata.Text = "没有处方数据";
                        lblNodata.Show();
                        return;
                    }

                    #region tabcontrol 重置

                    var pageCount = uiTabControl1.TabPages.Count;

                    for (int i = 0; i < pageCount; i++)
                    {
                        uiTabControl1.TabPages.RemoveAt(uiTabControl1.TabPages.Count - 1);
                    }

                    #endregion

                    //查询处方详情 
                    var charge_status = "1";
                    paramurl = string.Format($"/api/mzsf/GetCprCharges?patient_id={patient_id}&times={times}&charge_status={charge_status}");
                    log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                    task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                    task.Wait();
                    response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var read = response.Content.ReadAsStringAsync();
                        read.Wait();
                        json = read.Result;
                    }
                    var detail_result = WebApiHelper.DeserializeObject<ResponseResult<List<CprChargesVM>>>(json);
                    if (detail_result.status == 1)
                    {
                        SessionHelper.mzOrders = result.data;
                        SessionHelper.cprCharges = detail_result.data;
                        if (result.data.Count > 0)
                        {
                            int pageIndex = 0;
                            foreach (var orderVM in SessionHelper.mzOrders)
                            {
                                OrderItemPage page;
                                if (detail_result.data != null && detail_result.data.Where(p => p.order_no == orderVM.order_no).Count() == 0)
                                {
                                    page = new OrderItemPage(orderVM.order_no, orderVM.order_type, true);
                                }
                                else
                                {
                                    page = new OrderItemPage(orderVM.order_no, orderVM.order_type);
                                }
                                page.TagString = orderVM.order_no.ToString();
                                page.setData = UpdateBottomPrice;

                                uiTabControl1.AddPage(page);
                                uiTabControl1.TabPages[pageIndex].Text = orderVM.title;
                                //uiTabControl1.TabPages[pageIndex].showclo
                                pageIndex++;
                            }
                            uiTabControl1.Show();
                            BindBottomChargeInfo(0);
                            pblSum.Show();
                            uiTabControl1.ShowActiveCloseButton = true;


                            return;

                            //int pageIndex = 0;
                            //for (int i = 0; i < result.data.Count; i++)
                            //{
                            //    if (detail_result.data.Where(p => p.order_no == result.data[i].order_no).Count() > 0)
                            //    {
                            //        var page = new OrderItemPage(result.data[i].order_no, result.data[i].order_type);
                            //        page.TagString = result.data[i].order_no.ToString();
                            //        page.setData = UpdateBottomPrice;

                            //        uiTabControl1.AddPage(page);
                            //        //uiTabControl1.AddPage(new OrderItemPage(result.data[i].order_no, result.data[i].order_type));
                            //        uiTabControl1.TabPages[pageIndex].Text = result.data[i].title;
                            //        pageIndex++;
                            //    }
                            //}
                            //uiTabControl1.Show();
                            //BindBottomChargeInfo(0);
                            //pblSum.Show(); //this.pnlAddOrder.Show();
                            //uiTabControl1.ShowCloseButton = true;

                            ////锁定处方
                            //LockOrder(SessionHelper.uservm.user_mi, patient_id, times, "2");
                            //is_order_lock = true;
                        }
                        else
                        {
                            lblNodata.Text = "已收费处方";

                            lblNodata.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show(detail_result.message);
                        log.Error(result.message);
                        return;
                    }


                }
                else
                {
                    MessageBox.Show(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void ChargePage_Load(object sender, EventArgs e)
        {

            InitUI();

            //cbxResponseType.DataSource = SessionHelper.responseTypes;
            //cbxResponseType.ValueMember = "code";
            //cbxResponseType.DisplayMember = "name";

            //cbxChargeTypes.DataSource = SessionHelper.chargeTypes;
            //cbxChargeTypes.ValueMember = "code";
            //cbxChargeTypes.DisplayMember = "name";

            BindOrderTypes();
        }

        public void BindOrderTypes()
        {
            //查询 处方类型列表
            Task<HttpResponseMessage> task;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetOrderTypes");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<OrderTypeVM>>>(json);
                if (result.status == 1)
                {
                    var orderTypes = result.data;
                    orderTypes = orderTypes.Where(p => p.name.Contains("诊疗")).ToList();
                    cbxOrderType.DataSource = orderTypes;
                    cbxOrderType.ValueMember = "code";
                    cbxOrderType.DisplayMember = "name";

                    cbxOrderType.SelectedValue = "01";
                }
                else
                {
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
        }

        private void InitUI()
        {
            this.uiTabControl1.Hide();
            this.pblSum.Hide();
            //this.pnlAddOrder.Hide();
            lblNodata.Parent = this;
            lblNodata.Top = 400;
            lblNodata.Left = 300;


            lblNodata.Hide();
            //txtCode.Text = "";
            ClearUserInfo();

        }
        public void ClearUserInfo()
        {
            txtName.Text = "";
            txtHicno.Text = "";
            txtAge.Text = "";
            txtSex.Text = "";
            txtTel.Text = "";
            lblTimes.Text = "来访号：";
            txtdistrict.Text = "";
            cbxResponseType.Text = "";
            cbxChargeTypes.Text = "";
            txtUnit.Text = "";
            txtDoct.Text = "";

            current_patient_id = "";

            SessionHelper.patientVM = null;
            SessionHelper.mzOrders = null;
            SessionHelper.cprCharges = null;
            ClearTab();
        }

        public void ClearTab()
        {
            #region tabcontrol 重置

            var pageCount = uiTabControl1.TabPages.Count;

            for (int i = 0; i < pageCount; i++)
            {
                uiTabControl1.TabPages.RemoveAt(uiTabControl1.TabPages.Count - 1);
            }

            #endregion

        }

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
        }



        Color lvse = Color.FromArgb(110, 190, 40);
        Color hongse = Color.FromArgb(230, 80, 80);

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
        private void btnSFZ_Click(object sender, EventArgs e)
        {
            btnCika.FillColor = lvse;
            btnIDCard.FillColor = lvse;
            btnSFZ.FillColor = hongse;
            btnYBK.FillColor = lvse;


            ReadCard rc = new ReadCard("身份证");
            //关闭，刷新
            rc.FormClosed += Rc_FormClosed; ;
            rc.ShowDialog();
        }

        private void Rc_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SessionHelper.cardno))
            {
                ClearUserInfo();
                txtCode.Text = SessionHelper.cardno;
                SearchUser();
            }
        }

        private void btnYBK_Click(object sender, EventArgs e)
        {
            YBHelper.currentYBInfo = null;

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
                }
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

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtCode.Focus();

            InitUI();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiTabControl1.SelectedIndex != -1)
            {
                BindBottomChargeInfo(uiTabControl1.SelectedIndex);
            }

            //var page = uiTabControl1.TabPages[uiTabControl1.SelectedIndex] as OrderItemPage;
            //var page = uiTabControl1.page(uiTabControl1.SelectedIndex).TabPage as OrderItemPage;

        }
        public void UpdateBottomPrice()
        {
            BindBottomChargeInfo(uiTabControl1.SelectedIndex);
        }


        public void BindBottomChargeInfo(int tabindex)
        {
            //            var order_list = SessionHelper.cprCharges.GroupBy(p => new { p.order_no })
            //.Select(g => g.First()).Select(p => p.order_no)
            //.ToList();

            //            if (tabindex >= order_list.Count)
            //            {
            //                return;
            //            }
            //            var order_no = order_list[tabindex];
            try
            {
                //var _order = SessionHelper.mzOrders.Where(p => p.order_no == tabindex + 1).FirstOrDefault();
                var _order = SessionHelper.mzOrders.OrderBy(p=>p.order_no).ToList()[tabindex];
                if (_order != null)
                {

                    var order = SessionHelper.cprCharges.Where(p => p.order_no == _order.order_no);

                    lblOrderCharge.Text = Math.Round(order.Sum(p => p.total_price), 2).ToString();
                    lblOrderItemCount.Text = order.Count().ToString();
                    lblOrderTotalCharge.Text = Math.Round(SessionHelper.cprCharges.Sum(p => p.total_price), 2).ToString();
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void btnHuajia_Click(object sender, EventArgs e)
        {
            SaveOrder();
            Huajia();

        }

        public void Huajia()
        {
            if (SessionHelper.patientVM != null && SessionHelper.cprCharges != null)
            {
                Check check = new Check();
                check.times = current_times;
                //check.FormClosed += Check_FormClosed;
                var dresult = check.ShowDialog();
                if (dresult == DialogResult.OK)
                {
                    //打印发票
                    if (SessionHelper.do_sf_print)
                    {

                        Task.Run(() =>
                        {
                            try
                            {

                                SessionHelper.do_sf_print = false;
                                //打印发票 
                                Print ghprint = new Print(SessionHelper.mzsf_report_code);
                                ghprint.Show();

                            }
                            catch (Exception ex)
                            {
                                log.Error(ex.Message);
                                log.Error(ex.StackTrace);

                            }
                        });

                    }
                    //查询处方
                    ReloadPageData();
                }
            }
        }

        private void Check_FormClosed(object sender, FormClosedEventArgs e)
        {

            //查询处方
            SearchUser();
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 增加处方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (current_patient_id == "")
            {
                UIMessageTip.ShowWarning("患者请刷卡！");
                txtCode.Focus();
                return;
            }

            if (SessionHelper.cprCharges == null)
            {
                SessionHelper.cprCharges = new List<CprChargesVM>();
            }
            if (SessionHelper.mzOrders == null)
            {
                SessionHelper.mzOrders = new List<MzOrderVM>();
            }
            int max_order_no = 0;

            //if (SessionHelper.cprCharges.Count > 0)
            if (SessionHelper.mzOrders != null && SessionHelper.mzOrders.Count > 0)
            {
                //max_order_no = SessionHelper.cprCharges.Max(p => p.order_no);
                max_order_no = SessionHelper.mzOrders.Max(p => p.order_no);



            }
            //else
            //{
            //    if (UIMessageDialog.ShowAskDialog(this, "当前患者没有医生处方，是否确认添加？"))
            //    { 
            //        CreateVisitRecord();

            //        this.uiTabControl1.Show();
            //        this.pblSum.Show();
            //    }
            //    else
            //    {
            //        return;
            //    } 
            //}
            this.uiTabControl1.Show();
            this.pblSum.Show();
             
            var _order = new MzOrderVM();
            _order.order_no = max_order_no + 1;
            _order.order_type = cbxOrderType.SelectedValue.ToString();
            SessionHelper.mzOrders.Add(_order);

            var page = new OrderItemPage(max_order_no + 1, cbxOrderType.SelectedValue.ToString());
            page.TagString = (max_order_no + 1).ToString();
            page.setData = UpdateBottomPrice;
            uiTabControl1.AddPage(page);
            uiTabControl1.TabPages[uiTabControl1.TabCount - 1].Text = "处方" + (max_order_no + 1) + "：" + cbxOrderType.Text;
            uiTabControl1.SelectedIndex = uiTabControl1.TabCount - 1;
            uiTabControl1.ShowCloseButton = true;

        }

        public bool CreateVisitRecord()
        {
            var d = new
            {
                haoming_code = SessionHelper.patientVM.haoming_code,
                patient_id = SessionHelper.patientVM.patient_id,
                times = SessionHelper.patientVM.times,
                expertflag = 1,
                unit_sn = SessionHelper.uservm.dept_sn,
                doctor_sn = SessionHelper.uservm.user_mi
            };

            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/CreateVisitRecord?haoming_code={d.haoming_code}&patient_id={d.patient_id}&times={d.times}&expertflag={d.expertflag}&unit_sn={d.unit_sn}&doctor_sn={d.doctor_sn}");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzVisitVM>>>(json);
                if (result.status == 1)
                {
                    var mzvisit = result.data[0];
                    GetOrders(mzvisit.patient_id, mzvisit.times);
                }
                else
                {
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
            return true;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveOrder();
            //MessageBox.Show(order_string);
        }

        public void SaveOrder()
        {

            if (SessionHelper.cprCharges == null)
            {
                return;
            }

            //搜集数据
            var add_list = SessionHelper.cprCharges.Where(p => p.times == 0);

            //var order_list = add_list.Distinct<string>(p => p.order_type).ToList();

            var order_list = add_list.GroupBy(p => new { p.order_no })
   .Select(g => g.First())
   .ToList();

            var order_string = "";//order_type-charge_code-charge_amount,order_type-charge_code-charge_amount;order_type-charge_code-charge_amount;
            foreach (var order in order_list)
            {
                var item_list = add_list.Where(p => p.order_no == order.order_no);

                var item_str = "";
                foreach (var item in item_list)
                {
                    item_str += "," + item.order_type + "-" + item.order_no + "-" + item.charge_code + "-" + item.serial_no + "-" + item.charge_amount;
                }
                if (item_str != "")
                {
                    item_str = item_str.Substring(1);
                    order_string += ";" + item_str;
                }
            }
            if (order_string != "")
            {
                order_string = order_string.Substring(1);
            }

            if (order_string == "")
            {
                //MessageBox.Show("没有新添加的处方，无需保存！");
                return;
            }

            var d = new
            {
                patient_id = current_patient_id,
                times = current_times,
                order_string = order_string,
                opera = SessionHelper.uservm.user_mi
            };

            //保存收费员处方
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/SaveOrder?patient_id={d.patient_id}&times={d.times}&order_string={d.order_string}&opera={d.opera}");

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
                    //UIMessageTip.Show("保存成功");
                    GetOrders(current_patient_id, current_times);
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
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }

        }

        private bool uiTabControl1_BeforeRemoveTabPage(object sender, int index)
        {
            var _order = SessionHelper.mzOrders.Where(p => p.order_no == index + 1).FirstOrDefault();
            if (_order != null)
            {
                if (!string.IsNullOrEmpty(_order.group_no) && SessionHelper.cprCharges != null && SessionHelper.cprCharges.Where(p => p.order_no == _order.order_no).Count() == 0)
                {
                    UIMessageTip.ShowError("医生处方不能删除！");
                    return false;
                }
                else
                {
                    var _order_no = _order.order_no;
                    SessionHelper.mzOrders.Remove(_order);
                    foreach (var item in SessionHelper.cprCharges.ToArray())
                    {
                        if (item.order_no == _order_no)
                        {
                            SessionHelper.cprCharges.Remove(item);
                        }
                    }
                }
            }


            // var order_list = SessionHelper.cprCharges.GroupBy(p => new { p.order_no })
            //.Select(g => g.First()).Select(p => p.order_no)
            //.ToList();
            //            if (index >= order_list.Count)
            //            {
            //                var order_no = order_list[index];

            //                foreach (var item in SessionHelper.cprCharges.ToArray())
            //                {
            //                    if (item.order_no == order_no)
            //                    {
            //                        SessionHelper.cprCharges.Remove(item);
            //                    }
            //                }
            //            }

            //            if (index >= order_list.Count)
            //            {
            //                var order_no = order_list[index];

            //                foreach (var item in SessionHelper.mzOrders.ToArray())
            //                {
            //                    if (item.order_no == order_no)
            //                    {
            //                        SessionHelper.mzOrders.Remove(item);
            //                    }
            //                }

            //            }

            return true;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (current_patient_id == "")
            {
                return;
            }

            if (SessionHelper.cprCharges == null)
            {
                return;
            }
            try
            {

                var pages = uiTabControl1.GetPages<OrderItemPage>();

                var aa = pages[uiTabControl1.SelectedIndex].Controls.Find("dgvOrderDetail", true);

                var dgv = aa[0] as UIDataGridView;

                //dgv.DataSource = null;

                int new_index = dgv.Rows.Add();

                dgv.SelectedIndex = new_index;

            }
            catch (Exception ex)
            {
                UIMessageTip.Show("现有处方不允许修改");
                log.Error(ex.ToString());
            }

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (current_patient_id == "")
            {
                return;
            }

            if (SessionHelper.cprCharges == null)
            {
                return;
            }
            try
            {
                var pages = uiTabControl1.GetPages<OrderItemPage>();

                var aa = pages[uiTabControl1.SelectedIndex].Controls.Find("dgvOrderDetail", true);

                var dgv = aa[0] as UIDataGridView;
                if (dgv.SelectedRows.Count > 0)
                {
                    dgv.Rows.Remove(dgv.SelectedRows[0]);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show("现有处方不允许修改");

                log.Error(ex.ToString());

            }

        }

        private void ChargePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (is_order_lock)
            {
                //解除锁定处方
                LockOrder(SessionHelper.uservm.user_mi, current_patient_id, current_times, "1");
                is_order_lock = false;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            SessionHelper.sf_print_user_ledger = 352;
            //打印发票 
            Print ghprint = new Print(SessionHelper.mzsf_report_code);
            ghprint.Show();
        }

        private void btnEditRelation_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblPatientid.Text))
            {
                RelationInfoEdit relationInfoEdit = new RelationInfoEdit(lblPatientid.Text, "", lblrelationname.Text);
                if (relationInfoEdit.ShowDialog() == DialogResult.OK)
                {
                    BindBaseInfo(lblPatientid.Text);
                }
            }

        }

        public void BindBaseInfo(string patient_id)
        {//获取数据   
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/guahao/GetPatientByPatientId?pid={patient_id}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);
                if (result.status == 1)
                {
                    var _patient = result.data.FirstOrDefault();
                    if (_patient != null)
                    {
                        BindUserInfo(_patient);
                    }
                }
                else
                {
                    //MessageBox.Show("没有查到用户数据");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }

        }

        public void ReloadPageData()
        {
            BindOrders(lblPatientid.Text);
        }
             
    }
}
