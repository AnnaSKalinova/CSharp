using System;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var territory = new char[size, size];
            var foodQuantity = 0;
            var snakeRow = 0;
            var snakeCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] inputRows = Console.ReadLine()
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = inputRows[col];
                    if (territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            bool isOutOfTerritory = false;
            bool isB = false;
            territory[snakeRow, snakeCol] = '.';
            while (true)
            {
                var command = Console.ReadLine();
                
                switch (command)
                {
                    case "up":
                        if (snakeRow < 1)
                        {
                            isOutOfTerritory = true;
                            break;
                        }
                        else if (territory[snakeRow - 1, snakeCol] == 'B')
                        {
                            territory[snakeRow - 1, snakeCol] = '.';
                            isB = true;
                            break;
                        }
                        else if (territory[snakeRow - 1, snakeCol] == '*')
                        {
                            foodQuantity++;
                        }
                        if (foodQuantity >= 10)
                        {
                            territory[snakeRow - 1, snakeCol] = 'S';
                        }
                        else
                        {
                            territory[snakeRow - 1, snakeCol] = '.';
                        }
                        snakeRow = snakeRow - 1;
                        break;
                    case "down":
                        if (snakeRow > territory.GetLength(0) - 2)
                        {
                            isOutOfTerritory = true;
                            break;  
                        }
                        else if (territory[snakeRow + 1, snakeCol] == 'B')
                        {
                            territory[snakeRow + 1, snakeCol] = '.';
                            isB = true;
                            break;
                        }
                        else if (territory[snakeRow + 1, snakeCol] == '*')
                        {
                            foodQuantity++;
                        }
                        if (foodQuantity >= 10)
                        {
                            territory[snakeRow + 1, snakeCol] = 'S';
                        }
                        else
                        {
                            territory[snakeRow + 1, snakeCol] = '.';
                        }
                        snakeRow = snakeRow + 1;
                        break;
                    case "left":
                        if (snakeCol < 1)
                        {
                            isOutOfTerritory = true;
                            break;
                        }
                        else if (territory[snakeRow, snakeCol - 1] == 'B')
                        {
                            territory[snakeRow, snakeCol - 1] = '.';
                            isB = true;
                            break;
                        }
                        else if (territory[snakeRow, snakeCol - 1] == '*')
                        {
                            foodQuantity++;
                        }
                        if (foodQuantity >= 10)
                        {
                            territory[snakeRow, snakeCol - 1] = 'S';
                        }
                        else
                        {
                            territory[snakeRow, snakeCol - 1] = '.';
                        }
                        snakeCol = snakeCol - 1;
                        break;
                    case "right":
                        if (snakeCol > territory.GetLength(1) - 2)
                        {
                            isOutOfTerritory = true;
                            break;
                        }
                        else if (territory[snakeRow, snakeCol + 1] == 'B')
                        {
                            territory[snakeRow, snakeCol + 1] = '.';
                            isB = true;
                            break;
                        }
                        else if (territory[snakeRow, snakeCol + 1] == '*')
                        {
                            foodQuantity++;
                        }
                        if (foodQuantity >= 10)
                        {
                            territory[snakeRow, snakeCol + 1] = 'S';
                        }
                        else
                        {
                            territory[snakeRow, snakeCol + 1] = '.';
                        }
                        snakeCol = snakeCol + 1;
                        break;
                }
                if (isB)
                {
                    var rowAndCol = BFileds(territory);
                    var bRow = rowAndCol[0];
                    var bCol = rowAndCol[1];
                    territory[bRow, bCol] = '.';
                    snakeRow = bRow;
                    snakeCol = bCol;
                }
                isB = false;
                if (isOutOfTerritory || foodQuantity >= 10)
                {
                    break;
                }
            }
            if (isOutOfTerritory)
            {
                Console.WriteLine("Game over!");
            }
            else if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }

        static int[] BFileds(char[,] matrix)
        {
            int[] rowAndCol = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        rowAndCol[0] = row;
                        rowAndCol[1] = col;
                        return rowAndCol;
                    }
                }
            }
            return rowAndCol;
        }
    }
}
