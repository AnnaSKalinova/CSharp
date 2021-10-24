using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var playerPool = new Dictionary<string, Dictionary<string, int>>();
            
            int lessSkill = 0;

            while (!input.Contains("Season end"))
            {
                if (input.Contains(" -> "))
                {
                    string[] tokens = input.Split(" -> ").ToArray();

                    string player = tokens[0];
                    string position = tokens[1];
                    int skill = int.Parse(tokens[2]);

                    if (!playerPool.ContainsKey(player))
                    {
                        playerPool.Add(player, new Dictionary<string, int>());
                    }
                    if (!playerPool[player].ContainsKey(position))
                    {
                        playerPool[player].Add(position, skill);
                    }
                    else
                    {
                        if (playerPool[player][position] < skill)
                        {
                            playerPool[player][position] = skill;
                        }
                    }

                }
                else if (input.Contains(" vs "))
                {
                    string[] tokens = input.Split(" vs ").ToArray();

                    string firstPlayer = tokens[0];
                    string secondPlayer = tokens[1];

                    if (!(playerPool.ContainsKey(firstPlayer) && playerPool.ContainsKey(secondPlayer)))
                    {
                        break;
                    }

                    foreach (var firstPosition in playerPool[firstPlayer])
                    {
                        foreach (var secondPosition in playerPool[secondPlayer])
                        {
                            if (firstPosition.Key == secondPosition.Key)
                            {
                                if (firstPosition.Value > secondPosition.Value)
                                {
                                    playerPool.Remove(secondPlayer);

                                }
                                else if (firstPosition.Value < secondPosition.Value)
                                {
                                    playerPool.Remove(firstPlayer);
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var playerTotal = new Dictionary<string, int>();

            foreach (var kvp in playerPool)
            {
                playerTotal.Add(kvp.Key, kvp.Value.Values.Sum());
            }

            foreach (var player in playerTotal
                .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");

                foreach (var players in playerPool.Values)
                {
                    Console.WriteLine($" - {players.Keys} <::> {players.Values}");
                }
            }
        }
            
    }
}
