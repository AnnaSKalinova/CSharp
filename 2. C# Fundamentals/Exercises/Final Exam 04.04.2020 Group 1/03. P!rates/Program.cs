using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _03._Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("||");

            var citiesPopulation = new Dictionary<string, int>();
            var citiesGold = new Dictionary<string, int>();

            while (input[0] != "Sail")
            {
                string city = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);

                if (!citiesPopulation.ContainsKey(city))
                {
                    citiesPopulation.Add(city, population);
                }
                else
                {
                    citiesPopulation[city] += population;
                }
                if (!citiesGold.ContainsKey(city))
                {
                    citiesGold.Add(city, gold);
                }
                else
                {
                    citiesGold[city] += gold;
                }

                input = Console.ReadLine().Split("||");
            }

            string[] events = Console.ReadLine().Split("=>");

            while (events[0] != "End")
            {
                switch (events[0])
                {
                    case "Plunder":
                        string plunderedTown = events[1];
                        int plunderedPeople = int.Parse(events[2]);
                        int plunderedGold = int.Parse(events[3]);

                        if (citiesPopulation.ContainsKey(plunderedTown))
                        {
                            citiesPopulation[plunderedTown] -= plunderedPeople;
                        }
                        if (citiesGold.ContainsKey(plunderedTown))
                        {
                            citiesGold[plunderedTown] -= plunderedGold;
                        }

                        Console.WriteLine($"{plunderedTown} plundered! {plunderedGold} gold stolen, {plunderedPeople} citizens killed.");

                        if (citiesPopulation[plunderedTown] == 0 || citiesGold[plunderedTown] == 0)
                        {
                            citiesPopulation.Remove(plunderedTown);
                            citiesGold.Remove(plunderedTown);

                            Console.WriteLine($"{plunderedTown} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        string prosperTown = events[1];
                        int prosperGold = int.Parse(events[2]);

                        if (prosperGold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            break;
                        }
                        if (citiesGold.ContainsKey(prosperTown))
                        {
                            citiesGold[prosperTown] += prosperGold;
                        }

                        Console.WriteLine($"{prosperGold} gold added to the city treasury. {prosperTown} now has {citiesGold[prosperTown]} gold.");
                        break;
                }

                events = Console.ReadLine().Split("=>");
            }

            if (citiesPopulation.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesPopulation.Count} wealthy settlements to go to:");

                foreach (var town in citiesGold
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    if (citiesPopulation.ContainsKey(town.Key))
                    {
                        Console.WriteLine($"{town.Key} -> Population: {citiesPopulation[town.Key]} citizens, Gold: {town.Value} kg");
                    }
                }
            }
        }
    }
}
