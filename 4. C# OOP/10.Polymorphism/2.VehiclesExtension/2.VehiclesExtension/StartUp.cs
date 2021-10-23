using System;
using System.Linq;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine()
                .Split()
                .ToArray();
            var fuelQuantity = double.Parse(carInfo[1]);
            var litersPerKm = double.Parse(carInfo[2]);
            var tankCapacity = double.Parse(carInfo[3]);

            Vehicle car = new Car(fuelQuantity, litersPerKm, tankCapacity);

            var truckInfo = Console.ReadLine()
                .Split()
                .ToArray();
            fuelQuantity = double.Parse(truckInfo[1]);
            litersPerKm = double.Parse(truckInfo[2]);
            tankCapacity = double.Parse(truckInfo[3]);

            Vehicle truck = new Truck(fuelQuantity, litersPerKm, tankCapacity);

            var busInfo = Console.ReadLine()
                .Split()
                .ToArray();
            fuelQuantity = double.Parse(busInfo[1]);
            litersPerKm = double.Parse(busInfo[2]);
            tankCapacity = double.Parse(busInfo[3]);

            Vehicle bus = new Bus(fuelQuantity, litersPerKm, tankCapacity);

            var numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                var command = Console.ReadLine()
                    .Split()
                    .ToArray();
                switch (command[0])
                {
                    case "Drive":
                    case "DriveEmpty":
                        var distance = double.Parse(command[2]);
                        var canDrive = false;
                        var vehicle = string.Empty;
                        switch (command[1])
                        {
                            case "Car":
                                canDrive = car.DistaceDriven(distance);
                                vehicle = "Car";
                                break;
                            case "Truck":
                                canDrive = truck.DistaceDriven(distance);
                                vehicle = "Truck";
                                break;
                            case "Bus":
                                if (command[0] == "Drive")
                                {
                                    canDrive = bus.DistaceDriven(distance);
                                }
                                else if (command[0] == "DriveEmpty")
                                {
                                    canDrive = bus.DriveEmpty(distance);
                                }
                                vehicle = "Bus";
                                break;
                        }
                        if (canDrive)
                        {
                            Console.WriteLine($"{vehicle} travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }
                        break;
                    case "Refuel":
                        var fuelToRefuel = double.Parse(command[2]);
                        switch (command[1])
                        {
                            case "Car":
                                car.FuelQuantity = car.Refuel(fuelToRefuel);
                                break;
                            case "Truck":
                                truck.FuelQuantity = truck.Refuel(fuelToRefuel);
                                break;
                            case "Bus":
                                bus.FuelQuantity = bus.Refuel(fuelToRefuel);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
