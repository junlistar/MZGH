using log4net;
using Newtonsoft.Json;
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
     
    public class ElecBillHelper
    {

        private static ILog log = LogManager.GetLogger(typeof(ElecBillHelper));//typeof放当前类

        public static bool InitCreateElecBillCom(string appid, string key, string weburl, string version, string ip, string port, string dllName, string func)
        {
            log.Debug("初始化电子发票");

            string method = "InitParams";
            string noise = Guid.NewGuid().ToString();

            var _data = new
            {
                url = weburl,
                appkey = key,
                type = "medical",
                testValue = "测试链接",
                printPreview = "0"
            };

            var stringA = $"appid={appid}&data={StringUtil.Base64Encode(JsonConvert.SerializeObject(_data))}&noise={noise}";

            //log.Debug("stringA:" + stringA);
            var stringSignTemp = stringA + $"&key={key}&version={version}";

            //log.Debug("stringSignTemp:" + stringSignTemp);

            var _sign = StringUtil.GenerateMD5(stringSignTemp).ToUpper();

            var _params = new
            {
                appid = appid,
                data = StringUtil.Base64Encode(JsonConvert.SerializeObject(_data)),
                noise = noise,
                version = version,
                sign = _sign
            };

            var _payload = new
            {
                method = method,
                @params = _params
            };
            string payload = StringUtil.Base64Encode(JsonConvert.SerializeObject(_payload));
            string url = $"http://{ip}:{port}/extend?dllName={dllName}&func={func}&payload={payload}";
             
            var json = HttpClientUtil.Get(url);

            if (json == "T2000")
            {
                return true;
            }
            return false;
        }

    }
}