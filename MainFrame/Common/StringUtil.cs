using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainFrame.Common
{
    public class StringUtil
    {
        public static string Base64Encode(string str)
        {
            var _strBytes = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Convert.ToBase64String(_strBytes);
        }
        public static string Base64Decode(string base64EncodeData)
        {
            var _base64EncodeBytes = System.Convert.FromBase64String(base64EncodeData);
            return System.Text.Encoding.UTF8.GetString(_base64EncodeBytes);
        }
    }
}
