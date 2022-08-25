using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> repeatingNums = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (repeatingNums.ContainsKey(num))
                {
                    repeatingNums[num]++;
                }
                else
                {
                    repeatingNums.Add(num, 1);
                }
            }
            Console.WriteLine(repeatingNums.Where(x => x.Value % 2 == 0).FirstOrDefault().Key);
        }
    }
}
