using System;

namespace Е02.VehiclesExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Car info
            string[] carInfo = Console.ReadLine().Split();
            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            if (carFuel > carTankCapacity)
            {
                Console.WriteLine($"Cannot fit {carFuel} fuel in the tank");
            }

            Car car = new Car(carFuel, carConsumption, carTankCapacity);


            // Truck info
            string[] truckInfo = Console.ReadLine().Split();
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            if (truckFuel > truckTankCapacity)
            {
                Console.WriteLine($"Cannot fit {truckFuel} fuel in the tank");
            }

            Truck truck = new Truck(truckFuel, truckConsumption, truckTankCapacity);


            // Bus info
            string[] busInfo = Console.ReadLine().Split();
            double busFuel = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            if (busFuel > busTankCapacity)
            {
                Console.WriteLine($"Cannot fit {busFuel} fuel in the tank");
            }

            Bus bus = new Bus(busFuel, busConsumption, busTankCapacity);



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
                    else if (cmd[1] == "Bus")
                    {
                        if (bus.Drive(distance))
                        {
                            Console.WriteLine($"Bus travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"Bus needs refueling");
                        }
                    }
                }
                else if (cmd[0] == "DriveEmpty")
                {
                    double distance = double.Parse(cmd[2]);

                    if (cmd[1] == "Bus")
                    {
                        if (bus.DriveEmpty(distance))
                        {
                            Console.WriteLine($"Bus travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"Bus needs refueling");
                        }
                    }
                }
                else if (cmd[0] == "Refuel")
                {
                    double liters = double.Parse(cmd[2]);

                    if (liters <= 0)
                    {
                        Console.WriteLine($"Fuel must be a positive number");
                    }
                    
                    else if (cmd[1] == "Car")
                    {
                        car.Refuel(liters);
                        if (liters <= car.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                        }
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Refuel(liters);
                        if (liters <= truck.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                        }
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.Refuel(liters);
                        if (liters <= bus.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                        }
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}\nTruck: {truck.FuelQuantity:f2}\nBus: {bus.FuelQuantity:f2}");
        }
    }
}
