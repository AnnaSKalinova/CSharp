using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];
            var counterKnightsToAttack = 0;
            var maxCounterKnightsToAttack = 0;
            var rowOfKnightToRemove = 0;
            var colOfKnightToRemove = 0;
            var removedKnightsCounter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLines = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLines[col];
                }
            }

            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            if (row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 2 && matrix[row + 1, col + 2] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (row < matrix.GetLength(0) - 2 && col < matrix.GetLength(1) - 1 && matrix[row + 2, col + 1] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (row >= 2 && col >= 1 && matrix[row - 2, col - 1] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (row >= 1 && col >= 2 && matrix[row - 1, col - 2] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (row < matrix.GetLength(0) - 1 && col >= 2 && matrix[row + 1, col - 2] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (row < matrix.GetLength(0) - 2 && col >= 1 && matrix[row + 2, col - 1] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (row >= 1 && col < matrix.GetLength(1) - 2 && matrix[row - 1, col + 2] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (row >= 2 && col < matrix.GetLength(1) - 1 && matrix[row - 2, col + 1] == 'K')
                            {
                                counterKnightsToAttack++;
                            }
                            if (counterKnightsToAttack > maxCounterKnightsToAttack)
                            {
                                rowOfKnightToRemove = row;
                                colOfKnightToRemove = col;
                                maxCounterKnightsToAttack = counterKnightsToAttack;
                            }

                            counterKnightsToAttack = 0;
                        }
                    }
                }

                if (maxCounterKnightsToAttack == 0)
                {
                    break;
                }
                matrix[rowOfKnightToRemove, colOfKnightToRemove] = '0';
                removedKnightsCounter++;
                maxCounterKnightsToAttack = 0;
            }

            Console.WriteLine(removedKnightsCounter);
        }
    }
}
