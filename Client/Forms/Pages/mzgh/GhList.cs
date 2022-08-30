using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.FastReportLib;
using Client.ViewModel;
using FastReport;
using log4net;
using Newtonsoft.Json;
using Sunny.UI;

namespace Client
{
    public partial class GhList : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(GhList));//typeof放当前类
        public GhList()
        {
            InitializeComponent();
        }
        List<UnitVM> units = null;
        List<ClinicTypeVM> clinicTypes = null;
        List<UserDicVM> userDics = null;
        private void GhList_Load(object sender, EventArgs e)
        {
            //初始化查询控件
            InitUI();

            //初始化字典数据
            InitDic();

            //查询列表
            //InitData();


            dgv.CellClick += dgvks_CellContentClick;
            dgv.KeyDown += dgvks_KeyDown;

            dgvzk.CellClick += dgvzk_CellContentClick;
            dgvzk.KeyDown += Dgvzk_KeyDown;

            dgvhb.CellClick += dgvhb_CellContentClick;
            dgvhb.KeyDown += Dgvhb_KeyDown;

            dgvhl.CellClick += dgvhl_CellContentClick;
            dgvhl.KeyDown += Dgvhl_KeyDown;

            dgvys.KeyDown += Dgvys_KeyDown;

            dgvghy.CellClick += dgvghy_CellContentClick;
            dgvghy.KeyDown += Dgvghy_KeyDown;

            this.Focus();

            //设置按钮提示文字信息
            uiToolTip1.SetToolTip(btnSearch, btnSearch.Text + "[F1]");
            uiToolTip1.SetToolTip(uiSymbolButton1, uiSymbolButton1.Text + "[F2]");
            uiToolTip1.SetToolTip(btnExit, btnExit.Text + "[F4]");
        }



        public void InitUI()
        {
            //设置日期
            this.txtRiqi.Value = DateTime.Now;

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
            cbxSXW.ValueMember = "code";
            cbxSXW.Text = "全部";

            //挂号状态 
            this.cbxStatus.Items.Clear();
            cbxStatus.Items.Add("全部");
            cbxStatus.Items.Add("已到院");
            cbxStatus.Items.Add("未到院");
            cbxStatus.Items.Add("退号");
            cbxStatus.Text = "全部";

            //加号
            this.cbxJiahao.Items.Clear();
            cbxJiahao.Items.Add("全部");
            cbxJiahao.Items.Add("加号");
            cbxJiahao.Items.Add("正常");
            cbxJiahao.Text = "全部";

        }

        public void InitDic()
        {
            log.Info("初始化数据字典：InitDic");

            units = SessionHelper.units;
            clinicTypes = SessionHelper.clinicTypes;
            userDics = SessionHelper.userDics;
        }

        public void InitData()
        {
            try
            {

                log.Info("InitData");

                decimal zje = 0;
                int zrc = 0;
                int ghrc = 0;
                int thrc = 0;
                  
                var gh_date = txtRiqi.Text;
                var ampm = "%";
                switch (cbxSXW.Text)
                {
                    case "上午": ampm = "a"; break;
                    case "下午": ampm = "p"; break;
                    case "中午": ampm = "m"; break;
                    case "夜间": ampm = "e"; break;
                    default:
                        break;
                }
                var visit_flag = "";
                switch (cbxStatus.Text)
                {
                    case "已到院": visit_flag = "1"; break;
                    case "未到院": visit_flag = "0"; break;
                    case "退号": visit_flag = "9"; break;
                    default:
                        break;
                }

                var visit_dept = string.IsNullOrWhiteSpace(txtks.Text) ? "%" : txtks.TagString;
                var clinic_type = string.IsNullOrWhiteSpace(txtHaobie.Text) ? "%" : txtHaobie.TagString;
                var doctor_code = string.IsNullOrWhiteSpace(txtDoct.Text) ? "%" : txtDoct.TagString;
                var group_sn = string.IsNullOrWhiteSpace(txtzk.Text) ? "%" : txtzk.TagString;
                var req_type = string.IsNullOrWhiteSpace(txtHaolei.Text) ? "%" : txtHaolei.TagString;
                var gh_opera = string.IsNullOrWhiteSpace(txtGhUser.Text) ? "%" : txtGhUser.TagString;
                var name = string.IsNullOrWhiteSpace(txtName.Text) ? "%" : txtName.Text.Trim();
                var p_bar_code = string.IsNullOrWhiteSpace(txtcode.Text) ? "%" : txtcode.Text.Trim();

                string paramurl = string.Format($"/api/GuaHao/GhSearchList?gh_date={gh_date}&visit_dept={visit_dept}&clinic_type={clinic_type}&doctor_code={doctor_code}&group_sn={group_sn}&req_type={req_type}&ampm={ampm}&gh_opera={gh_opera}&name={name}&p_bar_code={p_bar_code}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var json = HttpClientUtil.Get(paramurl);
                  
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhSearchVM>>>(json);
                if (result.status == 1)
                {
                    //筛选状态
                    if (visit_flag != "")
                    {
                        result.data = result.data.Where(p => p.visit_flag == visit_flag).ToList();
                    }
                    var list = result.data;

                    var source = list.Select(p => new
                    {
                        ampm = p.ampm,
                        charge_fee = p.charge_fee,
                        charge_name = p.charge_name,
                        clinic_name = p.clinic_name,
                        doctor_name = p.doctor_name,
                        flag = p.flag,
                        gh_date = p.gh_date,
                        gh_order = p.gh_order,
                        gh_sequence = p.gh_sequence,
                        gh_sequence_f = p.gh_sequence_f,
                        gh_time = p.gh_time,
                        group_name = p.group_name,
                        haoming_name = p.haoming_name,
                        opera_name = p.opera_name,
                        patient_id = p.patient_id,
                        patient_name = p.patient_name.Trim(),
                        p_bar_code = p.p_bar_code,
                        receipt_no = p.receipt_no,
                        receipt_sn = p.receipt_sn,
                        req_name = p.req_name,
                        response_name = p.response_name,
                        times = p.times,
                        ledger_sn = p.ledger_sn,
                        unit_name = p.unit_name,
                        visit_flag = p.visit_flag,
                        visit_status = p.visit_status,
                    }).ToList();
                    //dgvlist.Init();
                    dgvlist.DataSource = source;
                    dgvlist.AutoGenerateColumns = false;
                    dgvlist.AutoResizeColumns();
                    dgvlist.CellBorderStyle = DataGridViewCellBorderStyle.Single;

                    zje = list.Sum(p => p.charge_fee);
                    zrc = list.Count();
                    ghrc = list.Count(p => p.ledger_sn > 0);
                    thrc = list.Count(p => p.ledger_sn < 0);

                    SetBackground();

                }
                else
                {
                    UIMessageBox.ShowError(result.message);
                    log.Error(result.message);
                }

                lblTotalCount.ForeColor = Color.Red;

                lblTotalCount.Text = $"总金额：{zje}元， 总人次：{zrc}人次， 挂号人次：{ghrc}人次，  退号人次：{thrc}人次";
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());
            }
        }
        public void BindNullData()
        {
            List<GhSearchVM> list = new List<GhSearchVM>();
            var source = list.Select(p => new
            {
                ampm = p.ampm,
                charge_fee = p.charge_fee,
                charge_name = p.charge_name,
                clinic_name = p.clinic_name,
                doctor_name = p.doctor_name,
                flag = p.flag,
                gh_date = p.gh_date,
                gh_order = p.gh_order,
                gh_sequence = p.gh_sequence,
                gh_sequence_f = p.gh_sequence_f,
                gh_time = p.gh_time,
                group_name = p.group_name,
                haoming_name = p.haoming_name,
                opera_name = p.opera_name,
                patient_id = p.patient_id,
                patient_name = p.patient_name.Trim(),
                p_bar_code = p.p_bar_code,
                receipt_no = p.receipt_no,
                receipt_sn = p.receipt_sn,
                req_name = p.req_name,
                response_name = p.response_name,
                times = p.times,
                ledger_sn = p.ledger_sn,
                unit_name = p.unit_name,
                visit_flag = p.visit_flag,
                visit_status = p.visit_status,
            }).ToList();
            //dgvlist.Init();
            dgvlist.DataSource = source;
        }
        public void SetBackground()
        {
            foreach (DataGridViewRow dr in dgvlist.Rows)
            {
                if (dr.Cells["ledger_sn"].Value != null && Convert.ToInt32(dr.Cells["ledger_sn"].Value) < 0)
                {
                    // 设置单元格的背景色
                    //dr.DefaultCellStyle.BackColor = Color.Yellow;
                    // 设置单元格的前景色
                    dr.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
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
            try
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

                    dgv.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgvks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //查询列表
            InitData();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtzk_TextChanged(object sender, EventArgs e)
        {
            try
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

                    dgvzk.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void dgvzk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtHaobie_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtHaobie.Text == "")
                {
                    return;
                }
                //查询科室信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIPanel;
                //获取数据 

                if (units != null && units.Count > 0)
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

                    dgvhb.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgvhb_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                txtHaobie.TextChanged -= txtHaobie_TextChanged;
                txtHaobie.Text = name;
                txtHaobie.TagString = unit_sn;
                txtHaobie.TextChanged += txtHaobie_TextChanged;

                dgvhb.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtHaolei_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtHaolei.Text == "")
                {
                    return;
                }
                //查询信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIPanel;
                //获取数据 

                if (units != null && units.Count > 0)
                {
                    var ipt = txtHaolei.Text.Trim();

                    dgvhl.Parent = this;
                    dgvhl.Top = pbl.Top + tb.Top + tb.Height;
                    dgvhl.Left = pbl.Left + tb.Left;
                    dgvhl.Width = tb.Width;
                    dgvhl.Height = 200;
                    dgvhl.BringToFront();
                    dgvhl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvhl.RowHeadersVisible = false;
                    dgvhl.BackgroundColor = Color.White;
                    dgvhl.ReadOnly = true;


                    List<RequestTypeVM> vm = SessionHelper.requestTypes;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgvhl.DataSource = vm;

                    dgvhl.Columns["code"].HeaderText = "编号";
                    dgvhl.Columns["name"].HeaderText = "名称";
                    dgvhl.Columns["py_code"].Visible = false;
                    dgvhl.Columns["d_code"].Visible = false;
                    dgvhl.AutoResizeColumns();

                    dgvhl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void dgvhl_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                txtHaolei.TextChanged -= txtHaolei_TextChanged;
                txtHaolei.Text = name;
                txtHaolei.TagString = unit_sn;
                txtHaolei.TextChanged += txtHaolei_TextChanged;

                dgvhl.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            txtks.TextChanged -= txtks_TextChanged;
            txtzk.TextChanged -= txtzk_TextChanged;

            //设置日期
            this.txtRiqi.Value = DateTime.Now;
            txtks.Text = "";
            txtHaobie.Text = "";
            txtzk.Text = "";
            txtHaolei.Text = "";
            txtName.Text = "";
            txtcode.Text = "";
            txtDoct.Text = "";
            txtGhUser.Text = "";

            cbxSXW.Text = "全部";

            cbxStatus.Text = "全部";

            txtks.TextChanged += txtks_TextChanged;
            txtzk.TextChanged += txtzk_TextChanged;

            //查询列表
            //InitData();
            BindNullData();
        }

        private void txtDoct_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtDoct.Text == "")
                {
                    return;
                }

                //查询信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIPanel;
                //获取数据 

                if (units != null && units.Count > 0)
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

                    dgvys.CellClick -= dgvys_CellContentClick;
                    dgvys.CellClick += dgvys_CellContentClick;
                    dgvys.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void dgvys_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                txtDoct.TextChanged -= txtDoct_TextChanged;
                txtDoct.Text = name;
                txtDoct.TagString = unit_sn;
                txtDoct.TextChanged += txtDoct_TextChanged;

                dgvys.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtGhUser_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtGhUser.Text == "")
                {
                    return;
                }

                // 查询信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIPanel;
                //获取数据 

                if (units != null && units.Count > 0)
                {
                    var ipt = txtGhUser.Text.Trim();

                    dgvghy.Parent = this;
                    dgvghy.Top = pbl.Top + tb.Top + tb.Height;
                    dgvghy.Left = pbl.Left + tb.Left;
                    dgvghy.Width = tb.Width;
                    dgvghy.Height = 200;
                    dgvghy.BringToFront();
                    dgvghy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvghy.RowHeadersVisible = false;
                    dgvghy.BackgroundColor = Color.White;
                    dgvghy.ReadOnly = true;


                    List<UserDicVM> vm = userDics;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgvghy.DataSource = vm;

                    dgvghy.Columns["code"].HeaderText = "编号";
                    dgvghy.Columns["name"].HeaderText = "名称";
                    dgvghy.Columns["py_code"].Visible = false;
                    dgvghy.Columns["d_code"].Visible = false;
                    dgvghy.Columns["emp_sn"].Visible = false;
                    dgvghy.AutoResizeColumns();

                    dgvghy.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void dgvghy_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                txtGhUser.TextChanged -= txtGhUser_TextChanged;
                txtGhUser.Text = name;
                txtGhUser.TagString = unit_sn;
                txtGhUser.TextChanged += txtGhUser_TextChanged;

                dgvghy.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
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



        private void txtks_KeyUp(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
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

        private void txtHaolei_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.dgvhl.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgvhl.Rows.Count > 0)
                    {

                        var code = dgvhl.Rows[0].Cells["code"].Value.ToString();
                        var name = dgvhl.Rows[0].Cells["name"].Value.ToString();


                        txtHaolei.TextChanged -= txtHaolei_TextChanged;
                        txtHaolei.Text = name;
                        txtHaolei.TagString = code;
                        txtHaolei.TextChanged += txtHaolei_TextChanged;

                        dgvhl.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void Dgvhl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvhl.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvhl.SelectedIndex);

                    dgvhl_CellContentClick(sender, ev);
                }
            }
        }
         
        /// <summary>
        /// fastreport打印
        /// </summary>
        /// <returns></returns>
        public Report CreateReportAndLoadFrx()
        {
            Report report = new Report();

            report.Load(Application.StartupPath + @"\FastReport\file\ghlist.frx");//这里是模板的路径 

            report.SetParameterValue("gh_date", this.txtRiqi.Text);

            return report;
        }

       
        private void txtDoct_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtGhUser_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.dgvghy.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgvghy.Rows.Count > 0)
                    {

                        var unit_sn = dgvghy.Rows[0].Cells["code"].Value.ToString();
                        var name = dgvghy.Rows[0].Cells["name"].Value.ToString();

                        txtGhUser.TextChanged -= txtGhUser_TextChanged;
                        txtGhUser.Text = name;
                        txtGhUser.TagString = unit_sn;
                        txtGhUser.TextChanged += txtGhUser_TextChanged;

                        dgvghy.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void Dgvghy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvghy.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvghy.SelectedIndex);

                    dgvghy_CellContentClick(sender, ev);
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

        private void GhList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    InitData(); //查询
                    break;
                case Keys.F2:
                    Reset();//重新
                    break;
                case Keys.F3:

                    break;
                case Keys.F4:
                    this.Close();//退出
                    break;
            }
        }

        private void GhList_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                this.Focus();
            }

        }

        private void dgvlist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }
        /// <summary>
        /// 打印电子发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            //补打电子发票
            try
            {

                //获取选择参数
                var _patientId = dgvlist.Rows[dgvlist.SelectedIndex].Cells["patient_id"].Value;
                if (_patientId == null)
                {
                    UIMessageTip.Show("没有数据！");
                    return;
                }
                var _ledger_sn = dgvlist.Rows[dgvlist.SelectedIndex].Cells["ledger_sn"].Value;
                var _subsys_id = "mz";

                //查询电子发票记录表  <List<FpData>> GetFpDatasByParams(string patient_id, int ledger_sn, string subsys_id)
                string paramurl = string.Format($"/api/mzsf/GetFpDatasByParams?patient_id={_patientId.ToString()}&ledger_sn={_ledger_sn.ToString()}&subsys_id={_subsys_id}");

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<FpData>>>(json);

                if (result.status != 1)
                {
                    UIMessageTip.Show(result.message);

                    log.Error(result.message);

                    return;

                }
                if (result.data == null || result.data.Count == 0)
                {
                    UIMessageTip.Show("没有电子发票数据！");

                    log.Error("没有电子发票数据！");

                    return;
                }

                string _billBatchCode = result.data[0].billBatchCode;
                string _billNo = result.data[0].billNo;
                string _random = result.data[0].random;

                string ip = ConfigurationManager.AppSettings["ip"];
                string port = ConfigurationManager.AppSettings["port"];
                string dllName = ConfigurationManager.AppSettings["dllName"];
                string func = ConfigurationManager.AppSettings["func"];

                string noise = Guid.NewGuid().ToString();

                string appid = ConfigurationManager.AppSettings["appid"];
                string key = ConfigurationManager.AppSettings["key"];
                string version = ConfigurationManager.AppSettings["version"];

                string method = "printElectBill";

                var _data = new
                {
                    billBatchCode = _billBatchCode,
                    billNo = _billNo,
                    random = _random,
                };

                var stringA = $"appid={appid}&data={StringUtil.Base64Encode(JsonConvert.SerializeObject(_data))}&noise={noise}";
                var stringSignTemp = stringA + $"&key={key}&version={version}";

                var _sign = StringUtil.GenerateMD5(stringSignTemp).ToUpper();

                var _params = new
                {
                    appid = appid,
                    data = StringUtil.Base64Encode(JsonConvert.SerializeObject(_data)),
                    noise = noise,
                    version = version,
                    sign = _sign
                };

                var _payload = new
                {
                    method = method,
                    @params = _params
                };
                string payload = StringUtil.Base64Encode(JsonConvert.SerializeObject(_payload)); 
                string url = $"http://{ip}:{port}/extend?dllName={dllName}&func={func}&payload={payload}";
                //var reslt = HttpClientUtil.Get(url);
                Task.Run(() =>
                {
                    HttpClientUtil.Get(url);
                });
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error("打印电子发票失败！");
                log.Error(ex.Message);
            }
        }
    }
}
