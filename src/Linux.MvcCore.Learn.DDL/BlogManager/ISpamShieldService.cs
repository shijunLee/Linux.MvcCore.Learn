using Linux.MvcCore.Learn.DDL.BlogManager;
using Linux.MvcCore.Learn.Model;
using Linux.MvcCore.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MvcCore.Learn.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Linux.MvcCore.Learn.Common
{


    public interface ISpamShieldService
    {
        string CreateTick(string key);

        string GenerateHash(string tick);

        bool IsSpam(SpamShield command);
    }

  
}
