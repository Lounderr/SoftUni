using System;
using System.IO;

namespace FilesAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileContent = File.ReadAllText(@"C:\Temp\data.txt");
            File.WriteAllText("output.txt", fileContent);

            string[] fileLines = File.ReadAllLines(@"C:\Temp\data.txt");
            File.WriteAllLines("output.txt", fileLines);

            Directory.CreateDirectory(@"C:\Temp\newDir");
            //Directory.Move(@"C:\Temp\newDir", @"C:\Temp\dirRenamed");

            foreach (var file in Directory.GetFiles("."))
            {
                Console.WriteLine($"{file} => {new FileInfo(file).Length}");
            }
        }
    }
}
