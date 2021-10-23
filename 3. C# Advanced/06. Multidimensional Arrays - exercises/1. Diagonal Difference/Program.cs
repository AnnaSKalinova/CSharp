using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                int[] rowsInt = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowsInt[col];
                    if (row == col)
                    {
                        sumPrimaryDiagonal += matrix[row, col];
                    }
                    if (col == n - row - 1)
                    {
                        sumSecondaryDiagonal += matrix[row, col];
                    }
                }
            }

            int result = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);
            Console.WriteLine(result);
        }
    }
}
