using System;

namespace _07.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            char operators = char.Parse(Console.ReadLine());

            double result = 0.0;

            switch (operators)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
                case '%':
                    result = num1 % num2;
                    break;
                default:
                    break;
            }
            if (num2 == 0)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
            else if (operators == '+' || operators == '-' || operators == '*')
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{num1} {operators} {num2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} {operators} {num2} = {result} - odd");
                }
            }
            else if (operators == '/')
            {
                Console.WriteLine($"{num1} / {num2} = {result:F2}");
            }
            else if (operators == '%')
            {
                Console.WriteLine($"{num1} % {num2} = {result}");
            }
        }
    }
}
