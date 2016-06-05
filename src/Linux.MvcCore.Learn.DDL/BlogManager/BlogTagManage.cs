using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.ViewModel;
using Linux.MvcCore.Learn.Model;
using Linux.MvcCore.Learn.Model.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public class BlogTagManage:IBlogTagManage
    {

        private readonly LearnContext context;

        private readonly ILogger _logger;

        public BlogTagManage(LearnContext context, ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger("IDataEventRecordResporitory");
            this.context = context;
        }

        public TagCloudViewModel GetAll(TagCloudBindingModel input)
        {
             
               List<BlogTagViewModel> list =
                context.BlogTags.GroupBy(p => new { p.Tag, p.Slug }).
                Select(group => new BlogTagViewModel(){ Name=group.Key.Tag, Slug=group.Key.Slug, PostCount=group.Count() })
                .ToList();
               if (list != null && list.Count > 0)
               {
                   return new TagCloudViewModel()
                   {
                       Tags = list
                   };
               }
             
            return null;
        }

        public TaggedBlogPostsViewModel GetPostByTag(TaggedBlogPostsBindingModel input)
        {
             
                var blogs = context.BlogPosts.Include(p=>p.Tags)
                    .Where(p => p.Tags.Any(t => t.Tag == input.Tag))
                    .Where(p => p.Status == (int)PublishStatus.Published)
                    .OrderByDescending(p=>p.PubDate).ToList();
                if (blogs.Count == 0)
                    return null;
                return new TaggedBlogPostsViewModel
                {
                    Posts = blogs,
                    Tag = input.Tag
                }; 
            
        }
    }
}
