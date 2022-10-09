using System.Collections.Generic;

namespace E01.Logger
{
    internal interface ILogger
    {
        List<IAppender> Appenders { get; }

        void Info(string dateTime, string message);

        void Error(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Fatal(string dateTime, string message);

    }
}