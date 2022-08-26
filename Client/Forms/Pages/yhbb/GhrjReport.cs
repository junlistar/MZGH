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
using log4net;
using Client.ClassLib;
using Client.ViewModel;
using FastReport;
using FastReport.Utils;
using System.Net.Http;
using System.IO;

namespace Client.Forms.Pages.yhbb
{
    public partial class GhrjReport : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(GhrjReport));//typeof放当前类
        public GhrjReport()
        {
            InitializeComponent();
        }
        public int _report_code;
        string report_date;
        string opera;

        UIDataGridView dgvghy = new UIDataGridView();

        private void txtGhUser_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.dgvghy.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgvghy.Rows.Count > 0)
                    {

                        var unit_sn = dgvghy.Rows[0].Cells["code"].Value.ToString();
                        var name = dgvghy.Rows[0].Cells["name"].Value.ToString();

                        txtGhUser.TextChanged -= txtGhUser_TextChanged;
                        txtGhUser.Text = name;
                        txtGhUser.TagString = unit_sn;

                        GetOperateTime();

                        txtGhUser.TextChanged += txtGhUser_TextChanged;

                        dgvghy.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }
        private void Dgvghy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvghy.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvghy.SelectedIndex);

                    dgvghy_CellContentClick(sender, ev);
                }
            }
        }
        private void txtGhUser_Leave(object sender, EventArgs e)
        {
            if (!dgvghy.Focused)
            {
                dgvghy.Hide();
            }
        }

        private void txtGhUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtGhUser.Text == "")
                {
                    return;
                }

                // 查询信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIPanel;
                //获取数据 

                if (SessionHelper.userDics != null && SessionHelper.userDics.Count > 0)
                {
                    var ipt = txtGhUser.Text.Trim();

                    dgvghy.Parent = this;
                    dgvghy.Top = pbl.Top + tb.Top + tb.Height;
                    dgvghy.Left = pbl.Left + tb.Left;
                    dgvghy.Width = tb.Width;
                    dgvghy.Height = 200;
                    dgvghy.BringToFront();
                    dgvghy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvghy.RowHeadersVisible = false;
                    dgvghy.BackgroundColor = Color.White;
                    dgvghy.ReadOnly = true;


                    List<UserDicVM> vm = SessionHelper.userDics;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgvghy.DataSource = vm;

                    dgvghy.Columns["code"].HeaderText = "编号";
                    dgvghy.Columns["name"].HeaderText = "名称";
                    dgvghy.Columns["py_code"].Visible = false;
                    dgvghy.Columns["d_code"].Visible = false;
                    dgvghy.Columns["emp_sn"].Visible = false;
                    dgvghy.AutoResizeColumns();

                    dgvghy.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }
        private void dgvghy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                var obj = sender as UIDataGridView;
                var unit_sn = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
                var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtGhUser.TextChanged -= txtGhUser_TextChanged;
                txtGhUser.Text = name;
                txtGhUser.TagString = unit_sn;
                txtGhUser.TextChanged += txtGhUser_TextChanged;

                dgvghy.Hide();

                GetOperateTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }
        private void GhrjReport_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;
            _report_code = SessionHelper.ghrj_report_code;

            txtDate.ValueChanged += TxtDate_ValueChanged;

            dgvghy.CellClick += dgvghy_CellContentClick;
            dgvghy.KeyDown += Dgvghy_KeyDown;
        }

        private void TxtDate_ValueChanged(object sender, DateTime value)
        {
            GetOperateTime();
        }

        public void GetOperateTime()
        {
            try
            {
                var opera = txtGhUser.TagString;

                if (string.IsNullOrEmpty(opera))
                {
                    return;
                }

                //查询当日扎帐记录
                var d = new
                {
                    opera = opera,
                    report_date = txtDate.Text,
                    mz_dept_no = "1"
                };

                var param = $"opera={d.opera}&report_date={d.report_date}&mz_dept_no={d.mz_dept_no}";

                var paramurl = string.Format($"/api/cwgl/GetGhDailyReport?{param}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                var json = HttpClientUtil.Get(paramurl);
                var result = WebApiHelper.DeserializeObject<ResponseResult<List<string>>>(json);
                cbxStatus.Items.Clear();
                if (result.status == 1)
                {
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
                    cbxStatus.SelectedIndex = result.data.Count - 1;

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

            report_date = cbxStatus.SelectedText;
            if (report_date == "未结")
            {
                UIMessageTip.Show("没有结算日期"); return;
            }
            if (txtGhUser.Text == "")
            {
                UIMessageTip.Show("请选择操作员"); return;
            }
            opera = txtGhUser.TagString;

            previewControl1.Hide();
            previewControl1.Clear();


            LoadingHelper.ShowLoadingScreen();//显示

            InitializeReport("PREVIEW");

            LoadingHelper.CloseForm();//关闭
        }


        
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
            DesignReport(RptMode);
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
                        paramurl = string.Format($"/api/cwgl/GetGhDailyByReportCode?code={_report_code}&report_date={report_date}&price_opera={opera}&mz_dept_no={"1"}");
                        //paramurl = string.Format($"/api/GuaHao/GetDateTableBySql?sql={sql}");

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
                    TargetReport.PrintSettings.Printer = SessionHelper.jsbb_printer;
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

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TargetReport != null)
                {
                    TargetReport.PrintSettings.Printer = SessionHelper.jsbb_printer;
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
    }
}
