using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var places = Console.ReadLine();

            var pattern = @"(=|\/)([A-Z][A-Za-z]{2,})(\1)";
            Regex regex = new Regex(pattern);
            var destinations = new List<string>();
            var travelPoints = 0;

            foreach (Match match in Regex.Matches(places, pattern))
            {
                if (match.Success)
                {
                    travelPoints += match.Groups[2].Value.Length;
                    destinations.Add(match.Groups[2].Value);
                }
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
