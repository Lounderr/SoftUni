using System;

namespace E01.Logger
{
    internal class SimpleLayout : ILayout
    {
        public string Generate(string dateTime, ReportLevel reportLevel, string message)
        {
            return $"{dateTime} - {Enum.GetName(typeof(ReportLevel), reportLevel)} - {message}\n";
        }
    }
}