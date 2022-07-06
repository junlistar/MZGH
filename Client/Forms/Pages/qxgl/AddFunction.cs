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
    public partial class AddFunction : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddFunction));//typeof放当前类
        List<XTUserGroupVM> _functions;
        List<XTUserGroupVM> _functions_all;
        string _subsysy_id; string _group_id;

        public AddFunction(List<XTUserGroupVM> functions,string subsysy_id,string group_id)
        {
            InitializeComponent();
            _functions = functions;
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
            //todo:save

            List<string> funclist = new List<string>();

            foreach (var item in tsf_functions.ItemsRight)
            {
                var func = _functions_all.Where(p => p.func_desc == item.ToString()).FirstOrDefault();

                if (func!=null)
                { 
                    funclist.Add(func.func_name);
                }  
            }

            string func_str = string.Join(",", funclist);
            try
            {
                //AddXtUserGroups(string func_str, string subsys_id, string user_group)
                var d = new
                {
                    func_str = func_str,
                    subsys_id = "mz",
                    user_group = _group_id
                };

                var param = $"func_str={d.func_str}&subsys_id={d.subsys_id}&user_group={d.user_group}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/AddXtUserGroups?{param}");

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
                tsf_functions.ItemsLeft.Clear();
                tsf_functions.ItemsRight.Clear();
                if (result.status == 1)
                {
                    UIMessageTip.Show("修改成功！");
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
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTUserGroupVM>>>(json);
                tsf_functions.ItemsLeft.Clear();
                tsf_functions.ItemsRight.Clear(); 
                if (result.status == 1)
                {
                    _functions_all = result.data;
                    if (_functions!=null)
                    {
                        foreach (var item in _functions)
                        {
                            tsf_functions.ItemsRight.Add(item.func_desc);
                        }
                    }

                    foreach (var item in _functions_all)
                    {
                        if (_functions.Where(p => p.func_name == item.func_name).Count() > 0)
                        {
                            continue;
                        }
                        tsf_functions.ItemsLeft.Add(item.func_desc);
                    } 
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
