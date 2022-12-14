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
using Microsoft.Win32;
using Sunny.UI;

namespace MainFrame
{
    public partial class ClientConfig : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(ClientConfig));//typeof放当前类

        public static MainClientConfigVM clientConfigVM;

        public ClientConfig()
        {
            InitializeComponent();
        }

        
        public void BindData()
        {
            try
            {
                //string json = "";
                //string paramurl = string.Format($"/api/SubSystem/GetMainClientConfig");

                //log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                //json = HttpClientUtil.Get(paramurl);

                //var result = HttpClientUtil.DeserializeObject<ResponseResult<MainClientConfigVM>>(json);

                //if (result.status == 1)
                //{
                //    //显示数据到界面
                //    clientConfigVM = result.data;

                //    txt_title.Text = result.data.title;
                //    txt_show_image.Text = result.data.show_image;
                //    txt_show_title.Text = result.data.show_title;
                //    txt_show_desc.Text = result.data.show_desc;
                //}
                //else
                //{
                //    UIMessageTip.ShowError($"查询失败：{result.message}", 2000);
                //}

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //获取界面修改的信息
                clientConfigVM.title = txt_title.Text;
                clientConfigVM.show_image = txt_show_image.Text;
                clientConfigVM.show_title = txt_show_title.Text;
                clientConfigVM.show_desc = txt_show_desc.Text; 

                string paramurl = string.Format($"/api/SubSystem/UpdateMainClientConfig");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                var json = HttpClientUtil.PostJSON(paramurl, clientConfigVM);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<bool>>(json);

                if (result.status == 1)
                {
                    UIMessageTip.ShowOk("修改成功！", 2000);
                    this.Close();
                }
                else
                {
                    UIMessageTip.ShowError($"修改失败：{result.message}", 2000);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }

            this.Close();
        }

        private void ClientConfig_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void txt_show_image_ButtonClick(object sender, EventArgs e)
        {
            var openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Title = "请选择图片文件";
            openFileDialog1.Filter = "图片文件|*.jpg;*.gif;*.bmp;*.png;*.ico";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var _filePath = openFileDialog1.FileName;     //显示文件路径 
              //  this.txt_iconpath.Text = _filePath.Replace(Application.StartupPath, "");
            }
        }
    }
}
