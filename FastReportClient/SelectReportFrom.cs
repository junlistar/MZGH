﻿using MyMzghLib;
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

            _main.sname =Convert.ToString( dataGridView1.SelectedRows[0].Cells["short_name"].Value) ;
            _main.lname =Convert.ToString( dataGridView1.SelectedRows[0].Cells["long_name"].Value);

            this.Close();
        }

        private void SelectReportFrom_Load(object sender, EventArgs e)
        {
            string sql = "select report_code,short_name,long_name,report_sql from rt_report_data_fast ";//where report_code = 220001
            DataTable dt = DbHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dt;

        }
    }
}
