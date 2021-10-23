using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxCounter = 1;
            int maxNum = 0;
            int counter = 1;
            int number = 0;

            for (int i = inputArr.Length - 1; i >= 1; i--)
            {
                if (inputArr[i] == inputArr[i - 1])
                {
                    counter++;
                    number = inputArr[i];
                }
                else
                {
                    counter = 1;
                }
                if (counter >= maxCounter)
                {
                    maxCounter = counter;
                    maxNum = number;
                }
            }
            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write(maxNum + " ");
            }
        }
    }
}
