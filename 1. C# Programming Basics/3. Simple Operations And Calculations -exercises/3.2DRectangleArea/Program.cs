using System;

namespace _3._2DRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double sideA = Math.Abs(x2 - x1);
            double sideB = Math.Abs(y2 - y1);

            double area = sideA * sideB;
            double perimeter = 2 * (sideA + sideB);

            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{perimeter:F2}");
        }
    }
}
