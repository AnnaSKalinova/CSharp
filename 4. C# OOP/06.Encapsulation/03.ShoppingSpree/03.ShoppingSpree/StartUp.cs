using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listOfPeople = new List<Person>();
            var listOfProducts = new List<Product>();

            var people = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < people.Length; i++)
            {
                var currentPerson = people[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var nameOfPerson = currentPerson[0];
                var money = decimal.Parse(currentPerson[1]);
                try
                {
                    Person person = new Person(nameOfPerson, money);
                    listOfPeople.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var products = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < products.Length; i++)
            {
                var currentPproduct = products[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var nameOfProduct = currentPproduct[0];
                var cost = decimal.Parse(currentPproduct[1]);
                try
                {
                    Product product = new Product(nameOfProduct, cost);
                    listOfProducts.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (!command.Contains("END"))
            {
                var givenName = command[0];
                var givenProductName = command[1];

                Person givenPerson = listOfPeople.Where(p => p.NameOfPerson == givenName).First();
                Product givenProduct = listOfProducts.Where(p => p.ProductName == givenProductName).First();

                givenPerson.CanBuy(givenProduct);

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var person in listOfPeople)
            {
                Console.Write(person.NameOfPerson + " - ");

                if (person.Products.Any())
                {
                    Console.WriteLine(string.Join(", ", person.Products.Select(x => x.ProductName)));
                }
                else
                {
                    Console.WriteLine("Nothing bought");
                }
            }
        }
    }
}
