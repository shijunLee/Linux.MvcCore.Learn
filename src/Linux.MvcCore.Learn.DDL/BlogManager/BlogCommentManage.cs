using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MvcCore.Learn.Common;
using Linux.MvcCore.Learn.Common.Extensions;
using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.CommandModel;
using Linux.MvcCore.Learn.DDL.ViewModel;
using Linux.MvcCore.Learn.Model;
using Linux.MvcCore.Learn.Model.Blog;
using Microsoft.Extensions.Logging;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public class BlogCommentManage: IBlogCommentManage
    {
        private readonly LearnContext context;

        private readonly ILogger _logger;

        private readonly ISpamShieldService service;

        public BlogCommentManage(LearnContext context, ILoggerFactory loggerFactory, ISpamShieldService service)
        {
            this._logger = loggerFactory.CreateLogger("IDataEventRecordResporitory");
            this.context = context;
            this.service = service;
        }

        public AllBlogCommentsViewModel GetAll(AllBlogCommentsBindingModel input)
        { 
            List<BlogComment> commentList = new List<BlogComment>();
            using (LearnContext context = new LearnContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LearnContext>()))
            {
                var skip = (input.Page - 1) * input.Take;
                commentList = context.BlogComments.OrderByDescending(p => p.CreatedTime)
                    .Skip(skip).Take(input.Take + 1).ToList();
                var pagedComments = commentList.Take(input.Take);
                var hasNextPage = commentList.Count > input.Take;
                return new AllBlogCommentsViewModel
                {
                    Comments = pagedComments,
                    Page = input.Page,
                    HasNextPage = hasNextPage
                };
            } 
        }

        public bool DeleteBlogComment(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                
                    BlogComment comment = context.BlogComments.Where(p => p.Id == id).SingleOrDefault();
                    if (comment != null)
                    {
                        context.BlogComments.Remove(comment);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
               
            }
            return false;
        }

        public bool SaveNewBlogComment(NewCommentCommand command)
        {
              

            if(service.IsSpam(command.SpamShield))
            {
                return false;
            }
            if (command != null)
            {
                
                    var comment = new BlogComment
                    {
                        Id = command.Id,
                        Email = command.Email,
                        NickName = command.NickName,
                        Content = command.Content,
                        IPAddress = command.IPAddress,
                        PostId = command.PostId,
                        SiteUrl = command.SiteUrl,
                        CreatedTime = DateTime.UtcNow
                    };
                    context.BlogComments.Add(comment);
                    context.SaveChanges();
                    return true;
                 
            
            }
            return false;
        }
    }
}
