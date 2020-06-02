using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Helper
{
    public class Logger
    {
        readonly static Invengo.Library.ILog.ILogger logger = Invengo.Library.ILog.LoggerBuilder.Build();
        /// <summary>
        /// 记录一般信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="color"></param>
        /// <param name="filePath"></param>
        public static void Log(string info)
        {
            logger.Info(info);
        }
        /// <summary>
        /// 记录Debug日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            logger.Debug(message);
        }
        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="e"></param>
        public static void LogError(Exception e)
        {
            logger.Error("", e);
        }

        public static void LogOpt(string moduleName, string message, bool isError)
        {
            logger.Info(message);
        }
    }
}
