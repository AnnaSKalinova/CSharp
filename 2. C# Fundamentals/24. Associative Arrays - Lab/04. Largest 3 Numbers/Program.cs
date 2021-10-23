using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] sortedNumbers = inputList.OrderByDescending(x => x).ToArray();

            if (sortedNumbers.Length < 3)
            {
                Console.WriteLine(string.Join(" ", sortedNumbers));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(sortedNumbers[i] + " ");
                }
            }
        }
    }
}
