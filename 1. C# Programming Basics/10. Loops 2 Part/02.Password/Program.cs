using System;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = Console.ReadLine();

            string inputPassword = Console.ReadLine();
            while (password != inputPassword)
            {
                inputPassword = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {userName}!");
        }
    }
}
