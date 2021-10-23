using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string productName;
        private decimal cost;

        public Product(string productName, decimal cost)
        {
            this.ProductName = productName;
            this.Cost = cost;
        }

        public string ProductName
        {
            get => this.productName;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannotbe empty");
                }
                this.productName = value;
            }
        }
        public decimal Cost
        {
            get => this.cost;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }
    }
}
