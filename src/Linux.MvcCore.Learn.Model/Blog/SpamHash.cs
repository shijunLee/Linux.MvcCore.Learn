using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.Model.Blog
{
    public class SpamHash
    {
        public string SpamHashId { get; set; }

        public string PostKey { get; set; }

        public string Hash { get; set; }

        public bool Pass { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
