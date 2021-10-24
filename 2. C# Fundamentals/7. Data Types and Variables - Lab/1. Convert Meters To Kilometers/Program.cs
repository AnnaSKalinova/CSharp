using System;

namespace _1._Convert_Meters_To_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());

            double km = meters * 0.001;

            Console.WriteLine($"{km:F2}");
        }
    }
}
