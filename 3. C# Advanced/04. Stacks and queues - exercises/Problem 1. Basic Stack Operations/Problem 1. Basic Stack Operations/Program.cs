using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input[0]; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
