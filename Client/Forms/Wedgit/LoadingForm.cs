using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms.Wedgit
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            this.BackColor = Color.White; this.TransparencyKey = Color.White;//设置窗体透明
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
