using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using log4net.Config;
using System.IO;
using log4net.Repository;
using log4net;
using System.Collections;
using System.Xml;

namespace Linux.MvcCore.Learn
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            //log4net.Config.XmlConfigurator.ConfigureAndWatch(rep, env.WebRootPath + "Log4Net.config");
            using (Stream stream = File.Open(env.ContentRootPath + "\\Log4Net.config", FileMode.Open))
            {
                XmlDocument log4netConfig = new XmlDocument();
                log4netConfig.Load(stream);
                ILoggerRepository rep = LogManager.CreateRepository("linux.mvcCore.Learn"); 
                ICollection configurationMessages = XmlConfigurator.Configure(rep, log4netConfig["log4net"]);
                //log4net.ILog log = LogManager.
            }
            
            // var item = env.ContentRootPath + "log4net.xml";
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
