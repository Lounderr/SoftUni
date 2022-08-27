using System;
using System.Linq;
using System.IO;

namespace EvenLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"C:\Temp\text.txt");
            string[] symbols = new string[] { "-", ",", ".", "!", "?" };
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string line = sr.ReadLine();
                if (i % 2 == 0)
                {
                    foreach (var symbol in symbols)
                    {
                        line = line.Replace(symbol, "@");
                    }
                    Console.WriteLine(String.Join(' ', line.Split(' ').Reverse()));
                }
            }
        }
    }
}
