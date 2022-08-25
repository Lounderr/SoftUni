using System;
using System.Collections.Generic;

namespace P06.SpeedRacing
{
    public class Car
    {
        public static Dictionary<string, Car> cars = new Dictionary<string, Car>();
        private string model; // model is unique 
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public void Drive(double km)
        {
            if (fuelAmount >= fuelConsumptionPerKilometer * km)
            {
                this.fuelAmount -= fuelConsumptionPerKilometer * km;
                this.travelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKM = double.Parse(carInfo[2]);
                Car.cars.Add(model, new Car(model, fuelAmount, fuelConsumptionPerKM));
            }

            while (true)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd[0] == "End")
                {
                    foreach (var car in Car.cars.Values)
                    {
                        Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
                    }
                    break;
                }

                if (cmd[0] == "Drive") // Drive {carModel} {amountOfKm} ; 20km =  1L
                {
                    string model = cmd[1];
                    double km = double.Parse(cmd[2]);

                    Car.cars[model].Drive(km);
                }
            }
        }
    }
}
