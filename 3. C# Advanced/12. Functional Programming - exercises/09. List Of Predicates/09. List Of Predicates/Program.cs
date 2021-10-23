using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(string.Join(" ", GetDivisibleNumbers(endOfRange, dividers)));
        }

        static List<int> GetDivisibleNumbers(int n, List<int> dividers)
        {
            var output = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool isDivisible = false;
                Func<int, bool> filter = x => i % x == 0;

                foreach (var currentDivider in dividers)
                {
                    if (filter(currentDivider))
                    {
                        isDivisible = true;
                    }
                    else
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    output.Add(i);
                }
            }
            return output;
        }
    }
}
