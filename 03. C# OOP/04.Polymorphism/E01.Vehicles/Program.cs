using System;

namespace E01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Car info
            string[] carInfo = Console.ReadLine().Split(); // Car {fuel quantity} {liters per km}
            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);

            Car car = new Car(carFuel, carConsumption);

            string[] truckInfo = Console.ReadLine().Split(); // Truck {fuel quantity} {liters per km}
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);

            Truck truck = new Truck(truckFuel, truckConsumption);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();


                if (cmd[0] == "Drive")
                {
                    double distance = double.Parse(cmd[2]);

                    if (cmd[1] == "Car")
                    {
                        if (car.Drive(distance))
                        {
                            Console.WriteLine($"Car travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"Car needs refueling");
                        }
                    }
                    else if (cmd[1] == "Truck")
                    {
                        if (truck.Drive(distance))
                        {
                            Console.WriteLine($"Truck travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"Truck needs refueling");
                        }
                    }
                }
                else if (cmd[0] == "Refuel")
                {
                    double liters = double.Parse(cmd[2]);

                    if (cmd[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}\nTruck: {truck.FuelQuantity:f2}");


        }
    }
}
