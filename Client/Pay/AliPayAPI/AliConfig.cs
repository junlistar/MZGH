using Alipay.EasySDK.Kernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Pay.AliPayAPI
{
    public class AliConfig
    {


        public static Config GetConfig()
        {
            return new Config
            {
                Protocol = "https",
                GatewayHost = "openapi.alipay.com",
                AppId = "<-- 请填写您的AppId，例如：2019022663440152 -->",
                SignType = "RSA2",

                AlipayPublicKey = "<-- 请填写您的支付宝公钥，例如：MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAumX1EaLM4ddn1Pia4SxTRb62aVYxU8I2mHMqrc"
                   + "pQU6F01mIO/DjY7R4xUWcLi0I2oH/BK/WhckEDCFsGrT7mO+JX8K4sfaWZx1aDGs0m25wOCNjp+DCVBXotXSCurqgGI/9UrY+"
                   + "QydYDnsl4jB65M3p8VilF93MfS01omEDjUW+1MM4o3FP0khmcKsoHnYGs21btEeh0LK1gnnTDlou6Jwv3Ew36CbCNY2cYkuyP"
                   + "AW0j47XqzhWJ7awAx60fwgNBq6ZOEPJnODqH20TAdTLNxPSl4qGxamjBO+RuInBy+Bc2hFHq3pNv6hTAfktggRKkKzDlDEUwg"
                   + "SLE7d2eL7P6rwIDAQAB -->",
                //MerchantPrivateKey = GetPrivateKey("<-- 请填写您的AppId，例如：2019022663440152 -->"),
                NotifyUrl = "<-- 请填写您的异步通知接收服务器地址，例如：https://www.test.com/callback"
            };
        }

        /// <summary>
        /// 从文件中读取私钥
        /// 
        /// 注意：实际开发过程中，请务必注意不要将私钥信息配置在源码中（比如配置为常量或储存在配置文件的某个字段中等），因为私钥的保密等级往往比源码高得多，将会增加私钥泄露的风险。
        /// 推荐将私钥信息储存在专用的私钥文件中，将私钥文件通过安全的流程分发到服务器的安全储存区域上，仅供自己的应用运行时读取。
        /// </summary>
        /// <param name="appId">私钥对应的APP_ID</param>
        /// <returns>私钥字符串</returns>
        private static string GetPrivateKey(string appId)
        {
            IDictionary<string, string> json = JsonConvert.DeserializeObject<IDictionary<string, string>>(
                File.ReadAllText(GetSolutionBasePath() + "/UnitTest/Fixture/privateKey.json"));
            return json[appId];
        }
        /// <summary>
        /// 获取解决方案所在路径
        /// </summary>
        /// <returns>解决方案所在绝对路径</returns>
        public static string GetSolutionBasePath()
        {
            string current = Directory.GetCurrentDirectory();
            do
            {
                current = Directory.GetParent(current).ToString();
            }
            while (!current.EndsWith("bin", StringComparison.Ordinal));
            return current + "/../..";
        }
    }
}
