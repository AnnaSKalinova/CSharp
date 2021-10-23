using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }
        public string Model { get; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void CanDrive(double distance)
        {
            if (this.FuelAmount < this.FuelConsumptionPerKilometer * distance)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= this.FuelConsumptionPerKilometer * distance;
                this.TravelledDistance += distance;
            }
        }
    }
}
