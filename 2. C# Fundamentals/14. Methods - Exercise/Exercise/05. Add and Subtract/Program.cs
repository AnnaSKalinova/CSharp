using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = Subtracts(firstNum, secondNum, thirdNum);

            Console.WriteLine(result);
        }

        static int Sum(int x, int y)
        {
            int result = x + y;
            return result;
        }

        static int Subtracts(int x, int y, int z)
        {
            int sum = Sum(x, y);
            int result = sum - z;
            return result;
        }
    }
}
