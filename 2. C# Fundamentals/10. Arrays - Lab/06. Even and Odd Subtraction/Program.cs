using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] % 2 == 0)
                {
                    evenSum += inputArr[i];
                }
                else
                {
                    oddSum += inputArr[i];
                }
            }

            Console.WriteLine(evenSum - oddSum);
        }
    }
}
