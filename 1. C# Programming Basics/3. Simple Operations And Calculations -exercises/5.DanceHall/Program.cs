using System;

namespace _5.DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallLenght = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double wardrobeSide = double.Parse(Console.ReadLine());

            double wardrobeArea = (wardrobeSide * 100) * (wardrobeSide * 100);
            double benchArea = (hallLenght * 100) * (hallWidth * 100) / 10;
            double hallArea = (hallLenght * 100) * (hallWidth * 100) - wardrobeArea - benchArea;
            double dancersCount = Math.Floor(hallArea / 7040);

            Console.WriteLine(dancersCount);
        }
    }
}
