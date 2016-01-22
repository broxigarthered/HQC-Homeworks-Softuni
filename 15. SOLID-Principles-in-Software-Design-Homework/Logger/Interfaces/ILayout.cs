
using System;
using Logger.Enums;

namespace Logger.Interfaces
{
    public interface ILayout
    {
        string Format(DateTime date, ReportLevel reportLevel, string message);
    }
}
