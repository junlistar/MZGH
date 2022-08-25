using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassLib
{
    public class PrintUtil
    {
        private static PrintDocument fPrintDocument = new PrintDocument();
        /// <summary>
        ///获取本机默认打印机名称  
        /// </summary>
        /// <returns></returns>
        public static String DefaultPrinter()
        {
            return fPrintDocument.PrinterSettings.PrinterName;
        }
        /// <summary>
        /// 获取本地打印机集合
        /// </summary>
        /// <returns></returns>
        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<String>();
            fPrinters.Add(DefaultPrinter()); //默认打印机始终出现在列表的第一项  
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                {
                    fPrinters.Add(fPrinterName);
                }
            }
            return fPrinters;
        }

        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name);  //调用win api将指定名称的打印机设置为默认打印机

    }
}
