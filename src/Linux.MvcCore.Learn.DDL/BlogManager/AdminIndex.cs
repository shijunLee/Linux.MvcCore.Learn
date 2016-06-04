using Linux.MvcCore.Learn.DDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MvcCore.Learn.Model;


namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public class AdminIndex
    {
        public AllStatisticsViewModel GetBlogStatistics()
        {
            AllStatisticsViewModel model = new AllStatisticsViewModel();
            using (LearnContext context = new LearnContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LearnContext>()))
            { 
                long postsCount =context.BlogPosts.Count();
                //long commentsCount=context.t
                int tagsCount = context.BlogTags.Count();
                model.PostsCount = postsCount;
                model.TagsCount = tagsCount;
                model.CommentsCount = 0;
            }

            return model;
        }
    }
}
