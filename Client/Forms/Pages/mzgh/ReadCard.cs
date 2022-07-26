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
using Client.ClassLib;
using log4net;
using Sunny.UI;

namespace Client
{
    public partial class ReadCard : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(ReadCard));//typeof放当前类
        public ReadCard(string cardName, bool no_enter = false)
        {
            InitializeComponent();
            _cardName = cardName;
            _no_enter = no_enter;
        }

        public string _cardName = ""; CardReader dto;
        bool _no_enter = false;

        private void ReadCard_Load(object sender, EventArgs e)
        {
            this.Text = "读" + _cardName;
            SessionHelper.cardno = ""; SessionHelper.CardReader = null;
            lblmsg.ForeColor = Color.Red;
            timer1.Interval = 2000;
            timer1.Start();

            if (_no_enter)
            {
                uiTabControl1.TabPages.RemoveAt(1); 
            }
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

                    Task.Run(() =>
                    {
                        SaveCardData(dto.Data);
                    });

                    this.DialogResult = DialogResult.OK;
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

        public void SaveCardData(CardReader_Data data)
        {
            //获取数据  UpdateSfzInfo(string name, string sex, string address, string folk, string birthday, string card_no)
            Task<HttpResponseMessage> task = null;
            string json = "";

            var d = new
            {
                name = data.Name,
                sex = data.Sex,
                address = data.Address,
                folk = data.Folk,
                birthday = data.BirthDay,
                card_no = data.IDCard,  
            };

            string paramurl = string.Format($"/api/user/UpdateSfzInfo?name={d.name}&sex={d.sex}&address={d.address}&folk={d.folk}&birthday={d.birthday}&card_no={d.card_no}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
            try
            {
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

                //task.Wait();
                //var response = task.Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    var read = response.Content.ReadAsStringAsync();
                //    read.Wait();
                //    json = read.Result;
                //} 
                //var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                //if (result.status == 1)
                //{
                   
                //}
                //else
                //{
                //}

            }
            catch (Exception ex)
            {
                log.Debug("请求接口数据出错：" + ex.Message);
                log.Debug("接口数据：" + json);

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            DoOk();
        }

        public void DoOk()
        {
            var card_no = txt_sfz.Text.Trim();

            if (!string.IsNullOrWhiteSpace(card_no))
            {
                //验证卡号是否是身份证号
                if (!StringUtil.CheckIDCard(card_no))
                {
                    UIMessageTip.ShowError("身份证号码不正确!");
                    txt_sfz.Focus();
                    return;
                }
            }
            else
            {
                UIMessageTip.ShowError("身份证号码为空!");
                return;
            }

            SessionHelper.cardno = card_no;
            this.Close();
        }

        private void uiTabControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoOk();

            }
        }
    }
}
