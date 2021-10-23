using System;
using System.Linq;

namespace _02._From_Left_to_the_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {
                long[] inputArr = Console.ReadLine().Split().Select(long.Parse).ToArray();

                long sumOfDigits = 0;
                long maxNum = 0;

                if (inputArr[0] > inputArr[1])
                {
                    maxNum = inputArr[0];
                }
                else
                {
                    maxNum = inputArr[1];
                }
                while (maxNum != 0)
                {
                    sumOfDigits += maxNum % 10;
                    maxNum /= 10;
                }
                Console.WriteLine(Math.Abs(sumOfDigits));
            }
        }
    }
}
