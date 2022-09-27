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

namespace Client.Forms.Pages.mzsf
{
    public partial class OrderTemplateSelect : UIForm
    {
        public string _code;
         
        public delegate void SetData();
        public SetData setData;


        public OrderTemplateSelect()
        {
            InitializeComponent();
        }

        private void OrderTemplateSelect_Load(object sender, EventArgs e)
        {
            StyleHelper.SetGridColor(dgvTp);//设置样式
            StyleHelper.SetGridColor(dgvTpDetails);//设置样式
            LoadTemplate();
        }

        public void LoadTemplate()
        {
            if (!string.IsNullOrEmpty(_code)&& SessionHelper.MzChargePatterns!=null)
            {
                var _dat = SessionHelper.MzChargePatterns.Where(p => p.code == _code).ToList();
                dgvTp.DataSource = _dat.Select(p=> new
                {selmb=1,
                    p.code,p.d_code,p.py_code,p.name
                }).ToList();
                dgvTp.Init();

                LoadDetails(_dat[0].code);
            }
        }

        public void LoadDetails(string tmp_code)
        {
            if (!string.IsNullOrEmpty(tmp_code) && SessionHelper.MzChargePatternDetails!=null)
            {
                var _dat = SessionHelper.MzChargePatternDetails.Where(p => p.code == tmp_code).ToList();
                dgvTpDetails.DataSource = _dat.Select(p=> new
                {
                    //seldetail = 1,
                    order_name = p.order_name??"",
                    charge_code = p.charge_code ?? "",
                    charge_name = p.charge_name??"",
                    serial=p.serial??"",
                    quantity=p.quantity,
                    price=p.orig_price,
                    exec_unit = p.exec_unit??""
                }).ToList();
                dgvTpDetails.Init();
                SetCheckBox();
            }
        }

        public void SetCheckBox()
        {
            foreach (DataGridViewRow row in dgvTpDetails.Rows)
            {
                row.Cells[0].Value = "1";
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            try
            {

            SessionHelper.mbChargeList = new List<CprChargesVM>();
            foreach (DataGridViewRow row in dgvTpDetails.Rows)
            { 
                //将选择的项目添加
                if (row.Cells[0].Value.ToString()=="1")
                { 
                    var _code = row.Cells["charge_code"].Value.ToString();
                    var _exec_unit = row.Cells["exec_unit"].Value.ToString();
                    var _order_name = row.Cells["order_name"].Value.ToString();
                    var _charge_name = row.Cells["charge_name"].Value.ToString();
                    var _serial = row.Cells["serial"].Value.ToString();
                    var _quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                    var _price = Convert.ToDecimal(row.Cells["price"].Value); 

                    if (_order_name=="诊疗")
                    {
                        var chargeVM = new CprChargesVM();
                        chargeVM.charge_code_lookup = _charge_name;
                        chargeVM.orig_price = _price;
                        chargeVM.charge_amount = _quantity; 
                        chargeVM.serial_no = _serial; 
                        chargeVM.charge_code = _code; 
                        chargeVM.exec_sn = _exec_unit;
                        SessionHelper.mbChargeList.Add(chargeVM);
                    }
                }
            } 

            setData();
            this.Close();
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
