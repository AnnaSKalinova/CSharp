using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            int countOfSuccessfulRegistrations = 0;

            for (int i = 0; i < countOfLines; i++)
            {
                string registration = Console.ReadLine();
                string pattern = @"U\$([A-Z][a-z]{2,})U\$P@\$([A-Za-z]{5,}[0-9]+)P@\$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(registration);

                if (match.Success)
                {
                    countOfSuccessfulRegistrations++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups[1].Value}, Password: {match.Groups[2].Value}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {countOfSuccessfulRegistrations}");
        }
    }
}
