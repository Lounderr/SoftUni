using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setLength = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = setLength[0];
            int m = setLength[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> result = new HashSet<int>();
            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    result.Add(num);
                }
            }

            Console.WriteLine(String.Join(' ', result));
        }
    }
}
