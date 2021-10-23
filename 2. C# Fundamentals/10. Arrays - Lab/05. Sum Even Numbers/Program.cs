using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] % 2 == 0)
                {
                    sum += inputArr[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
