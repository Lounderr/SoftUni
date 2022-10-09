﻿using System.Collections.Generic;

namespace E01.Logger
{
    internal class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>();
            foreach (var appender in appenders)
            {
                Appenders.Add(appender);
            }
        }

        public List<IAppender> Appenders { get; }

        public void Info(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.INFO, message);
            }
        }

        public void Warning(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.WARNING, message);
            }
        }

        public void Error(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.ERROR, message);
            }
        }

        public void Critical(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.CRITICAL, message);
            }
        }

        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, ReportLevel.FATAL, message);
            }
        }
    }
}