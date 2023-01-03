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
using Client.Forms.Pages.qxgl;
using Client.ViewModel;
using log4net;
using MainFrame.Common;
using Sunny.UI;

namespace MainFrame
{
    public partial class UserManage : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(UserManage));//typeof放当前类

        string subsys_id = "his_main";

        public UserManage()
        {
            InitializeComponent();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            InitGroupsData();

            LoadMouseKeyMenu();
        }

        public void BindSystemGroupData()
        {
            try
            {
                string json = "";
                string paramurl = string.Format($"/api/subsystem/GetSubSystemGroups");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<SubSystemGroupVM>>>(json);
                if (result.status == 1)
                {
                    //system_groups = result.data.OrderBy(p => p.sort).ToList();
                    //dgvlist.DataSource = system_groups.Select(p => new
                    //{
                    //    p.group_code,
                    //    p.group_name,
                    //    p.sort,
                    //    p.update_time
                    //}).ToList();
                    //dgvlist.AutoResizeColumns();
                }
                else
                {
                    UIMessageTip.ShowError(result.message, 2000);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }
        }
        public void BindSystemData()
        {
            try
            {
                string json = "";
                string paramurl = string.Format($"/api/subsystem/GetSubSystems");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<SubSystemVM>>>(json);
                if (result.status == 1)
                {
                    //systemList = result.data.OrderBy(p => p.sys_no).ToList();
                    //dgvlist.DataSource = systemList.Select(p => new
                    //{
                    //    p.sys_no,
                    //    p.sys_code,
                    //    p.sys_name,
                    //    p.file_path,
                    //    p.icon_path,
                    //    p.file_type,
                    //    p.open_mode_str,
                    //}).ToList();
                    //dgvlist.AutoResizeColumns();
                }
                else
                {
                    UIMessageTip.ShowError(result.message, 2000);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }
        }

        public void LoadMouseKeyMenu()
        {
            cms_group.Items.Clear();
            ToolStripMenuItem item = new ToolStripMenuItem("添加") { Tag = "A" };
            item.Click += GroupItem_Click;
            cms_group.Items.Add(item);
            ToolStripMenuItem item2 = new ToolStripMenuItem("删除") { Tag = "D" };
            item2.Click += GroupItem_Click;
            cms_group.Items.Add(item2);

            //cms_functions.Items.Clear();
            //ToolStripMenuItem item3 = new ToolStripMenuItem("添加") { Tag = "A" };
            //item3.Click += FunctionItem_Click;
            //cms_functions.Items.Add(item3);
            //ToolStripMenuItem item4 = new ToolStripMenuItem("删除") { Tag = "D" };
            //item4.Click += FunctionItem_Click;
            //cms_functions.Items.Add(item4);

            cms_user.Items.Clear();
            ToolStripMenuItem item5 = new ToolStripMenuItem("添加") { Tag = "A" };
            item5.Click += UserItem_Click;
            cms_user.Items.Add(item5);
            ToolStripMenuItem item6 = new ToolStripMenuItem("删除") { Tag = "D" };
            item6.Click += UserItem_Click;
            cms_user.Items.Add(item6);

            //cms_reports.Items.Clear();
            //ToolStripMenuItem item7 = new ToolStripMenuItem("添加") { Tag = "A" };
            //item7.Click += ReportItem_Click;
            //cms_reports.Items.Add(item7);
            //ToolStripMenuItem item8 = new ToolStripMenuItem("删除") { Tag = "D" };
            //item8.Click += ReportItem_Click;
            //cms_reports.Items.Add(item8);
        }
        private void GroupItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Tag.ToString() == "A")
            {
                log.Info("添加组开始");
                AddGroup addGroup = new AddGroup();
                var dr = addGroup.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    log.Info("添加组成功");
                    InitGroupsData();
                }
                else
                {
                    log.Info("添加组取消");
                }
            }
            else if (item.Tag.ToString() == "D")
            {
                var _name = tv_groups.SelectedNode.Text.Trim();
                var _key = tv_groups.SelectedNode.Name.Trim();
                var _msg = "确定要删除用户组：" + _name + " 吗?";
                log.Info("删除用户组开始：" + _name);
                if (UIMessageBox.ShowAsk(_msg))
                {
                    log.Info("删除用户组成功：" + _name);
                    DeleteGroup(_key);
                }
                else
                {
                    log.Info("删除用户组取消");
                }
            }
        }

        private void UserItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;

                if (item.Tag.ToString() == "A")
                {
                    if (tv_groups.Nodes.Count > 0)
                    {
                        var _group_id = int.Parse(tv_groups.SelectedNode.Name);

                        AddUser addUser = new AddUser(_group_id);
                        if (addUser.ShowDialog() == DialogResult.OK)
                        {
                            //刷新 
                            InitUserData(_group_id.ToString());
                        };
                    }
                    else
                    {
                        UIMessageTip.ShowError("没有用户组信息！");
                    }

                }
                else if (item.Tag.ToString() == "D")
                {
                    var _group_id = tv_groups.SelectedNode.Name;

                    //var _name = tv_users.SelectedNode.Text.Trim();
                    var _name = tv_users.SelectedNode.Tag.ToString().Trim();
                    var _key = tv_users.SelectedNode.Name.Trim();
                    var _msg = "确定要删除用户：" + _name + " 吗?";
                    if (UIMessageBox.ShowAsk(_msg))
                    {
                        string login_name = _key.Split(",")[1];

                        DeleteUser(login_name, _group_id);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        public void DeleteGroup(string user_group)
        {
            // DeleteXTGroup(string user_group, string subsys_id)
            try
            {
                var d = new
                {
                    user_group = user_group,
                    subsys_id = subsys_id
                };

                var param = $"user_group={d.user_group}&subsys_id={d.subsys_id}";

                var paramurl = string.Format($"/api/qxgl/DeleteXTGroup?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);

                if (result.status == 1)
                {
                    UIMessageTip.Show("删除成功！");
                    InitGroupsData();
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

        public void DeleteUser(string user_name, string user_group)
        {
            // DeleteXtUser(string user_name, string subsys_id, string user_group)
            try
            {
                var d = new
                {
                    user_name = user_name,
                    user_group = user_group,
                    subsys_id = subsys_id
                };

                var param = $"user_name={d.user_name}&user_group={d.user_group}&subsys_id={d.subsys_id}";

                var paramurl = string.Format($"/api/qxgl/DeleteXtUser?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(json);

                if (result.status == 1)
                {
                    UIMessageTip.Show("删除成功！");
                    InitUserData(user_group);
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


        public void InitGroupsData()
        {
            try
            {
                var d = new
                {
                    subsys_id = subsys_id
                };

                var param = $"subsys_id={d.subsys_id}";

                var paramurl = string.Format($"/api/qxgl/GetXTGroupsBySysId?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTGroupVM>>>(json);
                tv_groups.Nodes.Clear();
                if (result.status == 1)
                {
                    foreach (var item in result.data)
                    {
                        tv_groups.Nodes.Add(item.user_group.ToString(), item.group_name);
                    }

                    if (tv_groups.Nodes.Count > 0)
                    {
                        tv_groups.SelectedNode = tv_groups.Nodes[0];

                        ////绑定其他项目
                        //var subsys_id = tv_groups.Nodes[0].Name;

                        //BindOtherTreeView(subsys_id);
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

        private void tv_groups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var subsys_id = tv_groups.SelectedNode.Name;
            BindOtherTreeView(subsys_id);
        }
        public void BindOtherTreeView(string user_group)
        { 
            InitUserData(user_group);
            //InitUserGroupData(user_group);
            //InitUserReportsData(user_group);

            LoadFuncTreeData();
        }

        public void InitUserData(string user_group)
        {
            try
            {
                var d = new
                {
                    subsys_id = subsys_id,
                    user_group = user_group
                };

                var param = $"subsys_id={d.subsys_id}&user_group={d.user_group}";

                var paramurl = string.Format($"/api/qxgl/GetXTUsersBySysId?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                string json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTUserVM>>>(json);
                tv_users.Nodes.Clear();
                if (result.status == 1)
                {
                    foreach (var item in result.data)
                    {
                        string view_text = "用户名：" + item.name + "\t" + "用户工号：" + item.user_mi + "\t" + "登录名：" + item.user_name;
                        TreeNode treeNode = new TreeNode();
                        treeNode.Name = item.user_mi + "," + item.user_name;
                        treeNode.Text = view_text;
                        treeNode.Tag = item.name;
                        //tv_users.Nodes.Add(item.user_mi.ToString(), view_text);
                        tv_users.Nodes.Add(treeNode);
                    }
                    if (tv_users.Nodes.Count > 0)
                    {
                        tv_users.SelectedNode = tv_users.Nodes[0];
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
        /// <summary>
        /// 加载树形选择控件
        /// </summary>
        public void LoadFuncTreeData()
        {
            try
            {
                var d = new
                {
                    subsys_id = subsys_id
                };

                var param = $"subsys_id={d.subsys_id}";

                var paramurl = string.Format($"/api/qxgl/GetXTUserGroups?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTFunctionsVM>>>(json);

                if (result.status == 1)
                {
                    tv_func_select.Nodes.Clear();
                    foreach (var item in result.data)
                    {
                        if (string.IsNullOrWhiteSpace(item.parent_func))
                        {
                            tv_func_select.Nodes.Add(item.func_name.Trim(), item.func_desc.Trim());
                        }
                    }
                    if (tv_func_select.Nodes.Count > 0)
                    {
                        LoadSubFuncItems(tv_func_select.Nodes, result.data);

                        tv_func_select.ExpandAll();
                    }
                    //选中已经有的
                    //SetCheckBox(tv_func_select.Nodes);

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

        /// <summary>
        /// 加载子项目
        /// </summary>
        /// <param name="treeNodeCollection"></param>
        /// <param name="data"></param>
        public void LoadSubFuncItems(TreeNodeCollection treeNodeCollection, List<XTFunctionsVM> data)
        {

            foreach (TreeNode node in treeNodeCollection)
            {
                var items = data.Where(p => p.parent_func != null && p.parent_func.Trim() == node.Name).ToList();
                if (items != null && items.Count > 0)
                {
                    foreach (var subitem in items)
                    {
                        node.Nodes.Add(subitem.func_name.Trim(), subitem.func_desc.Trim());
                    }
                    LoadSubFuncItems(node.Nodes, data);
                }
            }
        }

    }
}
