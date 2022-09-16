using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ViewModel;
using Sunny.UI;

namespace Client.Forms.Pages.hbgl
{
    public partial class DoctoutGhRequest : UIForm
    {
        public List<BaseRequestVM> list;
        public string doct_name;
        public string doct_sn;
        public string t1;
        public string t2;
        public DoctoutGhRequest()
        {
            InitializeComponent();
        }

        private void DoctoutGhRequest_Load(object sender, EventArgs e)
        {
            lbl_doctname.Text = doct_name;
            lbl_t1.Text = t1;
            lbl_t2.Text = t2;

            if (list!=null )
            {
                dgvlist.DataSource = list.Select(p => new
                {
                    p.record_sn,
                    p.request_date_str,
                    p.ampm,
                    p.unit_name,
                    p.group_name,
                    p.clinic_name,
                    p.ygsl
                }).ToList();
            }
            else
            {
                dgvlist.DataSource = new List<BaseRequestVM>();
            }
            
        }
    }
}
