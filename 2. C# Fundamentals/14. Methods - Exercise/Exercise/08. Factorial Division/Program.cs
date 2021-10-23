using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            long firstNumFactorial = CalculateFactorial(firstNum);
            long secondNumFactorial = CalculateFactorial(secondNum);

            double result = Division(firstNumFactorial, secondNumFactorial);

            Console.WriteLine($"{result:F2}");
        }

        static long CalculateFactorial(int x)
        {
            long factorial = 1;
            for (int i = 1; i <= x; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        static double Division(double x, double y)
        {
            double result = x / y;
            return result;
        }
    }
}
