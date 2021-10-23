using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotationsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotationsCount; i++)
            {
                int firstNum = inputArr[0];

                for (int j = 0; j < inputArr.Length - 1; j++)
                {
                    int currentNum = inputArr[j + 1];
                    inputArr[j] = currentNum;
                }
                inputArr[inputArr.Length - 1] = firstNum;
            }

            Console.WriteLine(string.Join(" ", inputArr));
        }
    }
}
