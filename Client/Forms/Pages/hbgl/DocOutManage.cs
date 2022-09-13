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
using Sunny.UI;

namespace Client.Forms.Pages.hbgl
{
    public partial class DocOutManage : UIPage
    {
        public DocOutManage()
        {
            InitializeComponent();
        }
        List<GhDoctorOutVM> list;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //<List<GhDoctorOut>> GetGhDoctorOuts()

            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DocOutEdit docOutEdit = new DocOutEdit();
            if (docOutEdit.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            var paramurl = string.Format($"/api/GuaHao/GetGhDoctorOuts");
            var json = HttpClientUtil.Get(paramurl);

            var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhDoctorOutVM>>>(json);
            if (result.status == 1)
            {
                list = result.data;
                dgvlist.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;

                dgvlist.DataSource = list;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                var _index = dgvlist.SelectedIndex;
                if (_index != -1)
                {
                    var _sn = dgvlist.Rows[_index].Cells["sn"].Value.ToString();
                    var _doctor_id = dgvlist.Rows[_index].Cells["doctor_id"].Value.ToString();
                    var _begin_date = Convert.ToDateTime(dgvlist.Rows[_index].Cells["begin_date"].Value.ToString());
                    var _end_date = Convert.ToDateTime(dgvlist.Rows[_index].Cells["end_date"].Value.ToString());
                    var _is_delete = Convert.ToInt32(dgvlist.Rows[_index].Cells["is_delete"].Value.ToString());

                    var _vm = new GhDoctorOutVM();
                    _vm.sn = _sn;
                    _vm.doctor_id = _doctor_id;
                    _vm.begin_date = _begin_date;
                    _vm.end_date = _end_date;
                    _vm.is_delete = _is_delete;
                    DocOutEdit docOutEdit = new DocOutEdit();
                    docOutEdit.vm = _vm;
                    if (docOutEdit.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvlist_SelectIndexChange(object sender, int index)
        {
            //dgvlist.Rows[index].DefaultCellStyle.BackColor = SessionHelper.dgv_row_seleced_color;
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
