using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public interface IHomeMainManager
    {
        RecentBlogPostsViewModel GetRecentBlogPosts(RecentBlogPostsBindingModel input);

        RecentBlogPostSummaryViewModel GetRecentBlogPostSummaryView(RecentBlogPostSummaryBindingModel input);
    }
}
