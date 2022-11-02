
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace GuXHis
{
    public class ShowWinForm
    {
        //private static ILog log = LogManager.GetLogger(typeof(ShowWinForm));//typeof放当前类
        //包含控件的窗口句柄
        public IntPtr intPtr;
        Process proexe;

        //FHeaderAsideMainFooter mf;

        public IntPtr GetWinFormHandle()
        {

            if (intPtr != null)
            { 
                return proexe.MainWindowHandle;
            }
            return IntPtr.Zero;
        }
        public ShowWinForm()
        {
            //MessageBox.Show("无参数"); //LoadCompoment();
        }

        public void SetRunParams(string args)
        {
            try
            {
                if (!string.IsNullOrEmpty(args))
                {
                    //MessageBox.Show(args);
                    //args = args.Replace("\"", "\\\"");

                    //var _index = args2.IndexOf("UserMi");
                    //MessageBox.Show(_index.ToString());
                    //if (_index > 0)
                    //{
                    //    args2 = args2.Substring(_index + 7);
                    //    _index = args2.IndexOf(","); 
                    //    args2 = args2.Substring(0, _index);
                    //    MessageBox.Show(args2);
                    //}

                    proexe = Process.Start(Application.StartupPath + @"\mzgh\GuXHisMzsfAndMzgh.exe", args); proexe.WaitForInputIdle();

                    intPtr = proexe.MainWindowHandle; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("客户端出错：" + ex.Message);
            }
        }

        public void CloseWinForm(object intPtr)
        {
            try
            {  
                proexe.CloseMainWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show("客户端出错：" + ex.Message);
            }
        }
    }
}
