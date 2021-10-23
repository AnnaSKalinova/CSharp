using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override List<Type> FoodToEat => new List<Type>
        {
            typeof(Vegetable),
            typeof(Meat)
        };
        public override double WeightGained => 0.30;
        public override string ProduceASound()
        {
            return "Meow";
        }
    }
}
