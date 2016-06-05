using System;
using System.Collections.Generic;
using System.Linq;
using Linux.MvcCore.Learn.DDL.BlogManager;
using Linux.MvcCore.Learn.DDL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Linux.MvcCore.Learn.Controllers
{
    public class BlogTagController : Controller
    {
        private readonly  IBlogTagManage manager;
        public BlogTagController(IBlogTagManage manager)
        {
            this.manager = manager;
        }
        //
        // GET: /BlogTag/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page=0)
        {
            TagCloudViewModel model = new TagCloudViewModel();
            //BlogTagManage manager = new BlogTagManage();
            model = manager.GetAll(null);
            return View(model);
        }

    }
}
