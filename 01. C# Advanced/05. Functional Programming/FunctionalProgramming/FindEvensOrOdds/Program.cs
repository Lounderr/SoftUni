using System;
using System.Linq;

namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string evenOdd = Console.ReadLine();

            Predicate<int> predicate = s => true;

            if (evenOdd == "even")
            {
                predicate = s => s % 2 == 0;
            }
            else if (evenOdd == "odd")
            {
                predicate = s => s % 2 != 0;
            }

            Console.WriteLine(String.Join(' ', Enumerable.Range(range[0], range[1] - range[0] + 1).Where(x => predicate(x))));

        }
    }
}
