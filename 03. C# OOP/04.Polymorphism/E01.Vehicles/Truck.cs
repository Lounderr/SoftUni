namespace E01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 1.6;
        }

        public override void Refuel(double refuelQuantity)
        {
            base.Refuel(refuelQuantity * 0.95);
        }
    }
}
