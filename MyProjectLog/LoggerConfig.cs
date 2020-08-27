using Invengo.Library.IConfiguration;
using Microsoft.Extensions.Configuration.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLog
{
    /// <summary>
    /// 日志配置
    /// </summary>
    [ConfigurationSourceBuilder(ConfigTarget = typeof(LoggerConfig),
                                    ConfigurationSourceType = typeof(XmlConfigurationSource))]
    [ConfigurationPath(Path = "Configs/logConfig.xml")]
    public sealed class LoggerConfig
    {
        /// <summary>
        /// 日志类所在程序集
        /// </summary>
        public string LogAssembly { get; set; }

        /// <summary>
        /// 日志类名称
        /// </summary>
        public string LogType { get; set; }
    }
}

