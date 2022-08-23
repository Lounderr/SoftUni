using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07.RawData
{
    class Program
    {
        class Car
        {
            public int speed;
            public int power;

            public string type;
            public int weight;


            public string Model { get; set; }
            public Tire[] Tires;
            public Engine EngSpeedAndPower { get; set; }
            public Cargo TypeAndWeight { get; set; }

            public Car()
            {
                Tires = new Tire[4];
                EngSpeedAndPower = new Engine(speed, power);
                TypeAndWeight = new Cargo(type, weight);
            }


            public Car(string model, Engine engine, int cargoWeught, string cargoType,
                double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
            {
                Model = model;



                EngSpeedAndPower = engine;
                TypeAndWeight.Weight = cargoWeught;
                TypeAndWeight.Type = cargoType;
                Tires[0].Pressure = tire1Pressure;
                Tires[0].Age = tire1Age;
                Tires[1].Pressure = tire2Pressure;
                Tires[1].Age = tire2Age;
                Tires[2].Pressure = tire3Pressure;
                Tires[2].Age = tire3Age;
                Tires[3].Pressure = tire4Pressure;
                Tires[3].Age = tire4Age;
            }

        }

        class Engine
        {
            public int Speed { get; set; }
            public int Power { get; set; }

            public Engine(int speed, int power)
            {
                Speed = speed;
                Power = power;
            }
        }

        class Cargo
        {
            public string Type { get; set; }
            public int Weight { get; set; }

            public Cargo(string type, int weight)
            {
                Type = type;
                Weight = weight;
            }
        }

        class Tire
        {
            public int Age { get; set; }
            public double Pressure { get; set; }

            public Tire(int age, double pressure)
            {
                Age = age;
                Pressure = pressure;
            }
        }


        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //Car car = new Car();
            List<Car> cars = new List<Car>();

            /* "{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
             * {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age}
             * {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"*/

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(" ");
                string carName = inputInfo[0];
                int engSpeed = int.Parse(inputInfo[1]);
                int engPower = int.Parse(inputInfo[2]);
                int cargoWeight = int.Parse(inputInfo[3]);
                string cargoType = inputInfo[4];

                double tire1Pressure = double.Parse(inputInfo[5]);
                int tire1Age = int.Parse(inputInfo[6]);
                double tire2Pressure = double.Parse(inputInfo[7]);
                int tire2Age = int.Parse(inputInfo[8]);
                double tire3Pressure = double.Parse(inputInfo[9]);
                int tire3Age = int.Parse(inputInfo[10]);
                double tire4Pressure = double.Parse(inputInfo[11]);
                int tire4Age = int.Parse(inputInfo[12]);


                Engine engine = new Engine(engSpeed, engPower);

                cars.Add(new Car(carName, engine, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age));
            }

            string command = Console.ReadLine();

            switch (command)
            {
                //The cars should be printed in order of appearing in the input.

                case "fragile":

                    foreach (var item in cars.Where(x => x.TypeAndWeight.Type == command && x.Tires.Any(y => y.Pressure < 1)))
                    {
                        Console.WriteLine(item.Model);
                    }
                    // print all cars whose cargo is "fragile" and have a pressure of a single tire < 1
                    break;

                case "flammable":
                    foreach (var item in cars.Where(x => x.TypeAndWeight.Type == command && x.EngSpeedAndPower.Power > 250))
                    {
                        Console.WriteLine(item.Model);
                    }
                    //print all cars, whose cargo is "flammable" and have engine power > 250
                    break;
            }
        }
    }
}