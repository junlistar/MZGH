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

namespace Client.Forms.Pages.yhbb
{
    public partial class WebReport : UIPage
    {
        public WebReport()
        {
            InitializeComponent();
        }

        private void WebReport_Initialize(object sender, EventArgs e)
        {
            LoadReportList();
            ControlHelper.SetIE(ControlHelper.IeVersion.标准ie8);
        }

        public void LoadReportList()
        {
            tv_reports.Nodes.Clear();

            var paramurl = string.Format($"/api/Report/GetMzWebReports");
            var json = HttpClientUtil.Get(paramurl);
            var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzWebReportVM>>>(json);

            if (result.status == 1)
            {
                foreach (MzWebReportVM item in result.data)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Name = item.code;
                    treeNode.Text = item.name;
                    treeNode.Tag = item.url;

                    this.tv_reports.Nodes.Add(treeNode);
                }
            }
        }

        private void tv_reports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string url = "";
            try
            { 
                var _obj = sender as UITreeView;
                //UIMessageTip.Show(_obj.SelectedNode.Name);

                url = _obj.SelectedNode.Tag.ToString();

                webBrowser1.Url = new Uri(url); 
            }
            catch (Exception ex)
            {
                UIMessageBox.Show($"打开WEB地址失败：{url}");
              
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            WebReportEdit webReportEdit = new WebReportEdit();
            webReportEdit.ShowDialog();
            LoadReportList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            WebReportEdit webReportEdit = new WebReportEdit();
            webReportEdit._code = tv_reports.SelectedNode.Name;
            webReportEdit.ShowDialog();
            LoadReportList();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
