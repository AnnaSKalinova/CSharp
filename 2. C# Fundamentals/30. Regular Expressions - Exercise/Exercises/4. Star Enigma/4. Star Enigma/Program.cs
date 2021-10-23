using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < countOfLines; i++)
            {
                int countOfLetters = 0;
                StringBuilder sb = new StringBuilder();

                string message = Console.ReadLine();

                for (int j = 0; j < message.Length; j++)
                {
                    switch (message[j])
                    {
                        case 'S':
                        case 's':
                        case 'T':
                        case 't':
                        case 'A':
                        case 'a':
                        case 'R':
                        case 'r':
                            countOfLetters++;
                            break;
                    }
                }

                for (int k = 0; k < message.Length; k++)
                {
                    char oldLetter = message[k];
                    int oldLettersCode = (int)message[k];
                    int newLettersCode = oldLettersCode - countOfLetters;
                    char newLetter = (char)newLettersCode;
                    sb.Append(newLetter);
                }

                string decryptedMessage = sb.ToString();

                string pattern = @"@([A-Za-z]+)[^@\-!:>]*:([0-9]+)[^@\-!:>]*!(A|D)![^@\-!:>]*->([0-9]+)";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(decryptedMessage);

                if (match.Success)
                {
                    string planetName = match.Groups[1].Value;
                    int population = int.Parse(match.Groups[2].Value);
                    char attackType = char.Parse(match.Groups[3].Value);
                    int sodierCount = int.Parse(match.Groups[4].Value);

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            
            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: { destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
