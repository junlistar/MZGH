using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MainFrame.Common
{
    /// <summary>
    /// 嵌入外部exe
    /// </summary>
    public class EmbeddedExeTool
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);
        [DllImport("User32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        IntPtr WindowHandle = IntPtr.Zero;
        private const int WS_THICKFRAME = 262144;
        private const int WS_BORDER = 8388608;
        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0xC00000;
        private Process proApp = null;
        private Control ContainerControl = null;

        private const int WS_VISIBLE = 0x10000000;
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public enum SpecialWindowHandles
        {
            HWND_TOP = 0,
            HWND_BOTTOM = 1,
            HWND_TOPMOST = -1,
            HWND_NOTOPMOST = -2
        }
        [Flags]
        public enum SetWindowPosFlags : uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,

            SWP_DEFERERASE = 0x2000,

            SWP_DRAWFRAME = 0x0020,

            SWP_FRAMECHANGED = 0x0020,

            SWP_HIDEWINDOW = 0x0080,

            SWP_NOACTIVATE = 0x0010,

            SWP_NOCOPYBITS = 0x0100,

            SWP_NOMOVE = 0x0002,

            SWP_NOOWNERZORDER = 0x0200,

            SWP_NOREDRAW = 0x0008,

            SWP_NOREPOSITION = 0x0200,

            SWP_NOSENDCHANGING = 0x0400,

            SWP_NOSIZE = 0x0001,

            SWP_NOZORDER = 0x0004,

            SWP_SHOWWINDOW = 0x0040,
        }

        private IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }
        const int WM_CLOSE = 0x10;   //关闭
        public void CloseHandle(IntPtr Window_Handle)
        {
            SendMessage(Window_Handle, WM_CLOSE, 0, 0);   //关闭窗体
        }

        public void LoadHandle(IntPtr hWndChild, Control control)
        {
            try
            {
                IntPtr hWndNewParent = control.Handle;
                SetParent(hWndChild, hWndNewParent);
                // Remove border and whatnot               这句话会导致闪屏。。
                //SetWindowLong(new HandleRef(this, hWndChild), GWL_STYLE, WS_VISIBLE);

                ShowWindow(hWndChild, (int)ProcessWindowStyle.Maximized);
                MoveWindow(hWndChild, 0, 0, control.Width, control.Height, true);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载外部exe程序到程序容器中
        /// </summary>
        /// <param name="control">要显示exe的容器控件</param>
        /// <param name="exepath">exe的完整绝对路径</param>
        public void LoadEXE(Control control, string exepath, string args)
        {
            ContainerControl = control;
            control.SizeChanged += Control_SizeChanged;
            ProcessStartInfo info = new ProcessStartInfo(exepath);
            info.WindowStyle = ProcessWindowStyle.Minimized;
            info.UseShellExecute = false;
            info.CreateNoWindow = false; info.Arguments = args;
            proApp = Process.Start(info);// proApp.WaitForInputIdle();
            Application.Idle += Application_Idle;
            EmbedProcess(proApp, control);
        }
        string winname = "";
        /// <summary>
        /// 加载外部exe程序到程序容器中
        /// </summary>
        /// <param name="form">要显示exe的窗体</param>
        /// <param name="exepath">exe的完整绝对路径</param>
        public void LoadEXE(Form form, string exepath, string args, string windown_name = "")
        {
            winname = windown_name;
            ContainerControl = form;
            form.SizeChanged += Control_SizeChanged;
            proApp = new Process();
            proApp.StartInfo.UseShellExecute = false;
            proApp.StartInfo.CreateNoWindow = false;
            proApp.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            proApp.StartInfo.FileName = exepath;
            proApp.StartInfo.Arguments = args;// Process.GetCurrentProcess().Id.ToString();
            proApp.Start();
            //proApp.WaitForInputIdle();
            //System.Threading.Thread.Sleep(1000);

            if (!string.IsNullOrEmpty(winname) && winname == "mzgh")
            {
                Application.Idle += Application_Idle;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                Application.Idle += Application_Idle_ForDelphi;
            }

            EmbedProcess(proApp, form);

        }
        /// <summary>
        /// 确保应用程序嵌入此容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Idle(object sender, EventArgs e)
        {
            if (this.proApp == null || this.proApp.HasExited)
            {
                this.proApp = null;
                Application.Idle -= Application_Idle;
                return;
            }
            if (proApp.MainWindowHandle == IntPtr.Zero) return;
            Application.Idle -= Application_Idle;
            EmbedProcess(proApp, ContainerControl);
        } 

        private void Application_Idle_ForDelphi(object sender, EventArgs e)
        {
            if (this.proApp == null || this.proApp.HasExited)
            {
                this.proApp = null;
                Application.Idle -= Application_Idle_ForDelphi;
                return;
            }
            if (!string.IsNullOrEmpty(winname) && (winname == "mzxyf" || winname == "zyxyf"))
            { 
                IntPtr window = FindWindow(null, "药品管理系统");
                if (window == IntPtr.Zero) return; 
            } 
            Application.Idle -= Application_Idle;
            EmbedProcess(proApp, ContainerControl);
        }
        /// <summary>
        /// 将指定的程序嵌入指定的控件
        /// </summary>
        private void EmbedProcess(Process app, Control control)
        {
            // Get the main handle  || app.MainWindowHandle == IntPtr.Zero
            if (app == null || control == null) return;// IntPtr.Zero;
            try
            {
                IntPtr window;
                if (!string.IsNullOrEmpty(winname) && (winname == "mzxyf" || winname == "zyxyf"))
                {
                    window = FindWindow(null, "药品管理系统");
                    Main.clientDic[SessionHelper.current_index] = window;
                    // Put it into this form
                    MoveWindow(window, 0, 0, control.Width, 500, true);
                    SetWindowPos(window, new IntPtr((int)SpecialWindowHandles.HWND_TOP), 10, 10, 450, 450, SetWindowPosFlags.SWP_SHOWWINDOW);
                    SetParent(window, control.Handle);

                }
                else
                {
                    window = app.MainWindowHandle;
                    Main.clientDic[SessionHelper.current_index] = window;
                    // Put it into this form
                    SetParent(window, control.Handle);
                    SetWindowLong(new HandleRef(this, window), GWL_STYLE, WS_VISIBLE);
                    ShowWindow(window, (int)ProcessWindowStyle.Maximized);
                    MoveWindow(window, 0, 0, control.Width, control.Height, true);
                }
                //Main.clientDic[SessionHelper.current_index] = window;
                // Put it into this form
                //SetParent(window, control.Handle);
                
                // Remove border and whatnot               
                //SetWindowLong(new HandleRef(this, window), GWL_STYLE, WS_VISIBLE); 
                //ShowWindow(window, (int)ProcessWindowStyle.Maximized);
                //ShowWindow(window, (int)ProcessWindowStyle.Minimized);
                //ShowWindow(window, (int)ProcessWindowStyle.Maximized);
                ////MoveWindow(window, 0, 0, control.Width, control.Height, true);
                // return window;


            }
            catch (Exception ex3)
            {
                Console.WriteLine(ex3.Message);
            }
           // return IntPtr.Zero;
        }
        /// <summary>
        /// 嵌入容器大小改变事件
        /// </summary>
        private void Control_SizeChanged(object sender, EventArgs e)
        {
            if (proApp == null)
            {
                return;
            }

            if (proApp.MainWindowHandle != IntPtr.Zero && ContainerControl != null)
            {
                MoveWindow(proApp.MainWindowHandle, 0, 0, ContainerControl.Width, ContainerControl.Height, true);
            }
        }
        public static string SerializeObject(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer(); jss.MaxJsonLength = int.MaxValue;
            try
            {
                return jss.Serialize(obj);
            }
            catch (Exception ex)
            {
                //LogHelper.Error("JSONHelper.SerializeObject 转换对象失败。", ex);
                throw new Exception("JSONHelper.SerializeObject(object obj): " + ex.Message);
            }
        }
    }
}
