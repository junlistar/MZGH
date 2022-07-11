using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.ClassLib
{

    public class COMInfo
    {
        public object Instance;
        public Type COMType;
        public COMInfo(Type type, object instance)
        {
            this.Instance = instance;
            this.COMType = type;
        }
    }

    public class ComHelper
    {

        [DllImport("ole32.dll")]
        static extern int CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid pclsid);

        public static object InvokeMethod(string comName, string methodName, ref object[] args)
        {

            object ret = null;
            COMInfo com = GetCOMInfo(comName);
            try
            {
                //用参数的索引属性来指出哪些参数是一个返回的参数
                //对于那些是[in]或ByRef的参数可以不用指定
                ParameterModifier[] ParamMods = new ParameterModifier[1];
                ParamMods[0] = new ParameterModifier(3); // 初始化为接口参数的个数
                ParamMods[0][2] = true; // 设置第三个参数为返回参数


                ret = com.COMType.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, com.Instance, args, ParamMods,
                                                         null,
                                                         null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


        public static COMInfo GetCOMInfo(string comName)
        {
            COMInfo comInfo;
            Type type;
            object instance = null;
            instance = CreateInstance(comName, out type);
            comInfo = new COMInfo(type, instance);
            return comInfo;
        }


        private static object CreateInstance(string progName, out Type type)
        {
            object instance = null;
            type = null;
            try
            {
                Guid clsid;
                int result = CLSIDFromProgID(progName, out clsid);
                type = Type.GetTypeFromCLSID(clsid, true);
                instance = Activator.CreateInstance(type);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return instance;
        }

    }
}