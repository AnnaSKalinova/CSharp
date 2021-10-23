using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                switch (command[0])
                {
                    case 1:
                        stack.Push(command[1]);
                        break;
                    case 2:
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
