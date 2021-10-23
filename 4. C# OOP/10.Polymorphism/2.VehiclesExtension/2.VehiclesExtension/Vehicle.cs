using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;

        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; }
        public double TankCapacity { get; }
        protected abstract double AirConditionIncrease { get; }

        public bool DistaceDriven(double distance)
        {

            bool canDriveGivenDistance = false;

            if (this.FuelQuantity >= distance * (this.FuelConsumption + this.AirConditionIncrease))
            {
                this.FuelQuantity -= distance * (this.FuelConsumption + this.AirConditionIncrease);

                canDriveGivenDistance = true;
            }

            return canDriveGivenDistance;
        }
        public bool DriveEmpty(double distance)
        {

            bool canDriveGivenDistance = false;

            if (this.FuelQuantity >= distance * this.FuelConsumption)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;

                canDriveGivenDistance = true;
            }

            return canDriveGivenDistance;
        }

        public virtual double Refuel(double fuelToRefuel)
        {
            if (fuelToRefuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.TankCapacity >= this.FuelQuantity + fuelToRefuel)
            {
                this.FuelQuantity += fuelToRefuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuelToRefuel} fuel in the tank");
            }

            return this.FuelQuantity;
        }
    }
}
