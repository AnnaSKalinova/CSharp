using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            int[] firstArr = new int[countOfLines];
            int[] secondArr = new int[countOfLines];

            for (int i = 0; i < countOfLines; i++)
            {
                int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArr[i] = inputArr[0];
                    secondArr[i] = inputArr[1];
                }
                else if(i % 2 == 1)
                {
                    firstArr[i] = inputArr[1];
                    secondArr[i] = inputArr[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstArr));
            Console.WriteLine(string.Join(" ", secondArr));
        }
    }
}
