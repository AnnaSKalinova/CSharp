using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item = null;
        private BankVault bankVault = null;


        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("some", "123456");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("some", item.Owner);
            Assert.AreEqual("123456", item.ItemId);
        }

        [Test]
        public void TestDictIsEmpty()
        {
            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }

        [Test]
        public void TestAdd()
        {
            bankVault.AddItem("A1", new Item("Pesho", "123"));
            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }

        [Test]
        public void TestAdd2()
        {
            Assert.Throws<ArgumentException>(() =>
            bankVault.AddItem("R1", new Item("Pesho", "123"))
            );
        }

        [Test]
        public void TestAdd3()
        {
            bankVault.AddItem("A1", new Item("Pesho", "123"));
            Assert.Throws<ArgumentException>(() =>
            bankVault.AddItem("A1", new Item("Pesho", "123"))
            );
        }

        [Test]
        public void TestAdd4()
        {
            bankVault.AddItem("A1", new Item("Pesho", "123"));
            Assert.Throws<InvalidOperationException>(() =>
            bankVault.AddItem("B1", new Item("Pesho", "123"))
            );
        }

        [Test]
        public void TestRemove1()
        {
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            Assert.AreEqual(null, bankVault.VaultCells["A1"]);
        }

        [Test]
        public void TestRemove2()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("C1", item)
            );
        }

        [Test]
        public void TestRemove3()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("A1", new Item("Pesho", "123"))
            );
        }

        [Test]
        public void TestRemove4()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("R1", item)
            );
        }

        [Test]
        public void TestDict()
        {
            int counter = 1;
            foreach (var keyValuePair in bankVault.VaultCells.OrderBy(k => k.Key))
            {
                switch (counter)
                {
                    case 1:
                        Assert.AreEqual("A1", keyValuePair.Key);
                        break;
                    case 2:
                        Assert.AreEqual("A2", keyValuePair.Key);
                        break;
                    case 3:
                        Assert.AreEqual("A3", keyValuePair.Key);
                        break;
                    case 4:
                        Assert.AreEqual("A4", keyValuePair.Key);
                        break;
                    case 5:
                        Assert.AreEqual("B1", keyValuePair.Key);
                        break;
                    case 6:
                        Assert.AreEqual("B2", keyValuePair.Key);
                        break;
                    case 7:
                        Assert.AreEqual("B3", keyValuePair.Key);
                        break;
                    case 8:
                        Assert.AreEqual("B4", keyValuePair.Key);
                        break;
                    case 9:
                        Assert.AreEqual("C1", keyValuePair.Key);
                        break;
                    case 10:
                        Assert.AreEqual("C2", keyValuePair.Key);
                        break;
                    case 11:
                        Assert.AreEqual("C3", keyValuePair.Key);
                        break;
                    case 12:
                        Assert.AreEqual("C4", keyValuePair.Key);
                        break;
                }
                counter++;
            }
        }

    }
}