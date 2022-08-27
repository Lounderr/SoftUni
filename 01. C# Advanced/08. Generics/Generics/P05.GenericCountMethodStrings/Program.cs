using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.GenericCountMethodStrings
{
    internal class Program
    {
        public static int GetCountGreaterThan<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            int count = 0;
            foreach (T item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> strings = new List<string>();
            for (int i = 0; i < n; i++)
            {
                strings.Add(Console.ReadLine());
            }
            string element = Console.ReadLine();

            Console.WriteLine(GetCountGreaterThan(strings, element));
        }
    }
}