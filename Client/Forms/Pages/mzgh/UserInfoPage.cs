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
using Client.Forms.Wedgit;
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
            //this.txtZhiye.TextChanged += txtZhiye_TextChanged;

            lblmsg.ForeColor = Color.Red;

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
                //var ipt = txtZhiye.Text.Trim();

                //dgv_zhiye.Parent = this;
                //dgv_zhiye.Top = tb.Top + tb.Height;
                //dgv_zhiye.Left = tb.Left;
                //dgv_zhiye.Width = tb.Width;
                //dgv_zhiye.Height = 200;
                //dgv_zhiye.BringToFront();
                //dgv_zhiye.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //dgv_zhiye.RowHeadersVisible = false;
                //dgv_zhiye.BackgroundColor = Color.White;
                //dgv_zhiye.ReadOnly = true;


                //List<OccupationCodeVM> vm = SessionHelper.occupationCodes;

                //if (!string.IsNullOrWhiteSpace(ipt))
                //{
                //    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                //}
                //dgv_zhiye.DataSource = vm;

                //dgv_zhiye.Columns["code"].HeaderText = "编号";
                //dgv_zhiye.Columns["name"].HeaderText = "名称";
                //dgv_zhiye.Columns["py_code"].Visible = false;
                //dgv_zhiye.Columns["d_code"].Visible = false;
                //dgv_zhiye.Columns["flag"].Visible = false;
                //dgv_zhiye.Columns["group_code"].Visible = false;
                //dgv_zhiye.Columns["tcmms_code"].Visible = false;

                //dgv_zhiye.AutoResizeColumns();

                //dgv_zhiye.CellClick += dgv_zhiye_CellContentClick;
                //dgv_zhiye.Show();
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
            //txtZhiye.TextChanged -= txtZhiye_TextChanged;
            //txtZhiye.Text = name;
            //txtZhiye.TagString = unit_sn;
            //txtZhiye.TextChanged += txtZhiye_TextChanged;

            dgv_zhiye.Hide();
        }

        private void txtZhiye_Leave(object sender, EventArgs e)
        {
            if (!dgv_zhiye.Focused)
            {
                dgv_zhiye.Hide();
            }
        }

        //private void Dgv_zhiye_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (dgv_zhiye.SelectedIndex != -1)
        //        {

        //            var ev = new DataGridViewCellEventArgs(0, dgv_zhiye.SelectedIndex);

        //            dgv_zhiye_CellContentClick(sender, ev);
        //        }
        //    }
        //}
        //private void txtZhiye_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        this.dgv_zhiye.Focus();
        //    }
        //    else if (e.KeyCode == Keys.Enter)
        //    {
        //        if (dgv_zhiye.Rows.Count > 0)
        //        {

        //            var unit_sn = dgv_zhiye.Rows[0].Cells["code"].Value.ToString();
        //            var name = dgv_zhiye.Rows[0].Cells["name"].Value.ToString();
        //            txtZhiye.TextChanged -= txtZhiye_TextChanged;
        //            txtZhiye.Text = name;
        //            txtZhiye.TagString = unit_sn;
        //            txtZhiye.TextChanged += txtZhiye_TextChanged;

        //            dgv_zhiye.Hide();
        //        }
        //    }

        //}
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

            

            dgv_district.KeyDown += Dgv_district_KeyDown;
           // dgv_zhiye.KeyDown += Dgv_zhiye_KeyDown;

            txtbirth.Text = DateTime.Now.ToShortDateString();
        }

        private void cbxhm_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
         

        private void btnSave_Click(object sender, EventArgs e)
        { 

            //if (text == "新病人" || text == "病人ID" || text == "磁卡号")
            //{
            //    EditUser();
            //}

        }

        public void EditUser()
        {
            //var cardId = txtbarcode.Text.Trim();
            //var sfzId = txtsno.Text.Trim();
            //var ybkId = txthicno.Text.Trim();
            //var patientId = this.txtId.Text;
            //var userName = this.txtname.Text;
            //var sex = this.cbxsex.Text == "男" ? "1" : "0";
            //var birth = this.txtbirth.Text;
            //var tel = this.txtTel.Text.Trim();


            ////验证卡号 
            //if (string.IsNullOrWhiteSpace(cardId))
            //{
            //    UIMessageTip.ShowError("卡号不能为空!");
            //    lblmsg.Text = "卡号不能为空";
            //    txtbarcode.Focus();
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(userName))
            //{
            //    UIMessageTip.ShowWarning("姓名不能为空!");
            //    lblmsg.Text = "姓名不能为空";
            //    txtname.Focus();
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(tel))
            //{
            //    UIMessageTip.ShowWarning("手机号码不能为空!");
            //    lblmsg.Text = "手机号码不能为空";
            //    txtTel.Focus();
            //    return;
            //}

            //if (!StringUtil.IsMobile(tel))
            //{
            //    UIMessageTip.ShowWarning("手机号码格式有误!");
            //    lblmsg.Text = "手机号码格式有误";
            //    txtTel.Focus();
            //    return;
            //}


            ////地区
            //var district = this.txthomedistrict.TagString;

            ////街道
            //var street = this.txthomestreet.Text;

            ////职业
            //var zhiye = this.txtZhiye.TagString;

            ////身份
            ////var response_type = this.txtShenfen.TagString;
            //var response_type = this.cbxShenfen.SelectedValue;

            ////费别
            //var charge_type = this.cbxFeibie.SelectedValue;

            //var sno = "";
            //var hicno = "";
            //var barcode = "";

            ////家长姓名
            //var relation_name = txtrelationname.Text;

            //var marrycode = 1;
            //switch (this.cbxmarrycode.Text)
            //{
            //    case "已婚":
            //        marrycode = 1; break;
            //    case "未婚":
            //        marrycode = 2; break;
            //    case "丧偶":
            //        marrycode = 3; break;
            //    case "离婚":
            //        marrycode = 4; break;
            //    case "其他":
            //        marrycode = 5; break;
            //    default:
            //        break;
            //}
            ////社保号
            //var addition_no1 = txtsbh.Text;
            ////工作单位 
            //var employer_name = txtemployer_name.Text;

            //if (!string.IsNullOrWhiteSpace(sfzId))
            //{
            //    //验证卡号是否是身份证号
            //    if (!StringUtil.CheckIDCard(sfzId))
            //    {
            //        UIMessageTip.ShowError("身份证号码不正确!");
            //        lblmsg.Text = "身份证号码不正确";
            //        txtsno.Focus();
            //        return;
            //    }
            //    sno = sfzId;
            //}
            //if (!string.IsNullOrWhiteSpace(ybkId))
            //{
            //    hicno = ybkId;
            //}
            //barcode = cardId;
            //try
            //{

            //    string json = ""; string paramurl = "";


            //    //根据patientId查找已存在的病人
            //    Task<HttpResponseMessage> task = null;
            //    json = "";
            //    paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={cardId}");
            //    task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            //    task.Wait();
            //    var response = task.Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var read = response.Content.ReadAsStringAsync();
            //        read.Wait();
            //        json = read.Result;
            //    }
            //    var result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);
            //    if (result.status == 1)
            //    {
            //        for (int i = 0; i < result.data.Count; i++)
            //        {
            //            var pid = result.data[i].patient_id;

            //            //else
            //            if (pid.Substring(3, 7) != patientId)
            //            {
            //                lblmsg.Text = "系统中已存在此卡号!";
            //                UIMessageTip.ShowError("系统中已存在此卡号!");
            //                txtbarcode.Focus();
            //                return;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        UIMessageBox.ShowError(result.message);
            //        log.Error(result.message);
            //        return;
            //    }



            //    json = "";
            //    paramurl = string.Format($"/api/GuaHao/GetPatientByCard?cardno={sno}");
            //    task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            //    task.Wait();
            //    response = task.Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var read = response.Content.ReadAsStringAsync();
            //        read.Wait();
            //        json = read.Result;
            //    }
            //    result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json);
            //    if (result.status == 1)
            //    {
            //        for (int i = 0; i < result.data.Count; i++)
            //        {
            //            var pid = result.data[i].patient_id;
            //            if (pid.Substring(3, 7) != patientId)
            //            {
            //                if (!UIMessageBox.ShowAsk("系统中已存在此身份证号,是否覆盖？"))
            //                {
            //                    txtsno.Focus();
            //                    return;
            //                }
            //                //清空相同身份证号信息
            //                DeleteSocialNo(sno);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        UIMessageBox.ShowError(result.message);
            //        log.Error(result.message);
            //        return;
            //    }
            //    var d = new
            //    {
            //        pid = patientId,
            //        sno = sno,
            //        hicno = hicno,
            //        barcode = barcode,
            //        name = userName,
            //        sex = sex,
            //        birth = birth,
            //        tel = tel,
            //        home_district = district,
            //        home_street = street,
            //        occupation_type = zhiye,
            //        response_type = response_type,
            //        charge_type = charge_type,
            //        relation_name = relation_name,
            //        marrycode = marrycode,
            //        addition_no1 = addition_no1,
            //        employer_name = employer_name,
            //        opera = SessionHelper.uservm.user_mi
            //    };
            //    var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
            //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    paramurl = string.Format($"/api/GuaHao/EditUserInfoPage?pid={d.pid}&sno={d.sno}&hicno={d.hicno}&barcode={d.barcode}&name={d.name}&sex={d.sex}&birthday={d.birth}&tel={d.tel}&home_district={d.home_district}&home_street={d.home_street}&occupation_type={d.occupation_type}&response_type={d.response_type}&charge_type={d.charge_type}&relation_name={d.relation_name}&marrycode={d.marrycode}&addition_no1={d.addition_no1}&employer_name={d.employer_name}&opera={d.opera}");

            //    string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
            //    var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);

            //    if (responseJson.status == 1 )
            //    {
            //        UIMessageTip.ShowOk("操作成功!");
            //        lblmsg.Text = "操作成功!";

            //    }
            //    else
            //    {
            //        lblmsg.Text = responseJson.message;
            //        log.Error(responseJson.message);
            //        UIMessageBox.ShowError(responseJson.message);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    log.Debug(ex.Message);
            //}

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
        

        

        public void BindUserInfo(PatientVM item)
        {


            this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
           // this.txtZhiye.TextChanged -= txtZhiye_TextChanged;

            //txtId.Text = item.patient_id.Substring(3, 7);
            //txtbarcode.Text = item.p_bar_code;
            txtsno.Text = item.social_no;
            txthicno.Text = item.hic_no;

            txt_sfz_name.Text = item.name;

            if (item.birthday.HasValue)
            {
                this.txtbirth.Text = item.birthday.Value.ToShortDateString();
            }
            //this.txtAge.Text = userInfo["age"].ToString();

            this.txtTel.Text = item.home_tel;

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
            txtsbh.Text = item.addition_no1;

            //工作单位
            //employer_name
            txtemployer_name.Text = item.employer_name;

            //合同单位contract_code


            this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
          //  this.txtZhiye.TextChanged += txtZhiye_TextChanged;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txthomedistrict.TextChanged -= txthomedistrict_TextChanged;
           // this.txtZhiye.TextChanged -= txtZhiye_TextChanged;

            //cbxhm.Text = "";
            //txtId.Text = "";
            //txtbarcode.Text = "";
            //txtname.Text = "";
            //cbxShenfen.SelectedValue = "";
            //cbxFeibie.SelectedValue = "";
            cbxsex.Text = "";
            txtbirth.Text = "";
            txtrelationname.Text = "";
            txtTel.Text = "";
            txtsno.Text = "";
            txthicno.Text = "";
            cbxmarrycode.Text = "";
            txtemployer_name.Text = "";
           // txtZhiye.Text = "";
            txtsbh.Text = "";
            txthomedistrict.Text = "";
            txthomestreet.Text = "";

            this.txthomedistrict.TextChanged += txthomedistrict_TextChanged;
            //this.txtZhiye.TextChanged += txtZhiye_TextChanged;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCika_Click(object sender, EventArgs e)
        {

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
                            lblmsg.Text = "没有查到用户数据"; 
                            return;
                        }
                        SessionHelper.patientVM = userInfo;


                        //当前最大记录次数
                        //current_times = userInfo.max_times;
                        //current_patient_id = userInfo.patient_id;

                        BindUserInfo(userInfo);
                         

                    }
                    else
                    {
                        MessageBox.Show("没有查到用户数据"); 
                    }

                }
                else
                {
                    MessageBox.Show("没有查到用户数据"); 
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
                log.Error("请求接口数据出错：" + ex.Message);
            }
        }

    }
}
