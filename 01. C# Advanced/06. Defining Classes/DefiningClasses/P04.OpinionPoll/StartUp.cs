using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> people = new List<Person>();
        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetOldestMember()
        {
            return people.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
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
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }
            foreach (var p in family.people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(p.Name + " - " + p.Age);
            }
        }
    }
}
