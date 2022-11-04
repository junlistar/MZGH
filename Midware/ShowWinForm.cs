
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        public class LoginVM
        {
            public string Application { get; set; }
            public string SubsysRelativePath { get; set; }
            public string UserMi { get; set; }
        }

        public void SetRunParams(string args)
        {
            try
            {
                if (!string.IsNullOrEmpty(args))
                {

                    var _vm = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginVM>(args);

                    //MessageBox.Show(_vm.UserMi);
                    //MessageBox.Show(_vm.SubsysRelativePath);

                    proexe = Process.Start(_vm.SubsysRelativePath + @"\GuXHisMzsfAndMzgh.exe", _vm.UserMi); proexe.WaitForInputIdle();
                    intPtr = proexe.MainWindowHandle;

                    return;

                    
                   // var _key = "SubsysRelativePath";
                   // var _index = args.IndexOf("SubsysRelativePath");
                   //// MessageBox.Show(_index.ToString());
                   // if (_index > 0)
                   // {
                   //     var _args = args.Substring(_index + _key.Length+2);
                   //     _index = _args.IndexOf(",");

                   //     //MessageBox.Show(_args);
                   //     _args = _args.Substring(2, _index-3);//去掉收尾引号
                   //     //MessageBox.Show(_args);
                   //     MessageBox.Show(_args + @"\GuXHisMzsfAndMzgh.exe");

                   //     proexe = Process.Start(_args + @"\GuXHisMzsfAndMzgh.exe", args); proexe.WaitForInputIdle();
                   //     intPtr = proexe.MainWindowHandle;
                   // }
                   // else
                   // {
                   //     MessageBox.Show("没有获取到程序子目录");
                   // }
                   // return;

                    //proexe = Process.Start(Application.StartupPath + @"\mzgh\GuXHisMzsfAndMzgh.exe", args); proexe.WaitForInputIdle();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("客户端出错：" + ex.Message);
            }
        }
        /// <summary>
        /// 是否可以关闭WinForm
        /// </summary>
        /// <param name="aHandle"></param>
        /// <returns>0不能关闭，1可以关闭</returns>
        public int CanCloseWinForm(object aHandle)
        {
            if (MessageBox.Show("确定要关闭该系统吗？","提示", MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                return 1;
            }
            return 0;
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
