using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            int currentSumOfClothes = 0;
            int racksCounter = 1;

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (currentSumOfClothes + stack.Peek() > capacity)
                {
                    racksCounter++;
                    currentSumOfClothes = 0;
                }
                currentSumOfClothes += stack.Peek();
                stack.Pop();
            }
            Console.WriteLine(racksCounter);
        }
    }
}
