namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double DEF_GRAMS_FISH = 22;
        public Fish(string name, decimal price)
            : base(name, price, 0)
        {
        }

        public override double Grams => DEF_GRAMS_FISH;
    }
}
