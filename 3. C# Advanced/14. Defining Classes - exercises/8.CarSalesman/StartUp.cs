using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace _8.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Engine[] engines = new Engine[n];

            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);
                var displacement = 0;
                var efficiency = string.Empty;

                if (engineInfo.Length == 2)
                {
                    engines[i] = new Engine(model, power);
                }
                else if (engineInfo.Length == 3)
                {
                    if (engineInfo[2].All(char.IsDigit))
                    {
                        displacement = int.Parse(engineInfo[2]);
                        engines[i] = new Engine(model, power, displacement);
                    }
                    else
                    {
                        efficiency = engineInfo[2];
                        engines[i] = new Engine(model, power, efficiency);
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    displacement = int.Parse(engineInfo[2]);
                    efficiency = engineInfo[3];

                    engines[i] = new Engine(model, power, displacement, efficiency);
                }
            }
            int m = int.Parse(Console.ReadLine());

            Car[] cars = new Car[m];

            for (int i = 0; i < m; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var model = carInfo[0];
                Engine engine = engines.First(e => e.Model == carInfo[1]);
                var weight = 0;
                var color = string.Empty;

                if (carInfo.Length == 2)
                {
                    cars[i] = new Car(model, engine);
                }
                else if (carInfo.Length == 3)
                {
                    if (carInfo[2].All(char.IsDigit))
                    {
                        weight = int.Parse(carInfo[3]);
                        cars[i] = new Car(model, engine, weight);
                    }
                    else
                    {
                        color = carInfo[2];
                        cars[i] = new Car(model, engine, color);
                    }
                }
                else if (carInfo.Length == 4)
                {
                    weight = int .Parse(carInfo[2]);
                    color = carInfo[3];
                    cars[i] = new Car(model, engine, weight, color);
                }
            }

            cars.ToList().ForEach(Console.WriteLine);
        }
    }
}
