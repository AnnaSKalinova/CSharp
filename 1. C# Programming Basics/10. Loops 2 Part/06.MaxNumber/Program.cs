using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNum = int.Parse(Console.ReadLine());

            int currentNum = 1;
            int maxNum = int.MinValue;

            while (currentNum <= countNum)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > maxNum)
                {
                    maxNum = num;
                }
                currentNum++;
            }
            Console.WriteLine(maxNum);
        }
    }
}
