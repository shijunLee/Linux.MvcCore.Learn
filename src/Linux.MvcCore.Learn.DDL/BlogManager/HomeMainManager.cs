using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.ViewModel;
using Linux.MvcCore.Learn.Model;
using Linux.MvcCore.Learn.Model.Blog;
using Linux.MvcCore.Learn.Common.Extensions;
using System.Globalization;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public class HomeMainManager
    {
        public RecentBlogPostsViewModel GetRecentBlogPosts(RecentBlogPostsBindingModel input)
        {
            using (LearnContext context = new LearnContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LearnContext>()))
            {
                var skip = (input.Page - 1) * input.Take;
                var take = input.Take + 1;
                List<BlogPost> postList = context.BlogPosts.Where(p => p.Status == (int)PublishStatus.Published)
                    .OrderByDescending(p => p.PubDate).Skip(skip).Take(take).ToList();
                var pagedPosts = postList.Take(input.Take).ToList();
                var hasNextPage = postList.Count > input.Take;
                return new RecentBlogPostsViewModel
                {
                    Posts = pagedPosts,
                    Page = input.Page,
                    HasNextPage = hasNextPage
                };
            }
        }

        public RecentBlogPostSummaryViewModel GetRecentBlogPostSummaryView(RecentBlogPostSummaryBindingModel input)
        {
            using (LearnContext context = new LearnContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LearnContext>()))
            {
                var titles = context.BlogPosts.Where(p => p.Status == (int)PublishStatus.Published).OrderByDescending(p => p.PubDate)
                    .Select(p => new { PostId=p.Id, Title = p.Title, PubDate = p.PubDate, TitleSlug = p.TitleSlug }).Take(input.Page).ToList();
                //p => new BlogPostSummary { Title = p.Title, Link = "/{0}/{1}".FormatWith(p.PubDate.ToString("yyyy/MM", CultureInfo.InvariantCulture), p.TitleSlug) }
                List<BlogPostSummary> lists = new List<BlogPostSummary>();
                foreach (var item in titles)
                {
                    BlogPostSummary sum = new BlogPostSummary() { Title = item.Title, Link = "/Home/Details/{0}".FormatWith(item.PostId) };
                    lists.Add(sum);
                }
                return new RecentBlogPostSummaryViewModel { BlogPostsSummaries = lists };
            }
        }
    }
}
