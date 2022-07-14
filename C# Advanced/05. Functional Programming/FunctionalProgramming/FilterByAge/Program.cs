using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    internal class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] pair = Console.ReadLine().Split(", ");
                people.Add(new Person(pair[0], int.Parse(pair[1])));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = p => true;

            if (condition == "younger")
            {
                filter = x => x.Age < age;
            }
            else if (condition == "older")
            {
                filter = x => x.Age >= age;
            }


            Func<Person, string> printFunc = p => "";

            if (format == "name")
            {
                printFunc = p => p.Name;
            }
            else if (format == "age")
            {
                printFunc = p => p.Age.ToString();
            }
            else if (format == "name age")
            {
                printFunc = p => $"{p.Name} - {p.Age}";
            }



            foreach (var p in people.Where(filter).Select(printFunc))
            {
                Console.WriteLine(p);
            }



        }
    }
}
