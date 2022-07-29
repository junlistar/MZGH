using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.Forms.Pages.mzgh;
using Client.Forms.Wedgit;
using Client.ViewModel;
using log4net;
using Sunny.UI;


namespace Client.Forms.Pages
{
    public partial class UserInfoPage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(UserInfoPage));//typeof放当前类

        List<MzPatientSfzVM> sfz_list;



        public UserInfoPage()
        {
            InitializeComponent();
        }

        private void UserInfoPage_Initialize(object sender, EventArgs e)
        {

        }

        private void UserInfoPage_Load(object sender, EventArgs e)
        {
            //加载数据字典
            InitDic();

            //this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            //this.txtZhiye.TextChanged += txtZhiye_TextChanged;

            lblmsg.ForeColor = Color.Red;

            sfz_birthday.Text = "";
            txt_birth.Text = "";
        }

        UIDataGridView dgv_district = new UIDataGridView();
        UIDataGridView dgv_zhiye = new UIDataGridView();
        UIDataGridView dgv_shenfen = new UIDataGridView();
          

        public void InitDic()
        {

            log.Info("初始化数据字典：InitDic");
             

            //获取用户  
            var json = "";
            var paramurl = string.Format($"/api/GuaHao/GetRelativeCodes");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            var task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            SessionHelper.relativeCodes = WebApiHelper.DeserializeObject<ResponseResult<List<RelativeCodeVM>>>(json).data;


            this.cbx_relation.DataSource = SessionHelper.relativeCodes;
            cbx_relation.DisplayMember = "name";
            cbx_relation.ValueMember = "code";
            cbx_relation.Text = "本人";
        }


        private void cbxhm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                //获取数据
                var _pid = txt_patientId.Text;
                var _name = txt_name.Text;
                var _tel = txtTel.Text;

                var sex = "1";
                switch (cbxsex.Text)
                {
                    case "男": sex = "1";break;
                    case "女": sex = "2";break;
                    default:
                        break;
                }
                var _sex = sex;

                var marrycode = 1;
                switch (this.cbxmarrycode.Text)
                {
                    case "已婚":
                        marrycode = 1; break;
                    case "未婚":
                        marrycode = 2; break;
                    case "丧偶":
                        marrycode = 3; break;
                    case "离婚":
                        marrycode = 4; break;
                    case "其他":
                        marrycode = 5; break;
                    default:
                        break;
                }
                var _marry_code = marrycode;
                var _birth = txt_birth.Value;
                var _relation_name = txtrelationname.Text;
                var _relation_code = cbx_relation.SelectedValue;
                var _home_address = sfz_home_address.Text;
                var _opera = SessionHelper.uservm.user_mi;

                var paramurl = string.Format($"/api/User/UpdateUserBaseInfo?pid={_pid}&name={_name}&sex={_sex}&marry_code={_marry_code}&birthday={_birth}&tel={_tel}&relation_name={_relation_name}&relation_code={_relation_code}&home_street={_home_address}&opera={_opera}");
                var json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                if (result.status == 1)
                {
                    UIMessageTip.Show("保存成功！");
                    GetPatientRelatedSfzInfo(txt_sfz_no.Text);
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

     
        public void DeleteSocialNo(string sno)
        {
            var paramurl = string.Format($"/api/GuaHao/DeleteSocialNo?sno={sno}");
            HttpClientUtil.Get(paramurl);
        }




        public void BindUserInfo(PatientVM item)
        {
            // this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
            // this.txtZhiye.TextChanged -= txtZhiye_TextChanged;

            //txtId.Text = item.patient_id.Substring(3, 7);

            txtCode.Text = item.p_bar_code;

            txt_patientId.Text = item.patient_id;

            txtTel.Text = item.home_tel;

            txt_sfz_no.Text = item.hic_no;
            //ybk_psn_no.Text = item.social_no;

            txt_name.Text = item.name;

            if (item.birthday.HasValue)
            {
                this.txt_birth.Text = item.birthday.Value.ToShortDateString();
            }
            if (!string.IsNullOrEmpty(item.relation_code))
            {
                cbx_relation.SelectedValue = item.relation_code;
                //var relativeCodeVM = SessionHelper.relativeCodes.Where(p => p.code == item.relation_code).FirstOrDefault();
                // if (relativeCodeVM!=null)
                // {
                //     cbx_relation.SelectedValue = relativeCodeVM.code;
                // }
            }
            else
            {
                cbx_relation.Text = "本人";
            }

            this.txtTel.Text = item.home_tel;

            //if (!string.IsNullOrWhiteSpace(item.home_district))
            //{
            //    this.txthomedistrict.TagString = item.home_district;

            //    var model = SessionHelper.districtCodes.Where(p => p.code == item.home_district).FirstOrDefault();

            //    if (model != null)
            //    {
            //        this.txthomedistrict.Text = model.name;
            //    }

            //}

            //地区
            this.sfz_home_address.Text = item.home_street;

            ////职业
            //if (!string.IsNullOrWhiteSpace(item.occupation_type))
            //{
            //    this.txtZhiye.TagString = item.occupation_type;

            //    var model = SessionHelper.occupationCodes.Where(p => p.code == item.occupation_type).FirstOrDefault();

            //    if (model != null)
            //    {
            //        this.txtZhiye.Text = model.name;
            //    }
            //}

            //身份
            //this.cbxShenfen.SelectedValue = item.response_type;

            ////费别
            //this.cbxFeibie.SelectedValue = item.charge_type;

            this.cbxsex.Text = item.sex == "1" ? "男" : "女";

            //婚姻
            var marrycode = "";
            switch (item.marry_code)
            {
                case "1":
                    marrycode = "已婚"; break;
                case "2":
                    marrycode = "未婚"; break;
                case "3":
                    marrycode = "丧偶"; break;
                case "4":
                    marrycode = "离婚"; break;
                case "5":
                    marrycode = "其他"; break;
                default:
                    break;
            }
            this.cbxmarrycode.Text = marrycode;

            //家长姓名
            //relation_name
            txtrelationname.Text = item.relation_name;

            //社保号码
            //addition_no1
            //ybk_psn_cert_type.Text = item.addition_no1;

            //工作单位
            //employer_name
            //txtemployer_name.Text = item.employer_name;

            //合同单位contract_code


            // this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            //  this.txtZhiye.TextChanged += txtZhiye_TextChanged;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
            // this.txtZhiye.TextChanged -= txtZhiye_TextChanged;

            //cbxhm.Text = "";
            //txtId.Text = "";
            //txtbarcode.Text = "";
            //txtname.Text = "";
            //cbxShenfen.SelectedValue = "";
            //cbxFeibie.SelectedValue = "";
            cbxsex.Text = "";
            sfz_birthday.Text = "";
            txtrelationname.Text = "";
            txtTel.Text = "";
            sfz_card_no.Text = "";
            ybk_psn_no.Text = "";
            cbxmarrycode.Text = "";
            //txtemployer_name.Text = "";
            // txtZhiye.Text = "";
            ybk_psn_cert_type.Text = "";
            // txthomedistrict.Text = "";
            sfz_home_address.Text = "";

            //this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            //this.txtZhiye.TextChanged += txtZhiye_TextChanged;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCika_Click(object sender, EventArgs e)
        {

            //清空缓存
            SessionHelper.CardReader = null;
            YBHelper.currentYBInfo = null;

            //更改刷卡方式按钮样式
            btnCika.FillColor = hongse;
            btnIDCard.FillColor = lvse;
            btnSFZ.FillColor = lvse;
            btnYBK.FillColor = lvse;

            ReadCika rc = new ReadCika("磁卡");
            rc.FormClosed += Rc_FormClosed1;
            rc.ShowDialog();
        }

        private void Rc_FormClosed1(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SessionHelper.cardno))
            {
                txtCode.Text = SessionHelper.cardno;
                SearchUser();
            }
        }

        Color lvse = Color.FromArgb(110, 190, 40);
        Color hongse = Color.FromArgb(230, 80, 80);

        private void btnIDCard_Click(object sender, EventArgs e)
        {
            //清空缓存
            SessionHelper.CardReader = null;
            YBHelper.currentYBInfo = null;

            //更改刷卡方式按钮样式
            btnCika.FillColor = lvse;
            btnIDCard.FillColor = hongse;
            btnSFZ.FillColor = lvse;
            btnYBK.FillColor = lvse;

            ReadCika rc = new ReadCika("ID号");
            rc.FormClosed += Rc_FormClosed1;
            rc.ShowDialog();
        }
        private void btnSFZ_Click(object sender, EventArgs e)
        {

            //清空缓存
            SessionHelper.CardReader = null;
            YBHelper.currentYBInfo = null;

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
                txtCode.Text = SessionHelper.cardno;
                SearchUser();
            }
        }
        public void ClearUserInfo()
        {
            //txtAge.Text = "";
            //txtSex.Text = "";
            //txtTel.Text = ""; 
            //txtdistrict.Text = "";
            //cbxResponseType.Text = "";
            //cbxChargeTypes.Text = ""; 

        }
        public void SearchUser()
        {
            lblmsg.Text = "";
            txtCode.Focus();


            ClearUserInfo();

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
                if (result.status == 1 && result.data != null && result.data.Count > 0)
                {
                        var userInfo = result.data[0];
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

                    //BindUserInfo(userInfo);
                    //查询patient_id关联的身份证信息
                    GetPatientRelatedSfzInfo(userInfo.hic_no);
                   
                }
                else
                {
                    //身份证
                    if (SessionHelper.CardReader != null || YBHelper.currentYBInfo != null)
                    { 

                        //自动创建一条用户信息
                        string _hicno = AutoAddUserInfo();

                        this.txtCode.Text = _hicno;
                        SearchUser();
                    }
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

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

        public void GetPatientRelatedSfzInfo(string sfz_id)
        {
            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/user/GetDataBySfzId?sfz_id={sfz_id}");

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

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzPatientSfzVM>>>(json);
                if (result.status == 1)
                {
                    sfz_list = result.data;
                    var _source = result.data.Select(p => new
                    {
                        patient_id = p.patient_id,
                        sfz_id = p.sfz_id,
                        relative_code = p.relative_str
                    }).ToList();
                    dgv_patient_sfz.Init();
                    dgv_patient_sfz.DataSource = _source;
                    dgv_patient_sfz.CellBorderStyle = DataGridViewCellBorderStyle.Single;

                    if (_source.Count > 0)
                    {
                        BindRelatedInfo(0);
                    }


                }
                else
                {
                    //MessageBox.Show("没有查到用户数据");
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

            }
        }


        private void btnYBK_Click(object sender, EventArgs e)
        {
            //清空缓存
            SessionHelper.CardReader = null;
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void dgv_patient_sfz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    BindRelatedInfo(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error(ex.StackTrace);

            }
        }

        public void BindRelatedInfo(int row_index)
        {
            try
            {

                if (row_index == -1)
                {
                    return;
                }

                var sfz_id = dgv_patient_sfz.Rows[row_index].Cells["sfz_id"].Value.ToString();
                var patient_id = dgv_patient_sfz.Rows[row_index].Cells["patient_id"].Value.ToString();

                //查询数据库身份证信息
                BindSfzInfo(patient_id);

                //绑定基础信息数据
                BindBaseInfo(patient_id);

                //查询patient_id 关联挂号记录
                GetRecordByPatientId(patient_id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
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


        public void BindSfzInfo(string patient_id)
        {
            var sfz_info = sfz_list.Where(p => p.patient_id == patient_id).FirstOrDefault();
            if (sfz_info != null)
            {
                sfz_card_no.Text = sfz_info.card_no;
                sfz_name.Text = sfz_info.name;
                sfz_sex.Text = sfz_info.sex;
                DateTime _dt = DateTime.MinValue;
                if (DateTime.TryParse(sfz_info.birthday, out _dt))
                {
                    sfz_birthday.Text = _dt.ToShortDateString();
                }
                sfz_folk.Text = sfz_info.folk;
                sfz_address.Text = sfz_info.address;
                sfz_home_address.Text = sfz_info.home_address;

                ybk_psn_no.Text = sfz_info.psn_no;
                ybk_psn_cert_type.Text = sfz_info.psn_cert_type_str;
                ybk_psn_name.Text = sfz_info.psn_name;
                ybk_certno.Text = sfz_info.certno;


                //查询医保卡其他信息
                var cert_no = sfz_info.certno;

                //
                GetYbkDetailInfo(cert_no);
            }
        }

        public void GetYbkDetailInfo(string certno)
        {
            //获取数据   
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/user/GetYbkDetailInfo?certno={certno}");

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


                var result = WebApiHelper.DeserializeObject<ResponseResult<UserInfoResponseModel>>(json);
                if (result.status == 1)
                {
                    if (result.data != null && result.data.insuinfo != null)
                    {
                        dgv_cbxx.DataSource = result.data.insuinfo;
                        dgv_cbxx.AutoResizeColumns();
                        dgv_cbxx.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    }
                    if (result.data != null && result.data.idetinfo != null)
                    {
                        dgv_sfxx.DataSource = result.data.idetinfo;
                        dgv_sfxx.AutoResizeColumns();
                        dgv_sfxx.CellBorderStyle = DataGridViewCellBorderStyle.Single;
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


        public void GetRecordByPatientId(string patient_id)
        {
            //获取数据  
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/guahao/GetRecordByPatientId?patient_id={patient_id}");

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


                var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhSearchVM>>>(json);
                if (result.status == 1)
                {
                    var ghlist = result.data;
                    var _source = result.data.Select(p => new
                    {
                        gh_date = p.gh_date,
                        unit_name = p.unit_name,
                        doctor_name = p.doctor_name,
                        ampm = p.ampm,
                        visit_status = p.visit_status
                    }).ToList();
                    //dgv_ghlist.Init();
                    dgv_ghlist.DataSource = _source;
                    dgv_ghlist.AutoResizeColumns();
                    dgv_ghlist.CellBorderStyle = DataGridViewCellBorderStyle.Single;


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

        private void dgv_ghlist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow dr = (sender as UIDataGridView).Rows[e.RowIndex];

            if (dr.Cells["visit_status"].Value != null && dr.Cells["visit_status"].Value.ToString() == "退号")
            {
                // 设置单元格的背景色
                //dr.DefaultCellStyle.BackColor = Color.Yellow;
                // 设置单元格的前景色
                dr.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                //dr.DefaultCellStyle.ForeColor = Color.Green;

            }
        }

        private void lklduka_Click(object sender, EventArgs e)
        {
            ReadCard rc = new ReadCard("身份证");
            //关闭，刷新
            rc.FormClosed += ReadSfz_FormClosed; ;
            rc.ShowDialog();
        }

        private void ReadSfz_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SessionHelper.CardReader != null)
            {
                this.sfz_card_no.Text = SessionHelper.CardReader.IDCard;
                this.sfz_name.Text = SessionHelper.CardReader.Name;
                this.sfz_address.Text = SessionHelper.CardReader.Address;
                this.sfz_birthday.Text = SessionHelper.CardReader.BirthDay;
                this.sfz_folk.Text = SessionHelper.CardReader.Folk;
                this.sfz_sex.Text = SessionHelper.CardReader.Sex;


            }
        }

        private void uiGroupBox5_Click(object sender, EventArgs e)
        {

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
        private void Ue_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SessionHelper.cardno))
            {
                txtCode.Text = SessionHelper.cardno;
                SearchUser();
            }
        }
    }
}
