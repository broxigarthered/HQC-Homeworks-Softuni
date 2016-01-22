using System;
using Logger.Enums;
using Logger.Interfaces;

namespace Logger.Models
{
   public class SimpleLayout : ILayout
    {
       public string Format(DateTime date, ReportLevel reportLevel, string message)
       {
           var formattedMessage = string.Format("{0} - {1} - {2}{3}", date, reportLevel, message, Environment.NewLine);

           return formattedMessage.Substring(0, formattedMessage.Length-1);
       }
    }
}
