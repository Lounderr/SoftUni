using E02.ValidationAttributes.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationAttributes
{
    internal class Person
    {
        private string egn;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;

            // custom exercise extension
            Random random = new Random();
            egn = String.Join("", Enumerable.Range(0, 10).Select(r => random.Next(10)).ToList());

            // debug
            Console.WriteLine(egn);
        }

        [MyRequired]
        public string FullName { get; }

        [MyRange(12, 90)]
        public int Age { get; }
    }
}
