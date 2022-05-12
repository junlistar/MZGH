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
using Sunny.UI;

namespace Client
{
    public partial class BaseRequestEdit : UIForm
    {
        BaseRequest _baseRequest;
       static HttpClient client = null;

        public BaseRequestEdit(BaseRequest baseRequest)
        {
            InitializeComponent();
            _baseRequest = baseRequest; client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));
        }

        private void BaseRequestEdit_Load(object sender, EventArgs e)
        {

            InitUI();

        }
        public void InitUI()
        {
            cbxHaobie.DataSource = _baseRequest.clinicTypes;
            cbxHaobie.ValueMember = "code";
            cbxHaobie.DisplayMember = "name";

            cbxWinNo.Text = "所有窗口";
            cbxOpenFlag.Text = "全部";
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

            if (_baseRequest.units != null && _baseRequest.units.Count > 0)
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


                List<UnitVM> vm = _baseRequest.units;

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

            if (_baseRequest.units != null && _baseRequest.units.Count > 0)
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


                List<UnitVM> vm = _baseRequest.units;

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

            if (_baseRequest.userDics != null && _baseRequest.userDics.Count > 0)
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


                List<UserDicVM> vm = _baseRequest.userDics;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var visit_dept = string.IsNullOrWhiteSpace(txtks.Text) ? "" : txtks.TagString;
            var clinic_type =cbxHaobie.SelectedValue;
            var doctor_code = string.IsNullOrWhiteSpace(txtDoct.Text) ? "" : txtDoct.TagString;
            var group_sn = string.IsNullOrWhiteSpace(txtzk.Text) ? "" : txtzk.TagString; 

            var ampm = ""; //cbxSXW.Text == "上午" ? "a" : "p";
            var week = "";
            var day = "";
            int window_no = 0;
            int open_flag = 1;
            int total_num = 0;


            if (cbxSXW.Text == "上午")
            {
                ampm = "a";
            }
            else if (cbxSXW.Text == "下午")
            {
                ampm = "p";
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
                open_flag = 1;
            }
            else if (cbxOpenFlag.Text == "不开放")
            {
                open_flag = 0;
            }
            int result = 0;
            if (int.TryParse(txtTotalNum.Text,out result))
            {
                total_num = result;
            }  

            if (string.IsNullOrWhiteSpace(visit_dept))
            {
                UIMessageTip.ShowError("请选择科室！");
                txtks.Focus();
                return;
            }
            if (clinic_type==null || clinic_type.ToString()=="")
            {
                UIMessageTip.ShowError("请选择号别！");
                cbxHaobie.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ampm))
            {
                UIMessageTip.ShowError("请选择上午下午！");
                cbxSXW.Focus();
                return;
            }
            if (string.IsNullOrEmpty(week))
            {
                UIMessageTip.ShowError("请选择周！");
                cbxWeek.Focus();
                return;
            }
            if (string.IsNullOrEmpty(day))
            {
                UIMessageTip.ShowError("请选择天！");
                cbxDay.Focus();
                return;
            }
            if (total_num<=0)
            {
                UIMessageTip.ShowError("总号数不正确！");
                txtTotalNum.Focus();
                return;
            }

            //判断是否存在
            Task<HttpResponseMessage> task = null;
            var json = "";


            var para = $"?unit_sn={visit_dept}&group_sn={group_sn}&doctor_sn={doctor_code}&clinic_type={clinic_type}&week={week}&day={day}&ampm={ampm}&window_no=&open_flag=";

            string paramurl = string.Format($"/api/GuaHao/GetBaseRequests" + para);
            task = client.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(json).data;

            if (listApi!=null && listApi.Count>0)
            {
                UIMessageTip.Show("验证失败 ，系统已存在相同的数据！");
            }
            else
            {

                //UIMessageTip.Show("验证成功 ，提交数据！");
                 
                var d = new
                {
                    request_sn = "",
                    unit_sn = visit_dept,
                    group_sn = group_sn,
                    doctor_sn = doctor_code,
                    clinic_type = clinic_type,
                    week = week,
                    day = day,
                    ampm = ampm,
                    totle_num = total_num,
                    window_no = window_no,
                    open_flag = open_flag,
                    op_id = SessionHelper.uservm.user_mi,
                };
                var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                paramurl = string.Format($"/api/GuaHao/EditBaseRequest?request_sn={d.request_sn}&unit_sn={d.unit_sn}&group_sn={d.group_sn}&doctor_sn={d.doctor_sn}&clinic_type={d.clinic_type}&week={d.week}&day={d.day}&ampm={d.ampm}&totle_num={d.totle_num}&window_no={d.window_no}&open_flag={d.open_flag}&op_id={d.op_id}");

                string res = client.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res).data;

                if (responseJson == 1|| responseJson == 2)
                { 
                    UIMessageTip.ShowOk("操作成功!");
                }

                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
