using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNums = int.Parse(Console.ReadLine());
            int[] inpurArr = new int[countOfNums];

            for (int i = 0; i < countOfNums; i++)
            {
                inpurArr[i] = int.Parse(Console.ReadLine());
            }

            for (int j = inpurArr.Length - 1; j >= 0; j--)
            {
                Console.Write(inpurArr[j] + " ");
            }
        }
    }
}
