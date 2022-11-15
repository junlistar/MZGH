using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
    public partial class AddSystem : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(AddSystem));//typeof放当前类

        List<SubSystemVM> systemList;

        public AddSystem()
        {
            InitializeComponent();
            this.Text = "GuxHix_子系统模块功能注册";
        }
        private void AddSystem_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void txtFilePath_ButtonClick(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Title = "请选择DLL文件或者EXE文件";
            openFileDialog1.Filter = "dll文件|*.dll|exe文件|*.exe";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var _filePath = openFileDialog1.FileName;     //显示文件路径 
                this.txt_filepath.Text = _filePath.Replace(Application.StartupPath, "");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
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
                    dgvlist.DataSource = systemList.Select(p => new
                    {
                        p.sys_no,
                        p.sys_code,
                        p.sys_name,
                        p.file_path,
                        p.file_type,
                        p.open_mode_str,
                    }).ToList();
                    dgvlist.AutoResizeColumns();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_syscode.Text))
                {
                    UIMessageTip.ShowError("系统标识不能为空", 2000);
                    txt_syscode.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_sysname.Text))
                {
                    UIMessageTip.ShowError("系统名称不能为空", 2000);
                    txt_sysname.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_filepath.Text))
                {
                    UIMessageTip.ShowError("文件路径不能为空", 2000);
                    txt_filepath.Focus();
                    return;
                }
                SubSystemVM subSystemVM = new SubSystemVM();
                subSystemVM.sys_code = txt_syscode.Text;
                subSystemVM.sys_name = txt_sysname.Text;
                subSystemVM.sys_no = int.Parse(txt_sysno.Text);
                subSystemVM.file_path = txt_filepath.Text;
                subSystemVM.file_type = txt_filetype.Text;
                subSystemVM.icon_path = txt_iconpath.Text;
                subSystemVM.sys_desc = txt_sysdesc.Text;
                if (txt_openmode.Text == "程序内嵌入")
                {
                    subSystemVM.open_mode = 1;
                }
                else if (txt_openmode.Text == "外部打开")
                {
                    subSystemVM.open_mode = 2;
                }
                else
                {
                    subSystemVM.open_mode = 1;
                }

                subSystemVM.active_flag = 1;

                string paramurl = string.Format($"/api/subsystem/UpdateSubSystem");

                var json = HttpClientUtil.PostJSON(paramurl, subSystemVM);
                var result = HttpClientUtil.DeserializeObject<ResponseResult<bool>>(json);

                if (result.status == 1)
                {
                    UIMessageTip.ShowOk("保存成功！");

                    //注册dll
                    RegisterDLL(subSystemVM.file_path);

                    SetControlEnabled(false);
                    BindData();
                }
                else
                {
                    UIMessageTip.ShowError(result.message, 2000);
                    log.Error(result.message);
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetControlEnabled(true);
        }

        public void SetControlEnabled(bool enable)
        {
            txt_syscode.Enabled = enable;
            txt_sysname.Enabled = enable;
            txt_sysno.Enabled = enable;
            txt_filepath.Enabled = enable;
            txt_filetype.Enabled = enable;
            txt_iconpath.Enabled = enable;
            txt_openmode.Enabled = enable;
            txt_sysdesc.Enabled = enable;

            if (systemList != null)
            {
                int maxno = systemList.Select(p => p.sys_no).Max();
                txt_sysno.Text = (++maxno).ToString();

                txt_filetype.Text = txt_filetype.Items[0].ToString();
                txt_openmode.Text = txt_openmode.Items[0].ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RegisterDLL(string dllPath)
        {
            var _batContent = $@"@echo off
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe {Application.StartupPath + dllPath }";
            var filePath = Application.StartupPath + @"\myBat.bat";
            WriteBatFile(filePath, _batContent);

            ProcessStartInfo myBat = new ProcessStartInfo()
            {
                FileName = filePath,
                WorkingDirectory = Directory.GetCurrentDirectory(),
                UseShellExecute = false
            };
            Process.Start(myBat).WaitForExit();

            UIMessageTip.ShowOk("注册dll成功！");
        }

        //批处理文件创建
        public void WriteBatFile(string filePath, string fileContent)
        {
            try
            {
                if (File.Exists(filePath))
                { 
                    File.Delete(filePath);
                }
                FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);//创建写入文件
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(fileContent);//开始写入值
                sw.Close();
                fs1.Close();
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = this.dgvlist.SelectedIndex;
                if (_index >= 0)
                {
                    var _system = systemList[_index];
                    if (_system.file_type.ToUpper() == FileTypeEnum.DLL.ToString())
                    {
                        RegisterDLL(_system.file_path);
                    }
                    else
                    {
                        UIMessageTip.ShowError("不是dll文件，无需注册");
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }
    }
}
