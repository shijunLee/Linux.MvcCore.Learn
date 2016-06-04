using Linux.MvcCore.Learn.Model.Admin;
using Linux.MvcCore.Learn.Model.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Linux.MvcCore.Learn.Controllers
{
    /// <summary>
    /// 控制Controller 基类进行方法添加集成 使用公用的权限方法判断
    /// </summary>
    public class BaseController : Controller
    {
        public Author author;
        public BaseController()
            : base()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                Role role = new Role();
                List<Role> roles = new List<Role>();
                roles.Add(role);
                this.author = new Author { DisplayName = "李士军", Email = "lishjun01@126.com", Id = "test", Roles = roles, HashedPassword = "test" };
                ( filterContext.Controller as Controller).ViewBag.Author = author;
            }
            else { 
                Response.Redirect(new PathString("/Admin/Index"));

            }
        }

    }
}