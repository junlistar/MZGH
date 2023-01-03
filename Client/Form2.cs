using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WxPayAPI;

namespace GuXHis
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            SessionHelper.MyHttpClient = HttpClientFactory.GetHttpClient();
            SessionHelper.MyHttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["apihost"]);

           var json = "";
           var paramurl = string.Format($"/api/GuaHao/GetUserDic");
            
            json = HttpClientUtil.Get(paramurl);
            SessionHelper.userDics = WebApiHelper.DeserializeObject<ResponseResult<List<UserDicVM>>>(json).data;

            userControl11.dgv.DataSource = SessionHelper.userDics;

            uiComboDataGridView1.DataGridView.Init();
            uiComboDataGridView1.ItemSize = new System.Drawing.Size(360, 240);
            uiComboDataGridView1.DataGridView.AddColumn("代码", "code");
            uiComboDataGridView1.DataGridView.AddColumn("名称", "name"); 
            uiComboDataGridView1.DataGridView.ReadOnly = true;
            uiComboDataGridView1.SelectIndexChange += UiComboDataGridView1_SelectIndexChange; ;
            uiComboDataGridView1.ShowFilter = true;
            uiComboDataGridView1.DataGridView.DataSource = SessionHelper.userDics;
            uiComboDataGridView1.FilterColumnName = "代码"; //不设置则全部列过滤
        }

        private void UiComboDataGridView1_SelectIndexChange(object sender, int index)
        {
            UIMessageTip.Show(index.ToString());
           // throw new NotImplementedException();
        }

        private void uiComboDataGridView1_TextChanged(object sender, EventArgs e)
        {
            UIMessageTip.Show(uiComboDataGridView1.Text);
        }

        private void uiComboDataGridView1_AutoValidateChanged(object sender, EventArgs e)
        {

        }

        private void uiComboDataGridView1_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void uiComboDataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void uiComboDataGridView1_ValueChanged(object sender, object value)
        {

        }

        private void uiComboDataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
