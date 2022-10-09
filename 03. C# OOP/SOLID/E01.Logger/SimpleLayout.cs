namespace E01.Logger
{
    internal class SimpleLayout : ILayout
    {
        public string Generate(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}\n";
        }
    }
}