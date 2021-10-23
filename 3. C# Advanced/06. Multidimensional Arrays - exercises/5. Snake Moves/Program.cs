using System;
using System.Linq;
using System.Reflection;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int counter = 0;

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                        matrix[row, col] = snake[counter];
                        counter++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                        matrix[row, col] = snake[counter];
                        counter++;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
