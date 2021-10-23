using System;

namespace _6.CircleAreaAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double circleArea = Math.PI * r * r;
            double circlePerimeter = 2 * Math.PI * r;

            Console.WriteLine($"{circleArea:F2}");
            Console.WriteLine("{0:F2}", circlePerimeter);
        }
    }
}
