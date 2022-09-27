using System;
using System.Collections.Generic;
using System.Text;

namespace Е02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override bool Drive(double distance)
        {
            if (0 <= FuelQuantity - distance * FuelConsumption + 1.4)
            {
                FuelQuantity = FuelQuantity - distance * FuelConsumption + 1.4;
                return true;
            }

            return false;
        }

        public bool DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }

    }
}
