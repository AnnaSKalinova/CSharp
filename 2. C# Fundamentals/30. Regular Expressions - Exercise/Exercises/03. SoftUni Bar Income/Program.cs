using System;
using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"%([A-Z][a-z]+)%.*<(\w+)>.*?\|(\d+)\|\w*?(\d+.*[0-9]*)\$";
            double totalIncome = 0.0;
            double totalPrice = 0.0;

            while (input != "end of shift")
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    totalPrice = double.Parse(match.Groups[3].Value) * double.Parse(match.Groups[4].Value);
                    Console.WriteLine($"{match.Groups[1].Value}: {match.Groups[2].Value} - {totalPrice:F2}");
                    totalIncome += totalPrice;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
