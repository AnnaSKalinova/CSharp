using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        private IReadOnlyCollection<IBakedFood> FoodOrders => foodOrders.ToList().AsReadOnly();
        private IReadOnlyCollection<IDrink> DrinkOrders => drinkOrders.ToList().AsReadOnly();

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; set; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople + this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(dr => dr.Price);

        public void Reserve(int numberOfPeople)
        {
            if (this.NumberOfPeople == numberOfPeople)
            {
                this.IsReserved = true;
            }
        }
        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }
        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }
        public decimal GetBill()
        {
            var result = this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(dr => dr.Price);

            return result;
        }
        public void Clear()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}
