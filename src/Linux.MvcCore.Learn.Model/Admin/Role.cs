using System;
using System.Collections.Generic;

namespace Linux.MvcCore.Learn.Model.Admin
{
    public partial class Role
    {
        public Role()
        {
            //this.SysMenus = new List<SysMenu>();
            //this.SysUsers = new List<SysUser>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public string RoleRemark { get; set; }
        //public virtual ICollection<SysMenu> SysMenus { get; set; }
        //public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
