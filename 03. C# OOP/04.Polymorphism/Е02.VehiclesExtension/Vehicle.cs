using System;

namespace Е02.VehiclesExtension
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }

            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        protected Vehicle()
        {
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public virtual bool Drive(double distance)
        {
            if (0 <= FuelQuantity - distance * FuelConsumption)
            {
                FuelQuantity = FuelQuantity - distance * FuelConsumption;
                return true;
            }

            return false;
        }

        public virtual bool Refuel(double refuelQuantity)
        {
            if (FuelQuantity + refuelQuantity <= TankCapacity)
            {
                FuelQuantity += refuelQuantity;
                return true;
            }

            return false;
        }
    }
}
