using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        public override List<Type> FoodToEat => new List<Type>
        {
            typeof(Meat)
        };
        public override double WeightGained => 0.25;
        public override string ProduceASound()
        {
            return "Hoot Hoot";
        }
    }
}
