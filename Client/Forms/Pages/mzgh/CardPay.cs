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

namespace Client
{
    public partial class CardPay : UIForm
    {

        string _key;
        string _jine;
        public CardPay(string key, string je)
        {
            InitializeComponent();
            _key = key;
            _jine = je;
        }

        private void CardPay_Load(object sender, EventArgs e)
        {
            lblJe.Text = _jine;
            if (int.Parse(_key) == (int)PayMethodEnum.Yinlian)
            {
                lblInfo.Text = "银联卡刷卡支付";
                this.Text = "银联支付";
            }
            else if (int.Parse(_key) == (int)PayMethodEnum.Yibao)
            {
                lblInfo.Text = "医保卡刷卡支付";
                this.Text = "医保支付";
            }
        }
    }
}
