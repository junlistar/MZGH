using Autofac;
using LogDashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using WatchDog;


namespace CoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLogDashboard();

            services.AddWatchDogServices();

            services.AddControllers().AddControllersAsServices();//

            //services.AddMvc(opt =>
            //{
            //    opt.UseCentralRoutePrefix(new RouteAttribute("[controller]/[action]"));
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWatchDog(opt =>
            {
                opt.WatchPageUsername = "admin";
                opt.WatchPagePassword = "123";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseLogDashboard();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            string IServicePath = Path.Combine(basePath, "CoreData.dll");
            Assembly IService = Assembly.LoadFrom(IServicePath);
            builder.RegisterAssemblyTypes(IService).InstancePerDependency().PropertiesAutowired().AsImplementedInterfaces();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

    }
}
