using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string nameOfPerson;
        private decimal money;
        private List<Product> products;

        public Person(string nameOfPerson, decimal money)
        {
            this.NameOfPerson = nameOfPerson;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string NameOfPerson
        {
            get => this.nameOfPerson;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.nameOfPerson = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public List<Product> Products { get; set; }

        public void CanBuy(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Products.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.NameOfPerson} bought {product.ProductName}");
            }
            else
            {
                Console.WriteLine($"{this.NameOfPerson} can't afford {product.ProductName}");
            }
        }
    }
}
