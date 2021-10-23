using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomCount = int.Parse(Console.ReadLine());
            char roomKind = ' ';

            for (int i = floors; i > 0; i--)
            {
                for (int j = 0; j < roomCount; j++)
                {
                    if (i == floors)
                    {
                        roomKind = 'L';
                    }
                    else if (i % 2 == 0)
                    {
                        roomKind = 'O';
                    }
                    else
                    {
                        roomKind = 'A';
                    }
                    
                    Console.Write($"{roomKind}"+ i + j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
