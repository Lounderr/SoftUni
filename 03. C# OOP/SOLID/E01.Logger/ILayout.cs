namespace E01.Logger
{
    internal interface ILayout
    {
        string Generate(string dateTime, string reportLevel, string message);
    }
}