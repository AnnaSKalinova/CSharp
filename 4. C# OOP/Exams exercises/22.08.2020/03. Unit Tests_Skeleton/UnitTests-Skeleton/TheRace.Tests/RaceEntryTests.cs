using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitCar car = null;
        UnitDriver driver = null;
        RaceEntry raceEntry = null;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("some", 100, 50);
            driver = new UnitDriver("Pesho", new UnitCar("fency", 200, 60));
            raceEntry = new RaceEntry();
        }

        [Test]
        public void TestIfUnitCarConstructorWorksCorrectly()
        {
            Assert.AreEqual("Pesho", driver.Name);
            Assert.AreEqual("fency", driver.Car.Model);
            Assert.AreEqual(200, driver.Car.HorsePower);
            Assert.AreEqual(60, driver.Car.CubicCentimeters);
        }

        [Test]
        public void TestIfUnitDriverConstructorWorksCorrectly()
        {
            Assert.AreEqual("some", car.Model);
            Assert.AreEqual(100, car.HorsePower);
            Assert.AreEqual(50, car.CubicCentimeters);
        }

        [Test]
        public void TestIfRaceEntryConstructorWorksCorrectly()
        {
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void TestIfAddNullDriverThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            raceEntry.AddDriver(null)
            );
        }

        [Test]
        public void TestThrowsExceptionIsAddExistingDriver()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            raceEntry.AddDriver(driver)
            );
        }

        [Test]
        public void TestIfAddDriverWorksCorrectly()
        {
            raceEntry.AddDriver(driver);

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void TestIfCalculateAverageHorsePowerWorksCorrectly()
        {
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(new UnitDriver("Stamat", new UnitCar("other", 100, 200)));

            Assert.AreEqual(150, raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestIfThrowsExceptionIfDriverCountIsLessThanMinParticipants()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            raceEntry.CalculateAverageHorsePower()
            );
        }
    }
}