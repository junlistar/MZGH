using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.FastReportLib
{
    public partial class PreviewFrom : Form
    {

        Report _report;
        public PreviewFrom(Report report)
        {
            InitializeComponent();
            _report = report;

        }

        private void PreviewFrom_Load(object sender, EventArgs e)
        {
            _report.Preview = previewControl1;
            _report.Prepare();
            _report.Show();
            //_report.Print();
        }
    }
}
