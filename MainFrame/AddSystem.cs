using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public SubSystemVM vm;
        List<SubSystemVM> systemList;
        List<SubSystemGroupVM> system_groups;

        public AddSystem()
        {
            InitializeComponent();
        }
        private void AddSystem_Load(object sender, EventArgs e)
        {
            //查询初始化界面控件 
            InitControlValue();

            //加载系统分组
            GetSystemGroups();
            GetSystemIds();
            GetGroupNames();

            if (vm != null)
            {
                BindEditData();
            }
        }

        public void BindEditData()
        {
            var _system = vm;

            txt_syscode.Text = _system.sys_code;
            txt_sysname.Text = _system.sys_name;
            txt_sysno.Text = _system.sys_no.ToString();
            txt_filepath.Text = _system.file_path;
            txt_iconpath.Text = _system.icon_path;
            txt_sysdesc.Text = _system.sys_desc;
            txt_updateurl.Text = _system.sys_update_url;
            txt_relative_path.Text = _system.sys_relative_path;

            txt_filetype.Text = _system.file_type.ToUpper();
            txt_openmode.Text = txt_openmode.Items[_system.open_mode - 1].ToString();

            if (!string.IsNullOrWhiteSpace(_system.subsys_id))
            {
                cbx_sysid.Text = _system.subsys_id;
            }

            if (!string.IsNullOrWhiteSpace(_system.group_no))
            {
                cbx_groupno.SelectedValue = _system.group_no;
            }
            if (!string.IsNullOrWhiteSpace(_system.sys_group_code))
            {
                txt_sysgroup.SelectedValue = _system.sys_group_code;
            }
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


        public void GetSystemGroups()
        {
            try
            {
                string json = "";
                string paramurl = string.Format($"/api/subsystem/GetSubSystemGroups");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<SubSystemGroupVM>>>(json);
                if (result.status == 1)
                {
                    system_groups = result.data.OrderBy(p => p.sort).ToList();
                    txt_sysgroup.DataSource = system_groups;
                    txt_sysgroup.ValueMember = "group_code";
                    txt_sysgroup.DisplayMember = "group_name";

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

        public void GetSystemIds()
        {
            try
            {
                string json = "";
                string paramurl = string.Format($"/api/subsystem/GetSubsysIds?user_name={SessionHelper.uservm.user_name}");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<string>>>(json);
                if (result.status == 1)
                {
                    cbx_sysid.DataSource = result.data;
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


        public void GetGroupNames()
        {
            try
            { 
                cbx_groupno.DataSource = SessionHelper.ypGroupsList;
                cbx_groupno.DisplayMember = "dept_name";
                cbx_groupno.ValueMember = "group_no"; 
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
                if (txt_sysgroup.SelectedValue == null)
                {
                    UIMessageTip.ShowError("系统分组不能为空", 2000);
                    txt_sysgroup.Focus();
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
                subSystemVM.sys_update_url = txt_updateurl.Text;
                subSystemVM.sys_relative_path = txt_relative_path.Text;
                subSystemVM.sys_group_code = txt_sysgroup.SelectedValue.ToString();
                subSystemVM.subsys_id = cbx_sysid.SelectedValue.ToString().Trim();
                subSystemVM.group_no = cbx_groupno.SelectedValue.ToString().Trim();

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
                    if (subSystemVM.file_type == FileTypeEnum.DLL.ToString())
                    {
                        //注册dll
                        RegisterDLL(subSystemVM.file_path);
                    }

                    //增加本地配置文件
                    AddLocalVersionFile(subSystemVM.sys_code);

                    this.Close();

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

        public void AddLocalVersionFile(string sys_code)
        {
            try
            {
                //判断文件是否存在
                var _versionFileFolder = Application.StartupPath + "\\version";
                if (!File.Exists($"{_versionFileFolder}\\{sys_code}.ini"))
                {
                    if (!Directory.Exists(_versionFileFolder))
                    {
                        Directory.CreateDirectory(_versionFileFolder);
                    }

                    // File.Create(Application.StartupPath + $"\\version\\{sys_code}.ini");//创建该文件

                    FileStream fs1 = new FileStream(Application.StartupPath + $"\\version\\{sys_code}.ini", FileMode.Create, FileAccess.Write);//创建写入文件 

                    StreamWriter sw = new StreamWriter(fs1);
                    sw.WriteLine("0.0.0.0");

                    sw.Close();
                    fs1.Close();
                }
                //读取配置
                ////读取文件值并显示到窗体
                //FileStream fs = new FileStream(Application.StartupPath + $"\\version\\{sys_code}.ini", FileMode.Open, FileAccess.ReadWrite);
                //StreamReader sr = new StreamReader(fs);
                //string line = sr.ReadLine();

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("创建版本文件失败，请查看日志信息！");
                log.Error(ex.ToString());
            }
        }




        public void InitControlValue()
        {
            txt_syscode.Text = "";
            txt_sysname.Text = "";
            txt_sysno.Text = "";
            txt_filepath.Text = "";
            txt_iconpath.Text = "";
            txt_sysdesc.Text = "";

            if (systemList != null)
            {
                int maxno = systemList.Select(p => p.sys_no).Max();
                txt_sysno.Text = (++maxno).ToString();

                txt_filetype.Text = txt_filetype.Items[0].ToString();
                txt_openmode.Text = txt_openmode.Items[0].ToString();
            }
        }


        public void RegisterDLL(string dllPath)
        {
            var _batContent = $@"@echo off
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe {Application.StartupPath + dllPath}";
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


        private void txt_iconpath_ButtonClick(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Title = "请选择图片文件";
            openFileDialog1.Filter = "图片文件|*.jpg;*.gif;*.bmp;*.png;*.ico";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var _filePath = openFileDialog1.FileName;     //显示文件路径 
                this.txt_iconpath.Text = _filePath.Replace(Application.StartupPath, "");
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
