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
    public partial class FunctionList : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddFunction));//typeof放当前类 
        List<XTFunctionsVM> _functions_all;
        string _subsysy_id; string _group_id;

        public FunctionList(string subsysy_id, string group_id)
        {
            InitializeComponent();
            _subsysy_id = subsysy_id;
            _group_id = group_id;
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


        }

        private void AddFunction_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
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
                    _functions_all = result.data;
                    dgv_functions.Init();
                    dgv_functions.DataSource = result.data;
                    lblSumText.Text = result.data.Count + "条数据";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FunctionEdit functionEdit = new FunctionEdit("add");
            functionEdit.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FunctionEdit functionEdit = new FunctionEdit("edit");
            var index = dgv_functions.SelectedIndex;

            functionEdit.subsys_id = "mz";
            functionEdit.func_name = dgv_functions.Rows[index].Cells["func_name"].Value.ToString().Trim();
            functionEdit.func_desc = dgv_functions.Rows[index].Cells["func_desc"].Value.ToString().Trim();
            functionEdit.action_flag = dgv_functions.Rows[index].Cells["action_flag"].Value.ToString().Trim();

            functionEdit.ShowDialog(); LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var index = dgv_functions.SelectedIndex;
             
            try
            { 
                var subsys_id = "mz";
                var func_name = dgv_functions.Rows[index].Cells["func_name"].Value.ToString().Trim();
                var func_desc = dgv_functions.Rows[index].Cells["func_desc"].Value.ToString().Trim();
                var action_flag = dgv_functions.Rows[index].Cells["action_flag"].Value.ToString().Trim();

                var _msg = "确定要删除功能：" + func_name + "," + func_desc + " 吗?";
                if (UIMessageBox.ShowAsk(_msg))
                {  
                    var d = new
                    {
                        func_name = func_name,
                        func_desc = func_desc,
                        action_flag = action_flag,
                        subsys_id = subsys_id
                    };

                    var param = $"subsys_id={d.subsys_id}&func_name={d.func_name}&func_desc={d.func_desc}&action_flag={d.action_flag}";

                    var json = "";
                    var paramurl = string.Format($"/api/qxgl/DelFuncton?{param}");

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
                        LoadData();
                    }
                    else
                    {
                        UIMessageTip.ShowError(result.message);
                        log.Error(result.message);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
