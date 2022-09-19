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
using log4net;
using Client.ClassLib;

namespace Client.Forms.Pages.hbgl
{
    public partial class DoctoutGhRequest : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(DoctoutGhRequest));//typeof放当前类

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

            if (list != null)
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
                DefaultSelect();
            }
            else
            {
                dgvlist.DataSource = new List<BaseRequestVM>();
            }

        }

        private void dgvlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                if (colIndex == 0 && rowIndex != -1)
                {

                    (dgvlist.Rows[rowIndex].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = true;
                    if (dgvlist.Rows[rowIndex].Cells[0].Value != null && Convert.ToBoolean(dgvlist.Rows[rowIndex].Cells[0].Value))
                    {
                        dgvlist.Rows[rowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        dgvlist.Rows[rowIndex].Cells[0].Value = true;
                    }
                   (dgvlist.Rows[rowIndex].Cells[0] as DataGridViewCheckBoxCell).ReadOnly = false;

                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
        public void DefaultSelect()
        {
            try
            {
                if (dgvlist.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvlist.Rows)
                    { 
                        row.Cells[0].Value = "True"; 
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
        //将勾选的挂号排班数据停诊
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var record_str = "";
                List<string> recordlist = new List<string>();
                for (int i = 0; i < dgvlist.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvlist.Rows[i].Cells[0].Value))
                    {
                        var record_sn = Convert.ToString(dgvlist.Rows[i].Cells["record_sn"].Value);
                        recordlist.Add(record_sn);
                    }
                }
                record_str = string.Join(",", recordlist);

                if (!string.IsNullOrWhiteSpace(record_str))
                {
                    //todo: update
                    //UpdateGhOpenFlag(string record_str)
                    string paramurl = string.Format($"/api/GuaHao/UpdateGhOpenFlag?record_str={record_str}");

                    var json = HttpClientUtil.Get(paramurl);

                    var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                    if (result.status == 1)
                    {
                        UIMessageBox.ShowSuccess("更新排班数据成功！");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        UIMessageBox.ShowError(result.message);
                    }

                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
