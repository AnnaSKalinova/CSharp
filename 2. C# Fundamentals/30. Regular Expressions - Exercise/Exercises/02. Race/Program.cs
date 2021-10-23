using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ").ToArray();
            string info = Console.ReadLine();

            var dictOfRacers = new Dictionary<string, int>();
            string patternForNames = "[A-Za-z]";
            string patternForDistance = "[0-9]";

            while (info != "end of race")
            {
                Regex regForName = new Regex(patternForNames);
                Regex regForDistance = new Regex(patternForDistance);
                MatchCollection matchesForNames = regForName.Matches(info);
                MatchCollection matchesForDistance = regForDistance.Matches(info);
                string name = string.Empty;
                int distance = 0;

                foreach (Match match in matchesForNames)
                {
                    name += match.Value;
                }
                foreach (Match distanceMatch in matchesForDistance)
                {
                    distance += int.Parse(distanceMatch.Value);
                }

                if (!dictOfRacers.ContainsKey(name))
                {
                    dictOfRacers.Add(name, distance);
                }
                else
                {
                    dictOfRacers[name] += distance;
                }

                info = Console.ReadLine();
            }

            int counter = 1;

            foreach (var racer in dictOfRacers.OrderByDescending(x => x.Value))
            {
                if (participants.Contains(racer.Key))
                {
                    if (counter == 1)
                    {
                        Console.WriteLine($"1st place: {racer.Key}");
                    }
                    else if (counter == 2)
                    {
                        Console.WriteLine($"2nd place: {racer.Key}");
                    }
                    else if (counter == 3)
                    {
                        Console.WriteLine($"3rd place: {racer.Key}");
                    }

                    counter++;
                }
                
            }
        }
    }
}
