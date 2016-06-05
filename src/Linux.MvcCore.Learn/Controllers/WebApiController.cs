using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http; 
using Linux.MvcCore.Learn.Model;
using Linux.MvcCore.Learn.Model.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Linux.MvcCore.Learn.Controllers
{
    public class WebApiController : Controller
    {

        private readonly LearnContext dbContext;

        public WebApiController(LearnContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public string Delete(string id)
        {
            List<SysUser> userList = new List<SysUser>();
             
                SysUser user = dbContext.SysUsers.Where(p => p.UserID == id).SingleOrDefault();
                if (user != null)
                {
                    dbContext.SysUsers.Remove(user);
                    dbContext.SaveChanges();
                }
                userList = dbContext.SysUsers.ToList();
            
            return "secuess";
        } 
    }
}
