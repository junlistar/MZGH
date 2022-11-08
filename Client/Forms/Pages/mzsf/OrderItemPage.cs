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
using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;
using Client.Forms.Pages.mzsf;

namespace Mzsf.Forms.Pages
{
    public partial class OrderItemPage : UIPage
    {
        public static int testno = 0;
        int _order_no = 0;
        string _order_type;
        bool _is_charge;
        public static string str = "";

        private static ILog log = LogManager.GetLogger(typeof(ChargePage));//typeof放当前类

        public delegate void SetData();
        public SetData setData;

        Dictionary<string, int> kucun_dic = new Dictionary<string, int>();

        public OrderItemPage(int order_no, string order_type, bool is_charge = false)
        {
            InitializeComponent();
            _order_no = order_no;
            _order_type = order_type;
            _is_charge = is_charge;
        }

        private void OrderItemPage_Load(object sender, EventArgs e)
        {
            if (_is_charge)
            {
                btnAddItem.Visible = false;
                btnDeleteItem.Visible = false;
                dgvOrderDetail.Visible = false;
                uiPanel1.Visible = false;

                lblNodata.Text = "已收费处方";
                lblNodata.Show();
            }
            else
            {
                StyleHelper.SetGridColor(dgvOrderDetail);//设置样式

                lblNodata.Hide();

                if (SessionHelper.cprCharges.Count(p => p.order_no == _order_no) > 0)
                {
                    btnAddItem.Visible = false;
                    btnDeleteItem.Visible = false;
                }

                InitUI();
                GetData();

                txtName.Focus();
            }

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

            dgv.KeyDown += Dgv_KeyDown; ;

            StyleHelper.SetGridColor(dgv);//设置样式
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (dgv.SelectedIndex != -1)
                {
                    var ev = new DataGridViewCellEventArgs(0, dgv.SelectedIndex);

                    Dgv_CellClick(sender, ev);
                    return;
                }
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (BindItemData(e.RowIndex))
                    {
                        //更新金额（当前金额和总金额）
                        CalcPrice();

                        txtAmount.Focus();

                    }

                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        public bool BindItemData(int sel_index)
        {
            try
            {
                string code = "";
                if (dgv.Rows[sel_index].Cells["code"].Value != null)
                {
                    code = dgv.Rows[sel_index].Cells["code"].Value.ToString();
                }

                if (dgv.Rows[sel_index].Cells["specification"] != null && dgv.Rows[sel_index].Cells["specification"].Value.ToString() == "模版")
                {
                    //弹出模板项目选择框
                    OrderTemplateSelect orderTemplateSelect = new OrderTemplateSelect();
                    orderTemplateSelect._code = code;
                    orderTemplateSelect.setData = BindMbData;
                    orderTemplateSelect.ShowDialog();
                    return true;
                }
                else
                {
                    var kucun = dgv.Rows[sel_index].Cells["amount"].Value.ToString();
                    if (kucun == "0" && _order_type != "01")
                    {
                        MessageBox.Show("库存不足"); return false;
                    }

                    //判断是否已添加相同药品
                    for (int i = 0; i < dgvOrderDetail.Rows.Count; i++)
                    {
                        var _code = dgvOrderDetail.Rows[i].Cells["code"].Value;
                        if (_code != null && _code.ToString() == code)
                        {
                            MessageBox.Show("已经添加了相同细目");
                            return false;
                        }
                    }
                    if (kucun != "")
                    {
                        if (kucun_dic.Keys.Contains(code))
                        {
                            kucun_dic[code] = int.Parse(kucun);
                        }
                        else
                        {
                            kucun_dic.Add(code, int.Parse(kucun));
                        }
                    }


                    dgv.Hide();


                    txtName.TextChanged -= txtName_TextChanged;
                    if (dgv.Rows[sel_index].Cells["name"].Value != null)
                    {
                        txtName.Text = dgv.Rows[sel_index].Cells["name"].Value.ToString();
                    }
                    var exec_unit = "";
                    if (dgv.Rows[sel_index].Cells["exec_unit"].Value != null)
                    {
                        exec_unit = dgv.Rows[sel_index].Cells["exec_unit"].Value.ToString();
                    }
                    if (dgv.Rows[sel_index].Cells["exec_unit_str"].Value != null)
                    {
                        txtUnit.Text = dgv.Rows[sel_index].Cells["exec_unit_str"].Value.ToString();
                    }
                    if (dgv.Rows[sel_index].Cells["price"].Value != null)
                    {
                        txtCharge.Text = dgv.Rows[sel_index].Cells["price"].Value.ToString();
                    }
                    txtAmount.Text = "1";
                    var _serial = "";
                    if (dgv.Rows[sel_index].Cells["serial"].Value != null)
                    {
                        _serial = dgv.Rows[sel_index].Cells["serial"].Value.ToString();
                    }
                    if (dgvOrderDetail.SelectedIndex == -1)
                    {
                        return false;
                    }

                    int index = dgvOrderDetail.SelectedIndex;


                    dgvOrderDetail.Rows[index].Cells["item_no"].Value = index+1;
                    dgvOrderDetail.Rows[index].Cells["charge_code_lookup_str"].Value = txtName.Text;
                    dgvOrderDetail.Rows[index].Cells["charge_code_lookup"].Value = exec_unit;
                    dgvOrderDetail.Rows[index].Cells["exec_SN_lookup"].Value = txtUnit.Text;
                    dgvOrderDetail.Rows[index].Cells["charge_price"].Value = txtCharge.Text;
                    dgvOrderDetail.Rows[index].Cells["charge_amount"].Value = txtAmount.Text;
                    dgvOrderDetail.Rows[index].Cells["serial"].Value = _serial;

                    dgvOrderDetail.Rows[index].Cells["code"].Value = code;

                    dgvOrderDetail.Rows[index].Cells["total_price"].Value = decimal.Parse(txtAmount.Text) * decimal.Parse(txtCharge.Text);

                    txtName.TextChanged += txtName_TextChanged;

                    dgvOrderDetail.AutoResizeColumns();

                    return true;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }

        public void BindMbData()
        {
            if (SessionHelper.mbChargeList != null)
            {
                dgv.Hide();
                txtName.TextChanged -= txtName_TextChanged;

                int index = dgvOrderDetail.SelectedIndex;
                if (dgvOrderDetail.Rows.Count > 0)
                {
                    index = dgvOrderDetail.Rows.Count-1;
                }

                for (int i = 0; i < SessionHelper.mbChargeList.Count; i++)
                {

                    var _item = SessionHelper.mbChargeList[i];
                    //chargeVM.charge_code_lookup = _charge_name;
                    //chargeVM.orig_price = _price;
                    //chargeVM.charge_amount = _quantity;
                    //chargeVM.serial_no = _serial;
                    //chargeVM.charge_code = _code;
                    if (index >= dgvOrderDetail.Rows.Count)
                    {
                        //AddNewRow();
                        index = dgvOrderDetail.Rows.Add();
                    }

                    dgvOrderDetail.Rows[index].Cells["item_no"].Value = dgvOrderDetail.Rows.Count;
                    dgvOrderDetail.Rows[index].Cells["charge_code_lookup_str"].Value = _item.charge_code_lookup;
                    dgvOrderDetail.Rows[index].Cells["charge_code_lookup"].Value = _item.charge_code_lookup;
                    dgvOrderDetail.Rows[index].Cells["exec_SN_lookup"].Value = _item.exec_sn;
                    dgvOrderDetail.Rows[index].Cells["charge_price"].Value = _item.orig_price;
                    dgvOrderDetail.Rows[index].Cells["charge_amount"].Value = _item.charge_amount;
                    dgvOrderDetail.Rows[index].Cells["serial"].Value = _item.serial_no;
                    dgvOrderDetail.Rows[index].Cells["code"].Value = _item.charge_code;

                    dgvOrderDetail.Rows[index].Cells["total_price"].Value = _item.charge_amount * _item.orig_price;


                    //index = index + 1;
                }
                txtName.TextChanged += txtName_TextChanged;
            }
            else
            {
                UIMessageTip.Show("没有对应的诊疗数据");
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
                    charge_price = q.orig_price,
                    charge_amount = q.charge_amount,
                    caoyao_fu = q.caoyao_fu,
                    total_price = q.total_price,
                    fybl = "",
                    yongfa = q.supply_code_lookup,
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
                    dgvOrderDetail.CellBorderStyle = DataGridViewCellBorderStyle.Single;
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
            try
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

                    //如果价格为0，可以编辑
                    if (Convert.ToDecimal(txtCharge.Text) == 0)
                    {
                        txtCharge.ReadOnly = false;
                         
                    }
                    else
                    {
                        txtCharge.ReadOnly = true;
                    }
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
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void dgvOrderDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
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
            if (txtName.Text.Length < 2)
            {
                return;
            }

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
                    serial = p.serial,
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
                dgv.Columns["serial"].Visible = false;

                //诊疗 不显示数量
                if (_order_type == "01")
                {
                    dgv.Columns["amount"].Visible = false;
                }

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
            try
            { 

                if (e.KeyCode == Keys.Enter)
                {
                    int _input = int.Parse(txtAmount.Text);
                    if (_input <= 0)
                    {
                        MessageBox.Show($"数量必须大于0");
                        return;
                    }
                    //判断库存是否足够 诊疗（01）不判断
                    if (dgvOrderDetail.SelectedRows[0].Cells["code"].Value != null && _order_type != "01")
                    {
                        var _code = dgvOrderDetail.SelectedRows[0].Cells["code"].Value.ToString();
                        if (kucun_dic.Keys.Contains(_code))
                        {
                            if (int.Parse(txtAmount.Text) > kucun_dic[_code])
                            {
                                MessageBox.Show($"库存不足！最大值:{kucun_dic[_code]}");

                                return;
                            }
                        }

                    }

                  
                    if (dgvOrderDetail.SelectedRows[0].Cells["charge_price"].Value!=null)
                    {
                        dgvOrderDetail.SelectedRows[0].Cells["charge_amount"].Value = txtAmount.Text;
                        dgvOrderDetail.SelectedRows[0].Cells["total_price"].Value = _input * decimal.Parse(dgvOrderDetail.SelectedRows[0].Cells["charge_price"].Value.ToString());
                    } 

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
                    //设焦点
                    this.dgvOrderDetail.CurrentCell = this.dgvOrderDetail[0, dgvOrderDetail.Rows.Count-1];
                    txtName.Focus();

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            var _orig_price = Convert.ToDecimal(dgvOrderDetail.Rows[index].Cells["charge_price"].Value);

            var _charge_amount = Convert.ToInt32(dgvOrderDetail.Rows[index].Cells["charge_amount"].Value);
            var _code = dgvOrderDetail.Rows[index].Cells["code"].Value.ToString();
            var _serial = "";
            if (dgvOrderDetail.Rows[index].Cells["serial"].Value != null)
            {
                _serial = dgvOrderDetail.Rows[index].Cells["serial"].Value.ToString();
            }
            var _caoyao_fu = 1;
            if (dgvOrderDetail.Rows[index].Cells["caoyao_fu"].Value != null)
            {
                _caoyao_fu = Convert.ToInt32(dgvOrderDetail.Rows[index].Cells["caoyao_fu"].Value.ToString());
            }


            CprChargesVM vm = new CprChargesVM();
            vm.charge_code_lookup = _charge_code_lookup;
            vm.orig_price = _orig_price;
            vm.charge_amount = _charge_amount;
            vm.charge_price = _orig_price * _charge_amount* _caoyao_fu;
            vm.caoyao_fu = _caoyao_fu;
            vm.item_no = (index + 1);
            vm.order_no = _order_no;

            vm.charge_code = _code;
            vm.order_type = _order_type;
            vm.serial_no = _serial;

            //if (item_list.Count == 0)
            //{
            //    page_total += _orig_price * _charge_amount;
            //    page_items++;
            //    item_amount += _charge_amount;

            //    SessionHelper.cprCharges.Add(vm);

            //}
            //else
            //{
            foreach (var aa in item_list.ToArray())
            {
                SessionHelper.cprCharges.Remove(aa);
            }
            index = 1;

            foreach (DataGridViewRow row in dgvOrderDetail.Rows)
            {
                if (row.Cells["charge_code_lookup"].Value == null)
                {
                    break;
                } 
                var charge_code_lookup = row.Cells["charge_code_lookup"].Value.ToString();
                var orig_price = Convert.ToDecimal(row.Cells["charge_price"].Value);
                var charge_amount = Convert.ToInt32(row.Cells["charge_amount"].Value);
                var code = row.Cells["code"].Value.ToString();
                var serial = "";
                if (row.Cells["serial"].Value != null)
                {
                    serial = row.Cells["serial"].Value.ToString();
                }
                var caoyao_fu = 1;
                if (row.Cells["caoyao_fu"].Value != null)
                {
                    caoyao_fu = Convert.ToInt32(row.Cells["caoyao_fu"].Value);
                }
                var chargeVM = new CprChargesVM();
                chargeVM.charge_code_lookup = charge_code_lookup;
                chargeVM.orig_price = orig_price;
                chargeVM.charge_amount = charge_amount;
                chargeVM.charge_price = orig_price * charge_amount* caoyao_fu;
                chargeVM.caoyao_fu = caoyao_fu;
                chargeVM.item_no = index++;
                chargeVM.order_no = _order_no;
                chargeVM.serial_no = serial;

                chargeVM.charge_code = code;
                chargeVM.order_type = _order_type;

                SessionHelper.cprCharges.Add(chargeVM);

            }


            //}
            setData();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddNewRow();

        }

        public void AddNewRow()
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
            try
            {
                if (dgvOrderDetail.SelectedRows.Count > 0)
                {
                    //dgv.Rows.Remove(dgv.SelectedRows[0]);


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
                            setData();
                            break;
                        }
                    }

                    dgvOrderDetail.Rows.RemoveAt(dgvOrderDetail.SelectedIndex);

                    if (dgvOrderDetail.Rows.Count == 0)
                    {
                        AddNewRow();
                    }
                    else
                    {
                        //更新显示序号
                        int _index = 1;
                        foreach (DataGridViewRow item in dgvOrderDetail.Rows)
                        {
                            var _code = item.Cells["code"].Value;
                            if (_code == null)
                            {
                                continue;
                            }
                            else
                            {
                                item.Cells["item_no"].Value = _index++;
                            }
                        }
                        dgvOrderDetail.SelectedIndex = 0;
                        BindSelectedRowData(0);
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.dgv.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //if (dgv.Rows.Count > 0)
                //{
                //    BindItemData(0);

                //    dgv.Hide();
                //}
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (!dgv.Focused)
            {
                dgv.Hide();
            }
        }

        private void txtCharge_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    decimal _input = decimal.Parse(txtCharge.Text);
                    if (_input <= 0)
                    {
                        MessageBox.Show($"金额必须大于0");
                        return;
                    }
                     

                    if (dgvOrderDetail.SelectedRows[0].Cells["charge_amount"].Value != null)
                    {
                        dgvOrderDetail.SelectedRows[0].Cells["charge_price"].Value = txtCharge.Text;
                        dgvOrderDetail.SelectedRows[0].Cells["total_price"].Value = _input * int.Parse(dgvOrderDetail.SelectedRows[0].Cells["charge_amount"].Value.ToString());
                    }

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
                    //设焦点
                    this.dgvOrderDetail.CurrentCell = this.dgvOrderDetail[0, dgvOrderDetail.Rows.Count - 1];
                    txtName.Focus();

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
