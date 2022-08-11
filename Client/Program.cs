using Client.FastReportLib;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
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
            //try
            //{

                ////设置应用程序处理异常方式：ThreadException处理
                //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                ////UI线程的未处理异常捕获
                //Application.ThreadException += Application_ThreadException;
                ////非UI线程的未处理异常捕获
                //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;


                //这段代码要在程序运行的入口进行配置
                log4net.Config.XmlConfigurator.Configure();//需要配置这段代码，log4才能生效

                log.Debug("打开了程序");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FHeaderAsideMainFooter());
                //Application.Run(new Form1());

                //菜单管理

                log.Debug("关闭了程序");

                 
            //}
            //catch (Exception ex)
            //{
            //    string str = ExceptionToString(ex, "主线程");
            //    MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //} 
           
        }
        /// <summary>
        /// 提取异常信息
        /// </summary>
        private static string ExceptionToString(Exception ex, string info)
        {
            StringBuilder str = new StringBuilder($"{DateTime.Now}, {info}发生了一个错误！{Environment.NewLine}");
            if (ex.InnerException == null)
            {
                str.Append($"【对象名称】：{ex.Source}{Environment.NewLine}");
                str.Append($"【异常类型】：{ex.GetType().Name}{Environment.NewLine}");
                str.Append($"【详细信息】：{ex.Message}{Environment.NewLine}");
                str.Append($"【堆栈调用】：{ex.StackTrace}");
            }
            else
            {
                str.Append($"【对象名称】：{ex.InnerException.Source}{Environment.NewLine}");
                str.Append($"【异常类型】：{ex.InnerException.GetType().Name}{Environment.NewLine}");
                str.Append($"【详细信息】：{ex.InnerException.Message}{Environment.NewLine}");
                str.Append($"【堆栈调用】：{ex.InnerException.StackTrace}");
            }
            return str.ToString();
        }

        /// <summary>
        /// UI线程未捕获异常处理函数
        /// </summary>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                string msg = ExceptionToString(e.Exception, "UI线程");
                MessageBox.Show(msg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string msg = ExceptionToString(ex, "UI线程 处理函数");
                MessageBox.Show(msg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 非UI线程未捕获异常处理函数
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                string msg;
                if (e.ExceptionObject is Exception ex)
                {
                    msg = ExceptionToString(ex, "非UI线程");
                }
                else
                {
                    msg = $"发生了一个错误！信息:{e.ExceptionObject}";
                }
                MessageBox.Show(msg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string msg = ExceptionToString(ex, "非UI线程 处理函数");
                MessageBox.Show(msg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
