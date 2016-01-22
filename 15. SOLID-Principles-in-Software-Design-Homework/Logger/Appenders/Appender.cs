using System;
using Logger.Enums;
using Logger.Interfaces;

namespace Logger.Models
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;

        }

        public ILayout Layout { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(DateTime date, ReportLevel reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            var formattedMessage = this.Layout.Format(date, reportLevel, message);
            this.WriteFormatedMessage(formattedMessage);
        }

        public abstract void WriteFormatedMessage(string message);
    }
}
