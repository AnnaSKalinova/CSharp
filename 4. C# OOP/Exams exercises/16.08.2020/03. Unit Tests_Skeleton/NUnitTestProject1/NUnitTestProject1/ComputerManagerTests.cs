using NUnit.Framework;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class ComputerManagerTests
    {
        private Computer computer;
        private List<Computer> computers;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("this", "some", 100);
            computers = new List<Computer>();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("this", computer.Manufacturer);
            Assert.AreEqual("some", computer.Model);
            Assert.AreEqual(100, computer.Price);
        }

        [Test]
        public void Test2()
        {
            computers.Add(computer);

            Assert.AreEqual(1, computers.Count);
        }
    }
}