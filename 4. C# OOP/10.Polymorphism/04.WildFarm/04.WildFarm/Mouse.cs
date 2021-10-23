using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
        public override List<Type> FoodToEat => new List<Type>
        {
            typeof(Vegetable),
            typeof(Fruit)
        };
        public override double WeightGained => 0.10;
        public override string ProduceASound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
