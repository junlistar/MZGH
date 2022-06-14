using Microsoft.Extensions.Configuration;
using System;

namespace MzsfData.Helpers
{
    public class ConfigHelper
    {
        private static readonly IConfiguration _configuration;

        static ConfigHelper()
        {
            //在当前目录或者根目录中寻找appsettings.json文件
            var fileName = "appsettings.json";

            var directory = AppContext.BaseDirectory;
            directory = directory.Replace("\\", "/");

            var filePath = $"{directory}/{fileName}";
            if (!System.IO.File.Exists(filePath))
            {
                var length = directory.IndexOf("/bin");
                filePath = $"{directory.Substring(0, length)}/{fileName}";
            }

            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true);

            _configuration = builder.Build();
        }

        /// <summary>
        /// 获取Section的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSectionValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        /// <summary>
        /// 获取ConnectionStrings下的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return _configuration.GetConnectionString(key);
        }
    }
}
