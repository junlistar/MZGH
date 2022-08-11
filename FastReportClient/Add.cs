using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyMzghLib;

namespace FastReportClient
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            string report_code = DateTime.Now.ToString("yy") + "0001";
            try
            { 
                string maxcodesql = "select max(report_code) report_code from rt_report_data_fast_net";
                var code = DbHelper.ExecuteScalar(maxcodesql);
                report_code =( code + 1).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtcode.Text = report_code;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtcode.Text))
                {
                    MessageBox.Show("编号不能为空！");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtsname.Text))
                {
                    MessageBox.Show("名称不能为空！");
                    return;
                }

                var code = int.Parse(txtcode.Text);
                var sname = txtsname.Text;
                var lname = txtlname.Text;

                string sql = @"insert into rt_report_data_fast_net(report_code,short_name,long_name,report_flag,datasetn)
values(@p1,@p2,@p3,1,0)";
                var para = new SqlParameter[3];
                para[0] = new SqlParameter("@p1", code);
                para[1] = new SqlParameter("@p2", sname);
                para[2] = new SqlParameter("@p3", lname);
                var result = DbHelper.ExecuteNonQuery(sql, para);
                if (result>0)
                {
                    MessageBox.Show("保存成功！");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
