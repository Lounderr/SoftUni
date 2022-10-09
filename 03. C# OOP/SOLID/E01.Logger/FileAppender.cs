using System;
using System.IO;
using System.Text;
namespace E01.Logger
{
    internal class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, LogFile logFile)
        {
            Layout = layout;
            LogFile = logFile;
            ReportLevel = ReportLevel.INFO;
            MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public LogFile LogFile { get; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void Append(string dateTime, string reportLevel, string message)
        {
            if (Enum.Parse<ReportLevel>(reportLevel) >= ReportLevel)
            {
                string layoutResult = Layout.Generate(dateTime, reportLevel.ToUpper(), message);
                LogFile.Write(layoutResult);
                MessagesAppended++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}, File size: {this.LogFile.Size}";
        }
    }
}