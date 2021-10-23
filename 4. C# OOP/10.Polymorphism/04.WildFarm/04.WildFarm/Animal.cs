using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public virtual List<Type> FoodToEat { get; set; }
        public virtual double WeightGained { get; set; }

        public double EatFood(Food food)
        {
            if (this.FoodToEat.Contains(food.GetType()))
            {
                this.Weight += this.WeightGained * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            return this.Weight;
        }
        public virtual double GainWeight()
        {
            return this.Weight;
        }
        public virtual string ProduceASound()
        {
            return string.Empty;
        }
    }
}
