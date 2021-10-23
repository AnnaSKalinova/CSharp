using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var snake = Console.ReadLine();

            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new string[rows , cols];
            var counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, col] = snake[counter].ToString();

                        counter++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                        matrix[row, col] = snake[counter].ToString();

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
