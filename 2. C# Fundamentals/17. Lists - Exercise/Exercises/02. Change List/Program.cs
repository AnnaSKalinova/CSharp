using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            
            while (command != "end")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Delete":
                        inputList.RemoveAll(x => x == int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        inputList.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", inputList));
        }
    }
}
