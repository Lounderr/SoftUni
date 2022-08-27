using System;
using System.Collections.Generic;
using System.Text;

namespace E01.Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }




        // 2. Add Constructor

        // 3. Add Properties

        // 4. Add Methods

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();

        }
    }
}
