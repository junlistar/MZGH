using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

namespace Client
{
    public partial class BaseWeiHu : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(BaseWeiHu));//typeof放当前类
         
        List<BaseRequestVM> list = null;

        public List<UnitVM> units = null;
        public List<ClinicTypeVM> clinicTypes = null;
        public List<UserDicVM> userDics = null;
        public List<RequestTypeVM> requestTyeps = null;

        public BaseWeiHu()
        {
            InitializeComponent();
        }
        private void BaseRequest_Load(object sender, EventArgs e)
        { 

            InitDic();

            //InitData();

            //设置按钮提示文字信息
            uiToolTip1.SetToolTip(btnSearch, btnSearch.Text + "[F1]");
            uiToolTip1.SetToolTip(btnReset, btnReset.Text + "[F2]");
            uiToolTip1.SetToolTip(btnAdd, btnAdd.Text + "[F3]");
            uiToolTip1.SetToolTip(btnExit, btnExit.Text + "[F4]");
        }

        public void InitDic()
        {
            log.Info("初始化数据字典：InitDic");

            units = SessionHelper.units;
            clinicTypes = SessionHelper.clinicTypes;
            userDics = SessionHelper.userDics;
            requestTyeps = SessionHelper.requestTypes;

            cbxRequestType.DataSource = requestTyeps;
            cbxRequestType.DisplayMember = "name";
            cbxRequestType.ValueMember = "code";

            txtDate.Value = DateTime.Now;

            //设置上午下午 
            this.cbxSXW.Items.Clear(); 

            var rh_list = new List<RequestHourVM>();
            foreach (var item in SessionHelper.requestHours.ToArray())
            {
                rh_list.Add(item);
            }
            var rh = new RequestHourVM();
            rh.code = "%";
            rh.name = "全部";
            rh_list.Insert(0, rh);
            cbxSXW.DataSource = rh_list;
            cbxSXW.DisplayMember = "name";
            cbxSXW.ValueMember = "code"; cbxSXW.Text = "全部";


            dgv.CellClick += dgvks_CellContentClick;
            dgv.KeyDown += dgvks_KeyDown;

            dgvzk.CellClick += dgvzk_CellContentClick;
            dgvzk.KeyDown += Dgvzk_KeyDown;

            dgvhb.CellClick += dgvhb_CellContentClick;
            dgvhb.KeyDown += Dgvhb_KeyDown;

            dgvys.CellClick += dgvys_CellContentClick;
            dgvys.KeyDown += Dgvys_KeyDown;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { 
            InitData();
        }



        public void InitData()
        {
            log.Info("InitData");

            Task<HttpResponseMessage> task = null;
            string json = "";

            #region 参数处理
             
            //var gh_date = txtRiqi.Text;
            var visit_dept = string.IsNullOrWhiteSpace(txtks.Text) ? "%" : txtks.TagString;
            var clinic_type = string.IsNullOrWhiteSpace(txtHaobie.Text) ? "%" : txtHaobie.TagString;
            var doctor_code = string.IsNullOrWhiteSpace(txtDoct.Text) ? "%" : txtDoct.TagString;
            var group_sn = string.IsNullOrWhiteSpace(txtzk.Text) ? "%" : txtzk.TagString;
            var req_type = cbxRequestType.SelectedValue;
            //var gh_opera = string.IsNullOrWhiteSpace(txtGhUser.Text) ? "%" : txtGhUser.TagString;
            //var name = string.IsNullOrWhiteSpace(txtName.Text) ? "%" : txtName.Text.Trim();
            //var p_bar_code = string.IsNullOrWhiteSpace(txtcode.Text) ? "%" : txtcode.Text.Trim();

            var ampm = "%"; //cbxSXW.Text == "上午" ? "a" : "p";
            var week = "%";
            var day = "%";
            var window_no = "%";
            var open_flag = "%";

            if (cbxSXW.Text != "全部")
            {
                ampm = cbxSXW.SelectedValue.ToString();
            }
 
             
            if (cbxOpenFlag.Text == "开放")
            {
                open_flag = "1";
            }
            else if (cbxOpenFlag.Text == "不开放")
            {
                open_flag = "0";
            }

            #endregion
             
            var begin = txtDate.Value.ToShortDateString();

            var para = $"?begin={begin}&end={begin}&unit_sn={visit_dept}&group_sn={group_sn}&doctor_sn={doctor_code}&clinic_type={clinic_type}&req_type={req_type}&ampm={ampm}&window_no={window_no}&open_flag={open_flag}";

            string paramurl = string.Format($"/api/GuaHao/GetRequestsByParams" + para);

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
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
                else
                {
                    log.Error(response.ReasonPhrase);
                }

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json);
                if (result.status==1 && result.data!=null)
                {  
                    var ds = result.data.Select(p => new
                    {
                        record_sn = p.record_sn,
                        request_date = p.request_date,
                        open_flag_str = p.open_flag_str,
                        apstr = p.apstr,
                        unit_name = p.unit_name,
                        clinic_name = p.clinic_name,
                        req_name = p.req_name,
                        group_name = p.group_name,
                        doct_name = p.doct_name,
                        //weekstr = p.weekstr,
                        //daystr = p.daystr,
                        winnostr = p.winnostr,
                        begin_no = p.begin_no,
                        current_no = p.current_no,
                        end_no = p.end_no,

                        //op_date_str = p.op_date_str
                    }).OrderBy(p => p.apstr).OrderBy(p => p.unit_name).OrderBy(p => p.group_name).OrderBy(p => p.clinic_name).OrderBy(p => p.doct_name).ToList();

                    dgvlist.Init();
                    dgvlist.DataSource = ds;
                    dgvlist.AutoResizeColumns();

                    dgvlist.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                }
                else
                {
                    UIMessageTip.ShowError("查询失败!");
                    log.Error(result.message);
                    BindNullData();
                }

            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.ToString());
            }



        }

        public void BindNullData()
        {
            var tmp = new List<BaseRequestVM>();
            var ds = tmp.Select(p => new
            {
                record_sn = p.record_sn,
                request_date = p.request_date,
                open_flag_str = p.open_flag_str,
                apstr = p.apstr,
                unit_name = p.unit_name,
                clinic_name = p.clinic_name,
                req_name = p.req_name,
                group_name = p.group_name,
                doct_name = p.doct_name,
                winnostr = p.winnostr,
                begin_no = p.begin_no,
                current_no = p.current_no,
                end_no = p.end_no,
            }).ToList();
            dgvlist.DataSource = ds;
        }

        UIDataGridView dgv = new UIDataGridView();
        UIDataGridView dgvzk = new UIDataGridView();
        UIDataGridView dgvhb = new UIDataGridView();
        UIDataGridView dgvhl = new UIDataGridView();
        UIDataGridView dgvys = new UIDataGridView();
        UIDataGridView dgvghy = new UIDataGridView();
        /// <summary>
        /// 输入自动提示处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtks_TextChanged(object sender, EventArgs e)
        {
            //查询科室信息 显示到girdview
            var tb = sender as UITextBox;
            var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (units != null && units.Count > 0)
            {
                var ipt = txtks.Text.Trim();

                dgv.Parent = this;
                dgv.Top = pbl.Top + tb.Top + tb.Height;
                dgv.Left = pbl.Left + tb.Left;
                dgv.Width = tb.Width;
                dgv.Height = 200;
                dgv.BringToFront();
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.BackgroundColor = Color.White;
                dgv.ReadOnly = true;


                List<UnitVM> vm = units;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                }
                dgv.DataSource = vm;

                dgv.Columns["code"].HeaderText = "编号";
                dgv.Columns["name"].HeaderText = "名称";
                dgv.Columns["py_code"].Visible = false;
                dgv.Columns["d_code"].Visible = false;
                dgv.Columns["unit_sn"].Visible = false;
                dgv.AutoResizeColumns();

                dgv.CellClick += dgvks_CellContentClick;
                dgv.Show();
            }

        }

        private void dgvks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            var obj = sender as UIDataGridView;
            var unit_sn = obj.Rows[e.RowIndex].Cells["unit_sn"].Value.ToString();
            var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtks.TextChanged -= txtks_TextChanged;
            txtks.Text = name;
            txtks.TagString = unit_sn;
            txtks.TextChanged += txtks_TextChanged;

            dgv.Hide();
        }

        private void txtzk_TextChanged(object sender, EventArgs e)
        {
            //查询科室信息 显示到girdview
            var tb = sender as UITextBox;
            var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (units != null && units.Count > 0)
            {
                var ipt = txtzk.Text.Trim();

                dgvzk.Parent = this;
                dgvzk.Top = pbl.Top + tb.Top + tb.Height;
                dgvzk.Left = pbl.Left + tb.Left;
                dgvzk.Width = tb.Width;
                dgvzk.Height = 200;
                dgvzk.BringToFront();
                dgvzk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvzk.RowHeadersVisible = false;
                dgvzk.BackgroundColor = Color.White;
                dgvzk.ReadOnly = true;


                List<UnitVM> vm = units;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                }
                dgvzk.DataSource = vm;

                dgvzk.Columns["code"].HeaderText = "编号";
                dgvzk.Columns["name"].HeaderText = "名称";
                dgvzk.Columns["py_code"].Visible = false;
                dgvzk.Columns["d_code"].Visible = false;
                dgvzk.Columns["unit_sn"].Visible = false;
                dgvzk.AutoResizeColumns();

                dgvzk.CellClick += dgvzk_CellContentClick;
                dgvzk.Show();
            }
        }
        private void dgvzk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            var obj = sender as UIDataGridView;
            var unit_sn = obj.Rows[e.RowIndex].Cells["unit_sn"].Value.ToString();
            var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtzk.TextChanged -= txtzk_TextChanged;
            txtzk.Text = name;
            txtzk.TagString = unit_sn;
            txtzk.TextChanged += txtzk_TextChanged;

            dgvzk.Hide();
        }

        private void txtDoct_TextChanged(object sender, EventArgs e)
        {
            //查询信息 显示到girdview
            var tb = sender as UITextBox;
            var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (userDics != null && userDics.Count > 0)
            {
                var ipt = txtDoct.Text.Trim();

                dgvys.Parent = this;
                dgvys.Top = pbl.Top + tb.Top + tb.Height;
                dgvys.Left = pbl.Left + tb.Left;
                dgvys.Width = tb.Width;
                dgvys.Height = 200;
                dgvys.BringToFront();
                dgvys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvys.RowHeadersVisible = false;
                dgvys.BackgroundColor = Color.White;
                dgvys.ReadOnly = true;


                List<UserDicVM> vm = userDics;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                }
                dgvys.DataSource = vm;

                dgvys.Columns["code"].HeaderText = "编号";
                dgvys.Columns["name"].HeaderText = "名称";
                dgvys.Columns["py_code"].Visible = false;
                dgvys.Columns["d_code"].Visible = false;
                dgvys.Columns["emp_sn"].Visible = false;
                dgvys.AutoResizeColumns();

                dgvys.CellClick += dgvys_CellContentClick;
                dgvys.Show();
            }
        }
        private void dgvys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            var obj = sender as UIDataGridView;
            var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
            var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtDoct.TextChanged -= txtDoct_TextChanged;
            txtDoct.Text = name;
            txtDoct.TagString = unit_sn;
            txtDoct.TextChanged += txtDoct_TextChanged;

            dgvys.Hide();
        }

        private void txtHaobie_TextChanged(object sender, EventArgs e)
        {
            //查询科室信息 显示到girdview
            var tb = sender as UITextBox;
            var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (clinicTypes != null && clinicTypes.Count > 0)
            {
                var ipt = txtHaobie.Text.Trim();

                dgvhb.Parent = this;
                dgvhb.Top = pbl.Top + tb.Top + tb.Height;
                dgvhb.Left = pbl.Left + tb.Left;
                dgvhb.Width = tb.Width;
                dgvhb.Height = 200;
                dgvhb.BringToFront();
                dgvhb.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvhb.RowHeadersVisible = false;
                dgvhb.BackgroundColor = Color.White;
                dgvhb.ReadOnly = true;


                List<ClinicTypeVM> vm = clinicTypes;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                }
                dgvhb.DataSource = vm;

                dgvhb.Columns["code"].HeaderText = "编号";
                dgvhb.Columns["name"].HeaderText = "名称";
                dgvhb.Columns["py_code"].Visible = false;
                dgvhb.Columns["d_code"].Visible = false;
                dgvhb.AutoResizeColumns();

                dgvhb.CellClick += dgvhb_CellContentClick;
                dgvhb.Show();
            }
        }

        private void dgvhb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            var obj = sender as UIDataGridView;
            var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
            var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtHaobie.TextChanged -= txtHaobie_TextChanged;
            txtHaobie.Text = name;
            txtHaobie.TagString = unit_sn;
            txtHaobie.TextChanged += txtHaobie_TextChanged;

            dgvhb.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            txtks.TextChanged -= txtks_TextChanged;
            txtzk.TextChanged -= txtzk_TextChanged;
            txtDoct.TextChanged -= txtDoct_TextChanged;
            txtHaobie.TextChanged -= txtHaobie_TextChanged;

            //重新初始化查询控件
            txtks.Text = "";
            txtzk.Text = "";
            txtDoct.Text = "";
            txtHaobie.Text = "";
            cbxSXW.Text = "";
            cbxWinNo.Text = "";
            //cbxWeek.Text = "";
            //cbxDay.Text = "";
            cbxOpenFlag.Text = "";

            txtks.TextChanged += txtks_TextChanged;
            txtzk.TextChanged += txtzk_TextChanged;
            txtDoct.TextChanged += txtDoct_TextChanged;
            txtHaobie.TextChanged += txtHaobie_TextChanged;

            //InitData();
            BindNullData();

        }

        private void txtDoct_Leave(object sender, EventArgs e)
        {
            if (!dgvys.Focused)
            {
                dgvys.Hide();
            }
        }

        private void txtGhUser_Leave(object sender, EventArgs e)
        {
            if (!dgvghy.Focused)
            {
                dgvghy.Hide();
            }
        }

        private void txtHaobie_Leave(object sender, EventArgs e)
        {
            if (!dgvhb.Focused)
            {
                dgvhb.Hide();
            }
        }

        private void txtHaolei_Leave(object sender, EventArgs e)
        {
            if (!dgvhl.Focused)
            {
                dgvhl.Hide();
            }
        }

        private void txtks_Leave(object sender, EventArgs e)
        {
            if (!dgv.Focused)
            {
                dgv.Hide();
            }
        }

        private void txtzk_Leave(object sender, EventArgs e)
        {
            if (!dgvzk.Focused)
            {
                dgvzk.Hide();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Edit();

        }

        public void Edit()
        {
            try
            {  
                if (dgvlist.Rows.Count > 0 && dgvlist.SelectedIndex >= 0)
                {
                    var record_sn = dgvlist.Rows[dgvlist.SelectedIndex].Cells["record_sn"].Value;

                    RequestEdit edit = new RequestEdit(record_sn.ToString());
                    edit.ShowDialog();
                    InitData();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = dgvlist.SelectedIndex;

            if (index >= 0)
            {

                try
                {

                    var request_sn = dgvlist.Rows[index].Cells["request_sn"].Value.ToString();


                    var d = new
                    {
                        request_sn = request_sn,
                    };
                    var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var paramurl = string.Format($"/api/GuaHao/DeleteBaseRequest?request_sn={d.request_sn}");

                    string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                    var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);

                    if (result.status == 1)
                    {
                        UIMessageTip.ShowOk("操作成功!");
                        return;
                    }
                    else
                    {
                        UIMessageTip.ShowError("查询失败!");
                        log.Error(result.message); 
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    log.Error(ex.StackTrace);
                }
            }
        }
        private void txtks_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Down)
            {
                this.dgv.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgv.Rows.Count > 0)
                {

                    var unit_sn = dgv.Rows[0].Cells["unit_sn"].Value.ToString();
                    var name = dgv.Rows[0].Cells["name"].Value.ToString();

                    txtks.TextChanged -= txtks_TextChanged;
                    txtks.Text = name;
                    txtks.TagString = unit_sn;
                    txtks.TextChanged += txtks_TextChanged;

                    dgv.Hide();
                }
            }
        }

        private void dgvks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgv.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgv.SelectedIndex);

                    dgvks_CellContentClick(sender, ev);
                }
            }

        }

        private void txtzk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.dgvzk.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgvzk.Rows.Count > 0)
                {

                    var unit_sn = dgvzk.Rows[0].Cells["unit_sn"].Value.ToString();
                    var name = dgvzk.Rows[0].Cells["name"].Value.ToString();

                    txtzk.TextChanged -= txtzk_TextChanged;
                    txtzk.Text = name;
                    txtzk.TagString = unit_sn;
                    txtzk.TextChanged += txtzk_TextChanged;

                    dgvzk.Hide();
                }
            }
        }



        private void Dgvzk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvzk.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvzk.SelectedIndex);

                    dgvzk_CellContentClick(sender, ev);
                }
            }
        }

        private void txtHaobie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.dgvhb.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgvhb.Rows.Count > 0)
                {

                    var code = dgvhb.Rows[0].Cells["code"].Value.ToString();
                    var name = dgvhb.Rows[0].Cells["name"].Value.ToString();

                    txtHaobie.TextChanged -= txtHaobie_TextChanged;
                    txtHaobie.Text = name;
                    txtHaobie.TagString = code;
                    txtHaobie.TextChanged += txtHaobie_TextChanged;


                    dgvhb.Hide();
                }
            }
        }

        private void Dgvhb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvhb.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvhb.SelectedIndex);

                    dgvhb_CellContentClick(sender, ev);
                }
            }
        }

        private void txtDoct_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Down)
            {
                this.dgvys.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgvys.Rows.Count > 0)
                {

                    var unit_sn = dgvys.Rows[0].Cells["code"].Value.ToString();
                    var name = dgvys.Rows[0].Cells["name"].Value.ToString();

                    txtDoct.TextChanged -= txtDoct_TextChanged;
                    txtDoct.Text = name;
                    txtDoct.TagString = unit_sn;
                    txtDoct.TextChanged += txtDoct_TextChanged;

                    dgvys.Hide();
                }
            }
        }
        private void Dgvys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvys.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvys.SelectedIndex);

                    dgvys_CellContentClick(sender, ev);
                }
            }
        }

        private void BaseWeiHu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F1:
                    InitData();
                    break;

                case Keys.F2:
                    Reset();
                    break;
                case Keys.F3:
                    Edit();
                    break;
                case Keys.F4:
                    this.Close();//退出
                    break;
            }
        }

        private void BaseWeiHu_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                this.Focus();
            }
        }
    }
}
