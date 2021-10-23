using System;

namespace _04.Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int currentNum = 1;

            //for (int i = 1; i <= num; i = 2 * i + 1)
            //{
            //    Console.WriteLine(i);
            //}

            while (currentNum <= num)
            {
                Console.WriteLine(currentNum);
                currentNum = 2 * currentNum + 1;
            }
        }
    }
}
