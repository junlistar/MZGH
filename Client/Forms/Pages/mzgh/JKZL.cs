using Client.ViewModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class JKZL : UIForm
    {

        string _key;
        string _jine;
        string patientId = "";
        public JKZL(string key, string je)
        {
            InitializeComponent();
            _key = key;
            _jine = je;
        }

        private void JKZL_Load(object sender, EventArgs e)
        {
            //txtjkje.Text = "0";
            //txtyjzje.Text = "0";
            txtjkje.ForeColor = Color.Red;
           
            txtjkje.Text = _jine;
            txtyjzje.Text = _jine;
            txtzlje.Text = "0.00";


            txtjkje.Focus();


            txtjkje.TextChanged += txtjkje_TextChanged;
        }

        private void txtjkje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 提交挂号收费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        { 

            ////获取数据 
            //MzghLib lib = new MzghLib();

            //lib.GuaHao(patientId, vm.record_sn);

           // MessageBox.Show("打印发票");

            //this.FormClosed += mainwindow.Main_Load;

            this.Close();
        }

        private void txtjkje_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtjkje.Text))
            {
                return;
            }
            decimal pay = Convert.ToDecimal(txtyjzje.Text);
            decimal ipt = Convert.ToDecimal(txtjkje.Text);
            if (pay > ipt)
            {
                this.txtzlje.Text = "交款不足";
                btnSave.Enabled = false;
            }
            else
            {
                this.txtzlje.Text = (ipt - pay).ToString("N2");
                btnSave.Enabled = true;

            }
        }
    }
}
