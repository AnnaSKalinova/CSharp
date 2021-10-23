using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager storeManager;
        private Product product;

        [SetUp]
        public void Setup()
        {
            storeManager = new StoreManager();
            product = new Product("test", 5, 50.5M);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual("test", product.Name);
            Assert.AreEqual(5, product.Quantity);
            Assert.AreEqual(50.5, product.Price);
        }

        [Test]
        public void TestIfConstructorWorksCorrectlyPart2()
        {
            Assert.AreEqual(0, storeManager.Count);
            CollectionAssert.IsEmpty(storeManager.Products);
        }

        [Test]
        public void TestIfAddCommandWorksCorrectly()
        {
            storeManager.AddProduct(product);
            Assert.AreEqual(1, storeManager.Count);
        }

        [Test]
        public void TestIfThrowsExceptionWhenQuantityIsNegative()
        {
            Product otherProduct = new Product("some", -2, 120);
            Assert.Throws<ArgumentException>(() =>
            storeManager.AddProduct(otherProduct)
            );
        }

        [Test]
        public void TestIfThrowsExceptionWhenQuantityIsNull()
        {
            Product otherProduct = new Product("some", 0, 120);
            Assert.Throws<ArgumentException>(() =>
            storeManager.AddProduct(otherProduct)
            );
        }

        [Test]
        public void TestIfCountWorksCorrect()
        {
            storeManager.AddProduct(product);

            Assert.AreEqual(1, storeManager.Count);
        }

        [Test]
        public void TestIfThrowsExceptionWhenProductIsNull()
        {
            Product otherProduct = null ;
            Assert.Throws<ArgumentNullException>(() =>
            storeManager.AddProduct(otherProduct)
            );
        }

        [Test]
        public void TestIfThrowsExceptionWhenBuyProductThatIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            storeManager.BuyProduct(" ", 5)
            );
        }

        [Test]
        public void TestIfWantedQuantityIsLessThanAvailabeQuantity()
        {
            storeManager.AddProduct(product);
            Assert.Throws<ArgumentException>(() =>
            storeManager.BuyProduct(product.Name, 10)
            );
        }

        [Test]
        public void TestIfFinalPriceWorksCorrectly()
        {
            storeManager.AddProduct(product);

            var actualResult = storeManager.BuyProduct(product.Name, 2);
            var expectedResult = 101;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfGetMostExpenciveProductWorksCorrectly()
        {
            Product otherProduct = new Product("other", 2, 100);
            storeManager.AddProduct(product);
            storeManager.AddProduct(otherProduct);

            var actualResult = storeManager.GetTheMostExpensiveProduct();
            var expectedResult = otherProduct;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}