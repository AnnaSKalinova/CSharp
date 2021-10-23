using System;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AirConditionIncrease => 1.6;

        public override double Refuel(double fuelToRefuel)
        {
            if (this.TankCapacity >= this.FuelQuantity + fuelToRefuel)
            {
                return base.Refuel(fuelToRefuel * 0.95);
            }
            else
            {
                return base.Refuel(fuelToRefuel);
            }
        }
    }
}
