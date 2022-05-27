using FastReport;
using FastReport.Design;
using FastReport.Preview;
using FastReport.Utils;
using MyMzghLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.FastReportLib
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }
        public string FormID { get; set; } = "PRDT"; //单据ID
        private string RptNo, RptName; //报表编号、名称
        private DataTable RptTable; //数据表
        private DataRow RptRow; //数据行(报表数据源)
        private bool isSaveAs = false; //另存为
        //初始化报表
        private void InitializeReport(string RptMode)
        {
            // DataSet Ds = mymeans.GetDataSet("SELECT RPT_NO,RPT_NAME,FILEDATA FROM AT_REPORT WHERE FORMID='" + FormID + "' AND RPT_NO='" + RptNo + "'", "REPORT");
            string sql = "select * from rt_report_data_fast where report_code = 5555";
            DataSet Ds = DbHelper.GetDataSet(sql, "REPORT");

            RptTable = Ds.Tables[0];
            RptRow = RptTable.Rows[0];
            RegisterDesignerEvents();
            DesignReport(RptMode);
        }
        //菜单事件注册
        private void RegisterDesignerEvents()
        {
            Config.DesignerSettings.CustomSaveDialog += new OpenSaveDialogEventHandler(DesignerSettings_CustomSaveDialog);
            Config.DesignerSettings.CustomSaveReport += new OpenSaveReportEventHandler(DesignerSettings_CustomSaveReport);
        }
        //保存菜单：对话框
        private void DesignerSettings_CustomSaveDialog(object sender, OpenSaveDialogEventArgs e)
        {
            isSaveAs = true;
        }
        //保存菜单：委托函数
        private void DesignerSettings_CustomSaveReport(object sender, OpenSaveReportEventArgs e)
        {
            //SaveReport(e.Report);
            using (MemoryStream stream = new MemoryStream())
            {
                //保存 
                TargetReport.Save(stream);

                string sql = @"update rt_report_data_fast set report_com=? where report_code = 5555";
                var para = new System.Data.OleDb.OleDbParameter[1] ;
                para[0] = new System.Data.OleDb.OleDbParameter("p1", stream.ToArray());
                var result = DbHelper.ExecuteNonQuery(sql, para);

               

            }
        }
        Report TargetReport;
        private void DesignReport(string RptMode)
        {
            try
            {

                TargetReport = new Report();

                TargetReport.FileName = RptMode;
                if (RptRow["report_com"].ToString().Length > 0)
                {
                    byte[] ReportBytes = (byte[])RptRow["report_com"];
                    using (MemoryStream Stream = new MemoryStream(ReportBytes))
                    {
                        TargetReport.Load(Stream);


                        string sql = @"select top 5 patient_id,name from mz_patient_mi order by patient_id desc";
                        var ds = DbHelper.GetDataSet(sql, "xt");
                        TargetReport.RegisterData(ds);
                    }
                }
                //操作方式：DESIGN-设计;PREVIEW-预览;PRINT-打印
                if (RptMode == "DESIGN")
                {
                    TargetReport.Design();
                }
                else if (RptMode == "PREVIEW")
                {
                    TargetReport.Prepare();
                    TargetReport.ShowPrepared();
                }
                else if (RptMode == "PRINT")
                {
                    TargetReport.Print();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            //
            //string sql = "select * form rt_report_data_fast where report_code = 1";
            //var dt = DbHelper.ExecuteDataTable(sql);
            //dataGridView1.DataSource = dt;


            InitializeReport("DESIGN");

            //Preview(this.previewControl1);

            //var report = CreateReportAndLoadFrx();
            ////report.Preview = previewControl;
            //report.Prepare();
            ////report.Show();
            //report.Print();

            //report.Save("aaa.xml");
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
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
