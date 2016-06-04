using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.ViewModel
{
    public class BlogTagViewModel
    {
        public BlogTagViewModel(BlogTag tag,int count)
        {
            Slug = tag.Slug;
            Name = tag.Tag;
        }
        public BlogTagViewModel(string name, string slug, int count)
        {
            this.Name = name;
            this.PostCount = count;
            this.Slug = slug;
        }

        public BlogTagViewModel()
        {
            // TODO: Complete member initialization
        }

        public string Slug { get; set; }

        public string Name { get; set; }

        public int PostCount { get; set; }
    }
}
