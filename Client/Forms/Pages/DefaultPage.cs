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
using log4net;

namespace Client.Forms.Pages
{
    public partial class DefaultPage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(DefaultPage));//typeof放当前类
        public DefaultPage()
        {
            InitializeComponent(); 
        }

        private void DefaultPage_Initialize(object sender, EventArgs e)
        {
            try
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/index.jpeg");
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("加载背景图片失败！");
                log.Error(ex.ToString());
            }
        }
    }
}
