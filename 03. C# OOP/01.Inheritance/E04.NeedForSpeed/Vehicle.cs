namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption { get; set; } = 1.25;

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }


        //The default fuel consumption for Vehicle is 1.25. Some of the classes have different default fuel consumption values:
        //•	SportCar – DefaultFuelConsumption = 10
        //•	RaceMotorcycle – DefaultFuelConsumption = 8
        //•	Car – DefaultFuelConsumption = 3
    }

    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            base.DefaultFuelConsumption = 3;
        }
    }

    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            base.DefaultFuelConsumption = 10;
        }
    }

    public class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }

    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }

    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            base.DefaultFuelConsumption = 8;
        }
    }

    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
