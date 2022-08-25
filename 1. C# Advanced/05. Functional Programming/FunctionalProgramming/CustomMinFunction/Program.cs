using System;
using System.Linq;

namespace CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minN = (ints) => ints.Min();

            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(minN(ints));
        }
    }
}
