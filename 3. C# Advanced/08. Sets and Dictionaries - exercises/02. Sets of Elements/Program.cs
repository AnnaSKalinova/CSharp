using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = inputNums[0];
            int m = inputNums[1];

            HashSet<int> firstHashSet = new HashSet<int>();
            HashSet<int> secondHashSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                firstHashSet.Add(currNum);
            }
            for (int j = 0; j < m; j++)
            {
                int currNum = int.Parse(Console.ReadLine());
                secondHashSet.Add(currNum);
            }

            Console.WriteLine(string.Join(" ", firstHashSet.Intersect(secondHashSet)));
        }
    }
}
