using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using log4net;
using Sunny.UI;

namespace Client.Forms.Pages.xt
{
    public partial class MzClientConfig : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(MzClientConfig));//typeof放当前类

        public MzClientConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void MzClientConfig_Initialize(object sender, EventArgs e)
        {
            InitPrinters();

            LoadInfo();
        }

        private void InitPrinters()
        {
            var localprints = PrintUtil.GetLocalPrinters();
            cbxDefaultPrint.DataSource = localprints;
            ghprint.DataSource = localprints;
            sfprint.DataSource = localprints;
            jsbbprint.DataSource = localprints;
            //获取本地打印机配置
            ReadPrintConfig();
            cbxDefaultPrint.SelectedIndexChanged += cbxDefaultPrint_SelectedIndexChanged;
            ghprint.SelectedIndexChanged += ghprint_SelectedIndexChanged;
            sfprint.SelectedIndexChanged += sfprint_SelectedIndexChanged;
            jsbbprint.SelectedIndexChanged += jsbbprint_SelectedIndexChanged;
        }

        public void LoadInfo()
        {
            if (SessionHelper.MzClientConfigVM != null)
            {
                txt_systype.Text = SessionHelper.MzClientConfigVM.sys_type;
                txt_clientname.Text = SessionHelper.MzClientConfigVM.client_name;
                txt_clientversion.Text = SessionHelper.MzClientConfigVM.client_version;
                txt_ghsearchkeylength.Text = SessionHelper.MzClientConfigVM.client_ghsearchkey_length.ToString();
                txt_updatetime.Text = SessionHelper.MzClientConfigVM.update_time.ToString();
            }
            else
            {
                UIMessageTip.Show("没有获取到配置数据信息");
            }

        }
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveData();

        }

        public void SaveData()
        {
            try
            {

                #region 非空验证
                if (string.IsNullOrWhiteSpace(txt_clientname.Text))
                {
                    UIMessageTip.Show("客户端名称不能为空");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_clientversion.Text))
                {
                    UIMessageTip.Show("客户端版本号不能为空");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_ghsearchkeylength.Text))
                {
                    UIMessageTip.Show("挂号搜索词数量不能为空");
                    return;
                }
                #endregion

                MzClientConfigVM clientConfig = new MzClientConfigVM();
                clientConfig.sys_type = txt_systype.Text.Trim();
                clientConfig.client_name = txt_clientname.Text.Trim();
                clientConfig.client_version = txt_clientversion.Text.Trim();
                clientConfig.client_ghsearchkey_length = int.Parse(txt_ghsearchkeylength.Text);

                var paramurl = string.Format($"/api/guahao/UpdateMzClientConfig");
                var json = HttpClientUtil.PostJSON(paramurl, clientConfig);
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);

                if (responseJson.status == 1)
                {
                    UIMessageTip.Show("修改成功");

                    //客户端配置 
                    paramurl = string.Format($"/api/GuaHao/GetMzClientConfig");
                    log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                    json = HttpClientUtil.Get(paramurl);
                    MzClientConfigVM mzClientConfig = WebApiHelper.DeserializeObject<ResponseResult<MzClientConfigVM>>(json).data;
                    if (mzClientConfig != null)
                    {
                        //系统配置信息，医院名称，版本号，挂号搜索词长度配置等
                        SessionHelper.MzClientConfigVM = mzClientConfig;
                        LoadInfo();
                    }
                }
                else
                {
                    UIMessageTip.ShowError(responseJson.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxDefaultPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PrintUtil.SetDefaultPrinter(cbxDefaultPrint.Text);
            EditFile(5, "default=" + cbxDefaultPrint.Text, Application.StartupPath + "\\config.ini");

        }


        public void ReadPrintConfig()
        {
            //判断文件是否存在
            if (!File.Exists(Application.StartupPath + "\\config.ini"))
            {
                //File.Create(Application.StartupPath + "\\AlarmSet.txt");//创建该文件

                FileStream fs1 = new FileStream(Application.StartupPath + "\\config.ini", FileMode.Create, FileAccess.Write);//创建写入文件 

                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine("[printer]");//开始写入值
                sw.WriteLine("ghxp=");
                sw.WriteLine("sfxp=");
                sw.WriteLine("jsbb=");
                sw.WriteLine("default=");

                sw.Close();
                fs1.Close();
            }
            //读取配置
            //读取文件值并显示到窗体
            FileStream fs = new FileStream(Application.StartupPath + "\\config.ini", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            int curLine = 0;
            while (line != null)
            { 

                if (++curLine == 2)//文件第2行
                {
                    var _ghxp = line.Substring(line.LastIndexOf("=") + 1);//截取=号后边的值
                    if (!string.IsNullOrWhiteSpace(_ghxp))
                    {
                        ghprint.Text = _ghxp;
                    } 
                }
                else if(++curLine == 3)
                {
                    var _sfxp = line.Substring(line.LastIndexOf("=") + 1);
                    if (!string.IsNullOrWhiteSpace(_sfxp))
                    {
                        sfprint.Text = _sfxp;
                    }
                }
                else if (++curLine == 4)
                {
                    var _jsbb = line.Substring(line.LastIndexOf("=") + 1);
                    if (!string.IsNullOrWhiteSpace(_jsbb))
                    {
                        jsbbprint.Text = _jsbb;
                    }
                }
                else if (++curLine == 5)
                {
                    var _def = line.Substring(line.LastIndexOf("=") + 1);
                    if (!string.IsNullOrWhiteSpace(_def))
                    {
                        cbxDefaultPrint.Text = _def;
                    }
                }
                 
                line = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }

        #region 设置匹配

        public static void EditFile(int curLine, string newLineValue, string patch)
        {
            FileStream fs = new FileStream(patch, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8"));//解决写入文件乱码
            string line = sr.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; line != null; i++)
            {
                sb.Append(line + "\r\n");
                if (i != curLine - 1)
                    line = sr.ReadLine();
                else
                {
                    sr.ReadLine();
                    line = newLineValue;
                }
            }
            sr.Close();
            fs.Close();
            FileStream fs1 = new FileStream(patch, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.Write(sb.ToString());
            sw.Close();
            fs.Close();
        }

        #endregion

        private void ghprint_SelectedIndexChanged(object sender, EventArgs e)
        { 
            EditFile(2, "ghxp=" + ghprint.Text, Application.StartupPath + "\\config.ini");
        }

        private void sfprint_SelectedIndexChanged(object sender, EventArgs e)
        { 
            EditFile(3, "sfxp=" + sfprint.Text, Application.StartupPath + "\\config.ini");
        }

        private void jsbbprint_SelectedIndexChanged(object sender, EventArgs e)
        { 
            EditFile(4, "jsbb=" + jsbbprint.Text, Application.StartupPath + "\\config.ini");
        }
    }
}
