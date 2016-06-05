using System;
using System.Collections.Generic;

namespace Linux.MvcCore.Learn.Model.Admin
{
    public partial class SysUser
    {
        public SysUser()
        {
            this.userdetials = new List<UserDetial>();
            //this.roles = new List<Role>();
        }

        public string UserID { get; set; }
        public string UserLoginName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserDetial> userdetials { get; set; }
        //public virtual ICollection<Role> roles { get; set; }
    }
}
