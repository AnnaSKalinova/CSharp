using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var roses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var lilies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var wreaths = 0;
            var storedFlowers = 0;

            while (roses.Count != 0 && lilies.Count != 0)
            {
                var sum = roses[0] + lilies[lilies.Count - 1];
                if (sum == 15)
                {
                    wreaths++;
                    roses.RemoveAt(0);
                    lilies.RemoveAt(lilies.Count - 1);
                }
                else if (sum > 15)
                {
                    lilies[lilies.Count - 1] -= 2;
                }
                else if (sum < 15)
                {
                    storedFlowers += roses[0];
                    storedFlowers += lilies[lilies.Count - 1];
                    roses.RemoveAt(0);
                    lilies.RemoveAt(lilies.Count - 1);
                }
            }

            if (storedFlowers >= 15)
            {
                wreaths += storedFlowers / 15;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
