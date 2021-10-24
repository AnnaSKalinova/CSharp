using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCommand = Console.ReadLine().Split(" -> ").ToArray();

            var contestDict = new Dictionary<string, Dictionary<string, int>>();
            var totalPointsDict = new Dictionary<string, int>();
            int lessPoints = 0;

            while (!inputCommand.Contains("no more time"))
            {
                string username = inputCommand[0];
                string contest = inputCommand[1];
                int points = int.Parse(inputCommand[2]);

                

                if (!contestDict.ContainsKey(contest))
                {
                    contestDict.Add(contest, new Dictionary<string, int>());
                }
                if (!contestDict[contest].ContainsKey(username))
                {
                    contestDict[contest].Add(username, points);
                }
                else
                {
                    if (contestDict[contest][username] < points)
                    {
                        lessPoints = contestDict[contest][username];
                        contestDict[contest][username] = points;
                    }
                }
                if (!totalPointsDict.ContainsKey(username))
                {
                    totalPointsDict.Add(username, points);
                }
                else
                {
                    totalPointsDict[username] -= lessPoints;
                    totalPointsDict[username] += points;
                }

                lessPoints = 0;
                inputCommand = Console.ReadLine().Split(" -> ").ToArray();
            }

            foreach (var contest in contestDict)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                int position = 1;

                foreach (var user in contest.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{position}. {user.Key} <::> {user.Value}");
                    position++;
                }
            }

            Console.WriteLine("Individual standings:");
            int counter = 1;

            foreach (var user in totalPointsDict
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter}. {user.Key} -> {user.Value}");
                counter++;
            }
        }
    }
}
