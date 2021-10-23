using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < input[0]; i++)
            {
                queue.Enqueue(elements[i]);
            }
            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
