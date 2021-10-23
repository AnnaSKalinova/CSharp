using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            int currentSum = 0;
            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] inputLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currentSum = 0;
                    for (int i = row; i <= row + 2; i++)
                    {
                        for (int j = col; j <= col + 2; j++)
                        {
                            currentSum += matrix[i, j];

                            if (currentSum > maxSum)
                            {
                                maxSum = currentSum;
                                maxRow = i;
                                maxCol = j;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            if (maxSum == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write("0 ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int row = maxRow - 2; row <= maxRow; row++)
                {
                    for (int col = maxCol - 2; col <= maxCol; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
