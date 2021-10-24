using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();

            while (!command.Contains("end"))
            {
                switch (command[0])
                {
                    case "swap":
                        Swap(inputList, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "multiply":
                        Multiply(inputList, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "decrease":
                        Decrease(inputList);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(", ", inputList));
        }

        static void Swap(List<int> list, int firstIndex, int secondIndex)
        {
            int firstCurrentNum = list[firstIndex];
            int secondCurrentNum = list[secondIndex];
            list.RemoveAt(firstIndex);
            list.Insert(firstIndex, secondCurrentNum);
            list.RemoveAt(secondIndex);
            list.Insert(secondIndex, firstCurrentNum);
        }

        static void Multiply(List<int> list, int firstIndex, int secondIndex)
        {
            int mulitpliedNum = list[firstIndex] * list[secondIndex];
            list.RemoveAt(firstIndex);
            list.Insert(firstIndex, mulitpliedNum);
        }

        static void Decrease(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] -= 1;
            }
        }
    }
}
