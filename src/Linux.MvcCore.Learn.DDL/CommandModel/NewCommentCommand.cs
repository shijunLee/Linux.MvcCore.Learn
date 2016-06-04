using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.CommandModel
{
    public class NewCommentCommand
    {
        public NewCommentCommand()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public SpamShield SpamShield { get; set; }

        public string PostId { get; set; }

    
        public string NickName { get; set; }

  
        public string Email { get; set; }

        public string SiteUrl { get; set; }

 
        public string Content { get; set; }

        public string IPAddress { get; set; }
    }
}
