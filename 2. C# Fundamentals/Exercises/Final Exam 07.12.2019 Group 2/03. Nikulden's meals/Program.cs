using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split('-').ToArray();

            var mealsList = new Dictionary<string, List<string>>();
            var unlikedMeals = 0;

            while (!command.Contains("Stop"))
            {
                var guest = command[1];
                var currentMeal = command[2];

                switch (command[0])
                {
                    case "Like":
                        if (!mealsList.ContainsKey(guest))
                        {
                            mealsList.Add(guest, new List<string>());
                            mealsList[guest].Add(currentMeal);
                        }
                        else
                        {
                            if (!mealsList[guest].Contains(currentMeal))
                            {
                                mealsList[guest].Add(currentMeal);
                            }
                        }
                        break;
                    case "Unlike":
                        if (!mealsList.ContainsKey(guest))
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                        }
                        else if (!mealsList[guest].Contains(currentMeal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {currentMeal} in his/her collection.");
                        }
                        else
                        {
                            unlikedMeals++;
                            mealsList[guest].Remove(currentMeal);
                            Console.WriteLine($"{guest} doesn't like the {currentMeal}.");
                        }
                        break;
                }

                command = Console.ReadLine().Split('-').ToArray();
            }

            foreach (var guests in mealsList
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.Write($"{guests.Key}: ");
                Console.WriteLine(string.Join(", ", guests.Value));
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
