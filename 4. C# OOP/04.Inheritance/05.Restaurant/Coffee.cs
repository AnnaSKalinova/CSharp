namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DEF_MILLILITERS_CAFFEE = 50;
        private const decimal DEF_PRICE_CAFFEE = 3.50M;
        public Coffee(string name, double caffeine)
            : base(name, 0, 0)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }

        public override decimal Price => DEF_PRICE_CAFFEE;
        public override double Milliliters => DEF_MILLILITERS_CAFFEE;
    }
}
