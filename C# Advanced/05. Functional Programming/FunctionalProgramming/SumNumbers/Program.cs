using System;
using System.Linq;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(ints.Length);
            Console.WriteLine(ints.Sum());
        }
    }
}
