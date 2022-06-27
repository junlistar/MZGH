using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Mzsf.ClassLib;
using Mzsf.ViewModel;
using Sunny.UI;

namespace Mzsf.Forms.Pages
{
    public partial class OrderItemPage : UIPage
    {
        public static int testno = 0;
        int _order_no = 0;
        string _order_type;
        public static string str = "";

        private static ILog log = LogManager.GetLogger(typeof(ChargePage));//typeof放当前类

        public OrderItemPage(int order_no, string order_type)
        {
            InitializeComponent();
            _order_no = order_no;
            _order_type = order_type;
        }

        private void OrderItemPage_Load(object sender, EventArgs e)
        {
            if (SessionHelper.cprCharges.Count(p => p.order_no == _order_no) > 0)
            {
                btnAddItem.Visible = false;
                btnDeleteItem.Visible = false;
            }

            InitUI();
            GetData();
        }



        private void InitUI()
        {
            //"01" 诊疗；"02"西药” 04:草药
            if (_order_type == "01")
            {

            }
            else if (_order_type == "02")
            {
                //gbx_jglx.Hide();
            }

            //初始化项目查询
            var tb = txtName;
            var pbl = tb.Parent as UIPanel;
            dgv.Parent = this;
            dgv.Top = pbl.Top + tb.Top + tb.Height;
            dgv.Left = pbl.Left + tb.Left;
            dgv.Width = 1000;
            dgv.Height = 200;
            dgv.BringToFront();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.ReadOnly = true;

            dgv.Hide();
            dgv.CellClick += Dgv_CellClick;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var kucun = dgv.Rows[e.RowIndex].Cells["amount"].Value.ToString();
                if (kucun == "0" && _order_type != "01")
                {
                    MessageBox.Show("库存不足"); return;
                }

                dgv.Hide();

                //MessageBox.Show(dgv.Rows[e.RowIndex].Cells["name"].Value.ToString());

                txtName.TextChanged -= txtName_TextChanged;

                txtName.Text = dgv.Rows[e.RowIndex].Cells["name"].Value.ToString();
                var exec_unit = "";
                if (dgv.Rows[e.RowIndex].Cells["exec_unit"].Value != null)
                {

                    txtUnit.Text = dgv.Rows[e.RowIndex].Cells["exec_unit_str"].Value.ToString();
                    exec_unit = dgv.Rows[e.RowIndex].Cells["exec_unit"].Value.ToString();
                }
                var code = dgv.Rows[e.RowIndex].Cells["code"].Value.ToString();
                txtCharge.Text = dgv.Rows[e.RowIndex].Cells["price"].Value.ToString();
                txtAmount.Text = "1";

                if (dgvOrderDetail.SelectedIndex == -1)
                {
                    return;
                }

                int index = dgvOrderDetail.SelectedIndex;

                dgvOrderDetail.Rows[index].Cells["item_no"].Value = dgvOrderDetail.Rows.Count;
                dgvOrderDetail.Rows[index].Cells["charge_code_lookup_str"].Value = txtName.Text;
                dgvOrderDetail.Rows[index].Cells["charge_code_lookup"].Value = exec_unit;
                dgvOrderDetail.Rows[index].Cells["exec_SN_lookup"].Value = txtUnit.Text;
                dgvOrderDetail.Rows[index].Cells["charge_price"].Value = txtCharge.Text;
                dgvOrderDetail.Rows[index].Cells["charge_amount"].Value = txtAmount.Text;

                dgvOrderDetail.Rows[index].Cells["code"].Value = code;

                txtName.TextChanged += txtName_TextChanged;

                dgvOrderDetail.AutoResizeColumns();

                //更新金额（当前金额和总金额）
                CalcPrice();
            }
        }

        public void GetData()
        {
            if (SessionHelper.cprCharges != null)
            {
                var dgv_data = SessionHelper.cprCharges.Where(p => p.order_no == _order_no).Select(q => new
                {
                    item_no = q.item_no,
                    charge_code_lookup_str = q.charge_code_lookup_str,
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
                    parent_no = q.parent_no,
                    code = q.charge_code
                }).ToList();

                if (dgv_data.Count > 0)
                {
                    dgvOrderDetail.DataSource = dgv_data;
                    dgvOrderDetail.AutoResizeColumns();
                    dgvOrderDetail.ShowGridLine = true;
                    BindSelectedRowData(0);
                }
                else
                {
                    int index = dgvOrderDetail.Rows.Add();
                }
            }
        }

