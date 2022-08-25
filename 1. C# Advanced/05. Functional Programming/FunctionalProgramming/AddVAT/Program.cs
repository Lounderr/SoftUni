using System;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x + x * 0.2).ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");

            }
        }
    }
}
