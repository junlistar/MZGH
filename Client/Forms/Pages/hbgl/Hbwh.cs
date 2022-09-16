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
    public partial class Hbwh : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(Hbwh));//typeof放当前类

        List<BaseRequestVM> list = null;

        public List<UnitVM> units = null;
        public List<ClinicTypeVM> clinicTypes = null;
        public List<UserDicVM> userDics = null;
        public List<RequestTypeVM> requestTyeps = null;

        string order_asc = "asc";

        /// <summary>
        /// 解决页面频繁刷新时界面闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public Hbwh()
        {
            InitializeComponent();
        }
        private void BaseRequest_Load(object sender, EventArgs e)
        {
            InitDic();

            //设置按钮提示文字信息
            uiToolTip1.SetToolTip(btnSearch, btnSearch.Text + "[F1]");
            uiToolTip1.SetToolTip(btnReset, btnReset.Text + "[F2]");
            uiToolTip1.SetToolTip(btnAdd, btnAdd.Text + "[F3]");
            uiToolTip1.SetToolTip(btnExit, btnExit.Text + "[F4]");
             
            dgvlist.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
            dgvlist.CellDoubleClick += dgvlist_CellDoubleClick;
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

            var _dt_now = DateTime.Now.ToShortDateString();
            txtDate.Text = _dt_now;
            txtDate2.Text = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1).ToShortDateString();

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

            InitData();
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
            if (txtDate.Value > txtDate2.Value)
            {
                UIMessageTip.ShowError("开始日期不能大于结束日期!");
                return;
            }


            LoadingHelper.ShowLoadingScreen();//显示

            var begin = txtDate.Value.ToShortDateString();
            var end = txtDate2.Value.ToShortDateString();

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
            var temp_flag = "0";

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

            //switch (cbx_tempflag.Text)
            //{
            //    case "全部": temp_flag = "%"; break;
            //    case "临时号": temp_flag = "1"; break;
            //    case "正常号": temp_flag = "0"; break;
            //    default:
            //        break;
            //}

            #endregion

            var para = $"?begin={begin}&end={end}&unit_sn={visit_dept}&group_sn={group_sn}&doctor_sn={doctor_code}&clinic_type={clinic_type}&req_type={req_type}&ampm={ampm}&window_no={window_no}&open_flag={open_flag}&temp_flag={temp_flag}";

            string paramurl = string.Format($"/api/GuaHao/GetRequestsByParamsV2" + para);

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<string>>(json);
                if (result.status == 1 && result.data != null)
                {
                    //list = result.data;
                    //var ds = result.data.Select(p => new
                    //{
                    //    record_sn = p.record_sn,
                    //    request_date = p.request_date,
                    //    open_flag_str = p.open_flag_str,
                    //    apstr = p.apstr,
                    //    unit_name = p.unit_name,
                    //    unit_sn = p.unit_sn,
                    //    clinic_name = p.clinic_name,
                    //    req_name = p.req_name,
                    //    group_name = p.group_name,
                    //    doct_name = p.doct_name,
                    //    //weekstr = p.weekstr,
                    //    //daystr = p.daystr,
                    //    winnostr = p.winnostr,
                    //    begin_no = p.begin_no,
                    //    current_no = p.current_no,
                    //    end_no = p.end_no,

                    //    //op_date_str = p.op_date_str
                    //}).OrderBy(p => p.apstr).OrderBy(p => p.unit_name).OrderBy(p => p.group_name).OrderBy(p => p.clinic_name).OrderBy(p => p.doct_name).ToList();

                    //lblTotalCount.Text = $"总计： {ds.Count} 条数据";
                    //dgvlist.Init();
                    //dgvlist.DataSource = ds;
                    //dgvlist.CellBorderStyle = DataGridViewCellBorderStyle.Single;

                    var jsontb = result.data;
                    var dataTable = DataTableHelper.ToDataTable(jsontb);

                    dataTable = ManaDT(dataTable);
                    dgvlist.MergeColumnHeaderBackColor = UIColor.Blue;
                    this.dgvlist.DataSource = dataTable;
                    this.dgvlist.ColumnHeadersHeight = 40;
                    this.dgvlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                    lblTotalCount.Text = $"总计： {dataTable.Rows.Count} 条数据";

                    if (dataTable.Rows.Count > 0)
                    {

                        var _date = txtDate.Value;
                        var _idx = 8;
                        var _name_index = 0;
                        while (_date <= txtDate2.Value && dgvlist.Columns.Count > 0)
                        {
                            var _day_str = DataTimeUtil.GetDayFromEnum(_date.DayOfWeek);
                            dgvlist.AddSpanHeader(_idx, 3, _date.ToShortDateString() + " " + _day_str);
                            _date = _date.AddDays(1);
                            if (_name_index > 0)
                            {
                                //dgvlist.Columns["sn" + _name_index].Visible = false;
                                dgvlist.Columns["bc" + _name_index].HeaderText = "班次";
                                dgvlist.Columns["xe" + _name_index].HeaderText = "限额";
                                dgvlist.Columns["xy" + _name_index].HeaderText = "限约"; 

                                dgvlist.Columns["bc" + _name_index].Tag = _name_index;
                                dgvlist.Columns["xe" + _name_index].Tag = _name_index;
                                dgvlist.Columns["xy" + _name_index].Tag = _name_index;


                                dgvlist.Columns["sn" + _name_index].Visible = false;
                                dgvlist.Columns["open_flag" + _name_index].Visible = false;
                            }
                            else
                            {
                                //dgvlist.Columns["sn"].Visible = false;
                                dgvlist.Columns["bc"].HeaderText = "班次";
                                dgvlist.Columns["xe"].HeaderText = "限额";
                                dgvlist.Columns["xy"].HeaderText = "限约";


                                dgvlist.Columns["bc"].Tag = _name_index;
                                dgvlist.Columns["xe"].Tag = _name_index;
                                dgvlist.Columns["xy"].Tag = _name_index;


                                dgvlist.Columns["sn"].Visible = false;
                                dgvlist.Columns["open_flag"].Visible = false;
                            }

                            _idx = _idx + 5;
                            _name_index++;
                        }
                        dgvlist.Columns["unit_name"].HeaderText = "出诊专科";
                        dgvlist.Columns["unit_sn"].HeaderText = "出诊编码";
                        dgvlist.Columns["clinic_name"].HeaderText = "挂号类型";
                        dgvlist.Columns["doct_name"].HeaderText = "出诊医生";
                        //dgvlist.Columns["group_name"].HeaderText = "出诊科室";



                        //dgvlist.Columns["unit_sn"].Visible= false;
                        //dgvlist.Columns["group_sn"].Visible = false;
                        //dgvlist.Columns["group_name"].Visible = false;
                        dgvlist.Columns["clinic_type"].Visible = false;
                        dgvlist.Columns["doctor_sn"].Visible = false;
                        dgvlist.Columns["ampm"].Visible = false;
                        //dgvlist.Columns[11].HeaderText = "班次";
                        //this.dgvlist.AddSpanHeader(9, 2, begin);

                        if (this.dgvlist.MergeColumnNames == null)
                        {
                            this.dgvlist.MergeColumnNames = new List<string>();
                        }

                        this.dgvlist.MergeColumnNames.Add("unit_name");
                        this.dgvlist.MergeColumnNames.Add("doct_name");
                        this.dgvlist.MergeColumnNames.Add("clinic_name");
                        this.dgvlist.MergeColumnNames.Add("unit_sn");
                        //this.dgvlist.MergeColumnNames.Add("group_name");


                        dgvlist.AutoResizeColumns();

                        SetTextColor();
                    }

                    return;

                }
                else
                {
                    UIMessageTip.ShowError("查询失败!");
                    log.Error(result.message);
                    BindNullData();
                    lblTotalCount.Text = $"总计： 0 条数据";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
            finally
            {

                LoadingHelper.CloseForm();//显示
            }
        }

        public void SetTextColor()
        {

            foreach (DataGridViewRow row in dgvlist.Rows)
            {
                //row.Cells["unit_name"].Style.ForeColor = Color.Green;
                ////row.Cells["group_name"].Style.ForeColor = UIColor.Orange;
                //row.Cells["clinic_name"].Style.ForeColor = UIColor.Orange;
                //row.Cells["doct_name"].Style.ForeColor = UIColor.Purple;
                //row.Cells["unit_sn"].Style.ForeColor = UIColor.Green;

                var _date = txtDate.Value;
                var _name_index = 0;
                while (_date <= txtDate2.Value)
                {
                    if (_name_index > 0)
                    {
                        if (row.Cells["bc" + _name_index].Value != null && row.Cells["bc" + _name_index].Value.ToString().IndexOf("(停)") != -1)
                        {
                            row.Cells["bc" + _name_index].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            //row.Cells["bc" + _name_index].Style.ForeColor = Color.Green;
                        }
                         
                        //row.Cells["xe" + _name_index].Style.ForeColor = UIColor.Blue;
                        //row.Cells["xy" + _name_index].Style.ForeColor = UIColor.Purple;
                    }
                    else
                    {
                        if (row.Cells["bc"].Value!=null && row.Cells["bc"].Value.ToString().IndexOf("(停)")!=-1)
                        {
                            row.Cells["bc"].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            //row.Cells["bc"].Style.ForeColor = Color.Green;
                        }

                        
                        //row.Cells["xe"].Style.ForeColor = UIColor.Blue;
                        //row.Cells["xy"].Style.ForeColor = UIColor.Purple;
                    }
                    _name_index++;
                    _date = _date.AddDays(1);
                }
            }
        }
        public DataTable ManaDT(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var _date = txtDate.Value;
                var _name_index = 0;
                while (_date <= txtDate2.Value)
                {
                    if (_name_index > 0)
                    {
                        dt.Rows[i]["bc" + _name_index] = GetBanciText(dt.Rows[i]["bc" + _name_index].ToString());

                        var _opent_flag = dt.Rows[i]["open_flag" + _name_index]; 
                        if (_opent_flag != null  && _opent_flag.ToString()!="1")
                        {
                            var _bc = dt.Rows[i]["bc" + _name_index];
                            if (_bc!=null && !string.IsNullOrWhiteSpace(_bc.ToString()))
                            {
                                dt.Rows[i]["bc" + _name_index] = _bc.ToString() + "(停)";
                            }
                            
                        }
                    }
                    else
                    {
                        //上下午 代码 改为班次
                        dt.Rows[i]["bc"] = GetBanciText(dt.Rows[i]["bc"].ToString());

                        //处理 不开放的号，增加（停）标识
                        var _opent_flag = dt.Rows[i]["open_flag"];
                        if (_opent_flag != null && dt.Rows[i]["bc"] != null && _opent_flag.ToString() != "1" )
                        { 
                            var _bc = dt.Rows[i]["bc"];
                            if (_bc != null && !string.IsNullOrWhiteSpace(_bc.ToString()))
                            {
                                dt.Rows[i]["bc"] = _bc.ToString() + "(停)";
                            }
                        }
                    }
                    _name_index++;
                    _date = _date.AddDays(1);
                }
            }
            return dt;
        }

        public string GetBanciText(string ap)
        {
            var requestHour = SessionHelper.requestHours.Where(p => p.code == ap).FirstOrDefault();
            if (requestHour != null)
            {
                return requestHour.name;
            }
            return "";
        }

        public void BindNullData()
        {
            dgvlist.DataSource = null; 
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
                dgvzk.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
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
             
            var _dt_now = DateTime.Now.ToShortDateString();
            txtDate.Text = _dt_now;
            txtDate2.Text = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1).ToShortDateString();

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
            EditClick();
        }
        public void EditClick()
        {
            var _rowIndex = dgvlist.SelectedCells[0].RowIndex;
            var _colIndex = dgvlist.SelectedCells[0].ColumnIndex;
            Edit(_rowIndex, _colIndex);
        }


        public void Edit(int _rowIndex, int _colIndex)
        {
            try
            {
                if (dgvlist.SelectedCells.Count > 0)
                {
                    if (_rowIndex != -1 && _colIndex != -1)
                    {
                        var col_head_tag = dgvlist.Columns[_colIndex].Tag;

                        if (col_head_tag != null)
                        {
                            var _record_sn = "0";
                            if (col_head_tag.ToString() == "0")
                            {
                                _record_sn = dgvlist.Rows[_rowIndex].Cells["sn"].Value.ToString();
                            }
                            else
                            {
                                _record_sn = dgvlist.Rows[_rowIndex].Cells["sn" + col_head_tag].Value.ToString();
                            }

                            if (_record_sn != "0")
                            {
                                RequestEdit edit = new RequestEdit(_record_sn);
                                if (edit.ShowDialog() == DialogResult.OK)
                                {
                                    InitData();
                                }
                            }
                            else
                            {
                                UIMessageTip.ShowWarning("该日期条件下没有数据！");
                            }
                        }
                        else
                        {
                            UIMessageTip.ShowWarning("请选择具体日期下面的数据操作");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //var index = dgvlist.SelectedIndex;

            //if (index >= 0)
            //{

            //    try
            //    {

            //        var request_sn = dgvlist.Rows[index].Cells["request_sn"].Value.ToString();


            //        var d = new
            //        {
            //            request_sn = request_sn,
            //        };
            //        var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
            //        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //        var paramurl = string.Format($"/api/GuaHao/DeleteBaseRequest?request_sn={d.request_sn}");

            //        string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
            //        var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(res);

            //        if (result.status == 1)
            //        {
            //            UIMessageTip.ShowOk("操作成功!");
            //            return;
            //        }
            //        else
            //        {
            //            UIMessageTip.ShowError("查询失败!");
            //            log.Error(result.message);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //        log.Error(ex.ToString());
            //    }
            //}
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
                    EditClick();
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

        private void dgvlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                Edit(e.RowIndex, e.ColumnIndex);
            }
        }



        private void dgvlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
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
                            case "request_date":
                                list = list.OrderBy(p => p.request_date).ToList();
                                break;
                            case "apstr":
                                list = list.OrderBy(p => p.ampm).ToList();
                                break;
                            case "unit_name":
                                list = list.OrderBy(p => p.unit_name).ToList();
                                break;
                            case "doct_name":
                                list = list.OrderBy(p => p.doct_name).ToList();
                                break;
                            case "clinic_name":
                                list = list.OrderBy(p => p.clinic_name).ToList();
                                break;
                            case "req_name":
                                list = list.OrderBy(p => p.req_name).ToList();
                                break;
                            case "begin_no":
                                list = list.OrderBy(p => p.begin_no).ToList();
                                break;
                            case "current_no":
                                list = list.OrderBy(p => p.current_no).ToList();
                                break;
                            case "toend_no":
                                list = list.OrderBy(p => p.end_no).ToList();
                                break;
                            case "winnostr":
                                list = list.OrderBy(p => p.winnostr).ToList();
                                break;
                            case "open_flag_str":
                                list = list.OrderBy(p => p.open_flag).ToList();
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
                            case "request_date":
                                list = list.OrderByDescending(p => p.request_date).ToList();
                                break;
                            case "apstr":
                                list = list.OrderByDescending(p => p.ampm).ToList();
                                break;
                            case "unit_name":
                                list = list.OrderByDescending(p => p.unit_name).ToList();
                                break;
                            case "doct_name":
                                list = list.OrderByDescending(p => p.doct_name).ToList();
                                break;
                            case "clinic_name":
                                list = list.OrderByDescending(p => p.clinic_name).ToList();
                                break;
                            case "req_name":
                                list = list.OrderByDescending(p => p.req_name).ToList();
                                break;
                            case "begin_no":
                                list = list.OrderByDescending(p => p.begin_no).ToList();
                                break;
                            case "current_no":
                                list = list.OrderByDescending(p => p.current_no).ToList();
                                break;
                            case "toend_no":
                                list = list.OrderByDescending(p => p.end_no).ToList();
                                break;
                            case "winnostr":
                                list = list.OrderByDescending(p => p.winnostr).ToList();
                                break;
                            case "open_flag_str":
                                list = list.OrderByDescending(p => p.open_flag).ToList();
                                break;
                            default:
                                break;
                        }
                        order_asc = "asc";
                    }
                    //标题头 
                    dgvlist.Columns[e.ColumnIndex].HeaderText = AddOrderSymbol(e.ColumnIndex, order_asc);

                    var ds = list.Select(p => new
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
                    SetColumnWidth();
                } 
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }
        public void SetColumnWidth()
        {

            dgvlist.Columns["request_date"].Width = 100;
            dgvlist.Columns["apstr"].Width = 100;
            dgvlist.Columns["unit_name"].Width = 100;
            dgvlist.Columns["doct_name"].Width = 100;
            dgvlist.Columns["clinic_name"].Width = 100;
            dgvlist.Columns["req_name"].Width = 100;
            dgvlist.Columns["begin_no"].Width = 100;
            dgvlist.Columns["current_no"].Width = 100;
            dgvlist.Columns["toend_no"].Width = 100;
            dgvlist.Columns["winnostr"].Width = 100;
            dgvlist.Columns["open_flag_str"].Width = 100;
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


        private void btnWeek1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt_from = DateTime.Now.ToShortDateString();
                var dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1).ToShortDateString();

                txtDate.Text = dt_from;
                txtDate2.Text = dt_to;

                InitData();
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }

        }

        private void btnWeek2_Click(object sender, EventArgs e)
        {
            try
            {

                var dt_from = DateTime.Now.AddDays(0 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((2 - 1) * 7) + 1).ToShortDateString();
                var dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((2 - 1) * 7) + 1).ToShortDateString();

                txtDate.Text = dt_from;
                txtDate2.Text = dt_to;

                InitData();
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgvlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                var text = dgvlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (text != null)
                {

                    var col_head_tag = dgvlist.Columns[e.ColumnIndex].Tag;
                    var col_name = dgvlist.Columns[e.ColumnIndex].Name;

                    if (col_head_tag != null && col_name.Contains("xe"))
                    {
                        var _record_sn = "0";
                        if (col_head_tag.ToString() == "0")
                        {
                            _record_sn = dgvlist.Rows[e.RowIndex].Cells["sn"].Value.ToString();
                        }
                        else
                        {
                            _record_sn = dgvlist.Rows[e.RowIndex].Cells["sn" + col_head_tag].Value.ToString();
                        }

                        if (_record_sn != "0")
                        {
                            var _arr = text.ToString().Split("/");
                            if (_arr.Length == 2)
                            {
                                int _num = 0;
                                if (int.TryParse(_arr[1], out _num))
                                {
                                    //更新挂号 总数
                                    UpdateTotalNum(_record_sn, _num);

                                    return;
                                }
                            }
                            MessageBox.Show("格式不正确！");

                        }
                        else
                        {
                            UIMessageTip.ShowWarning("该日期条件下没有数据！");
                        }
                    }
                    else
                    {
                        UIMessageTip.ShowWarning("请选择具体日期下面的数据操作");
                    }
                }
                else
                {
                    UIMessageTip.Show("end");
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        public void UpdateTotalNum(string record_sn, int total_num)
        {
            // EditRequestTotalNum(string record_sn, int total_num)

            var para = $"?record_sn={record_sn}&total_num={total_num}";

            string paramurl = string.Format($"/api/GuaHao/EditRequestTotalNum" + para);

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                string json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);
                if (result.status == 1)
                {
                    UIMessageTip.Show("修改成功！");
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgvlist_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            MessageBox.Show($"{e.RowIndex},{e.ColumnIndex}");
        }

        private void dgvlist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //效果不好，下拉会有颜色变化， 弃用，改用dgvlist_ColumnHeaderMouseClick：SetTextColor();
            //if (e.RowIndex!=-1)
            //{
            //    var row = dgvlist.Rows[e.RowIndex];
            //    row.Cells["unit_name"].Style.ForeColor = UIColor.Red;
            //    //row.Cells["group_name"].Style.ForeColor = UIColor.Orange;
            //    row.Cells["clinic_name"].Style.ForeColor = UIColor.Orange;
            //    row.Cells["doct_name"].Style.ForeColor = UIColor.Purple;
            //    row.Cells["unit_sn"].Style.ForeColor = UIColor.Green;

            //    var _date = txtDate.Value;
            //    var _name_index = 0;
            //    while (_date <= txtDate2.Value)
            //    {
            //        if (_name_index > 0)
            //        {
            //            row.Cells["bc" + _name_index].Style.ForeColor = UIColor.Red;
            //            row.Cells["xe" + _name_index].Style.ForeColor = UIColor.Blue;
            //            row.Cells["xy" + _name_index].Style.ForeColor = UIColor.Purple;
            //        }
            //        else
            //        {
            //            row.Cells["bc"].Style.ForeColor = UIColor.Red;
            //            row.Cells["xe"].Style.ForeColor = UIColor.Blue;
            //            row.Cells["xy"].Style.ForeColor = UIColor.Purple;
            //        }
            //        _name_index++;
            //        _date = _date.AddDays(1);
            //    }
            //} 
        }

        private void dgvlist_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetTextColor();
        }
    }
}
