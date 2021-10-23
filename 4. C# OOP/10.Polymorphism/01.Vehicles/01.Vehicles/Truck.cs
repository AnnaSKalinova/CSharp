namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double IncreaseForAirCondition => 1.6;

        public override double Refuel(double fuelToRefuel)
        {
            return base.Refuel(fuelToRefuel * 0.95);
        }
    }
}
