using System;
using System.Collections.Generic;
using System.Linq;
using Linux.MvcCore.Learn.DDL.BlogManager;
using Linux.MvcCore.Learn.DDL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Linux.MvcCore.Learn.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IAdminIndex indexManager;

        public BlogController(IAdminIndex indexManager)
        {
            this.indexManager = indexManager;
        }
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            AllStatisticsViewModel model = new AllStatisticsViewModel();
            //AdminIndex indexManager = new AdminIndex();
            model = indexManager.GetBlogStatistics();
         
            return View(model);
        }


        public ActionResult ReturnHomeAction()
        {
            return View();
        }
    }
}
