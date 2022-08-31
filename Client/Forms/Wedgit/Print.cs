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
    public partial class Print : Form
    {
        private static ILog log = LogManager.GetLogger(typeof(Print));//typeof放当前类

        public int _report_code;
        public string _printer;

        public Print(int report_code)
        {
            InitializeComponent();
            _report_code = report_code;
        }

        private void GhPrint_Load(object sender, EventArgs e)
        {
            InitializeReport("PRINT");
            this.Close();
        }

        public string FormID { get; set; } = "PRDT"; //单据ID
        //private string RptNo, RptName; //报表编号、名称
        //private DataTable RptTable; //数据表
        //private DataRow RptRow; //数据行(报表数据源)
        private bool isSaveAs = false; //另存为

        ReportDataVM rdvm;
        //初始化报表
        private void InitializeReport(string RptMode)
        {
            Task<HttpResponseMessage> task = null; var json = "";
            var paramurl = string.Format($"/api/GuaHao/GetReportDataByCode?code={_report_code}");

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

                #region 接口方式

                var report_data = System.Text.Encoding.UTF8.GetString(stream.ToArray());

                string paramurl = string.Format($"/api/GuaHao/UpdateReportDataByCode?code={_report_code}&report_com={report_data}");

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
                if (rdvm != null && rdvm.report_com.Length > 0)
                {
                    //byte[] ReportBytes = (byte[])RptRow["report_com"];
                    byte[] ReportBytes = System.Text.Encoding.UTF8.GetBytes(rdvm.report_com);
                    string sql = rdvm.report_sql;
                    using (MemoryStream Stream = new MemoryStream(ReportBytes))
                    {
                        TargetReport.Load(Stream);


                        #region 接口方式
                        //查询数据 
                        string paramurl = string.Format($"/api/GuaHao/GetReportParam?code={_report_code}");

                        log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                        var result = WebApiHelper.DeserializeObject<ResponseResult<List<ReportParamVM>>>(responseJson);
                        if (result.status == 1)
                        {
                            foreach (var item in result.data)
                            {
                                if (item.param_name == "patient_id")
                                {
                                    sql = sql.Replace(":" + item.param_name, "'"+ SessionHelper.patientVM.patient_id + "'");
                                }
                                else if (item.param_name == "ledger_sn")
                                {
                                    sql = sql.Replace(":" + item.param_name,  SessionHelper.sf_print_user_ledger.ToString());
                                }

                                //if (item.param_name == "report_date")
                                //{
                                //    sql = sql.Replace(":" + item.param_name, "'1900-01-01 00:00:00'");
                                //}
                                //else if (item.param_name == "price_opera")
                                //{
                                //    sql = sql.Replace(":" + item.param_name, "'" + SessionHelper.uservm.user_mi+ "'");
                                //}
                                //else if (item.param_name == "mz_dept_no")
                                //{
                                //    sql = sql.Replace(":" + item.param_name, "'1'");
                                //}

                            }
                        }
                        paramurl = string.Format($"/api/GuaHao/GetDateTableBySql?sql={sql}");

                        //log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                        var ds_result = WebApiHelper.DeserializeObject<ResponseResult<string>>(responseJson);
                        if (ds_result.status == 1)
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

                            //TargetReport.Design();
                        }
                        #endregion
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
                    if (!string.IsNullOrEmpty(_printer))
                    {
                        TargetReport.PrintSettings.Printer = _printer;
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
