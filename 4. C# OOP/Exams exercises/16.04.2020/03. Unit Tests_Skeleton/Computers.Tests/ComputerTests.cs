namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        Part part = null;
        Computer computer = null;
        List<Part> parts;

        [SetUp]
        public void Setup()
        {
            part = new Part("some", 200);
            computer = new Computer("test");
            parts = new List<Part>();
        }

        [Test]
        public void TestIfPartConstructorWorksCorrectly()
        {
            Assert.AreEqual("some", part.Name);
            Assert.AreEqual(200, part.Price);
        }

        [Test]
        public void TestIfComputerWorksCorrectly()
        {
            Assert.AreEqual("test", computer.Name);
        }

        [Test]
        public void TestIfComputerWorksCorrectlyPart2()
        {
            Assert.AreEqual(0, parts.Count);
        }

        [Test]
        public void TestIfThrowsExceptionWhenComputersNameIsNull()
        {
            Computer nullComputer = null;

            Assert.Throws<ArgumentNullException>(() =>
            nullComputer = new Computer(null)
            );
        }

        [Test]
        public void TestIfTotalPriceWorksCorrectly()
        {
            computer.AddPart(part);
            computer.AddPart(new Part("other", 300));
            var actualReasult = computer.TotalPrice;

            Assert.AreEqual(500, actualReasult);
        }
        [Test]
        public void TestIfThrowsAnExceptionIfAddNullPart()
        {
            Assert.Throws<InvalidOperationException>(() =>
            computer.AddPart(null)
            );
        }

        [Test]
        public void TestIfRemovePartWorksCrrectly()
        {
            computer.AddPart(part);
            computer.AddPart(new Part("other", 300));
            computer.RemovePart(part);

            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        public void TestIfGetPartWorksCrrectly()
        {
            computer.AddPart(part);
            
            Assert.AreEqual(part, computer.GetPart("some"));
        }
    }
}