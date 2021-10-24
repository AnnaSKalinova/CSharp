using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Add":
                        train.Add(int.Parse(tokens[1]));
                        break;
                    default:
                        for (int i = 0; i < train.Count; i++)
                        {
                            if (train[i] <= capacity - int.Parse(tokens[0]))
                            {
                                train[i] += int.Parse(tokens[0]);
                                break;
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
