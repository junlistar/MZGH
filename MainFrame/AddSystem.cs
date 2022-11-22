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
        List<SubSystemGroupVM> system_groups;

        public AddSystem()
        {
            InitializeComponent();
            this.Text = "GuxHix_子系统模块功能注册";
        }
        private void AddSystem_Load(object sender, EventArgs e)
        {

            //查询初始化界面控件
            btnSave.Enabled = false;
            SetControlEnabled(false);
            InitControlValue();

            BindData();
            //加载系统分组
            GetSystemGroups();
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
            //查询初始化界面控件
            btnSave.Enabled = false;
            SetControlEnabled(false);
            InitControlValue();

            BindData();
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

                    //dgvlist.DataSource = system_groups.Select(p => new
                    //{
                    //    p.group_code,
                    //    p.group_name,
                    //    p.sort,
                    //    p.update_time
                    //}).ToList();
                    //dgvlist.AutoResizeColumns();
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
                    systemList = result.data.OrderBy(p => p.sys_no).ToList();
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
                if (txt_sysgroup.SelectedValue==null)
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

                    btnSearch_Click(sender,e);
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
                    sw.WriteLine("1.0.0.0");

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "新增")
            {
                btnSave.Enabled = true;
                btnAdd.Text = "取消";
                SetControlEnabled(true);
            }
            else
            {
                btnSave.Enabled = false;
                btnAdd.Text = "新增";
                SetControlEnabled(false);  
            }
            InitControlValue();
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
            txt_relative_path.Enabled = enable;
            txt_updateurl.Enabled = enable;
            txt_sysgroup.Enabled = enable;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = this.dgvlist.SelectedIndex;
                if (_index >= 0)
                {
                    var _system = systemList[_index];

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

                    if (!string.IsNullOrWhiteSpace(_system.sys_group_code))
                    {
                        txt_sysgroup.SelectedValue = _system.sys_group_code;
                    } 

                    btnSave.Enabled = true;
                    SetControlEnabled(true); 
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = this.dgvlist.SelectedIndex;
                if (_index >= 0)
                {
                    var _system = systemList[_index];
                    string paramurl = string.Format($"/api/subsystem/DeleteSubSystem?sys_code={_system.sys_code}");

                    if (!UIMessageDialog.ShowAskDialog(this, $"确定要删除子系统: {_system.sys_name} 吗?"))
                    {
                        return;
                    }

                    var json = HttpClientUtil.Get(paramurl);
                    var result = HttpClientUtil.DeserializeObject<ResponseResult<bool>>(json);

                    if (result.status == 1)
                    {
                        UIMessageTip.ShowOk("保存成功！");

                        BindData();
                    }
                    else
                    {
                        UIMessageTip.ShowError(result.message, 2000);
                        log.Error(result.message);
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
