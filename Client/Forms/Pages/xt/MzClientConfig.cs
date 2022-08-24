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

namespace Client.Forms.Pages.xt
{
    public partial class MzClientConfig : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(MzClientConfig));//typeof放当前类

        public MzClientConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void MzClientConfig_Initialize(object sender, EventArgs e)
        {
            LoadInfo();
        }
        public void LoadInfo()
        {
            if (SessionHelper.MzClientConfigVM != null)
            { 
                txt_systype.Text = SessionHelper.MzClientConfigVM.sys_type;
                txt_clientname.Text = SessionHelper.MzClientConfigVM.client_name;
                txt_clientversion.Text = SessionHelper.MzClientConfigVM.client_version;
                txt_ghsearchkeylength.Text = SessionHelper.MzClientConfigVM.client_ghsearchkey_length.ToString();
                txt_updatetime.Text = SessionHelper.MzClientConfigVM.update_time.ToString();
            }
            else
            {
                UIMessageTip.Show("没有获取到配置数据信息");
            }
        } 
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveData();

        }

        public void SaveData()
        {
            try
            {

                #region 非空验证
                if (string.IsNullOrWhiteSpace(txt_clientname.Text))
                {
                    UIMessageTip.Show("客户端名称不能为空");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_clientversion.Text))
                {
                    UIMessageTip.Show("客户端版本号不能为空");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_ghsearchkeylength.Text))
                {
                    UIMessageTip.Show("挂号搜索词数量不能为空");
                    return;
                }
                #endregion

                MzClientConfigVM clientConfig = new MzClientConfigVM();
                clientConfig.sys_type = txt_systype.Text.Trim();
                clientConfig.client_name = txt_clientname.Text.Trim();
                clientConfig.client_version = txt_clientversion.Text.Trim();
                clientConfig.client_ghsearchkey_length = int.Parse(txt_ghsearchkeylength.Text);

                var paramurl = string.Format($"/api/guahao/UpdateMzClientConfig");
                var json = HttpClientUtil.PostJSON(paramurl, clientConfig);
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                if (responseJson.status == 1)
                {
                    UIMessageTip.Show("修改成功");

                    //客户端配置 
                    paramurl = string.Format($"/api/GuaHao/GetMzClientConfig");
                    log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                    json = HttpClientUtil.Get(paramurl);
                    MzClientConfigVM mzClientConfig = WebApiHelper.DeserializeObject<ResponseResult<MzClientConfigVM>>(json).data;
                    if (mzClientConfig != null)
                    {
                        //系统配置信息，医院名称，版本号，挂号搜索词长度配置等
                        SessionHelper.MzClientConfigVM = mzClientConfig;
                        LoadInfo();
                    }
                }
                else
                {
                    UIMessageTip.ShowError(responseJson.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
