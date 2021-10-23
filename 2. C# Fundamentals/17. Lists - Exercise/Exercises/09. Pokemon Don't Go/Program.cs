using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            while (inputList.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                int removedElement = 0;
                
                if (index < 0)
                {
                    removedElement = inputList[0];
                    inputList.RemoveAt(0);
                    inputList.Insert(0, inputList[inputList.Count - 1]);
                }
                else if (index > inputList.Count - 1)
                {
                    removedElement = inputList[inputList.Count - 1];
                    inputList.RemoveAt(inputList.Count - 1);
                    inputList.Add(inputList[0]);
                }
                else
                {
                    removedElement = inputList[index];
                    inputList.RemoveAt(index);
                }

                sum += removedElement;

                for (int i = 0; i < inputList.Count; i++)
                {
                    if (inputList[i] <= removedElement)
                    {
                        inputList[i] += removedElement;
                    }
                    else if (inputList[i] > removedElement)
                    {
                        inputList[i] -= removedElement;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
