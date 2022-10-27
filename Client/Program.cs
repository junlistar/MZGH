using Client.FastReportLib;
using Client;
using GuxHis.Mzsf;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace GuxHis  
//程序集GuXHisMzsfAndMzgh
namespace GuxHis.Mzsf
{
    internal static class Program
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));//typeof放当前类
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //这段代码要在程序运行的入口进行配置
            log4net.Config.XmlConfigurator.Configure();//需要配置这段代码，log4才能生效

            log.Debug("打开了程序");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FHeaderAsideMainFooter(args));
            //Application.Run(new Form1());

            //菜单管理 
            log.Debug("关闭了程序");
        }
    }
    public class MainForm
    {
        private static ILog log = LogManager.GetLogger(typeof(MainForm));//typeof放当前类
        //包含控件的窗口句柄
        public IntPtr intPtr;

        FHeaderAsideMainFooter mf;

        public IntPtr GetGuxHisMzsfHandle()
        {
            if (mf != null)
            {
                intPtr = mf.GetGuxHisMzsfHandle();
                return intPtr;
            }
            return IntPtr.Zero;
        }
        public MainForm()
        {
            MessageBox.Show("无参数"); //LoadCompoment();
        }
        public void OpenFormWithParams(string args)
        {
            MessageBox.Show($"参数:{args}");
            //log.Debug($"程序被调用，参数：{args}");

            if (!string.IsNullOrEmpty(args))
            {
                //mf = new FHeaderAsideMainFooter(new string[] { args });
                //mf = new FHeaderAsideMainFooter();
                //Application.Run(mf);

                //这段代码要在程序运行的入口进行配置
                //log4net.Config.XmlConfigurator.Configure();//需要配置这段代码，log4才能生效

                log.Debug("打开了程序");
                mf = new FHeaderAsideMainFooter(new string[] { args });
                Application.Run(mf);
                //Application.Run(new Form1());

                //菜单管理 
                log.Debug("关闭了程序");
            }
        }
    }

    //public class ShowWinForm
    //{
    //    private static ILog log = LogManager.GetLogger(typeof(ShowWinForm));//typeof放当前类
    //    //包含控件的窗口句柄
    //    public IntPtr intPtr;

    //    FHeaderAsideMainFooter mf;

    //    public IntPtr GetWinFormHandle()
    //    {
    //        if (mf!=null)
    //        {
    //            intPtr = mf.GetGuxHisMzsfHandle();
    //            return intPtr;
    //        }
    //        return IntPtr.Zero;
    //    }
    //    public ShowWinForm()
    //    {
    //        MessageBox.Show("无参数"); //LoadCompoment();
    //    }
    //    public void SetRunParams(string args)
    //    {
    //        MessageBox.Show($"参数:{args}");
    //        //log.Debug($"程序被调用，参数：{args}");

    //        if (!string.IsNullOrEmpty(args))
    //        {
    //            MessageBox.Show($"参数打开界面");
    //            //mf = new FHeaderAsideMainFooter(new string[] { args });
    //            //mf = new FHeaderAsideMainFooter();
    //            //Application.Run(mf);

    //            //这段代码要在程序运行的入口进行配置
    //            log4net.Config.XmlConfigurator.Configure();//需要配置这段代码，log4才能生效

    //            log.Debug("打开了程序");
    //            mf = new FHeaderAsideMainFooter(new string[] { args });
    //            Application.Run(mf);
    //            //Application.Run(new Form1());

    //            //菜单管理 
    //            log.Debug("关闭了程序");
    //        }
    //    }
    //}
}
