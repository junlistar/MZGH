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
    public partial class AddSystemGroup : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddSystemGroup));//typeof放当前类
        public AddSystemGroup()
        {
            InitializeComponent();
        }

        public string group_code;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_groupcode.Text))
                {
                    UIMessageTip.ShowError("系统分组代码不能为空", 2000);
                    txt_groupcode.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_groupname.Text))
                {
                    UIMessageTip.ShowError("系统分组名称不能为空", 2000);
                    txt_groupname.Focus();
                    return;
                }

                SubSystemGroupVM vm = new SubSystemGroupVM();
                vm.group_code = txt_groupcode.Text.Trim();
                vm.group_name = txt_groupname.Text;
                vm.sort = int.Parse(txt_sort.Text);
                vm.active_flag = 1;

                string paramurl = string.Format($"/api/subsystem/UpdateSubSystemGroup");

                var json = HttpClientUtil.PostJSON(paramurl, vm);
                var result = HttpClientUtil.DeserializeObject<ResponseResult<bool>>(json);

                if (result.status == 1)
                {
                    UIMessageTip.ShowOk("保存成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UIMessageTip.ShowError(result.message, 2000);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void AddSystemGroup_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(group_code))
            {
                BindData();
            }
        }

        public void BindData()
        {
            var _group = SystemGroup.system_groups.Where(p => p.group_code == group_code).FirstOrDefault();
            if (_group != null)
            {
                txt_groupcode.Text = _group.group_code;
                txt_groupname.Text = _group.group_name;
                txt_sort.Text = _group.sort.ToString();
            }
        }
    }
}
