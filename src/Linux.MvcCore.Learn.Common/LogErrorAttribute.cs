using Microsoft.AspNetCore.Mvc.Filters;

namespace Linux.MvcCore.Learn.Common
{
    /// <summary>
    /// 异常日志
    /// </summary>
    public class LogErrorAttribute : ExceptionFilterAttribute
    {
        //public 
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LogHelper.WriteLog(filterContext.GetType(), filterContext.Exception);

        }
    }
}
