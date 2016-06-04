using Linux.MvcCore.Learn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.UserManager
{
    public class UserManager
    { /// <summary>
      /// 用户登陆
      /// </summary>
      /// <param name="userCode"></param>
      /// <param name="passWord"></param>
      /// <returns></returns>
        public bool UserLogin(string userCode, string passWord)
        {
            using (var dbContext = new LearnContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LearnContext>()))
            {
                var result = dbContext.SysUsers.Where(p => p.UserLoginName == userCode && p.Password == passWord).ToList();
                if (result.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ChangePassword(string userCode, string oldPassword, string newPassword)
        {
            using (var dbContext = new LearnContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LearnContext>()))
            {
                var result = dbContext.SysUsers.Where(p => p.UserLoginName == userCode && p.Password == oldPassword).ToList();
                if (result.Count == 1)
                {
                    ;
                    if (result[0] != null)
                    {
                        result[0].Password = newPassword;
                        dbContext.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    throw new Exception("用户查询登陆信息出现异常");
                }
            }
        }
    }
}
