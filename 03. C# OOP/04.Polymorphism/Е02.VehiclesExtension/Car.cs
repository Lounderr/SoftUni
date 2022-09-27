﻿namespace Е02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base (fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 0.9;
        }
    }
}
