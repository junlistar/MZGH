using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;
using log4net;

namespace Client.Forms.Pages.hbgl
{
    public partial class DocOutManage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(DocOutManage));//typeof放当前类
        public DocOutManage()
        {
            InitializeComponent();
        }
        List<GhDoctorOutVM> list;

        public List<UserDicVM> docList;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //<List<GhDoctorOut>> GetGhDoctorOuts()

            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DocOutEdit docOutEdit = new DocOutEdit();
            docOutEdit.Style = this.Style;
            if (docOutEdit.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            try
            {
                 
                var dt1 = txtDate.Text;
                //var dt2 = txtDate2.Value;
                //if (dt1 > dt2)
                //{
                //    UIMessageTip.Show("结算日期必须大于等于开始日期");
                //    return;
                //}
                var doct_sn = "";
                if (!string.IsNullOrWhiteSpace(txtDoct.Text))
                {
                    doct_sn = txtDoct.TagString;
                }

                var paramurl = string.Format($"/api/GuaHao/GetGhDoctorOutsByParams?doctor_id={doct_sn}&date1={dt1}");
                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhDoctorOutVM>>>(json);
                if (result.status == 1)
                {
                    list = result.data;

                    dgvlist.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
                  
                    dgvlist.DataSource = list; dgvlist.AutoResizeColumns();
                }
                else
                {
                    dgvlist.DataSource = new List<GhDoctorOutVM>();
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                var _index = dgvlist.SelectedIndex;
                if (_index != -1)
                {
                    var _sn = dgvlist.Rows[_index].Cells["sn"].Value.ToString();
                    var _doctor_id = dgvlist.Rows[_index].Cells["doctor_id"].Value.ToString();
                    var _begin_date = Convert.ToDateTime(dgvlist.Rows[_index].Cells["begin_date"].Value.ToString());
                    var _end_date = Convert.ToDateTime(dgvlist.Rows[_index].Cells["end_date"].Value.ToString());
                    var _is_delete = Convert.ToInt32(dgvlist.Rows[_index].Cells["is_delete"].Value.ToString());

                    var _vm = new GhDoctorOutVM();
                    _vm.sn = _sn;
                    _vm.doctor_id = _doctor_id;
                    _vm.begin_date = _begin_date;
                    _vm.end_date = _end_date;
                    _vm.is_delete = _is_delete;
                    DocOutEdit docOutEdit = new DocOutEdit();
                    docOutEdit.Style = this.Style;
                    docOutEdit.vm = _vm;
                    if (docOutEdit.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgvlist_SelectIndexChange(object sender, int index)
        {
            //dgvlist.Rows[index].DefaultCellStyle.BackColor = SessionHelper.dgv_row_seleced_color;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DocOutManage_Initialize(object sender, EventArgs e)
        {
            txtDate.Text = "";
            dgvys.KeyDown += Dgvys_KeyDown;

            docList = SessionHelper.userDics.Where(p => !string.IsNullOrEmpty(p.yb_ys_code)).ToList();

            //默认查询
            LoadData();
        }

        UIDataGridView dgvys = new UIDataGridView();

        private void txtDoct_KeyUp(object sender, KeyEventArgs e)
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
            var pbl = tb.Parent as UIPanel;
            //获取数据 

            if (docList != null && docList.Count > 0)
            {
                var ipt = txtDoct.Text.Trim();

                dgvys.Parent = this;
                dgvys.Top = pbl.Top + tb.Top + tb.Height;
                dgvys.Left = pbl.Left + tb.Left;
                dgvys.Width = 500;
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
                dgvys.Columns["dept_sn"].HeaderText = "部门编号";
                dgvys.Columns["dept_name"].HeaderText = "部门名称";
                dgvys.Columns["yb_ys_code"].Visible = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                var _index = dgvlist.SelectedIndex;
                if (_index != -1)
                {
                    var _sn = dgvlist.Rows[_index].Cells["sn"].Value.ToString();

                    var _entity = list.Where(p => p.sn == _sn).FirstOrDefault();

                    _entity.is_delete = 1;

                    string paramurl = string.Format($"/api/GuaHao/UpdateGhDoctorOut");
                    var json = HttpClientUtil.PostJSON(paramurl, _entity);
                    var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                    if (result.status == 1)
                    {
                        UIMessageTip.ShowOk("删除成功！");
                        LoadData();
                    }
                    else
                    {
                        UIMessageTip.ShowError("保存失败！" + result.message);
                    }  
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var _dt = DateTime.Now;
            txtDate.Value = _dt; 
            txtDoct.TextChanged -= txtDoct_TextChanged;
            txtDoct.Text = "";
            txtDoct.TextChanged += txtDoct_TextChanged;
            dgvlist.DataSource = new List<GhDoctorOutVM>(); ; 
        }

        private void DocOutManage_Load(object sender, EventArgs e)
        { 
            StyleHelper.SetGridColor(dgvlist);//设置样式
        }
    }
}
