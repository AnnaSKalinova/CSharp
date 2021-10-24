using System;

namespace _3.SquareArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSide = int.Parse(Console.ReadLine());
            int squareArea = squareSide * squareSide;

            Console.WriteLine(squareArea);
        }
    }
}
