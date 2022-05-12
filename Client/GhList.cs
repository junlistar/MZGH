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

            dgvzk.KeyDown += Dgvzk_KeyDown;
            dgvhb.KeyDown += Dgvhb_KeyDown;
            dgvhl.KeyDown += Dgvhl_KeyDown;
        }

        public void InitUI()
        {
            //设置日期
            this.txtRiqi.Value = DateTime.Now;

            //设置上午下午
            this.cbxSXW.Items.Clear();
            cbxSXW.Items.Add("上午");
            cbxSXW.Items.Add("下午");
            cbxSXW.Text = DateTime.Now.Hour > 12 ? "下午" : "上午";

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
            log.Info("InitData");

            Task<HttpResponseMessage> task = null;
            string json = "";
            //string paramurl = string.Format($"/api/GuaHao/GhSearchList?gh_date={gh_date}&visit_dept={visit_dept}&clinic_type={clinic_type}&doctor_code={doctor_code}&group_sn={group_sn}&req_type={req_type}&ampm={ampm}&gh_opera={gh_opera}&name={name}&p_bar_code={p_bar_code}");
            //group_sn={group_sn}&req_type={req_type}&ampm={ampm}&gh_opera={gh_opera}&name={name}&p_bar_code={p_bar_code}
            var gh_date = txtRiqi.Text;
            var ampm = cbxSXW.Text == "上午" ? "a" : "p";
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
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());
            }

            var list = WebApiHelper.DeserializeObject<ResponseResult<List<GhSearchVM>>>(json).data;

            dgvlist.DataSource = list;
            dgvlist.AutoResizeColumns();


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

        private void txtHaobie_TextChanged(object sender, EventArgs e)
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

        private void txtHaolei_TextChanged(object sender, EventArgs e)
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

                dgvhl.CellClick += dgvhl_CellContentClick;
                dgvhl.Show();
            }
        }
        private void dgvhl_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            txtks.Text = "";
            txtHaobie.Text = "";
            txtzk.Text = "";
            txtHaolei.Text = "";
            txtName.Text = "";
            txtcode.Text = "";
            txtDoct.Text = "";
            txtGhUser.Text = "";
        }

        private void txtDoct_TextChanged(object sender, EventArgs e)
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

        private void txtGhUser_TextChanged(object sender, EventArgs e)
        {
            if (txtGhUser.Text=="")
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

                dgvghy.CellClick += dgvghy_CellContentClick;
                dgvghy.Show();
            }
        }
        private void dgvghy_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtHaolei_KeyUp(object sender, KeyEventArgs e)
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
    }
}
