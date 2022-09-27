namespace E01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base (fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 0.9;
        }
    }
}
