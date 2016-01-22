using System;
using Logger.Interfaces;

namespace Logger.Models
{
    public class ConsoleAppender: Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void WriteFormatedMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
