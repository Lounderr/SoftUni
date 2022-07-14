using System;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string[], int, string[]> getLessOrEqualLengths = (arr, n) => arr.Where(s => s.Length <= n).ToArray();
            Console.WriteLine(String.Join(Environment.NewLine, getLessOrEqualLengths(names, n)));
        }
    }
}
