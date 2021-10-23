using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Car
    {
        private string model;
        private decimal fuelAmount;
        private decimal fuelConsumptionPerKilometer;
        private decimal travelledDistance;

        public Car(string model, decimal fuelAmount, decimal fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public string Model { get; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumptionPerKilometer { get; }
        public decimal TravelledDistance { get; set; }

        public decimal Distance(decimal fuelAmount, decimal fuelConsumptionPerKilometer)
        {
            decimal travelledDistance = fuelAmount / fuelConsumptionPerKilometer;

            return travelledDistance;
        }

        public void CanMove(decimal distance)
        {
            if (distance * this.FuelConsumptionPerKilometer >= this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += distance;
            }
        }
    }
}

