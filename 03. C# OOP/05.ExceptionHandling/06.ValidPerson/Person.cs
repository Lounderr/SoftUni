using System;

namespace _06.ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get => firstName; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                lastName = value;
            }
        }
        public int Age
        {
            get => age; set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException();
                }
                age = value;
            }
        }
    }
}
