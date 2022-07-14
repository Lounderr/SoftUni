using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Temp\text.txt");

            for (int row = 0; row < lines.Length; row++)
            {
                string line = lines[row];

                lines[row] = $"Line {row + 1}: {line} ({line.Count(x => char.IsLetter(x))})({line.Count(x => char.IsPunctuation(x))})";
            }
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
