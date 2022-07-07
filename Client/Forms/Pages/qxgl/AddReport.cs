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
using log4net;
using Sunny.UI;

namespace Client.Forms.Pages.qxgl
{
    public partial class AddReport : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddReport));//typeof放当前类
        string _group_id;

        //添加后 刷新主页数据
        public delegate void SetData();
        public SetData setData;

        public AddReport(string group_id)
        {
            InitializeComponent();
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
                // AddXtUserReports(string rep_id, string subsys_id, string user_group)
                var d = new
                {
                    rep_id = tv_reports.SelectedNode.Name,
                    subsys_id = "mz", 
                    user_group = _group_id
                };

                var param = $"rep_id={d.rep_id}&subsys_id={d.subsys_id}&user_group={d.user_group}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/AddXtUserReports?{param}");

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
                    UIMessageTip.Show("添加成功！");
                    setData();
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
                var paramurl = string.Format($"/api/qxgl/GetXTUserReports?{param}");

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
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTUserReportVM>>>(json);
                tv_reports.Nodes.Clear();
                if (result.status == 1)
                {
                    foreach (var item in result.data)
                    {
                        if (item.parent_id == null || result.data.Where(p => p.rep_id == item.parent_id).Count() == 0)
                        {
                            tv_reports.Nodes.Add(item.rep_id, item.rep_name);

                        }
                    }
                    if (tv_reports.Nodes.Count > 0)
                    {
                        LoadSubItems(tv_reports.Nodes, result.data);
                        tv_reports.ExpandAll();
                        tv_reports.SelectedNode = tv_reports.Nodes[0];
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
        public void LoadSubItems(TreeNodeCollection treeNodeCollection, List<XTUserReportVM> data)
        {

            foreach (TreeNode node in treeNodeCollection)
            {
                var items = data.Where(p => p.parent_id == node.Name).ToList();
                if (items != null && items.Count > 0)
                {
                    foreach (var subitem in items)
                    {
                        node.Nodes.Add(subitem.rep_id, subitem.rep_name);
                    }
                    LoadSubItems(node.Nodes, data);
                }
            }
        }

        private void AddReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
