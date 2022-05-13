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
using Client.ViewModel;
using log4net;
using Sunny.UI;


namespace Client.Forms.Pages
{
    public partial class UserInfoPage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(UserInfoPage));//typeof放当前类
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
            this.txtZhiye.TextChanged += txtZhiye_TextChanged;

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
                dgv_zhiye.Height = 200;
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


        public void InitDic()
        {

            log.Info("初始化数据字典：InitDic");

            //获取用户费别信息
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/GuaHao/GetMzHaomings");

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
            var hmlist = WebApiHelper.DeserializeObject<ResponseResult<List<MzHaomingVM>>>(json).data;

            MzHaomingVM vm = new MzHaomingVM();
            vm.code = "";
            vm.name = "";
            hmlist.Insert(0, vm);
            this.cbxhm.DataSource = hmlist;

            cbxhm.DisplayMember = "name";
            cbxhm.ValueMember = "code";

            this.cbxShenfen.DataSource = SessionHelper.responseTypes;
            cbxShenfen.DisplayMember = "name";
            cbxShenfen.ValueMember = "code";
            this.cbxFeibie.DataSource = SessionHelper.chargeTypes;
            cbxFeibie.DisplayMember = "name";
            cbxFeibie.ValueMember = "code";


            dgv_district.KeyDown += Dgv_district_KeyDown;
            dgv_zhiye.KeyDown += Dgv_zhiye_KeyDown;

            txtbirth.Text = DateTime.Now.ToShortDateString();
        }

        private void cbxhm_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = cbxhm.SelectedText;
            var val = cbxhm.SelectedValue;

            if (text == "新病人")
            {
                GetNewPatientId();

                this.txtId.ReadOnly = true;
            }
            else if (text == "病人ID")
            {
                this.txtId.ReadOnly = false;
            }
            else if (text == "磁卡号")
            {
                this.txtId.ReadOnly = true;
            }
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
            var newid = WebApiHelper.DeserializeObject<ResponseResult<string>>(json).data;

            this.txtId.Text = newid;
            this.txtbarcode.Text = newid;
            txtname.Text = "新病人";
            cbxsex.Text = "男";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var text = cbxhm.SelectedText;
            var val = cbxhm.SelectedValue;

            if (text == "新病人" || text == "病人ID" || text == "磁卡号")
            {
                EditUser();
            }

        }

        public void EditUser()
        {
            var cardId = txtbarcode.Text.Trim();
            var sfzId = txtsno.Text.Trim();
            var ybkId = txthicno.Text.Trim();
            var patientId = this.txtId.Text;
            var userName = this.txtname.Text;
            var sex = this.cbxsex.Text == "男" ? "1" : "0";
            var birth = this.txtbirth.Text;
            var tel = this.txtTel.Text.Trim();


            //验证卡号 
            if (string.IsNullOrWhiteSpace(cardId))
            {
                UIMessageTip.ShowError("卡号不能为空!");
                txtbarcode.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                UIMessageTip.ShowWarning("姓名不能为空!");
                txtname.Focus();
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
            var charge_type = this.cbxFeibie.SelectedValue;

            var sno = "";
            var hicno = "";
            var barcode = "";

            var pname = txtpname.Text;




            if (!string.IsNullOrWhiteSpace(sfzId))
            {
                //验证卡号是否是身份证号
                if (!StringUtil.CheckIDCard(sfzId))
                {
                    UIMessageTip.ShowError("身份证号码不正确!");
                    txtsno.Focus();
                    return;
                }
                sno = sfzId;
            }
            if (!string.IsNullOrWhiteSpace(ybkId))
            {
                hicno = ybkId;
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
                var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;


                if (listApi.Count > 0)
                {
                    for (int i = 0; i < listApi.Count; i++)
                    {
                        var pid = listApi[i].patient_id;
                        //if (string.IsNullOrEmpty(patientId) || patientId.Length == 7)
                        //{
                        //    UIMessageTip.ShowError("系统中已存在此卡号!");
                        //    txtbarcode.Focus();
                        //    return;
                        //}
                        //else
                        if (pid.Substring(3,7) != patientId)
                        {
                            lblmsg.Text = "系统中已存在此卡号!";
                            UIMessageTip.ShowError("系统中已存在此卡号!");
                            txtbarcode.Focus();
                            return;
                        }
                    }

                }

                json = "";
                paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={sno}");
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;


                if (listApi.Count > 0)
                {
                    for (int i = 0; i < listApi.Count; i++)
                    {
                        var pid = listApi[i].patient_id;
                        //if (string.IsNullOrEmpty(patientId) || patientId.Length == 7)
                        //{
                        //    UIMessageTip.ShowError("系统中已存在此身份证号!");
                        //    txtsno.Focus();
                        //    return;
                        //}
                        //else 
                        if (pid.Substring(3, 7) != patientId)
                        {
                            lblmsg.Text = "系统中已存在此身份证号!";
                            UIMessageTip.ShowError("系统中已存在此身份证号!");
                            txtsno.Focus();
                            return;
                        }
                    }

                }



                var d = new
                {
                    pid = patientId,
                    sno = sno,
                    hicno = hicno,
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
                    UIMessageTip.ShowOk("操作成功!");
                    SessionHelper.cardno = barcode;
                    //this.Close();
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

        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbxhm.SelectedText == "病人ID")
            {
                if (!txtId.ReadOnly && !string.IsNullOrWhiteSpace(txtId.Text.Trim()))
                {
                    //搜索id 并赋值
                    string json = "";
                    string paramurl = string.Format($"/api/GuaHao/GetPatientByPatientId?pid={txtId.Text.Trim()}");
                    var task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                    task.Wait();
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var read = response.Content.ReadAsStringAsync();
                        read.Wait();
                        json = read.Result;
                    }
                    var dat = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;
                    if (dat != null && dat.Count > 0)
                    {
                        var item = dat[0];

                        BindUserInfo(item);
                    }
                }
            }
        }



        private void txtbarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cbxhm.SelectedText =="磁卡号")
            {
                //搜索bardcode 并赋值

                if (!string.IsNullOrWhiteSpace(txtbarcode.Text.Trim()))
                {
                    string json = "";
                    string paramurl = string.Format($"/api/GuaHao/GetPatientByBarcode?barcode={txtbarcode.Text.Trim()}");
                    var task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                    task.Wait();
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var read = response.Content.ReadAsStringAsync();
                        read.Wait();
                        json = read.Result;
                    }
                    var dat = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;
                    if (dat != null && dat.Count > 0)
                    {
                        var item = dat[0];

                        BindUserInfo(item);
                    }

                }
            }
        }

        public void BindUserInfo(PatientVM item)
        {


            this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
            this.txtZhiye.TextChanged -= txtZhiye_TextChanged;

            txtId.Text = item.patient_id.Substring(3,7);
            txtbarcode.Text = item.p_bar_code;
            txtsno.Text = item.social_no;
            txthicno.Text = item.hic_no;
 
            txtname.Text = item.name;

            if (item.birthday.HasValue)
            {
                this.txtbirth.Text = item.birthday.Value.ToShortDateString();
            }
            //this.txtAge.Text = userInfo["age"].ToString();

            this.txtTel.Text = item.home_tel;

            //cbxmarrycode.Text = EnumExtension.GetDescription()


            if (!string.IsNullOrWhiteSpace(item.home_district))
            {
                this.txthomedistrict.TagString = item.home_district;

                var model = SessionHelper.districtCodes.Where(p => p.code == item.home_district).FirstOrDefault();

                if (model != null)
                {
                    this.txthomedistrict.Text = model.name;
                }

            }

            //地区
            this.txthomestreet.Text = item.home_street;

            //职业
            if (!string.IsNullOrWhiteSpace(item.occupation_type))
            {
                this.txtZhiye.TagString = item.occupation_type;

                var model = SessionHelper.occupationCodes.Where(p => p.code == item.occupation_type).FirstOrDefault();

                if (model != null)
                {
                    this.txtZhiye.Text = model.name;
                }
            }

            //身份
            this.cbxShenfen.SelectedValue = item.response_type;

            //费别
            this.cbxFeibie.SelectedValue = item.charge_type;

            this.cbxsex.Text = item.sex == "1"? "男" : "女";


            this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            this.txtZhiye.TextChanged += txtZhiye_TextChanged;
        }
    }
}
