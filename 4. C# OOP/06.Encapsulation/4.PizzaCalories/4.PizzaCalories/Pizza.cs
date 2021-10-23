using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PizzaCalories
{
    public class Pizza
    {
        private string EXC_MSG_NAME = "Pizza name should be between 1 and 15 symbols.";
        private string EXC_MSG_TOPP_COUNT = "Number of toppings should be in range [0..10].";
        private string pizzaName;
        private List<Topping> toppings;

        public Pizza(string pizzaName)
        {
            this.PizzaName = pizzaName;
            this.Toppings = new List<Topping>();
        }

        public string PizzaName 
        {
            get => this.pizzaName;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(EXC_MSG_NAME);
                }
                this.pizzaName = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count >= 10)
            {
                throw new ArgumentException(EXC_MSG_TOPP_COUNT);
            }
            this.Toppings.Add(topping);
        }

        public double CalculateCalories()
        {
            var calculateToppingCalories = this.Toppings.Select(t => t.CalculateToppingCalories()).Sum();
            var calculateDoughCalories = this.Dough.CalculateDoughCalories();
            var totalCalories = calculateToppingCalories + calculateDoughCalories;

            return totalCalories;
        }
    }
}
