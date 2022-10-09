namespace E01.Logger
{
    internal interface IAppender
    {
        void Append(string dateTime, string reportLevel, string message);

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; }

        public string ToString();
    }
}