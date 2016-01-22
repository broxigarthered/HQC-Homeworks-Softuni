using System;
using Logger.Interfaces;

namespace Logger.Models
{
    public class FileAppender : Appender
    {
        private string file;

        public FileAppender(ILayout layout) 
            : base(layout)
        {
        }

        public string File
        {
            get { return this.file; }
            set { this.file = value; }
        }
        public override void WriteFormatedMessage(string message)
        {
            System.IO.File.AppendAllText(this.File, message);
        }
    }
}
