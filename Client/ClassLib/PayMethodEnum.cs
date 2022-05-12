using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassLib
{
    public enum PayMethodEnum
    {
        /// <summary>
        /// 微信支付
        /// </summary>
        WeiXin = 12,
        /// <summary>
        /// 支付宝
        /// </summary>
        Zhifubao = 11,
        /// <summary>
        /// 银联
        /// </summary>
        Yinlian = 14,
        /// <summary>
        /// 医保卡
        /// </summary>
        Yibao = 6,
        /// <summary>
        /// 现金
        /// </summary>
        Xianjin = 1,
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
    }

}
