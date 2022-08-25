using System;
using System.Collections.Generic;

namespace P06.GenericCountMethodDouble
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
            List<double> strings = new List<double>();
            for (int i = 0; i < n; i++)
            {
                strings.Add(double.Parse(Console.ReadLine()));
            }
            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(GetCountGreaterThan(strings, element));
        }
    }

}
