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

namespace Client.Forms.Pages.zfgl
{
    public partial class SelfPay : UIPage
    {
        public SelfPay()
        {
            InitializeComponent();
        }

        private void SelfPay_Initialize(object sender, EventArgs e)
        {

            txtBeginDate.Value = DateTime.Now;
            txtEndDate.Value = DateTime.Now;
        }
    }
}
