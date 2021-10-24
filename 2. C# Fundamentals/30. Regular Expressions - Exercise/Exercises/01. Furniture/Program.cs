using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> furnitureBought = new List<string>();
            double totalPrice = 0.0;

            while (input != "Purchase")
            {
                var pattern = @">>([A-Za-z]+)<<([0-9]+\.?[0-9]*)!([0-9]+)";
                Regex regex = new Regex(pattern);
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    furnitureBought.Add(match.Groups[1].Value);
                    totalPrice += double.Parse(match.Groups[2].Value) * double.Parse(match.Groups[3].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture: ");
            if (furnitureBought.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitureBought));
            }
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
