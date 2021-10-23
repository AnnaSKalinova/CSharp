using System;

namespace _10.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            string boxes = Console.ReadLine();

            int volume = width * lenght * hight;
            int totalBoxes = 0;

            while (boxes != "Done")
            {
                totalBoxes += int.Parse(boxes);
                boxes = Console.ReadLine();
                if (totalBoxes > volume)
                {
                    break;
                }
            }
            if (totalBoxes <= volume)
            {
                Console.WriteLine($"{volume - totalBoxes} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {totalBoxes - volume} Cubic meters more.");
            }
        }
    }
}
