namespace Е02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 1.6;
        }

        public override bool Refuel(double refuelQuantity)
        {
            return base.Refuel(refuelQuantity * 0.95);
        }
    }
}
