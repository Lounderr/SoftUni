using System.Text;

namespace E01.Logger
{
    internal class XmlLayout : ILayout
    {
        public string Generate(string dateTime, string reportLevel, string message)
        {
            StringBuilder xmlString = new StringBuilder();

            xmlString.AppendLine($"<log>");
            xmlString.AppendLine($"\t<date>{dateTime}</date>");
            xmlString.AppendLine($"\t<level>{reportLevel}</level>");
            xmlString.AppendLine($"\t<message>{message}</message>");
            xmlString.AppendLine($"</log>");

            return xmlString.ToString();
        }
    }
}