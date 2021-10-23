using System;
using System.Linq;

namespace ConsoleApp1
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
                string model = carInfo[0];
                decimal fuelAmount = decimal.Parse(carInfo[1]);
                decimal fuelConsumptionFor1km = decimal.Parse(carInfo[2]);

                cars[i] = new Car(model, fuelAmount, fuelConsumptionFor1km);

                decimal travelledDistance = cars[i].Distance(fuelAmount, fuelConsumptionFor1km);
            }

            string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

            while (!command.Contains("End"))
            {
                string model = command[1];
                decimal amountOfKm = decimal.Parse(command[2]);

                cars.Where(c => c.Model == model).ToList().ForEach(c => c.CanMove(amountOfKm));

                command = Console.ReadLine()
                    .Split()
                    .ToArray();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine("{0} {1:F2} {2}", car.Model, car.FuelAmount, car.TravelledDistance);
            }
        }
    }
}
