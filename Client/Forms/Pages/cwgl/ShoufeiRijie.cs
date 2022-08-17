using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using FastReport;
using FastReport.Utils;
using MyMzghLib;
using FastReport.Design;
using log4net;
using Sunny.UI;
using System.Drawing;

namespace Client.Forms.Pages.cwgl
{
    public partial class ShoufeiRijie : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(GuahaoRijie));//typeof放当前类

        public Color sel_color = Color.FromArgb(230, 80, 80);
        public string _searchKey = "hzrb";
        public int _report_code;

        public ShoufeiRijie()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuahaoRijie_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;

            btn_hzrb.FillColor = sel_color;

            _report_code = SessionHelper.sfrj_report_code;

            btnSave.Enabled = false;

            //previewControl1.Hide();

            pnlReport.Text = "选择日期时间，进行预览和结算操作";

        }

        /// <summary>
        /// 查询
        /// </summary>
        public void GetMzsfReport()
        {
            try
            {

                //查询当日扎帐记录  GetMzsfReport(string opera, string report_date)
                //ResponseResult<List<string>> GetGhDailyReport(string opera, string report_date, string mz_dept_no)
                var d = new
                {
                    opera = SessionHelper.uservm.user_mi,
                    report_date = txtDate.Value.ToShortDateString(),
                    mz_dept_no = "1"
                };

                var param = $"opera={d.opera}&report_date={d.report_date}";
                 
                var paramurl = string.Format($"/api/cwgl/GetMzsfReport?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<string>>>(json);
                cbxStatus.Items.Clear();
                if (result.status == 1)
                {
                    cbxStatus.Items.Add("未结");
                    foreach (var item in result.data)
                    {
                        if (item == null)
                        {
                            cbxStatus.Items.Add("未结");
                        }
                        else
                        {
                            var dt_text = Convert.ToDateTime(item).ToString("yyyy-MM-dd HH:mm:ss");
                            cbxStatus.Items.Add(dt_text);
                        }
                    }
                    cbxStatus.SelectedIndex = cbxStatus.Items.Count - 1;

                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
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
            try
            { 
                var paramurl = string.Format($"/api/GuaHao/GetReportDataByCode?code={_report_code}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string json = HttpClientUtil.Get(paramurl);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
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
                                if (item.param_name == "report_date")
                                {
                                    sql = sql.Replace(":" + item.param_name, "'1900-01-01 00:00:00'");
                                }
                                else if (item.param_name == "price_opera")
                                {
                                    sql = sql.Replace(":" + item.param_name, "'" + SessionHelper.uservm.user_mi + "'");
                                }
                                else if (item.param_name == "mz_dept_no")
                                {
                                    sql = sql.Replace(":" + item.param_name, "'1'");
                                }
                            }
                        }
                        var report_date = cbxStatus.SelectedText;
                        var cash_date = txtDate.Text;
                        if (report_date == "未结")
                        {
                            report_date = "1900-01-01 00:00:00";
                        }
                        else
                        {
                            cash_date = "6008-01-01";
                        }

                        paramurl = string.Format($"/api/cwgl/GetMzsfDailyByReportCode?code={_report_code}&report_date={report_date}&price_opera={SessionHelper.uservm.user_mi}&cash_date={cash_date}");

                        log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
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

                                //TargetReport.Design();
                                if (report_date == "1900-01-01 00:00:00")
                                {
                                    btnSave.Enabled = true;
                                }

                                previewControl1.Show();
                                TargetReport.Preview = previewControl1;
                                TargetReport.Prepare();
                                TargetReport.Show();

                            }
                            else
                            {
                                pnlReport.Text = "该报表无数据";
                                UIMessageTip.Show("该报表无数据");
                            }

                        }
                        else
                        {
                            MessageBox.Show(ds_result.message);
                            log.Error(ds_result.message);
                        }
                        #endregion
                    }
                }
                ////操作方式：DESIGN-设计;PREVIEW-预览;PRINT-打印
                //if (RptMode == "DESIGN")
                //{
                //    TargetReport.Design();
                //}
                //else if (RptMode == "PREVIEW")
                //{
                //    TargetReport.Prepare();
                //    TargetReport.ShowPrepared();
                //}
                //else if (RptMode == "PRINT")
                //{
                //    TargetReport.Print();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var d = new
                {
                    opera = SessionHelper.uservm.user_mi,
                    cash_date = txtDate.Text,
                };
                var param = $"opera={d.opera}&cash_date={d.cash_date}";

                var json = "";
                var paramurl = string.Format($"/api/cwgl/SaveMzsfDaily?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                var task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                if (result.status == 1 && result.data)
                {
                    UIMessageTip.ShowOk("保存成功");

                    //查询日结记录
                    GetMzsfReport();
                    previewControl1.Hide();
                    previewControl1.Clear();
                    InitializeReport("PREVIEW");
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            previewControl1.Hide();
            previewControl1.Clear();

            LoadingHelper.ShowLoadingScreen();//显示

            InitializeReport("PREVIEW");

            LoadingHelper.CloseForm();//关闭
        }

        private void txtDate_ValueChanged(object sender, DateTime value)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (TargetReport != null)
                {
                    TargetReport.Print();
                }
                else
                {
                    UIMessageTip.Show("请选择日期，预览后操作！");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;
            previewControl1.Clear();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            //查询日结记录
            GetMzsfReport();
        }
    }
}
