using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            while (firstSequence.Any() && secondSequence.Any())
            {
                int currentSum = firstSequence[0] + secondSequence[secondSequence.Count - 1];

                if (currentSum % 2 == 0)
                {
                    sum += currentSum;
                    firstSequence.RemoveAt(0);
                    secondSequence.RemoveAt(secondSequence.Count - 1);
                }
                else
                {
                    firstSequence.Add(secondSequence[secondSequence.Count - 1]);
                    secondSequence.RemoveAt(secondSequence.Count - 1);
                }
            }

            if (!firstSequence.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
