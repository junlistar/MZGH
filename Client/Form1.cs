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
using System.Linq;
using Client.ClassLib;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //this.CancelButton = this.button1;
            //DataTable dt = new DataTable();
            //dt.Columns.Add("1");
            //dt.Columns.Add("2");
            //dt.Columns.Add("3");
            //dt.Columns.Add("4");
            //dt.Rows.Add("中国", "上海", "5000", "7000");
            //dt.Rows.Add("中国", "北京", "3000", "5600");
            //dt.Rows.Add("美国", "纽约", "6000", "8600");
            //this.rowMergeView1.DataSource = dt;
            //this.rowMergeView1.ColumnHeadersHeight = 40;
            //this.rowMergeView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.rowMergeView1.MergeColumnNames.Add("begin_no");
            //this.rowMergeView1.MergeColumnNames.Add("current_no");
            //this.rowMergeView1.AddSpanHeader(2, 2, "男女数据");

            ControlHelper.SetIE(ControlHelper.IeVersion.强制ie10);

        }

        private void Btn1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var _btn = sender as UIButton; 
                UIMessageTip.Show(_btn.Text);
            }
        }

        private void Btn1_Leave(object sender, EventArgs e)
        {
            var _btn = sender as UIButton;
            _btn.Style = UIStyle.Blue;
        }

        private void Btn1_Enter(object sender, EventArgs e)
        {
            var _btn = sender as UIButton;
            _btn.Style = UIStyle.Red;
            UIMessageTip.Show(_btn.Text);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            uiFlowLayoutPanel1.Clear();

            for (int i = 0; i < 20; i++)
            {
                UIButton btn1 = new UIButton();

                btn1.Style = UIStyle.LayuiGreen;
                btn1.StyleCustomMode = true;
                btn1.Width = 200;
                btn1.Height = 50;
                btn1.Text = "按钮" + i;
                //btn1.TabStop = true;

                btn1.Enter += Btn1_Enter;
                btn1.Leave += Btn1_Leave;
                btn1.KeyUp += Btn1_KeyUp; ;

                uiFlowLayoutPanel1.Controls.Add(btn1);

            }


            // uiFlowLayoutPanel1.Focus();
            var _cts = uiFlowLayoutPanel1.GetAllControls();
            if (_cts.Count > 3)
            {
                var _btn = _cts[3] as UIButton;
                _btn.Focus();
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
