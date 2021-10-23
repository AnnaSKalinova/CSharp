using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string message = Console.ReadLine();

            string output = string.Empty;

            for (int i = 0; i < inputList.Count; i++)
            {
                int currentNumber = inputList[i];
                int index = 0;
                int counter = 0;

                while (currentNumber > 0)
                {
                    index += currentNumber % 10;
                    currentNumber /= 10;
                }

                for (int j = 0; j < message.Length; j++)
                {
                    if (j == message.Length - 1)
                    {
                        j = 0;
                        counter++;
                    }
                    if (index == counter)
                    {
                        output += message[j];
                        message = message.Remove(j, 1);
                        break;
                    }
                    counter++;
                }
            }

            Console.WriteLine(output);
        }
    }
}
