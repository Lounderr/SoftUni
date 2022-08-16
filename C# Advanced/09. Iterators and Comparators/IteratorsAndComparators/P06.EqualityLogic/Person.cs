using System;
using System.Diagnostics.CodeAnalysis;

namespace P06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Person;

            if (item == null)
            {
                return false;
            }

            if (this.Name == item.Name)
            {
                return this.Age.Equals(item.Age);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (this.Name + this.Age).GetHashCode();
        }

        public int CompareTo([AllowNull] Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
                result = Age.CompareTo(other.Age);

            return result;
        }
    }
}


