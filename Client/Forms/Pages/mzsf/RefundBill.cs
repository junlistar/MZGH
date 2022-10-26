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
    public partial class RefundBill : UIForm
    {
        public RefundBill()
        {
            InitializeComponent();
        }

        public MzDepositVM[] deposit_list;
        public decimal zje;
        public decimal tkje;

        private void RefundBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void RefundBill_Load(object sender, EventArgs e)
        {
            StyleHelper.SetGridColor(dgvDeposit);//设置样式

            if (deposit_list != null)
            {
                lbltje.Text = tkje.ToString();
                lblzje.Text = zje.ToString();
                lblzje2.Text = (zje - tkje).ToString();
                if (zje!=tkje)
                {
                    deposit_list = new MzDepositVM[1] { new MzDepositVM()};
                    deposit_list[0].cheque_name = "现金";
                    deposit_list[0].bcje = zje - tkje;
                    deposit_list[0].charge = zje;
                    deposit_list[0].ytje = tkje;
                     
                    lbltxj.Text = tkje.ToString();

                    //var depo = deposit_list.Where(p => p.cheque_name == "现金").FirstOrDefault();
                    //if (depo!=null)
                    //{
                    //    depo.bcje = zje - tkje;
                    //    depo.ytje = tkje;
                    //}
                    //else
                    //{

                    //}
                    
                }
                else
                {
                    foreach (var item in deposit_list)
                    {
                        item.bcje = 0;
                        item.ytje = item.charge;
                    }
                }

                var dat = deposit_list.Select(p => new
                {
                    cheque_name = p.cheque_name,
                    bcje = p.bcje, 
                    charge = p.charge,
                    ytje = p.ytje

                }).ToList();
                dgvDeposit.Init();
                dgvDeposit.DataSource = dat;
                dgvDeposit.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            }
        }
    }
}
