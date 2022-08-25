using System;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person()
        {

        }

        public Person(string name, int age) : this()
        {
            Name = name;
            Age = age;
        }

    }
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Peter";
            person1.Age = 20;

            Person person2 = new Person();
            person2.Name = "George";
            person2.Age = 18;

            Person person = new Person("Jose", 43);

        }
    }
}
