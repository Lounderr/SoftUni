namespace E01.Logger
{
    internal interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int MessagesAppended { get; }

        string ToString();
    }
}