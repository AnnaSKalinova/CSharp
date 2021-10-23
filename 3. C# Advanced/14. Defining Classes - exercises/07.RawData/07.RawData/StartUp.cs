using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _07.RawData
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Car[] cars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split()
                    .ToArray();
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                cars[i] = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
            }

            var command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                    var result = cars
                        .Where(c => c.Cargo.CargoType == "fragile")
                        .Where(x => x.Tires.Any(t => t.TirePressure < 1));
                    Console.WriteLine(string.Join(Environment.NewLine, result));
                    break;
                case "flamable":
                    result = cars
                        .Where(c => c.Cargo.CargoType == "flamable")
                        .Where(x => x.Engine.EnginePower > 250);
                    Console.WriteLine(string.Join(Environment.NewLine, result));
                    break;
            }
        }
    }
}
