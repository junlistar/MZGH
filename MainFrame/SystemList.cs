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
    public partial class SystemList : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(SystemList));//typeof放当前类

        List<SubSystemVM> systemList;
        List<SubSystemGroupVM> system_groups;

        public SystemList()
        {
            InitializeComponent();
            this.Text = "GuxHix_子系统模块功能注册";
        }
        private void AddSystem_Load(object sender, EventArgs e)
        {

            //查询初始化界面控件 
            BindData();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            //查询初始化界面控件  
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
                    systemList = result.data.OrderBy(p => p.sys_no).ToList();
                    dgvlist.DataSource = systemList.Select(p => new
                    {
                        p.sys_no,
                        p.sys_code,
                        p.sys_name,
                        p.file_path,
                        p.icon_path,
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
            AddSystem addSystem = new AddSystem();

            addSystem.ShowDialog();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

                    AddSystem addSystem = new AddSystem();
                    addSystem.vm = _system;

                    addSystem.ShowDialog();

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
