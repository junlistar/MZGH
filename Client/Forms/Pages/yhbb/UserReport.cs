using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using FastReport;
using FastReport.Design;
using FastReport.Utils;
using log4net;
using Sunny.UI;

namespace Client.Forms.Pages.yhbb
{
    public partial class UserReport : UIPage
    {

        private static ILog log = LogManager.GetLogger(typeof(UserReport));//typeof放当前类

        public UserReport()
        {
            InitializeComponent();
        }
        string _report_code;
        List<ReportParamVM> reportParamVMs;

        public void InitUserReportsData(string user_group)
        {
            try
            {
                var d = new
                {
                    subsys_id = "mz_new",
                    user_group = user_group
                };

                var param = $"subsys_id={d.subsys_id}&user_group={d.user_group}";
                 
                var json = "";
                var paramurl = string.Format($"/api/qxgl/GetXTUserReportsByGroupId?{param}");

                if (SessionHelper.uservm.user_mi == "00000")
                { 
                    param = $"subsys_id={d.subsys_id}"; 
                    paramurl = string.Format($"/api/qxgl/GetXTUserReports?{param}");
                }

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<XTUserReportVM>>>(json);
                tv_reports.Nodes.Clear();
                if (result.status == 1)
                {
                    foreach (var item in result.data)
                    {
                        if (item.parent_id == null || result.data.Where(p => p.rep_id == item.parent_id).Count() == 0)
                        {
                            tv_reports.Nodes.Add(item.rep_id, item.rep_name,item.report_code);

                        }
                    }
                    if (tv_reports.Nodes.Count > 0)
                    {
                        LoadSubItems(tv_reports.Nodes, result.data);

                        tv_reports.ExpandAll();
                        tv_reports.SelectedNode = tv_reports.Nodes[0];
                    }
                    tv_reports.AfterSelect -= tv_reports_AfterSelect;
                    tv_reports.AfterSelect += tv_reports_AfterSelect;
                    tv_reports.SelectedNode = null;
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public void LoadSubItems(TreeNodeCollection treeNodeCollection, List<XTUserReportVM> data)
        {

            foreach (TreeNode node in treeNodeCollection)
            {
                var items = data.Where(p => p.parent_id == node.Name).ToList();
                if (items != null && items.Count > 0)
                {
                    foreach (var subitem in items)
                    {
                        node.Nodes.Add(subitem.rep_id, subitem.rep_name, subitem.report_code);
                    }
                    LoadSubItems(node.Nodes, data);
                }
            }
        }

        private void UserReport_Initialize(object sender, EventArgs e)
        {
            InitUserReportsData(SessionHelper.uservm.user_group);
        }

        private void tv_reports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tv_reports.SelectedNode.ImageKey))
                {
                    return;
                }

                lblTitle.Text = $"{tv_reports.SelectedNode.Text}";
                lblpnltile.Text = $"报表编号：{tv_reports.SelectedNode.ImageKey}";

                uiPanel1.Text= $"{tv_reports.SelectedNode.Text}";

                _report_code = tv_reports.SelectedNode.ImageKey;

                //SetDefaultParams();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetDefaultParams()
        {
            try
            {
                string paramurl = string.Format($"/api/GuaHao/GetReportParam?code={_report_code}");
                log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<ReportParamVM>>>(responseJson);
                reportParamVMs = result.data;
                switch (_report_code)
                {
                    case "220001":
                        lbl_times.Text = "挂号次数";
                        foreach (var item in reportParamVMs)
                        {
                            if (item.param_name == "patient_id")
                            {
                                txt_patientid.Text = item.param_defaultvalue;
                            }
                            else if (item.param_name == "times")
                            {
                                txt_tims.Text = item.param_defaultvalue;
                            }
                        }
                        break;
                    case "220007":
                        lbl_times.Text = "缴费次数";
                        foreach (var item in result.data)
                        {
                            if (item.param_name == "patient_id")
                            {
                                txt_patientid.Text = item.param_defaultvalue;
                            }
                            else if (item.param_name == "ledger_sn")
                            {
                                txt_tims.Text = item.param_defaultvalue;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_reports_Click(object sender, EventArgs e)
        {
            //无效事件
        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_report_code))
            {
                UIMessageTip.Show("请选择报表进行查询");
                return;
            }

            previewControl1.Hide();
            previewControl1.Clear();

            //LoadingHelper.ShowLoadingScreen();//显示

            InitializeReport("PREVIEW");

            //LoadingHelper.CloseForm();//关闭
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
            var paramurl = string.Format($"/api/GuaHao/GetReportDataByCode?code={_report_code}");
            var json = HttpClientUtil.Get(paramurl);
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
                        ////查询数据 
                        //string paramurl = string.Format($"/api/GuaHao/GetReportParam?code={_report_code}");

                        //log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        //string responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
                        //var result = WebApiHelper.DeserializeObject<ResponseResult<List<ReportParamVM>>>(responseJson);
                        //if (result.status == 1)
                        if (reportParamVMs != null)
                        {
                            foreach (var item in reportParamVMs)
                            {
                                //if (item.param_name == "report_date")
                                //{
                                //    sql = sql.Replace(":" + item.param_name, "'1900-01-01 00:00:00'");
                                //}
                                //else if (item.param_name == "price_opera")
                                //{
                                //    sql = sql.Replace(":" + item.param_name, "'" + SessionHelper.uservm.user_mi + "'");
                                //}
                                //else if (item.param_name == "mz_dept_no")
                                //{
                                //    sql = sql.Replace(":" + item.param_name, "'1'");
                                //}
                                if (_report_code == "220001")
                                {

                                    if (item.param_name == "patient_id")
                                    {
                                        sql = sql.Replace(":" + item.param_name, "'" + txt_patientid.Text + "'");
                                    }
                                    else if (item.param_name == "times")
                                    {
                                        sql = sql.Replace(":" + item.param_name, "'" + txt_tims.Text + "'");
                                    }
                                }
                                else if (_report_code == "220007")
                                {
                                    if (item.param_name == "patient_id")
                                    {
                                        sql = sql.Replace(":" + item.param_name, "'" + txt_patientid.Text + "'");
                                    }
                                    else if (item.param_name == "ledger_sn")
                                    {
                                        sql = sql.Replace(":" + item.param_name, "'" + txt_tims.Text + "'");
                                    }
                                }
                            }
                        }

                        //paramurl = string.Format($"/api/cwgl/GetGhDailyByReportCode?code={_report_code}&report_date={report_date}&price_opera={SessionHelper.uservm.user_mi}&mz_dept_no={"1"}");
                        var paramurl = string.Format($"/api/GuaHao/GetDateTableBySql?sql={sql}");

                        log.Info("接口：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                        var responseJson = SessionHelper.MyHttpClient.PostAsync(paramurl, null).Result.Content.ReadAsStringAsync().Result;
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
                                previewControl1.Show();
                                TargetReport.Preview = previewControl1;
                                TargetReport.Prepare();
                                TargetReport.Show();
                            }
                            else
                            {
                                MessageBox.Show("该报表无数据");
                            }

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
                    UIMessageTip.Show("请选择报表，预览后操作！");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }

}
