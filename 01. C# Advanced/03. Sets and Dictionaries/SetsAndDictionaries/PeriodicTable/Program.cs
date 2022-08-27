using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] chemEls = Console.ReadLine().Split(' ');
                foreach (var chemEl in chemEls)
                {
                    set.Add(chemEl);
                }
            }
            Console.WriteLine(String.Join(' ', set));
        }
    }
}
