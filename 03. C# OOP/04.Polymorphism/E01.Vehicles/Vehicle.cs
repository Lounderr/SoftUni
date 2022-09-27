namespace E01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public virtual bool Drive(double distance)
        {
            if (0 <= FuelQuantity - distance * FuelConsumption)
            {
                FuelQuantity = FuelQuantity - distance * FuelConsumption;
                return true;
            }

            return false;
        }

        public virtual void Refuel(double refuelQuantity)
        {
            FuelQuantity += refuelQuantity;
        }
    }
}
