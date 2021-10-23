using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            CharsInRange(start, end);
        }

        static void CharsInRange(char a, char b)
        {
            if ((int)a > (int)b)
            {
                for (char i = (char)(b + 1); i < a; i++)
                {
                    Console.Write(i + " ");
                }
            }
            else
            {
                for (char i = (char)(a + 1); i < b; i++)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
