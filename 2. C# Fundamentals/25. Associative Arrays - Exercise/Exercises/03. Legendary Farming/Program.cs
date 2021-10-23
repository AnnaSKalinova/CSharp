using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine().Split().ToArray();

            var legendaryItems = new Dictionary<string, int>();
            legendaryItems.Add("shards", 0);
            legendaryItems.Add("fragments", 0);
            legendaryItems.Add("motes", 0);

            var junk = new Dictionary<string, int>();
            bool isWinner = false;
            string winner = string.Empty;

            while (true)
            {
                for (int i = 0; i < inputArr.Length - 1; i += 2)
                {
                    int quantity = int.Parse(inputArr[i]);
                    string material = inputArr[i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        legendaryItems[material] += quantity;

                        if (legendaryItems[material] >= 250)
                        {
                            switch (material)
                            {
                                case "shards":
                                    winner = "Shadowmourne";
                                    break;
                                case "fragments":
                                    winner = "Valanyr";
                                    break;
                                case "motes":
                                    winner = "Dragonwrath";
                                    break;
                            }
                            legendaryItems[material] -= 250;

                            isWinner = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += quantity;
                        }
                        else
                        {
                            junk.Add(material, quantity);
                        }
                    }
                }

                if (isWinner)
                {
                    break;
                }

                inputArr = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"{winner} obtained!");

            foreach (var element in legendaryItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToArray())
            {

                Console.WriteLine($"{element.Key}: {element.Value}");
            }
            foreach (var element in junk.OrderBy(x => x.Key).ToArray())
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
        }
    }
}
