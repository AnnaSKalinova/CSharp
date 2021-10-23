using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());

            Car[] cars = new Car[numOfCars];

            for (int i = 0; i < numOfCars; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
                var model = carInfo[0];
                var fuelAmount = double.Parse(carInfo[1]);
                var fuelConsumptionFor1km = double.Parse(carInfo[2]);

                cars[i] = new Car(model, fuelAmount, fuelConsumptionFor1km);
            }

            var command = Console.ReadLine()
                .Split()
                .ToArray();

            while (!command.Contains("End"))
            {
                var carModel = command[1];
                var amountOfKm = double.Parse(command[2]);

                cars.Where(c => c.Model == carModel).ToList().ForEach(c => c.CanDrive(amountOfKm));

                command = Console.ReadLine()
                .Split()
                .ToArray();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
