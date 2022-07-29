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
using Client.ViewModel;
using log4net;
using Sunny.UI;

namespace Client.Forms.Pages.mzgh
{
    public partial class SelectPatient : UIForm
    {
        List<PatientVM> _list; 

        private static ILog log = LogManager.GetLogger(typeof(SelectPatient));//typeof放当前类

        public SelectPatient(List<PatientVM> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void SelectPatient_Load(object sender, EventArgs e)
        {
            var _data = _list.Select(p => new
            {
                patient_id = p.patient_id,
                name = p.name,
            }).ToList();
            this.dgvUsers.DataSource = _data;
            dgvUsers.Init();
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    var pid = dgvUsers.Rows[e.RowIndex].Cells["patient_id"].Value.ToString();
                    SessionHelper.sel_patientid = pid;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }
    }
}
