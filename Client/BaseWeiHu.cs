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
        static HttpClient client = null;
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
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));


            InitDic();

            //InitData();

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
            var open_flag = "%";


            if (cbxSXW.Text == "上午")
            {
                ampm = "a";
            }
            else if (cbxSXW.Text == "下午")
            {
                ampm = "p";
            }

            //switch (cbxWeek.Text)
            //{
            //    case "第一周": week = "1"; break;
            //    case "第二周": week = "2"; break;
            //    case "第三周": week = "3"; break;
            //    case "第四周": week = "4"; break;
            //    default:
            //        break;
            //}

            //switch (cbxDay.Text)
            //{
            //    case "星期一": day = "1"; break;
            //    case "星期二": day = "2"; break;
            //    case "星期三": day = "3"; break;
            //    case "星期四": day = "4"; break;
            //    case "星期五": day = "5"; break;
            //    case "星期六": day = "6"; break;
            //    case "星期日": day = "7"; break;
            //    default:
            //        break;
            //}

            if (cbxOpenFlag.Text == "开放")
            {
                open_flag = "1";
            }
            else if (cbxOpenFlag.Text == "不开放")
            {
                open_flag = "0";
            }

            #endregion

            if (list != null && list.Count > 0)
            {
                //var ds = list.CopyTo(ds);

                //if (visit_dept!="%")
                //{
                //    ds= list.Where(p => p.unit_sn.StartsWith(visit_dept));
                //}
            }

            var begin = txtDate.Value.ToShortDateString();

            var para = $"?begin={begin}&end={begin}";

            //string paramurl = string.Format($"/api/GuaHao/GhSearchList?gh_date={gh_date}&visit_dept={visit_dept}&clinic_type={clinic_type}&doctor_code={doctor_code}&group_sn={group_sn}&req_type={req_type}&ampm={ampm}&gh_opera={gh_opera}&name={name}&p_bar_code={p_bar_code}");
            string paramurl = string.Format($"/api/GuaHao/GetRequestsByDate" + para);

            log.Info(client.BaseAddress + paramurl);
            try
            {
                task = client.GetAsync(paramurl);

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

                list = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json).data;
                if (list != null && list.Count > 0)
                {
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
                        //weekstr = p.weekstr,
                        //daystr = p.daystr,
                        winnostr = p.winnostr,
                        begin_no = p.begin_no,
                        current_no = p.current_no,
                        end_no = p.end_no,

                        //op_date_str = p.op_date_str
                    }).OrderBy(p => p.apstr).ToList();
                    dgvlist.DataSource = ds;
                    dgvlist.AutoResizeColumns();
                }
                else
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

            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());
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
            try
            {

                if (dgvlist.Rows.Count > 0 && dgvlist.SelectedIndex >= 0)
                {
                    var record_sn = dgvlist.Rows[dgvlist.SelectedIndex].Cells["record_sn"].Value;

                    RequestEdit edit = new RequestEdit(record_sn.ToString());
                    edit.ShowDialog();
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

                    string res = client.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                    var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res).data;

                    if (responseJson == 1 || responseJson == 2)
                    {
                        UIMessageTip.ShowOk("操作成功!");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    UIMessageTip.ShowError(ex.ToString());

                }
            }
        }
    }
}
