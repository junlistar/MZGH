using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mzsf.ClassLib;
using Sunny.UI;

namespace Mzsf.Forms.Pages
{
    public partial class OrderItemPage : UIPage
    {
        int _order_no = 0;
        string _order_type;
        public OrderItemPage(int order_no,string order_type)
        {
            InitializeComponent();
            _order_no = order_no;
            _order_type = order_type;
        }

        private void OrderItemPage_Load(object sender, EventArgs e)
        {
            InitUI();
            GetData();
        }

        private void InitUI()
        {
            //"01" 诊疗；"02"西药
            if (_order_type=="01")
            {

            }
            else if (_order_type == "02")
            {
                gbx_jglx.Hide();
            }
        }

        public void GetData()
        {
            if (SessionHelper.cprCharges != null)
            {
                var dgv_data = SessionHelper.cprCharges.Where(p => p.order_no == _order_no).Select(q => new
                {
                    item_no = q.item_no,
                    charge_code_lookup = q.charge_code_lookup,
                    exec_SN_lookup = q.exec_SN_lookup,
                    charge_price = q.charge_price,
                    charge_amount = q.charge_amount,
                    caoyao_fu = q.caoyao_fu,
                    total_price = q.total_price,
                    fybl = "",
                    yongfa = "",
                    comment = q.comment,
                    dosage = q.dosage,
                    freq_code = q.freq_code,

                }).ToList();
                dgvOrderDetail.Init();
                dgvOrderDetail.DataSource = dgv_data;
                dgvOrderDetail.AutoResizeColumns();
                dgvOrderDetail.ShowGridLine = true;

                if (dgv_data.Count>0)
                {
                    BindSelectedRowData(0);
                }
            }
        }

        private void dgvOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                BindSelectedRowData(e.RowIndex);
            }
        }

        public void BindSelectedRowData(int rowIndex)
        {
            var row = dgvOrderDetail.Rows[rowIndex];

            txtName.Text = row.Cells["charge_code_lookup"].Value.ToString();
            txtUnit.Text = row.Cells["exec_SN_lookup"].Value.ToString();
            txtCharge.Text = row.Cells["charge_price"].Value.ToString();
            txtAmount.Text = row.Cells["charge_amount"].Value.ToString();
        }
    }
}
