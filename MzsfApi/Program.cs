using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzsfApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string logOutputTemplate = "{Timestamp:HH:mm:ss.fff zzz} || {Level} || {SourceContext:l} || {Message} || {Exception} ||end {NewLine}";
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .MinimumLevel.Override("Default", LogEventLevel.Information)
              .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
              .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
              .Enrich.FromLogContext()
              .WriteTo.Console(theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code)
              .WriteTo.File($"{AppContext.BaseDirectory}Logs/Log.log", rollingInterval: RollingInterval.Day, outputTemplate: logOutputTemplate)
              .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseServiceProviderFactory(new AutofacServiceProviderFactory());//使用Autofac服务提供工厂(强类型)--> 集成Autofac;
    }
}
