using FastReport;
using FastReport.Design;
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

namespace FastReportClient
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public string code = "";
        public string sql = "";
        public string sname = "";
        public string lname = "";

        public static List<ReportParam> list;

        private void button1_Click(object sender, EventArgs e)
        {
            SelectReportFrom srf = new SelectReportFrom(this);
            srf.FormClosed += Srf_FormClosed;
            srf.ShowDialog();

            lblcode.Text = code;
            lblname.Text = sname;

        }

        private void Srf_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtsql.Text = sql;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(code))
            {
                //return;
            }
            var sql = txtsql.Text.Trim();

            if (string.IsNullOrWhiteSpace(sql))
            {
                MessageBox.Show("sql为空");
                return;
            }

            //查询文本中的参数
            var splitstr = ':';
            var param_count = sql.Split(splitstr);

            List<string> paramlist = new List<string>();

            int param_index = 0;


            do
            {
                param_index = sql.IndexOf(splitstr);
                if (param_index == -1)
                {
                    break;
                }
                sql = sql.Substring(param_index);
                var p1 = sql.IndexOf("\r\n");
                var p2 = sql.IndexOf(' ');
                var p3 = sql.IndexOf(')');

                var str = "";
                if (p1 != -1 && p2 != -1)
                {
                    if (p1 < p2)
                    {
                        str = sql.Substring(1, p1 - 1);
                    }
                    else
                    {
                        str = sql.Substring(1, p2 - 1);
                    }
                }
                else if (p1 != -1)
                {
                    str = sql.Substring(1, p1 - 1);
                }
                else if (p2 != -1)
                {
                    str = sql.Substring(1, p2 - 1);
                }
                else
                {
                    MessageBox.Show("数据库格式有误！"); break;
                }


                paramlist.Add(str);

                sql = sql.Substring(str.Length);
            } while (1 == 1);


            SetSelectParams ssp = new SetSelectParams();
            ssp.sname = sname;
            ssp.lname = lname;
            ssp.code = code;

            ssp.paralist = paramlist;


            if (ssp.ShowDialog() == DialogResult.OK)
            {
                var sel = txtsql.Text.Trim();


                //查询参数
                //string param_sql = $"select * from  rt_report_params_fast where report_code ={code}";
                //var dt_param = DbHelper.ExecuteDataTable(param_sql);

                //if (dt_param != null && dt_param.Rows.Count > 0)
                //{ 
                //    for (int i = 0; i < dt_param.Rows.Count; i++)
                //    {
                //        sel = sel.Replace(":" + dt_param.Rows[i]["param_name"].ToString(), "'" + dt_param.Rows[i]["param_defaultvalue"].ToString() + "'");
                //    } 
                //}

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        sel = sel.Replace(":" + item.param_name, "'" + item.param_defaultvalue + "'");
                    }

                }


                try
                {

                    var ds = DbHelper.GetDataSet(sel, "ghinfo");

                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public string FormID { get; set; } = "PRDT"; //单据ID
        private string RptNo, RptName; //报表编号、名称
        private DataTable RptTable; //数据表
        private DataRow RptRow; //数据行(报表数据源)
        private bool isSaveAs = false; //另存为
        //初始化报表
        private void InitializeReport(string RptMode)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                string sql = $"select * from rt_report_data_fast_net where report_code = {code}";
                DataSet Ds = DbHelper.GetDataSet(sql, "REPORT");

                RptTable = Ds.Tables[0];
                RptRow = RptTable.Rows[0];
            }
            else
            {

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
                if (string.IsNullOrWhiteSpace(code))
                {
                    int _code = int.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    string sql = $@"insert into rt_report_data_fast_net (report_code,short_name,long_name,report_sql,report_com,report_flag,datasetn)
values(?, ?, ?, ?,?, 1, 0)";
                    var para = new System.Data.OleDb.OleDbParameter[5];
                    para[0] = new System.Data.OleDb.OleDbParameter("p1", _code);
                    para[1] = new System.Data.OleDb.OleDbParameter("p2", "test");
                    para[2] = new System.Data.OleDb.OleDbParameter("p3", "test");
                    para[3] = new System.Data.OleDb.OleDbParameter("p4", txtsql.Text);
                    para[4] = new System.Data.OleDb.OleDbParameter("p5", stream.ToArray());
                    var result = DbHelper.ExecuteNonQuery(sql, para);
                }
                else
                {

                    string sql = $"update rt_report_data_fast_net set report_com=? where report_code = {code}";
                    var para = new System.Data.OleDb.OleDbParameter[1];
                    para[0] = new System.Data.OleDb.OleDbParameter("p1", stream.ToArray());
                    var result = DbHelper.ExecuteNonQuery(sql, para);

                }
                RegisterDesignerEvents();
            }
        }
        Report TargetReport;

        private void button3_Click(object sender, EventArgs e)
        {
            InitializeReport("DESIGN");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            InitializeReport("PREVIEW");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            InitializeReport("PRINT");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (code == "")
                {
                    return;
                }

                //保存sql和参数
                string sqltext = txtsql.Text.Trim();
                string sql1 = $"update rt_report_data_fast_net set report_sql=? where report_code=?";

                var para = new System.Data.OleDb.OleDbParameter[2];
                para[0] = new System.Data.OleDb.OleDbParameter("p1", sqltext);
                para[1] = new System.Data.OleDb.OleDbParameter("p2", int.Parse(code));
                var result = DbHelper.ExecuteNonQuery(sql1, para);


                //保存参数变化
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        if (item.report_code == -1)
                        {
                            //新增
                            string sql2 = $@"insert into rt_report_params_fast_net(report_code,param_name,param_label,param_type,param_defaultvalue,sqltag,sort_no)
                                    values({code},'{item.param_name}','{item.param_label.Trim()}','{item.param_type}','{item.param_defaultvalue}','{item.sqltag}','{item.sort_no}')";
                            result = DbHelper.ExecuteNonQuery(sql2);

                        }
                        else
                        {
                            //修改
                            string sql2 = $@"update rt_report_params_fast_net 
                                    set param_label='{item.param_label.Trim()}',param_defaultvalue='{item.param_defaultvalue}',
                                    sqltag='{item.sqltag}',param_type='{item.param_type}',sort_no='{item.sort_no}'
                                    where report_code={item.report_code} and  param_name='{item.param_name}'";
                            result = DbHelper.ExecuteNonQuery(sql2);
                        }
                    }
                }

                if (result > 0)
                {
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        } 

        private void DesignReport(string RptMode)
        {

            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("请选择报表");
                return;
            }

            try
            {

                TargetReport = new Report();

                TargetReport.FileName = RptMode;

                if (!string.IsNullOrEmpty(code) && RptRow["report_com"].ToString().Length > 0)
                {
                    byte[] ReportBytes = (byte[])RptRow["report_com"];
                    var str = RptRow["report_com"].ToString();
                     
                    //str1 = System.Text.Encoding.UTF8.GetString(ReportBytes);

                    string sql = RptRow["report_sql"].ToString();
                    using (MemoryStream Stream = new MemoryStream(ReportBytes))
                    {
                        TargetReport.Load(Stream);
                        //TargetReport.ReportResourceString=str1;

                        //查询参数
                        string param_sql = $"select * from  rt_report_params_fast_net where report_code = {code}";
                        var dt_param = DbHelper.ExecuteDataTable(param_sql);
                        if (dt_param != null && dt_param.Rows.Count > 0)
                        {
                            // var param = new System.Data.OleDb.OleDbParameter[dt_param.Rows.Count];

                            for (int i = 0; i < dt_param.Rows.Count; i++)
                            {
                                sql = sql.Replace(":" + dt_param.Rows[i]["param_name"].ToString(), "'" + dt_param.Rows[i]["param_defaultvalue"].ToString() + "'");
                            }
                            //param[0] = new System.Data.OleDb.OleDbParameter("p1", GuaHao.PatientVM.patient_id);
                            //var ds = DbHelper.GetDataSet(sql, "ghinfo", param);
                        }
                        var ds = DbHelper.GetDataSet(sql, "DataTable");
                        var ds2 = DbHelper.GetDataSet(sql, "DataTable2");


                        //var dt = ds.Tables[0].Copy();
                        //var ds2 = new DataSet();
                        //ds2.Tables.Add(dt);
                        //////ds2.Tables[0].TableName = ""

                        TargetReport.RegisterData(ds);
                        TargetReport.RegisterData(ds2);


                    }
                }
                else
                {
                    string sql = txtsql.Text;
                    //查询参数
                    string param_sql = $"select * from  rt_report_params_fast_net where report_code = {code}";
                    var dt_param = DbHelper.ExecuteDataTable(param_sql);
                    if (dt_param != null && dt_param.Rows.Count > 0)
                    {
                        // var param = new System.Data.OleDb.OleDbParameter[dt_param.Rows.Count];

                        for (int i = 0; i < dt_param.Rows.Count; i++)
                        {
                            sql = sql.Replace(":" + dt_param.Rows[i]["param_name"].ToString(), "'" + dt_param.Rows[i]["param_defaultvalue"].ToString() + "'");
                        }
                        //param[0] = new System.Data.OleDb.OleDbParameter("p1", GuaHao.PatientVM.patient_id);
                        //var ds = DbHelper.GetDataSet(sql, "ghinfo", param);
                    }
                    var ds = DbHelper.GetDataSet(sql, "DataTable");
                    TargetReport.Load(Application.StartupPath + @"\file\Untitled.frx");//这里是模板的路径

                    TargetReport.RegisterData(ds);


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
