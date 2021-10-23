using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (inputArr.Length > 1)
            {
                int[] condensedArray = new int[inputArr.Length - 1];
                for (int i = 0; i < condensedArray.Length; i++)
                {
                    condensedArray[i] = inputArr[i] + inputArr[i + 1];
                }
                inputArr = condensedArray;
            }

            Console.WriteLine(inputArr[0]);
        }
    }
}
