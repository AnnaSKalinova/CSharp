using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        Add(inputList, command);
                        break;
                    case "Insert":
                        if (int.Parse(tokens[2]) > inputList.Count - 1 || int.Parse(tokens[2]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        Insert(inputList, command);
                        break;
                    case "Remove":
                        if (int.Parse(tokens[1]) > inputList.Count - 1 || int.Parse(tokens[1]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        Remove(inputList, command);
                        break;
                    case "Shift":
                        if (tokens[1] == "left")
                        {
                            ShiftLeft(inputList, command);
                        }
                        else
                        {
                            ShiftRight(inputList, command);
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            
            Console.WriteLine(string.Join(" ", inputList));
        }

        static List<int> Add(List<int> list, string command)
        {
            string[] tokens = command.Split();
            if (command.Contains("Add"))
            {
                list.Add(int.Parse(tokens[1]));
            }
            return list;
        }

        static List<int> Insert(List<int> list, string command)
        {
            string[] tokens = command.Split();
            if (command.Contains("Insert"))
            {
                list.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
            }
            return list;
        }

        static List<int> Remove(List<int> list, string command)
        {
            string[] tokens = command.Split();
            if (command.Contains("Remove"))
            {
                list.RemoveAt(int.Parse(tokens[1]));
            }
            return list;
        }

        static List<int> ShiftLeft(List<int> list, string command)
        {
            string[] tokens = command.Split();
            if (command.Contains("left"))
            {
                for (int i = 0; i < int.Parse(tokens[2]); i++)
                {
                    int firstNum = list[0];
                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        list[j] = list[j + 1];
                    }
                    list[list.Count - 1] = firstNum;
                }
            }
            return list;
        }

        static List<int> ShiftRight(List<int> list, string command)
        {
            string[] tokens = command.Split();
            if (command.Contains("right"))
            {
                for (int i = 0; i < int.Parse(tokens[2]); i++)
                {
                    int lastNum = list[list.Count - 1];
                    for (int j = list.Count - 1; j >= 1; j--)
                    {
                        list[j] = list[j - 1];
                    }
                    list[0] = lastNum;
                }
            }
            return list;
        }
    }
}
