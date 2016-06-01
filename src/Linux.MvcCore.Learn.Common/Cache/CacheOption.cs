using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.Common.Cache
{
    public class CacheOption : IOptions<MemoryCacheOptions>
    {
        public MemoryCacheOptions Value
        {
            get
            {
                MemoryCacheOptions options = new MemoryCacheOptions();
               
                return options;
            }
        }
    }
}
