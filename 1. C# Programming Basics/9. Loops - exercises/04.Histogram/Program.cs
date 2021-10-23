using System;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double countOfNums = double.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 0; i < countOfNums; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    p1++;
                }
                else if (num >= 200 && num <= 399)
                {
                    p2++;
                }
                else if (num >= 400 && num <= 599)
                {
                    p3++;
                }
                else if (num >= 600 && num <= 799)
                {
                    p4++;
                }
                else if (num >= 800)
                {
                    p5++;
                }
            }
            Console.WriteLine($"{(p1 / countOfNums * 100):f2}%");
            Console.WriteLine($"{(p2 / countOfNums * 100):f2}%");
            Console.WriteLine($"{(p3 / countOfNums * 100):f2}%");
            Console.WriteLine($"{(p4 / countOfNums * 100):f2}%");
            Console.WriteLine($"{(p5 / countOfNums * 100):f2}%");
        }
    }
}
