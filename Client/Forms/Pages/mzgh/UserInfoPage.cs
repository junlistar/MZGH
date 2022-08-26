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

            this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            //this.txtZhiye.TextChanged += txtZhiye_TextChanged;
            txthomedistrict.KeyUp += txthomedistrict_KeyUp;
            txthomedistrict.Leave += txthomedistrict_Leave;
            dgv_district.Leave += dgv_district_Leave;

            this.txtZhiye.TextChanged += txtZhiye_TextChanged;
            txtZhiye.KeyUp += txtZhiye_KeyUp;
            txtZhiye.Leave += txtZhiye_Leave;
            dgv_zhiye.Leave += dgv_zhiye_Leave;

            dgv_district.KeyDown += Dgv_district_KeyDown;
            dgv_zhiye.KeyDown += Dgv_zhiye_KeyDown;

            lblmsg.ForeColor = Color.Red;

            txt_birth.Text = "";
            txt_rel_birth.Text = "";

            cbxResponseType.DataSource = SessionHelper.responseTypes;
            cbxResponseType.ValueMember = "code";
            cbxResponseType.DisplayMember = "name";

            cbxChargeTypes.DataSource = SessionHelper.chargeTypes;
            cbxChargeTypes.ValueMember = "code";
            cbxChargeTypes.DisplayMember = "name";


        }
        #region 文本框搜索查询事件

        UIDataGridView dgv_district = new UIDataGridView();
        UIDataGridView dgv_zhiye = new UIDataGridView();
        UIDataGridView dgv_shenfen = new UIDataGridView();

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
                log.Error(ex.StackTrace);
            }
        }

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
                log.Error(ex.StackTrace);
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
                log.Error(ex.StackTrace);
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
                log.Error(ex.StackTrace);
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
                log.Error(ex.StackTrace);
            }
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
        #endregion

        public void InitDic()
        {

            log.Info("初始化数据字典：InitDic");


            cbxResponseType.DataSource = SessionHelper.responseTypes;
            cbxResponseType.ValueMember = "code";
            cbxResponseType.DisplayMember = "name";

            cbxChargeTypes.DataSource = SessionHelper.chargeTypes;
            cbxChargeTypes.ValueMember = "code";
            cbxChargeTypes.DisplayMember = "name";

            this.cbx_relation.DataSource = SessionHelper.relativeCodes;
            cbx_relation.DisplayMember = "name";
            cbx_relation.ValueMember = "code";
            cbx_relation.Text = "本人";


            this.cbx_rel_relation.DataSource = SessionHelper.relativeCodes;
            cbx_rel_relation.DisplayMember = "name";
            cbx_rel_relation.ValueMember = "code";
            cbx_rel_relation.Text = "本人";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                //获取数据
                var _pid = txt_patientId.Text;
                if (string.IsNullOrEmpty(_pid))
                {
                    UIMessageTip.Show("没有数据");
                    return;
                }

                var _name = txt_name.Text;
                var _tel = txthometel.Text;

                var _responseType = cbxResponseType.SelectedValue;
                var _chargeType = cbxChargeTypes.SelectedValue;
                var _district = txthomedistrict.TagString;

                var _employer_name = txtemployername.Text;
                var _zhiye = txtZhiye.TagString;

                var sex = "1";
                switch (cbxsex.Text)
                {
                    case "男": sex = "1"; break;
                    case "女": sex = "2"; break;
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

                var _patientVM = new PatientVM();
                _patientVM.patient_id = _pid;
                _patientVM.name = _name;
                _patientVM.sex = _sex;
                _patientVM.marry_code = _marry_code.ToString();
                _patientVM.birthday = _birth;
                _patientVM.home_tel = _tel;
                _patientVM.relation_name = _relation_name;
                if (_relation_code != null)
                {
                    _patientVM.relation_code = _relation_code.ToString();
                }
                _patientVM.home_street = _home_address;
                _patientVM.home_district = _district;
                _patientVM.response_type = _responseType.ToString();
                _patientVM.charge_type = _chargeType.ToString();
                _patientVM.occupation_type = _zhiye;
                _patientVM.employer_name = _employer_name;

                _patientVM.update_opera = _opera;


                string jsonStr = WebApiHelper.SerializeObject(_patientVM);

                HttpContent httpContent = new StringContent(jsonStr, Encoding.GetEncoding("UTF-8"));

                var paramurl = string.Format($"/api/User/UpdateUserBaseInfoByJson");
                string json = HttpClientUtil.PostJSON(paramurl, _patientVM);
                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                if (result.status == 1)
                {
                    //更新监护人信息
                    UpdateRelationInfo();

                    UIMessageTip.Show("保存成功！");
                    BindBaseInfo(_pid);
                    BindRelativeInfo(_pid);
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }


                //var paramurl = string.Format($"/api/User/UpdateUserBaseInfo?pid={_pid}&name={_name}&sex={_sex}&marry_code={_marry_code}&birthday={_birth}&tel={_tel}&relation_name={_relation_name}" +
                //     $"&relation_code={_relation_code}&home_street={_home_address}&district={_district}&responseType={_responseType}&chargeType={_chargeType}&opera={_opera}");
                //var json = HttpClientUtil.Get(paramurl);
                //var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                //if (result.status == 1)
                //{
                //    UIMessageTip.Show("保存成功！");
                //    BindRelativeInfo(_pid);
                //}
                //else
                //{
                //    UIMessageTip.ShowError(result.message);
                //    log.Error(result.message);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        /// <summary>
        /// 更新监护人信息
        /// </summary>
        public void UpdateRelationInfo()
        {

            try
            {

                var _pid = txt_patientId.Text;
                var _code = cbx_rel_relation.SelectedValue;
                var _sfz_id = txt_rel_sfzid.Text;
                var _name = txt_relationname.Text;
                var _sex = cbxsex.Text == "男" ? 1 : 2;
                var _tel = txt_rel_tel.Text;
                var _opera = SessionHelper.uservm.user_mi;
                var _birth = txt_rel_birth.Value;
                var _addr = txt_rel_address.Text;

                if (_code == null || string.IsNullOrEmpty(_code.ToString()))
                {
                    UIMessageTip.Show("请选择关系！"); cbx_rel_relation.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(_name))
                {
                    UIMessageTip.Show("请输入姓名！"); txt_relationname.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(_sfz_id))
                {
                    UIMessageTip.Show("请输入身份证！"); txt_rel_sfzid.Focus();
                    return;
                }
                string paramurl = string.Format($"/api/user/UpdateMzPatientRelation?patient_id={_pid}&relation_code={_code}&sfz_id={_sfz_id}&username={_name}&sex={_sex}&tel={_tel}&opera={_opera}&birth={_birth}&address={_addr}");

                var json = HttpClientUtil.Get(paramurl);

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
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
            try
            {


                this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
                this.txtZhiye.TextChanged -= txtZhiye_TextChanged;

                //txtId.Text = item.patient_id.Substring(3, 7);

                txtCode.Text = "";

                txt_barcode.Text = item.p_bar_code;

                txt_patientId.Text = item.patient_id;

                txt_sfz_no.Text = item.hic_no;

                if (item.birthday.HasValue)
                {
                    this.txt_birth.Text = item.birthday.Value.ToShortDateString();
                    int _year = 0, _month = 0, _day = 0;
                    DataTimeUtil.GetAgeByBirthday(item.birthday.Value, DateTime.Now, out _year, out _month, out _day);
                    item.age = _year.ToString();

                    txtAge.Text = _year.ToString();
                    txtMonth.Text = _month.ToString();
                    txtDay.Text = _day.ToString();
                }
                else
                {
                    this.txt_birth.Text = "";
                }

                txthometel.Text = item.home_tel;
                txthomedistrict.Text = item.home_street;

                txt_name.Text = item.name;

                if (!string.IsNullOrEmpty(item.home_district))
                {
                    var model = SessionHelper.districtCodes.Where(p => p.code == item.home_district).FirstOrDefault();

                    if (model != null)
                    {
                        txthomedistrict.Text = model.name;
                        txthomedistrict.TagString = item.home_district;
                    }
                }
                if (!string.IsNullOrEmpty(item.occupation_type))
                {
                    var model = SessionHelper.occupationCodes.Where(p => p.code == item.occupation_type).FirstOrDefault();

                    if (model != null)
                    {
                        txtZhiye.Text = model.name;
                        txtZhiye.TagString = item.occupation_type;
                    }
                }

                //地区
                this.sfz_home_address.Text = item.home_street;

                //身份  
                //费别 
                cbxResponseType.SelectedValue = item.response_type;
                cbxChargeTypes.SelectedValue = item.charge_type;
                txtrelationname.Text = item.relation_name;
                if (!string.IsNullOrEmpty(item.relation_code))
                {
                    cbx_relation.SelectedValue = item.relation_code;
                }
                else
                {
                    cbx_relation.Text = "本人";
                }

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
                        marrycode = "未婚"; break;
                        break;
                }
                this.cbxmarrycode.Text = marrycode;

                txtemployername.Text = item.employer_name;


                this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
                this.txtZhiye.TextChanged += txtZhiye_TextChanged;
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
            // this.txtZhiye.TextChanged -= txtZhiye_TextChanged;


            cbxsex.Text = "";
            txtrelationname.Text = "";
            txthometel.Text = "";
            ybk_psn_no.Text = "";
            cbxmarrycode.Text = "";
            ybk_psn_cert_type.Text = "";
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
            this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
            this.txtZhiye.TextChanged -= txtZhiye_TextChanged;

            txt_barcode.Text = "";
            txt_patientId.Text = "";
            txt_sfz_no.Text = "";
            txtAge.Text = "";
            txtMonth.Text = "";
            txtDay.Text = "";
            txtDay.Text = "";
            txthometel.Text = "";
            txthomedistrict.Text = "";
            txt_name.Text = "";
            this.txt_birth.Text = "";
            txthomedistrict.Text = "";
            txtZhiye.Text = "";
            txtemployername.Text = "";

            //地区
            this.sfz_home_address.Text = "";

            //费别

            //cbxResponseType.Text = "";
            //cbxChargeTypes.Text = "";
            txtrelationname.Text = "";
            cbx_relation.Text = "本人";

            this.cbxsex.Text = "";

            //婚姻 
            this.cbxmarrycode.Text = "";

            this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            this.txtZhiye.TextChanged += txtZhiye_TextChanged;

            sfz_home_address.Text = "";

            ybk_psn_no.Text = "";
            ybk_psn_cert_type.Text = "";
            ybk_psn_name.Text = "";
            ybk_certno.Text = "";

        }
        public void SearchUser()
        {
            try
            {
                lblmsg.Text = "";
                txtCode.Focus();

                var input_str = this.txtCode.Text.Trim();

                if (string.IsNullOrEmpty(input_str))
                {
                    return;
                }

                ClearUserInfo();

                //获取数据    
                var barcode_url = string.Format($"/api/GuaHao/GetPatientByBarcode?barcode={input_str}");

                string paramurl = barcode_url;
                #region 根据数据长度判断查询

                //如果点击的是身份证或医保卡，择查询身份证信息
                if (SessionHelper.CardReader != null || YBHelper.currentYBInfo != null)
                {
                    paramurl = string.Format($"/api/GuaHao/GetPatientBySfzId?sfzid={input_str}");
                }
                else if (input_str.Length == 11)
                {
                    //如果长度为12，则查询patient_id 
                    paramurl = string.Format($"/api/GuaHao/GetPatientByTel?tel={input_str}");
                }
                else if (input_str.Length == 12)
                {
                    //如果长度为12，则查询patient_id 
                    paramurl = string.Format($"/api/GuaHao/GetPatientByPatientId?pid={input_str}");
                }
                else if (input_str.Length == 15 || input_str.Length == 18)
                {
                    //如果长度为15或18，则查询身份证对应的hic_no
                    paramurl = string.Format($"/api/GuaHao/GetPatientBySfzId?sfzid={input_str}");
                }
                #endregion

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);
                if (result.status == 1 && result.data.Count == 0)
                {
                    //如果没有查到数据 并且不是根据barcode查询，则再用barcode查询一次，避免数据遗漏
                    if (paramurl != barcode_url)
                    {
                        json = HttpClientUtil.Get(paramurl);
                        result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);
                    }
                }

                if (result.status == 1 && result.data != null && result.data.Count > 0)
                { 
                    //默认取最大的patient_id数据
                    var userInfo = result.data.OrderByDescending(p => p.patient_id).FirstOrDefault();

                    #region 如果身份证查询到多条记录 (废弃，默认取最大的那条记录)
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
                    #endregion

                    //绑定用户基本信息
                    BindUserInfo(userInfo);

                    //查询绑定监护人信息
                    BindRelativeInfo(userInfo.patient_id);

                    //查询patient_id关联的医保卡
                    GetYbkDetailInfo(userInfo.hic_no);
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
                    else
                    {
                        lblmsg.Text = "没有查询到数据！";
                        lblmsg.Show();
                    }
                }

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
            }
        }

        /// <summary>
        /// 查询绑定监护人信息
        /// </summary>
        /// <param name="pid">患者Id</param>
        public void BindRelativeInfo(string pid)
        {
            try
            {
                //根据patientId查找已存在的病人
                string paramurl = string.Format($"/api/user/GetMzPatientRelationByPatientId?pid={pid}");

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzPatientRelationVM>>>(json);

                if (result.status == 1 && result.data.Count > 0)
                {
                    BindUserRelativeInfo(result.data[0]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }

        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="userInfo"></param>
        private void BindUserRelativeInfo(MzPatientRelationVM userInfo)
        {
            try
            {
                cbx_rel_relation.SelectedValue = userInfo.relation_code;
                txt_relationname.Text = userInfo.username;
                txt_rel_sfzid.Text = userInfo.sfz_id;
                txt_rel_tel.Text = userInfo.tel;
                if (userInfo.birth.HasValue)
                {
                    txt_rel_birth.Value = userInfo.birth.Value;
                }
                txt_rel_address.Text = userInfo.address;
                cbx_relsex.Text = userInfo.sex == "1" ? "男" : "女";

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

        /// <summary>
        /// 根据id查询并绑定用户信息
        /// </summary>
        /// <param name="patient_id"></param>
        public void BindBaseInfo(string patient_id)
        {//获取数据    
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


        public void GetYbkDetailInfo(string certno)
        {
            if (string.IsNullOrWhiteSpace(certno))
            {
                return;
            }

            //获取数据    
            string json = "";
            string paramurl = string.Format($"/api/user/GetYbkDetailInfo?certno={certno}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                json = HttpClientUtil.Get(paramurl);

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

        private void txt_patientId_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchUser();
            }
        }

        private void btnEditRelation_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_patientId.Text))
            {
                RelationInfoEdit relationInfoEdit = new RelationInfoEdit(txt_patientId.Text, "", txtrelationname.Text);
                if (relationInfoEdit.ShowDialog() == DialogResult.OK)
                {
                    BindBaseInfo(txt_patientId.Text);
                    BindRelativeInfo(txt_patientId.Text);
                }
            }

        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void txthomedistrict_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
