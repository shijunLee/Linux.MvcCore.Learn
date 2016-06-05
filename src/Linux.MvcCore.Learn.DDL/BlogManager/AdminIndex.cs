using Linux.MvcCore.Learn.DDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MvcCore.Learn.Model;
using Microsoft.Extensions.Logging;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public class AdminIndex:IAdminIndex
    {

        private readonly LearnContext context;

        private readonly ILogger _logger;

        public AdminIndex(LearnContext context, ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger("IDataEventRecordResporitory");
            this.context = context;
        }

        public AllStatisticsViewModel GetBlogStatistics()
        {
            AllStatisticsViewModel model = new AllStatisticsViewModel();

            long postsCount = context.BlogPosts.Count();
            //long commentsCount=context.t
            int tagsCount = context.BlogTags.Count();
            model.PostsCount = postsCount;
            model.TagsCount = tagsCount;
            model.CommentsCount = 0;


            return model;
        }
    }
}
