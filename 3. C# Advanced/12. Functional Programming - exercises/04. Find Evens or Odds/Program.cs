using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int start = bounds[0];
            int end = bounds[1];
            var command = Console.ReadLine();

            Predicate<int> predicate = null; ;

            switch (command)
            {
                case "odd":
                    predicate = x => x % 2 != 0;
                    break;
                case "even":
                    predicate = x => x % 2 == 0;
                    break;
            }

            PrintNums(start, end, predicate);

            static void PrintNums(int start, int end, Predicate<int> predicate)
            {
                var queue = new Queue<int>();

                for (int i = start; i <= end; i++)
                {
                    if (predicate(i))
                    {
                        queue.Enqueue(i);
                    }
                }
                Console.WriteLine(string.Join(" ", queue));
            }
        }
    }
}
