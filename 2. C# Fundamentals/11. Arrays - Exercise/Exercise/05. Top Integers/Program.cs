using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int i = 0; i < inputArr.Length - 1; i++)
            {
                bool isTopInteger = false;
                for (int j = i + 1; j < inputArr.Length; j++)
                {
                    if (inputArr[i] > inputArr[j])
                    {
                        isTopInteger = true;
                    }
                    else
                    {
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    Console.Write(inputArr[i] + " ");
                }
            }
            Console.WriteLine(inputArr[inputArr.Length - 1]);
        }
    }
}
