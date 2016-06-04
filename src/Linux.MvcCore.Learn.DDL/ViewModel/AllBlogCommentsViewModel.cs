using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.ViewModel
{
    public class AllBlogCommentsViewModel
    {
        public IEnumerable<BlogComment> Comments { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPrevPage
        {
            get
            {
                return Page > 1;
            }
        }

        public int Page { get; set; }
    }
}
