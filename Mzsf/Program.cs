using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mzsf
{
    internal static class Program
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));//typeof放当前类
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //这段代码要在程序运行的入口进行配置
            log4net.Config.XmlConfigurator.Configure();//需要配置这段代码，log4才能生效
            log.Debug("打开了程序");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FHeaderAsideMainFooter());
            
            log.Debug("关闭了程序");
        }
    }
}
