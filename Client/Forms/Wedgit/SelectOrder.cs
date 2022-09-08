using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Client.Forms.Pages;
using Client.ViewModel;
using Sunny.UI; 
using Mzsf.Forms.Pages;

namespace Client.Forms.Wedgit
{
    public partial class SelectOrder : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(SelectOrder));//typeof放当前类
        List<MzVisitVM> _list;

        public SelectOrder(List<MzVisitVM> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void SelectOrder_Load(object sender, EventArgs e)
        {
            dgvOrders.Init();
            dgvOrders.DataSource = _list.Select(p=> new
            {
                times = p.times,
                visit_date = p.visit_date,
                doct_name = p.doct_name,
                doct_code = p.doctor_code,
                unit_name =  p.unit_name,
                icd_code =  p.icd_code
            }).OrderBy(o=>o.times).ToList();
            dgvOrders.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvOrders.AutoResizeColumns();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    int times = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["times"].Value);
                    ChargePage.current_times = times;
                    if (dgvOrders.Rows[e.RowIndex].Cells["doct_name"].Value!=null)
                    {
                        ChargePage.current_doct_name = dgvOrders.Rows[e.RowIndex].Cells["doct_name"].Value.ToString();
                    }
                    if (dgvOrders.Rows[e.RowIndex].Cells["unit_name"].Value!=null)
                    {
                        ChargePage.current_unit_name = dgvOrders.Rows[e.RowIndex].Cells["unit_name"].Value.ToString(); ;
                    }
                    if (dgvOrders.Rows[e.RowIndex].Cells["doct_code"].Value != null)
                    {
                        ChargePage.current_doct_sn = dgvOrders.Rows[e.RowIndex].Cells["doct_code"].Value.ToString(); ;
                    }
                    if (dgvOrders.Rows[e.RowIndex].Cells["icd_code"].Value != null)
                    {
                        ChargePage.current_icd_code = dgvOrders.Rows[e.RowIndex].Cells["icd_code"].Value.ToString(); ;
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.Message);
            }
            
        }

        private void SelectOrder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
