namespace E01.Logger
{
    internal interface ILayout
    {
        string Generate(string dateTime, ReportLevel reportLevel, string message);
    }
}