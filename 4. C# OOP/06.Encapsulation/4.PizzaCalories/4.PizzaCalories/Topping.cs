using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string EXC_MSG_TYPE = "Cannot place {0} on top of your pizza.";
        private string EXC_MSG_WEIGHT = "{0} weight should be in the range [1..50].";
        private double modifier = 1;
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => this.toppingType;
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(EXC_MSG_TYPE, value));
                }
                this.toppingType = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(EXC_MSG_WEIGHT, this.ToppingType));
                }
                this.weight = value;
            }
        }

        public double CalculateModifier()
        {
            switch (this.ToppingType.ToLower())
            {
                case "meat":
                    modifier *= 1.2;
                    break;
                case "veggies":
                    modifier *= 0.8;
                    break;
                case "cheese":
                    modifier *= 1.1;
                    break;
                case "sauce":
                    modifier *= 0.9;
                    break;
            }

            return modifier;
        }

        public double CalculateToppingCalories()
        {
            var toppingCalories = 2 * this.Weight * CalculateModifier();

            return toppingCalories;
        }
    }
}
