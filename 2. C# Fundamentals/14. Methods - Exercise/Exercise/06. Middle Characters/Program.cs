using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleCharacter(input);
        }

        static void MiddleCharacter(string text)
        {
            string resultChar = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (text.Length % 2 == 0)
                {
                    resultChar = (text[text.Length / 2 - 1]).ToString() + (text[text.Length / 2]).ToString();
                }
                else
                {
                    resultChar = (text[text.Length / 2]).ToString();
                }
            }
            Console.WriteLine(resultChar);
        }
    }
}
