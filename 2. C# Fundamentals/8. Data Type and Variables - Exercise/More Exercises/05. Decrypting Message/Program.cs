using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int countOfLines = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < countOfLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                message += (char)(letter + key);
            }
            Console.WriteLine(message);
        }
    }
}
