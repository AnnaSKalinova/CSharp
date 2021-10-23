using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("../../../words.txt");
            var lines = File.ReadAllLines("../../../text.txt");

            var actualResult = new string[words.Count()];
            var expectedResult = new string[words.Count()];

            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                dict.Add(word, 0);
            }

            foreach (var line in lines)
            {
                var textLine = line
                    .ToLower()
                    .Split(new char[] { ' ', '-', '.', ',', '!', '?' });

                foreach (var matchingWord in textLine)
                {
                    if (dict.ContainsKey(matchingWord))
                    {
                        dict[matchingWord]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach ((string word, int count) in dict)
            {
                sb.AppendLine($"{word} - {count}");
            }

            File.WriteAllText("../../../actualResults.txt", sb.ToString());

            dict = dict
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);
            sb.Clear();
            foreach ((string word, int count) in dict)
            {
                sb.AppendLine($"{word} - {count}");
            }

            File.WriteAllText("../../../expectedResult.txt", sb.ToString());
        }
    }
}
