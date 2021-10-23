using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('-').ToArray();

            var dict = new Dictionary<string, int>();
            var languageSubmissionsDict = new Dictionary<string, int>();

            while (!input.Contains("exam finished"))
            {
                string username = input[0];

                if (input.Contains("banned"))
                {
                    if (dict.ContainsKey(username))
                    {
                        dict.Remove(username);
                    }

                    input = Console.ReadLine().Split('-').ToArray();
                    break;
                }
                
                string language = input[1];
                int points = int.Parse(input[2]);

                if (!dict.ContainsKey(username))
                {
                    dict.Add(username, points);
                }
                else
                {
                    if (dict[username] < points)
                    {
                        dict[username] = points;
                    }
                }
                if (!languageSubmissionsDict.ContainsKey(language))
                {
                    languageSubmissionsDict.Add(language, 1);
                }
                else
                {
                    languageSubmissionsDict[language]++;
                }

                input = Console.ReadLine().Split('-').ToArray();
            }

            Console.WriteLine("Results:");
            foreach (var user in dict
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var language in languageSubmissionsDict
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
