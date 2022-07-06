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

namespace Client.Forms.Pages.qxgl
{
    public partial class AddUser : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddUser));//typeof放当前类
        int _group_id = 0;

        public AddUser(int group_id)
        {
            InitializeComponent(); _group_id = group_id;
        }

        private void AddGroup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //save & close
                SaveData();
            }
        }
        public void SaveData()
        {
            try
            { 
                var d = new
                {
                    user_name = txtName.Text.Trim(),
                    subsys_id = "mz",
                    pass_word = txtpwd.Text.Trim(),
                    user_group = _group_id,
                    user_mi = txtUserName.TagString, 
                };

                var param = $"user_name={d.user_name}&subsys_id={d.subsys_id}&pass_word={d.pass_word}&user_group={d.user_group}&user_mi={d.user_mi}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/AddXtUser?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                var task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);

                if (result.status == 1)
                {
                    UIMessageTip.Show("添加成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        UIDataGridView dgv_user = new UIDataGridView();
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                return;
            }

            //查询信息 显示到girdview
            var tb = sender as UITextBox; 
            //获取数据 

            var user_list = SessionHelper.userDics;

            if (user_list != null && user_list.Count > 0)
            {
                var ipt = txtUserName.Text.Trim();

                dgv_user.Parent = this;
                dgv_user.Top =  tb.Top + tb.Height;
                dgv_user.Left =  tb.Left;
                dgv_user.Width = tb.Width;
                dgv_user.Height = 170;
                dgv_user.BringToFront();
                dgv_user.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_user.RowHeadersVisible = false;
                dgv_user.BackgroundColor = Color.White;
                dgv_user.ReadOnly = true;
                  
                if (!string.IsNullOrWhiteSpace(ipt))
                {
                    user_list = user_list.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                }
                dgv_user.DataSource = user_list;

                dgv_user.Columns["code"].HeaderText = "编号";
                dgv_user.Columns["name"].HeaderText = "名称";
                dgv_user.Columns["dept_sn"].HeaderText = "部门编号";
                dgv_user.Columns["dept_name"].HeaderText = "部门名称";
                dgv_user.Columns["dept_sn"].Visible = false;
                dgv_user.Columns["py_code"].Visible = false;
                dgv_user.Columns["d_code"].Visible = false;
                dgv_user.Columns["emp_sn"].Visible = false;
                dgv_user.AutoResizeColumns();

                dgv_user.CellClick -= dgv_user_CellContentClick;
                dgv_user.CellClick += dgv_user_CellContentClick;
                dgv_user.Show();
            }
        }
        private void dgv_user_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            var obj = sender as UIDataGridView;
            var code = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
            var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtUserName.TextChanged -= txtUserName_TextChanged;
            txtUserName.Text = name;
            txtUserName.TagString = code;
            txtUserName.TextChanged += txtUserName_TextChanged;

            dgv_user.Hide();
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.dgv_user.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgv_user.Rows.Count > 0)
                {

                    var code = dgv_user.Rows[0].Cells["code"].Value.ToString();
                    var name = dgv_user.Rows[0].Cells["name"].Value.ToString();

                    txtUserName.TextChanged -= txtUserName_TextChanged;
                    txtUserName.Text = name;
                    txtUserName.TagString = code;
                    txtUserName.TextChanged += txtUserName_TextChanged;

                    dgv_user.Hide();
                }
            }
        }
        private void dgvks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgv_user.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgv_user.SelectedIndex);

                    dgv_user_CellContentClick(sender, ev);
                }
            }

        }

        private void AddUser_Load(object sender, EventArgs e)
        {

            dgv_user.CellClick += dgv_user_CellContentClick;
            dgv_user.KeyDown += dgvks_KeyDown;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
