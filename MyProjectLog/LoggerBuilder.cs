using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Invengo.Library.IConfiguration;

namespace MyProjectLog
{
    /// <summary>
    /// 日志构造器
    /// </summary>
    public static class LoggerBuilder
    {
        private static ILogger _logger = null;

        private static object lockObject = new object();

        /// <summary>
        /// 构造器
        /// </summary>
        /// <returns></returns>
        public static ILogger Build()
        {
            if (_logger == null)
            {
                lock (lockObject)
                {
                    if (_logger == null)
                    {
                        try
                        {
                            //加载配置类
                            var config = ConfigurationFactory.BuildConfiguration<LoggerConfig>();
                            if (!string.IsNullOrEmpty(config.LogAssembly) || !string.IsNullOrEmpty(config.LogType))
                            {
                                if (string.IsNullOrEmpty(config.LogAssembly))
                                {
                                    //从当前执行环境创建
                                    var currentLogger = Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, config.LogType) as ILogger;
                                    if (currentLogger != null)
                                    {
                                        _logger = currentLogger;
                                    }
                                }
                                else
                                {
                                    //从用户指定的配置创建日志
                                    var customerLogger = Activator.CreateInstance(config.LogAssembly, config.LogType).Unwrap() as ILogger;
                                    if (customerLogger != null)
                                    {
                                        _logger = customerLogger;
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }

                        if (_logger == null)
                        {
                            _logger = new NullLogger();
                        }
                    }
                }
            }
            return _logger;
        }
    }
}
