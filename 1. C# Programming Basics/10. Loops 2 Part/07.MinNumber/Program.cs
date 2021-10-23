using System;

namespace _07.MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNums = int.Parse(Console.ReadLine());

            int minNum = int.MaxValue;
            int currentNum = 1;

            while (currentNum <= countNums)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < minNum)
                {
                    minNum = num;
                }
                currentNum++;
            }
            Console.WriteLine(minNum);
        }
    }
}
