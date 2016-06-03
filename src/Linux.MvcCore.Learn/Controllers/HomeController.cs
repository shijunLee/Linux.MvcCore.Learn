using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Linux.MVC.Learn.Common;

namespace Linux.MvcCore.Learn.Controllers
{
    [LogErrorAttribute]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("日志测试功能");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            //AppDomain.CurrentDomain.GetAssemblies();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
