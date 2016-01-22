using System.Collections;
using System.Collections.Generic;
using Logger.Enums;

namespace Logger.Interfaces
{
    public interface ILogger
    {
        IAppender FileAppender { get; }

        IAppender ConsoleAppender { get; }

        void Info(string message);

        void Warn(string message);

        void Error(string message);

        void Fatal(string message);

        void Critical(string message);

        void Log(string message, ReportLevel reportlevel);
    }
}
