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

namespace Client.Forms.Wedgit
{
    public partial class UserInfoNullDataConfig : UIForm
    {
        public UserInfoNullDataConfig()
        {
            InitializeComponent();
        }

        private void UserInfoNullDataConfig_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {

            try
            {
                //<List<string>> GetColumnNames(string obj_name)
                var paramurl = string.Format($"/api/GuaHao/GetSysConfig?item_name={"mzPatientInfo_notNullColumns"}");

                var json = HttpClientUtil.Get(paramurl);
                var result1 = WebApiHelper.DeserializeObject<ResponseResult<SysConfigVM>>(json);
                if (result1.status == 1)
                {
                    if (result1.data != null)
                    {
                        txtItemName.Text = result1.data.item_name;
                        txtComment.Text = result1.data.comment;
                        txtValue.Text = result1.data.current_value;

                        var _settings = result1.data.current_settings.Split(";");
                        tsf_colums.ItemsRight.AddRange(_settings);

                        paramurl = string.Format($"/api/GuaHao/GetColumnNames?obj_name={"mz_patient_mi"}");

                        json = HttpClientUtil.Get(paramurl);
                        var cols_result = WebApiHelper.DeserializeObject<ResponseResult<List<string>>>(json);
                        if (cols_result.status == 1)
                        {
                            foreach (var item in cols_result.data)
                            {
                                if (!_settings.Contains(item))
                                {
                                    tsf_colums.ItemsLeft.Add(item);
                                }
                            }
                        }
                        else
                        {
                            UIMessageTip.ShowError(cols_result.message);
                        }
                    }
                }
                else
                {
                    UIMessageTip.ShowError(result1.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var _item_name = txtItemName.Text;
                var _comment = txtComment.Text;
                var _value = txtValue.Text;

                List<string> columslist = new List<string>();

                foreach (var item in tsf_colums.ItemsRight)
                {
                    columslist.Add(item.ToString());
                }

                string _settings = string.Join(";", columslist);

                SysConfigVM _vm = new SysConfigVM();
                _vm.comment = _comment;
                _vm.item_name = _item_name;
                _vm.current_value = _value;
                _vm.current_settings = _settings;
                 
                var paramurl = string.Format($"/api/GuaHao/UpdateSysConfig");

                var json = HttpClientUtil.PostJSON(paramurl, _vm);
                var cols_result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                if (cols_result.status == 1)
                {
                    UIMessageTip.ShowOk("修改成功！");
                }
                else
                {
                    UIMessageBox.ShowError(cols_result.message);
                }


            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
