using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Client.ViewModel;
using System.Net.Http;
using System.Configuration;
using Client.ClassLib;
using System.Net.Http.Headers;
using log4net; 
using System.Drawing.Printing;
using FastReport;
using Client.FastReportLib;
using System.Runtime.InteropServices;
using System.Reflection;
using FastReport.Utils;
using MyMzghLib;
using FastReport.Design;
using System.IO;

namespace Client.Forms.Wedgit
{
    public partial class GhPrint : Form
    {
        private static ILog log = LogManager.GetLogger(typeof(GhPrint));//typeof放当前类

        public string patient_id;
        public string times;

        public GhPrint()
        {
            InitializeComponent();
        }

        private void GhPrint_Load(object sender, EventArgs e)
        {
           // GetPatientInfo();
            InitializeReport("PRINT");
            this.Close();
        }

        //public void GetPatientInfo()
        //{
        //    string paramurl = string.Format($"/api/GuaHao/GetPatientByPatientId?pid={GuaHao.PatientVM.patient_id}");

        //    log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
        //    string responseJson = HttpClientUtil.Get(paramurl);

        //    var result = WebApiHelper.DeserializeObject<ResponseResult<List<PatientVM>>>(responseJson);

        //    patientVM = result.data[0];
        //}

        public string FormID { get; set; } = "PRDT"; //单据ID
        //private string RptNo, RptName; //报表编号、名称
        //private DataTable RptTable; //数据表
        //private DataRow RptRow; //数据行(报表数据源)
        private bool isSaveAs = false; //另存为

        ReportDataVM rdvm;
        //初始化报表
        private void InitializeReport(string RptMode)
        {
            //string sql = "select * from rt_report_data_fast_net where report_code = 220001";
            //DataSet Ds = DbHelper.GetDataSet(sql, "REPORT");


            Task<HttpResponseMessage> task = null; var json = "";
            var paramurl = string.Format($"/api/GuaHao/GetReportDataByCode?code={SessionHelper.mzgh_report_code}");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
            task = SessionHelper.MyHttpClient.GetAsync(paramurl);
            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            else
            {
                log.Info(response.ReasonPhrase);
            }

            var resp = WebApiHelper.DeserializeObject<ResponseResult<ReportDataVM>>(json);

            if (resp.status == 1)
            {
                rdvm = resp.data;
            }
            else
            {
                MessageBox.Show(resp.message);
                log.Error(resp.message);
                return;
            } 
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
                //解决多次保存问题
                Config.DesignerSettings.CustomSaveDialog -= new OpenSaveDialogEventHandler(DesignerSettings_CustomSaveDialog);
                Config.DesignerSettings.CustomSaveReport -= new OpenSaveReportEventHandler(DesignerSettings_CustomSaveReport);

                //保存 
                TargetReport.Save(stream);

                #region sql直连
                //string sql = @"update rt_report_data_fast_net set report_com=? where report_code = 220001";
                //var para = new System.Data.OleDb.OleDbParameter[1];
                //para[0] = new System.Data.OleDb.OleDbParameter("p1", stream.ToArray());
                //var result = DbHelper.ExecuteNonQuery(sql, para);
                #endregion

                #region 接口方式

                var report_data = System.Text.Encoding.UTF8.GetString(stream.ToArray());

                string paramurl = string.Format($"/api/GuaHao/UpdateReportDataByCode?code={SessionHelper.mzgh_report_code}&report_com={report_data}");

                log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                var result = WebApiHelper.DeserializeObject<ResponseResult<int>>(responseJson);

                if (result.status == 1)
                {
                    log.Info("保存报表成功");
                }
                else
                {
                    log.Error(result.message);
                }
                #endregion

            }
        }
        Report TargetReport;
        private void DesignReport(string RptMode)
        {
            try
            {

                TargetReport = new Report();

                TargetReport.FileName = RptMode;
                // if (RptRow["report_com"].ToString().Length > 0)
                if (rdvm != null && rdvm.report_com.Length > 0)
                {
                    //byte[] ReportBytes = (byte[])RptRow["report_com"];
                    byte[] ReportBytes = System.Text.Encoding.UTF8.GetBytes(rdvm.report_com);
                    string sql = rdvm.report_sql;
                    using (MemoryStream Stream = new MemoryStream(ReportBytes))
                    {
                        TargetReport.Load(Stream); 

                        string paramurl = string.Format($"/api/cwgl/GetMzghBill?code={SessionHelper.mzgh_report_code}&patient_id={patient_id}&times={times}");

                        log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        var responseJson = HttpClientUtil.Get(paramurl);
                        var ds_result = WebApiHelper.DeserializeObject<ResponseResult<string>>(responseJson);
                        if (ds_result.status == 1)
                        {
                            if (ds_result.data != "[]")
                            {
                                var jsontb = ds_result.data;
                                var dt = DataTableHelper.ToDataTable(jsontb);
                                var dataset = new DataSet();
                                dataset.Tables.Add(dt);
                                dataset.Tables[0].TableName = "DataTable";
                                TargetReport.RegisterData(dataset);

                                var dataset2 = dataset.Copy();
                                dataset2.Tables[0].TableName = "DataTable2";
                                TargetReport.RegisterData(dataset2);
                            }
                            else
                            {
                                UIMessageTip.Show("该报表无数据");
                            }
                        }
                         
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
                    if (!string.IsNullOrWhiteSpace(SessionHelper.gh_printer))
                    {
                        TargetReport.PrintSettings.Printer = SessionHelper.gh_printer; 
                    }
                    TargetReport.Print();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }
    }
}
