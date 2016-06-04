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
        [HttpGet]
        public string Delete(string id)
        {
            List<SysUser> userList = new List<SysUser>();
            using (LearnContext dbContext = new LearnContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LearnContext>()))
            {
                SysUser user = dbContext.SysUsers.Where(p => p.UserID == id).SingleOrDefault();
                if (user != null)
                {
                    dbContext.SysUsers.Remove(user);
                    dbContext.SaveChanges();
                }
                userList = dbContext.SysUsers.ToList();
            }
            return "secuess";
        } 
    }
}
