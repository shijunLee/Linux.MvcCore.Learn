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
using Linux.MvcCore.Learn.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Linux.MvcCore.Learn.DDL.UserManager;
using Linux.MvcCore.Learn.DDL.BlogManager;
using Linux.MvcCore.Learn.Common;
using Linux.MVC.Learn.GlobalFilter;

namespace Linux.MvcCore.Learn
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
             
            using (Stream stream = File.Open(env.ContentRootPath + "/Log4Net.config", FileMode.Open))
            {
                XmlDocument log4netConfig = new XmlDocument();
                log4netConfig.Load(stream);
                ILoggerRepository rep = LogManager.CreateRepository("linux.mvcCore.Learn"); 
                ICollection configurationMessages = XmlConfigurator.Configure(rep, log4netConfig["log4net"]);
                
            }
             
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
            services.AddDataProtection(option =>
            {
                option.ApplicationDiscriminator= "MvcCoreLearn";
            });

            var connection = Configuration["dataConnection:SqliteConnectionString"];

            services.AddDbContext<LearnContext>(options =>
                options.UseSqlite(connection)
            );
            // Add framework services.
            services.AddMvc(config =>
            { 
                config.Filters.Add( new WebAppFilter());
            });


            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IAdminIndex, AdminIndex>();
            services.AddScoped<IBlogCommentManage, BlogCommentManage>();
            services.AddScoped<IBlogPostManager, BlogPostManager>();
            services.AddScoped<IBlogTagManage, BlogTagManage>();
            services.AddScoped<IHomeMainManager, HomeMainManager>();
            services.AddScoped<ISpamShieldService, SpamShieldService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           var dataProtection = DataProtectionProvider.Create(env.ContentRootPath + "\\keys");
           // var dataProtection = new DataProtectionProvider(new DirectoryInfo(@"C:\keys"));// no use UNC share
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationScheme = "MyCookieMiddlewareInstance",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(43200),
                LoginPath = new PathString("/Admin/login"),
                CookieName = ".MvcCoreLearnCookie",
                CookiePath = "/",
                DataProtectionProvider = dataProtection
            });
           

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

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
