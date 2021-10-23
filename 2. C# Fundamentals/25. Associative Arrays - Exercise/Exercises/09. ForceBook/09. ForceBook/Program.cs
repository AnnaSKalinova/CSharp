using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = Console.ReadLine();
            List<string> allUsers = new List<string>();

            var forceBook = new Dictionary<string, List<string>>();

            while (!inputCommand.Contains("Lumpawaroo"))
            {
                bool isInSide = false;

                if (inputCommand.Contains('|'))
                {
                    string[] splittedInput = inputCommand.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string forceSide = splittedInput[0];
                    string forceUser = splittedInput[1];
                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());
                    }
                    if (!forceBook[forceSide].Contains(forceUser) && !forceBook.Values.Any(x => x.Contains(forceUser)))
                    {
                        forceBook[forceSide].Add(forceUser);
                    }
                }
                else if (inputCommand.Contains("->"))
                {
                    string[] splittedInput = inputCommand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string forceSide = splittedInput[1];
                    string forceUser = splittedInput[0];
                    if (allUsers.Contains(forceUser))
                    {
                        string neededSide = string.Empty;

                        foreach (var key in forceBook.Keys)
                        {
                            if (forceBook[key].Contains(forceUser))
                            {
                                neededSide = key;
                                break;
                            }
                        }
                        forceBook[neededSide].Remove(forceUser);
                        forceBook[forceSide].Add(forceUser);

                    }
                    else if (forceBook.ContainsKey(forceSide) && !forceBook[forceSide].Contains(forceUser))
                    {
                        forceBook[forceSide].Add(forceUser);
                        allUsers.Add(forceUser);
                    }
                    else
                    {
                        forceBook.Add(forceSide, new List<string>() { forceUser });
                        allUsers.Add(forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                inputCommand = Console.ReadLine();
            }

            foreach (var elemnet in forceBook
                .OrderByDescending(x => x.Value.Count())
                .ThenBy(x => x.Key)
                .ToArray())
            {
                if (elemnet.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {elemnet.Key}, Members: {elemnet.Value.Count()}");

                    foreach (var members in elemnet.Value
                    .OrderBy(x => x)
                    .ToArray())
                    {
                        Console.WriteLine($"! {members}");
                    }
                }
            }
        }
    }
}
