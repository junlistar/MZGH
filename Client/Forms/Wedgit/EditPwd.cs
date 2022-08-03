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

namespace Client.Forms.Wedgit
{
    public partial class EditPwd : UIForm
    {
        public EditPwd()
        {
            InitializeComponent();
        }

        private void EditPwd_Load(object sender, EventArgs e)
        {
            #region 初始化控件
            pnl1.Show();
            pnl2.Hide();
            pnl3.Hide();

            pnl2.Left = pnl1.Left;
            pnl3.Left = pnl1.Left;
            pnl2.Top = pnl1.Top;
            pnl3.Top = pnl1.Top;
            #endregion
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            this.uiBreadcrumb1.ItemIndex++;
            pnl1.Hide();
            pnl2.Show();
        }

        private void btn2left_Click(object sender, EventArgs e)
        {
            this.uiBreadcrumb1.ItemIndex--;
            pnl1.Show();
            pnl2.Hide();
        }

        private void btn2right_Click(object sender, EventArgs e)
        {
            this.uiBreadcrumb1.ItemIndex++;
            pnl3.Show();
            pnl2.Hide();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void uiBreadcrumb1_ItemIndexChanged(object sender, int value)
        {

        }
    }
}
