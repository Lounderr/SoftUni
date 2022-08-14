using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace IteratorsAndComparators
{
    public class CompareByName : IComparer<Apple>
    {
        public int Compare(Apple first, Apple other)
        {
            return first.Name.CompareTo(other.Name);
        }
    }
    public class Apple : IComparable<Apple>
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public Apple(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public int CompareTo([AllowNull] Apple other)
        {
            // Custom Logic

            // this > other => 1
            // this < other => -1
            // this == other => 0

            return Size.CompareTo(other.Size);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Apple> applesList = new List<Apple>()
            {
                new Apple("Ябълката Анчо", 10),
                new Apple("Ябълката Срацимир", 15),
                new Apple("Ябълката Генчо", 5)
            };

            //applesList.Sort();
            applesList.Sort(new CompareByName());

            foreach (var apple in applesList)
            {
                Console.WriteLine($"Име: {apple.Name}");
                Console.WriteLine($"Големина: {apple.Size}");
            }
        }
    }
}


