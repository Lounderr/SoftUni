using System;
using System.IO;
using System.Text;

namespace SteamsFilesAndDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"C:\Temp\data.txt");

            Console.WriteLine(@"Writing to ""C:\Temp\outputFile.txt""");

            using StreamWriter sw = new StreamWriter(@"C:\Temp\outputFile.txt", false, Encoding.UTF8);
            int i = 0;
            while (!sr.EndOfStream)
            {
                sw.Write(i);
                sw.WriteLine(sr.ReadLine());
                i++;
            }
            sw.WriteLine("Hello world!");
            //sw.Dispose(); //sw.Close();



            using var sw2 = new StreamWriter("console.txt");
            Console.SetOut(sw2);
            Console.WriteLine("Test");
        }
    }
}
