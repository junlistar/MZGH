using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
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

                //var geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
                //pnl_browser.Controls.Clear();
                //pnl_browser.Controls.Add(geckoWebBrowser);
                //geckoWebBrowser.Navigate(url);


                WebBrowser = new ChromiumWebBrowser(url);
                //{
                //    // 填充整个父控件
                //    Dock = DockStyle.Fill
                //};
                WebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrameEndFunc);
                // 添加到窗口的控件列表中
                pnl_browser.Controls.Clear();
                pnl_browser.Controls.Add(WebBrowser);
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
        ChromiumWebBrowser WebBrowser;
        private void WebReport_Load(object sender, EventArgs e)
        {
            var settings = new CefSettings()
            {
                UserAgent = "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Mobile Safari/537.36",
            };

            //Perform dependency check to make sure all relevant resources are in our output directory.
            //Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            // cefsharp提供的浏览器控件，一般用它充满窗口就搞定了
            //WebBrowser = new ChromiumWebBrowser("http://www.163.com")
            //{
            //    // 填充整个父控件
            //    Dock = DockStyle.Fill
            //};
           // WebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrameEndFunc);

        }
        private void FrameEndFunc(object sender, FrameLoadEndEventArgs e)
        {
            //MessageBox.Show(WebBrowser.GetSourceAsync().Result);
            //this.BeginInvoke(new Action(() =>
            //{
            //    String html = WebBrowser.GetSourceAsync().Result;
            //    richTextBox1.Text = html;
            //}));
        }

        private void WebReport_ForeColorChanged(object sender, EventArgs e)
        {
        }

        private void WebReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
