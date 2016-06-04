using Linux.MvcCore.Learn.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.Model.Blog
{
    public class Author
    {
        public Author()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string HashedPassword { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public List<Role> Roles { get; set; }
    }
}
