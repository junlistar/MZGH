﻿using System;
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
    public partial class UserManage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(UserManage));//typeof放当前类
          
        public UserManage()
        {
            InitializeComponent();
        }

        private void UserManage_Initialize(object sender, EventArgs e)
        {
            InitGroupsData();

            //菜单数据加载
            LoadMouseKeyMenu();

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

            cms_functions.Items.Clear();
            ToolStripMenuItem item3 = new ToolStripMenuItem("添加") { Tag = "A" };
            item3.Click += FunctionItem_Click;
            cms_functions.Items.Add(item3);
            ToolStripMenuItem item4 = new ToolStripMenuItem("删除") { Tag = "D" };
            item4.Click += FunctionItem_Click;
            cms_functions.Items.Add(item4);

            cms_user.Items.Clear();
            ToolStripMenuItem item5 = new ToolStripMenuItem("添加") { Tag = "A" };
            item5.Click += UserItem_Click;
            cms_user.Items.Add(item5);
            ToolStripMenuItem item6 = new ToolStripMenuItem("删除") { Tag = "D" };
            item6.Click += UserItem_Click;
            cms_user.Items.Add(item6);

            cms_reports.Items.Clear();
            ToolStripMenuItem item7 = new ToolStripMenuItem("添加") { Tag = "A" };
            item7.Click += ReportItem_Click;
            cms_reports.Items.Add(item7);
            ToolStripMenuItem item8 = new ToolStripMenuItem("删除") { Tag = "D" };
            item8.Click += ReportItem_Click;
            cms_reports.Items.Add(item8);
        }

        private void GroupItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Tag.ToString() == "A")
            {
                AddGroup addGroup = new AddGroup();
                addGroup.ShowDialog(); 
            }
            else if (item.Tag.ToString() == "D")
            {
                var _name = tv_groups.SelectedNode.Text.Trim();
                var _key = tv_groups.SelectedNode.Name.Trim();
                var _msg = "确定要删除用户组：" + _name + " 吗?";
                if (UIMessageBox.ShowAsk(_msg))
                {
                    UIMessageTip.Show("todo:删除操作" + _key);
                }
            }  
        }
        private void FunctionItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Tag.ToString() == "A")
            {
                AddFunction addFunction = new AddFunction();
                addFunction.ShowDialog();
            }
            else if (item.Tag.ToString() == "D")
            {
            
            }
                

            MessageBox.Show("function");
        }
        private void UserItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Tag.ToString() == "A")
            {
                AddUser addUser = new AddUser();
                addUser.ShowDialog();
            }
            else if (item.Tag.ToString() == "D")
            {
                //var _name = tv_users.SelectedNode.Text.Trim();
                var _name = tv_users.SelectedNode.Tag.ToString().Trim();
                var _key = tv_users.SelectedNode.Name.Trim();
                var _msg = "确定要删除用户：" + _name + " 吗?";
                if (UIMessageBox.ShowAsk(_msg))
                {
                    UIMessageTip.Show("todo:删除操作" + _key);
                }
            }
        }

        private void ReportItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Tag.ToString() == "A")
            {
                AddReport addReport = new AddReport();
                addReport.ShowDialog();
            }
            else if (item.Tag.ToString() == "D") { 
            
            }

        }
        public void InitGroupsData()
        {
            try
            {
                var d = new
                {
                    subsys_id = "mz"
                };

                var param = $"subsys_id={d.subsys_id}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/GetXTGroupsBySysId?{param}");

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

        public void BindOtherTreeView(string subsys_id)
        {
            //MessageBox.Show(subsys_id);
            InitUserData(subsys_id);
            InitUserGroupData(subsys_id);
            InitUserReportsData(subsys_id);
        }

        public void InitUserData(string user_group)
        {
            try
            {
                var d = new
                {
                    subsys_id = "mz",
                    user_group = user_group
                };

                var param = $"subsys_id={d.subsys_id}&user_group={d.user_group}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/GetXTUsersBySysId?{param}");

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
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTUserVM>>>(json);
                tv_users.Nodes.Clear();
                if (result.status == 1)
                {
                    foreach (var item in result.data)
                    {
                        string view_text = "用户名：" + item.name + "\t" + "用户工号：" + item.user_mi + "\t" + "登录名：" + item.user_name;
                        TreeNode treeNode = new TreeNode();
                        treeNode.Name = item.user_mi.ToString();
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
        public void InitUserGroupData(string user_group)
        {
            try
            {
                var d = new
                {
                    subsys_id = "mz",
                    user_group = user_group
                };

                var param = $"subsys_id={d.subsys_id}&user_group={d.user_group}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/GetXTUserGroupsBySysId?{param}");

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
                tv_functions.Nodes.Clear();
                if (result.status == 1)
                {
                    foreach (var item in result.data)
                    {
                        tv_functions.Nodes.Add(item.func_name, item.func_desc);
                    }
                    if (tv_functions.Nodes.Count > 0)
                    {
                        tv_functions.SelectedNode = tv_functions.Nodes[0];
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
        public void InitUserReportsData(string user_group)
        {
            try
            {
                var d = new
                {
                    subsys_id = "mz",
                    user_group = user_group
                };

                var param = $"subsys_id={d.subsys_id}&user_group={d.user_group}";

                var json = "";
                var paramurl = string.Format($"/api/qxgl/GetXTUserReportsBySysId?{param}");

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

        private void tv_groups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var subsys_id = tv_groups.SelectedNode.Name;
            BindOtherTreeView(subsys_id);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }

}
