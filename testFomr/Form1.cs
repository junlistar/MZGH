using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using System.Security.Principal;

namespace testFomr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _str = this.textBox1.Text;//"{'UserName':'super','UserMi':'00000'}"
            TestHisVM vM = new TestHisVM();
            vM.Application = "75415424";
            vM.Screen = "75349424";
            vM.AppServer = "10.102.38.225";
            vM.UserMi = "00000"; 

            var jso = SerializeObject(vM);
           // jso = jso.Replace("\"", "\\\"");
            _str = jso;
            this.textBox1.Text = _str;
            MessageBox.Show(_str);

            Process proexe = Process.Start(Application.StartupPath + @"\Client.exe", _str);
        }
        public class TestHisVM
        {
            public string Application { get; set; }
            public string Screen { get; set; }
            public string UserMi { get; set; }
            public string AppServer { get; set; }
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
         
        private void button2_Click(object sender, EventArgs e)
        {
            var _str = this.textBox1.Text;//"{'UserName':'super','UserMi':'00000'}"

            TestHisVM vM = new TestHisVM();
            vM.Application = "75415424";
            vM.Screen = "75349424";
            vM.AppServer = "10.102.38.225";
            vM.UserMi = "00000";

            var jso = SerializeObject(vM);
            jso = jso.Replace("\"", "\\\"");
            _str = jso;


            this.textBox1.Text = _str;

            MessageBox.Show(_str);
            Process proexe = Process.Start(Application.StartupPath + @"\GuXHisMzsfAndMzgh.exe", _str);

            MessageBox.Show(proexe.Handle.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterDll();
        }

        private bool RegisterDll()
        {
            bool result = true;
            try
            {
                string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GuXHisMzsfAndMzgh.dll");//获得要注册的dll的物理路径
                if (!File.Exists(dllPath))
                {
                    //Loger.Write(string.Format("“{0}”目录下无“XXX.dll”文件！", AppDomain.CurrentDomain.BaseDirectory));
                    MessageBox.Show(string.Format("“{0}”目录下无“GuXHisMzsfAndMzgh.dll”文件！", AppDomain.CurrentDomain.BaseDirectory));
                    return false;
                }
                //拼接命令参数
                string startArgs = string.Format("/s '{0}'", dllPath);

                Process p = new Process();//创建一个新进程，以执行注册动作
                p.StartInfo.FileName = "regsvr32";
                p.StartInfo.Arguments = startArgs;

                //以管理员权限注册dll文件
                WindowsIdentity winIdentity = WindowsIdentity.GetCurrent(); //引用命名空间 System.Security.Principal
                WindowsPrincipal winPrincipal = new WindowsPrincipal(winIdentity);
                if (!winPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    p.StartInfo.Verb = "runas";//管理员权限运行
                }
                p.Start();
                p.WaitForExit();
                p.Close();
                p.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
                //记录日志，抛出异常
            }
            MessageBox.Show("执行完毕");

            return result;
        }
    }
}
