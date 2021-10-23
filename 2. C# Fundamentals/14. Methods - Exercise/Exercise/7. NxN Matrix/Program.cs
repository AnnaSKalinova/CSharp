using System;

namespace _7._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintMatrix(n);
        }

        static void PrintLine(int x)
        {
            for (int i = 0; i < x; i++)
            {
                Console.Write(x + " ");
            }
        }

        static void PrintMatrix(int x)
        {
            for (int i = 0; i < x; i++)
            {
                PrintLine(x);
                Console.WriteLine();
            }
        }
    }
}
