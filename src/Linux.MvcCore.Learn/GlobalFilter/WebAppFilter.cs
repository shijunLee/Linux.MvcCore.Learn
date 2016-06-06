
using Linux.MvcCore.Learn.DDL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linux.MVC.Learn.GlobalFilter
{
    public class WebAppFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            List<ViewMessage> message = new List<ViewMessage>();
            (filterContext.Controller as Controller).ViewBag.Messages = message; 
            base.OnActionExecuted(filterContext);
            if (filterContext.HttpContext.User.Identity == null)
            {
                RedirectResult result = new RedirectResult("~/Home/Index");
                result.ExecuteResult((filterContext.Controller as Controller).ControllerContext);
            }
           
        }
    }
}