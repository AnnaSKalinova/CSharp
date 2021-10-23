using System;

namespace _07.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNums = int.Parse(Console.ReadLine());
            int sumOfNums = 0;
            for (int i = 0; i < countOfNums; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sumOfNums += num;
            }
            Console.WriteLine(sumOfNums);
        }
    }
}
