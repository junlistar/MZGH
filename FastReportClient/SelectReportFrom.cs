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
    public partial class SelectReportFrom : Form
    {
        Main _main;
        public SelectReportFrom(Main main)
        {
            InitializeComponent();
            _main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedRows.Count;

            var sql = dataGridView1.SelectedRows[0].Cells["report_sql"].Value.ToString();

            _main.code = dataGridView1.SelectedRows[0].Cells["report_code"].Value.ToString();
            _main.sql = sql;

            _main.sname = Convert.ToString(dataGridView1.SelectedRows[0].Cells["short_name"].Value);
            _main.lname = Convert.ToString(dataGridView1.SelectedRows[0].Cells["long_name"].Value);

            this.Close();
        }

        private void SelectReportFrom_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select report_code,short_name,long_name,report_sql from rt_report_data_fast_net order by report_code";//where report_code = 220001
                DataTable dt = DbHelper.ExecuteDataTable(sql);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
                InitDefaultParams();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        public void InitParam(string code)
        {
            string sql = $" select * from rt_report_params_fast_net where report_code = {code}";

            DataTable dt = DbHelper.ExecuteDataTable(sql);

            dgvparams.DataSource = dt; dgvparams.AutoResizeColumns();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());

            if (e.RowIndex >= 0)
            {
                InitDefaultParams();
            }
        }

        public void InitDefaultParams()
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
            var code = dataGridView1.SelectedRows[0].Cells["report_code"].Value.ToString();
            InitParam(code);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            string sql = $"select report_code,short_name,long_name,report_sql from rt_report_data_fast_net where report_code like '%{txtcode.Text.Trim()}%' and (short_name like '%{txtName.Text.Trim()}%' or long_name like '%{txtName.Text.Trim()}%') order by report_code";//where report_code = 220001
            DataTable dt = DbHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            InitDefaultParams();
        }
    }
}
