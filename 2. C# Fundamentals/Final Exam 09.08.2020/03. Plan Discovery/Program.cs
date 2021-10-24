using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace _03._Plan_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfLines = int.Parse(Console.ReadLine());

            var ratingsDict = new Dictionary<string, List<double>>();

            var plantsDict = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < countOfLines; i++)
            {
                var plantInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var plant = plantInfo[0];
                var rarity = double.Parse(plantInfo[1]);

                if (!plantsDict.ContainsKey(plant))
                {
                    plantsDict.Add(plant, new Dictionary<string, double>());
                }

                if (!plantsDict[plant].ContainsKey("Rarity"))
                {
                    plantsDict[plant].Add("Rarity", rarity);
                }
                else
                {
                    plantsDict[plant]["Rarity"] = rarity;
                }
            }

            var command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (!command.Contains("Exhibition"))
            {
                var action = command[0];
                
                switch (action)
                {
                    case "Rate":
                        var tokens = command[1].Split(" - ").ToArray();
                        var plant = tokens[0];
                        var rating = double.Parse(tokens[1]);
                        
                        if (plantsDict.ContainsKey(plant))
                        {
                            if (!ratingsDict.ContainsKey(plant))
                            {
                                ratingsDict.Add(plant, new List<double>());
                            }
                            ratingsDict[plant].Add(rating);
                            var averageRating = ratingsDict[plant].Average();

                            if (!plantsDict[plant].ContainsKey("Rating"))
                            {
                                plantsDict[plant].Add("Rating", averageRating);
                            }
                            else
                            {
                                plantsDict[plant]["Rating"] = averageRating;
                            }
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        tokens = command[1].Split(" - ").ToArray();
                        plant = tokens[0];
                        var newRarity = double.Parse(tokens[1]);

                        if (plantsDict.ContainsKey(plant))
                        {
                            if (!plantsDict[plant].ContainsKey("Rarity"))
                            {
                                plantsDict[plant].Add("Rarity", newRarity);
                            }
                            else
                            {
                                plantsDict[plant]["Rarity"] = newRarity;
                            }
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        plant = command[1];
                        if (plantsDict.ContainsKey(plant))
                        {
                            if (plantsDict[plant].ContainsKey("Rating"))
                            {
                                plantsDict[plant]["Rating"] = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }

                command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plantsDict
                .OrderByDescending(x => x.Value["Rarity"])
                .ThenByDescending(x => x.Value["Rating"]))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value["Rarity"]}; Rating: {plant.Value["Rating"]:F2}");
            }
        }
    }
}
