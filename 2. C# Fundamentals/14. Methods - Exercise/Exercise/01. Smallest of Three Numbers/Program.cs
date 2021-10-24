using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());
                int thirdNum = int.Parse(Console.ReadLine());

                SmallestNum(firstNum, secondNum, thirdNum);
            }

            static void SmallestNum(int a, int b, int c)
            {
                if (a <= b & a <= c)
                {
                    Console.WriteLine(a);
                }
                else if (b < a && b <= c)
                {
                    Console.WriteLine(b);
                }
                else if (c < a && c < b)
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
