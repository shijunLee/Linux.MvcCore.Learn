using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.UserManager
{
   public interface IUserManager
    {
        bool UserLogin(string userCode, string passWord);

        bool ChangePassword(string userCode, string oldPassword, string newPassword);
    }
}
