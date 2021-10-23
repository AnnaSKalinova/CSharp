using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            var currentRow = 0;
            var currentCol = 0;
            bool isWon = false;

            for (int row = 0; row < size; row++)
            {
                var inputLine = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputLine[col];
                    if (matrix[row, col] == 'f')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                var command = Console.ReadLine();
                matrix[currentRow, currentCol] = '-';

                GetMoved(matrix, command, ref currentRow, ref currentCol);
                ChechIndexes(matrix, ref currentRow, ref currentCol);

                if (matrix[currentRow, currentCol] == 'B')
                {
                    GetMoved(matrix, command, ref currentRow, ref currentCol);
                    ChechIndexes(matrix, ref currentRow, ref currentCol);
                }
                if (matrix[currentRow, currentCol] == 'T')
                {
                    switch (command)
                    {
                        case "up":
                            command = "down";
                            break;
                        case "down":
                            command = "up";
                            break;
                        case "left":
                            command = "right";
                            break;
                        case "right":
                            command = "left";
                            break;
                    }
                    GetMoved(matrix, command, ref currentRow, ref currentCol);
                    ChechIndexes(matrix, ref currentRow, ref currentCol);
                }
                if (matrix[currentRow, currentCol] == 'F')
                {
                    isWon = true;
                    matrix[currentRow, currentCol] = 'f';
                    break;
                }

                matrix[currentRow, currentCol] = 'f';
            }


            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            
            PrintMatrix(size, matrix);
        }

        
        private static void GetMoved(char[,] matrix, string command, ref int currentRow, ref int currentCol)
        {
            switch (command)
            {
                case "up":
                    currentRow--;
                    break;
                case "down":
                    currentRow++;
                    break;
                case "left":
                    currentCol--;
                    break;
                case "right":
                    currentCol++;
                    break;
            }
        }

        private static void ChechIndexes(char[,] matrix, ref int currentRow, ref int currentCol)
        {
            if (currentRow < 0)
            {
                currentRow = matrix.GetLength(0) - 1;
            }
            else if (currentRow > matrix.GetLength(0) - 1)
            {
                currentRow = 0;
            }
            if (currentCol < 0)
            {
                currentCol = matrix.GetLength(1) - 1;
            }
            else if (currentCol > matrix.GetLength(1) - 1)
            {
                currentCol = 0;
            }
        }

        private static void PrintMatrix(int size, char[,] matrix)
        {
            for (int currentRow = 0; currentRow < size; currentRow++)
            {
                for (int currentCol = 0; currentCol < size; currentCol++)
                {
                    Console.Write(matrix[currentRow, currentCol]);
                }
                Console.WriteLine();
            }
        }
    }
}
