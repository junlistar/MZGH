using MyMzghLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastReportClient
{

    public partial class SetSelectParams : Form
    {
        public SetSelectParams()
        {
            InitializeComponent();
        }

        public string code = "";
        public string sname = "";
        public string lname = "";
        public List<string> paralist = new List<string>();

        //数据集合
        List<ReportParam> list;

        private void SetSelectParams_Load(object sender, EventArgs e)
        {
            txtsname.Text = sname;
            txtlname.Text = lname;

            if (!string.IsNullOrWhiteSpace(code))
            {
                //search
                //查询参数
                string param_sql = $"select * from  rt_report_params_fast_net where report_code ={code}";
                var dt_param = DbHelper.ExecuteDataTable(param_sql);

                list = new List<ReportParam>();

                foreach (var item in paralist)
                {
                    bool isExist = false;
                    if (dt_param != null && dt_param.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_param.Rows.Count; i++)
                        {
                            var name = dt_param.Rows[i]["param_name"];
                            if (name != null && name.ToString() == item)
                            {
                                ReportParam rp = new ReportParam();
                                rp.report_code = int.Parse(code);
                                rp.param_name = dt_param.Rows[i]["param_name"].ToString();
                                rp.param_label = dt_param.Rows[i]["param_label"].ToString();
                                rp.param_type = dt_param.Rows[i]["param_type"].ToString();
                                rp.param_defaultvalue = dt_param.Rows[i]["param_defaultvalue"].ToString();
                                rp.sort_no = dt_param.Rows[i]["sort_no"].ToString();
                                list.Add(rp);
                                isExist = true;
                                break;
                            }
                        }
                    }
                    if (!isExist)
                    {
                        ReportParam rp = new ReportParam();
                        rp.report_code = -1;
                        rp.param_name = item;
                        rp.param_label = item;
                        rp.param_type = "string";
                        rp.param_defaultvalue = "";
                        rp.sort_no = ""; list.Add(rp);
                    }
                }
                dataGridView1.DataSource = list;

                dataGridView1.AutoResizeColumns();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.list = list;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class ReportParam
    {
        public int report_code { get; set; }
        public string param_name { get; set; }
        public string param_label { get; set; }
        public string param_type { get; set; }
        public string param_defaultvalue { get; set; }
        public string sqltag { get; set; }
        public string sort_no { get; set; }
    }
}
