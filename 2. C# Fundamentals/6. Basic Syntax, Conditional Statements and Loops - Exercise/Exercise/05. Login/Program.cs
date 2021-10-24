using System;

namespace _5._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Empty;
            int counter = 1;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            string input = Console.ReadLine();

            while (input != password)
            {
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    input = Console.ReadLine();
                    counter++;
                }
            }
            if (counter < 4)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
