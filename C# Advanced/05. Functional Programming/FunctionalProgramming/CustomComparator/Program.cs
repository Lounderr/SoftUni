using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> isEven = (x) => x % 2 == 0;
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> even = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (isEven(nums[i]))
                {
                    even.Add(nums[i]);
                    nums.RemoveAt(i);
                }
            }
            Console.WriteLine(String.Join(' ', even.OrderBy(x => x).Concat(nums.OrderBy(x => x))));
        }
    }
}
