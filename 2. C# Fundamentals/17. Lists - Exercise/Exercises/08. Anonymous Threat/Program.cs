using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];
                switch (action)
                {
                    case "merge":
                        Merge(inputList, int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "divide":
                        Divide(inputList, int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', inputList));
        }

        static void Merge(List<string> inputList, int start, int end)
        {
            if (start < 0)
            {
                start = 0;
            }
            if (end < 0)
            {
                end = 0;
            }
            if (start > inputList.Count - 1)
            {
                start = inputList.Count - 1;
            }
            if (end > inputList.Count - 1)
            {
                end = inputList.Count - 1;
            }
            for (int i = start + 1; i <= end; i++)
            {
                inputList[start] += inputList[i];
            }
            inputList.RemoveRange(start + 1, end - start);
        }

        static void Divide(List<string> inputList, int index, int partitions)
        {
            List<string> partOfList = new List<string>();
            string element = inputList[index];
            inputList.RemoveAt(index);
            int counter = 0;

            for (int i = 0; i < partitions; i++)
            {
                string partOfElement = string.Empty;

                for (int j = 0; j < element.Length / partitions; j++)
                {
                    partOfElement += element[counter];
                    counter++;
                }
                if (i == partitions - 1 && element.Length % partitions != 0)
                {
                    partOfElement += element.Last();
                }

                partOfList.Add(partOfElement);
            }

            inputList.InsertRange(index, partOfList);
        }
    }
}
