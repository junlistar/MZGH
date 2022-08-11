using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassLib
{
    public enum PayMethodEnum
    {
        /// <summary>
        /// 微信支付
        /// </summary>
        WeiXin ,
        /// <summary>
        /// 支付宝
        /// </summary>
        Zhifubao ,
        /// <summary>
        /// 银联
        /// </summary>
        Yinlian,
        /// <summary>
        /// 医保卡
        /// </summary>
        Yibao,
        /// <summary>
        /// 现金
        /// </summary>
        Xianjin
    }
    public class PayMethod
    {  
        public static string GetPayStringByEnum(PayMethodEnum payMethod)
        {
            switch (payMethod)
            {
                case PayMethodEnum.WeiXin:
                    return "微信";
                case PayMethodEnum.Zhifubao:
                    return "支付宝";
                case PayMethodEnum.Yinlian:
                    return "银联";
                case PayMethodEnum.Yibao:
                    return "医保卡";
                case PayMethodEnum.Xianjin:
                    return "现金";
                default:
                    break;
            }
            return "其他";

        }
        public static string GetChequeTypeByEnum(PayMethodEnum payMethod)
        {
            switch (payMethod)
            {
                case PayMethodEnum.WeiXin:
                    return SessionHelper.pay_weixin;
                case PayMethodEnum.Zhifubao:
                    return SessionHelper.pay_zhifubao;
                case PayMethodEnum.Yinlian:
                    return SessionHelper.pay_yinlian;
                case PayMethodEnum.Yibao:
                    return SessionHelper.pay_yibao;
                case PayMethodEnum.Xianjin:
                    return SessionHelper.pay_xianjin;
                default:
                    break;
            }
            return "其他";

        }
        public static string GetPayStringByEnumValue(string payMethod)
        {
            if (payMethod== SessionHelper.pay_weixin)
            {
                return "微信";
            }
            else if (payMethod == SessionHelper.pay_zhifubao)
            {
                return "支付宝";
            }
            else if (payMethod == SessionHelper.pay_yinlian)
            {
                return "银联";
            }
            else if (payMethod == SessionHelper.pay_yibao)
            {
                return "医保卡";
            }
            else if (payMethod == SessionHelper.pay_xianjin)
            {
                return "现金";
            }
            else
            {
                return payMethod;
            }

        }
    }


    public enum MarryCodeEnum
    {
        /// <summary>
        /// 已婚
        /// </summary>
        [Description("已婚")]
        Yihun = 1,
        /// <summary>
        /// 未婚
        /// </summary>
        [Description("未婚")]
        Weinhun = 2,
        /// <summary>
        /// 丧偶
        /// </summary>
        [Description("丧偶")] 
        Sangou = 3,
        /// <summary>
        /// 离婚
        /// </summary>
        [Description("离婚")] 
        Lihun = 4,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Qita = 5,
    }
  
    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum en)
        {
            Type type = en.GetType();
            FieldInfo fd = type.GetField(en.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string name = string.Empty;
            foreach (DescriptionAttribute attr in attrs)
            {
                name = attr.Description;
            }
            return name;
        }
    }

}
