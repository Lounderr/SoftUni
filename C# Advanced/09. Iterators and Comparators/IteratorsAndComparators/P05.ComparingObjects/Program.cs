using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                people.Add(new Person(name, age, town));

                input = Console.ReadLine().Split();
            }
            
            int n = int.Parse(Console.ReadLine());

            Person person = people[n - 1];
            int matches = 0;
            int nonMatches = 0;
            int allPeople = people.Count;

            foreach (var otherPerson in people)
            {
                if (person.CompareTo(otherPerson) == 0)
                {
                    matches++;
                }
                else
                {
                    nonMatches++;
                }
            }

            if (matches != 1)
            {
                Console.WriteLine($"{matches} {nonMatches} {allPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
