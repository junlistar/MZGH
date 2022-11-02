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
    public partial class About : UIForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            ControlHelper.SetIE(ControlHelper.IeVersion.强制ie10); 
            webBrowser1.Navigate(Application.StartupPath + "\\webpage\\about.html");
             
        }

        private void About_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
