using System;
using System.Collections.Generic;
using Logger.Enums;
using Logger.Interfaces;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        public Logger(ConsoleAppender consoleAppender, FileAppender fileAppender)
        {
            this.ConsoleAppender = consoleAppender;
            this.FileAppender = fileAppender;
        }


        public IAppender FileAppender { get; }
        public IAppender ConsoleAppender { get; }

        public void Info(string message)
        {
            this.Log(message, ReportLevel.Info);
        }

        public void Warn(string message)
        {
            this.Log(message, ReportLevel.Warning);
        }

        public void Error(string message)
        {
            this.Log(message, ReportLevel.Error);
        }

        public void Fatal(string message)
        {
            this.Log(message, ReportLevel.Fatal);
        }

        public void Critical(string message)
        {
            this.Log(message, ReportLevel.Critical);
        }

        public void Log(string message, ReportLevel reportLevel)
        {
            DateTime date = DateTime.Now;

            this.FileAppender.Append(date, reportLevel, message);
            this.ConsoleAppender.Append(date, reportLevel, message);
        }
    }
}

