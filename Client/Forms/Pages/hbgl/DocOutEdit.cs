using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ViewModel;
using Sunny.UI;
using Client.ClassLib;
using log4net;

namespace Client.Forms.Pages.hbgl
{
    public partial class DocOutEdit : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(DocOutEdit));//typeof放当前类
        public DocOutEdit()
        {
            InitializeComponent();
        }

        public string _sn = "";
        public GhDoctorOutVM vm;
        public List<UserDicVM> docList;

        UIDataGridView dgvys = new UIDataGridView();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DocOutEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void DocOutEdit_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";

            txtDoct.Text = "";
            this.txtDate.Text = "";
            this.txtDate2.Text = "";
            docList = SessionHelper.userDics.Where(p => !string.IsNullOrEmpty(p.yb_ys_code)).ToList();

            if (vm != null)
            {
                //绑定数据
                var _doct = docList.Where(p => p.code == vm.doctor_id).FirstOrDefault();
                if (_doct != null)
                {
                    txtDoct.TextChanged -= txtDoct_TextChanged;
                    txtDoct.Text = _doct.name;
                    txtDoct.TagString = vm.doctor_id;
                    txtDoct.TextChanged += txtDoct_TextChanged;
                }

                txtDate.Text = vm.begin_date.ToShortDateString();
                txtDate2.Text = vm.end_date.ToShortDateString();
                chk_status.Checked = vm.is_delete == 1 ? false : true;
            }

            dgvys.KeyDown += Dgvys_KeyDown;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                if (vm == null)
                {
                    vm = new GhDoctorOutVM();
                }

                if (!string.IsNullOrWhiteSpace(txtDoct.Text))
                {
                    vm.doctor_id = txtDoct.TagString;
                    vm.doctor_name = txtDoct.Text;
                    vm.begin_date = txtDate.Value;
                    vm.end_date = txtDate2.Value.AddDays(1).AddSeconds(-1);
                    vm.is_delete = 0;//chk_status.Checked ? 0 : 1;

                    if (vm.begin_date > vm.end_date)
                    {
                        lblErrorMsg.Text = "开始日期必须大于结束日期";
                        return;
                    }

                    //查询当前医生的停诊信息
                    var paramurl = string.Format($"/api/GuaHao/GetGhDoctorOutsByParams?doctor_id={ vm.doctor_id}&date1=");
                    var json = HttpClientUtil.Get(paramurl);
                    var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhDoctorOutVM>>>(json);
                    if (result.status == 1 && result.data != null)
                    {
                        var _msg = "";
                        foreach (var item in result.data)
                        {
                            if (item.sn != vm.sn && ((vm.begin_date >= item.begin_date && vm.begin_date <= item.end_date) || (vm.end_date >= item.begin_date && vm.end_date <= item.end_date) || (vm.end_date >= item.end_date && vm.begin_date <= item.begin_date)))
                            {
                                _msg += $"日期冲突：{item.begin_date} - {item.end_date}\r\n";
                            }
                        }
                        if (!string.IsNullOrEmpty(_msg))
                        {
                            lblErrorMsg.Text = _msg;
                            return;
                        }
                    }

                    //1.停诊提交时，如果停诊期间存在已生成的排班数据，需要提示是否更新

                    //2.要展示已经挂出了多少号和列出已经生成的排班数据，然后选择是否更新

                    //3.最后一步要提示如有疑问，请到号表维护处理。

                    //查询停诊期间存在的已生成排版数据

                    paramurl = string.Format($"/api/GuaHao/GetExistGhrequest?doctor_sn={vm.doctor_id}&t1={vm.begin_date}&t2={vm.end_date}");
                    json = HttpClientUtil.PostJSON(paramurl, vm);
                    var ghresult = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json);
                    if (ghresult.status == 1)
                    {
                        if (ghresult.data != null && ghresult.data.Count > 0)
                        {
                            //列出已经生成的排班数据
                            if (UIMessageDialog.ShowAskDialog(this, "停诊期间存在已生成的排班数据，是否更新？"))
                            {
                                DoctoutGhRequest doctoutGh = new DoctoutGhRequest();
                                doctoutGh.list = ghresult.data;
                                doctoutGh.doct_name = vm.doctor_name;
                                doctoutGh.doct_sn = vm.doctor_id;
                                doctoutGh.t1 = vm.begin_date.ToString("yyyy-MM-dd HH:mm:ss");
                                doctoutGh.t2 = vm.end_date.ToString("yyyy-MM-dd HH:mm:ss");

                                if (doctoutGh.ShowDialog() != DialogResult.OK)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    paramurl = string.Format($"/api/GuaHao/UpdateGhDoctorOut");
                    json = HttpClientUtil.PostJSON(paramurl, vm);
                    var result1 = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                    if (result1.status == 1)
                    {
                        UIMessageBox.ShowInfo("保存停诊日期成功！如有疑问，请到号表维护处理！");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        UIMessageBox.ShowError("保存失败！" + result.message);
                    }
                }
            }
            catch (Exception ex)
            {

                UIMessageBox.ShowError("保存失败！" + ex.Message);
                log.Error(ex.ToString());
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

        private void txtDoct_Leave(object sender, EventArgs e)
        {
            if (!dgvys.Focused)
            {
                dgvys.Hide();
            }
        }

        private void txtDoct_TextChanged(object sender, EventArgs e)
        {
            //查询信息 显示到girdview
            var tb = sender as UITextBox;
            //获取数据 

            if (docList != null && docList.Count > 0)
            {
                var ipt = txtDoct.Text.Trim();

                dgvys.Parent = this;
                dgvys.Top = tb.Top + tb.Height;
                dgvys.Left = tb.Left;
                dgvys.Width = tb.Width;
                dgvys.Height = 200;
                dgvys.BringToFront();
                dgvys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvys.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
                dgvys.RowHeadersVisible = false;
                dgvys.BackgroundColor = Color.White;
                dgvys.ReadOnly = true;


                List<UserDicVM> vm = docList;

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
    }
}
