using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.CommandModel;
using Linux.MvcCore.Learn.DDL.ViewModel;
using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public interface IBlogPostManager
    {

        AllBlogPostsViewModel GetBlogPostList(AllBlogPostsBindingModel input);

        BlogPost GetById(string id);

        bool DeleteBlogPost(string id);

        BlogPostDetailsViewModel GetBlogDetails(BlogPostDetailsBindingModel input);

        BlogPost SaveEditBlogPost(EditPostCommand command);

        bool SaveBlogPost(NewPostCommand command);
    }
}
