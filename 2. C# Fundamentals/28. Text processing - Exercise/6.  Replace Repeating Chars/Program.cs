using System;
using System.Text;

namespace _6.__Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            char letterToAdd = ' ';

            for (int i = 0; i < text.Length; i++)
            {
                letterToAdd = text[i];

                if (i < text.Length - 1 && text[i] != text[i + 1])
                {
                    sb.Append(letterToAdd);
                }
                else if (i == text.Length - 1)
                {
                    sb.Append(letterToAdd);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
