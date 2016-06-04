using System;
using System.Collections.Generic;

namespace Linux.MvcCore.Learn.Model.Admin
{
    public partial class SysMenu
    {
        public SysMenu()
        {
            this.Roles = new List<Role>();
        }

        public string SysMenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string MenuRemark { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
