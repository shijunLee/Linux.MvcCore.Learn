
using System;
using System.Collections.Generic;
using System.Linq;
using Linux.MvcCore.Learn.Model.Blog;
using Microsoft.AspNetCore.Mvc;
using Linux.MvcCore.Learn.DDL.BlogManager;
using Linux.MvcCore.Learn.DDL.CommandModel;
using Linux.MvcCore.Learn.DDL.ViewModel;
using Linux.MvcCore.Learn.DDL.BindingModel;

namespace Linux.MvcCore.Learn.Controllers
{
    public class BlogCommentController : Controller
    {
        //
        // GET: /BlogComment/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetList(int page =1)
        {
            BlogCommentManage manager = new BlogCommentManage();
            AllBlogCommentsViewModel model = new AllBlogCommentsViewModel();
            model = manager.GetAll(new AllBlogCommentsBindingModel()
                    {
                        Page = page
                    });
            return View(model);
        }

        public ActionResult Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                BlogCommentManage manager = new BlogCommentManage();
                manager.DeleteBlogComment(id);
            }

            return RedirectToAction("GetList", "BlogComment");
        }

        public ActionResult AddComment(NewCommentCommand command,SpamShield spam)
        {
            command.SpamShield = spam;
            command.IPAddress = Request.Host.Host;
           
            BlogCommentManage manager = new BlogCommentManage();
            manager.SaveNewBlogComment(command);
            return RedirectToAction("Details", "Home", new { id = command.PostId });
        }
    }
}
