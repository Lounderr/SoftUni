using System;
using System.Linq;

namespace ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ');
            Action<string[]> printNames = (names) 
                => Console.WriteLine(String.Join(Environment.NewLine, names));
            printNames(names);
        }
    }
}
