using System;
using Logger.Enums;

namespace Logger.Interfaces
{
    public interface IAppender
    {
       ILayout Layout { get; set; }

        ReportLevel ReportLevel { get; set; }

        void Append(DateTime date, ReportLevel reportLevel, string message);
    }
}
