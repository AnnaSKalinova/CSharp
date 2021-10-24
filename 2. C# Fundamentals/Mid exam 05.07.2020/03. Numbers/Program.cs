using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputSequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            int counter = 0;
            int totalValue = 0;
            double averageValue = 0.0;
            bool isNumber = false;

            for (int i = 0; i < inputSequence.Count; i++)
            {
                totalValue += inputSequence[i];
            }

            averageValue = totalValue * 1.0 / inputSequence.Count();

            inputSequence.Sort();
            inputSequence.Reverse();

            foreach (var number in inputSequence)
            {
                if (counter == 5)
                {
                    break;
                }
                if (number * 1.0 > averageValue)
                {
                    isNumber = true;
                    Console.Write(number + " ");
                }
                counter++;
            }

            if (!isNumber)
            {
                Console.WriteLine("No");
            }
        }
    }
}
