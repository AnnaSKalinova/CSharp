namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; }

        protected abstract double IncreaseForAirCondition { get; }

        public bool Drive(double distance)
        {
            bool canDriveDistance = false;
            if (FuelQuantity >= distance * this.FuelConsumption + distance * this.IncreaseForAirCondition)
            {
                this.FuelQuantity -= distance * FuelConsumption + distance * IncreaseForAirCondition;
                canDriveDistance = true;
            }
            return canDriveDistance;
        }

        public virtual double Refuel(double fuelToRefuel)
        {
            this.FuelQuantity += fuelToRefuel;
            return this.FuelQuantity;
        }
    }
}
