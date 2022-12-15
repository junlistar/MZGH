using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFrame.Common;
using Sunny.UI;
using System.Runtime.InteropServices;
using log4net;

namespace MainFrame
{
    public partial class TestForm : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(TestForm));//typeof放当前类
        public TestForm()
        {
            InitializeComponent();

        }

        public string sys_key;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        private void Container_Initialize(object sender, EventArgs e)
        {
        }

        private void Container_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Red;

            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(this.Width, this.Height);

            switch (sys_key)
            {
                case "mzgh":
                default:
                    OpenSubSystem();
                    break;
            }
        }
        Process proexe;

        public void OpenSubSystem()
        {
            try
            {


                EmbeddedExeTool exetool = new EmbeddedExeTool();

                var _args = StringUtil.Base64Encode(EmbeddedExeTool.SerializeObject(Main.vM));

                exetool.LoadEXE_test(this, Application.StartupPath + @"\yp_Test.exe", _args); 

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("系统配置有误！请查看日志文件");
                log.Error(ex.ToString());
            }
        }
    }
}
