using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassLib
{
    /// <summary>
    /// dll文件读取的方法
    /// </summary>
    /// <param name="strDllName"></param>
    /// <returns></returns>
    public static class IDR210
    {

        [DllImport("kernel32")]
        public static extern int LoadLibrary(string strDllName);
        [DllImport("idCardDll/sdtapi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SDT_OpenPort(int iPort);
        [DllImport("idCardDll/sdtapi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SDT_ClosePort(int iPort);
        [DllImport("idCardDll/sdtapi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SDT_StartFindIDCard(int iPort, ref byte pRAPDU, int iIfOpen);
        [DllImport("idCardDll/sdtapi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SDT_SelectIDCard(int iPort, ref byte pRAPDU, int iIfOpen);
        [DllImport("idCardDll/sdtapi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SDT_ReadBaseMsg(int iPort, ref byte pucCHMsg, ref int puiCHMsgLen, ref byte pucPHMsg, ref int puiPHMsgLen, int iIfOpen);
        [DllImport("idCardDll/sdtapi.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SDT_ReadNewAppMsg(int iPort, ref byte pucAppMsg, ref int puiAppMsgLen, int iIfOpen);
        [DllImport("idCardDll/WltRS.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
        public static extern int GetBmp(string filename, int nType);
    }
    /// <summary>
    /// 读卡器数据返回类
    /// </summary>
    public class CardReader
    {
        /// <summary>
        /// 身份证信息
        /// </summary>
        public CardReader_Data Data { get; set; }
        /// <summary>
        /// 读卡器异常消息
        /// </summary>
        public string Msg { get; set; }
    }
    public class CardReader_Data
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 名族
        /// </summary>
        public string Folk { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string BirthDay { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgPath { get; set; }

    }
    public class ReadIdCardHelper
    { 
        /// <summary>
        /// 获取姓名
        /// </summary>
        /// <returns></returns>
        public static string GetEpr6000Name(int puiCHMsgLen, byte[] pucCHMsg)
        {
            string Name = "";
            if (puiCHMsgLen == 0)
            {
                return "";
            }
            Name = System.Text.Encoding.Unicode.GetString(pucCHMsg, 0, 30);
            return Name.Trim();
        }
        /// <summary>
        /// 获取性别
        /// </summary>
        /// <returns></returns>
        public static string GetSex(int puiCHMsgLen, byte[] pucCHMsg)
        {
            if (puiCHMsgLen == 0)
            {
                return " ";
            }

            byte sex = pucCHMsg[30];

            if (sex == '1')
            {
                return "男";
            }
            else
                return "女";

        }
        /// <summary>
        ///获取名族
        /// </summary>
        /// <returns></returns>
        public static string GetPeople(int puiCHMsgLen, byte[] pucCHMsg)
        {
            string str = "";
            if (puiCHMsgLen == 0)
            {
                return " ";
            }

            str = System.Text.Encoding.Unicode.GetString(pucCHMsg, 32, 4);
            switch (str)
            {
                case "01": return "汉";
                case "02": return "蒙古";
                case "03": return "回";
                case "04": return "藏";
                case "05": return "维吾尔";
                case "06": return "苗";
                case "07": return "彝";
                case "08": return "壮";
                case "09": return "布依";
                case "10": return "朝鲜";
                case "11": return "满";
                case "12": return "侗";
                case "13": return "瑶";
                case "14": return "白";
                case "15": return "土家";
                case "16": return "哈尼";
                case "17": return "哈萨克";
                case "18": return " 傣";
                case "19": return " 黎";
                case "20": return " 傈僳";
                case "21": return " 佤";
                case "22": return " 畲";
                case "23": return " 高山";
                case "24": return " 拉祜";
                case "25": return " 水";
                case "26": return " 东乡";
                case "27": return " 纳西";
                case "28": return " 景颇";
                case "29": return " 柯尔克孜";
                case "30": return " 土";
                case "31": return " 达斡尔";
                case "32": return " 仫佬";
                case "33": return "羌";
                case "34": return "布朗";
                case "35": return "撒拉";
                case "36": return "毛南";
                case "37": return "仡佬";
                case "38": return "锡伯";
                case "39": return "阿昌";
                case "40": return "普米";
                case "41": return "塔吉克";
                case "42": return "怒";
                case "43": return "乌孜别克";
                case "44": return "俄罗斯";
                case "45": return "鄂温克";
                case "46": return "德昂";
                case "47": return "保安";
                case "48": return "裕固";
                case "49": return "京";
                case "50": return "塔塔尔";
                case "51": return "独龙";
                case "52": return "鄂伦春";
                case "53": return "赫哲";
                case "54": return "门巴";
                case "55": return "珞巴";
                case "56": return "基诺";
                case "97": return "其他";
                case "98": return "外国血统中国籍人士";
                default: return "";
            }
        }
        /// <summary>
        /// 返回生日
        /// </summary>
        /// <returns></returns>
        public static string GetBirthday(int puiCHMsgLen, byte[] pucCHMsg)
        {

            if (puiCHMsgLen == 0)
            {
                return " ";
            }
            return System.Text.Encoding.Unicode.GetString(pucCHMsg, 36, 16).Trim();
        }
        /// <summary>
        /// 返回地址
        /// </summary>
        /// <param name="puiCHMsgLen"></param>
        /// <param name="pucCHMsg"></param>
        /// <returns></returns>
        public static string GetAddress(int puiCHMsgLen, byte[] pucCHMsg)
        {
            if (puiCHMsgLen == 0)
                return " ";
            return System.Text.Encoding.Unicode.GetString(pucCHMsg, 52, 70);
        }
        /// <summary>
        /// 返回身份证号码
        /// </summary>
        /// <returns></returns>
        public static string GetIDCode(int puiCHMsgLen, byte[] pucCHMsg)
        {
            if (puiCHMsgLen == 0)
                return "";
            return System.Text.Encoding.Unicode.GetString(pucCHMsg, 122, 36).Trim();
        }
        /// <summary>
        /// 返回签发机关
        /// </summary>
        /// <returns></returns>
        public static string GetAuthority(int puiCHMsgLen, byte[] pucCHMsg)
        {
            if (puiCHMsgLen == 0)
                return " ";
            return System.Text.Encoding.Unicode.GetString(pucCHMsg, 158, 30).Trim();
        }
        /// <summary>
        /// 返回起始有效期限 如有效期2010~2020
        /// </summary>
        /// <returns></returns>
        public static string GetIssueDay(int puiCHMsgLen, byte[] pucCHMsg)
        {
            if (puiCHMsgLen == 0)
                return "";
            return System.Text.Encoding.Unicode.GetString(pucCHMsg, 188, 16);
        }
        /// <summary>
        /// 返回结束有效期限 如有效期2010~2020
        /// </summary>
        /// <returns></returns>
        public static string GetExpityDay(int puiCHMsgLen, byte[] pucCHMsg)
        {
            if (puiCHMsgLen == 0)
                return "";
            return System.Text.Encoding.Unicode.GetString(pucCHMsg, 204, 16); ;
        }

        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <returns></returns>
        public static CardReader Reader()
        {
            CardReader Read = new CardReader();
            try
            { 
                CardReader_Data Data = new CardReader_Data();
                bool m_bNIDapi = false;
                //读取到的 ID 卡内文字信息， 
                byte[] pucCHMsg = new byte[512];
                //，读取到的 ID 卡内照片信息 
                byte[] pucPHMsg = new byte[1024];
                int puiCHMsgLen = 512;
                int puiPHMsgLen = 1024;
                int m_nOpenPort = 0;
                bool m_bIsIDCardLoaded = false;
                ///判断dll文件是否存在,dll文件存放在Debug文件夹下
                int nRet = IDR210.LoadLibrary("idCardDll/sdtapi.dll");
                if (nRet == 0)
                {
                    Read.Msg = "精伦IDR210：未找到sdtapi.dll文件";
                    return Read;
                }
                //判断是否连接读卡器
                for (int iPort = 1001; iPort < 1017; iPort = iPort + 1)
                {
                    int a = IDR210.SDT_OpenPort(iPort);
                    if (a == 0x90)
                    {
                        m_nOpenPort = iPort;
                        m_bNIDapi = true;
                        break;
                    }
                }
                if (!m_bNIDapi)
                {
                    Read.Msg = "精伦IDR210：连接至读卡器失败!";
                    return Read;
                }
                byte[] pRAPDU = new byte[30];
                byte[] pucAppMsg = new byte[320];
                int len = 320;
                nRet = IDR210.SDT_ReadNewAppMsg(m_nOpenPort, ref pucAppMsg[0], ref len, 0);
                /*if (nRet == 0x91 || nRet == 0x90)
                 {
                   Read.Msg = "精伦IDR210：此身份证信息已经读取过!";
                    return Read;
                 }*/
                nRet = IDR210.SDT_StartFindIDCard(m_nOpenPort, ref pRAPDU[0], 0);
                if (nRet != 0x9F)
                {
                    Read.Msg = "精伦IDR210：请重新放置身份证!";
                    return Read;
                }
                if (IDR210.SDT_SelectIDCard(m_nOpenPort, ref pRAPDU[0], 0) != 0x90)
                {
                    Read.Msg = "精伦IDR210：读取身份证信息失败!";
                    return Read;
                }
                nRet = IDR210.SDT_ReadBaseMsg(m_nOpenPort, ref pucCHMsg[0], ref puiCHMsgLen, ref pucPHMsg[0], ref puiPHMsgLen, 0);
                if (nRet != 0x90 && nRet != 144)
                {
                    Read.Msg = "精伦IDR210：读取身份证信息失败!";
                    return Read;
                }
                Data.Name = GetEpr6000Name(puiCHMsgLen, pucCHMsg);
                Data.Sex = GetSex(puiCHMsgLen, pucCHMsg);
                Data.BirthDay = DateTime.ParseExact(GetBirthday(puiCHMsgLen, pucCHMsg), "yyyyMMdd", null).ToString();
                Data.Address = GetAddress(puiCHMsgLen, pucCHMsg);
                Data.IDCard = GetIDCode(puiCHMsgLen, pucCHMsg);
                Data.Folk = GetPeople(puiCHMsgLen, pucCHMsg);
                //保存wlt文件。然后从Wlt文件里面读取图片信息。保存图片
                string uuid = Guid.NewGuid().ToString();
                //string path = string.Format("{0}\\Images", Application.StartupPath);
                //string savepath = string.Format("{0}\\{1}.wlt", path, uuid);
                //FileStream fs;
                //fs = new FileStream(savepath, FileMode.Create, FileAccess.ReadWrite);
                //fs.Write(pucPHMsg, 0, pucPHMsg.Length);
                //fs.Close();
                //IDR210.GetBmp(savepath, 2);
                //Data.ImgPath = path + string.Format("\\{0}.bmp", uuid);
                Read.Data = Data;
                return Read;
            }
            catch
                {
                Read.Msg = "精伦IDR210：读取身份证信息出错!";
                return Read;
            }
        }

    } 
 
}
