using System;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DEF_CALORIES_CAKE = 1000;
        private const double DEF_GRAMS_CAKE = 250;
        private const decimal DEF_PRICE_CAKE = 5;

        public Cake(string name)
            : base(name, 0, 0, 0)
        {
        }

        public override double Calories => DEF_CALORIES_CAKE;
        public override double Grams => DEF_GRAMS_CAKE;
        public override decimal Price => DEF_PRICE_CAKE;

    }
}
