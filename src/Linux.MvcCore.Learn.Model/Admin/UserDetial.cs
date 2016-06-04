using System;
using System.Collections.Generic;

namespace Linux.MvcCore.Learn.Model.Admin
{
    public partial class UserDetial
    {
        public string UserDetialId { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<int> Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual SysUser sysuser { get; set; }
    }
}
