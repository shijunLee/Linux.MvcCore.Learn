using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.BlogManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linux.MvcCore.Learn.Controllers
{
    public class FrontBaseController:Controller
    {
        public FrontBaseController()
            : base()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HomeMainManager manager = new HomeMainManager();
            ViewBag.Recent = manager.GetRecentBlogPostSummaryView( new RecentBlogPostSummaryBindingModel { Page = 10 });
            BlogTagManage tagManager = new BlogTagManage();

            ViewBag.TagCould = tagManager.GetAll(new TagCloudBindingModel() { Threshold = 2 });
        }
    }
}