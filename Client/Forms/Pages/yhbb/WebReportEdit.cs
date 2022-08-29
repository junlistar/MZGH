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

namespace Client.Forms.Pages.yhbb
{
    public partial class WebReportEdit : UIForm
    {
        public WebReportEdit()
        {
            InitializeComponent();
        }

        public string _code;

        private void WebReportEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var _code = txt_code.Text.Trim();
            var _name = txt_name.Text.Trim();
            var _url = txt_url.Text.Trim();
            var _flag = chk_openflag.Checked ? 1 : 0;
              
            MzWebReportVM vm = new MzWebReportVM();
            vm.code = _code;
            vm.name = _name;
            vm.url = _url;
            vm.open_flag = _flag;
            vm.create_opera = SessionHelper.uservm.user_mi;
            vm.update_opera = SessionHelper.uservm.user_mi;

            var paramurl = string.Format($"/api/Report/EditWebReportByJson");
            var json = HttpClientUtil.PostJSON(paramurl, vm);
            var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
            if (result.status == 1)
            {
                UIMessageTip.Show("保存成功");
                this.Close();
            }
        }

        private void WebReportEdit_Load(object sender, EventArgs e)
        {
            LoadInfo();

            uiComboDataGridView1.DataGridView.DataSource = SessionHelper.userDics;
            uiComboDataGridView1.FilterColumnName = "py_code";
            
        }

        public void LoadInfo()
        {
            if (string.IsNullOrEmpty(_code))
            {
                return;
            }
            var paramurl = string.Format($"/api/Report/GetMzWebReportByCode?code={_code}");
            var json = HttpClientUtil.Get(paramurl);
            var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzWebReportVM>>>(json);

            if (result.status == 1)
            {
                var _vm = result.data.FirstOrDefault();
                if (_vm!=null)
                {
                    txt_code.Text = _vm.code;
                    txt_name.Text = _vm.name;
                    txt_url.Text = _vm.url;
                    chk_openflag.Checked = _vm.open_flag == 1;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
