using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        public static Dictionary<string, Car> cars = new Dictionary<string, Car>();

        private string model;
        private Engine engine; // speed, power
        private Cargo cargo; // type, weight
        private Tire[] tires = new Tire[4]; // age, pressure

        public string Model { get => model; set { model = value; } }
        public Engine Engine { get => engine; set => engine = value; }
        public Cargo Cargo { get => cargo; set => cargo = value; }
        public Tire[] Tires { get => tires; set => tires = value; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
    }
}
