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
using log4net;
using Sunny.UI;

namespace Client
{
    public partial class ReadCard : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(ReadCard));//typeof放当前类
        public ReadCard(string cardName)
        {
            InitializeComponent();
            _cardName = cardName;
        }

        public string _cardName = ""; CardReader dto;

        private void ReadCard_Load(object sender, EventArgs e)
        {
            this.Text = "读" + _cardName;
            SessionHelper.cardno = ""; SessionHelper.CardReader = null;
            lblmsg.ForeColor = Color.Red;
            timer1.Interval = 2000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //UIMessageTip.Show("读卡");
            if (_cardName == "身份证")
            {
                dto = ReadIdCardHelper.Reader();
                if (dto.Data != null)
                {
                    SessionHelper.cardno = dto.Data.IDCard;

                    SessionHelper.CardReader = dto.Data;

                    log.Debug("读卡信息：" + dto.Data.IDCard + "," + dto.Data.Name + "," + dto.Data.Sex);

                    this.Close();
                }
                else if (!string.IsNullOrEmpty(dto.Msg))
                {
                    lblmsg.Text = dto.Msg;
                }
            }
            else if (_cardName == "磁卡")
            {

            }
            else if (_cardName == "医保卡")
            {

            }

        }

        private void ReadCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Dispose();
        }

        private void ReadCard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
