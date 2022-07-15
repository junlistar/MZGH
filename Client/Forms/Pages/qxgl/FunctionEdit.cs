using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Client.ClassLib;
using Client.ViewModel;
using log4net;

namespace Client.Forms.Pages.qxgl
{
    public partial class FunctionEdit : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddGroup));//typeof放当前类
        string _method_type = "add";

        public string subsys_id;
        public string func_name;
        public string func_desc;
        public string action_flag;


        public FunctionEdit(string method_type)
        {
            InitializeComponent();
            _method_type = method_type;
            LoadAllFunctions();
        }

        public void LoadAllFunctions()
        {
            try
            {
                var d = new
                {
                    subsys_id = "mz"
                };

                var param = $"subsys_id={d.subsys_id}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/GetXTUserGroups?{param}");

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
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTFunctionsVM>>>(json);

                if (result.status == 1)
                {
                    var _ds = result.data;
                    _ds.Insert(0, new XTFunctionsVM());
                    cbxFunctions.DataSource = _ds;
                    cbxFunctions.DisplayMember = "func_desc";
                    cbxFunctions.ValueMember = "func_name";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        public void SaveData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
                {
                    UIMessageTip.Show("数据不能为空！");
                    txtName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDesc.Text.Trim()))
                {
                    UIMessageTip.Show("数据不能为空！");
                    txtDesc.Focus();
                    return;
                }
                var _parent_func = "";
                if (cbxFunctions.SelectedValue!=null)
                {
                    _parent_func = cbxFunctions.SelectedValue.ToString().Trim();
                } 
                 
                var d = new
                {
                    func_name = txtName.Text.Trim(),
                    func_desc = txtDesc.Text.Trim(),
                    action_flag = cbxStatus.Text == "启用" ? 1 : 0,
                    parent_func = _parent_func,
                    subsys_id = "mz"
                };

                var param = $"subsys_id={d.subsys_id}&func_name={d.func_name}&func_desc={d.func_desc}&parent_func={d.parent_func}&action_flag={d.action_flag}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/AddFuncton?{param}");
                if (_method_type == "edit")
                {
                    paramurl = string.Format($"/api/qxgl/UpdateFuncton?{param}");
                }


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
                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                if (result.status == 1)
                {
                    UIMessageTip.Show("操作成功！");
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

        private void FunctionEdit_Load(object sender, EventArgs e)
        {

            if (_method_type == "edit")
            {
                txtName.Text = func_name;
                txtName.ReadOnly = true;
                txtDesc.Text = func_desc;
                cbxStatus.Text = action_flag == "1" ? "启用" : "不启用";
            }
            else
            {
                cbxStatus.Text = "启用";
            }
        }
    }
}
