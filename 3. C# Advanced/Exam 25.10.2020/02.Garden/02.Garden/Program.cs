using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowSize = dimensions[0];
            var colSize = dimensions[1];

            int[,] matrix = new int[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            var command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (!command.Contains("Bloom"))
            {
                var rowToPlant = int.Parse(command[0]);
                var colToPlant = int.Parse(command[1]);

                if (rowToPlant >= 0 && rowToPlant < rowSize && colToPlant >= 0 && colToPlant < colSize)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, colToPlant] += 1;
                    }
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[rowToPlant, col] += 1;
                    }
                    matrix[rowToPlant, colToPlant]--;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
