using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            var heroesHP = new Dictionary<string, int>();
            var heroesMP = new Dictionary<string, int>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroesInfo = Console.ReadLine().Split().ToArray();

                string heroName = heroesInfo[0];
                int hitPoints = int.Parse(heroesInfo[1]);
                int manaPoints = int.Parse(heroesInfo[2]);

                if (!heroesHP.ContainsKey(heroName))
                {
                    heroesHP.Add(heroName, hitPoints);
                    heroesMP.Add(heroName, manaPoints);
                }
            }

            string[] command = Console.ReadLine().Split(" - ").ToArray();

            while (!command.Contains("End"))
            {
                switch (command[0])
                {
                    case "CastSpell":
                        string heroName = command[1];
                        int mpNeeded = int.Parse(command[2]);
                        string spellName = command[3];

                        if (heroesMP[heroName] >= mpNeeded)
                        {
                            heroesMP[heroName] -= mpNeeded;
                            int manaPointsLeft = heroesMP[heroName];
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {manaPointsLeft} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        heroName = command[1];
                        int damage = int.Parse(command[2]);
                        string attacker = command[3];
                        heroesHP[heroName] -= damage;

                        if (heroesHP[heroName] <= 0)
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroesHP.Remove(heroName);
                        }
                        else
                        {
                            int currentHP = heroesHP[heroName];
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHP} HP left!");
                        }
                        break;
                    case "Recharge":
                        heroName = command[1];
                        int amount = int.Parse(command[2]);

                        if (heroesMP[heroName] + amount > 200)
                        {
                            amount = 200 - heroesMP[heroName];
                            heroesMP[heroName] = 200;
                        }
                        else
                        {
                            heroesMP[heroName] += amount;
                        }

                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                        break;
                    case "Heal":
                        heroName = command[1];
                        amount = int.Parse(command[2]);

                        if (heroesHP[heroName] + amount > 100)
                        {
                            amount = 100 - heroesHP[heroName];
                            heroesHP[heroName] = 100;
                        }
                        else
                        {
                            heroesHP[heroName] += amount;
                        }

                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                        break;
                }

                command = Console.ReadLine().Split(" - ").ToArray();
            }

            foreach (var hp in heroesHP
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x)
                .ToArray())
            {
                Console.WriteLine(hp.Key);
                Console.WriteLine($"  HP: {hp.Value}");
                foreach (var mp in heroesMP)
                {
                    if (mp.Key == hp.Key)
                    {
                        Console.WriteLine($"  MP: {mp.Value}");
                    }
                }
            }
        }
    }
}
