using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isPasswordValid = false;

            if (!(IsBetween6And10Chars(password)))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (IsNotOnlyNumsAndDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!(IsAtLeast2Digits(password)))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (IsBetween6And10Chars(password) && !IsNotOnlyNumsAndDigits(password) && IsAtLeast2Digits(password))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsBetween6And10Chars(string text)
        {
            int counter = 0;
            bool isBetween6And10Chars = false;

            for (int i = 0; i < text.Length; i++)
            {
                counter++;
            }

            if (counter >= 6 && counter <= 10)
            {
                isBetween6And10Chars = true;
            }

            return isBetween6And10Chars;
        }

        static bool IsNotOnlyNumsAndDigits(string text)
        {
            bool isNotOnlyNumsAndDigits = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (!(text[i] >= '0' && text[i] <= '9' || text[i] >= 'a' && text[i] <= 'z' || text[i] >= 'A' && text[i] <= 'Z'))
                {
                    isNotOnlyNumsAndDigits = true;
                }
            }

            return isNotOnlyNumsAndDigits;
        }

        static bool IsAtLeast2Digits(string text)
        {
            int counter = 0;
            bool isAtLeast2Digits = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '0' && text[i] <= '9')
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                isAtLeast2Digits = true;
            }

            return isAtLeast2Digits;
        }
    }
}
