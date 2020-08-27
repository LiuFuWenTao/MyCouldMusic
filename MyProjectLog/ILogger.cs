using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLog
{
    /// <summary>
    /// 日志对外接口
    /// </summary>
    public interface ILogger
    {
        void Debug(string message);

        void Debug(string message, Exception exception);

        void DebugFormat(string format, params object[] args);

        void Info(string message);

        void Info(string message, Exception exception);

        void InfoFormat(string format, params object[] args);

        void Warn(string message);

        void Warn(string message, Exception exception);

        void WarnFormat(string format, params object[] args);

        void Error(string message);

        void Error(string message, Exception exception);

        void ErrorFormat(string format, params object[] args);

        void Fatal(string message);

        void Fatal(string message, Exception exception);

        void FatalFormat(string format, params object[] args);

        bool IsDebugEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsWarnEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }

    }
}
