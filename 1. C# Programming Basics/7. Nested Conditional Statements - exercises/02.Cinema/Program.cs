using System;

namespace _02.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            int area = rows * colums;
            double income = 0.0;

            switch (projectionType)
            {
                case "Premiere":
                    income = area * 12;
                    break;
                case "Normal":
                    income = area * 7.50;
                    break;
                case "Discount":
                    income = area * 5;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"{income:F2} leva");
        }
    }
}
