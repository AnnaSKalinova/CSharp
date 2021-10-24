using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            BigInteger coolThreshold = 1;

            foreach (char character in input)
            {
                if (char.IsDigit(character))
                {
                    coolThreshold *= int.Parse(character.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            string pattern = @"(::|\*\*)([A-Z][a-z]{2,})(\1)";
            Regex regex = new Regex(pattern);
            int countOfEmoji = 0;
            List<string> emojis = new List<string>();

            foreach (Match match in Regex.Matches(input, pattern))
            {
                if (match.Success)
                {
                    countOfEmoji++;
                    int coolness = 0;

                    for (int i = 0; i < match.Groups[2].Value.Length; i++)
                    {
                        coolness += (int)match.Groups[2].Value[i];
                    }

                    if (coolness > coolThreshold)
                    {
                        emojis.Add(match.Value);
                    }
                }
            }

            Console.WriteLine($"{countOfEmoji} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, emojis));
        }
    }
}
