using System;
using System.Linq;

namespace DefiningClasses
{
    internal class Program
    {
        public struct structure
        {
            public int[] arr;
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person() 
            {
                Console.WriteLine("Zero constructor!");
            }

            public Person(string name) : this()
            {
                Name = name;
                Console.WriteLine("First constructor!");
            }
            public Person(string name, int age) : this(name)
            {
                Age = age;
                Console.WriteLine("Second constructor!");
            }
        }
        static void Main(string[] args)
        {
            structure first = new structure();
            structure second = new structure();

            first.arr = new int[] { 1 };
            second.arr = new int[] { 1 };

            Console.WriteLine(structure.Equals(first, second));


            Person person = new Person();

            Person person2 = new Person("Shkumbata", 50);

        }
    }
}
