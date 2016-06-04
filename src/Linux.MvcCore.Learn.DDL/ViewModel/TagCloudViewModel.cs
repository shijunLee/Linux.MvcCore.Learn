using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.ViewModel
{
    public class TagCloudViewModel
    {
        public IEnumerable<BlogTagViewModel> Tags { get; set; }
    }
}
