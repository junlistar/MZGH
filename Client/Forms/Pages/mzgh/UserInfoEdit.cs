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
using System.Net.Http;
using System.Configuration;
using Client.ClassLib;
using System.Net.Http.Headers;
using Client.ViewModel;
using log4net;
using System.Runtime.InteropServices;

namespace Client
{
    public partial class UserInfoEdit : UIForm
    {
        public string barCode = ""; CardReader _dto;
        PatientVM userInfo;

        private static ILog log = LogManager.GetLogger(typeof(UserInfoEdit));//typeof放当前类



        public UserInfoEdit(string _barCode, CardReader dto)
        {
            InitializeComponent();
            this.barCode = _barCode; _dto = dto;

        }

        private void GetNewPatientId()
        {

            try
            {
                //根据patientId查找已存在的病人 
                var paramurl = string.Format($"/api/GuaHao/GetNewPatientId");
                var json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<string>>(json);
                if (result.status == 1)
                {
                    var newid = result.data;
                    this.txtpatientid.Text = newid;
                    this.txtCardId.Text = newid;
                }
                else
                {
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        public async void SaveData()
        {
            try
            {
                //var cardType = cbxCardType.Text.ToString();
                var cardId = txtCardId.Text.Trim();
                var sfzId = sfz_card_no.Text.Trim();
                var ybkId = "";
                var shebaohao = txtshebaohao.Text.Trim();
                var patientId = this.txtpatientid.Text;
                var userName = this.txtUserName.Text;
                var sex = cbxSex.Text == "男" ? "1" : "2";
                var birth = sfz_birthday.Text;
                var tel = this.txtTel.Text.Trim();
                 
                var marrycode = cbxmarrycode.Text;
                switch (marrycode)
                {
                    case "已婚":
                        marrycode = "1"; break;
                    case "未婚":
                        marrycode = "2"; break;
                    case "丧偶":
                        marrycode = "3"; break;
                    case "离婚":
                        marrycode = "4"; break;
                    case "其他":
                        marrycode = "5"; break;
                    default:
                        marrycode = "5";
                        break;
                }

                //地区
                var district = this.txthomedistrict.TagString;

                //街道
                var street = this.txthomestreet.Text;

                //工作单位
                var employername = txtemployername.Text;

                //职业
                var zhiye = this.txtZhiye.TagString;

                //身份
                var response_type = cbxShenfen.SelectedValue;

                //费别
                var charge_type = cbxChargeType.SelectedValue;

                //监护人信息部分
                var relation_name = txtRelationName.Text;
                var relation_code = cbxRelation.SelectedValue;

                //var _sfz_id = txt_rel_sfzid.Text;
                //var _sex = cbx_relsex.Text == "男" ? 1 : 2;
                //var _tel = txt_rel_tel.Text;
                var _opera = SessionHelper.uservm.user_mi;
                //var _birth = txt_rel_birth.Value;
                //var _addr = txt_rel_address.Text;


                //医保卡
                var sno = "";
                //身份证
                var hicno = "";
                //磁卡
                var barcode = "";

                if (cbxSex.Text != "男" && cbxSex.Text != "女")
                {
                    UIMessageTip.ShowError("性别不正确!");
                    cbxSex.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(sfzId))
                {
                    //验证卡号是否是身份证号
                    if (!StringUtil.CheckIDCard(sfzId))
                    {
                        UIMessageTip.ShowError("身份证号码不正确!");
                        sfz_card_no.Focus();
                        return;
                    }
                    hicno = sfzId;
                }
                if (!string.IsNullOrWhiteSpace(ybkId))
                {
                    sno = ybkId;
                }
                barcode = cardId;

                //根据patientId查找已存在的病人 
                //var paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={cardId}");
                var paramurl = string.Format($"/api/GuaHao/GetPatientByBarcode?barcode={cardId}"); ;
                var json = await HttpClientUtil.GetAsync(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);

                if (result.status == 1 && result.data.Count > 0)
                {
                    for (int i = 0; i < result.data.Count; i++)
                    {
                        var pid = result.data[i].patient_id;
                        if (string.IsNullOrEmpty(patientId) || patientId.Length == 7)
                        {
                            UIMessageTip.ShowError("系统中已存在此卡号!");
                            txtCardId.Focus();
                            return;
                        }
                        else if (pid != patientId)
                        {
                            UIMessageTip.ShowError("系统中已存在此卡号!");
                            txtCardId.Focus();
                            return;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(hicno))
                {

                    // paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={hicno}");
                    paramurl = string.Format($"/api/GuaHao/GetPatientBySfzId?sfzid={hicno}");
                    json = await HttpClientUtil.GetAsync(paramurl);
                    result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);

                    if (result.status == 1 && result.data.Count > 0)
                    {
                        for (int i = 0; i < result.data.Count; i++)
                        {
                            var pid = result.data[i].patient_id;

                            //新用户
                            if (string.IsNullOrEmpty(patientId) || patientId.Length == 7)
                            {
                                //if (!UIMessageBox.ShowAsk("系统中已存在此身份证号,是否覆盖？"))
                                if (UIMessageBox.ShowAsk("系统中已存在此身份证号,是否调取患者最后一次就诊记录？"))
                                {
                                    //调取最后一次记录Id 
                                    SessionHelper.cardno = result.data[0].p_bar_code;
                                    this.Close();
                                    return;
                                }
                                else
                                {
                                    return;
                                }
                                ////清空相同身份证号信息
                                //DeleteSocialNo(sno);
                            }
                            else if (pid != patientId)//编辑
                            {
                                if (UIMessageBox.ShowAsk("系统中已存在此身份证号,是否调取患者最后一次就诊记录？"))
                                {
                                    //默认身份证唯一，取现有数据
                                    SessionHelper.cardno = result.data[0].p_bar_code;
                                    this.Close();
                                    return;
                                }
                                else
                                {
                                    return;
                                }
                                //if (UIMessageBox.ShowAsk("系统中已存在此身份证号,是否覆盖？"))
                                //{
                                //    sfz_card_no.Focus();
                                //    //清空相同身份证号信息
                                //    // DeleteSocialNo(sno);
                                //    return;
                                //}
                                //else
                                //{
                                //    break;
                                //} 
                            }
                        }
                    }
                }

                var _patientVM = new PatientVM();
                _patientVM.patient_id = patientId;
                _patientVM.hic_no = hicno;
                _patientVM.social_no = sno;
                _patientVM.addition_no1 = shebaohao;
                _patientVM.p_bar_code = barcode;
                _patientVM.name = userName;
                _patientVM.sex = sex;
                _patientVM.birthday = Convert.ToDateTime(birth);
                _patientVM.home_tel = tel;
                _patientVM.marry_code = marrycode;
                _patientVM.relation_name = relation_name;
                if (relation_code != null)
                {
                    _patientVM.relation_code = relation_code.ToString();
                }
                _patientVM.home_district = district;
                _patientVM.home_street = street;
                _patientVM.response_type = response_type.ToString();
                _patientVM.charge_type = charge_type.ToString();
                _patientVM.occupation_type = zhiye;
                _patientVM.employer_name = employername;

                _patientVM.update_opera = _opera;

                _patientVM.relation_addr = txt_rel_address.Text;
                _patientVM.relation_birth = txt_rel_birth.Text;
                _patientVM.relation_sfzid = txt_rel_sfzid.Text;
                _patientVM.relation_tel = txt_rel_tel.Text;
                _patientVM.relation_sex = cbx_relsex.Text == "男" ? "1" : "2";

                //非空验证
                var paramurl1 = string.Format($"/api/GuaHao/GetSysConfig?item_name={"mzPatientInfo_notNullColumns"}");

                var json1 = HttpClientUtil.Get(paramurl1);
                var result1 = WebApiHelper.DeserializeObject<ResponseResult<SysConfigVM>>(json1);
                if (result1.status == 1 && result1.data != null)
                {
                    var _settings = result1.data.current_settings.Split(";");

                    if (_settings.Contains("p_bar_code"))
                    {
                        //验证卡号 
                        if (string.IsNullOrWhiteSpace(_patientVM.p_bar_code))
                        {
                            UIMessageTip.ShowError("卡号不能为空!");
                            txtCardId.Focus();
                            return;
                        }
                    }
                    if (_settings.Contains("name"))
                    {
                        if (string.IsNullOrWhiteSpace(_patientVM.name))
                        {
                            UIMessageTip.ShowWarning("姓名不能为空!");
                            txtUserName.Focus();
                            return;
                        }
                    }
                    if (_settings.Contains("home_tel"))
                    {
                        if (string.IsNullOrWhiteSpace(_patientVM.home_tel))
                        {
                            UIMessageTip.ShowWarning("手机号码不能为空!");
                            txtTel.Focus();
                            return;
                        }
                        if (!StringUtil.IsMobile(_patientVM.home_tel))
                        {
                            UIMessageTip.ShowWarning("手机号码格式有误!");
                            txtTel.Focus();
                            return;
                        }
                    }
                    if (_settings.Contains("sex"))
                    {
                        if (string.IsNullOrWhiteSpace(_patientVM.sex))
                        {
                            UIMessageTip.ShowError("请选择性别!");
                            cbxSex.Focus();
                            return;
                        } 
                    }
                    if (_settings.Contains("response_type"))
                    {
                        if (string.IsNullOrWhiteSpace(_patientVM.response_type))
                        {
                            UIMessageTip.ShowWarning("请选择身份类型!");
                            cbxShenfen.Focus();
                            return;
                        }
                    }
                    if (_settings.Contains("charge_type"))
                    {
                        if (string.IsNullOrWhiteSpace(_patientVM.charge_type))
                        {
                            UIMessageTip.ShowWarning("请选择费别!");
                            cbxChargeType.Focus();
                            return;
                        }
                    }
                    if (_settings.Contains("hic_no"))
                    {
                        if (string.IsNullOrWhiteSpace(_patientVM.hic_no))
                        {
                            UIMessageTip.ShowWarning("身份证号码不能为空!");
                            sfz_card_no.Focus();
                            return;
                        }
                    }

                }



                string jsonStr = WebApiHelper.SerializeObject(_patientVM);

                HttpContent httpContent = new StringContent(jsonStr, Encoding.GetEncoding("UTF-8"));

                paramurl = string.Format($"/api/User/EditUserInfoByJson");
                //json = HttpClientUtil.PostJSON(paramurl, _patientVM);
                json = await HttpClientUtil.PostJSONAsync(paramurl, _patientVM);
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                if (responseJson.status == 1)
                {
                    barCode = cardId;
                    UIMessageTip.ShowOk("操作成功!");
                    SessionHelper.cardno = barcode;
                    this.Close();
                }
                else
                {
                    log.Error(responseJson.message);
                    UIMessageBox.ShowError(responseJson.message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        public void DeleteSocialNo(string sno)
        {
            var json = "";
            var paramurl = string.Format($"/api/GuaHao/DeleteSocialNo?sno={sno}");
            var task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
        }

        private void UserInfoEdit_Load(object sender, EventArgs e)
        {
            try
            {

                SessionHelper.cardno = "";

                InitUI();

                if (string.IsNullOrEmpty(barCode))
                {
                    //创建新的id
                    GetNewPatientId();

                    this.txtUserName.Text = "新患者";
                    cbxSex.Text = "男"; cbxmarrycode.Text = "未婚";

                    cbxRelation.Text = "";
                    cbx_relsex.Text = "";
                    txt_rel_birth.Text = "";

                    //绑定身份证数据
                    if (SessionHelper.CardReader != null)
                    {
                        //this.cbxCardType.Text = "身份证";
                        this.sfz_card_no.Text = SessionHelper.CardReader.IDCard;
                        this.txtUserName.Text = SessionHelper.CardReader.Name;
                        this.txthomestreet.Text = SessionHelper.CardReader.Address;

                        cbxSex.Text = SessionHelper.CardReader.Sex;

                        if (!string.IsNullOrWhiteSpace(SessionHelper.CardReader.BirthDay))
                        {
                            this.sfz_birthday.Value = Convert.ToDateTime(SessionHelper.CardReader.BirthDay);
                        }

                    }
                    else if (YBHelper.currentYBInfo != null)
                    {
                        //this.cbxCardType.Text = "身份证";
                        this.sfz_card_no.Text = YBHelper.currentYBInfo.output.baseinfo.certno;
                        this.sfz_card_no.Text = YBHelper.currentYBInfo.output.baseinfo.certno;
                        this.txtUserName.Text = YBHelper.currentYBInfo.output.baseinfo.psn_name;


                        if (YBHelper.currentYBInfo.output.baseinfo.gend == "1")
                        {
                            cbxSex.Text = "男";
                        }
                        else
                        {
                            cbxSex.Text = "女";
                        }

                        if (!string.IsNullOrWhiteSpace(YBHelper.currentYBInfo.output.baseinfo.brdy))
                        {
                            this.sfz_birthday.Value = Convert.ToDateTime(YBHelper.currentYBInfo.output.baseinfo.brdy);
                        }

                    }
                }
                else
                {
                    LoadUserInfo(barCode);
                }
                BindEvent();

                txtUserName.Focus(); this.ActiveControl = this.txtUserName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        private Control GetFocusedControl()
        {
            Control focusedControl = null;
            // To get hold of the focused control:
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                // Note that if the focused Control is not a .Net control, then this will return null.
                focusedControl = Control.FromHandle(focusedHandle);

            MessageBox.Show(focusedControl.Name);
            return focusedControl;
        }


        public void InitUI()
        {

            this.cbxChargeType.DataSource = SessionHelper.chargeTypes;

            this.cbxChargeType.ValueMember = "code";
            this.cbxChargeType.DisplayMember = "name";


            this.cbxShenfen.DataSource = SessionHelper.responseTypes;

            this.cbxShenfen.ValueMember = "code";
            this.cbxShenfen.DisplayMember = "name";


            cbxRelation.DataSource = SessionHelper.relativeCodes;

            cbxRelation.ValueMember = "code";
            cbxRelation.DisplayMember = "name";

            this.sfz_birthday.Value = DateTime.Now;


            //cbxDist.DataSource = SessionHelper.districtCodes;
            //cbxDist.ValueMember = "code";
            //cbxDist.DisplayMember = "name";


            dgv_district.KeyDown += Dgv_district_KeyDown;
            dgv_zhiye.KeyDown += Dgv_zhiye_KeyDown;
        }

        private void Dgv_zhiye_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgv_zhiye.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgv_zhiye.SelectedIndex);

                    dgv_zhiye_CellContentClick(sender, ev);
                }
            }
        }

        private void Dgv_district_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgv_district.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgv_district.SelectedIndex);

                    dgv_district_CellContentClick(sender, ev);
                }
            }
        }

        public void LoadUserInfo(string code)
        {
            try
            {
                //根据patientId查找已存在的病人 
                string paramurl = string.Format($"/api/GuaHao/GetPatientByPatientId?pid={code}");
                var json = HttpClientUtil.Get(paramurl);
                var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;


                if (listApi != null && listApi.Count > 0)
                {
                    userInfo = listApi[0];

                    BindUserInfo(userInfo, code);
                }
                else
                {
                    //没有查到，新增病人信息
                    if (this._dto != null && _dto.Data != null)
                    {
                        //this.cbxCardType.Text = "身份证";
                        this.txtCardId.Text = _dto.Data.IDCard;
                        this.txtUserName.Text = _dto.Data.Name;
                        this.sfz_card_no.Text = _dto.Data.Name;
                        this.txthomestreet.Text = _dto.Data.Address;
                        //sfz_folk.Text = _dto.Data.Folk;
                        cbxSex.Text = _dto.Data.Sex;
                        sfz_card_no.Text = _dto.Data.IDCard;

                        if (!string.IsNullOrWhiteSpace(_dto.Data.BirthDay))
                        {
                            this.sfz_birthday.Value = Convert.ToDateTime(_dto.Data.BirthDay);
                        }
                    }
                    else
                    {

                        //this.cbxCardType.Text = "身份证";
                        txtCardId.Text = code;
                        this.txtUserName.Text = "新病人";
                        //this.rdoMale.Checked = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }

        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="userInfo"></param>
        private void BindUserInfo(PatientVM userInfo, string code)
        {
            try
            {
                txtCardId.Text = userInfo.p_bar_code;

                this.txtpatientid.Text = userInfo.patient_id;
                this.txtUserName.Text = userInfo.name;
                this.sfz_card_no.Text = userInfo.hic_no;
                this.txthomestreet.Text = userInfo.home_street;
                cbxSex.Text = userInfo.sex == "1" ? "男" : "女";

                txtshebaohao.Text = userInfo.addition_no1;
                txtemployername.Text = userInfo.employer_name;

                if (userInfo.birthday.HasValue)
                {
                    this.sfz_birthday.Text = userInfo.birthday.Value.ToShortDateString();
                }
                this.txtTel.Text = userInfo.home_tel;

                //婚姻
                var marrycode = "";
                switch (userInfo.marry_code)
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
                        marrycode = "未婚";
                        break;
                }
                this.cbxmarrycode.Text = marrycode;

                if (!string.IsNullOrWhiteSpace(userInfo.home_district))
                {
                    this.txthomedistrict.TagString = userInfo.home_district;

                    var model = SessionHelper.districtCodes.Where(p => p.code == userInfo.home_district).FirstOrDefault();

                    if (model != null)
                    {
                        this.txthomedistrict.Text = model.name;
                    }

                }

                //地区
                this.txthomestreet.Text = userInfo.home_street;

                //职业
                if (!string.IsNullOrWhiteSpace(userInfo.occupation_type))
                {
                    this.txtZhiye.TagString = userInfo.occupation_type;

                    var model = SessionHelper.occupationCodes.Where(p => p.code == userInfo.occupation_type).FirstOrDefault();

                    if (model != null)
                    {
                        this.txtZhiye.Text = model.name;
                    }
                }

                //身份 
                this.cbxShenfen.SelectedValue = userInfo.response_type;

                //费别
                this.cbxChargeType.SelectedValue = userInfo.charge_type;

                //txtRelationName.Text = userInfo.relation_name;

                //if (userInfo.relation_code != null)
                //{
                //    cbxRelation.SelectedValue = userInfo.relation_code;
                //}
                //else
                //{
                //    cbxRelation.Text = "";
                //}

                //查询监护人信息
                BindRelationInfo(userInfo.patient_id);

                //查询身份证表信息
                //BindSfzInfo(userInfo.patient_id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        public void BindRelationInfo(string pid)
        {
            try
            {
                //根据patientId查找已存在的病人
                string paramurl = string.Format($"/api/user/GetMzPatientRelationByPatientId?pid={pid}");

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzPatientRelationVM>>>(json);

                if (result.status == 1 && result.data.Count > 0)
                {
                    var relationInfo = result.data[0];
                    if (relationInfo.relation_code != null)
                    {
                        cbxRelation.SelectedValue = relationInfo.relation_code;
                    }
                    txtRelationName.Text = relationInfo.username;
                    txt_rel_sfzid.Text = relationInfo.sfz_id;
                    txt_rel_tel.Text = relationInfo.tel;
                    if (relationInfo.birth.HasValue)
                    {
                        txt_rel_birth.Value = relationInfo.birth.Value;
                    }
                    txt_rel_address.Text = relationInfo.address;
                    cbx_relsex.Text = relationInfo.sex == "1" ? "男" : "女";
                }
                else
                {
                    cbxRelation.Text = "";
                    cbx_relsex.Text = "";
                    txt_rel_birth.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }


        private void BindEvent()
        {

            this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            this.txtZhiye.TextChanged += txtZhiye_TextChanged;
            //this.txtShenfen.TextChanged += txtShenfen_TextChanged;

            txthomedistrict.KeyUp += txthomedistrict_KeyUp;
            txtZhiye.KeyUp += txtZhiye_KeyUp;

            txthomedistrict.Leave += txthomedistrict_Leave;
            txtZhiye.Leave += txtZhiye_Leave;

            dgv_district.Leave += dgv_district_Leave;
            dgv_zhiye.Leave += dgv_zhiye_Leave;
        }

        UIDataGridView dgv_district = new UIDataGridView();
        UIDataGridView dgv_zhiye = new UIDataGridView();
        UIDataGridView dgv_shenfen = new UIDataGridView();
        private void txthomedistrict_TextChanged(object sender, EventArgs e)
        {
            //查询科室信息 显示到girdview
            var tb = sender as UITextBox;
            var pbl = tb.Parent as UIGroupBox;
            //获取数据 

            if (SessionHelper.districtCodes != null && SessionHelper.districtCodes.Count > 0)
            {
                var ipt = txthomedistrict.Text.Trim();

                dgv_district.Parent = this;
                dgv_district.Top = pbl.Top + tb.Top + tb.Height;
                dgv_district.Left = pbl.Left + tb.Left;
                dgv_district.Width = tb.Width;
                dgv_district.Height = 200;
                dgv_district.BringToFront();
                dgv_district.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_district.RowHeadersVisible = false;
                dgv_district.BackgroundColor = Color.White;
                dgv_district.ReadOnly = true;


                List<DistrictCodeVM> vm = SessionHelper.districtCodes;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                }
                dgv_district.DataSource = vm;

                dgv_district.Columns["code"].HeaderText = "编号";
                dgv_district.Columns["name"].HeaderText = "名称";
                dgv_district.Columns["py_code"].Visible = false;
                dgv_district.Columns["d_code"].Visible = false;
                dgv_district.Columns["zip_code"].Visible = false;
                dgv_district.Columns["gb_code"].Visible = false;

                dgv_district.AutoResizeColumns();

                dgv_district.CellClick += dgv_district_CellContentClick;
                dgv_district.Show();
            }

        }
        private void dgv_district_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                var obj = sender as UIDataGridView;
                var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
                var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
                txthomedistrict.Text = name;
                txthomedistrict.TagString = unit_sn;
                txthomedistrict.TextChanged += txthomedistrict_TextChanged;

                dgv_district.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txthomedistrict_Leave(object sender, EventArgs e)
        {
            if (!dgv_district.Focused)
            {
                dgv_district.Hide();
            }
        }
        private void dgv_district_Leave(object sender, EventArgs e)
        {
            if (!txthomedistrict.Focused)
            {
                dgv_district.Hide();
            }
        }
        private void txtZhiye_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //查询科室信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIGroupBox;
                //获取数据 

                if (SessionHelper.occupationCodes != null && SessionHelper.occupationCodes.Count > 0)
                {
                    var ipt = txtZhiye.Text.Trim();

                    dgv_zhiye.Parent = this;
                    dgv_zhiye.Top = pbl.Top + tb.Top + tb.Height;
                    dgv_zhiye.Left = pbl.Left + tb.Left;
                    dgv_zhiye.Width = tb.Width;
                    dgv_zhiye.Height = 150;
                    dgv_zhiye.BringToFront();
                    dgv_zhiye.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv_zhiye.RowHeadersVisible = false;
                    dgv_zhiye.BackgroundColor = Color.White;
                    dgv_zhiye.ReadOnly = true;


                    List<OccupationCodeVM> vm = SessionHelper.occupationCodes;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgv_zhiye.DataSource = vm;

                    dgv_zhiye.Columns["code"].HeaderText = "编号";
                    dgv_zhiye.Columns["name"].HeaderText = "名称";
                    dgv_zhiye.Columns["py_code"].Visible = false;
                    dgv_zhiye.Columns["d_code"].Visible = false;
                    dgv_zhiye.Columns["flag"].Visible = false;
                    dgv_zhiye.Columns["group_code"].Visible = false;
                    dgv_zhiye.Columns["tcmms_code"].Visible = false;

                    dgv_zhiye.AutoResizeColumns();

                    dgv_zhiye.CellClick += dgv_zhiye_CellContentClick;
                    dgv_zhiye.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgv_zhiye_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                var obj = sender as UIDataGridView;
                var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
                var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtZhiye.TextChanged -= txtZhiye_TextChanged;
                txtZhiye.Text = name;
                txtZhiye.TagString = unit_sn;
                txtZhiye.TextChanged += txtZhiye_TextChanged;

                dgv_zhiye.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtZhiye_Leave(object sender, EventArgs e)
        {
            if (!dgv_zhiye.Focused)
            {
                dgv_zhiye.Hide();
            }
        }
        private void dgv_zhiye_Leave(object sender, EventArgs e)
        {
            if (!txtZhiye.Focused)
            {
                dgv_zhiye.Hide();
            }
        }



        //private void txtShenfen_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //查询科室信息 显示到girdview
        //        var tb = sender as UITextBox;
        //        //var pbl = tb.Parent as UIPanel;
        //        //获取数据 

        //        if (SessionHelper.responseTypes != null && SessionHelper.responseTypes.Count > 0)
        //        {
        //            var ipt = txtShenfen.Text.Trim();

        //            dgv_shenfen.Parent = this;
        //            dgv_shenfen.Top = tb.Top + tb.Height;
        //            dgv_shenfen.Left = tb.Left;
        //            dgv_shenfen.Width = tb.Width;
        //            dgv_shenfen.Height = 200;
        //            dgv_shenfen.BringToFront();
        //            dgv_shenfen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //            dgv_shenfen.RowHeadersVisible = false;
        //            dgv_shenfen.BackgroundColor = Color.White;
        //            dgv_shenfen.ReadOnly = true;


        //            List<ResponceTypeVM> vm = SessionHelper.responseTypes;

        //            if (!string.IsNullOrWhiteSpace(ipt))
        //            {
        //                vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
        //            }
        //            dgv_shenfen.DataSource = vm;

        //            dgv_shenfen.Columns["code"].HeaderText = "编号";
        //            dgv_shenfen.Columns["name"].HeaderText = "名称";
        //            dgv_shenfen.Columns["py_code"].Visible = false;
        //            dgv_shenfen.Columns["d_code"].Visible = false;
        //            dgv_shenfen.Columns["response_group"].Visible = false;

        //            dgv_shenfen.AutoResizeColumns();

        //            dgv_shenfen.CellClick += dgv_shenfen_CellContentClick;
        //            dgv_shenfen.Show();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        log.Error(ex.ToString());
        //    }
        //}

        //private void dgv_shenfen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex == -1)
        //        {
        //            return;
        //        }
        //        var obj = sender as UIDataGridView;
        //        var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
        //        var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
        //        txtShenfen.TextChanged -= txtShenfen_TextChanged;
        //        txtShenfen.Text = name;
        //        txtShenfen.TagString = unit_sn;
        //        txtShenfen.TextChanged += txtShenfen_TextChanged;

        //        dgv_shenfen.Hide();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        log.Error(ex.ToString());
        //    }
        //}
        //private void txtShenfen_Leave(object sender, EventArgs e)
        //{
        //    if (!dgv_shenfen.Focused)
        //    {
        //        dgv_shenfen.Hide();
        //    }
        //}


        private void cbxCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (userInfo != null)
            //{
            //    if (cbxCardType.Text == "身份证")
            //    {
            //        txtCardId.Text = userInfo.social_no;
            //    }
            //    else if (cbxCardType.Text == "医保卡")
            //    {
            //        txtCardId.Text = userInfo.hic_no;
            //    }
            //    else if (cbxCardType.Text == "磁卡")
            //    {
            //        txtCardId.Text = userInfo.p_bar_code;
            //    }

            //}

        }

        private void txtCardId_Leave(object sender, EventArgs e)
        {
            try
            {
                ////如果是身份证，自动填充出生日期
                //if (cbxCardType.Text == "身份证")
                //{

                //    var cardId = txtCardId.Text.Trim();
                //    //验证卡号是否是身份证号
                //    if (StringUtil.CheckIDCard(cardId))
                //    {
                //        if (cardId.Length == 18)
                //        {
                //            string birth = cardId.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                //            DateTime time = new DateTime();
                //            if (DateTime.TryParse(birth, out time))
                //            {
                //                this.dtpBirth.Value = time;
                //            }
                //        }
                //        else if (cardId.Length == 15)
                //        {
                //            string birth = cardId.Substring(6, 6).Insert(4, "-").Insert(2, "-");
                //            DateTime time = new DateTime();
                //            if (DateTime.TryParse(birth, out time))
                //            {
                //                this.dtpBirth.Value = time;
                //            }
                //        }
                //    }

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtsfz_Leave(object sender, EventArgs e)
        {
            try
            {
                var cardId = sfz_card_no.Text.Trim();
                //验证卡号是否是身份证号
                if (StringUtil.CheckIDCard(cardId))
                {
                    if (cardId.Length == 18)
                    {
                        string birth = cardId.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                        DateTime time = new DateTime();
                        if (DateTime.TryParse(birth, out time))
                        {
                            //this.dtpBirth.Value = time;
                        }
                    }
                    else if (cardId.Length == 15)
                    {
                        string birth = cardId.Substring(6, 6).Insert(4, "-").Insert(2, "-");
                        DateTime time = new DateTime();
                        if (DateTime.TryParse(birth, out time))
                        {
                            //this.dtpBirth.Value = time;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void txthomedistrict_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.dgv_district.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgv_district.Rows.Count > 0)
                    {

                        var unit_sn = dgv_district.Rows[0].Cells["code"].Value.ToString();
                        var name = dgv_district.Rows[0].Cells["name"].Value.ToString();
                        txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
                        txthomedistrict.Text = name;
                        txthomedistrict.TagString = unit_sn;
                        txthomedistrict.TextChanged += txthomedistrict_TextChanged;

                        dgv_district.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtZhiye_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.dgv_zhiye.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgv_zhiye.Rows.Count > 0)
                    {

                        var unit_sn = dgv_zhiye.Rows[0].Cells["code"].Value.ToString();
                        var name = dgv_zhiye.Rows[0].Cells["name"].Value.ToString();
                        txtZhiye.TextChanged -= txtZhiye_TextChanged;
                        txtZhiye.Text = name;
                        txtZhiye.TagString = unit_sn;
                        txtZhiye.TextChanged += txtZhiye_TextChanged;

                        dgv_zhiye.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void UserInfoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SaveData();
            }
        }


        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbxmarrycode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // e.Handled = true;
            }
        }

    }
}
