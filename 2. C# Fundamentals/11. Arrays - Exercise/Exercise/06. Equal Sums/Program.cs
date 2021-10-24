using System;
using System.Linq;

namespace _6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < inputArr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                if (i == 0)
                {
                    leftSum = 0;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        leftSum += inputArr[j];
                    }
                }
                if (i == inputArr.Length - 1)
                {
                    rightSum = 0;
                }
                else
                {
                    for (int k = i + 1; k < inputArr.Length; k++)
                    {
                        rightSum += inputArr[k];
                    }
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
