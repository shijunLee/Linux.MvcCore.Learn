using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.BindingModel
{
    /// <summary>
    /// 数据绑定使用类
    /// </summary>
    public class AllBlogPostsBindingModel
    {
        public AllBlogPostsBindingModel()
        {
            Page = 1;
            Take = 10;
        }

        public int Page { get; set; }

        public int Take { get; set; }
    }
}
