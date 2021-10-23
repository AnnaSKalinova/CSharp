using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        public override List<Type> FoodToEat => new List<Type>
        {
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds),
            typeof(Vegetable)
        };
        public override double WeightGained => 0.35;
        public override string ProduceASound()
        {
            return "Cluck";
        }
    }
}
