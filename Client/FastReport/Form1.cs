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
            report.Preview = previewControl;
            report.Prepare();
            report.Show();
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            Preview(this.previewControl1);
        }

        public static Report CreateReportAndLoadFrx()
        { 
            Report report = new Report();

            report.Load(Application.StartupPath + @"\FastReport\file\gh_pay.frx");//这里是模板的路径

            return report;
        } 
    }
}
