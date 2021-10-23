using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var dict = new SortedDictionary<double, int>();

            foreach (var element in input)
            {
                if (!dict.ContainsKey(element))
                {
                    dict.Add(element, 1);
                }
                else
                {
                    dict[element]++;
                }
            }

            foreach (var number in dict)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
