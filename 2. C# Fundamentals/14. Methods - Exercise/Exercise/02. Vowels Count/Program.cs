using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelsCounter = CountVowels(input);
            Console.WriteLine(vowelsCounter);
        }

        static int CountVowels(string text)
        {
            int countOfVowels = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case 'a':
                    case 'o':
                    case 'e':
                    case 'i':
                    case 'u':
                    case 'A':
                    case 'O':
                    case 'E':
                    case 'I':
                    case 'U':
                        countOfVowels++;
                        break;
                    default:
                        break;
                }
            }
            return countOfVowels;
        }
    }
}
