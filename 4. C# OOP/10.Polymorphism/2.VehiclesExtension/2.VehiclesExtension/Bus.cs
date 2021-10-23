namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public bool IsWithPeople { get; set; }
        protected override double AirConditionIncrease => 1.4;
    }
}
