using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], bool> isDividable = (x, y) =>
            {
                for (int i = 0; i < y.Length; i++)
                {
                    if (x % y[i] != 0)
                    {
                        return false;
                    }
                }
                return true;
            };


            int[] range = Enumerable.Range(1, n).ToArray();

            Console.WriteLine(String.Join(" ", range.Where(x => isDividable(x, dividers))));

        }
    }
}
