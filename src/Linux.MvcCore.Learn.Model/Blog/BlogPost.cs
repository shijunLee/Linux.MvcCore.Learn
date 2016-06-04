using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Linux.MvcCore.Learn.Common.Extensions;
using System.Globalization;

namespace Linux.MvcCore.Learn.Model.Blog
{
    public class BlogPost
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// blog标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 固定连接key
        /// </summary>
        public string TitleSlug { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        
        public string Description
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Content))
                    return string.Empty;
                var des = Regex.Replace(Content, "<[^>]+>", string.Empty).Trim();
                var length = des.Length < 240 ? des.Length : 240;
                des = des.Substring(0, length) + " ...";
                return des;
            }
        }

        /// <summary>
        /// 显示序号
        /// </summary>
        public int ViewCount { get; set; }
        /// <summary>
        /// 无标签内容
        /// </summary>
        public string MarkDown { get; set; }

        /// <summary>
        /// html文本内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        public PublishStatus Status { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime PubDate { get; set; }
       
        
        /// <summary>
        /// UTC时间
        /// </summary>
        public DateTime DateUTC { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public List<BlogTag> Tags { get; set; }


        public List<BlogComment> Comments { get; set; }

        /// <summary>
        /// 编辑人显示姓名
        /// </summary>
        public string AuthorDisplayName { get; set; }

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string AuthorEmail { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublished
        {
            get { return PubDate <= DateTime.UtcNow && Status == PublishStatus.Published; }
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        public string GetLink()
        {
            return "/Home/Details/{0}".FormatWith(Id);
        }
    }

    public static class BlogPostExtensions
    {
        public static BlogPost ToPublishedBlogPost(this BlogPost blogPost)
        {
            blogPost.PubDate = DateTime.UtcNow.AddDays(-1);
            blogPost.Status = PublishStatus.Published;
            return blogPost;
        }
    }
}
