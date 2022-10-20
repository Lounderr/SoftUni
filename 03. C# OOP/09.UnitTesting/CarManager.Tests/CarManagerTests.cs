using CarManager;

namespace CarManager.Tests
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.ComponentModel;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CtorNormalParams()
        {
            Car car = new Car("make", "model", 1.4, 30);

            Assert.That("make" == car.Make);
            Assert.That("model" == car.Model);
            Assert.That(1.4 == car.FuelConsumption);
            Assert.That(30 == car.FuelCapacity);
        }

        [Test]
        public void CtorEmptyOrNullMake()
        {
            Assert.That(() =>
            {
                Car car = new Car("", "model", 1.4, 30);
            },
            Throws.ArgumentException);

            Assert.That(() =>
            {
                Car car = new Car(null, "model", 1.4, 30);
            },
            Throws.ArgumentException);
        }

        [Test]
        public void CtorEmptyOrNullModel()
        {
            Assert.That(() =>
            {
                Car car = new Car("make", "", 1.4, 30);
            },
            Throws.ArgumentException);

            Assert.That(() =>
            {
                Car car = new Car("make", null, 1.4, 30);
            },
            Throws.ArgumentException);
        }

        [Test]
        public void CtorFuelConsumptionZeroOrNegative()
        {
            Assert.That(() =>
            {
                Car car = new Car("make", "model", 0, 30);
            },
            Throws.ArgumentException);

            Assert.That(() =>
            {
                Car car = new Car("make", "model", -1.4, 30);
            },
            Throws.ArgumentException);
        }

        [Test]
        public void CtorFuelCapacityZeroOrNegative()
        {
            Assert.That(() =>
            {
                Car car = new Car("make", "model", 1.4, 0);
            },
            Throws.ArgumentException);

            Assert.That(() =>
            {
                Car car = new Car("make", "model", 1.4, -1);
            },
            Throws.ArgumentException);
        }

        [Test]
        public void RefuelNormal()
        {
            Car car = new Car("make", "model", 1.4, 30);

            car.Refuel(15);

            Assert.That(15 == car.FuelAmount);
        }

        [Test]
        public void RefuelZeroOrNegative()
        {
            Car car = new Car("make", "model", 1.4, 30);

            Assert.That(() => car.Refuel(0), Throws.ArgumentException);

            Assert.That(() => car.Refuel(-1), Throws.ArgumentException);
        }

        [Test]
        public void RefuelOverCapacity()
        {
            Car car = new Car("make", "model", 1.4, 30);
            car.Refuel(35);

            Assert.That(car.FuelAmount == 30);
        }

        [Test]
        public void DriveNormal()
        {
            Car car = new Car("make", "model", 1.4, 30);

            car.Refuel(30);
            car.Drive(150);

            Assert.That(car.FuelAmount == 27.9);
        }

        [Test]
        public void DriveTooFar()
        {
            Car car = new Car("make", "model", 1.4, 30);

            car.Refuel(2);

            Assert.That(() => car.Drive(150), Throws.InvalidOperationException);
        }

        [Test]
        public void FuelAmountNegative()
        {
            Car car = new Car("make", "model", 1.4, 30);

            try
            {
                typeof(Car).GetProperty(nameof(Car.FuelAmount)).SetValue(car, -1, null);
            }
            catch (Exception e)
            {

                Assert.That(e.InnerException.GetType() == typeof(ArgumentException));
                return;
            }

            Assert.IsTrue(false);
        }
    }
}