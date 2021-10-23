using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            TopNumber(number);
        }

        static void TopNumber(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                if (DivisibleBy8(i) && IsAtLeastOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool DivisibleBy8(int x)
        {
            int sumOfDigits = 0;
            while (x > 0)
            {
                sumOfDigits += x % 10;
                x /= 10;
            }

            bool isDivisibleBy8 = false;
            if (sumOfDigits % 8 == 0)
            {
                isDivisibleBy8 = true;
            }
            return isDivisibleBy8;
        }

        static bool IsAtLeastOneOddDigit(int x)
        {
            bool isAtLeastOneOddDigit = false;
            for (int i = 0; i < x.ToString().Length; i ++)
            {
                if (x.ToString()[i] % 2 != 0)
                {
                    isAtLeastOneOddDigit = true;
                }
            }
            return isAtLeastOneOddDigit;
        }
    }
}
