using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var username in input)
            {
                if (IsValidUsername(username))
                {
                    sb.Append((username) + " ");
                }
            }

            string[] validPasswords = sb.ToString().Split(" ");

            Console.WriteLine(string.Join(Environment.NewLine, validPasswords));
        }

        static bool IsValidUsername(string word)
        {
            bool isValidPassword = false;
            if (word.Length >= 3 && word.Length <= 16)
            {
                foreach (char letter in word)
                {
                    if (char.IsDigit(letter) || char.IsLetter(letter) || letter == '-' || letter == '_')
                    {
                        isValidPassword = true;
                    }
                    else
                    {
                        isValidPassword = false;
                        return false;
                    }
                }
            }
            return isValidPassword;
        }
    }
}
