using FastReport;
using FastReport.Preview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.FastReportLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public static void Preview(PreviewControl previewControl)
        {
            var report = CreateReportAndLoadFrx();
            //report.Preview = previewControl;
            report.Prepare();
            //report.Show();
            report.Print();
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            Preview(this.previewControl1);
        }

        public static Report CreateReportAndLoadFrx()
        { 
            Report report = new Report();

           report.Load(Application.StartupPath + @"\FastReport\file\gh_pay.frx");//这里是模板的路径
            //report.Load(Application.StartupPath + @"\FastReport\file\test.frx");//这里是模板的路径

            report.SetParameterValue("lbl_cardno", "9999999999");
            report.SetParameterValue("lbl_name", "尼古拉斯，咆哮");
            report.SetParameterValue("lbl_age", "尼古拉斯，咆哮\r\n99\r\n9999999999");
            report.SetParameterValue("lbl_prit_time", DateTime.Now.ToShortDateString());

            var p = report.GetParameter("lbl_cardno");
            p.Value = "aaaaaaaa";
            report.SetParameterValue("pid", "000296903300");
            report.SetParameterValue("record_sn", "4399359");


            return report;
        } 
    }
}
