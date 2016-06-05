using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.BlogManager;
using Linux.MvcCore.Learn.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Linux.MvcCore.Learn.DDL.CommandModel;
using Linux.MvcCore.Learn.Model.Blog;
using Linux.MvcCore.Learn.Model.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Linux.MvcCore.Learn.Controllers
{
    public class BlogPostController : BaseController
    {

        private readonly IBlogPostManager manager;

        public BlogPostController(IBlogPostManager manager)
        {
            this.manager = manager;

        }
        //
        // GET: /BlogPost/

        public ActionResult Comments()
        {
            return View();
        }


        public ActionResult GetList(int page = 1)
        {
            //BlogPostManager manager = new BlogPostManager();
            var model = manager.GetBlogPostList(new AllBlogPostsBindingModel()
            {
                Page = page,
                Take = 30
            });
            //return View["Posts", model];

            return View(model);

        }

        public ActionResult Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                //BlogPostManager manager = new BlogPostManager();
                manager.DeleteBlogPost(id);
            }
            return RedirectToAction("GetList", "BlogPost",1);
        }

        //[HttpPost]
        //public ActionResult Comments()
        //{
        //    return View();
        //}


        // GET: /BlogPost/
        public ActionResult Edit(string id)
        {
            BlogPostEditBindingModel post = new BlogPostEditBindingModel();
            if (!String.IsNullOrEmpty(id))
            {
               // BlogPostManager manager = new BlogPostManager();
                BlogPost blogPost = new BlogPost();
                blogPost = manager.GetById(id);
                //string tags = "";
                //if (blogPost.Tags != null && blogPost.Tags.Count > 0)
                //{
                //    tags = String.Join(",", blogPost.Tags.Select(p => p.Tag).ToArray());
                //    //tags.TrimEnd(',');
                //}
                post = new BlogPostEditBindingModel { BlogPost = blogPost };
            }
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(EditPostCommand postCommand)
        {
            //BlogPostManager manager = new BlogPostManager();
            BlogPost post = manager.SaveEditBlogPost(postCommand);

            BlogPostEditBindingModel editPost = new BlogPostEditBindingModel();
            if (post != null)
                editPost = new BlogPostEditBindingModel { BlogPost = post };
            return View(editPost);
        }

        
        
        public ActionResult NewPost()
        {
            NewPostCommand post = new NewPostCommand();
            return View(post);
        }

        //[ValidateInput(false)]
        [HttpPost]
        public ActionResult NewPost(NewPostCommand command)
        {


            command.Author = this.author;
            //BlogPostManager manager = new BlogPostManager();
            manager.SaveBlogPost(command);
            return View(command);
        }


        public ActionResult Posts()
        {
            return View();
        }

        public ActionResult Tags()
        {
            return View();
        }


        public string Slug(string title)
        {
            return title.ToSlug();
        }
    }
}
