using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Tire
    {
        private int age;
        private double pressure;

        public int Age { get => age; set => age = value; }
        public double Pressure { get => pressure; set => pressure = value; }

        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
