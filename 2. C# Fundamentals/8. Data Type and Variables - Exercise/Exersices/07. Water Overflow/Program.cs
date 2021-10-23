using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int linesCount = int.Parse(Console.ReadLine());
            int waterTank = 0;

            for (int i = 0; i < linesCount; i++)
            {
                int pouredWater = int.Parse(Console.ReadLine());
                if (capacity < pouredWater)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                else
                {
                    capacity -= pouredWater;
                    waterTank += pouredWater;
                }
            }
            Console.WriteLine(waterTank);
        }
    }
}