        private void dgvOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void BindSelectedRowData(int rowIndex)
        {
            var row = dgvOrderDetail.Rows[rowIndex];

            txtName.TextChanged -= txtName_TextChanged;

            if (row.Cells["charge_code_lookup"].Value != null)
            {
                if (row.Cells["charge_code_lookup_str"].Value != null)
                {
                    txtName.Text = row.Cells["charge_code_lookup_str"].Value.ToString();
                }
                if (row.Cells["exec_SN_lookup"].Value != null)
                {

                    txtUnit.Text = row.Cells["exec_SN_lookup"].Value.ToString();
                }
                txtCharge.Text = row.Cells["charge_price"].Value.ToString();
                txtAmount.Text = row.Cells["charge_amount"].Value.ToString();
            }
            else
            {
                txtName.Text = "";
                txtUnit.Text = "";
                txtCharge.Text = "";
                txtAmount.Text = "";
            }

            txtName.TextChanged += txtName_TextChanged;
        }

        private void dgvOrderDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var pno = Convert.ToString(this.dgvOrderDetail.Rows[e.RowIndex].Cells["parent_no"].Value);
                if (pno != "0")
                {
                    dgvOrderDetail.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }

            }
        }

        private void dgvOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                BindSelectedRowData(e.RowIndex);
                this.txtName.Focus();
            }
        }

        UIDataGridView dgv = new UIDataGridView();
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //查询信息 显示到girdview 
            var ds = GetItemDate(_order_type, txtName.Text.ToUpper());

            if (ds != null && ds.Count > 0)
            {
                dgv.DataSource = ds.Select(p => new
                {
                    code = p.code,
                    name = p.name.Trim(),
                    py_code = p.py_code,
                    d_code = p.d_code,
                    specification = p.specification,
                    exec_unit_str = p.exec_unit_str,
                    exec_unit = p.exec_unit,
                    price = p.orig_price,
                    amount = p.stock_amount2,
                }).ToList();
                dgv.Init();
                dgv.Columns["code"].HeaderText = "编号";
                dgv.Columns["name"].HeaderText = "名称";
                dgv.Columns["exec_unit"].HeaderText = "执行科室";
                dgv.Columns["price"].HeaderText = "价格";
                dgv.Columns["amount"].HeaderText = "数量";
                dgv.Columns["specification"].HeaderText = "规格";
                dgv.Columns["exec_unit_str"].HeaderText = "执行科室";
                dgv.Columns["py_code"].Visible = false;
                dgv.Columns["d_code"].Visible = false;
                dgv.Columns["exec_unit"].Visible = false;
                dgv.AutoResizeColumns();

                dgv.Show();

            }


        }

        public List<MzOrderItemVM> GetItemDate(string order_type, string py_code)
        {
            Task<HttpResponseMessage> task = null;
            string json = "";
            string paramurl = string.Format($"/api/mzsf/GetMzOrderItem?order_type={order_type}&py_code={py_code}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzOrderItemVM>>>(json);
                if (result.status == 1)
                {
                    return result.data;
                }
                else
                {
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
            return new List<MzOrderItemVM>();
        }

        private void OrderItemPage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                dgvOrderDetail.SelectedRows[0].Cells["charge_amount"].Value = txtAmount.Text;

                //更新金额（当前金额和总金额）
                CalcPrice();

                if (dgvOrderDetail.Rows[dgvOrderDetail.Rows.Count - 1].Cells["charge_code_lookup"].Value != null)
                {
                    try
                    {
                        int new_index = dgvOrderDetail.Rows.Add();
                        //增加新的一行，并设焦点
                        this.dgvOrderDetail.CurrentCell = this.dgvOrderDetail[0, new_index];
                        BindSelectedRowData(new_index);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                    }
                }
                else
                {
                    BindSelectedRowData(dgvOrderDetail.Rows.Count - 1);
                }

                txtName.Focus();

            }
        }

        /// <summary>
        /// 计算当前表格的金额
        /// </summary>
        public void CalcPrice()
        {
            int row_count = dgvOrderDetail.Rows.Count;
            //金额总计
            decimal page_total = 0;
            //明细项目
            int page_items = 0;
            //数量总计
            int item_amount = 0;

            var item_list = SessionHelper.cprCharges.Where(p => p.order_no == _order_no).ToList();

            var index = dgvOrderDetail.SelectedIndex;

            var obj = dgvOrderDetail.Rows[index].Cells["charge_code_lookup_str"].Value;
            if (obj == null)
            {
                return;
            }

            var _charge_code_lookup = dgvOrderDetail.Rows[index].Cells["charge_code_lookup"].Value.ToString();
            var _charge_price = Convert.ToDecimal(dgvOrderDetail.Rows[index].Cells["charge_price"].Value);
            var _charge_amount = Convert.ToInt32(dgvOrderDetail.Rows[index].Cells["charge_amount"].Value);
            var _code = dgvOrderDetail.Rows[index].Cells["code"].Value.ToString();

            CprChargesVM vm = new CprChargesVM();
            vm.charge_code_lookup = _charge_code_lookup;
            vm.charge_price = _charge_price;
            vm.charge_amount = _charge_amount;
            vm.item_no = (index + 1);
            vm.order_no = _order_no;

            vm.charge_code = _code;
            vm.order_type = _order_type;

            if (item_list.Count == 0)
            {
                page_total += _charge_price * _charge_amount;
                page_items++;
                item_amount += _charge_amount;

                SessionHelper.cprCharges.Add(vm);

            }
            else
            {
                foreach (var aa in item_list.ToArray())
                {
                    SessionHelper.cprCharges.Remove(aa);
                }
                index = 1;

                foreach (DataGridViewRow row in dgvOrderDetail.Rows)
                {
                    var charge_code_lookup = row.Cells["charge_code_lookup"].Value.ToString();
                    var charge_price = Convert.ToDecimal(row.Cells["charge_price"].Value);
                    var charge_amount = Convert.ToInt32(row.Cells["charge_amount"].Value);
                    var code = row.Cells["code"].Value.ToString();

                    var chargeVM = new CprChargesVM();
                    chargeVM.charge_code_lookup = charge_code_lookup;
                    chargeVM.charge_price = charge_price;
                    chargeVM.charge_amount = charge_amount;
                    chargeVM.item_no = index++;
                    chargeVM.order_no = _order_no;

                    chargeVM.charge_code = code;
                    chargeVM.order_type = _order_type;

                    SessionHelper.cprCharges.Add(chargeVM);

                }

                //if (item!=null&& index < dgvOrderDetail.Rows.Count)
                //{
                //    //更新数量
                //    for (int i = 0; i < item_list.Count; i++)
                //    {
                //        if (item_list[i].charge_code == _code)
                //        {
                //            item_list[i].charge_amount = _charge_amount;
                //            break;
                //        }
                //    }
                //}
                //else
                //{

                //    //新增一条项目
                //    SessionHelper.cprCharges.Add(vm);
                //}
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvOrderDetail.Rows.Count == 0 || dgvOrderDetail.Rows[dgvOrderDetail.Rows.Count - 1].Cells["charge_code_lookup"].Value != null)
                { 
                    int new_index = dgvOrderDetail.Rows.Add();
                    //增加新的一行，并设焦点
                    this.dgvOrderDetail.CurrentCell = this.dgvOrderDetail[0, new_index];
                    BindSelectedRowData(new_index);
                    txtName.Focus();
                }


            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }


        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetail.SelectedRows.Count > 0)
            {
                //dgv.Rows.Remove(dgv.SelectedRows[0]);
                dgvOrderDetail.Rows.RemoveAt(dgvOrderDetail.SelectedIndex);

                var row = dgvOrderDetail.Rows[dgvOrderDetail.SelectedIndex];

                var obj = row.Cells["code"].Value;
                if (obj == null)
                {
                    return;
                }
                var charge_code_lookup = row.Cells["charge_code_lookup"].Value.ToString();
                var charge_price = Convert.ToDecimal(row.Cells["charge_price"].Value);
                var charge_amount = Convert.ToInt32(row.Cells["charge_amount"].Value);
                var code = row.Cells["code"].Value.ToString();
                 
                var item_list = SessionHelper.cprCharges.Where(p => p.order_no == _order_no).ToList();
                 
                foreach (var item in item_list)
                {
                    if (item.charge_code == code)
                    {
                        SessionHelper.cprCharges.Remove(item);
                        break;
                    }
                }
                 
            }
        }
    }
}
