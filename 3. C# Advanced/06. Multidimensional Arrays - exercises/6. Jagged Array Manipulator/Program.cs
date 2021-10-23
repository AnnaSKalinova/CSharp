using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                double[] inputCols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                matrix[row] = inputCols;
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            while (!command.Contains("End"))
            {
                switch (command[0])
                {
                    case "Add":
                        int row = int.Parse(command[1]);
                        int col = int.Parse(command[2]);
                        int value = int.Parse(command[3]);
                        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                        {
                            matrix[row][col] += value;
                        }
                        break;
                    case "Subtract":
                        row = int.Parse(command[1]);
                        col = int.Parse(command[2]);
                        value = int.Parse(command[3]);
                        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                        {
                            matrix[row][col] -= value;
                        }
                        break;
                }

                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
