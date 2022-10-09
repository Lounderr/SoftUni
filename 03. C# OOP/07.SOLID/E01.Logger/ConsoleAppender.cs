﻿using System;

namespace E01.Logger
{
    internal class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
            ReportLevel = ReportLevel.INFO;
            MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                string layoutResult = Layout.Generate(dateTime, reportLevel, message);
                Console.Write(layoutResult);
                MessagesAppended++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}";
        }
    }
}