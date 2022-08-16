using System;
using System.Collections.Generic;

namespace P06.EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> ss = new SortedSet<Person>();
            HashSet<Person> hs = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0].ToLower();

                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                ss.Add(person);
                hs.Add(person);
            }

            Console.WriteLine(ss.Count);
            Console.WriteLine(hs.Count);
        }
    }
}


