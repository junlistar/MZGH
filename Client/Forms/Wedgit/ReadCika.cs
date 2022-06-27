using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Sunny.UI;

namespace Client.Forms.Wedgit
{
    public partial class ReadCika : UIForm
    {
        public ReadCika(string cardName)
        {
            InitializeComponent();
            _cardName = cardName;
        }

        public string _cardName = "";
        private void ReadCika_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
            if (_cardName=="磁卡")
            {
                this.Text = "读磁卡";
                lblkahao.Text = "磁卡号";
            }
            else if (_cardName == "ID号")
            {
                this.Text = "读ID号";
                lblkahao.Text = "ID号"; 
            }

            SessionHelper.cardno = "";
            lblmsg.ForeColor = Color.Red;
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var code = txtCode.Text;
                if (string.IsNullOrWhiteSpace(code))
                {
                    return;
                }
                SessionHelper.cardno = code; this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
