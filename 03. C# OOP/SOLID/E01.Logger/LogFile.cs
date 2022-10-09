using System.IO;
using System.Text;
using System.Linq;
using System;

namespace E01.Logger
{
    public class LogFile
    {
        private StringBuilder log;
        
        public LogFile()
        {
            log = new StringBuilder();
            Size = 0;
        }
        public int Size { get; private set; }

        public void Write(string layoutResult)
        {
            using StreamWriter logFileWriter = new StreamWriter("log.txt", true, Encoding.UTF8);
            logFileWriter.WriteLine(layoutResult);

            log.AppendLine(layoutResult);

            Size = log.ToString().Where(x => char.IsLetter(x)).Select(x => (int)x).Sum();
            //Console.WriteLine(String.Join("", log.ToString().Where(x => char.IsLetter(x))));
            //Console.WriteLine(Size);
        }
    }
}