using System; 

//WINDOWS 下与linux下有所区别在文件路径部分
//[assembly: log4net.Config.XmlConfigurator(Environment. = @"bin/Log4Net.config", Watch = true)]
namespace Linux.MvcCore.Learn.Common
{
    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("linux.mvcCore.Learn",t);
          

            log.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("linux.mvcCore.Learn", t);
            log.Error(msg);
        }

        #endregion

    }
}
