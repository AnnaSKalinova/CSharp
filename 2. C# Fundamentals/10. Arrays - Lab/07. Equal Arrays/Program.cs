using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumOfElements = 0;
            int index = -1;

            for (int i = 0; i < firstArr.Length; i++)
            {
                index++;
                if (firstArr[i] == secondArr[i])
                {
                    sumOfElements += firstArr[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
                    return;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sumOfElements}");
        }
    }
}
