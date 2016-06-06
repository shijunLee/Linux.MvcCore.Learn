using Linux.MvcCore.Learn.Common;
using Linux.MvcCore.Learn.Model.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Linux.MvcCore.Learn.DDL.UserManager;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.Controllers
{
    public class AdminController : Controller
    {

        private readonly IUserManager manager;


        public AdminController(IUserManager manager)
        {
            this.manager = manager;
        }
        // GET: / Home/Index
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
        {

            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }


        //
        // POST: /Login/Index
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(SysUser user, string ReturnUrl)
        {

            //DDL.UserManager.UserManager manager = new DDL.UserManager.UserManager();
            LogHelper.WriteLog(typeof(String), "this is a test" + user.UserLoginName);
            bool result = manager.UserLogin(user.UserLoginName, user.Password);

            if (result)
            {
              
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserLoginName),
                    
                }; 
                var id = new ClaimsIdentity(claims, "CustomApiKeyAuth");
                
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(); 
                claimsPrincipal.AddIdentity(id);
                await HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance", claimsPrincipal);

                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }

            }
            else
            {
                ViewBag.ErrorMessage = "用户名和密码错误请重新登陆！";
                return RedirectToAction("Index", "Admin");
            }

        }

    }
}
