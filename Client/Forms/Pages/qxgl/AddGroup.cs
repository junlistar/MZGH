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
    public partial class AddGroup : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddGroup));//typeof放当前类
        public AddGroup()
        {
            InitializeComponent();
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
                //AddXTGroup(string group_name, string subsys_id);
                var d = new
                {
                    group_name = txtName.Text.Trim(),
                    subsys_id = "mz"
                };

                var param = $"group_name={d.group_name}&subsys_id={d.subsys_id}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/AddXTGroup?{param}");

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
    }
}
