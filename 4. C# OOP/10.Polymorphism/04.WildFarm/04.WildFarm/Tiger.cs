using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override List<Type> FoodToEat => new List<Type>
        {
            typeof(Meat)
        };
        public override double WeightGained => 1;
        public override string ProduceASound()
        {
            return "ROAR!!!";
        }
    }
}
