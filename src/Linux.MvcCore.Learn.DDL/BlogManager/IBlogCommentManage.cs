using Linux.MvcCore.Learn.DDL.BindingModel;
using Linux.MvcCore.Learn.DDL.CommandModel;
using Linux.MvcCore.Learn.DDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public  interface IBlogCommentManage
    {
        AllBlogCommentsViewModel GetAll(AllBlogCommentsBindingModel input);

        bool DeleteBlogComment(string id);

        bool SaveNewBlogComment(NewCommentCommand command);
    }
}
