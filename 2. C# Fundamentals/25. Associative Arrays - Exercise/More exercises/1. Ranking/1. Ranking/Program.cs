using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _1._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] contests = Console.ReadLine().Split(':').ToArray();

            var dictOfContests = new Dictionary<string, string>();
            var totalPointsOfCandidates = new SortedDictionary<string, int>();

            while (!contests.Contains("end of contests"))
            {
                string contest = contests[0];
                string passwordForContest = contests[1];

                if (!dictOfContests.ContainsKey(contest))
                {
                    dictOfContests.Add(contest, passwordForContest);
                }

                contests = Console.ReadLine().Split(':').ToArray();
            }

            string[] submissions = Console.ReadLine().Split("=>").ToArray();
            var contentsInfo = new Dictionary<string, Dictionary<string, int>>();

            while (!submissions.Contains("end of submissions"))
            {
                string contest = submissions[0];
                string password = submissions[1];
                string username = submissions[2];
                int points = int.Parse(submissions[3]);

                if (dictOfContests.ContainsKey(contest))
                {
                    if (dictOfContests[contest] == password)
                    {
                        if (!contentsInfo.ContainsKey(username))
                        {
                            contentsInfo.Add(username, new Dictionary<string, int>());
                        }
                        if (!contentsInfo[username].ContainsKey(contest))
                        {
                            contentsInfo[username].Add(contest, points);
                        }
                        else
                        {
                            if (contentsInfo[username][contest] < points)
                            {
                                contentsInfo[username][contest] = points;
                            }
                        }
                        if (!totalPointsOfCandidates.ContainsKey(username))
                        {
                            totalPointsOfCandidates.Add(username, points);
                        }
                        if (totalPointsOfCandidates[username] < points)
                        {
                            totalPointsOfCandidates[username] = points;
                        }
                    }
                }

                submissions = Console.ReadLine().Split("=>").ToArray();
            }

            var reversedTotalPoints = totalPointsOfCandidates.Reverse();

            var first = reversedTotalPoints.First();
            Console.WriteLine($"Best candidate is {first.Key} with total {first.Value} points.");

            Console.WriteLine("Ranking: ");

            foreach (var user in contentsInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var course in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
