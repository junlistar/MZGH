using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ViewModel;
using log4net;
using MainFrame.Common;
using Sunny.UI;

namespace MainFrame
{
    public partial class Index : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(Index));//typeof放当前类
        public Index()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        public delegate void SetData(string clientName, int index);
        public SetData setData;
        public static List<SubSystemVM> systemList;

        private void Index_Initialize(object sender, EventArgs e)
        {
            //pnlSystem.Hide();
        }
        public void LoadSystem()
        {
            int _index = 0;
            foreach (var subSystem in systemList)
            {
                var _txt = subSystem.sys_name;
                UIButton uIButton = new UIButton();
                uIButton.Font = new Font("微软雅黑", 16, FontStyle.Regular);
                uIButton.Style = UIStyles.PopularStyles()[_index++];
                uIButton.Text = _txt;
                uIButton.Width = 370;
                uIButton.Height = 200;
                uIButton.TagString = subSystem.sys_no.ToString();
                uIButton.Click += UIButton_Click;
                pnlSystem.Controls.Add(uIButton);
            }

            for (int i = _index; i < 6; i++)
            {
                var _txt = "门诊子系统" + (i + 1).ToString();
                UIButton uIButton = new UIButton();
                uIButton.Font = new Font("微软雅黑", 16, FontStyle.Regular);
                uIButton.Style = UIStyles.PopularStyles()[i];
                uIButton.Text = _txt;
                uIButton.Width = 370;
                uIButton.Height = 200;
                uIButton.TagString = "9999";
                uIButton.Click += UIButton_Click;
                pnlSystem.Controls.Add(uIButton);
            }
            // pnlSystem.Show();
        }

        private void UIButton_Click(object sender, EventArgs e)
        {
            var _btn = sender as UIButton;

            //UIPage uIPage = new UIPage();
            //uIPage.Text = _btn.Text;

            int _sysno = int.Parse(_btn.TagString);

            //获取当前系统
            var _system = Index.systemList.Where(p => p.sys_no == _sysno).FirstOrDefault();
            if (_system == null)
            {
                UIMessageTip.ShowError("未配置系统");
            }
            else
            {
                setData(_btn.Text, _sysno);
            }

        }

        private void Index_Load(object sender, EventArgs e)
        {
            try
            {
                pnlSystem.FillColor = Color.Transparent;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "/resource/index.jpeg");
                //this.BackColor =Color.Wheat;
                BindData();
                LoadSystem();
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("加载背景图片失败！");

            }
        }
        public void BindData()
        {
            try
            {
                string json = "";
                string paramurl = string.Format($"/api/subsystem/GetSubSystems");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<SubSystemVM>>>(json);
                if (result.status == 1)
                {
                    systemList = result.data;
                }
                else
                {
                    UIMessageTip.ShowError(result.message, 2000);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message, 2000);
                log.Error(ex.ToString());
            }
        }
        private void uiLabel1_Click(object sender, EventArgs e)
        {
            AddSystem addSystem = new AddSystem();
            addSystem.FormClosing += AddSystem_FormClosing;
            addSystem.ShowDialog();
        }

        private void AddSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            BindData();
        }
    }
}
