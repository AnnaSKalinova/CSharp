using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> trace = Console.ReadLine().Split().Select(int.Parse).ToList();

            int midPoint = trace.Count / 2;
            int carIndex = 0;
            double timeOfLeftCar = 0;
            double timeOfRightCar = 0;

            while (carIndex != midPoint)
            {
                timeOfLeftCar += trace[carIndex];
                if (trace[carIndex] == 0)
                {
                    timeOfLeftCar -= timeOfLeftCar * 0.2;
                }
                timeOfRightCar += trace[trace.Count - 1 - carIndex];
                if (trace[trace.Count - 1 - carIndex] == 0)
                {
                    timeOfRightCar -= timeOfRightCar * 0.2;
                }
                carIndex++;
            }

            if (timeOfRightCar < timeOfLeftCar)
            {
                Console.WriteLine($"The winner is right with total time: {timeOfRightCar}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {timeOfLeftCar}");
            }
        }
    }
}
