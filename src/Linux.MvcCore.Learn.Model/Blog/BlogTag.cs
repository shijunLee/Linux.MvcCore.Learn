using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.Model.Blog
{
    public class BlogTag
    {
        /// <summary>
        /// 标签Id
        /// </summary>
        public string BlogTagId { get; set; }

        /// <summary>
        /// 外键id
        /// </summary>
        public string BlogPostId { get; set; }
       
        /// <summary>
        /// 标签对应的博客
        /// </summary>
        public BlogPost BlogPost { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }

        
        /// <summary>
        /// 标签别名
        /// </summary> 
        public string Slug { get; set; }
    }
}
