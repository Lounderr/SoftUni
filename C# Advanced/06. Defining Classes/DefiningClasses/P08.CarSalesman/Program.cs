using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>();
            Dictionary<string, Engine> Engines = new Dictionary<string, Engine>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Engine engine = new Engine();

                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                int power = int.Parse(engineData[1]);

                engine.Model = model;
                engine.Power = power;

                if (engineData.Length == 3)
                {
                    if (char.IsDigit(engineData[2], 0))
                    {
                        engine.Displacement = int.Parse(engineData[2]);
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }
                else if (engineData.Length == 4)
                {
                    engine.Displacement = int.Parse(engineData[2]);
                    engine.Efficiency = engineData[3];
                }
                Engines.Add(model, engine);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                Car car = new Car();

                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                string engine = carData[1];
                car.Model = model;
                car.Engine = Engines[engine];


                if (carData.Length == 3)
                {
                    if (char.IsDigit(carData[2], 0))
                    {
                        car.Weight = int.Parse(carData[2]);
                    }
                    else
                    {
                        car.Color = carData[2];
                    }
                }
                else if (carData.Length == 4)
                {

                    car.Weight = int.Parse(carData[2]);
                    car.Color = carData[3];
                }
                Cars.Add(car);
            }

            foreach (var car in Cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
