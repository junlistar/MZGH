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
            string json = ""; string paramurl = "";


            //根据patientId查找已存在的病人
            Task<HttpResponseMessage> task = null;
            json = "";
            paramurl = string.Format($"/api/GuaHao/GetNewPatientId");
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            var result = WebApiHelper.DeserializeObject<ResponseResult<string>>(json);
            if (result.status==1)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            //var cardType = cbxCardType.Text.ToString();
            var cardId = txtCardId.Text.Trim();
            var sfzId = txtsfz.Text.Trim();
            var ybkId = txtybk.Text.Trim();
            var patientId = this.txtpatientid.Text;
            var userName = this.txtUserName.Text;
            var sex = this.rdoMale.Checked ? "1" : "2";
            var birth = this.dtpBirth.Text;
            var tel = this.txtTel.Text.Trim();


            //验证卡号 
            if (string.IsNullOrWhiteSpace(cardId))
            {
                UIMessageTip.ShowError("卡号不能为空!");
                txtCardId.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                UIMessageTip.ShowWarning("姓名不能为空!");
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tel))
            {
                UIMessageTip.ShowWarning("手机号码不能为空!");
                txtTel.Focus();
                return;
            }

            if (!StringUtil.IsMobile(tel))
            {
                UIMessageTip.ShowWarning("手机号码格式有误!");
                txtTel.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(sfzId))
            {
                UIMessageTip.ShowWarning("身份证号码不能为空!");
                txtsfz.Focus();
                return;
            }

            //地区
            var district = this.txthomedistrict.TagString;

            //街道
            var street = this.txthomestreet.Text;

            //职业
            var zhiye = this.txtZhiye.TagString;

            //身份
            //var response_type = this.txtShenfen.TagString;
            var response_type = this.cbxShenfen.SelectedValue;

            //费别
            var charge_type = this.cbxChargeType.SelectedValue;


            //医保卡
            var sno = "";
            //身份证
            var hicno = "";
            //磁卡
            var barcode = "";

            if (!string.IsNullOrWhiteSpace(sfzId))
            {
                //验证卡号是否是身份证号
                if (!StringUtil.CheckIDCard(sfzId))
                {
                    UIMessageTip.ShowError("身份证号码不正确!");
                    txtsfz.Focus();
                    return;
                }
                hicno = sfzId;
            }
            if (!string.IsNullOrWhiteSpace(ybkId))
            {
                sno = ybkId;
            }
            barcode = cardId;
            try
            {

                string json = ""; string paramurl = "";


                //根据patientId查找已存在的病人
                Task<HttpResponseMessage> task = null;
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={cardId}");
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



                json = "";
                paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={hicno}");
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);
                 
                if (result.status == 1 && result.data.Count > 0)
                {
                    for (int i = 0; i < result.data.Count; i++)
                    {
                        var pid = result.data[i].patient_id;
                        if (string.IsNullOrEmpty(patientId) || patientId.Length == 7)
                        {
                            //UIMessageTip.ShowError("系统中已存在此身份证号!");

                            if (!UIMessageBox.ShowAsk("系统中已存在此身份证号,是否覆盖？"))
                            {
                                txtsfz.Focus();
                                return;
                            }
                            //清空相同身份证号信息
                            DeleteSocialNo(sno);
                        }
                        else if (pid != patientId)
                        {
                            if (!UIMessageBox.ShowAsk("系统中已存在此身份证号,是否覆盖？"))
                            {
                                txtsfz.Focus();
                                return;
                            }
                            //清空相同身份证号信息
                            DeleteSocialNo(sno);

                        }
                    }

                }



                var d = new
                {
                    pid = patientId,
                    hicno = hicno,
                    sno = sno,
                    barcode = barcode,
                    name = userName,
                    sex = sex,
                    birth = birth,
                    tel = tel,
                    home_district = district,
                    home_street = street,
                    occupation_type = zhiye,
                    response_type = response_type,
                    charge_type = charge_type,
                    opera = SessionHelper.uservm.user_mi
                };
                var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                paramurl = string.Format($"/api/GuaHao/EditUserInfo?pid={d.pid}&sno={d.sno}&hicno={d.hicno}&barcode={d.barcode}&name={d.name}&sex={d.sex}&birthday={d.birth}&tel={d.tel}&home_district={d.home_district}&home_street={d.home_street}&occupation_type={d.occupation_type}&response_type={d.response_type}&charge_type={d.charge_type}&opera={d.opera}");

                string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);

                if (responseJson.data == 1 || responseJson.data == 2)
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
                log.Debug(ex.Message);
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
            SessionHelper.cardno = "";

            InitUI();

            if (string.IsNullOrEmpty(barCode))
            {
                //创建新的id
                GetNewPatientId();

                this.txtUserName.Text = "新病人";
                this.rdoMale.Checked = true;

                //绑定身份证数据
                if (SessionHelper.CardReader != null)
                {
                    //this.cbxCardType.Text = "身份证";
                    this.txtsfz.Text = SessionHelper.CardReader.IDCard;
                    this.txtUserName.Text = SessionHelper.CardReader.Name;
                    this.txthomestreet.Text = SessionHelper.CardReader.Address;


                    if (SessionHelper.CardReader.Sex == "男")
                    {
                        this.rdoMale.Checked = true;
                    }
                    else
                    {
                        this.rdoFemale.Checked = true;
                    }

                    if (!string.IsNullOrWhiteSpace(SessionHelper.CardReader.BirthDay))
                    {
                        this.dtpBirth.Value = Convert.ToDateTime(SessionHelper.CardReader.BirthDay);
                    }

                }
                else if (YBHelper.currentYBInfo != null)
                {
                    try
                    {
                        //this.cbxCardType.Text = "身份证";
                        this.txtybk.Text = YBHelper.currentYBInfo.output.baseinfo.certno;
                        this.txtsfz.Text = YBHelper.currentYBInfo.output.baseinfo.certno;
                        this.txtUserName.Text = YBHelper.currentYBInfo.output.baseinfo.psn_name;


                        if (YBHelper.currentYBInfo.output.baseinfo.gend == "1")
                        {
                            this.rdoMale.Checked = true;
                        }
                        else
                        {
                            this.rdoFemale.Checked = true;
                        }

                        if (!string.IsNullOrWhiteSpace(YBHelper.currentYBInfo.output.baseinfo.brdy))
                        {
                            this.dtpBirth.Value = Convert.ToDateTime(YBHelper.currentYBInfo.output.baseinfo.brdy);
                        }

                    }
                    catch (Exception ex)
                    {
                        log.Error("医保数据为空：" + ex.Message);
                    }
                }
            }
            else
            {
                LoadUserInfo(barCode);
            }
            BindEvent();
        }




        public void InitUI()
        {

            this.cbxChargeType.DataSource = SessionHelper.chargeTypes;

            this.cbxChargeType.ValueMember = "code";
            this.cbxChargeType.DisplayMember = "name";


            this.cbxShenfen.DataSource = SessionHelper.responseTypes;

            this.cbxShenfen.ValueMember = "code";
            this.cbxShenfen.DisplayMember = "name";


            this.dtpBirth.Value = DateTime.Now;


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
                Task<HttpResponseMessage> task = null;
                string json = "";
                string paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={code}");
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;


                if (listApi!=null &&listApi.Count > 0)
                {
                    userInfo = listApi[0];

                    BindUserInfo(userInfo, code);
                }
                else
                {
                    //没有查到，新增病人信息
                    if (this._dto != null && _dto.Data != null)
                    {
                        this.cbxCardType.Text = "身份证";
                        this.txtCardId.Text = _dto.Data.IDCard;
                        this.txtUserName.Text = _dto.Data.Name;
                        this.txthomestreet.Text = _dto.Data.Address;


                        if (_dto.Data.Sex == "男")
                        {
                            this.rdoMale.Checked = true;
                        }
                        else
                        {
                            this.rdoFemale.Checked = true;
                        }

                        if (!string.IsNullOrWhiteSpace(_dto.Data.BirthDay))
                        {
                            this.dtpBirth.Value = Convert.ToDateTime(_dto.Data.BirthDay);
                        }
                    }
                    else
                    {

                        this.cbxCardType.Text = "身份证";
                        txtCardId.Text = code;
                        this.txtUserName.Text = "新病人";
                        this.rdoMale.Checked = true;
                    }

                }
            }
            catch (Exception ex)
            {

                log.Debug(ex.Message);
            }

        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="userInfo"></param>
        private void BindUserInfo(PatientVM userInfo, string code)
        {

            //if (code == userInfo.p_bar_code)
            //{
            //    this.cbxCardType.Text = "磁卡";
            //}
            //else if (code == userInfo.social_no)
            //{
            //    this.cbxCardType.Text = "身份证";
            //}
            //else if (code == userInfo.hic_no)
            //{
            //    this.cbxCardType.Text = "医保卡";
            //}
            //else
            //{
            //    this.cbxCardType.Text = "身份证";
            //}
            //txtCardId.Text = code;
            txtCardId.Text = userInfo.p_bar_code;

            //0524字段调整：hic_no 是身份证号，social_no是医保号
            txtsfz.Text = userInfo.hic_no;
            txtybk.Text = userInfo.social_no;

            this.txtpatientid.Text = userInfo.patient_id;
            this.txtUserName.Text = userInfo.name;

            if (userInfo.sex == "1")
            {
                this.rdoMale.Checked = true;
            }
            else
            {
                this.rdoFemale.Checked = true;
            }
            if (userInfo.birthday.HasValue)
            {
                this.dtpBirth.Text = userInfo.birthday.Value.ToShortDateString();
            }
            //this.txtAge.Text = userInfo["age"].ToString();

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
            if (!string.IsNullOrWhiteSpace(userInfo.response_type))
            {
                this.txtShenfen.TagString = userInfo.response_type;

                var model = SessionHelper.responseTypes.Where(p => p.code == userInfo.response_type).FirstOrDefault();

                if (model != null)
                {
                    this.txtShenfen.Text = model.name;
                }
            }

            this.cbxShenfen.SelectedValue = userInfo.response_type;

            //费别
            this.cbxChargeType.SelectedValue = userInfo.charge_type;


        }

        private void BindEvent()
        {

            this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            this.txtZhiye.TextChanged += txtZhiye_TextChanged;
            this.txtShenfen.TextChanged += txtShenfen_TextChanged;

        }

        UIDataGridView dgv_district = new UIDataGridView();
        UIDataGridView dgv_zhiye = new UIDataGridView();
        UIDataGridView dgv_shenfen = new UIDataGridView();
        private void txthomedistrict_TextChanged(object sender, EventArgs e)
        {
            //查询科室信息 显示到girdview
            var tb = sender as UITextBox;
            //var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (SessionHelper.districtCodes != null && SessionHelper.districtCodes.Count > 0)
            {
                var ipt = txthomedistrict.Text.Trim();

                dgv_district.Parent = this;
                dgv_district.Top = tb.Top + tb.Height;
                dgv_district.Left = tb.Left;
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
            if (e.RowIndex == -1)
            {
                return;
            }
            var obj = sender as UIDataGridView;
            var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
            var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
            txthomedistrict.Text = name;
            //txthomestreet.Text = name;
            txthomedistrict.TagString = unit_sn;
            txthomedistrict.TextChanged += txthomedistrict_TextChanged;

            dgv_district.Hide();
        }

        private void txthomedistrict_Leave(object sender, EventArgs e)
        {
            if (!dgv_district.Focused)
            {
                dgv_district.Hide();
            }
        }

        private void txtZhiye_TextChanged(object sender, EventArgs e)
        {
            //查询科室信息 显示到girdview
            var tb = sender as UITextBox;
            //var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (SessionHelper.occupationCodes != null && SessionHelper.occupationCodes.Count > 0)
            {
                var ipt = txtZhiye.Text.Trim();

                dgv_zhiye.Parent = this;
                dgv_zhiye.Top = tb.Top + tb.Height;
                dgv_zhiye.Left = tb.Left;
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

        private void dgv_zhiye_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtZhiye_Leave(object sender, EventArgs e)
        {
            if (!dgv_zhiye.Focused)
            {
                dgv_zhiye.Hide();
            }
        }

        private void txtShenfen_TextChanged(object sender, EventArgs e)
        {
            //查询科室信息 显示到girdview
            var tb = sender as UITextBox;
            //var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (SessionHelper.responseTypes != null && SessionHelper.responseTypes.Count > 0)
            {
                var ipt = txtShenfen.Text.Trim();

                dgv_shenfen.Parent = this;
                dgv_shenfen.Top = tb.Top + tb.Height;
                dgv_shenfen.Left = tb.Left;
                dgv_shenfen.Width = tb.Width;
                dgv_shenfen.Height = 200;
                dgv_shenfen.BringToFront();
                dgv_shenfen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_shenfen.RowHeadersVisible = false;
                dgv_shenfen.BackgroundColor = Color.White;
                dgv_shenfen.ReadOnly = true;


                List<ResponceTypeVM> vm = SessionHelper.responseTypes;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                }
                dgv_shenfen.DataSource = vm;

                dgv_shenfen.Columns["code"].HeaderText = "编号";
                dgv_shenfen.Columns["name"].HeaderText = "名称";
                dgv_shenfen.Columns["py_code"].Visible = false;
                dgv_shenfen.Columns["d_code"].Visible = false;
                dgv_shenfen.Columns["response_group"].Visible = false;

                dgv_shenfen.AutoResizeColumns();

                dgv_shenfen.CellClick += dgv_shenfen_CellContentClick;
                dgv_shenfen.Show();
            }
        }

        private void dgv_shenfen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            var obj = sender as UIDataGridView;
            var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
            var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtShenfen.TextChanged -= txtShenfen_TextChanged;
            txtShenfen.Text = name;
            txtShenfen.TagString = unit_sn;
            txtShenfen.TextChanged += txtShenfen_TextChanged;

            dgv_shenfen.Hide();
        }
        private void txtShenfen_Leave(object sender, EventArgs e)
        {
            if (!dgv_shenfen.Focused)
            {
                dgv_shenfen.Hide();
            }
        }

        private void txthomedistrict_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cbxCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userInfo != null)
            {
                if (cbxCardType.Text == "身份证")
                {
                    txtCardId.Text = userInfo.social_no;
                }
                else if (cbxCardType.Text == "医保卡")
                {
                    txtCardId.Text = userInfo.hic_no;
                }
                else if (cbxCardType.Text == "磁卡")
                {
                    txtCardId.Text = userInfo.p_bar_code;
                }

            }

        }

        private void txtCardId_Leave(object sender, EventArgs e)
        {
            //如果是身份证，自动填充出生日期
            if (cbxCardType.Text == "身份证")
            {

                var cardId = txtCardId.Text.Trim();
                //验证卡号是否是身份证号
                if (StringUtil.CheckIDCard(cardId))
                {
                    if (cardId.Length == 18)
                    {
                        string birth = cardId.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                        DateTime time = new DateTime();
                        if (DateTime.TryParse(birth, out time))
                        {
                            this.dtpBirth.Value = time;
                        }
                    }
                    else if (cardId.Length == 15)
                    {
                        string birth = cardId.Substring(6, 6).Insert(4, "-").Insert(2, "-");
                        DateTime time = new DateTime();
                        if (DateTime.TryParse(birth, out time))
                        {
                            this.dtpBirth.Value = time;
                        }
                    }
                }

            }
        }

        private void txtsfz_Leave(object sender, EventArgs e)
        {
            var cardId = txtsfz.Text.Trim();
            //验证卡号是否是身份证号
            if (StringUtil.CheckIDCard(cardId))
            {
                if (cardId.Length == 18)
                {
                    string birth = cardId.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                    DateTime time = new DateTime();
                    if (DateTime.TryParse(birth, out time))
                    {
                        this.dtpBirth.Value = time;
                    }
                }
                else if (cardId.Length == 15)
                {
                    string birth = cardId.Substring(6, 6).Insert(4, "-").Insert(2, "-");
                    DateTime time = new DateTime();
                    if (DateTime.TryParse(birth, out time))
                    {
                        this.dtpBirth.Value = time;
                    }
                }
            }
        }

        private void lklduka_Click(object sender, EventArgs e)
        {
            ReadCard rc = new ReadCard("身份证");
            //关闭，刷新
            rc.FormClosed += Rc_FormClosed; ;
            rc.ShowDialog();
        }

        private void Rc_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SessionHelper.CardReader != null)
            {
                this.txtsfz.Text = SessionHelper.CardReader.IDCard;
                this.txtUserName.Text = SessionHelper.CardReader.Name;
                this.txthomestreet.Text = SessionHelper.CardReader.Address;


                if (SessionHelper.CardReader.Sex == "男")
                {
                    this.rdoMale.Checked = true;
                }
                else
                {
                    this.rdoFemale.Checked = true;
                }

                if (!string.IsNullOrWhiteSpace(SessionHelper.CardReader.BirthDay))
                {
                    this.dtpBirth.Value = Convert.ToDateTime(SessionHelper.CardReader.BirthDay);
                }
            }
        }

        private void cbxDist_TextChanged(object sender, EventArgs e)
        {
            //cbxDist.DataSource = SessionHelper.units.Where(p => p.py_code.StartsWith(cbxDist.Text)).ToList();
            //cbxDist.ValueMember = "code";
            //cbxDist.DisplayMember = "name";
        }

        private void cbxDist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txthomedistrict_KeyUp(object sender, KeyEventArgs e)
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

        private void txtZhiye_KeyUp(object sender, KeyEventArgs e)
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

        private void UserInfoEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
