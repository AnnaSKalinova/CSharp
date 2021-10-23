using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var bombCasings = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var bombs = new Dictionary<string, int>();
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);
            var daturaBomb = 40;
            var cherryBomb = 60;
            var smokeDecoyBomb = 120;
            bool isSuccessful = false;

            while (bombCasings.Any() && bombEffects.Any())
            {
                var currSum = bombEffects[0] + bombCasings[bombCasings.Count - 1];
                if (currSum == daturaBomb || currSum == cherryBomb || currSum == smokeDecoyBomb)
                {
                    switch (currSum)
                    {
                        case 40:
                            bombs["Datura Bombs"]++;
                            break;
                        case 60:
                            bombs["Cherry Bombs"]++;
                            break;
                        case 120:
                            bombs["Smoke Decoy Bombs"]++;
                            break;

                    }
                    bombEffects.RemoveAt(0);
                    bombCasings.RemoveAt(bombCasings.Count - 1);

                }
                else
                {
                    bombCasings[bombCasings.Count - 1] -= 5;
                }

                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    isSuccessful = true;
                    break;
                }
            }

            if (isSuccessful)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
