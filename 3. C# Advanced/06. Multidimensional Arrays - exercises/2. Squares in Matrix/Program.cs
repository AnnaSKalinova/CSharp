using System;
using System.Linq;

namespace _2._Squares_in_Matrix
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
            string[,] matrix = new string[rows, cols];
            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split()
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (row > 0 && col > 0 && 
                        matrix[row, col] == matrix[row - 1, col] &&
                        matrix[row, col] == matrix[row, col - 1] &&
                        matrix[row, col] == matrix[row - 1, col - 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
