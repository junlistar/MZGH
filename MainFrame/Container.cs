﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainFrame.Common;
using Sunny.UI;
using System.Runtime.InteropServices;
using log4net;

namespace MainFrame
{
    public partial class Container : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(Container));//typeof放当前类
        public Container()
        {
            InitializeComponent();

        }

        public string sys_key;

        /// <summary>
        /// 解决页面频繁刷新时界面闪烁问题(自定义控件拖动花屏)
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        private void Container_Initialize(object sender, EventArgs e)
        {
        }

        private void Container_Load(object sender, EventArgs e)
        {

            switch (sys_key)
            {
                case "mzgh":
                default:
                    OpenSubSystem();
                    break;
            }
        }
        Process proexe;

        public void OpenSubSystem()
        {
            try
            {

                //参数
                var _args = EmbeddedExeTool.SerializeObject(Main.vM);
                //_args = _args.Replace("\"", "\\\"");

                //获取当前系统
                var _system = Index.systemList.Where(p => p.sys_no == this.PageIndex).FirstOrDefault();
                if (_system != null)
                {
                    var _filetype = _system.file_type;
                    if (_filetype == FileTypeEnum.DLL.ToString())
                    {
                        //调用已注册的dll
                        //string path = Application.StartupPath + @"\GuXHisMzsfAndMzgh.dll";
                        string path = Application.StartupPath + _system.file_path;

                        Assembly assem = Assembly.LoadFile(path);

                        Type[] tys = assem.GetTypes();//只好得到所有的类型名，然后遍历，通过类型名字来区别了
                        foreach (Type ty in tys) 
                        {
                            if (ty.Name == "ShowWinForm")
                            {
                                ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);//获取不带参数的构造函数
                                object magicClassObject = magicConstructor.Invoke(new object[] { });

                                //object magicClassObject = Activator.CreateInstance(t);//获取无参数的构造实例还可以通过这样
                                MethodInfo mi = ty.GetMethod("SetRunParams");
                                object aa = mi.Invoke(magicClassObject, new string[] { _args });
                                try
                                {
                                    MethodInfo _gethandle = ty.GetMethod("GetWinFormHandle");
                                    object _handle = _gethandle.Invoke(magicClassObject, null);

                                    IntPtr intPtr1 = (IntPtr)_handle;
                                    while (intPtr1.ToString() == "0")
                                    {
                                        //System.Threading.Thread.Sleep(100);
                                        _handle = _gethandle.Invoke(magicClassObject, null);
                                        intPtr1 = (IntPtr)_handle;
                                    }

                                    EmbeddedExeTool exeTool = new EmbeddedExeTool();
                                    exeTool.LoadHandle(intPtr1, this);
                                    Main.clientDic.Add(this.PageIndex, intPtr1);
                                }
                                catch (Exception ex1)
                                {
                                    MessageBox.Show(ex1.Message);
                                }
                            }
                            if (ty.Name == "Class2")
                            {
                                //ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);//获取不带参数的构造函数，如果有构造函数且没有不带参数的构造函数时，这儿就不能这样子啦
                                //object magicClassObject = magicConstructor.Invoke(new object[] { });
                                //MethodInfo mi = ty.GetMethod("saybeautiful");
                                //object aa = mi.Invoke(magicClassObject, null);//方法有参数时，需要把null替换为参数的集合
                                //MessageBox.Show(aa.ToString());
                            }
                        }
                    }
                    else if (_filetype == FileTypeEnum.EXE.ToString())
                    {
                        EmbeddedExeTool exetool = new EmbeddedExeTool();
                        exetool.LoadEXE(this, Application.StartupPath + _system.file_path, Main.vM.UserMi);
                        //exetool.LoadEXE(this, Application.StartupPath + @"\mzgh\GuXHisMzsfAndMzgh.exe", Main.vM.UserMi);
                        Main.clientDic.Add(this.PageIndex, IntPtr.Zero);
                    }
                    else
                    {
                        UIMessageTip.ShowError("未处理的子程序格式:" + _filetype);
                    }
                }
                else
                {
                    UIMessageTip.ShowError("未配置系统");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("系统配置有误！请查看日志文件");
                log.Error(ex.ToString());
            }
        }
    }
}
