using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Froggy
{
    internal class Program
    {
        static void Main()
        {
            List<int> rocks = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Lake lake = new Lake(rocks);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
