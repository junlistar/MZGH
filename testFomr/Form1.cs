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
            Process proexe = Process.Start(Application.StartupPath + @"\Client.exe", _str);
        }
       
    }
}
