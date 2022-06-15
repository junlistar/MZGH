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
using Mzsf.ClassLib;
using Mzsf.Forms.Wedgit;
using Mzsf.ViewModel;
using Sunny.UI;

namespace Mzsf.Forms.Pages
{
    public partial class ChargePage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(ChargePage));//typeof放当前类

        Color cur_color = Color.FromArgb(80, 160, 255);
        public static int current_times = 0;
        public static string current_unit_name = "";
        public static string current_doct_name = "";


        public ChargePage()
        {
            InitializeComponent();
        }

        public void SearchUser()
        {
            lblMsg.Text = "";
            txtCode.Focus();
            InitUI();

            var barcode = this.txtCode.Text.Trim();

            if (string.IsNullOrEmpty(barcode))
            {
                return;
            }

            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetPatientByCard?cardno={barcode}");

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
                        if (string.IsNullOrEmpty(userInfo.name))
                        {
                            lblMsg.Text = "没有查询到数据";
                            return;
                        }
                        SessionHelper.PatientVM = userInfo;


                        //当前最大记录次数
                        current_times = userInfo.max_times;

                        BindUserInfo(userInfo);

                        BindOrders(userInfo.patient_id);

                    }
                    else
                    {
                        lblMsg.Text = "没有查询到数据";
                    }

                }
                else
                {
                    lblMsg.Text = "没有查询到数据";
                    log.Error(result.message);
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
                            selectOrder.ShowDialog();

                            //绑定科室 医生信息
                            txtUnit.Text = current_unit_name;
                            txtDoct.Text = current_doct_name;
                            lblTimes.Text = "来访号：" + current_times;
                        }
                         
                        //查询处方
                        GetOrders(patient_id, current_times);

                        //锁定处方
                        //LockOrder();
                    }
                    else
                    {
                        lblMsg.Text = "没有查询到数据";
                    }

                }
                else
                {
                    lblMsg.Text = "没有查询到数据";
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

            txtCode.TagString = userInfo.patient_id;
            txtName.Text = userInfo.name.ToString();
            txtAge.Text = userInfo.age.ToString() + "岁";
            txtTel.Text = userInfo.home_tel.ToString();
            if (userInfo.sex == "1")
            {
                txtSex.Text = "男";
            }
            else if (userInfo.sex == "2")
            {
                txtSex.Text = "女";
            }
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
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                    var pageCount = uiTabControl1.TabPages.Count;

                    for (int i = 0; i < pageCount; i++)
                    {
                        uiTabControl1.TabPages.RemoveAt(uiTabControl1.TabPages.Count - 1);
                    }
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
                        if (detail_result.data.Count > 0)
                        {
                            for (int i = 0; i < result.data.Count; i++)
                            {
                                uiTabControl1.AddPage(new OrderItemPage(result.data[i].order_no, result.data[i].order_type));
                                uiTabControl1.TabPages[i].Text = result.data[i].title;
                            }
                            uiTabControl1.Show();
                            BindBottomChargeInfo(0);
                            pblSum.Show();
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
                log.Error(ex.Message);
            }
        }

        private void ChargePage_Load(object sender, EventArgs e)
        {

            InitUI();

            cbxResponseType.DataSource = SessionHelper.responseTypes;
            cbxResponseType.ValueMember = "code";
            cbxResponseType.DisplayMember = "name";

            cbxChargeTypes.DataSource = SessionHelper.chargeTypes;
            cbxChargeTypes.ValueMember = "code";
            cbxChargeTypes.DisplayMember = "name";
        }

        private void InitUI()
        {
            this.uiTabControl1.Hide();
            this.pblSum.Hide();
            lblNodata.Parent = this;
            lblNodata.Top = 350;
            lblNodata.Left = 300;

            lblNodata.Hide();
            //txtCode.Text = "";
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


            SessionHelper.PatientVM = null;
            SessionHelper.mzOrders = null;
            SessionHelper.cprCharges = null;
        }

        private void btnCika_Click(object sender, EventArgs e)
        {

            //更改刷卡方式按钮样式
            btnCika.FillColor = cur_color;
            btnSFZ.FillColor = Color.LightSteelBlue;
            btnYBK.FillColor = Color.LightSteelBlue;
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                txtCode.Focus();
                return;
            }
            SearchUser();
        }

        private void btnSFZ_Click(object sender, EventArgs e)
        {
            btnSFZ.FillColor = cur_color;
            btnCika.FillColor = Color.LightSteelBlue;
            btnYBK.FillColor = Color.LightSteelBlue;

            ReadCard rc = new ReadCard("身份证");
            //关闭，刷新
            rc.FormClosed += Rc_FormClosed; ;
            rc.ShowDialog();
        }

        private void Rc_FormClosed(object sender, FormClosedEventArgs e)
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

            btnSFZ.FillColor = Color.LightSteelBlue;
            btnYBK.FillColor = cur_color;
            btnCika.FillColor = Color.LightSteelBlue;

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
            if (SessionHelper.PatientVM != null)
            {
                //todo 解除锁定处方

            }
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBottomChargeInfo(uiTabControl1.SelectedIndex);
        }

        public void BindBottomChargeInfo(int tabindex)
        {
            var order = SessionHelper.cprCharges.Where(p => p.order_no == tabindex + 1);

            lblOrderCharge.Text = Math.Round(order.Sum(p => p.charge_price), 2).ToString();
            lblOrderItemCount.Text = order.Count().ToString();
            lblOrderTotalCharge.Text = Math.Round(SessionHelper.cprCharges.Sum(p => p.charge_price), 2).ToString();
        }

        private void btnHuajia_Click(object sender, EventArgs e)
        {
            if (SessionHelper.PatientVM != null && lblNodata.Visible == false)
            {
                Check check = new Check();
                check.Show();
            }

        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
