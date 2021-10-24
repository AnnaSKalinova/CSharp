using System;

namespace _9.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentageInput = double.Parse(Console.ReadLine());

            double volume = lenght * width * height;
            double litersVolume = volume * 0.001; ;
            double otherStuff = litersVolume * percentageInput * 0.01;
            double volumeOfWater = litersVolume - otherStuff;

            Console.WriteLine($"{volumeOfWater:F3}");
        }
    }
}
