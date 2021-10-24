using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] indexesOfLadybugs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];
            for (int i = 0; i < indexesOfLadybugs.Length; i++)
            {
                for (int j = 0; j < field.Length; j++)
                {
                    if (j == indexesOfLadybugs[i])
                    {
                        field[j] = 1;
                    }
                } 
            }
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                int index = int.Parse(tokens[0]);
                string direction = tokens[1];
                int flyLenght = int.Parse(tokens[2]);

                switch (direction)
                {
                    case "right":
                        if (index + flyLenght < fieldSize)
                        {
                            for (int i = index; i < length; i++)
                            {

                            }
                        }
                        else
                        {
                            field[index] = 0;
                        }
                        break;
                    case "left":
                        //todo
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

        }
    }
}
