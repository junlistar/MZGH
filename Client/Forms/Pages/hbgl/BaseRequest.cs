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
    public partial class BaseRequest : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(BaseRequest));//typeof放当前类

        List<BaseRequestVM> list = new List<BaseRequestVM>();

        public List<UnitVM> units = null;
        public List<ClinicTypeVM> clinicTypes = null;
        public List<UserDicVM> userDics = null;

        public string current_sn = "";
        string order_asc = "asc";

        public BaseRequest()
        {
            InitializeComponent();
        }
        private void BaseRequest_Load(object sender, EventArgs e)
        {
            StyleHelper.SetGridColor(dgvlist);//设置样式

            InitDic();

            InitData();

            dgv.CellClick += dgvks_CellContentClick;
            dgv.KeyDown += dgvks_KeyDown;

            dgvzk.CellClick += dgvzk_CellContentClick;
            dgvzk.KeyDown += Dgvzk_KeyDown;

            dgvhb.CellClick += dgvhb_CellContentClick;
            dgvhb.KeyDown += Dgvhb_KeyDown;

            dgvys.CellClick += dgvys_CellContentClick;
            dgvys.KeyDown += Dgvys_KeyDown;


            //设置按钮提示文字信息
            uiToolTip1.SetToolTip(btnSearch, btnSearch.Text + "[F1]");
            uiToolTip1.SetToolTip(btnReset, btnReset.Text + "[F2]");
            uiToolTip1.SetToolTip(btnAdd, btnAdd.Text + "[F5]");
            uiToolTip1.SetToolTip(btnEdit, btnEdit.Text + "[F6]");
            uiToolTip1.SetToolTip(btnDelete, btnDelete.Text + "[F7]");
            uiToolTip1.SetToolTip(btnExit, btnExit.Text + "[F4]");

            BindBottomData(); 

             
            dgvhl.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
            dgvghy.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
        }

        public void InitDic()
        {
            log.Info("初始化数据字典：InitDic");

            units = SessionHelper.units;
            clinicTypes = SessionHelper.clinicTypes;
            userDics = SessionHelper.userDics;

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


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitData();
        } 
        public void InitData()
        {
            log.Info("InitData");

            string json = "";

            #region 参数处理

            //string paramurl = string.Format($"/api/GuaHao/GhSearchList?gh_date={gh_date}&visit_dept={visit_dept}&clinic_type={clinic_type}&doctor_code={doctor_code}&group_sn={group_sn}&req_type={req_type}&ampm={ampm}&gh_opera={gh_opera}&name={name}&p_bar_code={p_bar_code}");
            //group_sn={group_sn}&req_type={req_type}&ampm={ampm}&gh_opera={gh_opera}&name={name}&p_bar_code={p_bar_code}
            //var gh_date = txtRiqi.Text;
            var visit_dept = string.IsNullOrWhiteSpace(txtks.Text) ? "%" : txtks.TagString;
            var clinic_type = string.IsNullOrWhiteSpace(txtHaobie.Text) ? "%" : txtHaobie.TagString;
            var doctor_code = string.IsNullOrWhiteSpace(txtDoct.Text) ? "%" : txtDoct.TagString;
            var group_sn = string.IsNullOrWhiteSpace(txtzk.Text) ? "%" : txtzk.TagString;
            //var req_type = string.IsNullOrWhiteSpace(txtHaolei.Text) ? "%" : txtHaolei.TagString;
            //var gh_opera = string.IsNullOrWhiteSpace(txtGhUser.Text) ? "%" : txtGhUser.TagString;
            //var name = string.IsNullOrWhiteSpace(txtName.Text) ? "%" : txtName.Text.Trim();
            //var p_bar_code = string.IsNullOrWhiteSpace(txtcode.Text) ? "%" : txtcode.Text.Trim();

            var ampm = "%"; //cbxSXW.Text == "上午" ? "a" : "p";
            var week = "%";
            var day = "%";
            var window_no = "%";
            window_no = txt_workroom.Text.Trim();
            var open_flag = "%";

            if (cbxSXW.Text != "全部")
            {
                ampm = cbxSXW.SelectedValue.ToString();
            }  


            switch (cbxWeek.Text)
            {
                case "第一周": week = "1"; break;
                case "第二周": week = "2"; break;
                case "第三周": week = "3"; break;
                case "第四周": week = "4"; break;
                default:
                    break;
            }

            switch (cbxDay.Text)
            {
                case "星期一": day = "1"; break;
                case "星期二": day = "2"; break;
                case "星期三": day = "3"; break;
                case "星期四": day = "4"; break;
                case "星期五": day = "5"; break;
                case "星期六": day = "6"; break;
                case "星期日": day = "7"; break;
                default:
                    break;
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


            var para = $"?unit_sn={visit_dept}&group_sn={group_sn}&doctor_sn={doctor_code}&clinic_type={clinic_type}&week={week}&day={day}&ampm={ampm}&window_no={window_no}&open_flag={open_flag}";

            string paramurl = string.Format($"/api/GuaHao/GetBaseRequests" + para);

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json);
                if (result.status == 1 && result.data.Count > 0)
                {
                    list = result.data;
                    if (list != null && list.Count > 0)
                    {

                        var ds = list.Skip(0).Take(uiPagination1.PageSize).Select(p => new
                        {
                            request_sn = p.request_sn,
                            unit_name = p.unit_name,
                            group_name = p.group_name,
                            doct_name = p.doct_name,
                            clinic_name = p.clinic_name,
                            weekstr = p.weekstr,
                            daystr = p.daystr,
                            apstr = p.apstr,
                            workroom = p.workroom,
                            totle_num = p.totle_num,
                            open_flag_str = p.open_flag_str,
                            op_date_str = p.op_date_str,
                            limit_appoint_percent = p.limit_appoint_percent
                        }).ToList();
                        dgvlist.DataSource = ds;
                        dgvlist.AutoGenerateColumns = false;
                        dgvlist.AutoResizeColumns();
                        dgvlist.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                        //SetColumnWidth();
                        SetGridTextColor();
                    }
                }
                else
                {
                    log.Error(result.message);
                    list = new List<BaseRequestVM>();
                    BindNullData();
                }
                BindBottomData();

            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());
            }
        }

        public void SetColumnWidth()
        {

            dgvlist.Columns["unit_name"].Width = 300;
            dgvlist.Columns["doct_name"].Width = 100;
            dgvlist.Columns["clinic_name"].Width = 100;
            dgvlist.Columns["daystr"].Width = 100;
            dgvlist.Columns["apstr"].Width = 100;
            dgvlist.Columns["totle_num"].Width = 100;
            dgvlist.Columns["open_flag_str"].Width = 100;
            dgvlist.Columns["winnostr"].Width = 100;
        }

        public void BindBottomData()
        {
            lblTotalCount.Text = "总计：" + list.Count.ToString() + "条, 每页 " + 50 + "条";
            //设置分页控件总数
            uiPagination1.TotalCount = list.Count;
            //设置分页控件每页数量
            uiPagination1.PageSize = 50;
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
                dgv.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
                dgv.RowHeadersVisible = false;
                dgv.BackgroundColor = Color.White;
                dgv.ReadOnly = true;
                 
                List<UnitVM> vm = units;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper()) || p.d_code.StartsWith(ipt.ToUpper()) || p.code.StartsWith(ipt)).ToList();
                }
                dgv.DataSource = vm;

                dgv.Columns["code"].HeaderText = "编号";
                dgv.Columns["name"].HeaderText = "名称";
                dgv.Columns["py_code"].Visible = false;
                dgv.Columns["d_code"].Visible = false;
                dgv.Columns["unit_sn"].Visible = false;
                dgv.Columns["yb_ks_code"].Visible = false;
                dgv.Columns["yb_ks_name"].Visible = false;
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
                dgvzk.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
                dgvzk.RowHeadersVisible = false;
                dgvzk.BackgroundColor = Color.White;
                dgvzk.ReadOnly = true;


                List<UnitVM> vm = units;

                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper()) || p.d_code.StartsWith(ipt.ToUpper()) || p.code.StartsWith(ipt)).ToList();
                }
                dgvzk.DataSource = vm;

                dgvzk.Columns["code"].HeaderText = "编号";
                dgvzk.Columns["name"].HeaderText = "名称";
                dgvzk.Columns["py_code"].Visible = false;
                dgvzk.Columns["d_code"].Visible = false;
                dgvzk.Columns["unit_sn"].Visible = false;
                dgvzk.Columns["yb_ks_code"].Visible = false;
                dgvzk.Columns["yb_ks_name"].Visible = false;
                dgvzk.AutoResizeColumns();

                dgvzk.Show();
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

        private void txtDoct_TextChanged(object sender, EventArgs e)
        {
            try
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
                    dgvys.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
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

        private void txtHaobie_TextChanged(object sender, EventArgs e)
        {
            try
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
                    dgvhb.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
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
            cbxSXW.Text = "全部"; 
            cbxWeek.Text = "";
            cbxDay.Text = "全部";
            cbxOpenFlag.Text = "全部";

            lblTotalCount.Text = "总计：" + 0 + "条";

            txtks.TextChanged += txtks_TextChanged;
            txtzk.TextChanged += txtzk_TextChanged;
            txtDoct.TextChanged += txtDoct_TextChanged;
            txtHaobie.TextChanged += txtHaobie_TextChanged;

            //InitData();

            BindNullData();
        }

        public void BindNullData()
        {
            var tmp = new List<BaseRequestVM>();
            var ds = tmp.Select(p => new
            {
                request_sn = p.request_sn,
                unit_name = p.unit_name,
                group_name = p.group_name,
                doct_name = p.doct_name,
                clinic_name = p.clinic_name,
                weekstr = p.weekstr,
                daystr = p.daystr,
                apstr = p.apstr,
                winnostr = p.winnostr,
                totle_num = p.totle_num,
                open_flag_str = p.open_flag_str,
                op_date_str = p.op_date_str,
                limit_appoint_percent = p.limit_appoint_percent
            }).ToList();
            dgvlist.DataSource = ds;
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
            Add();
        }

        public void Add()
        {
            BaseRequestEdit edit = new BaseRequestEdit("");
            edit.Style = this.Style;
            edit.ShowDialog();

            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete(); InitData();
        }

        public void Delete()
        {

            var index = dgvlist.SelectedIndex;

            if (index >= 0)
            {

                if (UIMessageBox.ShowAsk("进行删除操作，是否确定？"))
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
                            UIMessageTip.ShowError(result.message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        log.Error(ex.ToString());
                    }
                }
            }
        }

        private void uiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            try
            {
                var data = list.Skip((pageIndex - 1) * count).Take(count).ToList();
                var ds = data.Select(p => new
                {
                    request_sn = p.request_sn,
                    unit_name = p.unit_name,
                    group_name = p.group_name,
                    doct_name = p.doct_name,
                    clinic_name = p.clinic_name,
                    weekstr = p.weekstr,
                    daystr = p.daystr,
                    apstr = p.apstr,
                    winnostr = p.winnostr,
                    totle_num = p.totle_num,
                    open_flag_str = p.open_flag_str,
                    op_date_str = p.op_date_str
                }).ToList();
                dgvlist.AutoResizeColumns();
                dgvlist.DataSource = ds; dgvlist.AutoResizeColumns();
                //SetColumnWidth();
                SetGridTextColor();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit(); InitData();
        }

        public void Edit()
        {
            var index = dgvlist.SelectedIndex;

            if (index >= 0)
            {
                try
                {
                    var request_sn = dgvlist.Rows[index].Cells["request_sn"].Value.ToString();

                    current_sn = request_sn;

                    BaseRequestEdit edit = new BaseRequestEdit(current_sn);
                    edit.Style = this.Style;
                    edit.FormClosed += Edit_FormClosed;
                    edit.ShowDialog();

                    current_sn = "";
                }
                catch (Exception ex)
                {
                    UIMessageTip.ShowError(ex.ToString());
                    log.Error(ex.ToString());
                }
            }
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            InitData();
        }

        private void txtks_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
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
                else if (e.KeyCode == Keys.Escape)
                {
                    dgv.Hide();
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
                else if (e.KeyCode == Keys.Escape)
                {
                    dgvzk.Hide();
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
                else if (e.KeyCode == Keys.Escape)
                {
                    dgvhb.Hide();
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
                else if (e.KeyCode == Keys.Escape)
                {
                    dgvys.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
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

        private void BaseRequest_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F5://添加
                    Add();
                    break;
                case Keys.F6://编辑
                    Edit();
                    break;
                case Keys.F7://删除
                    Delete();
                    break;
            }
        }

        private void BaseRequest_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                this.Focus();
            }
        }

        private void BaseRequest_Initialize(object sender, EventArgs e)
        {

        }

        private void dgvlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Edit();
            }
        }

        private void dgvlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("e.RowIndex" + e.RowIndex.ToString());
            //MessageBox.Show("e.ColumnIndex" + e.ColumnIndex.ToString());
        }

        private void dgvlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.RowIndex != -1 || e.ColumnIndex == -1)
                {
                    return;
                }
                var _cIndex = e.ColumnIndex;
                if (list != null && list.Count > 0)
                {
                    if (order_asc == "asc")
                    {
                        switch (dgvlist.Columns[e.ColumnIndex].Name)
                        {
                            case "unit_name":
                                list = list.OrderBy(p => p.unit_name).ToList();
                                break;
                            case "doct_name":
                                list = list.OrderBy(p => p.doct_name).ToList();
                                break;
                            case "clinic_name":
                                list = list.OrderBy(p => p.clinic_name).ToList();
                                break;
                            case "daystr":
                                list = list.OrderBy(p => p.day).ToList();
                                break;
                            case "apstr":
                                list = list.OrderBy(p => p.ampm).ToList();
                                break;
                            case "totle_num":
                                list = list.OrderBy(p => p.totle_num).ToList();
                                break;
                            case "open_flag_str":
                                list = list.OrderBy(p => p.open_flag).ToList();
                                break;
                            case "winnostr":
                                list = list.OrderBy(p => p.window_no).ToList();
                                break;
                            default:
                                break;
                        }
                        order_asc = "desc";
                    }
                    else
                    {
                        switch (dgvlist.Columns[e.ColumnIndex].Name)
                        {
                            case "unit_name":
                                list = list.OrderByDescending(p => p.unit_name).ToList();
                                break;
                            case "doct_name":
                                list = list.OrderByDescending(p => p.doct_name).ToList();
                                break;
                            case "clinic_name":
                                list = list.OrderByDescending(p => p.clinic_name).ToList();
                                break;
                            case "daystr":
                                list = list.OrderByDescending(p => p.day).ToList();
                                break;
                            case "apstr":
                                list = list.OrderByDescending(p => p.ampm).ToList();
                                break;
                            case "totle_num":
                                list = list.OrderByDescending(p => p.totle_num).ToList();
                                break;
                            case "open_flag_str":
                                list = list.OrderByDescending(p => p.open_flag).ToList();
                                break;
                            case "winnostr":
                                list = list.OrderByDescending(p => p.window_no).ToList();
                                break;
                            default:
                                break;
                        }
                        order_asc = "asc";
                    }
                    //标题头
                    //dgvlist.Columns[e.ColumnIndex].HeaderText = AddOrderSymbol(dgvlist.Columns[e.ColumnIndex].HeaderText, order_asc); 
                    dgvlist.Columns[e.ColumnIndex].HeaderText = AddOrderSymbol(e.ColumnIndex, order_asc);

                    uiPagination1.PagerCount = 1;
                    var ds = list.Skip(0).Take(uiPagination1.PageSize).Select(p => new
                    {
                        request_sn = p.request_sn,
                        unit_name = p.unit_name,
                        group_name = p.group_name,
                        doct_name = p.doct_name,
                        clinic_name = p.clinic_name,
                        weekstr = p.weekstr,
                        daystr = p.daystr,
                        apstr = p.apstr,
                        winnostr = p.winnostr,
                        totle_num = p.totle_num,
                        open_flag_str = p.open_flag_str,
                        op_date_str = p.op_date_str
                    }).ToList();

                    dgvlist.DataSource = ds; dgvlist.AutoResizeColumns();
                    //SetColumnWidth(); 
                    SetGridTextColor();
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        public string AddOrderSymbol(int col_index, string order)
        {
            for (int i = 0; i < dgvlist.Columns.Count; i++)
            {
                dgvlist.Columns[i].HeaderText = RemoveOrderSymbol(dgvlist.Columns[i].HeaderText);
            }

            var text = dgvlist.Columns[col_index].HeaderText;

            if (order == "asc")
            {
                text += "↑";
            }
            else
            {
                text += "↓";
            }
            return text;
        }

        public string RemoveOrderSymbol(string text)
        {
            return text.Replace("↑", "").Replace("↓", "");
        }

        private void dgvlist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    dgvlist.Rows[e.RowIndex].Cells["unit_name"].Style.ForeColor = Color.Green;
            //    dgvlist.Rows[e.RowIndex].Cells["doct_name"].Style.ForeColor = UIColor.Blue;
            //    dgvlist.Rows[e.RowIndex].Cells["clinic_name"].Style.ForeColor = UIColor.Purple;
            //    dgvlist.Rows[e.RowIndex].Cells["daystr"].Style.ForeColor = UIColor.Green;
            //    dgvlist.Rows[e.RowIndex].Cells["apstr"].Style.ForeColor = UIColor.Orange;
            //    dgvlist.Rows[e.RowIndex].Cells["totle_num"].Style.ForeColor = UIColor.Blue;
            //    dgvlist.Rows[e.RowIndex].Cells["winnostr"].Style.ForeColor = UIColor.Purple;
            //    dgvlist.Rows[e.RowIndex].Cells["open_flag_str"].Style.ForeColor = Color.Orange;

            //}
        }

        public void SetGridTextColor()
        {
            foreach (DataGridViewRow row in dgvlist.Rows)
            {
                //row.Cells["unit_name"].Style.ForeColor = Color.Green;
                //row.Cells["doct_name"].Style.ForeColor = UIColor.Blue;
                //row.Cells["clinic_name"].Style.ForeColor = UIColor.Purple;
                //row.Cells["daystr"].Style.ForeColor = UIColor.Green;
                //row.Cells["apstr"].Style.ForeColor = UIColor.Orange;
                //row.Cells["totle_num"].Style.ForeColor = UIColor.Blue;
                //row.Cells["winnostr"].Style.ForeColor = UIColor.Purple;
                //row.Cells["open_flag_str"].Style.ForeColor = Color.Orange;
                if (row.Cells["open_flag_str"].Value != null && row.Cells["open_flag_str"].Value.ToString() == "不开放")
                {
                    row.Cells["open_flag_str"].Style.ForeColor = Color.Orange;
                }
            }
        }
    }
}
