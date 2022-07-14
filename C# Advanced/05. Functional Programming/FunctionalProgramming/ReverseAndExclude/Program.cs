using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, int, IEnumerable<int>> reverseCollection = ReverseCollection;

            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(String.Join(' ', reverseCollection(nums, n)));
        }
        static IEnumerable<T> ReverseCollection<T>(IEnumerable<T> collection, int n)
        {
            if (collection == null)
            {
                throw new ArgumentException();
            }

            return collection.Where(x => Convert.ToInt32(x) % n != 0).Reverse();
        }
    }
}
