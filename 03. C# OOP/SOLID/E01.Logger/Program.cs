using System;

namespace E01.Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                ILayout layout = null;
                IAppender appender = null;

                string[] cmd = Console.ReadLine().Split();

                if (cmd[1] == "SimpleLayout")
                    layout = new SimpleLayout();
                else if (cmd[1] == "XmlLayout")
                    layout = new XmlLayout();

                if (cmd[0] == "ConsoleAppender")
                    appender = new ConsoleAppender(layout);
                else if (cmd[0] == "FileAppender")
                    appender = new FileAppender(layout, new LogFile());

                if (cmd.Length == 3)
                {
                    ReportLevel reportLevel = Enum.Parse<ReportLevel>(cmd[2]);
                    appender.ReportLevel = reportLevel;
                }

                appenders[i] = appender;
            }

            var logger = new Logger(appenders);

            while (true)
            {
                string[] log = Console.ReadLine().Split("|");
                if (log[0] == "END")
                    break;

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(log[0]);

                string dateTime = log[1];
                string message = log[2];

                switch (reportLevel)
                {
                    case ReportLevel.INFO:
                        logger.Info(dateTime, message);
                        break;
                    case ReportLevel.WARNING:
                        logger.Warning(dateTime, message);
                        break;
                    case ReportLevel.ERROR:
                        logger.Error(dateTime, message);
                        break;
                    case ReportLevel.CRITICAL:
                        logger.Critical(dateTime, message);
                        break;
                    case ReportLevel.FATAL:
                        logger.Fatal(dateTime, message);
                        break;
                }
            }

            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }
    }
}
