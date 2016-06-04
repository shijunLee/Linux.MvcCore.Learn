using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.ViewModel
{
    public class TaggedBlogPostsViewModel
    {
        public IEnumerable<BlogPost> Posts { get; set; }

        public string Tag { get; set; }
    }
}
