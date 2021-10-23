using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        public override List<Type> FoodToEat => new List<Type>
        {
            typeof(Meat)
        };
        public override double WeightGained => 0.40;
        public override string ProduceASound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
