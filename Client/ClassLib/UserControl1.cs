using FastReport.Utils;
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

namespace GuXHis.ClassLib
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public UIDataGridView dgv =new UIDataGridView();


        private void txtks_TextChanged(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;

            var ipt = txtks.Text.Trim();

            dgv.Parent = this;
            dgv.Top = txtks.Top + txtks.Top + txtks.Height;
            dgv.Left = txtks.Left;
            dgv.Width = this.Width;
            dgv.Height = this.Height- txtks.Height;
            dgv.BringToFront();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.ReadOnly = true;


            List<UnitVM> vm = new List<UnitVM>();
           

            //if (!string.IsNullOrWhiteSpace(ipt))
            //{
            //    vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper()) || p.d_code.StartsWith(ipt.ToUpper()) || p.code.StartsWith(ipt)).ToList();
            //}
            //dgv.DataSource = vm;

            dgv.Columns["code"].HeaderText = "编号";
            dgv.Columns["name"].HeaderText = "名称"; 
            dgv.AutoResizeColumns();

            dgv.Show(); dgv.BringToFront();


        }
    }
}
