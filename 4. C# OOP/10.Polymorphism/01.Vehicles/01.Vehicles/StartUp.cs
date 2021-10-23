using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputCar = Console.ReadLine()
                .Split()
                .ToArray();
            var fuelQuantity = double.Parse(inputCar[1]);
            var fuelConsumption = double.Parse(inputCar[2]);
            Vehicle car = new Car(fuelQuantity, fuelConsumption);

            var inputTruck = Console.ReadLine()
                .Split()
                .ToArray();
            fuelQuantity = double.Parse(inputTruck[1]);
            fuelConsumption = double.Parse(inputTruck[2]);
            Vehicle truck = new Truck(fuelQuantity, fuelConsumption);

            var numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                var command = Console.ReadLine()
                    .Split()
                    .ToArray();
                switch(command[0])
                {
                    case "Drive":
                        bool canDrive = false;
                        string vehicle = string.Empty;

                        if (command[1] == "Car")
                        {
                            canDrive = car.Drive(double.Parse(command[2]));
                            vehicle = "Car";
                        }
                        else if (command[1] == "Truck")
                        {
                            canDrive = truck.Drive(double.Parse(command[2]));
                            vehicle = "Truck";
                        }

                        if (canDrive)
                        {
                            Console.WriteLine($"{vehicle} travelled {double.Parse(command[2])} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }
                        break;
                    case "Refuel":
                        if (command[1] == "Car")
                        {
                            car.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
