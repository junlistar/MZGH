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
using Sunny.UI;

namespace Client.Forms.Wedgit
{
    public partial class YBJSPreview : UIForm
    {
        public YBJSPreview()
        {
            InitializeComponent();
        }

        public MzjsResponse mzjsResponse;

        private void YBJSPreview_Load(object sender, EventArgs e)
        {
            if (mzjsResponse!=null)
            {
                if (mzjsResponse.setlinfo!=null)
                {
                    this.lblybkname.ForeColor = Color.Red;
                    this.lblprice.ForeColor = Color.Red;
                    this.lblSyje.ForeColor = Color.Red;

                    this.lblybkname.Text = mzjsResponse.setlinfo.psn_name;
                    this.lblprice.Text = mzjsResponse.setlinfo.medfee_sumamt;
                    this.lblSyje.Text = mzjsResponse.setlinfo.balc;

                }

                if (mzjsResponse.setldetail != null)
                {
                    var _dat = mzjsResponse.setldetail.Select(p=>new
                    {
                        fund_pay_type_name = p.fund_pay_type_name,
                        fund_payamt = p.fund_payamt
                    });
                    dgv_detail.Init();
                    dgv_detail.DataSource = _dat.ToList();
                }
            }
           
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
