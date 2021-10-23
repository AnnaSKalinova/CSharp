using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            var side = int.Parse(Console.ReadLine());

            var matrix = new char[side, side];
            var beePossitionRow = 0;
            var beePossitionCol = 0;
            var pollinatedFlowers = 0;

            for (int row = 0; row < side; row++)
            {
                var inputLine = Console.ReadLine();

                for (int col = 0; col < side; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                bool isOnBonus = false;
                bool isLost = false;
                bool isCommandComplete = false;

                for (int row = beePossitionRow; row < side; row++)
                {
                    for (int col = beePossitionCol; col < side; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            beePossitionRow = row;
                            beePossitionCol = col;

                            switch (command)
                            {
                                case "up":
                                    beePossitionRow--;
                                    break;
                                case "down":
                                    beePossitionRow++;
                                    break;
                                case "left":
                                    beePossitionCol--;
                                    break;
                                case "right":
                                    beePossitionCol++;
                                    break;
                            }

                            if (beePossitionRow < 0 || beePossitionRow > side - 1 || beePossitionCol < 0 || beePossitionCol > side - 1)
                            {
                                Console.WriteLine("The bee got lost!");
                                isLost = true;
                                matrix[row, col] = '.';
                                break;
                            }
                            matrix[row, col] = '.';

                            row = beePossitionRow;
                            col = beePossitionCol;

                            if (matrix[row, col] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (matrix[row, col] == 'O')
                            {
                                isOnBonus = true;
                                matrix[row, col] = 'B';
                                row--;
                                col--;
                                break;
                            }
                            matrix[row, col] = 'B';
                            isCommandComplete = true;
                            break;
                        }

                    }
                    if (isLost || isCommandComplete)
                    {
                        break;
                    }

                    if (isOnBonus)
                    {
                        continue;
                    }
                }

                if (isLost)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            for (int row = 0; row < side; row++)
            {
                for (int col = 0; col < side; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
