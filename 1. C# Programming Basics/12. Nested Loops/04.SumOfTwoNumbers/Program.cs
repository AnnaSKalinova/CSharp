using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int begginingNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());
            int magicalNum = int.Parse(Console.ReadLine());

            int counter = 0;
            bool isMagic = false;
            int i = 0;
            int j = 0;

            for (i = begginingNum; i <= endingNum; i++)
            {
                for (j = begginingNum; j <= endingNum; j++)
                {
                    counter++;
                    if (i + j == magicalNum)
                    {
                        isMagic = true;
                        break;
                    }
                }
                if (isMagic)
                {
                    break;
                }
            }

            if (isMagic)
            {
                Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicalNum})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicalNum}");
            }
        }
    }
}
