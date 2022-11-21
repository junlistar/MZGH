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
using log4net;
using MainFrame.Common;
using Sunny.UI;

namespace MainFrame
{
    public partial class SystemGroup : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(SystemGroup));//typeof放当前类

        public static List<SubSystemGroupVM> system_groups;

        public SystemGroup()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
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
                    system_groups = result.data.OrderBy(p => p.sort).ToList();
                    dgvlist.DataSource = system_groups.Select(p => new
                    {
                        p.group_code,
                        p.group_name,
                        p.sort,
                        p.update_time
                    }).ToList();
                    dgvlist.AutoResizeColumns();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSystemGroup addSystemGroup = new AddSystemGroup();
            if (addSystemGroup.ShowDialog() == DialogResult.OK)
            {
                BindData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = dgvlist.SelectedIndex;
                if (_index != -1)
                {
                    var _groupcode = dgvlist.Rows[_index].Cells["group_code"].Value;
                    if (_groupcode != null)
                    {
                        EditSystemGroup(_groupcode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }

        }

        public void EditSystemGroup(string code = "")
        {
            AddSystemGroup addSystemGroup = new AddSystemGroup();
            addSystemGroup.group_code = code;
            if (addSystemGroup.ShowDialog() == DialogResult.OK)
            {
                BindData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = dgvlist.SelectedIndex;
                if (_index != -1)
                {
                    var _groupcode = dgvlist.Rows[_index].Cells["group_code"].Value;
                    var _groupname = dgvlist.Rows[_index].Cells["group_name"].Value;
                    if (_groupcode != null)
                    { 
                        string paramurl = string.Format($"/api/subsystem/DeleteSubSystemGroup?sys_code={_groupcode}");

                        if (!UIMessageDialog.ShowAskDialog(this, $"确定要删除系统分组: {_groupname} 吗?"))
                        {
                            return;
                        }

                        var json = HttpClientUtil.Get(paramurl);
                        var result = HttpClientUtil.DeserializeObject<ResponseResult<bool>>(json);

                        if (result.status == 1)
                        {
                            UIMessageTip.ShowOk("操作成功！");

                            BindData();
                        }
                        else
                        {
                            UIMessageTip.ShowError(result.message, 2000);
                            log.Error(result.message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }
        }
        

    }
}
