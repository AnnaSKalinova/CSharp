using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n , n];
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] rowInts = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInts[col];

                    if (row == col)
                    {
                        primaryDiagonalSum += matrix[row, col];
                    }
                    if (col == ((n - 1) - row))
                    {
                        secondaryDiagonalSum += matrix[row, col];
                    }
                }
            }

            int diff = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(diff);
        }
    }
}
