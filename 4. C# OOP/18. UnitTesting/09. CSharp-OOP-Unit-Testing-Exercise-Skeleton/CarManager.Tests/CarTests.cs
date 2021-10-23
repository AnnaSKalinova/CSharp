using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            //Arrange
            car = new Car("Renault", "Capture", 8, 250);
        }

        [Test]
        public void TestIfGettersWorksCorrectly()
        {
            // Act
            var expectedResult = car;

            // Assert
            Assert.That(expectedResult.Make == "Renault");
            Assert.That(expectedResult.Model == "Capture");
            Assert.That(expectedResult.FuelConsumption == 8);
            Assert.That(expectedResult.FuelCapacity == 250);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(car);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowsExceptionIfMakeIsNull(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(make, "X-Trail", 10, 300);
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowsExceptionIfModelIsNull(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Nissan", model, 10, 300);
            });
        }

        [TestCase(null)]
        [TestCase(-10)]
        public void ThrowsExceptionIfFuelConsumptionIsNullOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Opel", "Astra", fuelConsumption, 120);
            });
        }
        [TestCase(null)]
        [TestCase(-100)]
        public void ThrowsExcepitonIfFuelCapacityIsNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Honda", "Civic", 9, fuelCapacity);
            });
        }

        [Test]
        public void TestIfFuelAmountIsZero()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase(-50)]
        public void ThrowAnExceptionIfFuelToRefuelIsZeroOrNegative(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            car.Refuel(fuelToRefuel)
            );
        }

        [Test]
        public void TestIfFuelToRefuelIsAddedToFuel()
        {
            // Act
            car.Refuel(15);

            var expectedResult = 15;
            var actualResult = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfFuelAmountIsBiggerThanCapacity()
        {
            // Act
            car.Refuel(300);

            var expectedResult = 250;
            var actualResult = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfFuelNeededIsCalculatedCorrectly()
        {
            // Act
            car.Refuel(10);
            car.Drive(100);

            var expectedResult = 2;
            var actualResult = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ThrowAnExceptionIfFuelNeededIsMoreThanFuelAmont()
        {
            // Act
            car.Refuel(6);
            
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            car.Drive(100)
            );
        }
    }
}