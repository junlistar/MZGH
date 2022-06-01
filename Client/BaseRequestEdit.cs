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

        public BaseRequestEdit(BaseRequest baseRequest)
        {
            InitializeComponent();
            _baseRequest = baseRequest;
        }

        private void BaseRequestEdit_Load(object sender, EventArgs e)
        {

            InitUI();

            if (!string.IsNullOrEmpty(_baseRequest.current_sn))
            {
                //查询数据
                InitData();
            }

        }

        public void InitData()
        {

            var d = new
            {
                request_sn = _baseRequest.current_sn,
            };
            var cdata = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(cdata);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var paramurl = string.Format($"/api/GuaHao/GetBaseRequestsBySN?request_sn={d.request_sn}");

            string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
            var responseJson = WebApiHelper.DeserializeObject<ResponseResult<BaseRequestVM>>(res);

            if (responseJson.status == 1)
            {
                txtks.TextChanged -= txtks_TextChanged;
                txtzk.TextChanged -= txtzk_TextChanged;
                txtDoct.TextChanged -= txtDoct_TextChanged;

                var data = responseJson.data;

                if (!string.IsNullOrWhiteSpace(data.unit_sn))
                {
                    this.txtks.TagString = data.unit_sn;

                    var model = SessionHelper.units.Where(p => p.code == data.unit_sn).FirstOrDefault();

                    if (model != null)
                    {
                        this.txtks.Text = model.name;
                    }

                }

                if (!string.IsNullOrWhiteSpace(data.group_sn))
                {
                    this.txtzk.TagString = data.group_sn;

                    var model = SessionHelper.units.Where(p => p.code == data.group_sn).FirstOrDefault();

                    if (model != null)
                    {
                        this.txtzk.Text = model.name;
                    }

                }

                if (!string.IsNullOrWhiteSpace(data.doctor_sn))
                {
                    this.txtDoct.TagString = data.doctor_sn;

                    var model = SessionHelper.userDics.Where(p => p.code == data.doctor_sn).FirstOrDefault();

                    if (model != null)
                    {
                        this.txtDoct.Text = model.name;
                    }
                }
                cbxHaobie.SelectedValue = data.clinic_type;
                //cbxRequestType.SelectedValue = data.req_type;
                txtTotalNum.Text = data.totle_num.ToString();


                switch (data.ampm)
                {
                    case "a": cbxSXW.Text = "上午"; break;
                    case "m": cbxSXW.Text = "中午"; break;
                    case "p": cbxSXW.Text = "下午"; break;
                    case "e": cbxSXW.Text = "夜间"; break;
                    default:
                        cbxSXW.Text = data.ampm;
                        break;
                }
                switch (data.week)
                {
                    case 1: cbxWeek.Text = "第一周"; break;
                    case 2: cbxWeek.Text = "第二周"; break;
                    case 3: cbxWeek.Text = "第三周"; break;
                    case 4: cbxWeek.Text = "第四周"; break;
                    default:
                        break;
                }

                switch (data.day)
                {
                    case 1: cbxDay.Text = "星期一"; break;
                    case 2: cbxDay.Text = "星期二"; break;
                    case 3: cbxDay.Text = "星期三"; break;
                    case 4: cbxDay.Text = "星期四"; break;
                    case 5: cbxDay.Text = "星期五"; break;
                    case 6: cbxDay.Text = "星期六"; break;
                    case 7: cbxDay.Text = "星期日"; break;
                    default:
                        break;
                }
                switch (data.open_flag)
                {
                    case "1":
                        cbxOpenFlag.Text = "开放"; break;
                    case "0":
                        cbxOpenFlag.Text = "不开放"; break;
                    default:
                        cbxOpenFlag.Text = data.open_flag.ToString();
                        break;
                }
                switch (data.window_no)
                {
                    case 0: cbxWinNo.Text = "所有窗口"; break;
                    default:
                        data.window_no.ToString(); break;
                }

                txtks.TextChanged += txtks_TextChanged;
                txtzk.TextChanged += txtzk_TextChanged;
                txtDoct.TextChanged += txtDoct_TextChanged;
            }
            else
            {
                UIMessageTip.ShowError(responseJson.message);
            }
        }

        public void InitUI()
        {
            cbxHaobie.DataSource = _baseRequest.clinicTypes;
            cbxHaobie.ValueMember = "code";
            cbxHaobie.DisplayMember = "name";

            cbxWinNo.Text = "所有窗口";
            cbxOpenFlag.Text = "全部";

            dgv.CellClick += dgvks_CellContentClick;
            dgv.KeyDown += dgvks_KeyDown;

            dgvzk.CellClick += dgvzk_CellContentClick;
            dgvzk.KeyDown += Dgvzk_KeyDown;
             

            dgvys.CellClick += dgvys_CellContentClick;
            dgvys.KeyDown += Dgvys_KeyDown;

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
            var clinic_type = cbxHaobie.SelectedValue;
            var doctor_code = string.IsNullOrWhiteSpace(txtDoct.Text) ? "" : txtDoct.TagString;
            var group_sn = string.IsNullOrWhiteSpace(txtzk.Text) ? "" : txtzk.TagString;

            var ampm = ""; //cbxSXW.Text == "上午" ? "a" : "p";
            var week = "";
            var day = "";
            int window_no = 0;
            int open_flag = 1;
            int total_num = 0;



            switch (cbxSXW.Text)
            {
                case "上午": ampm = "a"; break;
                case "中午": ampm = "m"; break;
                case "下午": ampm = "p"; break;
                case "夜间": ampm = "e"; break;
                default:
                    break;
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
            if (int.TryParse(txtTotalNum.Text, out result))
            {
                total_num = result;
            }

            if (string.IsNullOrWhiteSpace(visit_dept))
            {
                UIMessageTip.ShowError("请选择科室！");
                txtks.Focus();
                return;
            }
            if (clinic_type == null || clinic_type.ToString() == "")
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
            if (total_num <= 0)
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
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            var listApi = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json).data;

            if (listApi != null && listApi.Count > 0)
            {
                if (string.IsNullOrEmpty(_baseRequest.current_sn))
                {
                    UIMessageTip.Show("验证失败 ，系统已存在相同的数据！");
                    return;
                }
                else
                {
                    if (listApi[0].request_sn != _baseRequest.current_sn)
                    {
                        UIMessageTip.Show("验证失败 ，系统已存在相同的数据！");
                        return;
                    }
                }
            }


            //UIMessageTip.Show("验证成功 ，提交数据！");

            var d = new
            {
                request_sn = _baseRequest.current_sn,
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

            string res = SessionHelper.MyHttpClient.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;

            var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res).data;

            if (responseJson == 1 || responseJson == 2)
            {
                UIMessageTip.ShowOk("操作成功!");
            }

            this.Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BaseRequestEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
