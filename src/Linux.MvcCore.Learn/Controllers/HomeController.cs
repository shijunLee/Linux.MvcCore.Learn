using System;
using System.Collections.Generic;
using System.Linq;
using Linux.MvcCore.Learn.Model.Admin;
using Linux.MvcCore.Learn.Model;
using Linux.MvcCore.Learn.DDL.UserManager;

using Linux.MvcCore.Learn.Common;
using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.BlogManager;
using Linux.MvcCore.Learn.DDL.ViewModel;
using System.Net;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Linux.MvcCore.Learn.Controllers
{
    public class HomeController : FrontBaseController
    {

        private readonly IHomeMainManager manager;

        private readonly IBlogTagManage tagManager;

        private readonly ISpamShieldService service; 
        private readonly IBlogPostManager blogPostmanager;

        private readonly ILogger _logger;

        public HomeController(IHomeMainManager manager, IBlogTagManage tagManager, ISpamShieldService service, IBlogPostManager blogPostmanager, ILoggerFactory loggerFactory) :base(manager, tagManager)
        {
            this.manager = manager;
            this.tagManager = tagManager;
            this.service = service;
            this.blogPostmanager = blogPostmanager;
            this._logger = loggerFactory.CreateLogger("HomeController");
        }

        public ActionResult KinderEditerTest()
        {
            return View();
        }


        public JsonResult UploadPicture()
        {
            string upresult = "";
            var imgFile = this.HttpContext.Request.Form.Files["imgFile"];
             Hashtable extTable = new Hashtable();
		    extTable.Add("image", "gif,jpg,jpeg,png,bmp");
		    extTable.Add("flash", "swf,flv");
		    extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
		    extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");
         //   JsonResult result = new JsonResult();
          //  result.Data = new {  };
            //hash["error"] = 0;
            //hash["url"] = fileUrl;
            return Json(new { error = 0, url = this.Request.PathBase+@"/Content/images/ymz.jpg" } );
        }

        public ActionResult Details(string id = "")
        {
            
            BlogPostDetailsViewModel model = blogPostmanager.GetBlogDetails(new BlogPostDetailsBindingModel() { Permalink = id });
            ViewBag.Title = model.BlogPost.Title;

            ViewBag.Tick = service.CreateTick(id);
            return View(model);
        }

        public ActionResult Spamhash(string id)
        { 
            string result =  service.GenerateHash(id);
            return Content(result);
        }
     
        public ActionResult Index(int page = 1)
        {
            ///Add The Configuration  Builder code
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
            var  configuration = builder.Build();
            var conntionString = configuration["dataConnection:SqliteConnectionString"];
           
            var optionsBuilder = new DbContextOptionsBuilder<LearnContext>();
            optionsBuilder.UseSqlite(conntionString);
            LearnContext dbContent = new LearnContext(optionsBuilder.Options);
            var list = dbContent.SysUsers.ToList();
            _logger.LogDebug("中文log测试" + list.Count);
            ////取dll所在文件文件夹的位置
            _logger.LogDebug("中文log测试" + AppContext.BaseDirectory);
            ////取当前运行程序文件位置
            _logger.LogDebug("中文log测试"+ Directory.GetCurrentDirectory());
            RecentBlogPostsViewModel model = manager.GetRecentBlogPosts(new RecentBlogPostsBindingModel() { Page = page,Take=10 });
            if (model.Posts.Count() == 0)
            {
                if (page > 1)
                    return Content("程序出现错误!", "text/html; charset=utf-8");
                else
                    return Content("MZBlog尚未发现任何已经发布的文章哦!", "text/html; charset=utf-8");
            }
            if (page == 1)
                ViewBag.Title = "首页";
            else
                ViewBag.Title = "文章列表"; 
            return View(model);

        }

        public ActionResult Tag(string id)
        {
             
            var result = tagManager.GetPostByTag(new TaggedBlogPostsBindingModel() { Tag = id });
            return View(result);
        }
    }
}
