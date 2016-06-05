using Linux.MvcCore.Learn.DDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.BlogManager
{
    public  interface IAdminIndex
    {
        AllStatisticsViewModel GetBlogStatistics();
    }
}
