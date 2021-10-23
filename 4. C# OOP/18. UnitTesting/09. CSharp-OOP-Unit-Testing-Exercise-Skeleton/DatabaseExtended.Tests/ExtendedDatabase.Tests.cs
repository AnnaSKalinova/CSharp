using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyConstructorShouldReturnCountZero()
        {
            // Arrange
            var db = new ExtendedDatabase();

            // Act
            var actualResult = db.Count;
            var expectedResult = 0;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddOnePersonToTheConstructorAndItShouldReturnOne()
        {
            // Arrane
            var db = new ExtendedDatabase();
            var person = new Person(111111, "Ivan");

            // Act
            db.Add(person);
            var expectedResult = 1;
            var actualReslt = db.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualReslt);
        }

        [Test]
        public void ConstructorShouldThrowAnExceptionIfAreAddedMorePeopleThan16()
        {
            // Arrange
            var personArr = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                personArr[i] = new Person(i, $"Ivan + {i}");
            }

            // Assert
            Assert.Throws<ArgumentException>(() =>
                new ExtendedDatabase(personArr), // Act
                "The collection is not full."
            );
        }

        [Test]
        public void TestIfAddingToTheCollectionWorksCorrectly()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(222, "Ivan"));

            // Act
            db.Add(new Person(111, "Pesho"));

            var actualResult = db.FindById(222);

            // Assert
            Assert.That(actualResult.Id, Is.EqualTo(222));
            Assert.That(actualResult.UserName, Is.EqualTo("Ivan"));
        }

        [Test]
        public void ThrowAnExceptionIfTryToAddAPersonToAFullCollection()
        {
            // Arrange
            var personArr = new Person[16];

            // Act
            for (int i = 0; i < personArr.Length; i++)
            {
                personArr[i] = new Person(i, $"Pesho + {i}");
            }
            var db = new ExtendedDatabase(personArr);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            db.Add(new Person(2535, "Ani"))
            );
        }

        [Test]
        public void AddingAPersonWithTheSameNameShouldThrowAnException()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(1235, "Acho"));

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            db.Add(new Person(543, "Acho"))
            );
        }

        [Test]
        public void AddingAPersonWithTheSameIdShouldThrowAnException()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(1235, "Acho"));

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            db.Add(new Person(1235, "Mariya")) // Act
            );
        }

        [Test]
        public void TestIfAddingAPersonIncreasesTheCount()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(246, "Iva"));

            // Act
            db.Add(new Person(5456, "Kaloyan"));

            var expectingResult = 2;
            var actualResult = db.Count;

            // Assert
            Assert.AreEqual(expectingResult, actualResult);
        }

        [Test]
        public void RemovingAPersonShouldDecreaseCount()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(54, "Stamat"));

            // Act
            db.Remove();

            var expectedResult = 0;
            var actualResult = db.Count;

            // Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void ShouldThrowAnExceptionIfRemoveAPersonFromAnEmptyCollection()
        {
            // Arrange
            var db = new ExtendedDatabase();

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            db.Remove() // Act
            );
        }

        [Test]
        public void TestIfFindByNameReturnsAPersonCorrectly()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(125, "Monika"));

            // Act
            var actualResult = db.FindByUsername("Monika");

            // Assert
            Assert.That(actualResult.UserName, Is.EqualTo("Monika"));
            Assert.That(actualResult.Id, Is.EqualTo(125));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ShouldThrowAnExceptionIfGivenNameIsNullOrEmpty(string username)
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(564, "Misho"));

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            db.FindByUsername(username) //Act
            );
        }

        [Test]
        public void ShoulThrowAnExceptionIfTheGivenNameDoesntExist()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(684, "Katya"));

            // Assert
            Assert.Throws<InvalidOperationException>(() => 
            db.FindByUsername("Polya")
            );
        }

        public void TestIfFindByIdReturnsAPersonCorrectly()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(125, "Monika"));

            // Act
            var actualResult = db.FindById(125);

            // Assert
            Assert.That(actualResult.UserName, Is.EqualTo("Monika"));
            Assert.That(actualResult.Id, Is.EqualTo(125));
        }

        [Test]
        public void ShouldThrowAnExceptionIfGivenIdIsNegative()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(564, "Misho"));

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            db.FindById(-652) //Act
            );
        }

        [Test]
        public void ShoulThrowAnExceptionIfTheGivenIdDoesntExist()
        {
            // Arrange
            var db = new ExtendedDatabase(new Person(684, "Katya"));

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            db.FindById(985)
            );
        }
    }
}