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

namespace Linux.MvcCore.Learn.Controllers
{
    public class HomeController : FrontBaseController
    {

        private readonly IHomeMainManager manager;

        private readonly IBlogTagManage tagManager;

        private readonly ISpamShieldService service; 
        private readonly IBlogPostManager blogPostmanager; 

        public HomeController(IHomeMainManager manager, IBlogTagManage tagManager, ISpamShieldService service, IBlogPostManager blogPostmanager) :base(manager, tagManager)
        {
            this.manager = manager;
            this.tagManager = tagManager;
            this.service = service;
            this.blogPostmanager = blogPostmanager;
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
